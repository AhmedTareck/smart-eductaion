using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Principal;
using Common;

using System.Net.Mail;
using Web.Models;
using Managegment.Controllers;
using Web.Controllers;

namespace Management.Controllers
{
    public class SecurityController : Controller
    {
        [TempData]
        public string ErrorMessage { get; set; }
        private Helper help;
        private readonly SmartEducationContext db;
        private IConfiguration Configuration { get; }
        public SecurityController(SmartEducationContext context, IConfiguration configuration)
        {
            this.db = context;
            help = new Helper();
            Configuration = configuration;
        }


        [AllowAnonymous]
        [HttpPost]
        public IActionResult SignupStudent([FromBody] Students student)
        {
            try
            {
                if (student == null)
                {
                    return BadRequest("Error sending data please re-enter");
                }

                if (string.IsNullOrWhiteSpace(student.FirstName))
                {
                    return BadRequest("الرجاء إدخال الاسم");
                }

                if (string.IsNullOrWhiteSpace(student.FatherName))
                {
                    return BadRequest("الرجاء إدخال اسم الاب");
                }

                if (string.IsNullOrWhiteSpace(student.GrandFatherName))
                {
                    return BadRequest("الرجاء إدخال إسم الجد");
                }

                if (string.IsNullOrWhiteSpace(student.SurName))
                {
                    return BadRequest("الرجاء إدخال اللفب");
                }


                if (!Validation.IsValidEmail(student.Email))
                {
                    return BadRequest("الرجاء إدخال البريد الإلكتروني بطريقة الصحيحة");
                }

                if (student.Gender == null && student.Gender != 1 && student.Gender != 2)
                {
                    return BadRequest("الرجاء إدخال الجنس بطريقة صح");

                }
                if (string.IsNullOrWhiteSpace(student.BirthDate.ToString()))
                {
                    return BadRequest("الرجاء إختيار تاريخ الميلاد");
                }
                if ((DateTime.Now.Year - student.BirthDate.Value.Year) < 10)
                {
                    return BadRequest("يجب ان يكون تاريخ ميلاد الطالب اكبر من 10 سنوات");
                }

                var cUser = (from u in db.Students
                             where u.Email == student.Email && u.Status != 9 && u.Status!=3
                             select u).SingleOrDefault();

                if (cUser != null)
                {
                    if (cUser.Status == 0)
                    {
                        return BadRequest("هذا البريد مسجل من قبل وتم قفله نهائيا");
                    }
                    if (cUser.Status == 1 || cUser.Status == 2)
                    {
                        return BadRequest("هذا البريد مسجل من قبل الرجاء الإتصال بالإدارة");
                    }
                }

                if (student.photo == null)
                {
                    student.Image = Convert.FromBase64String("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////////////////////////////A+gAAAAA/////////////////////////////wPoAAAAAP////////////////////////////8D6AAAAAD/////////////////////////////A+gAADhCSU0EAAAAAAAAAgAAOEJJTQQCAAAAAAACAAA4QklNBDAAAAAAAAEBADhCSU0ELQAAAAAABgABAAAAAjhCSU0ECAAAAAAAEAAAAAEAAAJAAAACQAAAAAA4QklNBB4AAAAAAAQAAAAAOEJJTQQaAAAAAANJAAAABgAAAAAAAAAAAAAAjAAAAIwAAAAKAFUAbgB0AGkAdABsAGUAZAAtADEAAAABAAAAAAAAAAAAAAAAAAAAAAAAAAEAAAAAAAAAAAAAAIwAAACMAAAAAAAAAAAAAAAAAAAAAAEAAAAAAAAAAAAAAAAAAAAAAAAAEAAAAAEAAAAAAABudWxsAAAAAgAAAAZib3VuZHNPYmpjAAAAAQAAAAAAAFJjdDEAAAAEAAAAAFRvcCBsb25nAAAAAAAAAABMZWZ0bG9uZwAAAAAAAAAAQnRvbWxvbmcAAACMAAAAAFJnaHRsb25nAAAAjAAAAAZzbGljZXNWbExzAAAAAU9iamMAAAABAAAAAAAFc2xpY2UAAAASAAAAB3NsaWNlSURsb25nAAAAAAAAAAdncm91cElEbG9uZwAAAAAAAAAGb3JpZ2luZW51bQAAAAxFU2xpY2VPcmlnaW4AAAANYXV0b0dlbmVyYXRlZAAAAABUeXBlZW51bQAAAApFU2xpY2VUeXBlAAAAAEltZyAAAAAGYm91bmRzT2JqYwAAAAEAAAAAAABSY3QxAAAABAAAAABUb3AgbG9uZwAAAAAAAAAATGVmdGxvbmcAAAAAAAAAAEJ0b21sb25nAAAAjAAAAABSZ2h0bG9uZwAAAIwAAAADdXJsVEVYVAAAAAEAAAAAAABudWxsVEVYVAAAAAEAAAAAAABNc2dlVEVYVAAAAAEAAAAAAAZhbHRUYWdURVhUAAAAAQAAAAAADmNlbGxUZXh0SXNIVE1MYm9vbAEAAAAIY2VsbFRleHRURVhUAAAAAQAAAAAACWhvcnpBbGlnbmVudW0AAAAPRVNsaWNlSG9yekFsaWduAAAAB2RlZmF1bHQAAAAJdmVydEFsaWduZW51bQAA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IkFkb2JlIFhNUCBDb3JlIDUuNi1jMTExIDc5LjE1ODMyNSwgMjAxNS8wOS8xMC0wMToxMDoyMCAgICAgICAgIj4gPHJkZjpSREYgeG1sbnM6cmRmPSJodHRwOi8vd3d3LnczLm9yZy8xOTk5LzAyLzIyLXJkZi1zeW50YXgtbnMjIj4gPHJkZjpEZXNjcmlwdGlvbiByZGY6YWJvdXQ9IiIgeG1sbnM6eG1wPSJodHRwOi8vbnMuYWRvYmUuY29tL3hhcC8xLjAvIiB4bWxuczp4bXBNTT0iaHR0cDovL25zLmFkb2JlLmNvbS94YXAvMS4wL21tLyIgeG1sbnM6c3RFdnQ9Imh0dHA6Ly9ucy5hZG9iZS5jb20veGFwLzEuMC9zVHlwZS9SZXNvdXJjZUV2ZW50IyIgeG1sbnM6ZGM9Imh0dHA6Ly9wdXJsLm9yZy9kYy9lbGVtZW50cy8xLjEvIiB4bWxuczpwaG90b3Nob3A9Imh0dHA6Ly9ucy5hZG9iZS5jb20vcGhvdG9zaG9wLzEuMC8iIHhtcDpDcmVhdG9yVG9vbD0iQWRvYmUgUGhvdG9zaG9wIENDIDIwMTUgKFdpbmRvd3MpIiB4bXA6Q3JlYXRlRGF0ZT0iMjAxNy0xMi0wMVQxOTozNDoxNyswMjowMCIgeG1wOk1ldGFkYXRhRGF0ZT0iMjAxNy0xMi0wMVQxOTozNDoxNyswMjowMCIgeG1wOk1vZGlmeURhdGU9IjIwMTctMTItMDFUMTk6MzQ6MTcrMDI6MDAiIHhtcE1NOkluc3RhbmNlSUQ9InhtcC5paWQ6MmE0MzNlNTUtNzk5ZC00NTRlLWI1ZTUtYWIwNjFmOTUwNThhIiB4bXBNTTpEb2N1bWVudElEPSJhZG9iZTpkb2NpZDpwaG90b3Nob3A6ZDM3ZThiZTYtZDZiZC0xMWU3LWIxNWEtOTViY2JlMzViMTFhIiB4bXBNTTpPcmlnaW5hbERvY3VtZW50SUQ9InhtcC5kaWQ6ZjMzZTk0OWItYWNkYi04MjQxLWIxNTctNDgwNDEyMDdkMzNmIiBkYzpmb3JtYXQ9ImltYWdlL2pwZWciIHBob3Rvc2hvcDpDb2xvck1vZGU9IjMiIHBob3Rvc2hvcDpJQ0NQcm9maWxlPSJzUkdCIElFQzYxOTY2LTIuMSI+IDx4bXBNTTpIaXN0b3J5PiA8cmRmOlNlcT4gPHJkZjpsaSBzdEV2dDphY3Rpb249ImNyZWF0ZWQiIHN0RXZ0Omluc3RhbmNlSUQ9InhtcC5paWQ6ZjMzZTk0OWItYWNkYi04MjQxLWIxNTctNDgwNDEyMDdkMzNmIiBzdEV2dDp3aGVuPSIyMDE3LTEyLTAxVDE5OjM0OjE3KzAyOjAwIiBzdEV2dDpzb2Z0d2FyZUFnZW50PSJBZG9iZSBQaG90b3Nob3AgQ0MgMjAxNSAoV2luZG93cykiLz4gPHJkZjpsaSBzdEV2dDphY3Rpb249InNhdmVkIiBzdEV2dDppbnN0YW5jZUlEPSJ4bXAuaWlkOjJhNDMzZTU1LTc5OWQtNDU0ZS1iNWU1LWFiMDYxZjk1MDU4YSIgc3RFdnQ6d2hlbj0iMjAxNy0xMi0wMVQxOTozNDoxNyswMjowMCIgc3RFdnQ6c29mdHdhcmVBZ2VudD0iQWRvYmUgUGhvdG9zaG9wIENDIDIwMTUgKFdpbmRvd3MpIiBzdEV2dDpjaGFuZ2VkPSIvIi8+IDwvcmRmOlNlcT4gPC94bXBNTTpIaXN0b3J5PiA8L3JkZjpEZXNjcmlwdGlvbj4gPC9yZGY6UkRGPiA8L3g6eG1wbWV0YT4gICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICA8P3hwYWNrZXQgZW5kPSJ3Ij8+/+IMWElDQ19QUk9GSUxFAAEBAAAMSExpbm8CEAAAbW50clJHQiBYWVogB84AAgAJAAYAMQAAYWNzcE1TRlQAAAAASUVDIHNSR0IAAAAAAAAAAAAAAAEAAPbWAAEAAAAA0y1IUCAgAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA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");
                }
                else
                {
                    student.Image = Convert.FromBase64String(student.photo.Substring(student.photo.IndexOf(",") + 1));
                }
                //student.Password = Security.ComputeHash(student.Password, HashAlgorithms.SHA512, null);
                student.CreatedOn = DateTime.Now;
                // 0 - lock for ever - Blocked by admin
                // 1- active
                // 2- pending lock - lock by enter wrong password it can activate again
                // 3- level one register - first levet of registration before activate the account
                // 9- deleted
                student.Status = 3;
                db.Students.Add(student);
                db.SaveChanges();


                MailMessage mail = new MailMessage();

                mail.From = new MailAddress("noreply@codeexperts.ly");

                mail.To.Add(student.Email.ToString());

                string confirm = Security.ComputeHash(student.Id.ToString() + "@codeexperts.ly", HashAlgorithms.SHA512, null);

                mail.Subject = "اللبنة الذكية";

                mail.Body = GetFormattedMessageHTML(student.FirstName + " " + student.SurName, Configuration.GetSection("Links")["WebServer"] + "/security/AccountActivate?confirm=" + student.Id.ToString() + "&account=" + Security.EncryptBase64(confirm));

                mail.IsBodyHtml = true;

                var smtp = new SmtpClient(Configuration.GetSection("Links")["SMTPClient"])
                {
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential("noreply@codeexperts.ly", "abdullah1988!@#"),
                    Port = Int32.Parse(Configuration.GetSection("Links")["SMTPPORT"]),
                    EnableSsl = Configuration.GetSection("Links")["SMTSSL"] == "1"
                };

                smtp.Send(mail);
               // Task.Factory.StartNew(() => smtp.Send(mail));



                return Ok("Student saved successfully");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }


        public string GetFormattedMessageHTML(string UserName, string path)
        {

            string WebServer = Configuration.GetSection("Links")["WebServer"];
            string FaceBookPage = Configuration.GetSection("Links")["FaceBookPage"];
            string EmailSupport = Configuration.GetSection("Links")["EmailSupport"];


            return "<!DOCTYPE html>" +
                   "<html lang = \"ar\" dir = \"rtl\"><head><meta charset = \"UTF-8\"><style>" +
                   "div.wrapper{ margin: auto; margin-top:13vh; max-width:550px; }" +
                   "img{ width: 100 %; height: 45px; } footer{ width: 85 %; margin: auto; }" +
                    "p{ line-height: 1.4; text-align: justify; }" +
                  ".purple{color:#8f48d2;}.grey{ color: grey; }.padd{padding: 10px 5px; }" +
                  ".calibri{ font-family: Calibri, 'Trebuchet MS'; }.Helvetica{ font-family: Helvetica; font-size: 14.5px; }" +
                  "footer div { text-align: center; }" +
                  "body{ font-family: Arial; font-size:15.5px; }" +
                  "</style></head><body>" +
                  "<div class=\"wrapper\"><header></header><div class=\"padd\"><p> عزيزي الطالب<span>" + " " + UserName + " " + "</span></p>" +
            "<p>  مرحبا بكم في<span class=\"purple calibri\"><b><em> اللبنة الذكية</em></b></span> ، من أجل الانتهاء من إجراءات تسجيل حسابك الجديد على منصتنا اللبنة الذكية<b class=\"calibri\">Smart Education</b> ، يرجى التحقق من عنوان البريد الإلكتروني الخاص بك و تأكيده عن طريق النقر على الرابط أدناه :</p> " +
                 "<p>الرابط: <a href = \" " + path + "\" target=\"_blank\" > Click Here</a></p>" +
                 "<p>نشير هنا إلى أن عملية التحقق من هويتك في مرحلة ما،  لن تؤثر على معظم الأنشطة بحسابك.</p>" +
                 "<p>للحصول على آخر التحديثات ، ومعرفة آخر الأخبار ، بإمكانك الاطلاع على صفحتنا عبر<a href=\"" + FaceBookPage + "\" class=\"calibri\"><b>FaceBook</b></a> ، و إذا كان لديك أي أسئلة أخرى، الرجاء مراسلتنا عبر<a href = \"mailto:" + EmailSupport + "\" class=\"calibri\"><b>" + EmailSupport + "</b></a>  .</p>" +
                 "<br><p>فريق عمل مشروع<b>(اللبنة الذكية)</b> </p>" +
                "</div><footer class=\"Helvetica\"><div class=\"grey\"><a href = \"" + WebServer + "\"> visit our website</a> | <a href = \"" + WebServer + "\"> log in to your account</a> | <a href = \"mailto:" + EmailSupport + "\"> get support</a></div>" +
                "<div class=\"grey\"> All rights reserved ,مشروع اللبنة الذكية  Copyright © ACT</div></footer></div></body></html>";

        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult AccountActivate(string confirm, string account)
        {
            try
            {
                confirm = confirm + "@codeexperts.ly";
                account = Security.DecryptBase64(account);

                if (!Security.VerifyHash(confirm, account, HashAlgorithms.SHA512))
                {
                    return RedirectToAction(nameof(HomeController.Index), "Home");
                }
                else
                {
                    ViewData["ApiServer"] = Configuration.GetSection("Links")["ApiServer"];
                    return View();
                }
            }
            catch
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }



        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string returnUrl = null)
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }


