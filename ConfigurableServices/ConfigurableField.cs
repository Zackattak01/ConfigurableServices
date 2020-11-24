using System;
using System.Reflection;

namespace ConfigurableServices
{
    public class ConfigurableField : Configurable
    {

        private FieldInfo field;

        public ConfigurableField(string configKey, FieldInfo field)
        : base(configKey)
        {
            this.field = field;
        }

        public override void SetValue(object obj, object value)
        {
            field.SetValue(obj, value);
        }
    }
}