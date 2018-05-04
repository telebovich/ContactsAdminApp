using ContactsAdminApp;
using ContactsAdminApp.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ContactsAdminApp.Controllers
{
    public class HomeController : Controller
    {
        private ContactsContext db = new ContactsContext();

        public ActionResult Index(int? page)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            var contacts = db.Contacts.Select(m => m)
                .OrderBy(m => m.Name)
                .Include(p => p.Position)
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize);
            ViewBag.Pager = Pager.Items(db.Contacts.Count())
                .PerPage(pageSize)
                .Move(pageNumber)
                .Segment(5)
                .Center();
            return View(contacts);
        }

        public ActionResult Create()
        {
            ViewBag.PositionId = new SelectList(db.Positions, "Id", "Name",  null);

            return View();
        }

        [HttpPost]
        public ActionResult Create(Contact contact, HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/images/uploads"), fileName);
                file.SaveAs(path);
                contact.ImageUrl = Path.Combine("/images/uploads", fileName.Replace('\\', '/'));
            }
            db.Contacts.Add(contact);
            db.SaveChanges();

            ViewBag.PositionId = new SelectList(db.Positions, "Id", "Name", null);

            return RedirectToAction("Edit", new { id = contact.Id });
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = db.Contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }

            ViewBag.PositionId = new SelectList(db.Positions, "Id", "Name", contact.PositionId);
            
            return View(contact);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id, HttpPostedFileBase file)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var contact = db.Contacts.Find(id);

            if (file != null && file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/images/uploads"), fileName);
                file.SaveAs(path);
                contact.ImageUrl = string.Format("/images/uploads/{0}", fileName);
            }

            if (TryUpdateModel(contact, "",
               new string[] { "Name", "Email", "PositionID", "LandlinePhone", "CellPhone", "DateOfBirth" }))
            {
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.PositionId = new SelectList(db.Positions, "Id", "Name", contact.Position.Id);
            return View(contact);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = db.Contacts.Single<Contact>(m => m.Id == id);
            db.Entry(contact).Reference(c => c.Position).Load();
            if (contact == null)
            {
                return HttpNotFound();
            }

            return View(contact);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = db.Contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            db.Contacts.Remove(contact);
            db.SaveChanges();

            return View();
        }
    }
}