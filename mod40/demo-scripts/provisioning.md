# Provisioning

* Prerequisite: deploy the “standalone” app here: https://gist.github.com/anthonychu/9ab34d2991fb5c1c0c29faeebbe43a51/  use standalone (be careful, certain regions are restricted, tested with eastus)
* Navigate the site a few levels deep to spin it up and start monitoring
* At least 12 hours before the presentation, navigate to the app service down to Monitoring->App service logs
* Turn on Application Logging (filesystem) level information
* Turn on Web server logging (file system) default quota (35) and retention 1 day
* Turn on detailed error messages and failed request tracing and save
* When prompted, click to install the ASP.NET Core extension
* Mangle the MongoDB connection string and use the shopping cart to throw some exceptions, then restore it back
* Create a new deployment set for staging. Clone all settings. Go into deployments and use “External Git” to point to the same repo/branch. Once deployed and working, change the mongodb connection string to break it.
* After throwing an exception, drill into it from Application Insights and click on an exception. The first time you’ll need to click a link “don’t see a snapshot? troubleshoot” and add the appropriate role.
