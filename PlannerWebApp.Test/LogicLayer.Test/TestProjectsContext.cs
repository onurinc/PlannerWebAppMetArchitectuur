//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using DataAccesLayer.Data;
//using Microsoft.CodeAnalysis;


//namespace PlannerWebApp.Test.LogicLayer.Test
//{
//    class TestProjectsContext : IProjectsContext
//    {
//        private List<ProjectsDTO> testProjects = new List<ProjectsDTO>();

//        public TestProjectsContext()
//        {
//            ProjectsDTO project1 = new ProjectsDTO(1, "TestProjectOne");
//            testProjects.Add(project1);
//        }

//        public IEnumerable<ProjectsDTO> GetAllProjects()
//        {
//            return testProjects;
//        }

//        public void AddProject(ProjectsDTO project)
//        {
//            throw new NotImplementedException();
//        }

//        public void DeleteProject(int id)
//        {
//            throw new NotImplementedException();
//        }

//        public void EditProject(ProjectsDTO project)
//        {
//            throw new NotImplementedException();
//        }


//        public ProjectsDTO GetProject(int id)
//        {
//            return testProjects.First(p => p.ProjectId == id);
//        }
//    }
//}
