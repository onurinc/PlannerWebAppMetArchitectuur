using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using LogicLayer.DAO;

namespace ProjectsOnlyCRUDWithoutEntityTemplate.Models
{
    public class ProjectViewModel
    {
        [Key]
        [Display(Name = "Id")]
        [Required(ErrorMessage = "Please enter an Id")]
        public int Id { get; set; }
        [Display(Name = "Name of the project")]
        [Required(ErrorMessage = "Please enter the name of the project")]
        public string ProjectName { get; set; }

        public ProjectViewModel()
        {

        }

        public ProjectViewModel(ProjectModel projectModel)
        {
            ProjectName = projectModel.Name;
            Id = projectModel.Id;
        }
    }
}
