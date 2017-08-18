using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using TagsCloudVisualization;

namespace TagsCloudContainer.ExtensionPoints.CloudLayouters
{
    class CloudLayouter : ICloudLayouter
    {
        public IList<Rectangle> PutIntoCloud(Point center, IReadOnlyCollection<Size> sizes)
        {
            var layouter = new CircularCloudLayouter(center);
            return sizes.Select(size => layouter.PutNextRectangle(size)).ToArray();
        }
    }
}