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
            return View();
        }

        //GET: ProjectsController/Create
       [HttpGet]
        public ActionResult Create()
        {
            ProjectViewModel projectsModel = new ProjectViewModel();
            return View(projectsModel);
        }

        // POST: ProjectsController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(ProjectsModel projectsModel)
        //{
        //    ProjectsContainerPL pContainer = new ProjectsContainerPL();
        //    if (ModelState.IsValid)
        //    {
        //        pContainer.AddProject();
        //    }
        //    return RedirectToAction(nameof(Index));

        //}

        //// GET: ProjectsController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    ProjectsModel projectsModel = new ProjectsModel();
        //    DataTable dtblProjects = new DataTable();

        //    using (SqlConnection sqlConnection =
        //        new SqlConnection(_configuration.GetConnectionString("Dbaseconnection")))
        //    {
        //        string sqlQuery = "SELECT * FROM Projects WHERE Id = @id";
        //        sqlConnection.Open();
        //        SqlDataAdapter sqlDa = new SqlDataAdapter(sqlQuery, sqlConnection);
        //        sqlDa.SelectCommand.Parameters.AddWithValue("@Id", id);
        //        sqlDa.Fill(dtblProjects);
        //    }

        //    if (dtblProjects.Rows.Count == 1)
        //    {
        //        projectsModel.Id = Convert.ToInt32(dtblProjects.Rows[0][0].ToString());
        //        projectsModel.ProjectName = dtblProjects.Rows[0][1].ToString();
        //        return View(projectsModel);
        //    }

        //    return RedirectToAction("Index");
        //}

        //// POST: ProjectsController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(ProjectsModel projectsModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        using (SqlConnection sqlConnection =
        //            new SqlConnection(_configuration.GetConnectionString("Dbaseconnection")))
        //        {
        //            string sqlQuery = "UPDATE Projects SET ProjectName = @ProjectName WHERE Id = @Id";
        //            sqlConnection.Open();
        //            SqlCommand sqlCmd = new SqlCommand(sqlQuery, sqlConnection);
        //            sqlCmd.Parameters.AddWithValue("@Id", projectsModel.Id);
        //            sqlCmd.Parameters.AddWithValue("@ProjectName", projectsModel.ProjectName);
        //            sqlCmd.ExecuteNonQuery();
        //        }
        //        return RedirectToAction("Index");

        //    }
        //    return View(projectsModel);
        //}

        //// GET: ProjectsController/Delete/5
        //public ActionResult Delete(int id)
        //{

        //    using (SqlConnection sqlConnection =
        //        new SqlConnection(_configuration.GetConnectionString("Dbaseconnection")))
        //    {
        //        string sqlQuery = "DELETE FROM Projects WHERE Id = @Id";
        //        sqlConnection.Open();
        //        SqlCommand sqlCmd = new SqlCommand(sqlQuery, sqlConnection);
        //        sqlCmd.Parameters.AddWithValue("@Id", id);
        //        sqlCmd.ExecuteNonQuery();
        //    }
        //    return RedirectToAction("Index");
        //}

        //// POST: ProjectsController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

    }
}
