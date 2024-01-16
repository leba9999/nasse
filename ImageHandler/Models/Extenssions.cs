using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageHandler.Models
{
    public class Extenssions
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }
    }
}
