using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class ToDo
    {
        public Guid TodoId { get; set; }
        
        [Required]
        public string? Name { get; set; }
        public string? Description { get; set; }
        
        [Display(Name = "Creating date")]
        public DateTime DateOfCreation { get; set; }
        
        [Display(Name = "Is done?")]
        public bool IsDone { get; set; }
        
        [Display(Name = "Important")]
        public bool IsImportant { get; set; }
        
        [Display(Name = "Date of end")]
        public DateTime DateToFinish { get; set; }
    }
}