# MOD50 (Tailwind Traders Deployment)

| [README](/MOD50/README.md) | [Slides](/MOD50/slides/README.md) | [Demos](/MOD50/demos/README.md) | [Deployment](/MOD50/deployment/README.md)
|--------|-------|------------|------|

## Prerequisites

To present **MOD50: Managing Delivery of your App via DevOps**, you'll need an account Microsoft Azure.
You will also need Visual Studio Code (VSCode) to make changes to the application.  

### Azure Subscription

If you are presenting the demonstrations live you will need to access the Azure Portal, which requires an Azure account. If you have not done so already, [sign up for free here](https://portal.azure.com).

### Visual Studio Code

You will need to access and make changes to the code locally, which requires a local editor.  Visual Studio Code can be downloaded from https://code.visualstudio.com/.  

You will also need the [GitHub Pull Requests Extension](https://marketplace.visualstudio.com/items?itemName=GitHub.vscode-pull-request-github) installed on Visual Studio Code.

Optionally, you can also install an extension that will display YAML files.  

You could also use a local git client to manage push/pull requests, but the VSCode method is preferable for demos.  

## Demo Environment Deployment Instructions

The Tailwindtraders demo requires a full backend system, plus two additional Web apps that will be used to deploy code from Azure DevOps.

There are four parts to the deployment: 

1) Deploy a full backend system
2) Deploy and configure the front end Web apps
3) Fork the application locally
4) Create an empty Azure DevOps project

### Automated Backend Deployment

Use the "deploy to Azure" button and choose the "Standalone" mode at [this link](https://github.com/microsoft/TailwindTraders-Website/tree/master/Source/Tailwind.Traders.Web/Standalone) to deploy the full backend system.

Follow the steps on that page for standalone configuration.  
Verify that the Web app that is generated as part of this deployment is fully operational.  

### Front end Web App deployment and configuration

Once you have created the standalone version of the backend application, and verified that it is fully operational, deploy the target Web Apps by pressing the blue "*Deploy to Azure*" button below.


<a href="https://portal.azure.com/#create/Microsoft.Template/uri/https%3A%2F%2Fraw.githubusercontent.com%2Fbbenz%2Fbrian-templates%2Fmaster%2Fapp-service%2Fazuredeploy.json" target="_blank">
    <img src="http://azuredeploy.net/deploybutton.png"/>
</a>

This creates two empty Web Apps that we will deploy code to from Azure DevOps.  
The production Web app is deployed with a deployment slot created called "canary".  This will be used for the A/B testing later.

Once the deployment process is completed, you will need to copy the connection strings for your SQL Database and your CosmosDB database to the new staging and production Web apps.  
Use the connection strings from the Web app that was generated as part of the backend deployment, and copy them to the new empty Web apps.

---

### Fork the application

You need to fork the application and clone it locally.  
We will use the local code to change the shipping cost in VS Code

Fork and clone https://github.com/microsoft/TailwindTraders-Website


### Create an empty Azure DevOps project

Next, we need to create a new Azure DevOps project for building and deploying the application.  

From the azure portal, create an Azure DevOps project.
For the Azure service to deploy to, select a Windows Web App.
Create a new project, and a new organization.  Enter your subscription information if it's not already displayed.  
Reuse the Web App name and location that you recorded when deploying the Web app names in the deployment step above

Go to https://dev.azure.com/, select the organization you created, then select the project.  

You have now deployed the application, a front-end resource group that wil be used as a target for the deployment, and all the Azure DevOps resources you need for building and deploying the application.   


## Post-Deployment Steps

After you have verified that the application is working, 

Open VS Code and verify that you can access the source code you will be changing in:
...TailwindTraders-Website\
Open Source\Tailwind.Traders.Web\ClientApp\src\assets\locales\translation.json

Copy provided-azure-pipelines.yml from https://github.com/bbenz/TailwindTraders-Website/blob/master/provided-azure-pipelines.yml to your local repo.

## Next up: Steps to prep demos

Deployment is now complete!  
Follow the Pre-delivery Preparation steps in [Demos](/mod50/demos/README.md) to prepare for the demos before a session


[A video of all of the Deployment steps above is available for download here](https://globaleventcdn.blob.core.windows.net/assets/mod/mod50/video/mod50directorscutTTT-2019-10-07%20-%20Copy.mp4)

---

## **IMPORTANT:** When you are done

Be sure to delete the resources when you have completed the presentation.

Run the following command from [Cloud Shell](https://shell.azure.com) to delete the entire resource group.  You will have to run it twice, once for the full backend resource group, and one for the frontend resource group.

``` az cli
az group delete --name <resource group name> --yes --no-wait
```

It will take several minutes, but by deleting the entire resource group, all resources associated with the demo environment will be destroyed.

---

## Having Trouble?

### Provider registration

The Tailwind Traders application uses many Azure services. In some cases, if a service has not yet been used in your subscription, a provider registration may be needed. The following commands will ensure your subscription is capable of running the Tailwind Traders application.

``` az cli
az provider register --namespace Microsoft.OperationalInsights
az provider register --namespace Microsoft.DocumentDB
az provider register --namespace Microsoft.DBforPostgreSQL
az provider register --namespace Microsoft.OperationsManagement
az provider register --namespace Microsoft.ContainerService
az provider register --namespace Microsoft.Sql
az provider register --namespace Microsoft.ContainerRegistry
```

---

## Source Repositories

For a deeper understanding of the infrastructure and applications this presentations uses as a demo environment, please reference the following repositories and documentation.

https://github.com/microsoft/TailwindTraders

https://github.com/neilpeterson/TailwindTraders-Backend

https://github.com/neilpeterson/TailwindTraders-Website
