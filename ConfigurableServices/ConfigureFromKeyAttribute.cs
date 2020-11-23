using System;

namespace ConfigurableServices
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class ConfigureFromKeyAttribute : Attribute
    {
        public string Key { get; }

        public ConfigureFromKeyAttribute(string key)
        {
            Key = key;
        }
    }
}