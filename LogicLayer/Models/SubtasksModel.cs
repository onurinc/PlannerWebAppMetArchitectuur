using DataAccesLayer.Data.Data_Transfer_Object;

namespace LogicLayer.Models
{
    public class SubtasksModel
    {
        public int SubtaskId { get; set; }
        public int ProjectId { get; set; }
        public bool SubtaskStatus { get; set; }
        public string SubtaskName { get; set; }
        public string SubtaskDescription { get; set; }
        public string SubtaskLabel { get; set; }


        public SubtasksModel(SubtasksDTO subtasksDto)
        {
            SubtaskId = subtasksDto.SubtaskId;
            ProjectId = subtasksDto.ProjectId;
            SubtaskStatus = subtasksDto.SubtaskStatus;
            SubtaskName = subtasksDto.SubtaskName;
            SubtaskDescription = subtasksDto.SubtaskDescription;
            SubtaskLabel = subtasksDto.SubtaskLabel;

        }
    }
}
