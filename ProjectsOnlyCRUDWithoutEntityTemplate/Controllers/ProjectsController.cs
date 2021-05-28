using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using DataAccesLayer.Data;
using LogicLayer.Container;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ProjectsOnlyCRUDWithoutEntityTemplate.ContainerPL;
using ProjectsOnlyCRUDWithoutEntityTemplate.Models;

namespace ProjectsOnlyCRUDWithoutEntityTemplate.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly IConfiguration _configuration;

        public ProjectsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // GET: ProjectsController
        public ActionResult Index()
        {
            ProjectsContainerPL pContainer = new ProjectsContainerPL();
            List<ProjectViewModel> projects = new List<ProjectViewModel>();
            projects = pContainer.GetAllProjects();

            return View(projects);
        }

        // GET: ProjectsController/Details/5
        public ActionResult Details(int id)
        {
            ProjectContainer pContainer = new ProjectContainer();
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
            ProjectContainer pContainer = new ProjectContainer();
            pContainer.AddProject(ProjectName);
            return RedirectToAction(nameof(Index));

        }

        // GET: ProjectsController/Edit/5
        public ActionResult Edit(int id, ProjectViewModel projectViewModel)
        {

            ProjectContainer pContainer = new ProjectContainer();
            pContainer.GetProjectById(id);

            return View(projectViewModel);
        }

        // POST: ProjectsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, string ProjectName)
        {
            ProjectContainer pContainer = new ProjectContainer();
            pContainer.EditProject(id, ProjectName);

            return RedirectToAction("Index");
        }

        // GET: ProjectsController/Delete/5
        public ActionResult Delete(int id)
        {
            ProjectContainer pContainer = new ProjectContainer();
            pContainer.GetProjectById(id);
            var project = pContainer.GetProjectById(id);
            return View(new ProjectViewModel(project));

        }

        // POST: ProjectsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            ProjectContainer pContainer = new ProjectContainer();
            pContainer.DeleteProject(id);

            return RedirectToAction("Index");
        }

    }
}
