using Employment_Project.Frontend.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace Employment_Project.Frontend.Controllers;

public class CityController : Controller
{
    private readonly HttpClient _httpClient;

    public CityController()
    {
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri("https://localhost:7225/api/");
    }
   
     private async Task<List<City>> GetCityAll()
    {
        var response = await _httpClient.GetAsync("City");
        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            var citylist = JsonConvert.DeserializeObject<List<City>>(content);
            return citylist;
        }
        return new List<City>();
     }
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var listCiy = await GetCityAll();
        return View(listCiy);
    }


    [HttpGet]
    public async Task<IActionResult> AddorEdit(int id)
    {
        if (id == 0)
        {
            var response = await _httpClient.GetAsync("State");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var stateList = JsonConvert.DeserializeObject<List<State>>(content);
                ViewData["StateId"] = new SelectList(stateList, "id", "stateName");
            }
            return View(new City());
        }
           
        else
        {

            var response = await _httpClient.GetAsync("State");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var stateList = JsonConvert.DeserializeObject<List<State>>(content);
                ViewData["StateId"] = new SelectList(stateList, "id", "stateName");
            }

            var Cityresponse = await _httpClient.GetAsync($"City/{id}");
            if (Cityresponse.IsSuccessStatusCode)
            {
                var departments = await Cityresponse.Content.ReadFromJsonAsync<City>();
                return View(departments);
            }
            else
            {
                return NotFound();
            }
        }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddorEdit(int id, City  city)
    {
        if (ModelState.IsValid)
        {
            if (id == 0)
            {
                //save data
                var response = await _httpClient.PostAsJsonAsync("City", city);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Failed to create the City.");
                    return View(city);
                }
            }
            else
            {
                //update Data
                if (id != city.id)
                {
                    return BadRequest();
                }
                if (ModelState.IsValid)
                {
                    var response = await _httpClient.PutAsJsonAsync($"City/{id}", city);

                    if (response.IsSuccessStatusCode)
                    {

                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Failed to update the City.");
                        return View(city);
                    }
                }
                return View(city);
            }
        }

        return View(new City());
    }
   
    public async Task<IActionResult> Delete(int id)
    {
        var response = await _httpClient.DeleteAsync($"City/{id}");
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
