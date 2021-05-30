using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using LogicLayer.DAO;
using LogicLayer.Models;

namespace ProjectsOnlyCRUDWithoutEntityTemplate.ViewModel
{
    public class NotesViewModel
    {
        [Key]
        [Display(Name = "Note Id")]
        [Required(ErrorMessage = "Please enter an NoteId")]
        public int NoteId { get; set; }
        [Display(Name = "Name of the Note")]
        [Required(ErrorMessage = "Please enter the name of the Note")]
        public string NoteName { get; set; }
        [Display(Name = "Description of the Note")]
        [Required(ErrorMessage = "Please enter the description of the Note")]
        public string Description { get; set; }
        [Display(Name = "Urgency of the Note")]
        [Required(ErrorMessage = "Please enter the urgency of the Note")]
        public string Urgency { get; set; }
        [Display(Name = "Project Id")]
        [Required(ErrorMessage = "Please enter an Id")]
        public int Id { get; set; }

        public NotesViewModel()
        {

        }

        public NotesViewModel(NotesModel notesModel)
        {
            NoteId = notesModel.NoteId;
            NoteName = notesModel.NoteName;
            Description = notesModel.Description;
            Urgency = notesModel.Urgency;
            Id = notesModel.Id;

        }
    }
}
