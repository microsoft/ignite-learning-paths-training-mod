# Deploying the data sources (Virtual Machines, IaaS)

In order to install the virtual machines that will be used as the source of the migration for the demo, follow these steps:

> Once the Virtual machines are deployed, do not switch them off. This can cause issues, especially with the MongoDB VM. Just keep the VMs running, and delete the resource group when you are done with the demo.

## I. Click on the button below to open the deployment page.

<a href="https://portal.azure.com/#create/Microsoft.Template/uri/https%3A%2F%2Fraw.githubusercontent.com%2Fmicrosoft%2Fignite-learning-paths%2Fmaster%2Fmod%2Fmod20%2FDeploymentTemplates%2Fazuredeploy-vms.json" target="_blank">
    <img src="http://azuredeploy.net/deploybutton.png"/>
</a>

## II. In the template page, enter the following information:

- Subscription: Select the subscription in which the resources should be deployed.
    
- Resource group: Create a new resource group. Try to name it consistently, for example we recommend `mod20[prefix]vms` where `[prefix]` is the unique prefix that you [prepared here](./01-preparation.md/#prefix).
    
- Location: Enter [the location that you selected](./01-preparation.md/#location) for this session's demos, for example `East US 2` or `West Europe`.

- Prefix: The **unique prefix** [that you prepared](./01-preparation.md/#prefix) for to render the resources names unique.

> IMPORTANT: Because of some limitations in some services' names, the prefix should be **4 characters long maximum**. You should only use **the letters a-z or the digits 0-9** for the prefix.

- Username: The [username that you prepared](./01-preparation.md/#credentials), that will be used to log into the virtual machines. We recommend sticking to a consistent username and password. For convenience, this field is pre-populated with the value `tailwind` but you can change it if you want.

- Password: The [password that you prepared](./01-preparation.md/#credentials), that will be used to log into the virtual machines. We recommend sticking to a consistent username and password. For convenience, this field is pre-populated with the value `traderstraders42.` but you can change it if you want.

After you entered the values, check the `Terms and conditions` checkbox and click on Purchase.

![Deployment template](./images/2019-09-22_22-39-05.png)

> Depending on a number of factors, the deployment should take about 6-10 minutes.

## III. Checking the deployment while it is running

After clicking on Purchase, there is a validation step which should happen without issues. Then you can see the progress by clicking on the Notifications button (the one with the bell icon) and then on `Deployment in progress`. This will open a new web page where you can follow what is happening.

![Notifications pane](./images/2019-09-23_17-53-56.png)

> Once the Virtual machines are deployed, do not switch them off. This can cause issues, especially with the MongoDB VM. Just keep the VMs running, and delete the resource group when you are done with the demo.

## IV. Deploy the other Azure services

[Click here](./03-prep-paas.md) and follow the instructions to deploy the other Azure services needed by the demos.