namespace DalApi;
using static DalApi.DalConfig;
using System.Reflection;

public static class Factory
{
    public static IDal Get
    {
        get
        {
            string dalType = s_dalName ?? throw new DalConfigException($"DAL name is not extracted from the configuration");
            string dal = s_dalPackages[dalType] ?? throw new DalConfigException($"Package for {dalType} is not found in packages list in dal-config.xml");

            Assembly assembly;
            try { assembly = Assembly.Load(dal); }
            catch (Exception ex) { throw new DalConfigException($"Failed to load {dal}.dll package", ex); }

            // שם ה-class הוא "Dal.<package>", ה-namespace בפועל הוא "Dal" -
            // מאתרים את הטיפוס בתוך ה-assembly שנטען, בלי להסתמך על שם ה-namespace
            Type type = assembly.GetType($"Dal.{dal}", throwOnError: false)
                     ?? assembly.GetTypes().FirstOrDefault(t => t.Name == dal && typeof(IDal).IsAssignableFrom(t))
                     ?? throw new DalConfigException($"Class Dal.{dal} was not found in {dal}.dll");

            return type.GetProperty("Instance", BindingFlags.Public | BindingFlags.Static)?.GetValue(null) as IDal ??
                throw new DalConfigException($"Class {dal} is not a singleton or wrong property name for Instance");
        }
    }
}
