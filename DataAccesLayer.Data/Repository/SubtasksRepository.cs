using System;
using System.Collections.Generic;
using System.Linq;
using DataAccesLayer.Data.Data_Transfer_Object;
using DataAccesLayer.Data.InterfaceContext;
using DataAccesLayer.Data.InterfaceRepository;

namespace DataAccesLayer.Data.Repository
{
    public class SubtasksRepository : ISubtasksRepository
    {
        private ISubtasksContext _context;

        public SubtasksRepository(ISubtasksContext context)
        {
            this._context = context;
        }

        public List<SubtasksDTO> GetAllSubtasks()
        {
            return _context.GetAllSubtasks().ToList();
        }

        public SubtasksDTO GetSubtask(int id)
        {
            throw new NotImplementedException();
        }

        public void AddSubtask(SubtasksDTO subtask)
        {
            throw new NotImplementedException();
        }

        public void EditSubtask(SubtasksDTO subtask)
        {
            throw new NotImplementedException();
        }

        public void DeleteSubtask(int id)
        {
            throw new NotImplementedException();
        }
    }
}