        public class user
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }
        public class userPassword
        {
            public int UserId { get; set; }
            public string NewPassword { get; set; }
            public string Password { get; set; }
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> loginUser([FromBody] user loginUser)
        {
            try
            {
                if (loginUser == null)
                {
                    return NotFound("الرجاء ادخال البريد الالكتروني او اسم الدخول");
                }

                //if (!Validation.IsValidEmail(loginUser.Email))
                //{
                //    return BadRequest("Please enter correct email address");
                //}
                if (string.IsNullOrWhiteSpace(loginUser.Email))
                {
                    return BadRequest("الرجاء ادخال البريد الالكتروني او اسم الدخول");
                }

                if (string.IsNullOrWhiteSpace(loginUser.Password))
                {
                    return BadRequest("الرجاء ادخال كلمه المرور");
                }

                var cUser = (from p in db.Students
                             where (p.Email == loginUser.Email || p.LoginName == loginUser.Email) && p.Status != 9
                             select p).SingleOrDefault();

                if (cUser == null)
                {
                    return NotFound("الرجاء التاكد من البريد الالكتروني وكلمة المرور");

                }

               

                if (cUser.Status == 0)
                {
                    return BadRequest("تم قفل الحساب نهائيا");
                }

                if (cUser.Status == 2)
                {
                    return BadRequest("تم إغلاق الحساب مؤقتا للأسباب امنية");
                }

                if (!Security.VerifyHash(loginUser.Password, cUser.Password, HashAlgorithms.SHA512))
                {

                    //cUser.LoginTryAttempts++;
                    //if (cUser.LoginTryAttempts >= 5 && cUser.Status == 1)
                    //{
                    //    cUser.LoginTryAttemptDate = DateTime.Now;
                    //    cUser.Status = 2;
                    //}
                    //db.SaveChanges();
                    return NotFound("الرجاء التاكد من البريد الالكتروني وكلمة المرور");
                }

                //string hospital = "";
                //if (cUser.UserType == 5 && cUser.HospitalId != null && cUser.HospitalId > 0)
                //{
                //    hospital = db.Hospital.Where(x => x.HospitalId == cUser.HospitalId).SingleOrDefault().Name;
                //}

                db.SaveChanges();
                //long branchId = -1;
                // int branchType = -1;

                var userInfo = new
                {
                    userId = cUser.Id,
                    FirstName = cUser.FirstName,
                    FatherName = cUser.FatherName,
                    SurName = cUser.SurName,
                    GrandFatherName = cUser.GrandFatherName,
                    //branchId = branchId,
                    LoginName = cUser.LoginName,
                    Email = cUser.Email,
                    Gender = cUser.Gender,
                    Status = cUser.Status,
                    Phone = cUser.Phone,
                    BirthDate = cUser.BirthDate,
                    cUser.Nid,
                    School="مدرسة الفجر الجديد",//cUser.School.Name,
                    yearAcadimic ="السنة الدراسية 2018",//cUser.AcadimecYear.Name,
                    imge = (cUser.Image !=null? 1:0),
                    userType=8
                };

                const string Issuer = "http://www.nid.ly";
                var claims = new List<Claim>();
                claims.Add(new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/id", cUser.Id.ToString(), ClaimValueTypes.Integer64, Issuer));
                claims.Add(new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/userType","8", ClaimValueTypes.Integer64, Issuer));
                
                var userIdentity = new ClaimsIdentity("thisisasecreteforauth");
                userIdentity.AddClaims(claims);
                var userPrincipal = new ClaimsPrincipal(userIdentity);

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    userPrincipal,
                    new AuthenticationProperties
                    {
                        ExpiresUtc = DateTime.UtcNow.AddHours(1),
                        IsPersistent = true,
                        AllowRefresh = true
                    });

                return Ok(userInfo);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }


        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            try
            {
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500, "error while logout");
            }

        }
        [HttpPost]

