# Demos description

This page describes the migration demos. You can find the [recordings of the demos as well as a complete dry run on the following page](./00A-videos.md). It can be useful to download the demo videos and save them locally in case the internet doesn't allow you to connect to Azure reliably, etc.

You can also see the recording of a dry run for this session, which includes the demos as well.

> **Important**: Make sure to run the [preparation steps](./01-preparation.md) first.

<a id="demo1"></a>
## Demo 1: Migrating from MongoDB to CosmosDB

In this demo we will migrate the shopping cart data from an on-premises MongoDB instance running in a Linux VM to CosmosDB. Then we will change the connection string in the App Service and show that the data has been migrated, and the shopping cart works without any changes to the code.

### Preparing the website and populating the shopping cart

Start this demo by opening the App Service in the Azure portal.

Then open the website in a new browser tab. Note that the grey debug header on top of the page shows the IP addresses of the VMs in which the "on-premises" databases are running.

Show the website to the audience, navigate in categories, open a product details, etc.

Then use the login button to log into the shopping cart. You can use any email address to log into the shopping cart but make sure to use the same email address that you use during the preparation.

> During [the preparation steps](./04-prep-finish.md), we populated the backup CosmosDB and Azure SQL instances with data. If the migration demo fails, you can use the backup databases to connect them to the website, and simulate that the migration succeeded anyway. In order for this to work, you must make sure to use the same email address for the login at every step.

> The password is dummy and is never checked so you can use any value here.

Once you are logged in, an `Add to cart` button appears. You can add an item to the shopping cart. Then go back to the website's main page, navigate to another item and add it too. Navigate to the cart, you can then increase the quantities.

### Showing the Linux VM

Now we can explain where the data is located. Open the MongoDB VM in the Azure Portal. You can find the SSH instruction by clicking the `Connect` button in the Overview tab of this VM.

