# MOD10 - Migrating Web Applications to Azure 

![Learning Path](https://img.shields.io/badge/Learning%20Path-MOD-fe5e00?logo=microsoft)  

## Session Abstract

When Tailwind Traders acquired Northwind earlier this year, they decided to consolidate their on-premises applications with Tailwind Traders' current applications running on Azure. Their goal: vastly simplify the complexity that comes with an on-premises installation.

In this session, you'll examine how a cloud architecture frees you up to focus on your applications, instead of your infrastructure. Then, you'll see the options to "lift and shift" a web application to Azure, including: how to deploy, manage, monitor, and backup both a Node.js and .NET Core API, using Virtual Machines and Azure App Service.


The session [Ignite Learning Paths - MOD10](https://github.com/microsoft/ignite-learning-paths-training-mod/tree/master/mod10).

## How To Use

Welcome, Presenter! 

We're glad you are here and look forward to your delivery of this amazing content. As an experienced presenter, we know you know HOW to present so this guide will focus on WHAT you need to present. It will provide you a full run-through of the presentation created by the presentation design team. 

Along with the video of the presentation, this document will link to all the assets you need to successfully present including PowerPoint slides and demo instructions &
code.

1.  Read document in its entirety.
2.  Watch the video presentation
3.  Ask questions of the Lead Presenter

## Getting Started

To begin the demo you'll need to do a few things which are described in the TTT video:

1. Execute a cloud shell
2. Download the [create-db.sh](https://github.com/microsoft/ignite-learning-paths-training-mod/blob/master/mod10/create-db.sh) script.
3. You'll need the presentation deck, get the latest from the [presentations.md](presentations.md)

We'll use these to prep before we go into the session.  Fully build the application at least before the session. Always keep a preview copy ready to go and build what you can as a demonstration live.  You will demonstrate building the databases live, but well remind the audience we're using "cooking show rules."  You will show the process of creating these databases.

Once you've prepped the app - you're going to build the same app live using the pre-created database information, an incremented name of the app from the one you've created for the demo.

IE: My pre-show demo 

```
az group create --subscription "Ignite The Tour" --name ignitemod10 --location eastus
```

What I will create live: resource group creation notes in [hints-for-presentation.md](hints-for-presentation.md)

```
az group create --subscription "Ignite The Tour" --name 001ignitemod10 --location eastus
```

The incremented name is just to keep it easy to follow.

---

## Creating Resource Group and Databases.

Within [create-db.sh](https://github.com/microsoft/ignite-learning-paths-training-mod/blob/master/mod10/create-db.sh) there are a few bash variables to change.

```
#!/bin/bash
set -e

# Credentials
azureResourceGroup=igniteapps30
adminUser=twtadmin
adminPassword=twtapps30pD
subname=cd400f31-6f94-40ab-863a-673192a3c0d0
location=eastus

# DB Name

cosmosdbname=apps30twtnosql
sqldbname=apps30twtsql
```

I do the same incrementing of the name for the "live" version.  I create these before hand but then demonstrate how to create from portal.  The versions I do from portal I do not "deploy" - before I "create and deploy" I explain for time we've already created our DB's with Azure SQL and Cosmos DB.

Example:

Live Version - 

```
#!/bin/bash
set -e

# Credentials
azureResourceGroup=ignitemod10
adminUser=example
adminPassword=examplesjefkjdkj
subname=2348283-example-398349839
location=eastus

# DB Name

cosmosdbname=001apps30twtnosql
sqldbname=001apps30twtsql
```

Once you've edited the script lets run it in bash Cloud Shell and begin process of building demo.

```
bash create-db.sh
```

This should take about 15 minutes for both DBs to create.

Collect both connection strings to put in the VARs for the container to connect to the database.

## Next Steps

Go through the opening of the talk with the application fully built in the background.  Keep two portals up, one with the "complete" version of the app, one of the resource group you're going to build live.  You'll want to show them the difference and how you're creating the resources live as you're explaining each part.

## Demoing Live


Run through the demo using [hints-for-presentation.md](hints-for-presentation.md) file.

1. Create Resource Group Cloud Shell (it's already created, but that's fine)
2. Create VNET in Cloud Shell (then show them the vnet in portal)
3. Create VM as described in video and in deck
    * Navigate to your resource group
    * Click Add - Select Ubuntu 18.04 LTS
    * Use Ignite the tour subscription
    * Create unique Virtual Machine name
    * Select region (try using something local to the event)
    * Don't use Spot, Don't enable infra redundancy (just explain it)
    * Use a username and password or use a SSH key (i use ssh key and paste from my terminal)
    * Select inbound ports 22, 443, 80 (explain you can secure better in a secureity group)
    * Click Next Disks
    * Explain adding disks, disk types, do not add new disk.
    * Click Next Networking
    * Use VLAN created in step 2, explain network security groups, load balancing, etc
    * Click Next Management  
    * explain monitoring, explain RBAC via AAD, explain autoshutdown, explain backups.
    * Click Next Advanced  
    * Explain extensions, cloud init, etc.  Click review and create.
    * Explain validation process via ARM - Explain Exporting via ARM template
    * Create - Show create messages in deployment.
4. Navigate to server in resource group, SSH into VM
5. Copy contents of [deploy.sh](deploy.sh) into shell after su to root
6. update variables as decribed in demo instructions in the deployment script (mongo string, SQL, api, etc)
7. Run deploy script - talk through as it runs.
8. Navigate browser to real prod tailwindtraders.com
9. Delete resources

## Assets in Train-The-Trainer kit

- This guide
- [PowerPoint presentation](https://globaleventcdn.blob.core.windows.net/assets/mod/mod10/mod10.pptx)
- [Full-length recording of presentation](https://globaleventcdn.blob.core.windows.net/assets/mod/mod10/mitt-mod10-dry-run.mp4)
- [Full-length presentation from Ignite 2019](https://myignite.techcommunity.microsoft.com/sessions/82988?source=speakerdetail)
- [Full-length recording of presentation - Director Cut](https://youtu.be/eczGFbKcT_A)
- [Recording of this session at Microsoft Ignite 2019](https://myignite.techcommunity.microsoft.com/sessions/82988?source=sessions)
- [Demo Instructions](https://github.com/microsoft/ignite-learning-paths-training-mod/tree/master/mod10)
  

## Become a Trained Presenter

To become a trained presenter, contact [scalablecontent@microsoft.com](mailto:scalablecontent@microsoft.com). In your email please include:

- Complete name:
- The code of this presentation: mod10
- Link (ex: unlisted YouTube video) to a video of you presenting (~10 minutes). 
  > It doesn't need to be this content, the important is to show your presenter skills

A mentor will get back to you with the information on the process.

## Trained Presenters

Thanks goes to these wonderful people ([emoji key](https://allcontributors.org/docs/en/emoji-key)):

<!-- ALL-CONTRIBUTORS-LIST:START - Do not remove or modify this section -->
<!-- prettier-ignore -->

<table>
<tr>
    <td align="center"><a href="http://cloud5mins.com/">
        <img src="https://avatars1.githubusercontent.com/u/2974195?s=400&u=9ab103b405a40dfeec2302ff0fb7700685d66915&v=4/u/2404846?s=460&v=4" width="100px;" alt="Jay Gordon"/><br />
        <sub><b>Jay Gordon</b></sub></a><br />
            <a href="https://github.com/neilpeterson/ignite-tour-fy20/commits?author=jaydestro" title="talk">📢</a>
            <a href="https://github.com/neilpeterson/ignite-tour-fy20/commits?author=jaydestro" title="Documentation">📖</a> 
    </td>
    <td align="center"><a href="http://cloud5mins.com/">
        <img src="https://avatars2.githubusercontent.com/u/2404846?s=460&v=4" width="100px;" alt="Frank Boucher"/><br />
        <sub><b>Frank Boucher</b></sub></a><br />
            <a href="https://github.com/microsoft/ignite-learning-paths-training-mod/commits?author=FBoucher" title="talk">📢</a>
            <a href="https://github.com/microsoft/ignite-learning-paths-training-mod/commits?author=FBoucher" title="Documentation">📖</a> 
    </td>
</tr></table>

<!-- ALL-CONTRIBUTORS-LIST:END -->

