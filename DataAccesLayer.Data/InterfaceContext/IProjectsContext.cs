using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccesLayer.Data
{
    public interface IProjectsContext
    {
        IEnumerable<ProjectsDTO> GetAllProjects();

        ProjectsDTO GetProject(int id);

    }
}
