//using System;
//using System.Collections.Generic;
//using System.Data.SqlClient;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.Extensions.Configuration;
//using ProjectsOnlyCRUDWithoutEntityTemplate.Models;


//namespace ProjectsOnlyCRUDWithoutEntityTemplate.Data
//{
//    public class ProjectsDataContext
//    {
//        private readonly IConfiguration _configuration;

//        public ProjectsDataContext(IConfiguration configuration)
//        {
//            _configuration = configuration;
//        }

//        public IEnumerable<ProjectsModel> GetAllProjects()
//        {
//            var ProjectsList = new List<ProjectsModel>();
//            using (SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("Dbaseconnection")))
//            {
//                string sqlQuery =
//                    "SELECT * FROM ProjectsTable";

//                SqlCommand cmd = new SqlCommand(sqlQuery, conn);
//                conn.Open();
//                SqlDataReader dr = cmd.ExecuteReader();
//                while (dr.Read())
//                {
//                    var project = new ProjectsModel();
//                    project.Id = Convert.ToInt32(dr["Id"].ToString());
//                    project.ProjectName = dr["ProjectName"].ToString();
//                    ProjectsList.Add(project);
//                }
//                conn.Close();
//            }
//            return ProjectsList;
//        }

//        public void CreateProject(ProjectsModel projectsModel)
//        {
//            using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("Dbaseconnection")))
//            {
//                string sqlQuery =
//                    "INSERT INTO ProjectsTable VALUES(@name)";

//                using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
//                {
//                    sqlConnection.Open();
//                    SqlCommand sqlCmd = new SqlCommand(sqlQuery, sqlConnection);
//                    sqlCmd.Parameters.AddWithValue("@name", projectsModel.ProjectName);
//                    sqlCmd.ExecuteNonQuery();
//                }
//            }
//        }
//    }
//}
