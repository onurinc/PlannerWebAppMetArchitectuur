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

        public NotesController(INotesContainer nContainer)
        {
            this._nContainer = nContainer;
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
            _nContainer.GetNoteById(id);
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
        public ActionResult Create(string noteName, string description, string urgency, int projectId)
        {
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
