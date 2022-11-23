using System.ComponentModel.DataAnnotations;

namespace TodoAPI.Model.Dtos
{
    public class TodoDto
    {
        [Required]
        public string Task { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
       
        public bool IsDone { get; set; }  


    }
}
