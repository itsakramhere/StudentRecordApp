using StudentRecords.DataLayer;
using StudentRecords.IDAO;
using StudentRecords.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentRecords.Controllers
{
    public class StudentController : Controller
    {
        IDaoLayer<StudentViewModel> dao = null;
        
        public ActionResult Index()
        {
            List<StudentViewModel> models = new List<StudentViewModel>();

            try
            {
                dao = new StudentDAO();
                ArrayList arr = dao.Index();
                foreach (var item in arr)
                {
                    var modelItem = (StudentViewModel)item;
                    models.Add(modelItem);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.InnerException?.ToString() + ex.Source + ex.StackTrace + ex.TargetSite?.ToString() + ex.HelpLink);
            }
            return View(models);
        }
        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {

                dao = new StudentDAO();
                string gender = null;
                switch (Convert.ToInt32(collection["Gender"]))
                {
                    case 1:
                        gender = "Male";
                        break;
                    case 2:
                        gender = "Female";
                        break;
                    case 3:
                        gender = "Other";
                        break;
                }

                StudentViewModel model = new StudentViewModel{
                    RollNumber=Convert.ToInt32(collection["RollNumber"]),
                    Name=collection["Name"],
                    Age=Convert.ToInt32(collection["Age"]),
                    Gender=gender
                  
                };

                dao.Add(model);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.InnerException?.ToString() + ex.Source + ex.StackTrace + ex.TargetSite?.ToString() + ex.HelpLink);
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            dao = new StudentDAO();
           
            StudentViewModel arr = dao.Edit(id);
            int genderId = -1;
            switch (arr.Gender)
            {
                case "Male":
                    genderId = 1;
                    break;
                case "Female":
                    genderId = 2;
                    break;
                case "Other":
                    genderId = 3;
                    break;
            }
            ViewBag.GenderId = genderId;
            return View(arr);
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                dao = new StudentDAO();
                string gender = null;
                switch (Convert.ToInt32(collection["Gender"]))
                {
                    case 1:
                        gender = "Male";
                        break;
                    case 2:
                        gender = "Female";
                        break;
                    case 3:
                        gender = "Other";
                        break;
                }
                StudentViewModel model = new StudentViewModel
                {
                    RollNumber = Convert.ToInt32(collection["RollNumber"]),
                    Name = collection["Name"],
                    Age = Convert.ToInt32(collection["Age"]),
                    Gender = gender

                };
                bool arr = dao.Edit(model,id);

                if (arr)
                {
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Edit", new { id = id });

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.InnerException?.ToString() + ex.Source + ex.StackTrace + ex.TargetSite?.ToString() + ex.HelpLink);
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            try
            {
                dao = new StudentDAO();

                bool arr = dao.Delete(id);

                if (arr)
                {
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.InnerException?.ToString() + ex.Source + ex.StackTrace + ex.TargetSite?.ToString() + ex.HelpLink);
            }
            return RedirectToAction("Delete", new { id = id });
        }   
        public ActionResult Search()
        {
            return View();

        }
        [HttpPost]
        public ActionResult Search(FormCollection collection)
        {
            List<StudentViewModel> models = new List<StudentViewModel>();

            try
            {
                dao = new StudentDAO();
                int searchField = Convert.ToInt32(collection["searchField"]);
                string query = collection["q"];
                var result = dao.Search(searchField, query);
                foreach (var item in result)
                {
                    var modelItem = (StudentViewModel)item;
                    models.Add(modelItem);
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.InnerException?.ToString() + ex.Source + ex.StackTrace + ex.TargetSite?.ToString() + ex.HelpLink);
            }
            return View(models);

        }
        

    }
}
