# MOD30: Demo Setup

The following steps are necessary to prepare for MOD30 demos.

## Software

1. Install [Node.js](https://nodejs.org) LTS
2. Install [artillery](https://artillery.io/): `npm i -g artillery`

    Windows - Add PATH to `artillery`.
    ```
    %USERPROFILE%\AppData\Roaming\npm
    ```

3. Install [Visual Studio or VS Code](https://visualstudio.microsoft.com/?WT.mc_id=msignitethetour2019-github-mod30)
4. (Optional) Install [Storage Explorer](https://docs.microsoft.com/azure/vs-azure-tools-storage-manage-with-storage-explorer?tabs=windows&WT.mc_id=msignitethetour2019-github-mod30)
5. (Optional) for sharing and screen mirroring on Android device: [Vysor](http://www.vysor.io/)
6. (Optional) for sharing and screen mirroring oniOS device: [Reflektor](https://www.airsquirrels.com/reflector)

## Deployments

1. Provision the Tailwind Traders monolith app available [here](https://github.com/microsoft/TailwindTraders-Website/tree/master/Source/Tailwind.Traders.Web/Standalone#deploy-to-azure-app-service-automatic-deployment)
2. Deploy the MOD30 Assets: [![Deploy to Azure](https://azuredeploy.net/deploybutton.png)](https://azuredeploy.net/?repository=https://github.com/microsoft/ignite-learning-paths-training-mod/tree/master/mod30)
    > **Note:** give it a unique prefix it with, i.e. `mod30xyz` should replace `mod30`, and hereafter assume `mod30-demo` translates to `mod30xyz-demo`
3. Navigate to the `azureeventgrid` connection, click "Edit API connection" then click `Authorize` to authorize the connection (don't forget to `Save` after authorizing!)
4. Publish the `Mod30Functions` app to the deployed `mod30-app` endpoint.
5. Open the `socialintegration` Logic App and update:
    1. Search term (trigger)
    2. Owner name (This will most likely be `Microsoft-CDA`)
    3. App name (This will most likely be `Tailwind-Traders`)
    4. Token from App Center. If you're a Microsoft employee, [visit this link](https://aka.ms/twt-appcenter-token). Otherwise, contact the session or learning path captains or Matt Soucoup.

***Deployment unsuccessful?** See [Troubleshooting](#troubleshooting)*

## Azure Portal

Create a custom dashboard for the session. (Tip: use `https:/aka.ms/publicportal` to ensure you are using the public portal.)

Pin the following items for easy reference:

* `mod30-demo` function app
* `mod30-demo` application insights
* `mod30demostorage` storage
* `mod30-app` function app
* `mod30-caption` logic app

## Mobile App Setup

This demo includes a mobile app. The instructions for setup can be found [here](MOBILE-APP-README.md).

## Demo Code

Demo code can be found [here](https://github.com/microsoft/ignite-learning-paths-training-mod/blob/master/mod30/src/Mod30Functions/)

## Deployment Troubleshooting

If after the deployment, you navigate to `mod30-app` and there are no functions, you may need to manually deploy:

1. Under the function app, go to `Platform features`
2. Click `Deployment center`
3. Choose `External git` then click continue
4. Choose `Kudu` then click continue
5. Put in repo: https://github.com/Microsoft/Ignite-Learning-Paths-training-mod and branch `master` and check `no` for `Private Repository`
6. Confirm and the deployment will begin. Once the status is `Success (Active)` you should have the function app.
