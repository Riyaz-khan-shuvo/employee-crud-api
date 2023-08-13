namespace Employment_Project.Frontend.Models.ViewModel;

public class State
{
    public int id { get; set; }
    public string stateName { get; set; } = string.Empty;
    public int countryId { get; set; }
    public Country ? country { get; set; }
   
}
