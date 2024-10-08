using CleanCodeArchitecture.Domain.Core.Entities;

namespace CleanCodeArchitecture.Domain.Entities;

public class Company : BaseEntity, IBaseEntity<int>
{
    public int Id { get; set; }

    public string Name { get; set; }
    
    public MainSettings MainSettings { get; set; }

    
}

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

public abstract class Settings<T> where T : class, new()
{
    public int Id { get; set; }


    public T Value { get; set; } = new T();

}

public class MainSettings : Settings<ApplicationSettingsData> ,  IBaseEntity<int>
{
    public Guid Guid { get; set; }

    public ModulePrimarySettings ModulePrimarySettings { get; set; } = new ModulePrimarySettings();

    public ModuleSecondarySettings ModuleSecondarySettings { get; set; } = new ModuleSecondarySettings();

}

public class ModulePrimarySettings : Settings<ModulePrimarySettingsData>, IBaseEntity<int>
{
    
}

public class ModuleSecondarySettings : Settings<ModuleSecondarySettingsData>, IBaseEntity<int>
{
    
}