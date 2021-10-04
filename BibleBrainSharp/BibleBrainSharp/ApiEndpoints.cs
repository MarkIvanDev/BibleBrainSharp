// MIT License

// Copyright(c) 2021 Mark Ivan Basto

// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:

// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.

// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

using System;

namespace BibleBrainSharp
{
    public static class ApiEndpoints
    {
        public static string Base => "https://4.dbt.io/api/";

        public static string Languages => "languages";
        public static string GetLanguage(int languageId) => $"{Languages}/{languageId}";

        public static string Countries => "countries";
        public static string GetCountry(string countryId) => $"{Countries}/{countryId}";

        public static string Alphabets => "alphabets";
        public static string GetAlphabet(string alphabetId) => $"{Alphabets}/{alphabetId}";

        public static string Numbers => "numbers";
        public static string NumbersRange => $"{Numbers}/range";
        public static string GetNumber(string numeralSystem) => $"{Numbers}/{numeralSystem}";

        public static string Bibles => "bibles";
        public static string GetBible(string bibleId) => $"{Bibles}/{bibleId}";
        public static string GetBooks(string bibleId) => $"{Bibles}/{bibleId}/book";
        public static string GetChapter(string fileSetId, string bookId, int chapter) => $"{Bibles}/filesets/{fileSetId}/{bookId}/{chapter}";
        public static string GetCopyright(string bibleId) => $"{Bibles}/{bibleId}/copyright";
        public static string DefaultBibles => $"{Bibles}/defaults/types";
        public static string MediaTypes => $"{Bibles}/filesets/media/types";

        public static string Timestamps => "timestamps";
        public static string GetTimestamps(string fileSetId, string bookId, int chapter) => $"{Timestamps}/{fileSetId}/{bookId}/{chapter}";

        public static string Search => "search";

    }
}
