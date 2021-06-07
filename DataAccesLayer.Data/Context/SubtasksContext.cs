using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using DataAccesLayer.Data.Data_Transfer_Object;
using DataAccesLayer.Data.InterfaceContext;

namespace DataAccesLayer.Data.Context
{
    public class SubtasksContext : ISubtasksContext
    {
        // Connectionstring for my desktop
        public string connectionstring = "Server=localhost\\SQLEXPRESS;Database=PlannerWebApp;Trusted_Connection=True;";

        // Connectionstring for my laptop
        // public string connectionstring = "Data Source=DESKTOP-NCSPB7A;Initial Catalog=PlannerWebApp;Integrated Security=True";

        public IEnumerable<SubtasksDTO> GetAllSubtasks()
        {
            var NotesList = new List<SubtasksDTO>();
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                string sqlQuery =
                    "SELECT * FROM Subtasks";

                SqlCommand cmd = new SqlCommand(sqlQuery, conn);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    var subtask = new SubtasksDTO();
                    subtask.SubtaskId = Convert.ToInt32(dr["SubtaskId"].ToString());
                    subtask.ProjectId = Convert.ToInt32(dr["ProjectId"].ToString());
                    subtask.SubtaskName = dr["SubtaskStatus"].ToString();
                    subtask.SubtaskName = dr["SubtaskName"].ToString();
                    subtask.SubtaskDescription = dr["SubtaskDescription"].ToString();
                    subtask.SubtaskLabel = dr["SubtaskLabel"].ToString();
                    NotesList.Add(subtask);
                }
                conn.Close();
            }
            return (NotesList);
        }

        public void AddSubtask(SubtasksDTO subtask)
        {
            throw new NotImplementedException();
        }

        public SubtasksDTO GetSubtask(int id)
        {
            throw new NotImplementedException();
        }

        public void EditSubtask(SubtasksDTO subtask)
        {
            throw new NotImplementedException();
        }

        public void DeleteSubtask(int id)
        {
            throw new NotImplementedException();
        }
    }
}
