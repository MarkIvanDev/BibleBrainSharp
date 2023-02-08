# BibleBrainSharp
An unofficial C# wrapper for the [Bible Brain (aka Digital Bible Platform v4) API](https://www.faithcomesbyhearing.com/audio-bible-resources/bible-brain).

## Getting started

**NOTE: You will need an API Key, which can be obtained by submitting a request [here](https://4.dbt.io/api_key/request).**


## Usage

```csharp
var client = new BibleBrainClient("<API-KEY>");

// Alphabet endpoints
var alphabets = await client.GetAlphabets();
var alphabet = await client.GetAlphabet("Latn");

// Bible endpoints
var bibles = await client.GetBibles();
var bible = await client.GetBible("ENGKJV");
var books = await client.GetBooks("ENGKJV");
var copyright = await client.GetCopyright("ENGKJV");
var chapter = await client.GetChapter("ENGKJV", "GEN", 1);
var defaultBibles = await client.GetDefaultBibles();
var mediaTypes = await client.GetMediaTypes();

// Country endpoints
var countries = await client.GetCountries();
var country = await client.GetCountry("PH");

// Language endpoints
var languages = await client.GetLanguages();
var language = await client.GetLanguage(6513);

// Number endpoints
var numbers = await client.GetNumbers();
var number = await client.GetNumber("thai");

// Search endpoints
var searches = await client.Search("love", "ENGKJV");

// Timestamp endpoints
var filesets = await client.GetFilesetsWithTimestamps();
var timestamps = await client.GetTimestamps("ENGKJVO1DA", "GEN", 1);
```


## Support
If you like my work and want to support me, buying me a coffee would be awesome! Thanks for your support!

<a href="https://www.buymeacoffee.com/markivandev" target="_blank"><img src="https://cdn.buymeacoffee.com/buttons/v2/default-blue.png" alt="Buy Me A Coffee" style="height: 60px !important;width: 217px !important;" ></a>

---------
**Mark Ivan Basto** &bullet; **GitHub**
**[@MarkIvanDev](https://github.com/MarkIvanDev)** &bullet; **Twitter**
**[@Rivolvan_Speaks](https://twitter.com/Rivolvan_Speaks)**