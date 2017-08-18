using System.Drawing;

namespace TagsCloudContainer.ExtensionPoints.ImageWriters
{
    class ImageWriter : IImageWriter
    {
        public void WriteImageTo(Image image, string filePath)
        {
            image.Save(filePath);
        }
    }
}