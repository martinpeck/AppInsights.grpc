# Deploying Application Insights

This folder contains an ARM template for deploying Application Insights.

To deploy, perform the following steps:

1. Open a terminal, and make sure you have the Azure CLI installed and logged in
2. Create a resource group to deploy AI into:

`az group create --name [resource-group-name] --location [location]`

3. Use the template to deploy Application Insights

`az group deployment create --name [deployment-name] --resource-group [resource-group-name] --template-file create-appinsights.json`

Once deployed you will see, as an output parameter, the instrumention key for your App Insights instance:

```json
"outputs": {
      "appInsightsInstrumentationKey": {
        "type": "String",
        "value": "bc2d7327-9c11-4687-955a-2b05affa27ce"
      }
    },
```

You will need this instrumentation key with the gRPC sample.