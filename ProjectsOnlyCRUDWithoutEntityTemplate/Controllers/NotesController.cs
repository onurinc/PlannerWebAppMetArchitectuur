using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LogicLayer.Container;
using LogicLayer.Models;
using ProjectsOnlyCRUDWithoutEntityTemplate.ContainerPL;
using ProjectsOnlyCRUDWithoutEntityTemplate.ViewModel;

namespace ProjectsOnlyCRUDWithoutEntityTemplate.Controllers
{
    public class NotesController : Controller
    {
        // GET: NotesController
        public ActionResult Index()
        {
            NotesContainerPL nContainer = new NotesContainerPL();
            List<NotesViewModel> notes = new List<NotesViewModel>();
            notes = nContainer.GetAllNotes();
            return View(notes);
        }

        // GET: NotesController/Details/5
        public ActionResult Details(int id)
        {
            NotesContainer nContainer = new NotesContainer();
            nContainer.GetNoteById(id);
            var note = nContainer.GetNoteById(id);
            return View(new NotesViewModel(note));
        }

        // GET: NotesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NotesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: NotesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: NotesController/Edit/5
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

        // GET: NotesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: NotesController/Delete/5
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
