﻿using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using POC.Data.NoSql;
using POC.Domain;
using POC.NetFramework.WebApi.Data;



namespace POC.NetFramework.WebApi.Controllers
{
    [RoutePrefix("api/Settings")]
    public class SettingsController : ApiController
    {
        
        private readonly ApplicationContext _context;

        private readonly INoSqlDbContext _noSqlDbContext;
        public SettingsController()
        {
            this._context =
                new ApplicationContext(
                    "Data Source=AFC-PC\\SQLEXPRESS;Initial Catalog=AdventureWorks2022;Integrated Security=True;Trust Server Certificate=True;");

            this._noSqlDbContext =
                new CosmosDbContext(
                    "AccountEndpoint=https://localhost:8081/;AccountKey=C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==",
                    "sample", "sample-settings");
        }

        [System.Web.Http.HttpGet]
        [Route("Data")]
        public IHttpActionResult Data()
        {
            var settings = this._context.MainSettings.Include("ModulePrimarySettings").Include("ModuleSecondarySettings").AsNoTracking().AsEnumerable();

            return this.Json(settings);
        }

        [System.Web.Http.HttpGet]
        [Route("SaveData")]
        public async Task<IHttpActionResult> SaveData()
        {
            var settings = new MainSettings();
             settings.Guid = Guid.NewGuid();
            settings.ValueData = new ApplicationSettingsData();
            //
            //
            // this._context.MainSettings.Add(settings);
            // await this._context.SaveChangesAsync();

            await this._noSqlDbContext.CreateItemAsync(settings);
            return this.Json(settings);
        }

        [HttpGet, Route("SaveDataPrimary")]
        public async Task<IHttpActionResult> SaveDataPrimary()
        {
            var settings = new MainSettings();
            settings.Guid = Guid.NewGuid();
            settings.ValueData = new ApplicationSettingsData();

            settings.ModulePrimarySettings = new ModulePrimarySettings();
            settings.ModulePrimarySettings.ValueData = new ModulePrimarySettingsData();


            this._context.MainSettings.Add(settings);
            await this._context.SaveChangesAsync();
            return Json(settings);
        }

        [HttpGet, Route("SaveDataSecondary")]
        public async Task<IHttpActionResult> SaveDataSecondary()
        {
            var settings = new MainSettings();
            settings.Guid = Guid.NewGuid();
            settings.ValueData = new ApplicationSettingsData();

            settings.ModuleSecondarySettings = new ModuleSecondarySettings();
            settings.ModuleSecondarySettings.ValueData = new ModuleSecondarySettingsData();


            this._context.MainSettings.Add(settings);
            await this._context.SaveChangesAsync();
            return Json(settings);
        }
    }
}