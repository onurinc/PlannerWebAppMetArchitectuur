using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccesLayer.Data.Context;
using DataAccesLayer.Data.Data_Transfer_Object;
using DataAccesLayer.Data.InterfaceContext;

namespace DataAccesLayer.Data.Repository
{
    class NotesRepository
    {
        private INotesContext context;
        public NotesRepository(INotesContext context)
        {
            this.context = context;
        }

        public NotesRepository()
        {
            this.context = new NotesContext();
        }

        public List<NotesDTO> GetAllNotes()
        {
            return context.GetAllNotes().ToList();
        }

        public NotesDTO GetNote(int id)
        {
            return context.GetNote(id);
        }

        public void AddProject(NotesDTO note)
        {
            context.AddNote(note);
        }

        public void EditProject(NotesDTO note)
        {
            context.EditNote(note);
        }

        public void DeleteProject(int id)
        {
            context.DeleteNote(id);
        }
    }
}
