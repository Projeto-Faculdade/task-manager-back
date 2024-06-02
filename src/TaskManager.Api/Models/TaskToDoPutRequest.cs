using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TaskManager.Api.Models
{
    public class TaskToDoPutRequest
    {   
        [JsonIgnore]
        public Guid Id { get; set;}

        [Required]
        public string Name { get; set; } = string.Empty!;

        [Required]
        public string Course { get; set; } = string.Empty!;

        [Required]
        public DateTime LimitDate { get; set; }

        [Required]
        public Guid StudentId { get; set; }
      
    }
}