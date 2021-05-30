using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using DataAccesLayer.Data.Data_Transfer_Object;
using DataAccesLayer.Data.InterfaceContext;

namespace DataAccesLayer.Data.Context
{
    public class NotesContext : INotesContext
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
                    note.Description = dr["Description"].ToString();
                    note.Urgency = dr["Urgency"].ToString();
                    note.Id = Convert.ToInt32(dr["Id"].ToString());
                    NotesList.Add(note);
                }
                conn.Close();
            }
            return (NotesList);
        }

        public NotesDTO GetNote(int id)
        {
            string sqlQuery = "SELECT * FROM Notes WHERE NoteId = @NoteId";
            using (var conn = new SqlConnection(connectionstring))
            {
                conn.Open();
                SqlCommand command = new SqlCommand(sqlQuery, conn);
                command.Parameters.AddWithValue("@NoteId", id);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var note = new NotesDTO();
                        {
                            note.NoteId = (int)reader["NoteId"];
                            note.NoteName = reader["NoteName"]?.ToString();
                            note.Description = reader["Description"]?.ToString();
                            note.Urgency = reader["Urgency"]?.ToString();
                            note.Id = (int)reader["Id"];

                        };
                        return note;
                    }
                }
                return null;
            }
        }

        public void AddNote(NotesDTO note)
        {
            string sqlQuery = "INSERT INTO Notes VALUES(@NoteName, @Description, @Urgency, @Id)";
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();
                SqlCommand command = new SqlCommand(sqlQuery, conn);
                command.Parameters.AddWithValue("@NoteName", note.NoteName);
                command.Parameters.AddWithValue("@Description", note.Description);
                command.Parameters.AddWithValue("@Urgency", note.NoteName);
                command.Parameters.AddWithValue("@Id", note.Id);
                command.ExecuteNonQuery();
            }
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
