using FPBLL;
using FPEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProjectWebApp.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: Registration
        public ActionResult Index(int eventId)
        {
            RegistrationService rs = new RegistrationService();
            var attendees = rs.GetAttendees(eventId);
            return View(attendees);
        }

        public ActionResult CreateRegistrationView()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateRegistrationView(Registration registration)
        {
            RegistrationService rs = new RegistrationService();
            if (rs.CreateRegistrationService(registration))
            {
                ViewBag.Message = "Registration has been added succcessfully";
            }
            return View();
        }

        public ActionResult EditRegistrationView(int eventID)
        {
            RegistrationService rs = new RegistrationService();
            return View(rs.GetAttendees(eventID).Find(x => x.EventID == eventID));
        }

        [HttpPost]
        public ActionResult EditRegistrationView(Registration registration)
        {
            RegistrationService rs = new RegistrationService();
            if (rs.EditRegistrationService(registration))
            {
                ViewBag.Message = "Registration is updated";
            }

            return View();
        }

        public ActionResult DeleteRegistrationView(int eventId)
        {
            RegistrationService rs = new RegistrationService();
            if (rs.DeleteRegistrationService(eventId))
            {
                return RedirectToAction("Index");
            }
            return null;
        }
    }
}