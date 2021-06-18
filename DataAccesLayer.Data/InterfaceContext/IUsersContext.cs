using System;
using System.Collections.Generic;
using System.Text;
using DataAccesLayer.Data.Data_Transfer_Object;

namespace DataAccesLayer.Data.InterfaceContext
{
    public interface IUsersContext
    {
        IEnumerable<UsersDTO> GetAllUsers();

        UsersDTO GetUser(int id);
    }
}
