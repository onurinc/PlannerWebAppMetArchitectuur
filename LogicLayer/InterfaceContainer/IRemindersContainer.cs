﻿using System.Collections.Generic;
using LogicLayer.DAO;
using LogicLayer.Models;

namespace LogicLayer.InterfaceContainer
{
    interface IRemindersContainer
    {
        public List<RemindersModel> GetAllReminders();

        public RemindersModel GetReminder(int id);

        public void AddReminder(int userId, string projectName, string projectDescription);

        public void EditReminder(int id, int userId, string projectName, string projectDescription);

        public void DeleteReminder(int id);
    }
}
