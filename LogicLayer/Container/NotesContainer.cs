using System;
using System.Collections.Generic;
using System.Text;
using DataAccesLayer.Data.Context;
using DataAccesLayer.Data.Data_Transfer_Object;
using DataAccesLayer.Data.Repository;
using LogicLayer.DAO;
using LogicLayer.Models;

namespace LogicLayer.Container
{
    public class NotesContainer
    {
        private NotesContext context = new NotesContext();

        public List<NotesModel> GetAllNotes()
        {
            NotesRepository repo = new NotesRepository(context);
            List<NotesModel> notes = new List<NotesModel>();

            var notesdto = repo.GetAllNotes();

            foreach (var dto in notesdto)
            {
                notes.Add(new NotesModel(dto));
            }
            return notes;
        }

        public NotesModel GetNoteById(int id)
        {
            NotesRepository repo = new NotesRepository(context);
            var note = repo.GetNote(id);
            NotesModel notesModel = new NotesModel(note);
            return notesModel;
        }

        public void AddNote(string noteName, string description, string urgency, int id)
        {
            NotesRepository repo = new NotesRepository(context);
            repo.AddNote(new NotesDTO() { NoteName = noteName, Description = description, Urgency = urgency, Id = id});
        }
        public void EditNote(int noteId, string noteName, string description, string urgency, int id)
        {
            NotesRepository repo = new NotesRepository(context);
            repo.EditNote(new NotesDTO() { NoteId = noteId, NoteName = noteName, Description = description, Urgency = urgency, Id = id });
        }
    }
}
