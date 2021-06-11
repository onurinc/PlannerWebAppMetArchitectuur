using System.Collections.Generic;
using System.Linq;
using DataAccesLayer.Data.Context;
using DataAccesLayer.Data.Data_Transfer_Object;
using DataAccesLayer.Data.InterfaceContext;
using DataAccesLayer.Data.InterfaceRepository;

namespace DataAccesLayer.Data.Repository
{
    public class NotesRepository : INotesRepository
    {
        private readonly INotesContext _notesContext;

        public NotesRepository(INotesContext notesContext)
        {
            this._notesContext = notesContext;
        }

        public NotesRepository()
        {
            this._notesContext = new NotesContext();
        }

        public List<NotesDTO> GetAllNotes()
        {
            return _notesContext.GetAllNotes().ToList();
        }

        public List<NotesInnerJoinsProjectsDTO> GetAllNotesIJProjects()
        {
            return _notesContext.GetAllNotesIJProjects().ToList();
        }

        public NotesDTO GetNote(int id)
        {
            return _notesContext.GetNote(id);
        }

        public void AddNote(NotesDTO note)
        {
            _notesContext.AddNote(note);
        }

        public void EditNote(NotesDTO note)
        {
            _notesContext.EditNote(note);
        }

        public void DeleteNote(int id)
        {
            _notesContext.DeleteNote(id);
        }
    }
}
