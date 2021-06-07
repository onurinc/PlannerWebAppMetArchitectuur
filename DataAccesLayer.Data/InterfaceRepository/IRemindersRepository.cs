using System.Collections.Generic;
using DataAccesLayer.Data.Data_Transfer_Object;

namespace DataAccesLayer.Data.InterfaceRepository
{
    interface IRemindersRepository
    {
        public List<RemindersDTO> GetAllReminders();

        public RemindersDTO GetReminder(int id);

        public void AddReminder(RemindersDTO reminder);

        public void EditReminder(RemindersDTO reminder);

        public void DeleteReminder(int id);
    }
}
