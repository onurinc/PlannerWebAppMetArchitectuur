using DataAccesLayer.Data.Data_Transfer_Object;

namespace LogicLayer.Models
{
    public class UsersModel
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public UsersModel(UsersDTO usersDto)
        {
            UserId = usersDto.UserId;
            Username = usersDto.Username;
        }
    }
}
