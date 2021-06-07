using System.Collections.Generic;
using DataAccesLayer.Data.Data_Transfer_Object;
using DataAccesLayer.Data.InterfaceRepository;
using LogicLayer.InterfaceContainer;
using LogicLayer.Models;

namespace LogicLayer.Container
{
    class RemindersContainer : IRemindersContainer
    {
        private readonly IRemindersRepository _reminderRepo;

        public RemindersContainer(IRemindersRepository reminderRepo)
        {
            this._reminderRepo = reminderRepo;
        }

        public List<RemindersModel> GetAllReminders()
        {
            List<RemindersModel> reminders = new List<RemindersModel>();

            var reminderdto = _reminderRepo.GetAllReminders();

            foreach (var dto in reminderdto)
            {
                reminders.Add(new RemindersModel(dto));
            }
            return reminders;
        }

        public void AddReminder(int userId, string reminderName, string reminderDescription)
        {
            _reminderRepo.AddReminder(new RemindersDTO() { UserId = userId, ReminderName = reminderName, ReminderDescription = reminderDescription });
        }

        public RemindersModel GetReminder(int id)
        {
            var reminder = _reminderRepo.GetReminder(id);
            RemindersModel reminderModel = new RemindersModel(reminder);
            return reminderModel;
        }

        public void EditReminder(int id, int userId, string reminderName, string reminderDescription)
        {
            _reminderRepo.AddReminder(new RemindersDTO() { ReminderId = id, UserId = userId, ReminderName = reminderName, ReminderDescription = reminderDescription });
        }
        public void DeleteReminder(int id)
        {
            _reminderRepo.DeleteReminder(id);
        }
    }
}
