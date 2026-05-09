namespace ApplicationCore.Models
{
    public class ReportModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Issue { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
