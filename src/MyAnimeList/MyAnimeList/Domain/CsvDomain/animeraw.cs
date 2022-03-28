using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using System.Text.RegularExpressions;

namespace MyAnimeList.Domain.CsvDomain;

public class AnimeRaw
{
    public int MyAnimeListId { get; set; }
    public string Name { get; set; }
    public decimal? Score { get; set; }  
    public string Genres { get; set; }  
    public string EnglishName { get; set; }
    public string JapaneseName { get; set; }
    public string Type { get; set; }
    public int? Episodes { get; set; }
    public string Aired { get; set; }
    public string Premiered { get; set; }
    public string Producers { get; set; }
    public string Licensors { get; set; }
    public string Studios { get; set; }
    public string Source { get; set; }
    public int? Duration { get; set; }
    public string Rating { get; set; }
    public decimal? Ranked { get; set; }
    public int? Popularity { get; set; }
    public int? Members { get; set; }
    public int? Favorites { get; set; }
    public int? Watching { get; set; }
    public int? Completed { get; set; }
    public int? OnHold { get; set; }
    public int? Dropped { get; set; }
    public int? PlanToWatch { get; set; }
    public decimal? Score10 { get; set; }
    public decimal? Score09 { get; set; }
    public decimal? Score08 { get; set; }
    public decimal? Score07 { get; set; }
    public decimal? Score06 { get; set; }
    public decimal? Score05 { get; set; }
    public decimal? Score04 { get; set; }
    public decimal? Score03 { get; set; }
    public decimal? Score02 { get; set; }
    public decimal? Score01 { get; set; }
}

public sealed class AnimeMap : ClassMap<AnimeRaw>
{
    public AnimeMap()
    {
        Map(m => m.MyAnimeListId).Name("MAL_ID");
        Map(m => m.Name).Name("Name");
        Map(m => m.Score).Name("Score").TypeConverter<UnknownDecimalConverter<string>>();
        Map(m => m.Genres).Name("Genres").TypeConverter<UnknownStringConverter<string>>();
        Map(m => m.EnglishName).Name("English name").TypeConverter<UnknownStringConverter<string>>();
        Map(m => m.JapaneseName).Name("Japanese name").TypeConverter<UnknownStringConverter<string>>();
        Map(m => m.Type).Name("Type").TypeConverter<UnknownStringConverter<string>>();
        Map(m => m.Episodes).Name("Episodes").TypeConverter<UnknownIntConverter<string>>();
        Map(m => m.Aired).Name("Aired").TypeConverter<UnknownStringConverter<string>>();
        Map(m => m.Premiered).Name("Premiered").TypeConverter<UnknownStringConverter<string>>();
        Map(m => m.Producers).Name("Producers").TypeConverter<UnknownStringConverter<string>>();
        Map(m => m.Licensors).Name("Licensors").TypeConverter<UnknownStringConverter<string>>();
        Map(m => m.Studios).Name("Studios").TypeConverter<UnknownStringConverter<string>>();
        Map(m => m.Source).Name("Source").TypeConverter<UnknownStringConverter<string>>();
        Map(m => m.Duration).Name("Duration").TypeConverter<DurationConverter<string>>();
        Map(m => m.Rating).Name("Rating").TypeConverter<UnknownStringConverter<string>>();
        Map(m => m.Ranked).Name("Ranked").TypeConverter<UnknownDecimalConverter<string>>();
        Map(m => m.Popularity).Name("Popularity").TypeConverter<UnknownIntConverter<string>>();
        Map(m => m.Members).Name("Members").TypeConverter<UnknownIntConverter<string>>();
        Map(m => m.Favorites).Name("Favorites").TypeConverter<UnknownIntConverter<string>>();
        Map(m => m.Watching).Name("Watching").TypeConverter<UnknownIntConverter<string>>();
        Map(m => m.Completed).Name("Completed").TypeConverter<UnknownIntConverter<string>>();
        Map(m => m.OnHold).Name("On-Hold").TypeConverter<UnknownIntConverter<string>>();
        Map(m => m.Dropped).Name("Dropped").TypeConverter<UnknownIntConverter<string>>();
        Map(m => m.PlanToWatch).Name("Plan to Watch").TypeConverter<UnknownIntConverter<string>>();
        Map(m => m.Score10).Name("Score-10").TypeConverter<UnknownDecimalConverter<string>>();
        Map(m => m.Score09).Name("Score-9").TypeConverter<UnknownDecimalConverter<string>>();
        Map(m => m.Score08).Name("Score-8").TypeConverter<UnknownDecimalConverter<string>>();
        Map(m => m.Score07).Name("Score-7").TypeConverter<UnknownDecimalConverter<string>>();
        Map(m => m.Score06).Name("Score-6").TypeConverter<UnknownDecimalConverter<string>>();
        Map(m => m.Score05).Name("Score-5").TypeConverter<UnknownDecimalConverter<string>>();
        Map(m => m.Score04).Name("Score-4").TypeConverter<UnknownDecimalConverter<string>>();
        Map(m => m.Score03).Name("Score-3").TypeConverter<UnknownDecimalConverter<string>>();
        Map(m => m.Score02).Name("Score-2").TypeConverter<UnknownDecimalConverter<string>>();
        Map(m => m.Score01).Name("Score-1").TypeConverter<UnknownDecimalConverter<string>>();
    }
}

public class UnknownIntConverter<T> : DefaultTypeConverter
{
    public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
    {
        return text == "Unknown" ? null : int.Parse(text);
    }
}

public class UnknownDecimalConverter<T> : DefaultTypeConverter
{
    public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
    {
        return text == "Unknown" ? null : decimal.Parse(text);
    }
}

public class UnknownStringConverter<T> : DefaultTypeConverter
{
    public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
    {
        return text == "Unknown" ? null : text;
    }
}

public class DurationConverter<T> : DefaultTypeConverter
{
    public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
    {
        Match m = Regex.Match(text, @"(?i)((?<hours>\d+)\s*(?=h))*\D*((?<minutes>\d+)\s*(?=m))");
        return !m.Success ? null : (!m.Groups["hours"].Success ? 0 : int.Parse(m.Groups["hours"].Value) * 60) +
            (!m.Groups["minutes"].Success ? 0 : int.Parse(m.Groups["minutes"].Value));
    }
}
