using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccesLayer.Data.Context;
using DataAccesLayer.Data.Data_Transfer_Object;
using DataAccesLayer.Data.InterfaceContext;
using DataAccesLayer.Data.InterfaceRepository;

namespace DataAccesLayer.Data.Repository
{
    public class UsersRepository : IUsersRepository
    {
        private readonly IUsersContext _usersContext;

        public UsersRepository(IUsersContext usersContext)
        {
            this._usersContext = usersContext;
        }

        public UsersRepository()
        {
            this._usersContext = new UsersContext();
        }

        public List<UsersDTO> GetAllUsers()
        {
            return _usersContext.GetAllUsers().ToList();
        }

        public UsersDTO GetUser(int id)
        {
            return _usersContext.GetUser(id);
        }

    }
}