        public IActionResult ChangePassword([FromBody] userPassword loginUser)
        {
            try
            {
                var userId = this.help.GetCurrentUser(HttpContext);
                if (loginUser.Password != null)
                {
                    var User = (from p in db.Users
                                where p.Status == userId && p.Status != 9
                                select p).SingleOrDefault();

                    if (Security.VerifyHash(loginUser.Password, User.Password, HashAlgorithms.SHA512))
                    {

                        User.Password = Security.ComputeHash(loginUser.NewPassword, HashAlgorithms.SHA512, null);
                        db.SaveChanges();


                    }
                    else
                    {
                        return BadRequest("الرجاء التاكد من كلمة المرور");
                    }
                }

                else
                {
                    var User = (from p in db.Users
                                where p.Id == loginUser.UserId && p.Status != 9
                                select p).SingleOrDefault();
                    if (User == null)
                    {
                        return BadRequest("خطأ بيانات المستخدم غير موجودة");
                    }
                    User.Password = Security.ComputeHash(loginUser.NewPassword, HashAlgorithms.SHA512, null);
                    db.SaveChanges();

                }
                return Ok("تمت عمليه تعديل بنجاح");
            }
            catch (Exception)
            {
                return StatusCode(500, "error while logout");
            }

        }
        [HttpGet]

