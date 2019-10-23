﻿using System;
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
    [Route("Api/Admin/Branches")]
    public class BranchesController : Controller
    {

        private readonly MailSystemContext db;
        private Helper help;
        public BranchesController(MailSystemContext context)
        {
            this.db = context;
            help = new Helper();
        }

        [HttpGet("Get")]
        public IActionResult Get(int pageNo, int pageSize,int BranchLevel)
        {
            try
            {


                IQueryable<Branches> BranchesQuery;


                if (BranchLevel == 0)
                {
                    BranchesQuery = from p in db.Branches
                                    where p.Status == 1
                                    select p;
                }
                else
                {
                   
                    BranchesQuery = from p in db.Branches
                                    where p.Status == 1 && p.BranchLevel== BranchLevel
                                    select p;
                }

                var BranchesCount = (from p in BranchesQuery
                                      select p).Count();

                var BranchesList = (from p in BranchesQuery
                                    orderby p.CreatedOn descending
                                     select new Branches
                                     {
                                         Name = p.Name,
                                         Description = p.Description,
                                         CreatedOn = p.CreatedOn,
                                         Status = p.Status,
                                         BranchId = p.BranchId,
                                         BranchLevel = p.BranchLevel

                                     }).Skip((pageNo - 1) * pageSize).Take(pageSize).ToList();

                return Ok(new { Branches = BranchesList, count = BranchesCount });
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("GetBranchs")]
        public IActionResult GetBranches()
        {
            try
            {

                IQueryable<Branches> BranchesQuery;

                BranchesQuery = from p in db.Branches
                                where p.Status == 1
                                select p;  
               
                var BranchesList = (from p in BranchesQuery
                                    orderby p.CreatedOn descending
                                    select new Branches
                                    {
                                        Name = p.Name, 
                                        BranchId = p.BranchId

                                    }).ToList();

                return Ok(new { Branches = BranchesList });
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }


        [HttpPost("{BranchId}/delete")]
        public IActionResult DeleteBranch(long BranchId)
        {
            try
            {
                var userId = this.help.GetCurrentUser(HttpContext);

                if (userId <= 0)
                {
                    return StatusCode(401, "Please make sure you are logged-in");
                }

                var Branch = (from p in db.Branches
                               where p.BranchId == BranchId
                               && (p.Status == 1)
                               select p).SingleOrDefault();

                if (Branch == null)
                {
                    return NotFound("ERROR: The country does not exist");
                }

                Branch.Status = 9;
                Branch.ModifiedBy = userId;
                Branch.ModifiedOn = DateTime.Now;
                db.SaveChanges();
                return Ok("لقد قمت بمسح الفرع بنـجاح");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost("Add")]
        public IActionResult AddBranches([FromBody] Branches Branch)
        {
            try
            {
                if (Branch == null)
                {
                    return BadRequest("حذث خطأ في ارسال البيانات الرجاء إعادة الادخال");
          
                }

                var userId = this.help.GetCurrentUser(HttpContext);

                if (userId <= 0)
                {

                    return StatusCode(401, "الرجاء الـتأكد من أنك قمت بتسجيل الدخول");
            
                }

                Branch.CreatedBy = userId;
                Branch.CreatedOn = DateTime.Now;
                Branch.Status = 1;
                db.Branches.Add(Branch);
                db.SaveChanges();
                return Ok("لقد قمت بتسـجيل الاداره بنــجاح");
         
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }


        [HttpPost("Edit")]
        public IActionResult EditBranches([FromBody] Branches Branch)
        {
            try
            {
                var userId = this.help.GetCurrentUser(HttpContext);

                if (userId <= 0)
                {
                    return StatusCode(401, "الرجاء الـتأكد من أنك قمت بتسجيل الدخول");
                }

                var Branches = (from p in db.Branches
                                     where p.BranchId == Branch.BranchId
                                     && (p.Status == 1)
                                     select p).SingleOrDefault();

                if (Branches == null)
                {
                    return BadRequest("حذث خطأ في ارسال البيانات الرجاء إعادة الادخال");

                }

                Branches.Name =  Branch.Name;
                Branches.Description =  Branch.Description;
                Branches.Status = 1;
                Branches.ModifiedBy = userId;
                Branches.ModifiedOn = DateTime.Now;
                db.SaveChanges();
                return Ok("تم تعديل بيانات الاداره بنجاح");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }


        [HttpGet("GetBranchesByLevel")]
        public IActionResult GetBranchesByLevel(short branchLevel)
        {
            try
            {

                IQueryable<Branches> BranchesQuery;

                BranchesQuery = from p in db.Branches
                                where p.Status == 1 && p.BranchLevel==branchLevel
                                select p;

                var BranchesList = (from p in BranchesQuery
                                    orderby p.CreatedOn descending
                                    select new Branches
                                    {
                                        Name = p.Name,
                                        BranchId = p.BranchId

                                    }).ToList();

                return Ok(new { Branches = BranchesList });
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }




    }
}