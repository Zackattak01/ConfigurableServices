# ConfigurableServices
ConfigurableServices is a very small library that is used for... you guessed it, configuring services.  To create a configurable service inherit from [Configurable Service](ConfigurableServices/ConfigurableService.cs)

The next step is to create a Config Service that implements [IConfigService](ConfigurableServices/IConfigService.cs) this service will interface with all your configurable components. Wether this is from config files or other means.

Finally, to create a configurable property or field decorate it with the [ConfigureFromKeyAttribute](ConfigurableServices/ConfigureFromKeyAttribute.cs).  The key provided will pull the value from the Config Service.

The service will stay updated with whatever the latest value in the Config Service is (as long as the [ConfigUpdated](ConfigurableServices/IConfigService.cs#L8) event is fired correctly).
