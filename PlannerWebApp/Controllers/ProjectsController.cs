using System.Collections.Generic;
using LogicLayer.InterfaceContainer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectsOnlyCRUDWithoutEntityTemplate.Models;

namespace ProjectsOnlyCRUDWithoutEntityTemplate.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly IProjectContainer _pContainer;

        public ProjectsController(IProjectContainer pContainer)
        {
            this._pContainer = pContainer;
        }

        // GET: ProjectsController
        public ActionResult Index()
        {
            List<ProjectViewModel> projects = new List<ProjectViewModel>();
            var project = _pContainer.GetAllProjects();
            foreach (var p in project)
            {
                projects.Add(new ProjectViewModel(p));
            }
            return View(projects);
        }

        // GET: ProjectsController/Details/5
        public ActionResult Details(int id)
        {
            var project = _pContainer.GetProjectById(id);
            return View(new ProjectViewModel(project));
        }

        //GET: ProjectsController/Create
       [HttpGet]
        public ActionResult Create(ProjectViewModel projectModel)
        {
            return View(projectModel);
        }

        // POST: ProjectsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm]int userId, string projectName, string projectDescription)
        {
            if (userId == null)
            {
                return RedirectToAction(nameof(Index));
            }
            _pContainer.AddProject(userId, projectName, projectDescription);
            return RedirectToAction(nameof(Index));
        }

        // GET: ProjectsController/Edit/5
        public ActionResult Edit(int id, ProjectViewModel projectViewModel)
        {
            var project = _pContainer.GetProjectById(id);
            return View(new ProjectViewModel(project));
        }

        // POST: ProjectsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, int userId, string projectName, string projectDescription)
        {
            _pContainer.EditProject(id, userId, projectName, projectDescription);
            return RedirectToAction("Index");
        }

        // GET: ProjectsController/Delete/5
        public ActionResult Delete(int id)
        {
            var project = _pContainer.GetProjectById(id);
            return View(new ProjectViewModel(project));

        }

        // POST: ProjectsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            _pContainer.DeleteProject(id);
            return RedirectToAction("Index");
        }

    }
}
