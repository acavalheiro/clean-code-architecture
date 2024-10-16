using System;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace POC.Domain
{

    public class ApplicationSettingsData
    {
        public bool AllowUpdates { get; set; }
        public bool IsModuleEnabled { get; set; }
    }

    public class ModulePrimarySettingsData
    {
        public DateTime StartDate { get; set; } = DateTime.UtcNow;
        
        public bool AllowChangeColor { get; set; }
    }
    
    public class ModuleSecondarySettingsData
    {
        public int MaxEmails { get; set; } = 10;
        
        public bool ConfirmDelivery { get; set; }
    }
    
    public abstract class Settings<T> where T : class
    {
        public string Id { get; set; }


#if NET8
        public T Value { get; set; }
#endif

#if NET48
        public string ValueString { get; set; }

        public T ValueData
        {
            get { return string.IsNullOrEmpty(this.ValueString) ? null :  JsonConvert.DeserializeObject<T>(this.ValueString); }
            set { this.ValueString = JsonConvert.SerializeObject(value); }
        }
#endif
        
    }

    public class MainSettings : Settings<ApplicationSettingsData>
    {
        public string id => this.guid.ToString();
        public Guid Guid { get; set; }

        public Guid guid { get; set; } = Guid.NewGuid();
        public ModulePrimarySettings ModulePrimarySettings { get; set; } = new ModulePrimarySettings();

        public ModuleSecondarySettings ModuleSecondarySettings { get; set; } = new ModuleSecondarySettings();
    }

    public class ModulePrimarySettings : Settings<ModulePrimarySettingsData>
    {
        //public virtual MainSettings MainSettings { get; set; }
    }
    
    public class ModuleSecondarySettings : Settings<ModuleSecondarySettingsData>
    {
        //public virtual MainSettings MainSettings { get; set; }
    }
    
    
}