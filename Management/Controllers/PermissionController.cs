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
        [HttpGet("IsPermissin")]
        public IActionResult IsPermissin(string perimm)
        {
            try
            {
                var perm = getPermissin(perimm);
                if (perm)
                {
                    return StatusCode(200, "تملك الصلاحية");
                }
                else
                {
                    return StatusCode(401, "الرجاء الـتأكد من أنك قمت بتسجيل الدخول");
                }
                
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost("addPermissionName")]
        public IActionResult addPermissionName([FromBody] PermissionObj form)
        {
            try
            {
                var perm = getPermissin("Permissions_Add");
                if (!perm)
                {
                    return StatusCode(401, "لا تملك الصلاحية");
                }
              
                if (form == null)
                {
                    return BadRequest("حذث خطأ في ارسال البيانات الرجاء إعادة الادخال");
                }

                var userId = this.help.GetCurrentUser(HttpContext);

                if (userId <= 0)
                {
                    return StatusCode(401, "الرجاء الـتأكد من أنك قمت بتسجيل الدخول");
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

        [HttpGet("GetPermissionsInfo")]
        public IActionResult GetPermissionsInfo(int pageNo, int pageSize)
        {
            try
            {
                var perm = getPermissin("Permissions_View");
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
        public bool getPermissin(string perimm)
        {
            try
            {
                var userId = this.help.GetCurrentUser(HttpContext);

                if (userId <= 0)
                {
                    return (false);
                }
                var cUser = (from p in db.Users
                             where p.Id == userId
                             select p).SingleOrDefault();

                var pre = (from p in db.Permissions
                           join g in db.PermissionGroup on p.Id equals g.PermissioinId
                           where (g.GroupId == cUser.GroupId)
                           select p.Name).ToList();
                var t = pre.Contains(perimm);
                return (t);
               // string dogCsv = string.Join(",", pre.ToArray());

            }
            catch (Exception e)
            {
                return (false);
            }
        }
    }
}