Copy the SSH command, then [open the Cloud Shell](https://shell.azure.com) and connect to the Linux VM with this SSH command. You will need to enter the password for this VM, which you can always find in the cheat sheet that you prepared during the prep steps.

Once you are logged into the VM, type the command `mongo`. This will start the MongoDB console. This is just to illustrate that this is the source for the MongoDB data.

Then you can type `exit` to exit the MongoDB console, then `exit` again to leave the virtual machine. You can then close the Cloud Shell.

### Showing the SQL VM

Since we just showed the MongoDB instance running in the Linux VM, we can now show the SQL Server instance running in the Windows Server 2012 virtual machine. In the Azure Portal, navigate to this VM and then click on `Connect` in the Overview tab.

In the drawer, click on `Download RDP file`. You can save this file somewhere and open it. This starts a remote desktop connection. In the dialog window, you can enter the credentials for the virtual machine. These are the same credentials used everywhere else.

Show the virtual machine and explain that this is an old server running on premises. You can then close the remote desktop connection.

### Migrating the MongoDB data

Go back to the Azure Portal and navigate to the Azure Database Migration Service instance.

In the Overview tab, click on New Migration Project. Then fill the data:

- Project name: Enter `mig-mongo`.
- Source server type: Select MongoDB. Explain the different sources that are available in this combo box.
- For MongoDB sources, there is only the CosmosDB target type.
- Click on `Type of Activity` and explain that we will perform an offline data migration here but that we will explain the online data migration later.
- Click on `Save` then `Create and run activity`.
- In the Source Details drawer, select `Connection String mode`.
- Copy the MongoDB connection string from the cheat sheet and paste it in the portal. Then click `Save`.
- In the Migration target details drawer, make sure to select the correct CosmosDB instance that you want to use for the target. It should be named `mod20[prefix]mongo` where `[prefix]` is the unique prefix that you [prepared here](./01-preparation.md/#prefix). The connection string is automatically copied by the DMS. Then click `Save`.
- In the Map to target databases drawer, check that the tailwind database is selected both in the source and the target. Explain that you can also throttle the troughput is needed. Then click `Save`.
- In the Collection setting drawer, show that the Cart collection will be created in the target database. Then click `Save`.
- Finally enter a name for the migration activity, for example `mig-mongo` again. Then click on `Run migration`.

The migration will take just a few seconds to complete. You can check the progress by clicking the `Refresh` button.

### Changing the connection string

Wen the migration is complete, open the CosmosDB instance in the portal. Show that the `cart` collection is now available. Then click on Connection String. Copy the Primary connection string to the clipboard.

Then navigate to the App Service instance. Click on `Configuration`, and then `Advanced edit`. Scroll down to the `MongoConnectionString` setting and paste the value you just copied. Show that even though it's now pointing to the CosmosDB instance, the connection string starts with the `mongodb://` protocol, because we are using the same APIs.

Click `OK` and then `Save`. This will force the web application to restart, which takes a couple of minutes.

> Wait until the notification turns green before navigating to another page

### Tour of the CosmosDB instance

Since we have a couple of minutes, we can give a small tour of the CosmosDB instance that we migrated to.

Open this instance in the portal. Select the `Connection string` tab and explain that all credentials are found here. Then select the `Replicate data globally` tab. Explain the benefits of replicating data globally, show how easy it is to do, without changes to the app. Show the read and write multi-region.

Then show the `Metrics` tab. Explain what SLAs we have, for example latency below 10ms for read and write, or availability above 99.999%. 

### Check the website

Go back to the website and refresh the page. The debug header should now show that the Mongo server is pointing to CosmosDB on Azure. The shopping cart data is still there, so the migration was successful. 

Go back to the CosmosDB instance and open the `Data explorer`. There, expand the `cart` collection. In the `Documents`, you will see some documents corresponding to the items in the cart.

> Because of a bug in the Data explorer, it is not currently possible to edit documents after the migration.

Click on `New document` to add an item to the cart. Then copy and paste the JSON data from the cheat sheet and click on `Save`. After the save action is complete, go back to the Shopping cart. You will see the new item that was just added in there.

### Explain online data migration

At this point you can explain what is the advantage of online data migration:

If we do this migration offline, during the time that it takes to migrate the data, change the connection string and restart the web app, it is possible that some users continue to shop, and their changes will be lost. 

To avoid this, we should shut the website down during the migration, but this is bad for business.

The Database migration service supports online data migration. In this mode, the data keeps synchronized during the source and the target databases as long as the DMS is running. This allows the migration to be done without downtime.

This concludes the first demo. Go back to the slides to introduce Azure SQL Database.

<a id="demo2"></a>
## Demo 2: SQL Server 2012 to Azure SQL Database

For the second demo, we will migrate the product descriptions from SQL Server 2012 to Azure SQL database. 

First, open the Azure SQL Database instance in the Azure portal. Then launch the Query editor.

> If your IP address changed, it is possible that you have to add your Client IP to the whitelist again. [The process is described here](./04-prep-finish.md#config-firewall).

In the Query editor, expand the Tables node. Show that it is empty at the moment.

### Migrating the SQL schema

Open the Database migration service instance. Then click on `New migration project`. Enter the name `mig-sql`. Show the Source server type choices in the combobox and underline the diverse choices we have. For this migration, select `SQL server`. For the Target server type, show the choices available. We will use `Azure SQL Database`. Click on `Choose type of activity`. Since we are using an Azure SQL Database single instance as the target of the migration, we will migrate the schema first. Select `Schema only migration`. Then click on `Save`.

Click on `Create and run activity`. 

Copy the SQL VM's IP address from the cheat sheet and paste it in the `Source SQL server instance name` field.

Select `SQL authentication` for the Authentication type.

Enter the username and the password as saved in the cheat sheet.

Then click on `Trust server certificate`. Then click on `Save`.

In the Migration target details drawer, copy the Target server name from the cheat sheet and paste it in the corresponding field. Then enter the username and password again for the SQL authentication. Then click on `Save`.

In the Map to target databases drawer, select the `tailwindsql` checkbox. For the Target database, select the target from the combobox. Make sure to NOT select the backup database. Then click on `Save`.

Finally enter a name for the activity, for example `mig-schema`. Select Validation options, and explain that to save time we will not validate the databases here, but you should do it in production. Then click on `Run migration`.

The migration takes a few seconds to complete, you can update the progress by clicking on `Refresh`.

### Migrating the SQL data

Go back to the database migration service. Click on the `mig-sql` project. Then click on `New activity` and select `Offline data migration`. You can remind people quickly about the difference between online and offline migration.

In the Migration source details drawer, enter the password. Then click `Save`.

Enter again the password in the Migration target details drawer and click `Save`.

In the drawer titled Map to target databases, select the `tailwindsql` database and select the correct target database from the combobox.

You can set the `Set source DB read-only` checkbox if you want to avoid any changes made in the source DB during the migration. Then click on `Save`.

In the Select tables drawer, you can expand to show the 5 tables. Then click on `Save`.

On the next page, enter a name for the activity, for example `mig-data` and press `Validation options`. Again, do not validate to save time, but explain that in production you would validate. Then click on `Save`, then `Run migration`.

Here too, the migration takes just a few seconds. You can click `Refresh` until the migration is complete.

### Setting the connection string

Open the App service, click on `Configuration`. Copy the Azure SQL database connection string from the cheat sheet, then go back to the App service, and click on `Advanced edit`. Scroll down to `SqlConnectionString` and replace the value with the one you just copied.

Then press `OK` and then `Save`.

> Wait until the notification turns green before navigating to another page

### Introducing Azure SQL database

While the application is restarting, we can take a quick tour of the Azure SQL database. Navigate to this instance in the Azure portal. Show the Geo-replication drawer and explain that this is configured for higher reliability.

Then click on `Connection strings` and show the various options.

Further down, click on `Advanced data security` then `Vulnerability Assessment`. Explain this feature and show that the current database has vulnerabilities, and show the report.

### Show the migrated website

Go back to the website and refresh the page. Show that the debug header now shows Azure as the source of the data. You can navigate in the categories and show that everything still works like before.


