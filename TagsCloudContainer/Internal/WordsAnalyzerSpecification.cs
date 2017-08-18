using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace TagsCloudContainer.Internal
{
    [TestFixture]
    class WordsAnalyzerSpecification
    {
        private WordsAnalyzer wordsAnalyzer;

        [SetUp]
        public void SetUp()
        {
            wordsAnalyzer = new WordsAnalyzer();
        }

        [Test]
        public void GetWeights_ShouldReturnEmpty_WhenNull()
        {
            wordsAnalyzer.GetWeights(null).Should().BeEmpty();
        }

        [Test]
        public void GetWeights_ShouldReturnEmpty_WhenNoWords()
        {
            wordsAnalyzer.GetWeights(new string[0]).Should().BeEmpty();
        }

        [Test]
        public void GetWeights_ShouldWorks_WhenOneWord()
        {
            var words = new [] {"one"};
            wordsAnalyzer.GetWeights(words)
                .ShouldBeEquivalentTo(new Dictionary<string, double>()
                {
                    {"one", 1.0}
                });
        }

        [Test]
        public void GetWeights_ShouldWorks_WhenTwoWords()
        {
            var words = new[] { "one", "two" };
            wordsAnalyzer.GetWeights(words)
                .ShouldBeEquivalentTo(new Dictionary<string, double>()
                {
                    {"one", 0.5},
                    {"two", 0.5}
                });
        }

        [Test]
        public void GetWeights_ShouldWorks_WhenSequentionalRepetitions()
        {
            var words = new[] { "one", "one", "one", "two", "two" };
            wordsAnalyzer.GetWeights(words)
                .ShouldBeEquivalentTo(new Dictionary<string, double>()
                {
                    {"one", 0.6},
                    {"two", 0.4}
                });
        }

        [Test]
        public void GetWeights_ShouldWorks_WhenNonSequentionalRepetitions()
        {
            var words = new[] { "one", "two", "one", "two", "one" };
            wordsAnalyzer.GetWeights(words)
                .ShouldBeEquivalentTo(new Dictionary<string, double>()
                {
                    {"one", 0.6},
                    {"two", 0.4}
                });
        }
    }
}