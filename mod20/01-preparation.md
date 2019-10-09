# MOD20 Demos deployment and preparation

> **TODO**: Finish this and ask other members of the team to test.

The deployment of the demos is mostly automated. You can run this deployment for training purpose and then delete the resource groups that you created, and deploy again. The deployment can also be run in parallel multiple times with a unique name. This is needed sometimes when multiple speakers are presenting the session in different locations at the same time.

In order to run the deployment, you will need the following decisions:

<a id="credentials"></a>
- A **username** and a **password** which will be used everywhere:
    - Windows 2012 virtual machine login.
    - SQL Server 2012 login.
    - Linux virtual machine running the MongoDB.
    - Azure SQL Databases.

<a id="location"></a>
- A **location** where your services should be deployed. Note that not all the services used here are available at all Azure locations. We recommend choosing a location that allows running all services, for instance `East US 2` or `West Europe`.

<a id="prefix"></a>
- A **unique prefix** that will be used to render each resource name unique.

> IMPORTANT: Because of some limitations in some services' names, the prefix should be **4 characters long maximum**. You should only use **the letters a-z or the digits 0-9** for the prefix.

## Initial deployment

The deployment for this session is split in two parts:

- [Data source](./02-prep-vms.md): This deployment installs two virtual machines: a Linux VM running MongoDB for the shopping cart; and a Windows Server 2012 VM running SQL Server 2012 for the products. These VMs are the source of the migration.

- [Platform as a Service](./03-prep-paas.md): This deployment installs the following services:
    - An Azure SQL server with two databases. The first database will be the target of the migration for the products. The second database is a backup that will be used during the demo in case the migration fails for any reason.
    - A CosmosDB database which will be used as the target of the migration for the shopping cart.
    - Another CosmosDB database as a backup that will be used during the demo in case the migration fails for any reason.
    - The front-end website connecting to the databases to show the catalog.
    - A storage account we'll use to configure advanced security features for the SQL database.
    - The Azure Database Migration Service we'll use for the demo.

After both deployments are complete, some additional steps will be needed to [complete the deployment](./04-prep-finish.md). Then you will be able to [prepare for the demos](./05-prep-demos.md), and then [run the demos](./06-demos.md).

The advantage of the automated deployment is that you can deploy and delete the resources as often as you need. To delete, simply [follow the steps described here](./07-cleaning-up.md).