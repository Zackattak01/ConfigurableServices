using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace ConfigurableServices
{
    public abstract class ConfigurableService
    {
        //Needs correct Dependency injection
        public IConfigService ConfigService { get; set; }

        private IEnumerable<ConfigurableProperty> configurableProperties;

        public ConfigurableService(IConfigService configService)
        {
            ConfigService = configService;
            ConfigService.ConfigUpdated += ConfigUpdated;

            //Generate Configurable Propertyies
            configurableProperties = GetConfigurableProperties();

            ConfigUpdated();
        }

        protected virtual void ConfigUpdated()
        {

            foreach (var property in configurableProperties)
            {

                object value = ConfigService.GetValue<object>(property.ConfigKey);
                property.SetValue(this, value);
            }


        }

        private IEnumerable<ConfigurableProperty> GetConfigurableProperties()
        {
            List<ConfigurableProperty> configurableProperties = new List<ConfigurableProperty>();

            IEnumerable<PropertyInfo> properties = this.GetType().GetProperties();

            foreach (var property in properties)
            {
                ConfigureFromKeyAttribute attribute = property.GetCustomAttribute<ConfigureFromKeyAttribute>();

                if (attribute != null)
                {
                    ConfigurableProperty configurableProperty = new ConfigurableProperty(attribute.Key, property);
                    configurableProperties.Add(configurableProperty);
                }
            }

            return configurableProperties;
        }
    }
}