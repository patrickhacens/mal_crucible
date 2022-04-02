
using CsvHelper;
using CsvHelper.Configuration;

using MediatR;
using Nudes.Retornator.AspnetCore;
using System.Reflection;
using FluentValidation;
using System.Linq.Expressions;
using Mapster;
using MyAnimeList.PipelineBehaviors;

using Microsoft.EntityFrameworkCore;
using MyAnimeList.Domain;
using MyAnimeList.Domain.CsvDomain;
using System.Text;
using MyAnimeList.Features.Import;
using System.Text.RegularExpressions;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

BenchmarkRunner.Run<Benchy>();
//Benchy d = new Benchy();


public class Benchy
{
    const string PATH_TO_ANIME = @"C:\Users\patri\Downloads\anime_source\anime.csv";

    CsvConfiguration Config = new CsvConfiguration(new System.Globalization.CultureInfo("en-US")) { Delimiter = "," };

    string[] AirDates;

    public Benchy()
    {
        //using (var fs = new FileStream(PATH_TO_ANIME, FileMode.Open, FileAccess.Read))
        using (var reader = new StreamReader(PATH_TO_ANIME, Encoding.UTF8))
        using (var csv = new CsvReader(reader, Config))
        {
            csv.Context.RegisterClassMap<AnimeMap>();
            AirDates = csv.GetRecords<AnimeRaw>()
                .Select(d => d.Aired)
                .ToArray();
        }
    }

    [Benchmark]
    public void InnerRegex()
    {
        foreach (var date in AirDates)
        {
            DateTime? startAired, endAired;

            if (date != null)
            {
                Match mDates = Regex.Match(date, @"(?i)^\s*(?<month>jan|feb|mar|apr|may|jun|jul|aug|sep|oct|nov|dec)*[\.,\s]*\D*(?:(?<day>\d{1,2})\D)*[\.,\s]*\D*(?<year>\d{4})(?:\s*to\s*(?<monthto>jan|feb|mar|apr|may|jun|jul|aug|sep|oct|nov|dec)*[\.,\s]*(?:(?<dayto>\d{1,2})\D)*\D*(?<yearto>\d{4})*)*");
                String sDateFrom = (mDates.Groups["month"].Success ? mDates.Groups["month"].Value : "Jan") + " " +
                                   (mDates.Groups["day"].Success ? mDates.Groups["day"].Value : "1") + ", " +
                                   mDates.Groups["year"].Value;
                startAired = DateTime.Parse(sDateFrom, new System.Globalization.CultureInfo("en-US"));
                if (mDates.Groups["yearto"].Success)
                {
                    String sDateTo = (mDates.Groups["monthto"].Success ? mDates.Groups["monthto"].Value : "Jan") + " " +
                                   (mDates.Groups["dayto"].Success ? mDates.Groups["dayto"].Value : "1") + ", " +
                                   mDates.Groups["yearto"].Value;
                    endAired = DateTime.Parse(sDateTo, new System.Globalization.CultureInfo("en-US"));
                }
                else
                {
                    endAired = null;
                }
            }
            else
            {
                startAired = null;
                endAired = null;
            }
        }
    }

    [Benchmark]
    public void OutterRegex()
    {
        Regex regex = new Regex(@"(?i)^\s*(?<month>jan|feb|mar|apr|may|jun|jul|aug|sep|oct|nov|dec)*[\.,\s]*\D*(?:(?<day>\d{1,2})\D)*[\.,\s]*\D*(?<year>\d{4})(?:\s*to\s*(?<monthto>jan|feb|mar|apr|may|jun|jul|aug|sep|oct|nov|dec)*[\.,\s]*(?:(?<dayto>\d{1,2})\D)*\D*(?<yearto>\d{4})*)*", RegexOptions.Compiled);
        
        foreach (var date in AirDates)
        {
            DateTime? startAired, endAired;

            if (date != null)
            {

                Match mDates = regex.Match(date);
                String sDateFrom = (mDates.Groups["month"].Success ? mDates.Groups["month"].Value : "Jan") + " " +
                                   (mDates.Groups["day"].Success ? mDates.Groups["day"].Value : "1") + ", " +
                                   mDates.Groups["year"].Value;
                startAired = DateTime.Parse(sDateFrom, new System.Globalization.CultureInfo("en-US"));
                if (mDates.Groups["yearto"].Success)
                {
                    String sDateTo = (mDates.Groups["monthto"].Success ? mDates.Groups["monthto"].Value : "Jan") + " " +
                                   (mDates.Groups["dayto"].Success ? mDates.Groups["dayto"].Value : "1") + ", " +
                                   mDates.Groups["yearto"].Value;
                    endAired = DateTime.Parse(sDateTo, new System.Globalization.CultureInfo("en-US"));
                }
                else
                {
                    endAired = null;
                }
            }
            else
            {
                startAired = null;
                endAired = null;
            }
        }
    }

