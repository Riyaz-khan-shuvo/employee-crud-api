
using Employment_Project.Frontend.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace Employment_Project.Frontend.Controllers
{
    public class StateController : Controller
    {
        private readonly HttpClient _httpClient;
        public StateController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7225/api/");
        }

        private async Task<List<State>> GetStaeAll()
        {
            var response = await _httpClient.GetAsync("State");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var citylist = JsonConvert.DeserializeObject<List<State>>(content);
                return citylist;
            }
            return new List<State>();
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var listState = await GetStaeAll();
            return View(listState);
        }


        [HttpGet]
        public async Task<IActionResult> AddorEdit(int id)
        {
            if (id == 0)
            {
                var response = await _httpClient.GetAsync("Country");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var stateList = JsonConvert.DeserializeObject<List<Country>>(content);
                    ViewData["countryId"] = new SelectList(stateList, "id", "countryName");
                }
                return View(new State());
            }

            else
            {

                var response = await _httpClient.GetAsync("Country");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var stateList = JsonConvert.DeserializeObject<List<Country>>(content);
                    ViewData["countryId"] = new SelectList(stateList, "id", "countryName");
                }

                var stateresponse = await _httpClient.GetAsync($"State/{id}");
                if (stateresponse.IsSuccessStatusCode)
                {
                    var satedata = await stateresponse.Content.ReadFromJsonAsync<State>();
                    return View(satedata);
                }
                else
                {
                    return NotFound();
                }
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddorEdit(int id, State  state)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    //save data
                    var response = await _httpClient.PostAsJsonAsync("State", state);

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Failed to create the State.");
                        return View(state);
                    }
                }
                else
                {
                    //update Data
                    if (id != state.id)
                    {
                        return BadRequest();
                    }
                    if (ModelState.IsValid)
                    {
                        var response = await _httpClient.PutAsJsonAsync($"State/{id}", state);

                        if (response.IsSuccessStatusCode)
                        {

                            return RedirectToAction("Index");
                        }
                        else
                        {
                            ModelState.AddModelError("", "Failed to update the State.");
                            return View(state);
                        }
                    }
                    return View(state);
                }
            }

            return View(new State());
        }
    }
}
