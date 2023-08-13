
using Employment_Project.Frontend.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System.Text.Json;

namespace Employment_Project.Frontend.Controllers;

public class CountryController : Controller
{

	private readonly HttpClient _httpClient;

	public CountryController()
	{
		_httpClient = new HttpClient();
		_httpClient.BaseAddress = new Uri("https://localhost:7225/api/"); 
	}
	private async Task<List<Country>> GetCountriesFromApi()
	{
		var response = await _httpClient.GetAsync("Country");

		if (response.IsSuccessStatusCode)
		{
			var content = await response.Content.ReadAsStringAsync();
			var countries = JsonSerializer.Deserialize<List<Country>>(content);
			return countries;
		}
		return new List<Country>();
	}
	public async Task<IActionResult> Index()
	{
		var countries = await GetCountriesFromApi();
		return View(countries);
	}
	[HttpGet]
	public async Task<IActionResult> AddorEdit(int id)
	{
		if(id == 0) 
		return View(new Country());
		else
		{
            var response = await _httpClient.GetAsync($"Country/{id}");
            if (response.IsSuccessStatusCode)
            {
                var country = await response.Content.ReadFromJsonAsync<Country>();
                return View(country);
            }
            else
            {
                return NotFound();
            }
        }
	}
	[HttpPost]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> AddorEdit(int id, Country country)
	{
		if (ModelState.IsValid)
		{
			if (id==0)
			{
				//save data
                var response = await _httpClient.PostAsJsonAsync("Country", country);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Failed to create the country.");
                    return View(country);
                }
            }
			else
			{
                //update Data
                if (id != country.id)
                {
                    return BadRequest();
                }
                if (ModelState.IsValid)
                {
                    var response = await _httpClient.PutAsJsonAsync($"Country/{id}", country);

                    if (response.IsSuccessStatusCode)
                    {
                       
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Failed to update the country.");
                        return View(country);
                    }
                }
                return View(country);
            }
        }

        return View(new Country());
	}
 
    public async Task<IActionResult> Delete(int id)
    {
        var response = await _httpClient.DeleteAsync($"Country/{id}");
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        else
        {
            return NotFound();
        }
    }
}