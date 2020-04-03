using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Managegment.Controllers;
using Management.Models;
using Management.objects;
using Microsoft.AspNetCore.Mvc;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Management.Controllers
{
    [Produces("application/json")]
    [Route("Api/Admin/Permission")]
    public class PermissionController : Controller
    {
        private readonly SmartEducationContext db;
        private Helper help;
        public PermissionController(SmartEducationContext context)
        {
            this.db = context;
            help = new Helper();
        }
        //[HttpGet("IsPermissin")]
        //public IActionResult IsPermissin(string perimm)
        //{
        //    try
        //    {
        //        var perm = getPermissin(perimm);
        //        if (perm)
        //        {
        //            return StatusCode(200, "تملك الصلاحية");
        //        }
        //        else
        //        {
        //            return StatusCode(401, "الرجاء الـتأكد من أنك قمت بتسجيل الدخول");
        //        }
                
        //    }
        //    catch (Exception e)
        //    {
        //        return StatusCode(500, e.Message);
        //    }
        //}

        [HttpPost("addPermissionName")]
        public IActionResult addPermissionName([FromBody] PermissionObj form)
        {
            try
            {
                var userId = this.help.GetCurrentUser(HttpContext);
                if (userId <= 0)
                {
                    return StatusCode(401, "الرجاء الـتأكد من أنك قمت بتسجيل الدخول");
                }
                var perm = this.help.getPermissin("Permissions_Add", userId, db);
                if (!perm)
                {
                    return StatusCode(401, "لا تملك الصلاحية");
                }
           
              
                if (form == null)
                {
                    return BadRequest("حذث خطأ في ارسال البيانات الرجاء إعادة الادخال");
                }


                

                var Years = (from p in db.Permissions where p.Name == form.name select p).SingleOrDefault();

                if (Years != null)
                {
                    return StatusCode(401, "الاسم موجود مسبقا");
                }

                Permissions pre = new Permissions();
                pre.Name = form.name;
                pre.State = 1;
                pre.CreatedBy = userId;
                pre.CreatedOn = DateTime.Now;
                db.Permissions.Add(pre);
                db.SaveChanges();

                return Ok("تمت عملية الاضافة بنجاح");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        [HttpPost("addGroup")]
        public IActionResult addGroup([FromBody] PermissionObj form)
        {
            try
            {
                var userId = this.help.GetCurrentUser(HttpContext);
                if (userId <= 0)
                {
                    return StatusCode(401, "الرجاء الـتأكد من أنك قمت بتسجيل الدخول");
                }
                var perm = this.help.getPermissin("Groups_Add", userId, db);
                if (!perm)
                {
                    return StatusCode(401, "لا تملك الصلاحية");
                }
           

                if (form == null)
                {
                    return BadRequest("حذث خطأ في ارسال البيانات الرجاء إعادة الادخال");
                }


                

                var Groups = (from p in db.Groups where p.Name == form.name select p).SingleOrDefault();

                if (Groups != null)
                {
                    return StatusCode(401, "الاسم موجود مسبقا");
                }

                Groups gr = new Groups();
                gr.Name = form.name;
                gr.State = 1;
                gr.CreatedBy = userId;
                gr.CreatedOn = DateTime.Now;
                db.Groups.Add(gr);
                foreach(var item in form.id)
                {
                    var h = item;
                    PermissionGroup pg = new PermissionGroup();
                    pg.PermissioinId = item;
                    pg.GroupId = gr.Id;
                    pg.CreatedBy = userId;
                    pg.CreatedOn = DateTime.Now;
                    pg.State = 1;
                    db.PermissionGroup.Add(pg);
                }
                db.SaveChanges();
                return Ok("تمت عملية الاضافة بنجاح");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpGet("GetPermissions")]
        public IActionResult GetPermissions()
        {
            try
            {
                var userId = this.help.GetCurrentUser(HttpContext);
                if (userId <= 0)
                {
                    return StatusCode(401, "الرجاء الـتأكد من أنك قمت بتسجيل الدخول");
                }
                var perm = this.help.getPermissin("Permissions_View", userId, db);
                if (!perm)
                {
                    return StatusCode(401, "لا تملك الصلاحية");
                }

             
                var PermissionInof = from p in db.Permissions where p.State != 9 select p;

                

                return Ok(new { Permission = PermissionInof.ToList()});
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }


        [HttpGet("GetPermissionsInfo")]
        public IActionResult GetPermissionsInfo(int pageNo, int pageSize)
        {
            try
            {
                var userId = this.help.GetCurrentUser(HttpContext);
                if (userId <= 0)
                {
                    return StatusCode(401, "الرجاء الـتأكد من أنك قمت بتسجيل الدخول");
                }
                var perm = this.help.getPermissin("Permissions_View", userId, db);
                if (!perm)
                {
                    return StatusCode(401, "لا تملك الصلاحية");
                }
                var PermissionInof = from p in db.Permissions where p.State != 9 select p;

                var Count = (from p in PermissionInof select p).Count();

                var PermInof = (from p in PermissionInof
                                orderby p.CreatedOn descending
                                select new
                                {
                                    id = p.Id,
                                    name = p.Name,
                                    createdOn = p.CreatedBy,
                                    createdBy = p.CreatedOn
                                }).Skip((pageNo - 1) * pageSize).Take(pageSize).ToList();

                return Ok(new { Permission = PermInof, count = Count });
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        [HttpGet("GetGroupInfo")]
        public IActionResult GetGroupInfo(int pageNo, int pageSize)
        {
            try
            {
                var userId = this.help.GetCurrentUser(HttpContext);
                var perm = this.help.getPermissin("Groups_View", userId,db);
                if (!perm)
                {
                    return StatusCode(401, "لا تملك الصلاحية");
                }
                var GroupInfo = from p in db.Groups where p.State != 9 select p;

                var Count = (from p in GroupInfo select p).Count();

                var group = (from p in GroupInfo
                                orderby p.CreatedOn descending
                                select new
                                {
                                    id = p.Id,
                                    name = p.Name,
                                    createdOn = p.CreatedBy,
                                    createdBy = p.CreatedOn
                                }).Skip((pageNo - 1) * pageSize).Take(pageSize).ToList();

                return Ok(new { group = group, count = Count });
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        [HttpGet("GetGroup")]
        public IActionResult GetGroup(int pageNo, int pageSize)
        {
            try
            {
                var userId = this.help.GetCurrentUser(HttpContext);
                if (userId <= 0)
                {
                    return StatusCode(401, "الرجاء الـتأكد من أنك قمت بتسجيل الدخول");
                }
                var perm = this.help.getPermissin("Groups_View", userId, db);
                if (!perm)
                {
                    return StatusCode(401, "لا تملك الصلاحية");
                }
               
                var GroupInfo = from p in db.Groups where p.State != 9 select p;

                

                return Ok(new { group = GroupInfo.ToList() });
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        //public bool getPermissin(string perimm)
        //{
        //    try
        //    {
        //        var userId = this.help.GetCurrentUser(HttpContext);

        //        if (userId <= 0)
        //        {
        //            return (false);
        //        }
        //        var cUser = (from p in db.Users
        //                     where p.Id == userId
        //                     select p).SingleOrDefault();
        //        if (cUser.UserType == 1)
        //        {
        //            return (true);
        //        }
        //        var pre = (from p in db.Permissions
        //                   join g in db.PermissionGroup on p.Id equals g.PermissioinId
        //                   where (g.GroupId == cUser.GroupId)
        //                   select p.Name).ToList();

        //        var t = pre.Contains(perimm);
        //        return (t);
        //       // string dogCsv = string.Join(",", pre.ToArray());

        //    }
        //    catch (Exception e)
        //    {
        //        return (false);
        //    }
        //}
    }
}
