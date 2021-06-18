using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogicLayer.InterfaceContainer;
using PlannerWebApp.ViewModel;

namespace PlannerWebApp.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersContainer _usersContainer;

        public UsersController(IUsersContainer usersContainer)
        {
            this._usersContainer = usersContainer;
        }

        public IActionResult Index()
        {
            List<UsersViewModel> users = new List<UsersViewModel>();
            var user = _usersContainer.GetAllUsers();
            foreach (var p in user)
            {
                users.Add(new UsersViewModel(p));
            }
            return View(users);
        }


    }
}
