using System.Drawing;
using SimpleInjector;
using TagsCloudContainer.ExtensionPoints.CloudLayouters;
using TagsCloudContainer.ExtensionPoints.ImageWriters;
using TagsCloudContainer.ExtensionPoints.WordDrawers;
using TagsCloudContainer.ExtensionPoints.WordReaders;
using TagsCloudContainer.ExtensionPoints.WordsTransformers;
using TagsCloudContainer.Internal;

namespace TagsCloudContainer
{
    class Program
    {
        //Библиотеки для разбора аргументов командной строки: https://github.com/gsscoder/commandline
        //Библиотека NHunspell http://www.crawler-lib.net/nhunspell (Приведение слова к начальной форме и определение частей речи)
        static void Main(string[] args)
        {
            var container = ConfigureContainer();
            var tagsCloudFacade = container.GetInstance<TagsCloudFacade>();
            tagsCloudFacade.BuildTagsCloud("words.txt", 800, 600, 50, "words.bmp");
        }

        private static Container ConfigureContainer()
        {
            var container = new Container();

            container.RegisterSingleton<IImageWriter, ImageWriter>();
            container.RegisterSingleton<IWordsReader, WordsReader>();
            container.RegisterSingleton<IWordsAnalyzer, WordsAnalyzer>();
            container.RegisterSingleton<ICloudLayouter, CloudLayouter>();
            container.RegisterSingleton<IWordDrawer>(new WordDrawer(FontFamily.GenericSerif, FontStyle.Regular,
                Brushes.Chocolate));
            container.RegisterCollection<IWordsTransformer>(
                new FilterWordsTransformer("act"),
                new LowerCaseWordsTransformer());
            container.Register<ITagsWeightsBuilder, TagsWeightsBuilder>();
            container.Register<ITagsCloudBuilder, TagsCloudBuilder>();
            return container;
        }
    }
}
