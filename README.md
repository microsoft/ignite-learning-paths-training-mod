# Ignite Learning Paths - Modernizing Web Applications and Data

![Learning Path](https://img.shields.io/badge/Learning%20Path-MOD-fe5e00?logo=microsoft)  ![Session](https://img.shields.io/badge/🗣️Sessions-6-31c754)

Welcome!

The content of this repository is available for you so you can reproduce any demo or learn how to present any session of the Learning Path presented at [Microsoft Ignite](https://www.microsoft.com/ignite) and during [Microsoft Ignite The Tour](https://www.microsoft.com/ignite-the-tour/), in your local field office, a community user group, or even as a lunch-and-learn event for your company.

## Do the Demos

If you are here to reproduce a demo in the comfort of your home/office, go to the [Sessions](#sessions) section. In each session you will find deployment instructions to create the environment you need, and a tutorial to do the demo step by step.

## Presenting the content

We're glad you are here and look forward to your delivery of this amazing content. As experienced presenters, we know you know HOW to present so this guide will focus on WHAT you need to present. It will provide you a full run-through of the presentation created by the presentation design team.

Along with the video of the presentation, this repository will link to all the assets you need to successfully present including PowerPoint slides and demo instructions & code.

We are looking forward to working with all speakers who will deliver the content built below - we welcome your feedback and help to keep the content up-to-date.

## Learning Path Description

Northwind is a well-known, old fashioned firm with a suite of web applications and databases that grew historically over the year. After their acquisition by Tailwind Traders, it is now time to migrate everything to Azure and to modernize the applications with best practices and new features. This may sound like a scary task but we are here to help you understand the benefits, work through the challenges gradually and end up with highly scalable, maintainable and modernized applications.

## Sessions

Here all the sessions available in the learning path **Modernizing Data, Applications, and APIs to the Cloud** (aka: **MOD**)

* There are **x5 45 minute sessions** ([MOD10](mod10/README.md), [MOD20](mod20/README.md), [MOD30](mod30/README.md), [MOD40](mod40/README.md) and [MOD50](mod50/README.md))
* And **x1 20 min theatre session** ([MOD41](mod41/README.md))

### [MOD10: Migrating Web Applications to Azure](./mod10/README.md)

When Tailwind Traders acquired Northwind earlier this year, they decided to consolidate their on-premises applications with Tailwind Traders’ current applications running on Azure. Their goal: vastly simplify the complexity that comes with an on-premises installation.

In this session, you’ll examine how a cloud architecture frees you up to focus on your applications, instead of your infrastructure. Then, you’ll see the options to “lift and shift” a web application to Azure, including: how to deploy, manage, monitor, and backup both a Node.js and .NET Core API, using Virtual Machines and Azure App Service.

### [MOD20: Moving Your Database to Azure](./mod20/README.md)

Northwind kept the bulk of its data in an on-premises data center, which hosted servers running both SQL Server and MongoDB. After the acquisition, Tailwind Traders worked with the Northwind team to move their data center to Azure.

In this session, you’ll see how to migrate an on-premises MongoDB database to Azure Cosmos DB and SQL Server database to an Azure SQL Server. From there, you’ll walk through performing the migration and ensuring minimal downtime while you switch over to the cloud-hosted providers.

### [MOD30: Enhancing Web Applications with Cloud Intelligence](./mod30/README.md)

Tailwind Traders has implemented development frameworks, deployment strategies, and server infrastructure for their apps. But now that they are on the cloud it’s time to add cool features using simple scripts to access powerful services that automatically scale and run exactly where and when they need them. This includes language translation, image recognition, and other AI/ML features.

In this session, we’ll create a set of routines that run on Azure Functions, respond to events in Azure Event Grid, and then orchestrate these functions and messages with Azure Logic Apps. We’ll also use Azure Cognitive Services to add AI capabilities and Xamarin to implement AR features with a phone app.

### [MOD40: Debugging and interacting with production applications](./mod40/README.md)

Now that Tailwind Traders is running fully on Azure, the developers must find ways to debug and interact with the production applications with minimal impact and maximal efficiency. Azure comes with a full set of tools and utilities that can be used to manage and monitor your applications. In this session, we will see how Streaming logs work to monitor the production application in real-time. We will also talk about Deployment slots that enable easy A/B testing of new features and show how Snapshot Debugging can be used to live debug applications. We'll also see how other tools can be used to manage your websites and containers live.

### [MOD41: (15-20 Minute Theatre Session)Deploying and A/B testing without risks with Deployment Slots](./mod41/README.md)

Who hasn’t been very scared when deploying a new feature to production? Sometimes we feel that we will break everything, and the stress level is just not something we want to experience ever again. That's why the Deployment Slots feature of Azure App Services is such a nice experience. With Deployment Slots, you can deploy to a staging slot that mirrors your production environment. You can test in isolation, without the risk of breaking something. Then you can gradually route some of the traffic to the new features, for example to perform A/B testing. When you are satisfied with the results, you can simply switch all the traffic to the new site. But don't fret, if something goes wrong, the old, safe site is just one mouse click away.

### [MOD50: Managing Delivery of your App via DevOps](./mod50/README.md)

In this session, we’ll show you how Tailwind Traders’ Developer team works with its Operations teams to safely automate tedious, manual tasks with reliable scripted routines and prepared services.

We’ll start with automating the building and deployment of a web application, backend web service and database with a few clicks. Then, we’ll add automated operations that developers control like A/B testing and automated approval gates. We’ll also discuss how Tailwind Traders can preserve their current investments in popular tools like Jenkins, while taking advantage of the best features of Azure DevOps.

## Contributing

To know more about about to contribute to this project please refer to the [Code of Conduct](CODE_OF_CONDUCT.md) and [Contributing](CONTRIBUTING.md) page.

## Become a Trained Presenter

You don't need anything to present this content, it's all there to be used. However, by becoming a *Trained Presenter* the scalable content team will recognize you as well. *Trained Presenter* see their contact information (name, picture, website) in the bottom of each session.

To become a *Trained Presenter*, contact [scalablecontent@microsoft.com](mailto:scalablecontent@microsoft.com). In your email please include:

* Complete name:
* The code of this presentation: \<Session Code (ex:APPS10)\>
* Link to an unlisted YouTube video of you presenting around 10 minutes of the content for this specific session.

## Legal Notices

Microsoft and any contributors grant you a license to the Microsoft documentation and other content in this repository under the [Creative Commons Attribution 4.0 International Public License](https://creativecommons.org/licenses/by/4.0/legalcode), see the [LICENSE](LICENSE) file, and grant you a license to any code in the repository under the [MIT License](https://opensource.org/licenses/MIT), see the [LICENSE-CODE](LICENSE-CODE)

Microsoft, Windows, Microsoft Azure and/or other Microsoft products and services referenced in the documentation may be either trademarks or registered trademarks of Microsoft in the United States and/or other countries. The licenses for this project do not grant you rights to use any Microsoft names, logos, or trademarks. Microsoft's general trademark guidelines can be found [here](http://go.microsoft.com/fwlink/?LinkID=254653).

Privacy information can be found [here](https://privacy.microsoft.com)

Microsoft and any contributors reserve all other rights, whether under their respective copyrights, patents, or trademarks, whether by implication, estoppel or otherwise.
