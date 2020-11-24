using System;

namespace ConfigurableServices
{
    public interface IConfigService
    {

        event Action ConfigUpdated;

        void Reload();

        string GetValue(string key);

        T GetValue<T>(string key)
            where T : class;


    }
}
