using System.ComponentModel.DataAnnotations;

namespace ProjectsService.Models
{
    public class Project
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
