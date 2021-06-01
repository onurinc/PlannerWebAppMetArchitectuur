    using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataAccesLayer.Data
{
    public class ProjectsContext : IProjectsContext
    {
        // Connectionstring for my desktop
        public string connectionstring = "Server=localhost\\SQLEXPRESS;Database=Projects;Trusted_Connection=True;";

        // Connectionstring for my laptop
        //public string connectionstring = "Data Source=DESKTOP-NCSPB7A;Initial Catalog=Projects;Integrated Security=True";

        public IEnumerable<ProjectsDTO> GetAllProjects()
        {
            var ProjectsList = new List<ProjectsDTO>();
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                string sqlQuery =
                    "SELECT * FROM Projects";

                SqlCommand cmd = new SqlCommand(sqlQuery, conn);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    var project = new ProjectsDTO();
                    project.ProjectId = Convert.ToInt32(dr["ProjectId"].ToString());
                    project.ProjectName = dr["ProjectName"].ToString();
                    ProjectsList.Add(project);
                }
                conn.Close();
            }
            return (ProjectsList);
        }

        public ProjectsDTO GetProject(int id)
        {
            string sqlQuery = "SELECT * FROM Projects WHERE ProjectId = @ProjectId";
            using (var conn = new SqlConnection(connectionstring))
            {
                conn.Open();
                SqlCommand command = new SqlCommand(sqlQuery, conn);
                command.Parameters.AddWithValue("@ProjectId", id);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var project = new ProjectsDTO();
                        {
                            project.ProjectId = (int) reader["ProjectId"];
                            project.ProjectName = reader["ProjectName"]?.ToString();
                        };
                        return project;
                    }
                }
                return null;
            }
        }

        public void AddProject(ProjectsDTO project)
        {
            string sqlQuery = "INSERT INTO Projects VALUES(@Name)";
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();
                SqlCommand command = new SqlCommand(sqlQuery, conn);
                command.Parameters.AddWithValue("@Name", project.ProjectName);
                command.ExecuteNonQuery();
            }
        }

        public void EditProject(ProjectsDTO project)
        {
            string sqlQuery = "UPDATE Projects SET ProjectName = @Name WHERE ProjectId = @ProjectId";
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();
                SqlCommand command = new SqlCommand(sqlQuery, conn);
                command.Parameters.AddWithValue("@ProjectId", project.ProjectId);
                command.Parameters.AddWithValue("@Name", project.ProjectName);
                command.ExecuteNonQuery();
            }
        }

        public void DeleteProject(int id)
        {
            string sqlQuery = "DELETE FROM Projects WHERE ProjectId = @ProjectId";
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();
                SqlCommand command = new SqlCommand(sqlQuery, conn);
                command.Parameters.AddWithValue("@ProjectId", id);
                command.ExecuteNonQuery();
            }
        }
    }
}