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

using Newtonsoft.Json;

namespace BibleBrainSharp.Models
{
    public class Organization
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("abbreviation")]
        public string Abbreviation { get; set; }

        [JsonProperty("primaryColor")]
        public string PrimaryColor { get; set; }

        [JsonProperty("secondaryColor")]
        public string SecondaryColor { get; set; }

        [JsonProperty("inactive")]
        public int? Inactive { get; set; }

        [JsonProperty("url_facebook")]
        public string Facebook { get; set; }

        [JsonProperty("url_website")]
        public string Website { get; set; }

        [JsonProperty("url_donate")]
        public string Donate { get; set; }

        [JsonProperty("url_twitter")]
        public string Twitter { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("address2")]
        public string Address2 { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("zip")]
        public int? Zip { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("email_director")]
        public string EmailDirector { get; set; }

        [JsonProperty("latitude")]
        public double? Latitude { get; set; }

        [JsonProperty("longitude")]
        public double? Longitude { get; set; }

        [JsonProperty("laravel_through_key")]
        public string LaravelThroughKey { get; set; }

        [JsonProperty("pivot")]
        public PivotInfo Pivot { get; set; }

        [JsonProperty("logo_icon")]
        public LogoIcon Logo { get; set; }

        [JsonProperty("logos")]
        public LogoIcon[] Logos { get; set; }

        [JsonProperty("translations")]
        public Translation[] Translations { get; set; }

        public class PivotInfo
        {
            [JsonProperty("bible_id")]
            public string BibleId { get; set; }

            [JsonProperty("organization_id")]
            public int OrganizationId { get; set; }

            [JsonProperty("relationship_type")]
            public string RelationshipType { get; set; }
        }

        public class LogoIcon
        {
            [JsonProperty("language_id")]
            public int LanguageId { get; set; }

            [JsonProperty("language_iso")]
            public string LanguageIso { get; set; }

            [JsonProperty("url")]
            public string Url { get; set; }

            [JsonProperty("icon")]
            public int? Icon { get; set; }
        }

        public class Translation
        {
            [JsonProperty("language_id")]
            public int LanguageId { get; set; }

            [JsonProperty("vernacular")]
            public int? Vernacular { get; set; }

            [JsonProperty("alt")]
            public int? Alt { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("description_short")]
            public string DescriptionShort { get; set; }
        }

    }
}
