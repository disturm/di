using System.Drawing;

namespace TagsCloudContainer.ExtensionPoints.ImageWriters
{
    /// <summary>
    /// В качестве результата программа должна генерировать png-файл.
    /// В перспективе — поддерживать разные форматы изображений.
    /// </summary>
    interface IImageWriter
    {
        void WriteImageTo(Image image, string filePath);
    }
}