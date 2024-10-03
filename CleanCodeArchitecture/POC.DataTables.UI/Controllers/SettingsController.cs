using Microsoft.AspNetCore.Mvc;
using POC.DataTables.UI.Models;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using POC.DataTables.UI.Data;
using POC.DataTables.UI.Data.Models;
using POC.Domain;

namespace POC.DataTables.UI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SettingsController : ControllerBase
    {
        private readonly ILogger<SettingsController> _logger;
        private readonly Data.ApplicationContext _context;

        public SettingsController(ILogger<SettingsController> logger, ApplicationContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet("Data")]
        public IActionResult Data()
        {
            var settings = this._context.MainSettings.Include(x => x.ModulePrimarySettings).Include(x => x.ModuleSecondarySettings).AsEnumerable();
            return Ok(settings);
        }
        
        [HttpGet("SaveData")]
        public async Task<IActionResult> SaveData()
        {
            var settings = new MainSettings();
            settings.Guid = Guid.NewGuid();
            settings.Value = new ApplicationSettingsData();


            await  this._context.MainSettings.AddAsync(settings);
            await this._context.SaveChangesAsync();
            return Ok(settings);
        }

        [HttpGet("SaveDataPrimary")]
        public async Task<IActionResult> SaveDataPrimary()
        {
            var settings = new MainSettings();
            settings.Guid = Guid.NewGuid();
            settings.Value = new ApplicationSettingsData();

            settings.ModulePrimarySettings = new ModulePrimarySettings();
            settings.ModulePrimarySettings.Value = new ModulePrimarySettingsData();


            await this._context.MainSettings.AddAsync(settings);
            await this._context.SaveChangesAsync();
            return Ok(settings);
        }

        [HttpGet("SaveDataSecondary")]
        public async Task<IActionResult> SaveDataSecondary()
        {
            var settings = new MainSettings();
            settings.Guid = Guid.NewGuid();
            settings.Value = new ApplicationSettingsData();

            settings.ModuleSecondarySettings = new ModuleSecondarySettings();
            settings.ModuleSecondarySettings.Value = new ModuleSecondarySettingsData();


            await this._context.MainSettings.AddAsync(settings);
            await this._context.SaveChangesAsync();
            return Ok(settings);
        }

        [HttpGet("UpdateAll")]
        public async Task<IActionResult> UpdateAll()
        {
            var settings = this._context.MainSettings.Include(x => x.ModulePrimarySettings).Include(x => x.ModuleSecondarySettings).AsEnumerable();

            foreach (var mainSettings in settings)
            {
                if (mainSettings.Value != null)
                {
                    mainSettings.Value.AllowUpdates = true;
                    mainSettings.Value.IsModuleEnabled = true;
                }

                if (mainSettings.ModulePrimarySettings?.Value != null)
                {
                    mainSettings.ModulePrimarySettings.Value.AllowChangeColor = true;
                    mainSettings.ModulePrimarySettings.Value.StartDate = DateTime.Now.AddYears(-10);
                }

                if (mainSettings.ModuleSecondarySettings?.Value != null)
                {
                    mainSettings.ModuleSecondarySettings.Value.ConfirmDelivery = true;
                    mainSettings.ModuleSecondarySettings.Value.MaxEmails = 99;
                }
            }

            await this._context.SaveChangesAsync();
            return Ok(settings);
        }



    }
}
