using System.Collections.Generic;

namespace TagsCloudContainer.ExtensionPoints.WordsTransformers
{
    class FilterWordsTransformer : IWordsTransformer
    {
        private readonly HashSet<string> stopWords;

        public FilterWordsTransformer(params string[] stopWords)
        {
            this.stopWords = new HashSet<string>(stopWords);
        }

        public IEnumerable<string> TransformWord(IEnumerable<string> words)
        {
            foreach (var word in words)
                if (!stopWords.Contains(word))
                    yield return word;
        }

        public int Priority => 1;
    }
}