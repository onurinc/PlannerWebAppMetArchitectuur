using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using DataAccesLayer.Data.Data_Transfer_Object;
using DataAccesLayer.Data.InterfaceContext;

namespace DataAccesLayer.Data.Context
{
    class NotesContext : INotesContext
    {
        public string connectionstring = "Server=localhost\\SQLEXPRESS;Database=Projects;Trusted_Connection=True;";

        public IEnumerable<NotesDTO> GetAllNotes()
        {
            throw new NotImplementedException();
        }

        public NotesDTO GetNote(int id)
        {
            throw new NotImplementedException();
        }

        public void AddNote(NotesDTO note)
        {
            throw new NotImplementedException();
        }
        public void EditNote(NotesDTO note)
        {
            throw new NotImplementedException();
        }

        public void DeleteNote(int id)
        {
            throw new NotImplementedException();
        }

    }
}
