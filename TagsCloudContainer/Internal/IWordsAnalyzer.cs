using System.Collections.Generic;

namespace TagsCloudContainer.Internal
{
    interface IWordsAnalyzer
    {
        IDictionary<string, double> GetWeights(IReadOnlyCollection<string> words);
    }
}