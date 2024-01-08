using ImageHandler;
using SixLabors.ImageSharp;
using System.Reflection;

namespace TestImageHandler.UnitTests
{
    public class ImageGeneratorTests
    {
        private ImageGenerator _imageGen;
        private string originalImagePath = "";
        private string outputImagePath = "";

        [SetUp]
        public void Setup()
        {
            _imageGen = new ImageGenerator();
            string? assemblyLocation = Assembly.GetExecutingAssembly().Location;
            string assemblyDirectory = Path.GetDirectoryName(assemblyLocation) ?? string.Empty;
            originalImagePath = Path.Combine(assemblyDirectory, "IMG_9149.JPG");
            outputImagePath = Path.Combine(assemblyDirectory, "IMG_9149_1.JPG");
            if (File.Exists(outputImagePath))
            {
                File.Delete(outputImagePath);
            }
        }

        [TearDown]
        public void TearDown()
        {
            if (File.Exists(outputImagePath))
            {
                File.Delete(outputImagePath);
            }
        }

        [Test, Description("Test successfull preview generation")]
        public void TestPreviewOverload_1()
        {
            _imageGen.Width = 1000;
            _imageGen.SourceFullPath = originalImagePath;
            _imageGen.OutputFullPath = outputImagePath;
            Assert.IsFalse(File.Exists(outputImagePath), "Image should not already exists");
            var originalImage = Image.Load(originalImagePath);
            var resizeImage = _imageGen.PreviewImage();

            Assert.IsTrue(File.Exists(originalImagePath));
            Assert.IsTrue(File.Exists(outputImagePath));
            Assert.That(originalImage.Width, Is.Not.EqualTo(resizeImage.Width));
            Assert.That(originalImage.Height, Is.Not.EqualTo(resizeImage.Height));
            Assert.That(_imageGen.Width, Is.EqualTo(resizeImage.Width));
        }

        [Test, Description("Test successfull preview generation")]
        public void TestPreviewOverload_2()
        {
            _imageGen.Height = 1000;
            Assert.IsFalse(File.Exists(outputImagePath), "Image should not already exists");
            var originalImage = Image.Load(originalImagePath);
            var resizeImage = _imageGen.PreviewImage(originalImagePath, outputImagePath);

            Assert.IsTrue(File.Exists(originalImagePath));
            Assert.IsTrue(File.Exists(outputImagePath));
            Assert.That(originalImage.Width, Is.Not.EqualTo(resizeImage.Width));
            Assert.That(originalImage.Height, Is.Not.EqualTo(resizeImage.Height));
            Assert.That(_imageGen.Height, Is.EqualTo(resizeImage.Height));
        }
        [Test, Description("Test Exceptions")]
        public void TestPreviewExceptions()
        {
            Assert.IsFalse(File.Exists(outputImagePath), "Image should not already exists");
            ArgumentException ex = Assert.Throws<ArgumentException>(() =>
            {
                _imageGen.PreviewImage();
            });
            ArgumentException inputEx = Assert.Throws<ArgumentException>(() =>
            {
                _imageGen.PreviewImage(string.Empty, outputImagePath);
            });
            ArgumentException outputEx = Assert.Throws<ArgumentException>(() =>
            {
                _imageGen.PreviewImage(originalImagePath, string.Empty);
            });
            StringAssert.Contains("cannot be null or empty", ex.Message);
            StringAssert.Contains("cannot be null or empty", inputEx.Message);
            StringAssert.Contains("cannot be null or empty", outputEx.Message);
        }
        [Test, Description("Test Width attribute")]
        public void TestWidth()
        {
            Assert.IsFalse(File.Exists(outputImagePath), "Image should not already exists");
            ArgumentException widthEx = Assert.Throws<ArgumentException>(() =>
            {
                _imageGen.Width = int.MinValue;
            });
            _imageGen.Width = int.MaxValue;
            StringAssert.Contains("cannot be negative", widthEx.Message);
            Assert.That(_imageGen.Width, Is.EqualTo(int.MaxValue));
        }
        [Test, Description("Test height attribute")]
        public void TestHeight()
        {
            Assert.IsFalse(File.Exists(outputImagePath), "Image should not already exists");
            ArgumentException heighthEx = Assert.Throws<ArgumentException>(() =>
            {
                _imageGen.Height = int.MinValue;
            });
            _imageGen.Height = int.MaxValue;
            StringAssert.Contains("cannot be negative", heighthEx.Message);
            Assert.That(_imageGen.Height, Is.EqualTo(int.MaxValue));
        }
    }
}