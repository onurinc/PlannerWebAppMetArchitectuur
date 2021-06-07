using System.Collections.Generic;
using LogicLayer.InterfaceContainer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectsOnlyCRUDWithoutEntityTemplate.Models;
using ProjectsOnlyCRUDWithoutEntityTemplate.ViewModel;

namespace ProjectsOnlyCRUDWithoutEntityTemplate.Controllers
{
    public class RemindersController : Controller
    {
        private readonly IRemindersContainer _remindersContainer;

        public RemindersController(IRemindersContainer remindersContainer)
        {
            this._remindersContainer = remindersContainer;
        }

        // GET: RemindersController
        public ActionResult Index()
        {
            List<RemindersViewModel> reminders = new List<RemindersViewModel>();
            var reminder = _remindersContainer.GetAllReminders();
            foreach (var r in reminder)
            {
                reminders.Add(new RemindersViewModel(r));
            }
            return View(reminders);
        }

        // GET: RemindersController/Details/5
        public ActionResult Details(int id)
        {
            var reminder = _remindersContainer.GetReminder(id);
            return View(new RemindersViewModel(reminder));
        }

        // GET: RemindersController/Create
        public ActionResult Create(RemindersViewModel remindersViewModel)
        {
            return View(remindersViewModel);
        }

        // POST: RemindersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int userId, string reminderName, string reminderDescription)
        {
            _remindersContainer.AddReminder(userId, reminderName, reminderDescription);
            return RedirectToAction(nameof(Index));
        }

        // GET: RemindersController/Edit/5
        public ActionResult Edit(int id, RemindersViewModel remindersViewModel)
        {
            var reminder = _remindersContainer.GetReminder(id);
            return View(new RemindersViewModel(reminder));
        }

        // POST: RemindersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, int userId, string reminderName, string reminderDescription)
        {
            _remindersContainer.EditReminder(id, userId, reminderName, reminderDescription);
            return RedirectToAction(nameof(Index));
        }

        // GET: RemindersController/Delete/5
        public ActionResult Delete(int id, RemindersViewModel remindersViewModel)
        {
            var reminder = _remindersContainer.GetReminder(id);
            return View(new RemindersViewModel(reminder));
        }

        // POST: RemindersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            _remindersContainer.DeleteReminder(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
