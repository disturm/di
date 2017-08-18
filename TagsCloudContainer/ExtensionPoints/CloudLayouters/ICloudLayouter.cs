using System.Collections.Generic;
using System.Drawing;

namespace TagsCloudContainer.ExtensionPoints.CloudLayouters
{
    interface ICloudLayouter
    {
        IList<Rectangle> PutIntoCloud(Point center, IReadOnlyCollection<Size> sizes);
    }
}