        public IActionResult GetUserImage(long userId)
        {
            var userimage = (from p in db.Users
                             where p.Id == userId
                             select p.Image).SingleOrDefault();

            return File(userimage, "image/jpg");
        }

        public IActionResult Error()
        {
            ViewData["RequestId"] = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            return View();
        }

        public IActionResult Unsupported()
        {
            ViewData["RequestId"] = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            return View();
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }



        [HttpPost("Security/ResetPassword/{email}")]
        [AllowAnonymous]
        public IActionResult ResetPassword(string email)
        {
            try
            {

                if (!Validation.IsValidEmail(email))
                {
                    return BadRequest("الرجاء ادخال البريد الالكتروني بطريقة الصحيحه");
                }

                var user = (from p in db.Users
                            where p.Email == email && p.Status != 9
                            select p).SingleOrDefault();

                if (user == null)
                {
                    return NotFound("البريد الإلكتروني غير مسجل بالنظـام !");
                }

                if (user.Status == 0)
                {
                    return BadRequest("تم إيقاف هذا المستخدم من النظام !");
                }


                MailMessage mail = new MailMessage();

                mail.From = new MailAddress("noreply@cra.gov.ly");

                mail.To.Add(email);

                string confirm = Security.ComputeHash(user.Id.ToString() + "@cra.gov.ly", HashAlgorithms.SHA512, null);

                mail.Subject = "مصلحة الاحوال المدنية - إعادة تعيين كلمة المرور";

                mail.Body = GetResetPasswordHTML(user.Name, "/security/AccountActivate?confirm=" + user.Id.ToString() + "&account=" + Security.EncryptBase64(confirm));

                mail.IsBodyHtml = true;

                var smtp = new SmtpClient("webmail.cra.gov.ly")
                {
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential("noreply@cra.gov.ly", "Qwerty@!@#123"),
                    Port = Int32.Parse(Configuration.GetSection("Links")["SMTPPORT"]),
                    EnableSsl = Configuration.GetSection("Links")["SMTSSL"] == "1"
                };
                smtp.Send(mail);
                //Task.Factory.StartNew(() => smtp.Send(mail));
                return Ok("تم ارسال بريد التحقق بنجاح الرجاء فتح بريدك الإلكتروني");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);

            }
        }

