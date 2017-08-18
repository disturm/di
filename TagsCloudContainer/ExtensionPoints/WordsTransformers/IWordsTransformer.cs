using System.Collections.Generic;

namespace TagsCloudContainer.ExtensionPoints.WordsTransformers
{
    /// <summary>
    /// На этапе предобработки, приведи все слова к нижнему регистру и исключи скучные слова
    /// В перспективе — дать возможность влиять на список скучных слов, которые не попадут в облако.
    /// В перспективе — поддерживать ввод данных из литературного текста, с приведением слов в начальную форму.
    /// В перспективе — дать возможность выбирать только определенные части речи(например, только существительные)
    /// </summary>
    interface IWordsTransformer
    {
        IEnumerable<string> TransformWord(IEnumerable<string> words);
        int Priority { get; }
    }
}