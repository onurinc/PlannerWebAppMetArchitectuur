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
        public int ProjectId { get; set; }

        [Display(Name = "UserId")]
        [Required(ErrorMessage = "Please enter an User Id")]
        public int UserId { get; set; }

        [Display(Name = "Name of the project")]
        [Required(ErrorMessage = "Please enter the name of the project")]
        public string ProjectName { get; set; }

        [Display(Name = "Project Description")]
        [Required(ErrorMessage = "Please enter the description of the project")]
        public string ProjectDescription { get; set; }

        public ProjectViewModel()
        {
        }

        public ProjectViewModel(ProjectModel projectModel)
        {
            ProjectId = projectModel.ProjectId;
            UserId = projectModel.UserId;
            ProjectName = projectModel.ProjectName;
            ProjectDescription = projectModel.ProjectDescription;
        }
    }
}
