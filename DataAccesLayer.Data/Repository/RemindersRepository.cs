using System.Collections.Generic;
using System.Linq;
using DataAccesLayer.Data.Data_Transfer_Object;
using DataAccesLayer.Data.InterfaceContext;
using DataAccesLayer.Data.InterfaceRepository;

namespace DataAccesLayer.Data.Repository
{
    public class RemindersRepository : IRemindersRepository
    {
        private readonly IRemindersContext _context;

        public RemindersRepository(IRemindersContext context)
        {
            this._context = context;
        }

        public List<RemindersDTO> GetAllReminders()
        {
            return _context.GetAllReminders().ToList();
        }

        public void AddReminder(RemindersDTO reminder)
        {
            _context.AddReminder(reminder);
        }
        public RemindersDTO GetReminder(int id)
        {
            return _context.GetReminder(id);
        }

        public void EditReminder(RemindersDTO reminder)
        {
            _context.EditReminder(reminder);
        }
        public void DeleteReminder(int id)
        {
            _context.DeleteReminder(id);
        }
    }
}
