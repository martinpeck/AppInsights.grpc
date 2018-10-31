# AppInsights.grpc

[![Build Status](https://dev.azure.com/martinpeck-github/AppInsights.grpc/_apis/build/status/martinpeck.AppInsights.grpc)](https://dev.azure.com/martinpeck-github/AppInsights.grpc/_build/latest?definitionId=1)

_Instrumentation of dotnet core base gRPC services, using Application Insights_

## WARNING
> NOTE: This project is currently a "work in progress". You're welcome to take a look, ask questions, raise issues, and submit pull requests, but please keep in mind that this code is not yet considered "done" and things will change. This message will be removed once the project is closer to being ready for use.

## Introduction

AppInsights.gprc provices C# extension methods that make it easier to add Application Insights telemetry to your gRPC Channels and Services.

Once installed, this package allows you to write the following code to add instrumentation:

```csharp
channel.UseApplicationInsights();

service.UseApplicationInsights();
```

## Folder Structure

This repo contains the following folders:

folder name | description
--- | ---
`/infrastructure` | Contains scripts to deploy Application Insights to Azure
`/samples` | Contains some sample gRPC applications that use the AppInsights.grpc package
`/src` | Contains the source code for the AppInsights.grpc package

## Installation

TODO: Add `nuget` commands

## Setting Up Application Insights

In order to set up an Application Insights instance you first need an Azure Subscription. You can then either use the Azure Portal <https://portal.azure.com> to create an App Insights instance, or you can use the [Azure CLI](https://docs.microsoft.com/en-us/cli/azure/install-azure-cli?view=azure-cli-latest).

To make things easier, there is an ARM template in this repository that will automate the deployment of Application Insights for you. Follow these instructions to use that template:

1. Open a terminal, and make sure you have the Azure CLI installed and that you are logged in (use `az login` to do this).
2. Create a resource group to deploy Application Insights into:

`az group create --name [resource-group-name] --location [location]`

3. Use the template to deploy Application Insights

`az group deployment create --name [deployment-name] --resource-group [resource-group-name] --template-file infrastructure/create-appinsights.json`

Once deployed you will see, as part of the output displayed to you, the instrumention key for your App Insights instance:

```json
"outputs": {
      "appInsightsInstrumentationKey": {
        "type": "String",
        "value": "bc2d7327-9c11-4687-955a-2b05affa27ce"
      }
    },
```

You will ned this instrumentation key later, so make a note of it.

## Instrumenting a gPRC Client

TODO

## Instrumenting a gRPC Service

TODO

