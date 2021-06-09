using System.Collections.Generic;
using DataAccesLayer.Data.Data_Transfer_Object;
using DataAccesLayer.Data.InterfaceRepository;
using LogicLayer.InterfaceContainer;
using LogicLayer.Models;

namespace LogicLayer.Container
{
    public class NotesContainer : INotesContainer
    {
        private readonly INotesRepository _notesRepo;

        public NotesContainer(INotesRepository notesRepo)
        {
            this._notesRepo = notesRepo;
        }

        public List<NotesModel> GetAllNotes()
        {
            List<NotesModel> notes = new List<NotesModel>();
            var notesdto = _notesRepo.GetAllNotes();
            foreach (var dto in notesdto)
            {
                notes.Add(new NotesModel(dto));
            }

            return notes;
        }

        public NotesModel GetNoteById(int id)
        {
            var note = _notesRepo.GetNote(id);
            NotesModel notesModel = new NotesModel(note);
            return notesModel;
        }

        public void AddNote(string noteName, string description, string urgency, int projectId)
        {
            _notesRepo.AddNote(new NotesDTO()
            { NoteName = noteName, Description = description, Urgency = urgency, ProjectId = projectId });
        }

        public void EditNote(int noteId, string noteName, string description, string urgency, int projectId)
        {
            _notesRepo.EditNote(new NotesDTO()
            {
                NoteId = noteId,
                NoteName = noteName,
                Description = description,
                Urgency = urgency,
                ProjectId = projectId
            });
        }

        public void DeleteNote(int id)
        {
            _notesRepo.DeleteNote(id);
        }
    }
}