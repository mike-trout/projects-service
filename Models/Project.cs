using System.ComponentModel.DataAnnotations;

namespace ProjectsService.Models
{
    public class Project
    {
        [Key]
        [Required]
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
