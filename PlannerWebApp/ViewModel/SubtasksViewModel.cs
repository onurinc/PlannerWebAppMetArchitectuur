using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using LogicLayer.Models;
using Microsoft.CodeAnalysis;

namespace PlannerWebApp.ViewModel
{
    public class SubtasksViewModel
    {
        [Key]
        [Display(Name = "Id")]
        [Required(ErrorMessage = "Please enter an Id")]
        public int SubtaskId { get; set; }

        [Display(Name = "ProjectId")]
        [Required(ErrorMessage = "Please enter an Project Id")]
        public int ProjectId { get; set; }

        [Display(Name = "Status of the subtask")]
        [Required(ErrorMessage = "Please enter the status of the subtask")]
        public bool SubtaskStatus { get; set; }

        [Display(Name = "Name of the subtask")]
        [Required(ErrorMessage = "Please enter the name of the subtask")]
        public string SubtaskName { get; set; }

        [Display(Name = "Project Description")]
        [Required(ErrorMessage = "Please enter the description of the subtask")]
        public string SubtaskDescription { get; set; }

        [Display(Name = "Subtask Label")]
        [Required(ErrorMessage = "Please enter the label of the subtask")]
        public string SubtaskLabel { get; set; }

        public SubtasksViewModel()
        {
        }

        public SubtasksViewModel(SubtasksModel subtasksModel)
        {
            SubtaskId = subtasksModel.SubtaskId;
            ProjectId = subtasksModel.ProjectId;
            SubtaskStatus = subtasksModel.SubtaskStatus;
            SubtaskName = subtasksModel.SubtaskName;
            SubtaskDescription = subtasksModel.SubtaskDescription;
            SubtaskLabel = subtasksModel.SubtaskLabel;
        }
    }
}
