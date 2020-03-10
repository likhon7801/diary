using Digital_Diary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Digital_Diary.Controllers
{
    public class LoginController : Controller
    {  
       
        DiaryDataContext Context = new DiaryDataContext();
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Registration()
        {
            return RedirectToAction("Index","Registration");
        }
        [HttpPost]
        public ActionResult Index(Login user)
        {
            try
            {
                var myUser = Context.Logins
        .FirstOrDefault(u => u.userName == user.userName
                     && u.Password == user.Password);

                if (myUser != null)
                {
                    Session["Name"] = myUser.userName;
                    Session["Id"] = user.Id;
                    
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return RedirectToAction("Index");
            }
           
        }
    }
}