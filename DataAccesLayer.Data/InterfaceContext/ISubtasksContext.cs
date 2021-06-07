using System;
using System.Collections.Generic;
using System.Text;
using DataAccesLayer.Data.Data_Transfer_Object;

namespace DataAccesLayer.Data.InterfaceContext
{
    public interface ISubtasksContext
    {
        IEnumerable<SubtasksDTO> GetAllSubtasks();

        public void AddSubtask(SubtasksDTO subtask);

        SubtasksDTO GetSubtask(int id);

        void EditSubtask(SubtasksDTO subtask);

        public void DeleteSubtask(int id);
    }
}
