using System.Collections.Generic;
using DataAccesLayer.Data.Data_Transfer_Object;

namespace DataAccesLayer.Data.InterfaceRepository
{
    public interface ISubtasksRepository
    {
        public List<SubtasksDTO> GetAllSubtasks();

        public SubtasksDTO GetSubtask(int id);

        public void AddSubtask(SubtasksDTO subtask);

        public void EditSubtask(SubtasksDTO subtask);

        public void DeleteSubtask(int id);
    }
}
