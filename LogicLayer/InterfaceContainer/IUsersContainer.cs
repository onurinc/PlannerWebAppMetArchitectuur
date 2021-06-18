using System;
using System.Collections.Generic;
using System.Text;
using LogicLayer.Models;

namespace LogicLayer.InterfaceContainer
{
    public interface IUsersContainer
    {
        public List<UsersModel> GetAllUsers();

        public UsersModel GetUser(int id);
    }
}
