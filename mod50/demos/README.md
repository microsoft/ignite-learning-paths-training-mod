# Technical Demonstrations

| [README](/mod50/README.md) | [Slides](/mod50/slides/README.md) | [Demos](/mod50/demos/README.md) | [Deployment](/mod50/deployment/README.md) | 
|--------|-------|------------|-----------|


## Pre-delivery Preparation

Before delivering the technical demonstrations, you will want to prepare a few things to save time and to create a demonstration audience members can follow.

Be sure to address each item on the presenter setup checklist below.

>**Presenter Setup Checklist:**

- [ ] Follow the steps for [Deployment](/mod50/deployment/README.md) and verify that everything is working
- [ ] In VS Code, open Source\Tailwind.Traders.Web\ClientApp\src\assets\locales\translation.json
- [ ] Ensure that [provided-azure-pipelines.yml](https://github.com/bbenz/TailwindTraders-Website/blob/master/provided-azure-pipelines.yml) is in your  local repo.
- [ ] Open the [GitHub Marketplace](https://github.com/marketplace) and search for 'Azure Pipelines' 
- [ ] Click Configure access then the configure button
- [ ] Copy your GitHub password into the clipboard so you don;t have to retrieve/show it live
- [ ] Test-add the TailwindTraders-Website as the repo to work with so you are pre-authenticated
- [ ] Bookmark/Open links: 
     - [ ] Portal 
     - [ ] Azure DevOps Project 
     - [ ] Staging in portal
     - [ ] Production in portal
     - [ ] Canary slot in portal
     - [ ] URL for Production 
     - [ ] URL for the Canary Deployment Slot 
     - [ ] [GitHub Actions latest Blog](https://github.blog/2019-08-08-github-actions-now-supports-ci-cd/)
     - [ ] [VS Code in GitHub: Pull Requests](https://github.com/Microsoft/vscode/pulls)
     - [ ] [VSCode's published builds](https://dev.azure.com/vscode/VSCode/_build?definitionId=1)
     - [ ] [Jenkins building Jenkins on Azure](https://ci.jenkins.io/)


## Demo Timing

There are five (5) separate demos, four (4) together, then one (1) 2 minute Audience participation as a follow-up to the main demo.

| Section / Demo | Minutes | Slides | Video
|----------|----------|-------|-----|
|[1 - Reviewing the tailwindtraders app](https://youtu.be/Ma9NulalaKk?t=1070)|2 | *3 - 11* | [Link](https://youtu.be/Ma9NulalaKk?t=1070)
|[2 - Changing the tailwindtraders shipping cost](https://youtu.be/Ma9NulalaKk?t=1193)|2 | *3 - 11* | [Link](https://youtu.be/Ma9NulalaKk?t=1193)
|[3 - Connecting the GitHub Repo and Azure DevOps](https://youtu.be/Ma9NulalaKk?t=1302)|6 | *12 - 24* |[Link](https://youtu.be/Ma9NulalaKk?t=1302)
|[4 - Creating an Azure DevOps Release Pipeline](https://youtu.be/Ma9NulalaKk?t=1562)|8 | *25-27* |[Link](https://youtu.be/Ma9NulalaKk?t=1562)
|[5 -  Audience Participation of A/B Testing](https://youtu.be/Ma9NulalaKk?t=2496) | 2 | *28-31* |[Link](https://youtu.be/Ma9NulalaKk?t=2496)
| Total       |20 | |


### [Demo 1: Reviewing the tailwindtraders app and the current shipping cost](https://youtu.be/Ma9NulalaKk?t=1070)

**What are we trying to demonstrate?**

This is the first on-stage technical demonstration for the presentation.  
We want to quickly review the Tailwind Traders app and highlight the shipping cost, which is set to $100.

This demo uses the following:

- TailWind traders app in a browser.

---

### [Demo 2: Changing the tailwindtraders shipping code in VS Code](https://youtu.be/Ma9NulalaKk?t=1193d)

**What are we trying to demonstrate?**

How to change the TailWind Traders shipping cost from $100 to $250.

This demo uses the following:

- GitHub
- Visual Studio Code

---

### [Demo 3: Connecting the GitHub Repo and Azure DevOps Build Pipelines](https://youtu.be/Ma9NulalaKk?t=1302)

**What are we trying to demonstrate?**

How to connect the TailWind Traders frontend repo to Azure DevOps Build Pipelines via GitHub Extensions.

This demo uses the following:

- GitHub
- The Azure Piplelines Extension in GitHub Marketplace
- Azure DevOps Build Pipelines

---

### [Demo 4: Creating an Azure DevOps Release Pipeline](https://youtu.be/Ma9NulalaKk?t=1562)

**What are we trying to demonstrate?**

How to create an Azure DevOps Release Pipeline to connect a successful Azure DevOps Build Pipeline to Staging and Production Azure Web Apps, including A/B Testing in deployment slots.

This demo uses the following:

- GitHub
- Azure DevOps Release Pipelines

### [Demo 5: Audience Participation of A/B Testing with Deployment Slots](https://youtu.be/Ma9NulalaKk?t=2496)

**What are we trying to demonstrate?**

The Audience should follow the link and QR Code in slide 32.  Collect a show of hands on who sees the new site with the $250 shipping threshold and who sees the old site with the $100 Shipping threshold (should be about 50/50).

This demo uses the following:

- GitHub
- Azure DevOps Release Pipelines

