using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Management.DTOs;
using Management.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Managegment.Controllers
{

    [Produces("application/json")]
    [Route("api/Admin/Messages")]
    public class MessagesController : Controller
    {
        private readonly MailSystemContext db;
        private Helper help;

        public MessagesController(MailSystemContext context)
        {
            this.db = context;
            help = new Helper();
        }

        [HttpGet("GetReceivedMassage")]
        public IActionResult GetReceivedMassage(int pageNo, int pageSize, int operateion)
        {
            try
            {
                //0-reseved
                //1-sent
                //2-archive
                //3-delete
                var userId = this.help.GetCurrentUser(HttpContext);

                var praticipations = (from p in db.Participations select p);
                var count = 0;

                if (operateion == 0)
                {
                    praticipations = (from p in db.Participations
                                      where
                                      p.IsDelete ==0 &&
                                      p.RecivedBy == userId &&
                                      p.Status != 0 &&
                                      p.Status != 3 &&
                                      p.Status != 4 &&
                                      p.Status != 6
                                      select p);
                }
                else if (operateion == 1)
                {
                    praticipations = (from p in db.Participations
                                      where
                                      p.SentBy == userId
                                      && p.IsDelete ==0 &&
                                      p.Status != 0 &&
                                      p.Status != 3 &&
                                      p.Status != 4 &&
                                      p.Status != 6
                                      select p);

                }
                else if (operateion == 2)
                {
                    praticipations = (from p in db.Participations
                                      where
                                      p.IsDelete ==0 &&
                                      (p.SentBy == userId || p.RecivedBy == userId) &&
                                      p.Status == 0 ||
                                      p.Status == 3 ||
                                      p.Status == 4 ||
                                      p.Status == 6
                                      select p);
                }
                else if (operateion == 3)
                {
                    praticipations = (from p in db.Participations where p.IsDelete == 1 && p.DeletedBy== userId select p);
                }



                var praticiapationsCount = praticipations.Count();

                var praticipationsList = (from p in praticipations
                                          orderby p.CreatedOn descending
                                          select new
                                          {
                                              ParticipationsId = p.ParticipationsId,
                                              ConversationId = p.ConversationId,
                                              SentBy = p.SentBy,
                                              SentName = p.SentByNavigation.FullName,
                                              Status = p.Status,
                                              CreatedOn = p.CreatedOn,
                                              is_Delete = p.IsDelete,
                                              AdType = p.Conversation.MessageType.Name,
                                              Body = help.GetPlainTextFromHtml(p.Conversation.Body),
                                              BodyWithHtml = p.Conversation.Body,
                                              Priolti = p.Conversation.Priolti,
                                              Subject = p.Conversation.Subject,
                                              MassageCreatedOn = p.Conversation.CreatedOn,
                                              Is_Replay = p.Conversation.IsGroup

                                          }).Skip((pageNo - 1) * pageSize).Take(pageSize).ToList();

                //var result = praticipationsList.GroupBy(test => test.ConversationId)
                //         .Select(grp => grp);
                return Ok(new { praticipations = praticipationsList, count= praticiapationsCount /*result.Skip((pageNo - 1) * pageSize).Take(pageSize), count = result.Count() */});
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }


        [HttpPost("ChangeMassageState")]
        public IActionResult ChangeMassageState(long ParticipationsId, short status)
        {
            try
            {
                var userId = this.help.GetCurrentUser(HttpContext);

                if (userId <= 0)
                {
                    return StatusCode(401, "Please make sure you are logged-in");
                }

                var Massage = (from p in db.Participations where p.ParticipationsId == ParticipationsId select p).SingleOrDefault();

                if (null == Massage)
                {
                    return NotFound("ERROR: The Massage does not exist");
                }

                Participations participations = Massage;

                Massage.Status = status;
                db.SaveChanges();
                return Ok("تم تغير حالة الرسالة بنجاح");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

  

        [HttpPost("DeleteMassage")]
        public IActionResult DeleteMassage(long ParticipationsId, bool removeFromTrash)
        {
            try
            {
                var userId = this.help.GetCurrentUser(HttpContext);

                if (userId <= 0)
                {
                    return StatusCode(401, "Please make sure you are logged-in");
                }

                var Massage = (from p in db.Participations where p.ParticipationsId == ParticipationsId select p).SingleOrDefault();

                if (null == Massage)
                {
                    return NotFound("ERROR: The Massage does not exist");
                }

                Participations participations = Massage;

                if(removeFromTrash)
                {
                    Massage.IsDelete = 2;
                }
                else
                {
                    
                    Massage.IsDelete = 1;
                }
                Massage.DeletedBy = userId;
                db.SaveChanges();
                return Ok("تم حذف الرسالة بنجاح");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("GetReplayes")]
        public IActionResult GetReplayes(int pageNo, int pageSize, long conversationId)
        {
            try
            {
                var userId = this.help.GetCurrentUser(HttpContext);

                var Replayes = (from p in db.Messages where p.ConversationId == conversationId select p);

                var ReplayesCount = (from p in Replayes
                                     select p).Count();

                var Attachment=(from p in db.Attachments where p.ConversationId==conversationId select
                                new { FileName=p.FileName,
                                      AttachmentId=p.AttachmentId,
                                      ContentFile =p.ContentFile,
                                      UserName=p.CreatedByNavigation.LoginName,
                                      CreatedOn=p.CreatedOn,
                                      Extension=p.Extension});


                var ReplayesList = (from p in Replayes
                                    orderby p.MessageId descending
                                    select new
                                    {
                                        Subject = p.Subject,
                                        SentName = p.Author.FullName,
                                        DateTime = p.DateTime,
                                        MassageCreatedOn = p.Conversation.CreatedOn,
                                        AuthorId = p.AuthorId

                                    }).Skip((pageNo - 1) * pageSize).Take(pageSize).ToList();

                return Ok(new { ReplayesLists = ReplayesList, count = ReplayesCount , Attachments= Attachment });
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost("AddReplay")]
        public IActionResult AddReplay(long conversationId, string ReplayBody)
        {
            try
            {
                var userId = this.help.GetCurrentUser(HttpContext);

                if (userId <= 0)
                {
                    return StatusCode(401, "Please make sure you are logged-in");
                }

                var Massage = (from p in db.Messages where p.ConversationId == conversationId select p);

                if (null == Massage)
                {
                    return NotFound("ERROR: The Massage does not exist");
                }

                Messages messages = new Messages();

                messages.DateTime = DateTime.Now;
                messages.AuthorId = userId;
                messages.ConversationId = conversationId;
                messages.Subject = ReplayBody;
                db.Messages.Add(messages);
                db.SaveChanges();
                return Ok("تم إضافة الرد بنجاح");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

    }
}