using FPBLL;
using FPDAL;
using FPEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace FinalProjectWebApp.Controllers
{
    public class EventController : Controller
    {
        // GET: Event
        public ActionResult Index()
        {
            EventService es = new EventService();
            var events =es.GetEvents();
            return View(events);
        }

        public ActionResult CreateEventView()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateEventView(Event events)
        {
            EventService es = new EventService();
            if(es.CreateEventService(events))
            {
                ViewBag.Message = "Event has bewn added succcessfully";
            }
            return View();
        }

        public ActionResult EditEventView(int eventID)
        {
            EventService es = new EventService();
            return View(es.GetEvents().Find(x => x.EventID == eventID));
        }

        [HttpPost]
        public ActionResult EditEventView(Event events)
        {
            EventService es = new EventService();
            if (es.EditEventService(events))
            {
                ViewBag.Message = "Event is updated";
            }

            return View();
        }

        public ActionResult DeleteEventView(int eventId)
        {
            EventService es = new EventService();
            if (es.DeleteEventService(eventId))
            {
                return RedirectToAction("Index");
            }
            return null;
        }
    }
}