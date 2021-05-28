using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogicLayer.Container;
using ProjectsOnlyCRUDWithoutEntityTemplate.Models;

namespace ProjectsOnlyCRUDWithoutEntityTemplate.ContainerPL
{
    public class ProjectsContainerPL
    {
        ProjectContainer pContainer = new ProjectContainer();

        public List<ProjectViewModel> GetAllProjects()
        {
            List<ProjectViewModel> projects = new List<ProjectViewModel>();
            var project = pContainer.GetAllProjects();
            foreach (var p in project)
            {
                projects.Add(new ProjectViewModel(p));
            }
            return projects;
        }
    }
}
