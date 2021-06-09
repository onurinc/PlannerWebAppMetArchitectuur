



namespace DataAccesLayer.Data.Data_Transfer_Object
{
    public class SubtasksDTO
    {
        public int SubtaskId { get; set; }
        public int ProjectId { get; set; }
        public bool SubtaskStatus { get; set; }
        public string SubtaskName { get; set; }
        public string SubtaskDescription { get; set; }
        public string SubtaskLabel { get; set; }

    }
}
