using Digital_Diary.Models;
using Digital_Diary.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Digital_Diary.Controllers
{
    public class RegistrationController : Controller
    {
        IRepository<Registration> Reg = new RegistrationRepository();
        IRepository<Login> Log = new LoginRepository();
        Login login = new Login();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return RedirectToAction("Index", "Login");
        }
        [HttpPost]
        public ActionResult Index(Registration reg)
        {

            try
            {
                string fileName = Path.GetFileNameWithoutExtension(reg.ImageFile.FileName);
                string extension = Path.GetExtension(reg.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                reg.image = "~/Image/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
                reg.ImageFile.SaveAs(fileName);
                reg.date = DateTime.Now.ToString();
                Reg.Insert(reg);
                ModelState.Clear();


                login.userName = reg.userName;
                login.Password = reg.Password;
                Log.Insert(login);
                return RedirectToAction("Index", "Login");
            }
            catch
            {
                return RedirectToAction("Index");
            }

           
           
            
        }
    }
}