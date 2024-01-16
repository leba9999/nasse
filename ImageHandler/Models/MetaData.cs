using System.ComponentModel.DataAnnotations;

namespace ImageHandler.Models
{
    public class MetaData
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Sizes Size { get; set; }

        public Camera? CameraType { get; set; }

        public Extenssions? ExtenssionType { get; set; }

        public CameraData? CameraData { get; set; }

        [Required]
        public Image Image { get; set; }
    }
}