using System.Collections.Generic;
using LogicLayer.Models;

namespace LogicLayer.InterfaceContainer
{
    public interface INotesContainer
    {
        public List<NotesModel> GetAllNotes();

        public NotesModel GetNoteById(int id);

        public void AddNote(string noteName, string description, string urgency, int projectId);

        public void EditNote(int noteId, string noteName, string description, string urgency, int projectId);

        public void DeleteNote(int id);


    }
}
