using System.Collections.Generic;
using System.Linq;
using DataAccesLayer.Data.Data_Transfer_Object;
using DataAccesLayer.Data.InterfaceContext;
using DataAccesLayer.Data.InterfaceRepository;

namespace DataAccesLayer.Data.Repository
{
    public class RemindersRepository : IRemindersRepository
    {
        private readonly IRemindersContext _remindersContext;

        public RemindersRepository(IRemindersContext remindersContext)
        {
            this._remindersContext = remindersContext;
        }

        public List<RemindersDTO> GetAllReminders()
        {
            return _remindersContext.GetAllReminders().ToList();
        }

        public void AddReminder(RemindersDTO reminder)
        {
            _remindersContext.AddReminder(reminder);
        }
        public RemindersDTO GetReminder(int id)
        {
            return _remindersContext.GetReminder(id);
        }

        public void EditReminder(RemindersDTO reminder)
        {
            _remindersContext.EditReminder(reminder);
        }
        public void DeleteReminder(int id)
        {
            _remindersContext.DeleteReminder(id);
        }
    }
}
