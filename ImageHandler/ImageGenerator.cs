using System;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace ImageHandler
{
    public class ImageGenerator
    {

        private int _width;
        private int _height;
        public string SourceFullPath { get; set; }
        public string OutputFullPath { get; set; }
        public int Width 
        { 
            get {  return _width; } 
            set 
            {
                if (value < 0)
                {
                    throw new ArgumentException("widht cannot be negative");
                }
                _width = value;
            }
        }
        public int Height
        {
            get { return _height; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("height cannot be negative");
                }
                _height = value;
            }
        }

        public ImageGenerator()
        {
            SourceFullPath = "";
            OutputFullPath = "";
            _width = 0;
            _height = 0;
        }
        public Image PreviewImage()
        {
            if (SourceFullPath == null || SourceFullPath == string.Empty)
            {
                throw new ArgumentException("sourceFullPath cannot be null or empty");
            }
            using (var image = Image.Load(SourceFullPath))
            {
                if (_width == 0)
                {
                    _width = image.Width;
                }
                if (_height == 0)
                {
                    _height = image.Height;
                }
                if (OutputFullPath == null || OutputFullPath == string.Empty)
                {
                    OutputFullPath = SourceFullPath;
                }

                image.Mutate(x => x
                    .Resize(new ResizeOptions
                    {
                        Size = new Size(_width, _height),
                        Mode = ResizeMode.Max
                    }));
                // Save the preview image
                image.Save(OutputFullPath);
                return image;
            }
        }

        public Image PreviewImage(string sourcePath, string outputPath)
        {
            if (sourcePath == null || sourcePath == string.Empty)
            {
                throw new ArgumentException("sourcePath cannot be null or empty");
            }
            if (outputPath == null || outputPath == string.Empty)
            {
                throw new ArgumentException("outputPath cannot be null or empty");
            }
            using (var image = Image.Load(sourcePath))
            {
                if (_width == 0)
                {
                    _width = image.Width;
                }
                if (_height == 0)
                {
                    _height = image.Height;
                }

                image.Mutate(x => x
                    .Resize(new ResizeOptions
                    {
                        Size = new Size(_width, _height),
                        Mode = ResizeMode.Max
                    }));

                // Save the preview image
                image.Save(outputPath);
                return image;
            }
        }
    }
}
