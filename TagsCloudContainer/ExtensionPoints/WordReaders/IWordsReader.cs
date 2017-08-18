namespace TagsCloudContainer.ExtensionPoints.WordReaders
{
    /// <summary>
    /// Источником данных должен быть файл со словами по одному в строке.
    /// В перспективе — поддерживать разные форматы файлов(txt, doc, docx, ...)
    /// </summary>
    interface IWordsReader
    {
        string[] ReadWordsFrom(string filePath);
    }
}