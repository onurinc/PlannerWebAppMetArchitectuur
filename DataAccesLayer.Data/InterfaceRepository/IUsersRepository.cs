using System;
using System.Collections.Generic;
using System.Text;
using DataAccesLayer.Data.Data_Transfer_Object;

namespace DataAccesLayer.Data.InterfaceRepository
{
    public interface IUsersRepository
    {
        public List<UsersDTO> GetAllUsers();

        public UsersDTO GetUser(int id);

    }
}
