using System;

namespace ConfigurableServices
{
    public interface IConfigService
    {

        event Action ConfigUpdated;

        void Reload();

        T GetValue<T>(string key)
            where T : class;


    }
}
