# Lykke.Job.OpsGenie
OpsGenie (https://www.opsgenie.com/)  service external adapter, created for usage in Lykke infrastructure

## Ops Genie Documentation
https://docs.opsgenie.com/docs/alerts-page

## What this service is inteded for
Service provide the messaging based API atop of OpsGenie API

## How to use the service

Include  https://www.nuget.org/packages/Lykke.Job.OpsGenie.Client/ in your project nuget package.
### Usage examples
- https://github.com/LykkeCity/Lykke.Job.OpsGenie/blob/dev/src/Lykke.Service.OpsGenieClientExample/Modules/ServiceModule.cs#L20 - client registration
- https://github.com/LykkeCity/Lykke.Job.OpsGenie/blob/dev/src/Lykke.Service.OpsGenieClientExample/Controllers/AlertController.cs#L31 client usage

## Lykke.Job.OpsGenie Configuration

### Settings

```json
{
  "MonitoringServiceClient": 
  {
    "MonitoringServiceUrl": "" // lykke monitoring client 
  },
  "OpsGenieJob": 
  {
    "ApiUrl": "https://api.opsgenie.com/",
    "Db": 
    {
      "LogsConnString": "",
      "DataConnString": ""
    },
    "DefaultDomainApiKey": "", //Configure OpsGenie Web API via web portal and put key for default integration. All alerts with domain, which do not math "Domain" sections, goes to this integration 
    "Domains": 
    [
      {
        "Name": "BIL",  // unique mnemonic to distinct domain
        "ApiKey": "" // api key for configured web api integration.
      }
    ]
  },
  "SlackNotifications": 
  {
    "AzureQueue": 
    {
      "ConnectionString": ",
      "QueueName": "slack-notifications"
    },
    "ThrottlingLimitSeconds": 60
  }
}
```
