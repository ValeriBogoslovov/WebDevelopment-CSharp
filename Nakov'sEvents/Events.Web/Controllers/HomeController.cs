﻿namespace Events.Web.Controllers
{
    using Microsoft.AspNet.Identity;
    using Models;
    using System;
    using System.Linq;
    using System.Web.Mvc;

    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            var events = this.db.Events
                .OrderBy(e => e.StartDateTime)
                .Where(e => e.IsPublic)
                .Select(EventViewModel.ViewModel);

            var upcomingEvents = events.Where(e => e.StartDateTime > DateTime.Now);
            var passedEvents = events.Where(e => e.StartDateTime <= DateTime.Now);

            var upcomingPassedEvents = new UpcomingPassedEventsViewModel()
            {
                UpcomingEvents = upcomingEvents,
                PassedEvents = passedEvents
            };

            return View(upcomingPassedEvents);
        }

        public ActionResult EventDetailsById(int id)
        {
            var currentUserId = this.User.Identity.GetUserId();
            var isAdmin = this.IsAdmin();
            var eventDetails = this.db.Events
                .Where(e => e.Id == id)
                .Where(e => e.IsPublic || isAdmin || (e.AuthorId != null && e.AuthorId == currentUserId))
                .Select(EventDetailsViewModel.ViewModel)
                .FirstOrDefault();

            var isOwner = (eventDetails != null && eventDetails.AuthorId != null && 
                eventDetails.AuthorId == currentUserId);
            this.ViewBag.CanEdit = isOwner || isAdmin;

            return this.PartialView("_EventDetails", eventDetails);
        }
    }
}