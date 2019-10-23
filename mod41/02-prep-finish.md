# Finishing the deployment

A few additional steps are needed to finish the deployment.

## I. Creating and configuring the Staging deployment slots

1. In the Azure Portal, open the App service you just deployed.

2. Open the Deployment slots drawer

3. Click on `Add Slot`

4. Enter the name `Staging` and select to clone the settings from the production slot.

5. Click on `Add`.

6. In the Staging slot, click on Deployment Center.

7. Select `External` as the source for continuous deployment. Then click on `Continue`.

8. Select `App Service build service` and click on `Continue`.

9. Under Repository, enter `https://github.com/lbugnion/TailwindTraders-Website`.

10. Under Branch, enter `Typos`.

11. Select `Git` Repository type.

12. Select `No` for Private repository.

13. Click on `Continue`.

14. Click on `Finish`.

15. Wait until the build is finished.

16. Click on Overview in the App Service.

17. Click on the URL to open the website in a new window.

You should now see the Tailwind Traders website, but there are some typos in the navigation menu, for example `Applyances` and `Sinq`.

![Navigation menu with typos](./images/20191022_1546.png)

> If you don't see the navigation menu, zoom the web brower window out a little to see more elements in the width.

## II. Creating and configuring the AbTest deployment slots

1. In the Azure Portal, open the App service you just deployed.

2. Open the Deployment slots drawer

3. Click on `Add Slot`

4. Enter the name `AbTest` and select to clone the settings from the production slot.

5. Click on `Add`.

6. In the AbTest slot, click on Deployment Center.

7. Select `External` as the source for continuous deployment. Then click on `Continue`.

8. Select `App Service build service` and click on `Continue`.

9. Under Repository, enter `https://github.com/lbugnion/TailwindTraders-Website`.

10. Under Branch, enter `AbColor`.

11. Select `Git` Repository type.

12. Select `No` for Private repository.

13. Click on `Continue`.

14. Click on `Finish`.

15. Wait until the build is finished.

16. Click on Overview in the App Service.

17. Click on the URL to open the website in a new window.

You should now see the Tailwind Traders website, but the main color has been changed to red for the demo.

![Red main color for AB test](./images/2019-10-23_13-58-10.png)

## V. Time to rehearse your demos!!

Every time before you start the demos, you will need to execute a few simple steps to make sure that the environment is ready. [These steps are described here in details](./03-prep-demo.md). Have fun!!