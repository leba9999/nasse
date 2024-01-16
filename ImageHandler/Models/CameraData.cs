using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageHandler.Models
{
    public class CameraData
    {
        [Key]
        public int Id { get; set; }

        public string? Flash { get; set; }
        public string? WhiteBalance { get; set; }
        public string? FocalLenght { get; set; }
        public string? ExposureTime { get; set; }
        public string? Aperture { get; set; }
        public string? ISOSpeed { get; set; }
        public string? ShutterSpeed { get; set; }
        public string? Contrast { get; set; }
        public string? ColorSpace { get; set; }


    }
}
