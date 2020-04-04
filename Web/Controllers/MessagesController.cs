using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Web.Models;

namespace Web.Controllers
{
    [Produces("application/json")]
    [Route("Api/Web/Messages")]
    public class MessagesController : Controller
    {
        private readonly SmartEducationContext db;
        private Helper help;
        public MessagesController(SmartEducationContext context)
        {
            this.db = context;
            help = new Helper();
        }


        public class MessageContent
        {
            public long? SentByStudent { get; set; }
            public long RecivedByStudent { get; set; }
            public string Subject { get; set; }
            public string Payload { get; set; }

        }

        //SentMessage
        [HttpPost("SentMessage")]
        public IActionResult SentMessage([FromBody] MessageContent Message)
        {
            try
            {
                if (Message == null)
                {
                    return BadRequest("حذث خطأ في ارسال البيانات الرجاء إعادة الادخال");
                }

                var userId = this.help.GetCurrentUser(HttpContext);
                if (userId <= 0)
                {
                    return BadRequest("لا يمكنك الوصول لهذه الصفحة , الرجاء تسجيل الدخول");
                }

                Messages MS = new Messages();
                MS.CreatedBy = userId;
                MS.CreatedOn = DateTime.Now;
                MS.Payload = Message.Payload;
                MS.Subject = Message.Subject;

                db.Messages.Add(MS);

                MessageTransaction MT = new MessageTransaction();
                MT.SentByStudent = userId;
                MT.RecivedByStudent = Message.RecivedByStudent;
                MT.MessageId = MS.MesssageId;
                MT.CreatedBy = userId;
                MT.CreatedOn = DateTime.Now;
                MT.IsRead = 1;

                db.MessageTransaction.Add(MT);
                db.SaveChanges();

                return Ok("لقد قمت بإرسال الرسالة بنـجاح");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }


        [HttpGet("GetInbox")]
        public IActionResult GetInbox(int pageNo, int pageSize)
        {
            try
            {
                var userId = this.help.GetCurrentUser(HttpContext);
                if (userId <= 0)
                {
                    return BadRequest("لايمكن الوصول الي الصفحة , الرجاء تسجيل دخول");
                }

                var MessagesQuery = from p in db.MessageTransaction
                                    where p.RecivedByStudent == userId
                                    select p;

                var MessagesCount = (from p in MessagesQuery
                                           select p).Count();

                var InboxList = (from p in MessagesQuery
                                          orderby p.CreatedOn descending
                                          select new
                                          {
                                             p.Message.Subject,
                                             p.Message.Payload,
                                             p.MessageTransactionId,
                                             p.Message.MesssageId,
                                             p.SentByStudent,
                                             p.IsRead,
                                             p.CreatedOn,
                                             SentBy = db.Students.Where(x=>x.Id == p.SentByStudent).SingleOrDefault()
                                          }).Skip((pageNo - 1) * pageSize).Take(pageSize).ToList();
                return Ok(new { Inbox = InboxList, count = MessagesCount });
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }


        [HttpGet("GetSentMessage")]
        public IActionResult GetSentMessage(int pageNo, int pageSize)
        {
            try
            {
                var userId = this.help.GetCurrentUser(HttpContext);
                if (userId <= 0)
                {
                    return BadRequest("لايمكن الوصول الي الصفحة , الرجاء تسجيل دخول");
                }

                var MessagesQuery = from p in db.MessageTransaction
                                    where p.SentByStudent == userId
                                    select p;

                var MessagesCount = (from p in MessagesQuery
                                     select p).Count();

                var InboxList = (from p in MessagesQuery
                                 orderby p.CreatedOn descending
                                 select new
                                 {
                                     p.Message.Subject,
                                     p.Message.Payload,
                                     p.MessageTransactionId,
                                     p.Message.MesssageId,
                                     p.SentByStudent,
                                     p.IsRead,
                                     RecivedBy = db.Students.Where(x => x.Id == p.RecivedByStudent).SingleOrDefault(),
                                     p.CreatedOn
                                 }).Skip((pageNo - 1) * pageSize).Take(pageSize).ToList();
                return Ok(new { SentMessage = InboxList, count = MessagesCount });
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

    }
}