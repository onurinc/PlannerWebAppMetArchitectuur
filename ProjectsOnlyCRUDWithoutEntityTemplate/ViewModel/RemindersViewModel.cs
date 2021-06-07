using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using LogicLayer.DAO;
using LogicLayer.Models;

namespace ProjectsOnlyCRUDWithoutEntityTemplate.ViewModel
{
    public class RemindersViewModel
    {
        [Key]
        [Display(Name = "Id")]
        [Required(ErrorMessage = "Please enter an Id")]
        public int ReminderId { get; set; }

        [Display(Name = "UserId")]
        [Required(ErrorMessage = "Please enter an User Id")]
        public int UserId { get; set; }

        [Display(Name = "Name of the reminder")]
        [Required(ErrorMessage = "Please enter the name of the reminder")]
        public string ReminderName { get; set; }

        [Display(Name = "Project Description")]
        [Required(ErrorMessage = "Please enter the description of the reminder")]
        public string ReminderDescription { get; set; }

        public RemindersViewModel()
        {
        }

        public RemindersViewModel(RemindersModel remindersModel)
        {
            ReminderId = remindersModel.ReminderId;
            UserId = remindersModel.UserId;
            ReminderName = remindersModel.ReminderName;
            ReminderDescription = remindersModel.ReminderDescription;
        }
    }
}
