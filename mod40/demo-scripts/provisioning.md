# Provisioning

* Prerequisite: deploy the “standalone” app here: https://gist.github.com/anthonychu/9ab34d2991fb5c1c0c29faeebbe43a51/ use standalone (be careful, certain regions are restricted, tested with eastus)
* Navigate to the deployed Tailwind Traders site and click through various pages to start monitoring
* At least 12 hours before the presentation navigate to the App Service in the Azure Portal and open "App service logs" which appears under "Monitoring" in the left navigation.
* Turn on:
  * Application Logging (Filesystem) and set Level to "Information"
  * Web server logging, selecting "File System". Leave Quota as default (35MB) and Retention Period as default (1 day)
  * Detailed error messages 
  * Failed request tracing
* Click Save
* When prompted, click to install the ASP.NET Core extension (it shows as a blue bar at the top of the page on Save)
* Navigate to the App Service Configuration and set an invalid value for the "MongoConnectionString" setting (keep a copy of the valid setting for later)
* In another tab use the Tailwind Traders site and attempt to add items ot the shopping cart which will throw some exceptions
* Return to the App Service and restore the working connection string
* Create a new App Service Deployment Slot called "staging" and clone all settings from the existing site. 
* Open the new Deploy Slot once cloned and open "Deployment Center"
* Select “External" under "Manual Deployment" and configureto the same repo/branch as the production slot (at time of writing that is: https://github.com/Microsoft/TailwindTraders-Website | master | Git | Public Repository). 
* Once the site has deployed, change the MongoDB connection string (as above) to break it.
* Browse to the staging site version of Tailwind Traders and attempt to add items to the cart (as above).
* After throwing an exception, switch back to the Portal and drill into the issue from Application Insights and click on an exception. The first time you’ll need to click a link “don’t see a snapshot? troubleshoot” and add the appropriate role.
