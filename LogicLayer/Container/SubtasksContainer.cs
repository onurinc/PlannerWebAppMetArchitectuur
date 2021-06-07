using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccesLayer.Data.InterfaceRepository;
using LogicLayer.InterfaceContainer;
using LogicLayer.Models;

namespace LogicLayer.Container
{
    public class SubtasksContainer : ISubtasksContainer
    {
        private readonly ISubtasksRepository _subtaskRepo;

        public SubtasksContainer(ISubtasksRepository subtaskRepo)
        {
            this._subtaskRepo = subtaskRepo;
        }

        public List<SubtasksModel> GetAllSubtasks()
        {
            List<SubtasksModel> subtasks = new List<SubtasksModel>();

            var subtasksdto = _subtaskRepo.GetAllSubtasks();

            foreach (var dto in subtasksdto)
            {
                subtasks.Add(new SubtasksModel(dto));
            }
            return subtasks;
        }

        public SubtasksModel GetSubtask(int id)
        {
            throw new NotImplementedException();
        }

        public void AddSubtask(int projectId, bool subtaskStatus, string subtaskName, string subtaskDescription, string subtaskLabel)
        {
            throw new NotImplementedException();
        }

        public void EditSubtask(int id, int projectId, bool subtaskStatus, string subtaskName, string subtaskDescription,
            string subtaskLabel)
        {
            throw new NotImplementedException();
        }

        public void DeleteSubtask(int id)
        {
            throw new NotImplementedException();
        }
    }
}
