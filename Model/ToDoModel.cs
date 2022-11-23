using System;

namespace TodoAPI.Model
{
    public class ToDoModel
    {
        public string Id { get; set; } = Guid.NewGuid().ToString(); 
        public string Task  { get; set; }

        public string Description { get; set; } 

        public bool IsDone { get; set; }    

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
      
            
    }
}
