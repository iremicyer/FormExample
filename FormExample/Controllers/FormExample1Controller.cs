using FormExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FormExample.Controllers
{
    public class FormExample1Controller : Controller
    {

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create() // post olmadığında yani sayfa görüntelemek istediğimizde bu Action çalışır.
        {
            return View();
        }
        [HttpPost] // sadece post olduğunda aşağıdaki Action ın çalışması için.
        public ActionResult Create(FormCollection form)
        {
            FormExampleDBEntities db = new FormExampleDBEntities();
            Users model = new Users();
            model.City = form["City"].Trim(); // Trim() fonksiyonu string değerin başındaki ve sonundaki boşlukları siler
            model.UserName = form["UserName"].Trim();
            model.UserSurname = form["UserSurname"].Trim();
            db.Users.Add(model); // veritabanının eklenmesi.
            db.SaveChanges(); // veritabanına verilerin eklenmesi.
            return View();
        }
    }
}