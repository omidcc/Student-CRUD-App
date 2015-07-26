using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StudentApp.Context;
using StudentApp.Models;

namespace StudentApp.Controllers
{
    public class StudentController : Controller
    {
        //
        // GET: /Student/
        private StudentContext db= new StudentContext();
        public ActionResult Index()
        {
            return View(db.Students.ToList());
        }

        //
        // GET: /Student/Details/5
        public ActionResult Details(int? id)
        {
            if(id==null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Student student = db.Students.Find(id);
            if (student == null)
                return HttpNotFound();

            return View(student);
        }

        //
        // GET: /Student/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Student/Create
        [HttpPost]
        public ActionResult Create(Student student)
        {
            try
            {
                if (ModelState.IsValid)

                {
                    db.Students.Add(student);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(student);
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Student/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Student student = db.Students.Find(id);
            if (student == null)
                return HttpNotFound();

            return View(student);
      
        }

        //
        // POST: /Student/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Student student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(student).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(student);
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Student/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Student student = db.Students.Find(id);
            if (student == null)
                return HttpNotFound();

            return View(student);
           
        }

        //
        // POST: /Student/Delete/5
        [HttpPost]
        public ActionResult Delete(int? id,Student st)
        {
            try
            {
                Student student=new Student();
                if (ModelState.IsValid)
                {
                    if (id == null)
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                     student = db.Students.Find(id);
                    if (student == null)
                        return HttpNotFound();

                    db.Students.Remove(student);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(student);
            }
            catch
            {
                return View();
            }
        }
    }
}
