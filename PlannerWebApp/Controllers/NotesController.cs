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
        private readonly INotesContainer _nContainer;
        private readonly IProjectContainer _pContainer;

        public NotesController(INotesContainer nContainer, IProjectContainer pContainer)
        {
            this._nContainer = nContainer;
            this._pContainer = pContainer;
        }

        // GET: NotesController
        public ActionResult Index()
        {
            List<NotesViewModel> notes = new List<NotesViewModel>();
            var note = _nContainer.GetAllNotes();
            foreach (var n in note)
            {
                notes.Add(new NotesViewModel(n));
            }

            return View(notes);
        }

        // GET: NotesController/Details/5
        public ActionResult Details(int id)
        {
            var note = _nContainer.GetNoteById(id);
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
        public ActionResult Create(NotesViewModel notesViewModel, string noteName, string description, string urgency, int projectId)
        {
            var project = _pContainer.GetProjectById(projectId);
            if (project == null)
            {
                return View(notesViewModel);
            }
            _nContainer.AddNote(noteName, description, urgency, projectId);
                return RedirectToAction(nameof(Index));
        }

        // GET: NotesController/Edit/5
        public ActionResult Edit(int id, NotesViewModel notesViewModel)
        {
            var note = _nContainer.GetNoteById(id);
            return View(new NotesViewModel(note));
        }

        // POST: NotesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int NoteId, string noteName, string description, string urgency, int projectId)
        {
            _nContainer.EditNote(NoteId, noteName, description, urgency, projectId);
            return RedirectToAction("Index");
        }

        // GET: NotesController/Delete/5
        public ActionResult Delete(int id, NotesViewModel notesViewModel)
        {
            var note = _nContainer.GetNoteById(id);
            return View(new NotesViewModel(note));
        }

        // POST: NotesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            _nContainer.DeleteNote(id);
            return RedirectToAction("Index");
        }
    }
}
