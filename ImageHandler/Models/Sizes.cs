using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageHandler.Models
{
    public class Sizes
    {

        [Key]
        public int Id { get; set; }
        [Required] 
        public int Width { get; set; }
        [Required]
        public int Height { get; set; }
    }
}
