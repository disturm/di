using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using TagsCloudContainer.ExtensionPoints.CloudLayouters;
using TagsCloudContainer.ExtensionPoints.WordDrawers;

namespace TagsCloudContainer.Internal
{
    //todo tests (one will be enought)
    class TagsCloudBuilder : ITagsCloudBuilder
    {
        private readonly ITagsWeightsBuilder tagsWeightsBuilder;
        private readonly IWordDrawer wordDrawer;
        private readonly ICloudLayouter cloudLayouter;

        public TagsCloudBuilder(ITagsWeightsBuilder tagsWeightsBuilder,
            IWordDrawer wordDrawer,
            ICloudLayouter cloudLayouter)
        {
            this.tagsWeightsBuilder = tagsWeightsBuilder;
            this.wordDrawer = wordDrawer;
            this.cloudLayouter = cloudLayouter;
        }

        public Image BuildTagsCloud(IReadOnlyCollection<string> words, int width, int height)
        {
            var weights = tagsWeightsBuilder.BuildWeights(words);

            var image = new Bitmap(width, height);
            using (var graphics = Graphics.FromImage(image))
            {
                var wordSizes = GetWordSizes(weights, graphics);
                var rectangles = cloudLayouter.PutIntoCloud(new Point(0, 0), wordSizes);
                var ratio = CalculateRatio(rectangles, width, height);
                DrawWordsWithRatio(weights, rectangles, ratio, graphics);
            }
            return image;
        }

        private List<Size> GetWordSizes(IDictionary<string, double> weights, Graphics graphics)
        {
            var sizes = new List<Size>();
            foreach (var wordAndWeight in weights)
            {
                var wordHeight = GetHeight(wordAndWeight.Value);
                var size = wordDrawer.GetOptimalWordSize(graphics, wordAndWeight.Key, wordHeight);
                sizes.Add(size);
            }
            return sizes;
        }

        private double CalculateRatio(IList<Rectangle> rectangles,
            int width, int height)
        {
            var right = rectangles.Max(r => r.Right);
            var bottom = rectangles.Max(r => r.Bottom);
            var left = rectangles.Min(r => r.Left);
            var top = rectangles.Min(r => r.Top);
            var ratio = Math.Min((double)width / (right - left), (double)height / (bottom - top));
            return ratio;
        }

        private void DrawWordsWithRatio(IDictionary<string, double> weights,
            IList<Rectangle> rectangles, double ratio, Graphics graphics)
        {
            var normalizedRectangles = GetNormalizedRectangles(rectangles, ratio);
            var infos = weights.Zip(normalizedRectangles,
                (wordAndWeight, rectangle) => new
                {
                    word = wordAndWeight.Key,
                    weight = wordAndWeight.Value,
                    x = rectangle.X,
                    y = rectangle.Y
                });
            foreach (var info in infos)
            {
                var normalizedHeight = ratio*GetHeight(info.weight);
                wordDrawer.DrawWordIn(graphics, info.word, normalizedHeight, info.x, info.y);
            }
        }

        private IList<Rectangle> GetNormalizedRectangles(IList<Rectangle> rectangles, double ratio)
        {
            var left = rectangles.Min(r => r.Left);
            var top = rectangles.Min(r => r.Top);

            var result = new List<Rectangle>();
            foreach (var rectangle in rectangles)
            {
                var normalized = new Rectangle(
                    (int) ((rectangle.X - left)*ratio),
                    (int) ((rectangle.Y - top)*ratio),
                    (int) (rectangle.Width*ratio),
                    (int) (rectangle.Height*ratio));
                result.Add(normalized);
            }
            return result;
        }

        private double GetHeight(double weight)
        {
            return 100 * (weight < 0.1 ? 0.1 : weight);
        }
    }
}