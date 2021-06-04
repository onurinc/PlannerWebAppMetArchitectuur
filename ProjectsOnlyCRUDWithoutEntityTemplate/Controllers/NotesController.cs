using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectsOnlyCRUDWithoutEntityTemplate.ViewModel;
using LogicLayer.InterfaceContainer;
using Microsoft.Extensions.Configuration;

namespace ProjectsOnlyCRUDWithoutEntityTemplate.Controllers
{
    public class NotesController : Controller
    {
        private readonly INotesContainer nContainer;

        private readonly IConfiguration _configuration;

        public NotesController(IConfiguration configuration, INotesContainer nContainer)
        {
            _configuration = configuration;
            this.nContainer = nContainer;
        }

        // GET: NotesController
        public ActionResult Index()
        {
            List<NotesViewModel> notes = new List<NotesViewModel>();
            var note = nContainer.GetAllNotes();
            foreach (var n in note)
            {
                notes.Add(new NotesViewModel(n));
            }

            return View(notes);
        }

        // GET: NotesController/Details/5
        public ActionResult Details(int id)
        {
            nContainer.GetNoteById(id);
            var note = nContainer.GetNoteById(id);
            return View(new NotesViewModel(note));
        }

        // GET: NotesController/Create
        public ActionResult Create(NotesViewModel notesViewModel)
        {
            return View(notesViewModel);
        }

        // POST: NotesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string noteName, string description, string urgency, int projectId)
        {
            nContainer.AddNote(noteName, description, urgency, projectId);
            return RedirectToAction(nameof(Index));
        }

        // GET: NotesController/Edit/5
        public ActionResult Edit(int id, NotesViewModel notesViewModel)
        {
            var note = nContainer.GetNoteById(id);
            return View(new NotesViewModel(note));
        }

        // POST: NotesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int NoteId, string noteName, string description, string urgency, int projectId)
        {
            nContainer.EditNote(NoteId, noteName, description, urgency, projectId);
            return RedirectToAction("Index");
        }

        // GET: NotesController/Delete/5
        public ActionResult Delete(int id, NotesViewModel notesViewModel)
        {
            var note = nContainer.GetNoteById(id);
            return View(new NotesViewModel(note));
        }

        // POST: NotesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            nContainer.DeleteNote(id);
            return RedirectToAction("Index");
        }
    }
}
