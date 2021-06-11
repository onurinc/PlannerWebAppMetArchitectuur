using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using LogicLayer.InterfaceContainer;
using PlannerWebApp.ViewModel;

namespace PlannerWebApp.Controllers
{
    public class NotesIJProjectsController : Controller
    {
        private readonly INotesContainer _notesContainer;

        public NotesIJProjectsController(INotesContainer _notesContainer)
        {
            this._notesContainer = _notesContainer;
        }

        // GET: ProjectsController
        public ActionResult Index()
        {
            List<NotesIJProjectsViewModel> notesIJProjects = new List<NotesIJProjectsViewModel>();
            var notesIJProject = _notesContainer.GetAllNotesIJProjects();
            foreach (var np in notesIJProject)
            {
                notesIJProjects.Add(new NotesIJProjectsViewModel(np));
            }
            return View(notesIJProjects);
        }
    }
}

