using FluentAssertions;
using NUnit.Framework;

namespace TagsCloudContainer.ExtensionPoints.WordsTransformers
{
    [TestFixture]
    class FilterWordsTransformerSpecification
    {
        private FilterWordsTransformer transformer;

        [SetUp]
        public void SetUp()
        {
            transformer = new FilterWordsTransformer("stop", "sad");
        }

        [Test]
        public void ShouldDoLower_WhenOneWord()
        {
            var words = new[] { "One" };
            transformer.TransformWord(words)
                .ShouldBeEquivalentTo(new[] { "One" });
        }

        [Test]
        public void ShouldDoLower_WhenOneStopWord()
        {
            var words = new[] { "sad" };
            transformer.TransformWord(words)
                .ShouldBeEquivalentTo(new string[0]);
        }

        [Test]
        public void ShouldDoLower_WhenSeveralWords()
        {
            var words = new[] { "One", "stop", "Stop" };
            transformer.TransformWord(words)
                .ShouldBeEquivalentTo(new[] { "One", "Stop" });
        }
    }
}