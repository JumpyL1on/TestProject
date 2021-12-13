namespace TestProject.Models
{
    public class IssueData
    {
        public string Summary { get; set; }
        public string Description { get; set; }

        public IssueData()
        {

        }

        public IssueData(string summary, string description)
        {
            Summary = summary;
            Description = description;
        }
    }
}