using System.Drawing;

namespace TagsCloudContainer.ExtensionPoints.WordDrawers
{
    /// <summary>
    /// Должна быть возможность задать цвета, шрифт и размер изображения.
    /// В перспективе — поддерживать разные алгоритмы расцветки слов.
    /// </summary>
    interface IWordDrawer
    {
        Size GetOptimalWordSize(Graphics graphics, string word, double height);
        void DrawWordIn(Graphics graphics, string word, double height, double x, double y);
    }
}