using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LogicLayer.InterfaceContainer;
using PlannerWebApp.ViewModel;

namespace PlannerWebApp.Controllers
{
    public class SubtasksController : Controller
    {
        private readonly ISubtasksContainer _subtasksContainer;
        private readonly IProjectContainer _pContainer;

        public SubtasksController(ISubtasksContainer subtasksContainer, IProjectContainer projectsContainer)
        {
            this._subtasksContainer = subtasksContainer;
            this._pContainer = projectsContainer;
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
        public ActionResult Create(SubtasksViewModel subtasksViewModel, int projectId, bool subtaskStatus, string subtaskName, string subtaskDescription, string subtaskLabel)
        {
            var project = _pContainer.GetProjectById(projectId);
            if (project == null)
            {
                ViewBag.Error = "You need to use a Project Id that exists.";
                return View(subtasksViewModel);
            }
            _subtasksContainer.AddSubtask(projectId, subtaskStatus, subtaskName, subtaskDescription, subtaskLabel);
            return RedirectToAction(nameof(Index));
        }

        // GET: SubtasksController/Edit/5
        public ActionResult Edit(int id)
        {
            var subtask = _subtasksContainer.GetSubtask(id);
            return View(new SubtasksViewModel(subtask));
        }

        // POST: SubtasksController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, int projectId, bool subtaskStatus, string subtaskName, string subtaskDescription, string subtaskLabel)
        {
            _subtasksContainer.EditSubtask(id, projectId, subtaskStatus, subtaskName, subtaskDescription, subtaskLabel);
            return RedirectToAction(nameof(Index));
        }

        // GET: SubtasksController/Delete/5
        public ActionResult Delete(int id)
        {
            var subtask = _subtasksContainer.GetSubtask(id);
            return View(new SubtasksViewModel(subtask));
        }

        // POST: SubtasksController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            _subtasksContainer.DeleteSubtask(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
