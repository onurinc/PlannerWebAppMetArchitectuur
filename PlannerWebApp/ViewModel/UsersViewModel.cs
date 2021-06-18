using System.ComponentModel.DataAnnotations;
using LogicLayer.Models;

namespace PlannerWebApp.ViewModel
{
    public class UsersViewModel
    {
        [Key]
        [Display(Name = "User Id")]
        public int UserId { get; set; }

        [Display(Name = "Name of the User")]
        public string UserName { get; set; }
        public UsersViewModel()
        {
        }

        public UsersViewModel(UsersModel usersModel)
        {
            UserId = usersModel.UserId;
            UserName = usersModel.Username;

        }
    }
}
