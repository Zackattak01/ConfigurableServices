using System;
using System.Reflection;

namespace ConfigurableServices
{
    public class ConfigurableProperty : Configurable
    {

        private PropertyInfo property;

        public ConfigurableProperty(string configKey, PropertyInfo property)
        : base(configKey)
        {
            this.property = property;
        }

        public override void SetValue(object obj, object value)
        {
            property.SetValue(obj, value);
        }
    }
}