﻿namespace MyAnimeList.Domain;

public class Anime
{
    public int Id { get; set; }
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
