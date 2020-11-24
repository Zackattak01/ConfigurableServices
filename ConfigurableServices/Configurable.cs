using System;
using System.ComponentModel;

namespace ConfigurableServices
{
    public abstract class Configurable
    {
        public string ConfigKey { get; }

        public Configurable(string configKey)
            => ConfigKey = configKey;

        public abstract void SetValue(object obj, object value);
    }
}