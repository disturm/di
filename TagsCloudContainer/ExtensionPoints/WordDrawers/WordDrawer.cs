using System.Drawing;

namespace TagsCloudContainer.ExtensionPoints.WordDrawers
{
    class WordDrawer : IWordDrawer
    {
        private readonly FontFamily fontFamily;
        private readonly FontStyle fontStyle;
        private readonly Brush brush;

        public WordDrawer(FontFamily fontFamily, FontStyle fontStyle, Brush brush)
        {
            this.fontFamily = fontFamily;
            this.fontStyle = fontStyle;
            this.brush = brush;
        }

        public Size GetOptimalWordSize(Graphics graphics, string word, double height)
        {
            var font = new Font(fontFamily, (float)height, fontStyle);
            var measuredSize = graphics.MeasureString(word, font);
            return new Size((int)measuredSize.Width, (int)measuredSize.Height);
        }

        public void DrawWordIn(Graphics graphics, string word, double height, double x, double y)
        {
            var font = new Font(fontFamily, (float)height, fontStyle);
            graphics.DrawString(word, font, brush, (float)x, (float)y);
        }
    }
}