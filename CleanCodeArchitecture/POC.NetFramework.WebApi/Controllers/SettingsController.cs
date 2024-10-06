using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
using POC.NetFramework.WebApi.Data;

namespace POC.NetFramework.WebApi.Controllers
{
    public class SettingsController : ApiController
    {
        private readonly ApplicationContext _context;
        public SettingsController()
        {
            this._context =
                new ApplicationContext(
                    "Data Source=AFC-PC\\SQLEXPRESS;Initial Catalog=AdventureWorks2022;Integrated Security=True;Trust Server Certificate=True;");
        }

        [System.Web.Http.HttpGet]
        public IHttpActionResult Data()
        {
            var settings = this._context.MainSettings.Include("ModulePrimarySettings").Include("ModuleSecondarySettings").AsNoTracking().AsEnumerable();

            return this.Json(settings);
        }
    }
}