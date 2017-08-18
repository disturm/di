using System.Collections.Generic;

namespace TagsCloudContainer.Internal
{
    internal interface ITagsWeightsBuilder
    {
        IDictionary<string, double> BuildWeights(IReadOnlyCollection<string> words);
    }
}