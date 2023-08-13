
using Employment_Project.Frontend.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Employment_Project.Frontend.Controllers;

public class DepartmentController : Controller
{

    private readonly HttpClient _httpClient;

    public DepartmentController()
    {
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri("https://localhost:7225/api/");
    }
    private async Task<List<Department>> GetDepartment()
    {
        var response = await _httpClient.GetAsync("Department");

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            var departments = JsonConvert.DeserializeObject<List<Department>>(content);
            return departments;
        }
        return new List<Department>();
    }
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var departments = await GetDepartment();
        return View(departments);
    }



    [HttpGet]
    public async Task<IActionResult> AddorEdit(int id)
    {
        if (id == 0)
            return View(new Department());
        else
        {
            var response = await _httpClient.GetAsync($"Department/{id}");
            if (response.IsSuccessStatusCode)
            {
                var departments = await response.Content.ReadFromJsonAsync<Department>();
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
    public async Task<IActionResult> AddorEdit(int id, Department department)
    {
        if (ModelState.IsValid)
        {
            if (id == 0)
            {
                //save data
                var response = await _httpClient.PostAsJsonAsync("Department", department);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Failed to create the department.");
                    return View(department);
                }
            }
            else
            {
                //update Data
                if (id != department.id)
                {
                    return BadRequest();
                }
                if (ModelState.IsValid)
                {
                    var response = await _httpClient.PutAsJsonAsync($"Department/{id}", department);

                    if (response.IsSuccessStatusCode)
                    {

                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Failed to update the country.");
                        return View(department);
                    }
                }
                return View(department);
            }
        }
        return View(new Department());
    }


    public async Task<IActionResult> Delete(int id)
    {
        var response = await _httpClient.DeleteAsync($"Department/{id}");
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
