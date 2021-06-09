



namespace DataAccesLayer.Data
{
    public class ProjectsDTO
    {
        public int ProjectId { get; set; }
        public int UserId { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }

        public ProjectsDTO()
        {
        }

        public ProjectsDTO(int projectId, int userId, string projectName, string projectDescription)
        {
            ProjectId = projectId;
            UserId = userId;
            ProjectName = projectName;
            ProjectDescription = projectDescription;
        }

    }
}
