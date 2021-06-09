using System.Collections.Generic;
using DataAccesLayer.Data.Data_Transfer_Object;

namespace DataAccesLayer.Data.InterfaceContext
{
    public interface IRemindersContext
    {
        IEnumerable<RemindersDTO> GetAllReminders();

        public void AddReminder(RemindersDTO reminder);

        RemindersDTO GetReminder(int id);

        void EditReminder(RemindersDTO reminder);

        public void DeleteReminder(int id);
    }
}
