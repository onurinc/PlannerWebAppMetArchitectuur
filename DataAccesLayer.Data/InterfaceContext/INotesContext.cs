using System.Collections.Generic;
using DataAccesLayer.Data.Data_Transfer_Object;

namespace DataAccesLayer.Data.InterfaceContext
{
    public interface INotesContext
    {
        IEnumerable<NotesDTO> GetAllNotes();

        NotesDTO GetNote(int id);

        void EditNote(NotesDTO note);

        public void AddNote(NotesDTO note);

        public void DeleteNote(int id);
    }
}
