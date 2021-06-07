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
            return View();
        }

        // GET: RemindersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RemindersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RemindersController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RemindersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RemindersController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RemindersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
