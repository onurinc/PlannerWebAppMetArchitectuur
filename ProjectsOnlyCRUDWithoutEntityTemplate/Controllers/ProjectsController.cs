using System.Collections.Generic;
using LogicLayer.InterfaceContainer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ProjectsOnlyCRUDWithoutEntityTemplate.Models;

namespace ProjectsOnlyCRUDWithoutEntityTemplate.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly IProjectContainer pContainer;

        private readonly IConfiguration _configuration;

        public ProjectsController(IConfiguration configuration, IProjectContainer pContainer)
        {
            _configuration = configuration;
            this.pContainer = pContainer;
        }

        // GET: ProjectsController
        public ActionResult Index()
        {
            List<ProjectViewModel> projects = new List<ProjectViewModel>();
            var project = pContainer.GetAllProjects();
            foreach (var p in project)
            {
                projects.Add(new ProjectViewModel(p));
            }

            return View(projects);
        }

        // GET: ProjectsController/Details/5
        public ActionResult Details(int id)
        {
            
            pContainer.GetProjectById(id);
            var project = pContainer.GetProjectById(id);
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
        public ActionResult Create(string ProjectName)
        {
            pContainer.AddProject(ProjectName);
            return RedirectToAction(nameof(Index));
        }


        // GET: ProjectsController/Edit/5
        public ActionResult Edit(int id, ProjectViewModel projectViewModel)
        {
            var project = pContainer.GetProjectById(id);
            return View(new ProjectViewModel(project));
        }

        // POST: ProjectsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, string ProjectName)
        {
            pContainer.EditProject(id, ProjectName);
            return RedirectToAction("Index");
        }

        // GET: ProjectsController/Delete/5
        public ActionResult Delete(int id)
        {
            var project = pContainer.GetProjectById(id);
            return View(new ProjectViewModel(project));

        }

        // POST: ProjectsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            pContainer.DeleteProject(id);
            return RedirectToAction("Index");
        }

    }
}
