using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
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

        private ImmutableList<Configurable> configurableProperties;

        public ConfigurableService(IConfigService configService)
        {
            ConfigService = configService;
            ConfigService.ConfigUpdated += ConfigUpdated;

            //Generate Configurable Propertyies
            configurableProperties = GetConfigurables();

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

        private ImmutableList<Configurable> GetConfigurables()
        {
            List<Configurable> configurableProperties = new List<Configurable>();


            //get all properties
            IEnumerable<PropertyInfo> properties = this.GetType().GetRuntimeProperties();

            //filter and create data object
            foreach (var property in properties)
            {
                ConfigureFromKeyAttribute attribute = property.GetCustomAttribute<ConfigureFromKeyAttribute>();

                if (attribute != null)
                {
                    ConfigurableProperty configurableProperty = new ConfigurableProperty(attribute.Key, property);
                    configurableProperties.Add(configurableProperty);
                }
            }

            //get all fields
            IEnumerable<FieldInfo> fields = this.GetType().GetRuntimeFields();

            //filter and create data object
            foreach (var field in fields)
            {
                ConfigureFromKeyAttribute attribute = field.GetCustomAttribute<ConfigureFromKeyAttribute>();

                if (attribute != null)
                {
                    ConfigurableField configurableProperty = new ConfigurableField(attribute.Key, field);
                    configurableProperties.Add(configurableProperty);
                }
            }

            return configurableProperties.ToImmutableList();
        }
    }
}