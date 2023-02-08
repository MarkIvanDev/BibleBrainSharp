namespace BibleBrainSharp
{
    public static class ApiEndpoints
    {
        public static string Base => "https://4.dbt.io/api/";

        public const string Languages = "languages";
        public static string GetLanguage(int languageId) => $"languages/{languageId}";
        public static string GetLanguageSearch(string searchText) => $"languages/search/{searchText}";

        public const string Countries = "countries";
        public static string GetCountry(string countryId) => $"countries/{countryId}";
        public static string GetCountrySearch(string searchText) => $"countries/search/{searchText}";

        public const string Alphabets = "alphabets";
        public static string GetAlphabet(string alphabetId) => $"alphabets/{alphabetId}";

        public const string Numbers = "numbers";
        public const string NumbersRange = "numbers/range";
        public static string GetNumber(string numeralSystem) => $"numbers/{numeralSystem}";

        public const string Bibles = "bibles";
        public static string GetBible(string bibleId) => $"bibles/{bibleId}";
        public static string GetBooks(string bibleId) => $"bibles/{bibleId}/book";
        public static string GetChapter(string fileSetId, string bookId, int chapter) => $"bibles/filesets/{fileSetId}/{bookId}/{chapter}";
        public static string GetCopyright(string bibleId) => $"bibles/{bibleId}/copyright";
        public static string GetVersesByLanguage(string languageCode, string bookId, int chapter, int? verse = null) => $"bibles/verses/{languageCode}/{bookId}/{chapter}/{verse}";
        public static string GetVersesByVersion(string bibleId, string bookId, int chapter, int? verse = null) => $"bible/{bibleId}/verses/{bookId}/{chapter}/{verse}";
        public const string DefaultBibles = "bibles/defaults/types";
        public const string MediaTypes = "bibles/filesets/media/types";
        public const string BibleSearch = "bibles/search";
        public static string GetBibleSearch(string searchText) => $"bibles/search/{searchText}";
        public static string GetVerseInfo(string filesetId, string bookId, int? chapter = null) => $"bibles/{filesetId}/{bookId}/{chapter}";

        public const string DownloadList = "download/list";
        public static string GetDownload(string filesetId, string bookId, int? chapter = null) => $"download/{filesetId}/{bookId}/{chapter}";

        public const string Timestamps = "timestamps";
        public static string GetTimestamps(string fileSetId, string bookId, int chapter) => $"{Timestamps}/{fileSetId}/{bookId}/{chapter}";

        public static string Search => "search";

    }
}
