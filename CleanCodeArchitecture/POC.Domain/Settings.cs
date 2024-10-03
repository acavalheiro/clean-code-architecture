using System;

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
        public int Id { get; set; }
        
        
        public T Value { get; set; }
    }

    public class MainSettings : Settings<ApplicationSettingsData> 
    {
        public Guid Guid { get; set; }
        
        public ModulePrimarySettings ModulePrimarySettings { get; set; }
        
        public ModuleSecondarySettings ModuleSecondarySettings { get; set; }
    }

    public class ModulePrimarySettings : Settings<ModulePrimarySettingsData>
    {
        
    }
    
    public class ModuleSecondarySettings : Settings<ModuleSecondarySettingsData>
    {
        
    }
    
    
}