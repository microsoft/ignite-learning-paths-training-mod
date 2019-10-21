# Train The Trainer - MOD30: Demo Setup

The following steps are necessary to prepare for MOD30 demos.

## Software

1. Install [Node.js](https://nodejs.org) LTS
2. Install [artillery](https://artillery.io/): `npm i -g artillery`
3. Install [Visual Studio 2019 Preview](https://visualstudio.microsoft.com/?WT.mc_id=msignitethetour2019-github-mod30) with the Azure/cloud workloads (for functions)
4. (Optional) Install [Storage Explorer](https://docs.microsoft.com/azure/vs-azure-tools-storage-manage-with-storage-explorer?tabs=windows&WT.mc_id=msignitethetour2019-github-mod30)
5. (Optional) for sharing Android device: [Vysor](http://www.vysor.io/)

## Deployments

1. Provision the Tailwind Traders monolith app available [here](https://gist.github.com/anthonychu/9ab34d2991fb5c1c0c29faeebbe43a51)
2. Deploy the MOD30 Assets: [![Deploy to Azure](https://azuredeploy.net/deploybutton.png)](https://azuredeploy.net/?repository=https://github.com/microsoft/ignite-learning-paths/tree/master/mod/mod30)
    > **Note:** give it a unique prefix it with, i.e. `mod30xyz` should replace `mod30`, and hereafter assume `mod30-demo` translates to `mod30xyz-demo`
3. Navigate to the `azureeventgrid` connection, click "Edit API connection" then click `Authorize` to authorize the connection (don't forget to `Save` after authorizing!)
4. Publish the `Mod30Functions` app to the deployed `mod30-app` endpoint.
5. Open the `socialintegration` Logic App and update:
    1. Search term (trigger)
    2. Owner name
    3. App name
    4. Token from App Center

***Deployment unsuccessful?** See [Troubleshooting](#troubleshooting)*

## Mobile App

*The mobile app currently is only available for phones. Devices such as Tablets (iPad) will not work*

1. Locate and install the Tailwind Traders app on your device's app store.
2. Login to app with fake email and password.
3. After logging in, go to Menu > Settings [image]
4. Update Product Service API URL with url of deployed website from [Deployment](#deployments) Step 1.
5. Update Storage Account Name with storage account created from [Deployment](#deployments) Step 2.
6. Update Functions App Url with Function App created from [Deployment](#deployments) Step 2.
7. Save your changes with the "Save" button at the bottom.

*Can't access the app after troubleshooting? Contact Matt Soucoup for assistance*

## Azure Portal

Create a custom dashboard for the session. (Tip: use `https:/aka.ms/publicportal` to ensure you are using the public portal.)

Pin the following items for easy reference:

* `mod30-demo` function app
* `mod30-demo` application insights
* `mod30demostorage` storage
* `mod30-app` function app
* `mod30-caption` logic app

## Deployment Troubleshooting

If after the deployment, you navigate to `mod30-app` and there are no functions, you may need to manually deploy:

1. Under the function app, go to `Platform features`
2. Click `Deployment center`
3. Choose `External git` then click continue
4. Choose `Kudu` then click continue
5. Put in repo: https://github.com/Microsoft/Ignite-Learning-Paths and branch `master` and check `no` for `Private Repository`
6. Confirm and the deployment will begin. Once the status is `Success (Active)` you should have the function app

## Mobile App Troubleshooting
