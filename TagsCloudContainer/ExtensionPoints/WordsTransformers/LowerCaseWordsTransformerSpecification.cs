using FluentAssertions;
using NUnit.Framework;

namespace TagsCloudContainer.ExtensionPoints.WordsTransformers
{
    [TestFixture]
    class LowerCaseWordsTransformerSpecification
    {
        private LowerCaseWordsTransformer transformer;

        [SetUp]
        public void SetUp()
        {
            transformer = new LowerCaseWordsTransformer();
        }

        [Test]
        public void ShouldDoLower_WhenOneWord()
        {
            var words = new[] {"One"};
            transformer.TransformWord(words)
                .ShouldBeEquivalentTo(new[] {"one"});
        }

        [Test]
        public void ShouldDoLower_WhenSeveralWords()
        {
            var words = new[] { "One", "tWo", "threE" };
            transformer.TransformWord(words)
                .ShouldBeEquivalentTo(new[] { "one", "two", "three" });
        }
    }
}