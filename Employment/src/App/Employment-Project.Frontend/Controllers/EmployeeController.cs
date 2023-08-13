
using Employment_Project.Frontend.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace Employment_Project.Frontend.Controllers;

public class EmployeeController : Controller
{
    private readonly HttpClient _httpClient;
    public EmployeeController()
    {
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri("https://localhost:7225/api/");
    }
    private async Task<List<Employee>> GetAlllEmployee()
    {
        var response = await _httpClient.GetAsync("Employee");

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            var citylist = JsonConvert.DeserializeObject<List<Employee>>(content);
            return citylist;
        }
        return new List<Employee>();
    }
    public async Task<IActionResult> Index()
    {
        var listEmp = await GetAlllEmployee();
        return View(listEmp);
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
            var countryresponse = await _httpClient.GetAsync("Country");
            if (countryresponse.IsSuccessStatusCode)
            {
                var content = await countryresponse.Content.ReadAsStringAsync();
                var stateList = JsonConvert.DeserializeObject<List<Country>>(content);
                ViewData["countryId"] = new SelectList(stateList, "id", "countryName");
            }

            var deptresponse = await _httpClient.GetAsync("Department");

            if (deptresponse.IsSuccessStatusCode)
            {
                var content = await deptresponse.Content.ReadAsStringAsync();
                var departments = JsonConvert.DeserializeObject<List<Department>>(content);
                ViewData["DeptId"] = new SelectList(departments, "id", "departmentName");

            }
            var cityresponse = await _httpClient.GetAsync("City");
            if (cityresponse.IsSuccessStatusCode)
            {
                var content = await cityresponse.Content.ReadAsStringAsync();
                var citylist = JsonConvert.DeserializeObject<List<City>>(content);
                ViewData["CityId"] = new SelectList(citylist, "id", "cityName");

            }


            return View(new Employee());
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
            var countryresponse = await _httpClient.GetAsync("Country");
            if (countryresponse.IsSuccessStatusCode)
            {
                var content = await countryresponse.Content.ReadAsStringAsync();
                var stateList = JsonConvert.DeserializeObject<List<Country>>(content);
                ViewData["countryId"] = new SelectList(stateList, "id", "countryName");
            }

            var deptresponse = await _httpClient.GetAsync("Department");

            if (deptresponse.IsSuccessStatusCode)
            {
                var content = await deptresponse.Content.ReadAsStringAsync();
                var departments = JsonConvert.DeserializeObject<List<Department>>(content);
                ViewData["DeptId"] = new SelectList(departments, "id", "departmentName");

            }
            var cityresponse = await _httpClient.GetAsync("City");
            if (cityresponse.IsSuccessStatusCode)
            {
                var content = await cityresponse.Content.ReadAsStringAsync();
                var citylist = JsonConvert.DeserializeObject<List<City>>(content);
                ViewData["CityId"] = new SelectList(citylist, "id", "cityName");

            }


            var Cityresponse = await _httpClient.GetAsync($"Employee/{id}");
            if (Cityresponse.IsSuccessStatusCode)
            {
                var departments = await Cityresponse.Content.ReadFromJsonAsync<Employee>();
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
    public async Task<IActionResult> AddorEdit(int id, Employee employee, IFormFile pictureFile)
    {
        if (ModelState.IsValid)
        {
            if (id == 0)
            {

                if (pictureFile != null && pictureFile.Length > 0)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", pictureFile.FileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        pictureFile.CopyTo(stream);
                    }
                    employee.picture = $"{pictureFile.FileName}";
                }
                var response = await _httpClient.PostAsJsonAsync("Employee", employee);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Failed to create the country.");
                    return View(employee);
                }
            }
            else
            {
                //update Data
                if (id != employee.id)
                {
                    return BadRequest();
                }
                if (ModelState.IsValid)
                {
                    if (pictureFile != null && pictureFile.Length > 0)
                    {
                        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", pictureFile.FileName);
                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            pictureFile.CopyTo(stream);
                        }
                        employee.picture = $"{pictureFile.FileName}";
                    }
                    var response = await _httpClient.PutAsJsonAsync($"Employee/{id}", employee);

                    if (response.IsSuccessStatusCode)
                    {

                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Failed to update the country.");
                        return View(employee);
                    }
                }
                return View(employee);
            }
        }

        return View(new Employee());
    }

    public async Task<IActionResult> Delete(int id)
    {
        var response = await _httpClient.DeleteAsync($"Employee/{id}");
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        else
        {
            return NotFound();
        }
    }
    public async Task<ActionResult> StateDropdownData(int countryId)
     {
        var response = await _httpClient.GetAsync("State");
        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            var stateList = JsonConvert.DeserializeObject<List<State>>(content);
            List<State> filteredStates = stateList.Where(state => state.countryId == countryId).ToList();
            return Json(filteredStates);
        }
        return NotFound();
    }


    public async Task<ActionResult> CityDropdownData(int stateId)
    {
        var response = await _httpClient.GetAsync("City");
        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            var CityList = JsonConvert.DeserializeObject<List<City>>(content);
            List<City> filteredStates = CityList.Where(state => state.stateId == stateId).ToList();
            return Json(filteredStates);
        }
        return NotFound();
    }
}