    [Benchmark]
    public void OutterRegexWithExactParse()
    {
        var culture = new System.Globalization.CultureInfo("en-US");
        Regex regex = new Regex(@"(?i)^\s*(?<month>jan|feb|mar|apr|may|jun|jul|aug|sep|oct|nov|dec)*[\.,\s]*\D*(?:(?<day>\d{1,2})\D)*[\.,\s]*\D*(?<year>\d{4})(?:\s*to\s*(?<monthto>jan|feb|mar|apr|may|jun|jul|aug|sep|oct|nov|dec)*[\.,\s]*(?:(?<dayto>\d{1,2})\D)*\D*(?<yearto>\d{4})*)*", RegexOptions.Compiled);

        foreach (var date in AirDates)
        {
            DateTime? startAired, endAired;

            if (date != null)
            {

                Match mDates = regex.Match(date);
                String sDateFrom = (mDates.Groups["month"].Success ? mDates.Groups["month"].Value : "Jan") + " " +
                                   (mDates.Groups["day"].Success ? mDates.Groups["day"].Value : "1") + ", " +
                                   mDates.Groups["year"].Value;
                startAired = DateTime.ParseExact(sDateFrom, "MMM d, yyyy", culture);
                if (mDates.Groups["yearto"].Success)
                {
                    String sDateTo = (mDates.Groups["monthto"].Success ? mDates.Groups["monthto"].Value : "Jan") + " " +
                                   (mDates.Groups["dayto"].Success ? mDates.Groups["dayto"].Value : "1") + ", " +
                                   mDates.Groups["yearto"].Value;
                    endAired = DateTime.ParseExact(sDateTo, "MMM d, yyyy",culture);
                }
                else
                {
                    endAired = null;
                }
            }
            else
            {
                startAired = null;
                endAired = null;
            }
        }
    }


    Dictionary<string, int> MonthToNumber = new Dictionary<string, int>()
    {
        { "Jan", 1 },
        { "Feb", 2 },
        { "Mar", 3 },
        { "Apr", 4 },
        { "May", 5 },
        { "Jun", 6 },
        { "Jul", 7 },
        { "Aug", 8 },
        { "Sep", 9 },
        { "Oct", 10 },
        { "Nov", 11 },
        { "Dec", 12 },
    };

    [Benchmark]
    public void OutterRegexWithNumbers()
    {
        Regex regex = new Regex(@"(?i)^\s*(?<month>jan|feb|mar|apr|may|jun|jul|aug|sep|oct|nov|dec)*[\.,\s]*\D*(?:(?<day>\d{1,2})\D)*[\.,\s]*\D*(?<year>\d{4})(?:\s*to\s*(?<monthto>jan|feb|mar|apr|may|jun|jul|aug|sep|oct|nov|dec)*[\.,\s]*(?:(?<dayto>\d{1,2})\D)*\D*(?<yearto>\d{4})*)*");
        foreach (var date in AirDates)
        {
            DateTime? startAired, endAired;
            int day, month, year;

            if (date != null)
            {

                Match mDates = regex.Match(date);

                month = mDates.Groups["month"].Success ? MonthToNumber[mDates.Groups["month"].Value] : 1;
                day = mDates.Groups["day"].Success ? int.Parse(mDates.Groups["day"].Value) : 1;
                year = int.Parse(mDates.Groups["year"].Value);

                startAired = new DateTime(year, month, day);

                if (mDates.Groups["yearto"].Success)
                {
                    month = mDates.Groups["monthto"].Success ? MonthToNumber[mDates.Groups["monthto"].Value] : 1;
                    day = mDates.Groups["dayto"].Success ? int.Parse(mDates.Groups["dayto"].Value) : 1;
                    year = int.Parse(mDates.Groups["yearto"].Value);
                    endAired = new DateTime(year, month, day);
                }
                else
                    endAired = null;
            }
            else
            {
                startAired = null;
                endAired = null;
            }
        }
    }
}


//var builder = WebApplication.CreateBuilder(args);

////builder.Configuration.AddJsonFile("appsettings.Development.json",true,true);

//// Add services to the container.

//builder.Configuration.AddJsonFile("appsettings.local.json", true, true);
//builder.Services.AddControllers().AddRetornator();
//builder.Services.AddErrorTranslator(ErrorHttpTranslatorBuilder.Default);
//builder.Services.AddMediatR(Assembly.GetEntryAssembly());
//builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
//builder.Services.AddValidatorsFromAssembly(Assembly.GetEntryAssembly());

//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//builder.Services.AddCors(options => options.AddPolicy("AllowAny", builder => builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()));

//TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());
//TypeAdapterConfig.GlobalSettings.Compiler = exp => exp.CompileWithDebugInfo();


//builder.Services
//    .AddDbContext<MyAnimeListContext>(options => options.UseSqlServer(
//        builder.Configuration.GetConnectionString("DefaultConnection")));



//var app = builder.Build();



//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseCors("AllowAny");

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//app.Run();
