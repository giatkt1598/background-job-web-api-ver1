using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgroundJobsWebApi.Domain.Entities
{
    public record AppBackgroundJob
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string JobName { get; set; }
        public string JobArgs { get; set; }
        public int Priority { get; set; }
        public bool IsFailure { get; set; }
        public string? Detail { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
