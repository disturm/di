using System.Collections.Generic;
using System.Drawing;

namespace TagsCloudContainer.Internal
{
    /// <summary>
    /// строим heights по статистике
    /// делегируем построение sizes
    /// делегируем построение прямоугольников
    /// рисуем их в Image с помощью делегирования
    /// </summary>
    interface ITagsCloudBuilder
    {
        Image BuildTagsCloud(IReadOnlyCollection<string> words, int width, int height);
    }
}