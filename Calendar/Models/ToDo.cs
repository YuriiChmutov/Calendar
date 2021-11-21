using System;

namespace Calendar.Models
{
    public class ToDo
    {
        public Guid TodoId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateOfCreation { get; set; }
        public bool IsDone { get; set; }
        public bool IsImportant { get; set; }
        public DateTime DateToFinish { get; set; }
    }
}