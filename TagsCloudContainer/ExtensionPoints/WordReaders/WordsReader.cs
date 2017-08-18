using System.IO;
using System.Linq;

namespace TagsCloudContainer.ExtensionPoints.WordReaders
{
    class WordsReader : IWordsReader
    {
        public string[] ReadWordsFrom(string filePath)
        {
            return File.ReadLines(filePath).ToArray();
        }
    }
}