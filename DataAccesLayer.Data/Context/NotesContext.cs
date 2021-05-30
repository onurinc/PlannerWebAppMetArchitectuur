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
            var NotesList = new List<NotesDTO>();
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                string sqlQuery =
                    "SELECT * FROM Notes";

                SqlCommand cmd = new SqlCommand(sqlQuery, conn);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    var note = new NotesDTO();
                    note.NoteId = Convert.ToInt32(dr["NoteId"].ToString());
                    note.NoteName = dr["NoteName"].ToString();
                    note.Description = dr["NoteDescription"].ToString();
                    note.Urgency = dr["NoteUrgency"].ToString();
                    note.Id = Convert.ToInt32(dr["Id"].ToString());
                    NotesList.Add(note);
                }
                conn.Close();
            }
            return (NotesList);
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