        public class UserActivation
        {
            public string password { get; set; }
            public string cpassword { get; set; }
            public int confirm { get; set; }
            public string account { get; set; }
        }

        [AllowAnonymous]
        [HttpPost("Security/ActivateUser")]
        public IActionResult ActivateUser([FromBody] UserActivation userActivate)
        {
            try
            {
                if (!Security.VerifyHash(userActivate.confirm.ToString() + "@codeexperts.ly", Security.DecryptBase64(userActivate.account), HashAlgorithms.SHA512))
                {
                    return BadRequest("الرابط غير مفعل");
                }

                var user = (from u in db.Students
                            where u.Id == userActivate.confirm
                            select u).SingleOrDefault();

                if (user == null)
                {
                    return NotFound(" المستخدم غير موجود ");
                }


                if (String.IsNullOrEmpty(userActivate.password))
                {
                    return BadRequest("يجب إدخال كلمة المرور");
                }
                else if (userActivate.password.Length <= 7)
                {
                    return BadRequest("يجب ان تكون كلمة المرور اكبر من سبع خانات");
                }
                else if (String.IsNullOrEmpty(userActivate.cpassword))
                {
                    return BadRequest("يجب إدخال تأكيد كلمة المرور ");
                }
                if (userActivate.password != userActivate.cpassword)
                {
                    return BadRequest("خطأ في عملية المطابقة لكلمة المرور");
                }


                using (var trans = db.Database.BeginTransaction())
                {
                    try
                    {
                        if (user.Status == 0)
                        {
                            user.Status = 1;
                        }
                        user.Password = Security.ComputeHash(userActivate.password, HashAlgorithms.SHA512, null);
                        user.Status = 1;
                        user.CreatedOn = DateTime.Now;
                        db.SaveChanges();
                        trans.Commit();
                        return Ok("لقد قمت بتغير كلمة المرور بنجاح");
                    }
                    catch (Exception)
                    {
                        trans.Rollback();
                        return StatusCode(500, null);

                    }
                }
            }
            catch (Exception)
            {
                return StatusCode(500, null);
            }

        }


