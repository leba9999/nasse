using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageHandler.Models
{
    public class Image
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public DateTime? UpdatedDate { get; set;}

        public bool ThumbnailGenerated { get; set; }

        public int MetadataId { get; set; }
        [Required]
        public MetaData Metadata { get; set; }
    }
}
