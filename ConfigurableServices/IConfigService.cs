using System;

namespace ConfigurableServices
{
    public interface IConfigService
    {

        event Action ConfigUpdated;

        void Reload();

        string GetValue(string key);


    }
}
