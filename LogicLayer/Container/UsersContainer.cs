using System.Collections.Generic;
using DataAccesLayer.Data.InterfaceRepository;
using LogicLayer.InterfaceContainer;
using LogicLayer.Models;

namespace LogicLayer.Container
{
    public class UsersContainer : IUsersContainer
    {
        private readonly IUsersRepository _usersRepo;

        public UsersContainer(IUsersRepository userRepo)
        {
            this._usersRepo = userRepo;
        }

        public List<UsersModel> GetAllUsers()
        {
            List<UsersModel> users = new List<UsersModel>();

            var usersdto = _usersRepo.GetAllUsers();

            foreach (var dto in usersdto)
            {
                users.Add(new UsersModel(dto));
            }
            return users;
        }

        public UsersModel GetUser(int id)
        {
            var user = _usersRepo.GetUser(id);
            UsersModel userModel = new UsersModel(user);
            return userModel;
        }
    }
}