        public string GetResetPasswordHTML(string UserName, string path)
        {

            string WebServer = Configuration.GetSection("Links")["WebServer"],
                   EmailSupport = Configuration.GetSection("Links")["EmailSupport"];


            return "<!DOCTYPE html>" +
                   "<html lang = \"ar\" dir = \"rtl\"><head><meta charset = \"UTF-8\"><style>" +
                   "div.wrapper{ margin: auto; margin-top:13vh; max-width:550px; }" +
                   "img{ width: 100 %; height: 45px; } footer{ width: 85 %; margin: auto; }" +
                    "p{ line-height: 1.4; text-align: justify; }" +
                  ".grey{ color: grey; }.padd{padding: 10px 5px; }" +
                  ".Helvetica{ font-family: Helvetica; font-size: 14.5px; }" +
                  "footer div { text-align: center; }" +
                  "body{ font-family: Arial; font-size:15.5px; }" +
                  "</style></head><body>" +
                  "<div class=\"wrapper\"><header><img src = \"" + WebServer + "/img/ddd.png\" /></header><div class=\"padd\"><p>عزيزي المستخدم<span>" + " " + UserName + " " + "</span></p>" +
                  "<p>  لتتمكن من استرجاع حسابك عليك ادخال كلمة مرور جديدة عن طريق النقر على الرابط أدناه :</p> " +
                 "<p>الرابط: <a href = \" " + WebServer + path + "\" > Click Here</a></p>" +
                 "<br><p>فريق عمل مشروع<b>مصلحة الاحوال المدنية</b> </p>" +
                "</div><footer class=\"Helvetica\"><div class=\"grey\"><a href = \"" + WebServer + "\"> visit our website</a> | <a href = \"" + WebServer + "\"> log in to your account</a> | <a href = \"mailto:" + EmailSupport + "\"> get support</a></div>" +
                "<div class=\"grey\"> All rights reserved ,مشروع مصلحة الاحوال المدنية  Copyright © CRA</div></footer></div></body></html>";

        }


    }
}