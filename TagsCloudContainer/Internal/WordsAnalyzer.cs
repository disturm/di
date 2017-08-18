using System.Collections.Generic;
using System.Linq;

namespace TagsCloudContainer.Internal
{
    class WordsAnalyzer : IWordsAnalyzer
    {
        public IDictionary<string, double> GetWeights(IReadOnlyCollection<string> words)
        {
            words = words ?? new string[0];
            var totalCount = (double)words.Count;
            return words
                .GroupBy(word => word, (word, group) => new {word, groupCount = group.Count()})
                .ToDictionary(pair => pair.word, pair => pair.groupCount/totalCount);
        }
    }
}