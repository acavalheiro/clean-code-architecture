using Microsoft.AspNetCore.Mvc;
using POC.DataTables.UI.Models;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using POC.DataTables.UI.Data;
using POC.DataTables.UI.Data.Models;

namespace POC.DataTables.UI.Controllers
{
    public class PersonController : Controller
    {
        private readonly ILogger<PersonController> _logger;
        private readonly Data.ApplicationContext _context;

        public PersonController(ILogger<PersonController> logger, ApplicationContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoadData(DataTablesRequestModel model)
        {

            



            await Task.CompletedTask;

            var data = this._context.Persons.AsQueryable();
                

            int totalRecords = data.Count();

            var paggedData = data.Skip(model.Start).Take(model.Length).AsEnumerable();


            var response = new DataTablesResponseModel<Person>()
            {
                Data = paggedData,
                Draw = model.Draw,
                RecordsTotal = totalRecords,
                RecordsFiltered = totalRecords

            };

            return Json(response);
            
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
