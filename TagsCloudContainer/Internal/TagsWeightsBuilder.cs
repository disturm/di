using System.Collections.Generic;
using System.Linq;
using TagsCloudContainer.ExtensionPoints.WordsTransformers;

namespace TagsCloudContainer.Internal
{
    //todo tests (one will be enought)
    class TagsWeightsBuilder : ITagsWeightsBuilder
    {
        private readonly IWordsTransformer[] wordsTransformers;
        private readonly IWordsAnalyzer wordsAnalyzer;

        public TagsWeightsBuilder(IWordsTransformer[] wordsTransformers,
            IWordsAnalyzer wordsAnalyzer)
        {
            this.wordsTransformers = wordsTransformers
                .OrderBy(t => t.Priority).ToArray();
            this.wordsAnalyzer = wordsAnalyzer;
        }

        public IDictionary<string, double> BuildWeights(IReadOnlyCollection<string> words)
        {
            var transformedWords = TransformWords(words).ToList();
            return wordsAnalyzer.GetWeights(transformedWords);
        }

        private IEnumerable<string> TransformWords(IEnumerable<string> words)
        {
            IEnumerable<string> result = words;
            foreach (var wordsTransformer in wordsTransformers)
                result = wordsTransformer.TransformWord(result);
            return result;
        }
    }
}