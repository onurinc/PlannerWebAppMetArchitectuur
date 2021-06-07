using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LogicLayer.InterfaceContainer;
using PlannerWebApp.ViewModel;
using ProjectsOnlyCRUDWithoutEntityTemplate.ViewModel;

namespace PlannerWebApp.Controllers
{
    public class SubtasksController : Controller
    {
        private readonly ISubtasksContainer _subtasksContainer;

        public SubtasksController(ISubtasksContainer subtasksContainer)
        {
            this._subtasksContainer = subtasksContainer;
        }
        // GET: SubtasksController
        public ActionResult Index()
        {
            List<SubtasksViewModel> subtasks = new List<SubtasksViewModel>();
            var subtask = _subtasksContainer.GetAllSubtasks();
            foreach (var s in subtask)
            {
                subtasks.Add(new SubtasksViewModel(s));
            }
            return View(subtasks);
        }

        // GET: SubtasksController/Details/5
        public ActionResult Details(int id)
        {
            var subtask = _subtasksContainer.GetSubtask(id);
            return View(new SubtasksViewModel(subtask));
        }

        // GET: SubtasksController/Create
        public ActionResult Create(SubtasksViewModel subtasksViewModel)
        {
            return View(subtasksViewModel);
        }

        // POST: SubtasksController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int projectId, bool subtaskStatus, string subtaskName, string subtaskDescription, string subtaskLabel)
        {
            _subtasksContainer.AddSubtask(projectId, subtaskStatus, subtaskName, subtaskDescription, subtaskLabel);
            return RedirectToAction(nameof(Index));
        }

        // GET: SubtasksController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SubtasksController/Edit/5
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

        // GET: SubtasksController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SubtasksController/Delete/5
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
