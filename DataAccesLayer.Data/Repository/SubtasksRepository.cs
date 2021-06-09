using System.Collections.Generic;
using System.Linq;
using DataAccesLayer.Data.Data_Transfer_Object;
using DataAccesLayer.Data.InterfaceContext;
using DataAccesLayer.Data.InterfaceRepository;

namespace DataAccesLayer.Data.Repository
{
    public class SubtasksRepository : ISubtasksRepository
    {
        private readonly ISubtasksContext _subtasksContext;

        public SubtasksRepository(ISubtasksContext subtasksContext)
        {
            this._subtasksContext = subtasksContext;
        }

        public List<SubtasksDTO> GetAllSubtasks()
        {
            return _subtasksContext.GetAllSubtasks().ToList();
        }

        public SubtasksDTO GetSubtask(int id)
        {
            return _subtasksContext.GetSubtask(id);
        }

        public void AddSubtask(SubtasksDTO subtask)
        {
            _subtasksContext.AddSubtask(subtask);
        }

        public void EditSubtask(SubtasksDTO subtask)
        {
            _subtasksContext.EditSubtask(subtask);
        }

        public void DeleteSubtask(int id)
        {
            _subtasksContext.DeleteSubtask(id);
        }
    }
}
