using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataAccesLayer.Data
{
    public class ProjectsContext : IProjectsContext
    {
        public string connectionstring = "Server=localhost\\SQLEXPRESS;Database=Projects;Trusted_Connection=True;";

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
                    project.Id = Convert.ToInt32(dr["Id"].ToString());
                    project.ProjectName = dr["ProjectName"].ToString();
                    ProjectsList.Add(project);
                }
                conn.Close();
            }
            return (ProjectsList);
        }

        public ProjectsDTO GetProject(int id)
        {
            string sqlQuery = "SELECT * FROM Projects WHERE Id = @id";
            using (var conn = new SqlConnection(connectionstring))
            {
                conn.Open();
                SqlCommand command = new SqlCommand(sqlQuery, conn);
                command.Parameters.AddWithValue("@Id", id);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var project = new ProjectsDTO();
                        {
                            project.Id = (int) reader["Id"];
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
            string sqlQuery = "INSERT INTO ProjectsTable VALUES(@Name)";
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
            string sqlQuery = "UPDATE Projects SET ProjectName = @ProjectName WHERE Id = @Id";
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();
                SqlCommand command = new SqlCommand(sqlQuery, conn);
                command.Parameters.AddWithValue("@Id", project.Id);
                command.Parameters.AddWithValue("@Name", project.ProjectName);
                command.ExecuteNonQuery();
            }
        }

        public void DeleteProject(int id)
        {
            string sqlQuery = "DELETE FROM Projects WHERE Id = @Id";
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();
                SqlCommand command = new SqlCommand(sqlQuery, conn);
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
            }
        }
    }
}