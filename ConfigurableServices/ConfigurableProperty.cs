using System;
using System.Reflection;

namespace ConfigurableServices
{
    public class ConfigurableProperty
    {
        public string ConfigKey { get; }

        private PropertyInfo property;

        public ConfigurableProperty(string configKey, PropertyInfo property)
        {
            ConfigKey = configKey;
            this.property = property;
        }

        public void SetValue(string value)
        {
            property.SetValue(this, value);
        }
    }
}