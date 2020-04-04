using Management.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Managegment.Controllers
{
    public class Helper
    {


        public long GetCurrentUser(HttpContext HttpUser)
        {
            try
            {
                var user = HttpUser.User;
                if (user == null || user.Claims == null)
                {
                    return 0;
                }

                var claims = user.Claims.ToList();

                if (claims.Count == 0)
                {
                    return 0;
                    // return 1;
                }
                string userIdClaim = "";
                if (claims.Count > 1)
                {
                    userIdClaim = claims.Where(p => p.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/id").ToList()[0].Value;
                }
                else
                {
                    userIdClaim = claims.Where(p => p.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/id").SingleOrDefault().Value;
                }


                long userId = Convert.ToInt64(userIdClaim);


                return Convert.ToInt64(userId);
            }
            catch (Exception)
            {
                return -999;
            }
        }


        public string GetPlainTextFromHtml(string htmlString)
        {
            string htmlTagPattern = "<.*?>";
            var regexCss = new Regex("(\\<script(.+?)\\</script\\>)|(\\<style(.+?)\\</style\\>)", RegexOptions.Singleline | RegexOptions.IgnoreCase);
            htmlString = regexCss.Replace(htmlString, string.Empty);
            htmlString = Regex.Replace(htmlString, htmlTagPattern, string.Empty);
            htmlString = Regex.Replace(htmlString, @"^\s+$[\r\n]*", "", RegexOptions.Multiline);
            htmlString = htmlString.Replace("&nbsp;", string.Empty);

            return htmlString;
        }

        public bool getPermissin(string perimm,long userId, SmartEducationContext db)
        {
            try
            {
                

                if (userId <= 0)
                {
                    return (false);
                }
                var cUser = (from p in db.Users
                             where p.Id == userId
                             select p).SingleOrDefault();
                if (cUser.UserType == 1)
                {
                    return (true);
                }
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
