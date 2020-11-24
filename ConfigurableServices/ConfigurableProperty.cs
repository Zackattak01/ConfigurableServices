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

        public void SetValue(object obj, object value)
        {
            property.SetValue(obj, value);
        }
    }
}