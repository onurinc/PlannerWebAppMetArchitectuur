using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using LogicLayer.Models;

namespace PlannerWebApp.ViewModel
{
    public class NotesIJProjectsViewModel
    {
        [Key]
        [Display(Name = "Note Id")]
        [Required(ErrorMessage = "Please enter an NoteId")]
        public int NoteId { get; set; }

        [Display(Name = "Name of the Project")]
        [Required(ErrorMessage = "Please enter the name of the Project")]
        public string ProjectName { get; set; }

        [Display(Name = "Name of the Note")]
        [Required(ErrorMessage = "Please enter the name of the Note")]
        public string NoteName { get; set; }

        [Display(Name = "Description of the Note")]
        [Required(ErrorMessage = "Please enter the description of the Note")]
        public string Description { get; set; }

        [Display(Name = "Urgency of the Note")]
        [Required(ErrorMessage = "Please enter the urgency of the Note")]
        public string Urgency { get; set; }

        public NotesIJProjectsViewModel()
        {
        }

        public NotesIJProjectsViewModel(NotesIJProjectsModel notesIJProjectsModel)
        {
            NoteId = notesIJProjectsModel.NoteId;
            ProjectName = notesIJProjectsModel.ProjectName;
            NoteName = notesIJProjectsModel.NoteName;
            Description = notesIJProjectsModel.Description;
            Urgency = notesIJProjectsModel.Urgency;
        }
    }
}
