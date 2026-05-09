using System;

namespace ApplicationCore.Entities
{
    public class Report
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public string Issue { get; set; }
        public DateTime CreatedDate { get; set; }

        public User User { get; set; }
    }
}
