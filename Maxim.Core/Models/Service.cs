using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maxim.Core.Models
{
    public class Service : BaseEntity
    {
        [Required(ErrorMessage = "Enter the information correctly!!!")]
        [StringLength(50)]
        public string Title { get; set; } = null!;
        [StringLength(250)]
        public string Description { get; set; } = null!;
        public string? ServicesImg { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; } = null!;
    }
}
