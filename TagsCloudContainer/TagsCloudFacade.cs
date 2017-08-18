using System.Linq;
using TagsCloudContainer.ExtensionPoints.ImageWriters;
using TagsCloudContainer.ExtensionPoints.WordReaders;
using TagsCloudContainer.Internal;

namespace TagsCloudContainer
{
    class TagsCloudFacade
    {
        private readonly IWordsReader wordsReader;
        private readonly ITagsCloudBuilder tagsCloudBuilder;
        private readonly IImageWriter imageWriter;

        public TagsCloudFacade(IWordsReader wordsReader,
            ITagsCloudBuilder tagsCloudBuilder,
            IImageWriter imageWriter)
        {
            this.wordsReader = wordsReader;
            this.tagsCloudBuilder = tagsCloudBuilder;
            this.imageWriter = imageWriter;
        }

        public void BuildTagsCloud(string inputWordsPath, int width, int height, int maxWords, string outputImagePath)
        {
            var words = wordsReader.ReadWordsFrom(inputWordsPath).Take(maxWords).ToArray();
            var image = tagsCloudBuilder.BuildTagsCloud(words, width, height);
            imageWriter.WriteImageTo(image, outputImagePath);
        }
    }
}