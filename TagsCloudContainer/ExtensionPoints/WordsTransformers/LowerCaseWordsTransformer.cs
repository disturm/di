using System.Collections.Generic;

namespace TagsCloudContainer.ExtensionPoints.WordsTransformers
{
    class LowerCaseWordsTransformer : IWordsTransformer
    {
        public IEnumerable<string> TransformWord(IEnumerable<string> words)
        {
            foreach (var word in words)
                yield return word.ToLowerInvariant();
        }

        public int Priority => 0;
    }
}