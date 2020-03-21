using Managegment.Controllers;
using Management.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Management.Controllers
{
    [Produces("application/json")]
    [Route("Api/Admin/AppApi")]
    public class AppAPI : Controller
    {
        private Helper help;

        private readonly Tranim_LearningContext db;

        public AppAPI(Tranim_LearningContext context)
        {
            this.db = context;
            help = new Helper();
        }


        [HttpGet("GetAds")]
        public IActionResult GetAds(int pageNo=1, int pageSize=20,short Status=1)
        {

            try
            {
                var adds = from p in db.Ads where p.Status == Status select p;


                var Count = (from p in adds select p).Count();

                var AdsInfo = (from p in adds
                               orderby p.CreatedOn descending
                               select new
                               {
                                   id = p.Id,
                                   Subject = p.Subject,
                                   Post = p.Post,
                                   Status = p.Status,
                                   createdOn = p.CreatedOn,
                                   image=p.Image
                               }).Skip((pageNo - 1) * pageSize).Take(pageSize).ToList();

                return Ok(new { adss = AdsInfo, count = Count });
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }



        [HttpGet("getSubject")]
        public IActionResult getSubject(int yearId)
        {
            try
            {
                var subject = from p in db.Subjects
                              where p.Status != 9 && p.AcadimecYearId == yearId
                              select p;

                return Ok(new { Subject = subject });
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("getShpater")]
        public IActionResult getShpater( long subjectId)
        {
            try
            {
                var Shapters = from p in db.Shapters where p.Status != 9 && p.SubjectId == subjectId select p;


                var ShpaterInfo = (from p in Shapters
                                   orderby p.CreatedOn descending
                                   select new
                                   {
                                       id = p.Id,
                                       name = p.Name,
                                       Number = p.Number,
                                       createdOn = p.CreatedOn
                                   }).ToList();

                return Ok(new { shapter = ShpaterInfo});
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("getLectures")]
        public IActionResult getLectures(long shpaterid)
        {
            try
            {
                var LecturesInfo = from p in db.Lectures where p.Status != 9 && p.ShaptersId == shpaterid select p;

                var LectureInfo = (from p in LecturesInfo
                                   orderby p.CreatedOn descending
                                   select new
                                   {
                                       id = p.Id,
                                       Name = p.Name,
                                       Number = p.Number,
                                       Description = p.Description,
                                       CreatedOn = p.CreatedOn,
                                       image=p.LectureImage.ToList(),
                                       Video = p.VideoFile.ToString(),
                                       pdf=p.AttashmentFile,
                                       sound=p.SoundFile.ToString()
                                   }).ToList();

                return Ok(new { lectures = LectureInfo });
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }



    }
}
