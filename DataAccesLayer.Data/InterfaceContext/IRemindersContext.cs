using System;
using System.Collections.Generic;
using System.Text;
using DataAccesLayer.Data.Data_Transfer_Object;

namespace DataAccesLayer.Data.InterfaceContext
{
    interface IRemindersContext
    {
        IEnumerable<RemindersDTO> GetAllReminders();
        public void AddReminder(RemindersDTO reminder);

        RemindersDTO GetReminder(int id);

        void EditReminder(RemindersDTO reminder);

        public void DeleteReminder(int id);
    }
}
