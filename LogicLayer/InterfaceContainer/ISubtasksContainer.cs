using System;
using System.Collections.Generic;
using System.Text;
using LogicLayer.Models;

namespace LogicLayer.InterfaceContainer
{
    public interface ISubtasksContainer
    {
        public List<SubtasksModel> GetAllSubtasks();

        public SubtasksModel GetSubtask(int id);

        public void AddSubtask(int projectId, bool subtaskStatus, string subtaskName, string subtaskDescription, string subtaskLabel);

        public void EditSubtask(int id, int projectId, bool subtaskStatus, string subtaskName, string subtaskDescription, string subtaskLabel);

        public void DeleteSubtask(int id);
    }
}
