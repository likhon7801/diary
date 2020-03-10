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
    public class HomeController : Controller
    {
        IRepository<Ddiary> d = new DdiaryRepository();
        IDdiaryRepository da = new DdiaryRepository();
        [HttpGet]
        
        public ActionResult Cheek()
        {
            string name = (string)(Session["Name"]);

            if (name=="")
            {
                return RedirectToAction("Index","Login");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        public HomeController()
        {
            //Cheek();
        }
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Logout()
        {
            return RedirectToAction("Index","Logout");
        }
        [HttpGet]
        public ActionResult List()
        {
            return View(da.GetAllDiary());
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Ddiary diary)
        {
            try
            {
                string fileName = Path.GetFileNameWithoutExtension(diary.ImageFile.FileName);
                string extension = Path.GetExtension(diary.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                diary.imagePath = "~/Image/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
                diary.ImageFile.SaveAs(fileName);
                diary.Date = DateTime.Now.ToString();
                diary.ModifiedDate = DateTime.Now.ToString();
                diary.R_Id = 1;
                d.Insert(diary);
                ModelState.Clear();
                return RedirectToAction("List");
            }
            catch
            {
                return RedirectToAction("Create");
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(d.Get(id));
        }
        [HttpPost]
        public ActionResult Edit(Ddiary diary)
        {
            try
            {

                string fileName = Path.GetFileNameWithoutExtension(diary.ImageFile.FileName);
                string extension = Path.GetExtension(diary.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                diary.imagePath = "~/Image/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
                diary.ImageFile.SaveAs(fileName);
                diary.ModifiedDate = DateTime.Now.ToString();
                diary.R_Id = 1;
                d.Update(diary);
                ModelState.Clear();
                return RedirectToAction("Details", new { @id = diary.Id });
            }
            catch
            {
               
                return RedirectToAction("Details", new { @id = diary.Id });
            }
            
           
            
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            return View(d.Get(id));
        }
        [HttpGet]
        public ActionResult delete(int id)
        {
            return View(d.Get(id));
        }
        [HttpPost,ActionName("Delete")]
        public ActionResult condelete(int id)
        {
            d.Delete(id);
            return RedirectToAction("List");
        }
    }

}