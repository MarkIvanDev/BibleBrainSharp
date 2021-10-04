using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace BibleBrainSharp.Models
{

    public class Book
    {
        [JsonProperty("book_id")]
        public string BookId { get; set; }

        [JsonProperty("book_id_usfx")]
        public string UsfxId { get; set; }

        [JsonProperty("book_id_osis")]
        public string OsisId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("testament")]
        public BookTestament? Testament { get; set; }

        [JsonProperty("testament_order")]
        public int? TestamentOrder { get; set; }

        [JsonProperty("book_order")]
        public int? BookOrder { get; set; }

        [JsonProperty("book_group")]
        public string BookGroup { get; set; }

        [JsonProperty("chapters")]
        public int[] Chapters { get; set; }

        [JsonProperty("content_types")]
        public string[] ContentTypes { get; set; }
    }

    public class BooksResult
    {
        [JsonProperty("data")]
        public Book[] Data { get; set; }
    }

}
