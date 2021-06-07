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
        // Connectionstring for my desktop
        public string connectionstring = "Server=localhost\\SQLEXPRESS;Database=PlannerWebApp;Trusted_Connection=True;";

        // Connectionstring for my laptop
        // public string connectionstring = "Data Source=DESKTOP-NCSPB7A;Initial Catalog=PlannerWebApp;Integrated Security=True";

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
                    note.ProjectId = Convert.ToInt32(dr["ProjectId"].ToString());
                    note.NoteName = dr["NoteName"].ToString();
                    note.Description = dr["Description"].ToString();
                    note.Urgency = dr["Urgency"].ToString();
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
                            note.ProjectId = (int)reader["ProjectId"];
                            note.NoteName = reader["NoteName"]?.ToString();
                            note.Description = reader["Description"]?.ToString();
                            note.Urgency = reader["Urgency"]?.ToString();

                        };
                        return note;
                    }
                }
                return null;
            }
        }

        public void AddNote(NotesDTO note)
        {
            string sqlQuery = "INSERT INTO Notes VALUES(@ProjectId, @NoteName, @Description, @Urgency)";
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();
                SqlCommand command = new SqlCommand(sqlQuery, conn);
                command.Parameters.AddWithValue("@ProjectId", note.ProjectId);
                command.Parameters.AddWithValue("@NoteName", note.NoteName);
                command.Parameters.AddWithValue("@Description", note.Description);
                command.Parameters.AddWithValue("@Urgency", note.Urgency);
                command.ExecuteNonQuery();
            }
        }

        public void EditNote(NotesDTO note)
        {
            string sqlQuery = "UPDATE Notes SET ProjectId = @ProjectId, NoteName = @NoteName, Description = @Description, Urgency = @Urgency WHERE NoteId = @NoteId";
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();
                SqlCommand command = new SqlCommand(sqlQuery, conn);
                command.Parameters.AddWithValue("@NoteId", note.NoteId);
                command.Parameters.AddWithValue("@ProjectId", note.ProjectId);
                command.Parameters.AddWithValue("@NoteName", note.NoteName);
                command.Parameters.AddWithValue("@Description", note.Description);
                command.Parameters.AddWithValue("@Urgency", note.Urgency);
                command.ExecuteNonQuery();
            }
        }

        public void DeleteNote(int id)
        {
            string sqlQuery = "DELETE FROM Notes WHERE NoteId = @NoteId";
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();
                SqlCommand command = new SqlCommand(sqlQuery, conn);
                command.Parameters.AddWithValue("@NoteId", id);
                command.ExecuteNonQuery();
            }
        }

    }
}
