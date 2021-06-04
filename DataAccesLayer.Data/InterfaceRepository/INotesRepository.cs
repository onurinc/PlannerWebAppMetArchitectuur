using System;
using System.Collections.Generic;
using System.Text;
using DataAccesLayer.Data.Data_Transfer_Object;

namespace DataAccesLayer.Data.InterfaceRepository
{
    public interface INotesRepository
    {
        public List<NotesDTO> GetAllNotes();

        public NotesDTO GetNote(int id);

        public void AddNote(NotesDTO note);

        public void EditNote(NotesDTO note);

        public void DeleteNote(int id);
    }
}
