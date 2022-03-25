namespace MyAnimeList.Domain;

public class Anime
{
    public int Id { get; set; }
    public int MyAnimeListId { get; set; }  
    public string Name { get; set; }
    public decimal Score { get; set; }  
    public string Genres { get; set; }
    public string EnglishName { get; set; } 
    public string JapaneseName { get; set; }    
    public string Type { get; set; }    
    public int Episodes { get; set; }   
    public string Aired { get; set; }   
    public string Premiered { get; set; }   
    public string Producers { get; set; }
    public string Licensors { get; set; }
    public string Studios { get; set; }
    public string Source { get; set; }  
    public decimal Duration { get; set; }   
    public string Rating { get; set; } 
    public int Ranked { get; set; }
    public int Popularity { get; set; }
    public int Members { get; set; }
    public int Favorites { get; set; }
    public int Watching { get; set; }   
    public int Completed { get; set; }
    public int Onhold { get; set; }
    public int Dropped { get; set; }    
    public int PlanToWatch { get; set; }
    public int Score10 { get; set; }    
    public int Score09 { get; set; }
    public int Score08 { get; set; }
    public int Score07 { get; set; }    
    public int Score06 { get; set; }
    public int Score05 { get; set; }
    public int Score04 { get; set; }
    public int Score03 { get; set; }
    public int Score02 { get; set; }
    public int Score01 { get; set; }
}
