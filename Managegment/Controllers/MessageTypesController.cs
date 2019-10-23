using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Managegment.Controllers;
using Management.Models;
using Management.Controllers;

using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Management.Controllers
{
    [Produces("application/json")]
    [Route("Api/Admin/MessageTypes")]
    public class MessageTypesController : Controller
    {
        private readonly MailSystemContext db;
        private Helper help;
        public MessageTypesController(MailSystemContext context)
        {
            this.db = context;
            help = new Helper();
        }

        [HttpGet("Get")]
        public IActionResult Get(int pageNo, int pageSize)
        {
            try
            {

                IQueryable<MessageType> MessageTypeQuery;

                MessageTypeQuery = from p in db.MessageType
                               select p;

                var MessageTypeCount = (from p in MessageTypeQuery
                                    select p).Count();

                var MessageTypeList = (from p in MessageTypeQuery

                                   select new MessageType
                                   {
                                       Name=p.Name,
                                       Description=p.Description,
                                       CreatedOn=p.CreatedOn,
                                       MessageTypeId=p.MessageTypeId
                                   }).Skip((pageNo - 1) * pageSize).Take(pageSize).ToList();

                return Ok(new { MessageType = MessageTypeList, count = MessageTypeCount });
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost("Add")]
        public IActionResult AddMessageType([FromBody] MessageType AddMessageType)
        {
            try
            {
                if (AddMessageType == null)
                {
                    return BadRequest("حذث خطأ في ارسال البيانات الرجاء إعادة الادخال");

                }

                var userId = this.help.GetCurrentUser(HttpContext);

                if (userId <= 0)
                {
                    return StatusCode(401, "الرجاء الـتأكد من أنك قمت بتسجيل الدخول");
                }

                AddMessageType.CreatedBy = userId;
                AddMessageType.CreatedOn = DateTime.Now;
                AddMessageType.Status = 1;
                db.MessageType.Add(AddMessageType);
                db.SaveChanges();
                return Ok("لقد قمت بتسـجيل نوع الرساله بنــجاح");

            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost("Edit")]
        public IActionResult EditMessageType([FromBody] MessageType EditMessageType)
        {
            try
            {
                var userId = this.help.GetCurrentUser(HttpContext);

                if (userId <= 0)
                {
                    return StatusCode(401, "الرجاء الـتأكد من أنك قمت بتسجيل الدخول");
                }

                var MessageTypePayLoad = (from p in db.MessageType
                               where p.MessageTypeId == EditMessageType.MessageTypeId
                               select p).SingleOrDefault();

                if (MessageTypePayLoad == null)
                {
                    return BadRequest("حذث خطأ في ارسال البيانات الرجاء إعادة الادخال");

                }

                MessageTypePayLoad.Name = EditMessageType.Name;
                MessageTypePayLoad.Description = EditMessageType.Description;
                MessageTypePayLoad.ModifiedBy = userId;
                MessageTypePayLoad.ModifiedOn = DateTime.Now;

                db.SaveChanges();
                return Ok("تم تعديل بيانات نوع الرسالة بنجاح");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);

            }
        }

    }
}