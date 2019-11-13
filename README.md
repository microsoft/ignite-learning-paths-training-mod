# Ignite Learning Paths - (MOD) Modernizing Data, Applications, and APIs to the Cloud

![Learning Path](https://img.shields.io/badge/Learning%20Path-MOD-fe5e00?logo=microsoft)  ![Session](https://img.shields.io/badge/🗣️Sessions-6-31c754)

**Welcome to the Train-the-Trainer content for the 'Modernizing Data, Applications, and APIs to the Cloud Learning Path**. 

We are looking forward to working with all speakers who will deliver the content built below - we welcome your feedback and help to keep the content up-to-date. 

* There are **x5 45 minute sessions** ([MOD10](mod10/README.md), [MOD20](mod20/README.md), [MOD30](mod30/README.md), [MOD40](mod40/README.md) and [MOD50](mod50/README.md))

* And **x1 20 min theatre session** ([MOD41](mod41/README.md))

## Learning Path Description

Northwind is a well-known, old fashioned firm with a suite of web applications and databases that grew historically over the year. After their acquisition by Tailwind Traders, it is now time to migrate everything to Azure and to modernize the applications with best practices and new features. This may sound like a scary task but we are here to help you understand the benefits, work through the challenges gradually and end up with highly scalable, maintainable and modernized applications.

## Session Descriptions

### [MOD10: Migrating Web Applications to Azure](./mod10/README.md)
#### Abstract:

When Tailwind Traders acquired Northwind earlier this year, they decided to consolidate their on-premises applications with Tailwind Traders’ current applications running on Azure. Their goal: vastly simplify the complexity that comes with an on-premises installation.

In this session, you’ll examine how a cloud architecture frees you up to focus on your applications, instead of your infrastructure. Then, you’ll see the options to “lift and shift” a web application to Azure, including: how to deploy, manage, monitor, and backup both a Node.js and .NET Core API, using Virtual Machines and Azure App Service. 

### [MOD20: Moving Your Database to Azure](./mod20/README.md) 
#### Abstract:

Northwind kept the bulk of its data in an on-premises data center, which hosted servers running both SQL Server and MongoDB. After the acquisition, Tailwind Traders worked with the Northwind team to move their data center to Azure. 

In this session, you’ll see how to migrate an on-premises MongoDB database to Azure Cosmos DB and SQL Server database to an Azure SQL Server. From there, you’ll walk through performing the migration and ensuring minimal downtime while you switch over to the cloud-hosted providers. 

### [MOD30: Modernizing Your Application with Containers](./mod30/README.md) 
#### Abstract:

Tailwind Traders has implemented development frameworks, deployment strategies, and server infrastructure for their apps. But now that they are on the cloud it’s time to add cool features using simple scripts to access powerful services that automatically scale and run exactly where and when they need them. This includes language translation, image recognition, and other AI/ML features.

In this session, we’ll create a set of routines that run on Azure Functions, respond to events in Azure Event Grid, and then orchestrate these functions and messages with Azure Logic Apps. We’ll also use Azure Cognitive Services to add AI capabilities and Xamarin to implement AR features with a phone app.

### [MOD40: Consolidating Infrastructure with Azure Kubernetes Service](./mod40/README.md) 
#### Abstract:

Now that Tailwind Traders is running fully on Azure, the developers must find ways to debug and interact with the production applications with minimal impact and maximal efficiency. Azure comes with a full set of tools and utilities that can be used to manage and monitor your applications. In this session, we will see how Streaming logs work to monitor the production application in live time. We will also talk about Deployment slots that enable easy A/B testing of new features and show how Snapshot Debugging can be used to live debug applications. We'll also see how other tools can be used to manage your websites and containers live.

### [MOD41: Deploying and A/B testing without risks with Deployment Slots](./mod41/README.md) 
#### Abstract:

Who hasn’t been very scared when deploying a new feature to a website? Sometimes we feel that we will break everything, and the stress level is just not something we want to experience ever again. That's why the Deployment Slots feature of Azure App Services is such a nice experience. With Deployment Slots, you can deploy to a safe slot in the same conditions than your production environment. You can test in isolation, without risking breaking something. Then you can gradually route some of the traffic to the new features, for example to perform A/B testing. When you are satisfied with the results, you can simply switch the whole traffic to the new site. But don't fret, if something goes wrong, the old, safe site is just one mouse click away.

### [MOD50: Debugging and Interacting with Production Applications](./mod50/README.md) 
#### Abstract:

In this session, we’ll show you how Tailwind Traders’ Developer team works with its Operations teams to safely automate tedious, manual tasks with reliable scripted routines and prepared services. 

We’ll start with automating the building and deployment of a web application, backend web service and database with a few clicks. Then, we’ll add automated operations that developers control like A/B testing and automated approval gates. We’ll also discuss how Tailwind Traders can preserve their current investments in popular tools like Jenkins, while taking advantage of the best features of Azure DevOps.