namespace Employment_Project.Frontend.Models.ViewModel;

public class Employee
{
    public int id { get; set; }
    public string name { get; set; }
    public string address { get; set; }
    public string gender { get; set; }
    public int departmentId { get; set; }
    public DateTime joiningDate { get; set; }
    public bool sSC { get; set; }
    public bool hSC { get; set; }
    public bool bSC { get; set; }
    public bool mSC { get; set; }
    public string picture { get; set; }
    public int countryId { get; set; }
    public int stateId { get; set; }
    public int cityId { get; set; }
    public Country? country { get; set; }
    public State? state { get; set; }
    public City?city { get; set; }
    public Department? department { get; set; }
}
