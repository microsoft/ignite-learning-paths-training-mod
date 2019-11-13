# MOD41 - Deploying and A/B testing without risks with Deployment Slots

![Learning Path](https://img.shields.io/badge/Learning%20Path-MOD-fe5e00?logo=microsoft)  

# Train-the-Trainer Guide

## Session Abstract

Who hasn’t been very scared when deploying a new feature to a website? Sometimes we feel that we will break everything, and the stress level is just not something we want to experience ever again. That's why the Deployment Slots feature of Azure App Services is such a nice experience. With Deployment Slots, you can deploy to a safe slot in the same conditions than your production environment. You can test in isolation, without risking breaking something. Then you can gradually route some of the traffic to the new features, for example to perform A/B testing. When you are satisfied with the results, you can simply switch the whole traffic to the new site. But don't fret, if something goes wrong, the old, safe site is just one mouse click away.

## How to Use

### Welcome, Presenter!

We're glad you are here and look forward to your delivery of this amazing content. As an experienced presenter, we know you know **HOW** to present so this guide will focus on **WHAT** you need to present. It will provide you a full run-through of the presentation created by the presentation design team.

Along with the video of the presentation, this document will link to all the assets you need to successfully present including PowerPoint slides and demo instructions & code.

* Read the document in its entirety.
* Watch the video presentation
* Ask questions of the Lead Presenter

### Assets in Train-the-Trainer Kit

* This guide
* [PowerPoint presentation](./presentations.md)
* [Outline for this session](./00-outline.md).
* [A demo video made to help you learn and present](./00A-videos.md)

### Demos deployment and preparation

> Note that the deployment is essentially the same as for the MOD40 session. [You can find more information about this deployment there](../mod40/README.md).

In order to run the demos, you will need to run a deployment to Azure. [This is explained in details here](./01-preparation.md). You can run this deployment for training purpose and then delete the resource groups that you created, and deploy again. The deployment can also be run in parallel multiple times with a unique name. This is needed sometimes when multiple speakers are presenting the session in different locations at the same time.

### Running the demos

Before each session you will need to run a few steps to [prepare the demo environment](./03-prep-demo.md). After that you'll be all set, and you can find a [complete description of the demo here](./04-demo.md).

### Cleaning up

After your session, and in order to save costs, you can simple [delete the resource groups and all the resources](./05-cleaning-up.md).

### Become a Trained Presenter

To become a trained presenter, contact [scalablecontent@microsoft.com](mailto:scalablecontent@microsoft.com). In your email please include:

- Complete name:
- The code of this presentation: MOD41
- Link (ex: unlisted YouTube video) to a video of you presenting (~10 minutes). 
  > It doesn't need to be this content, the important is to show your presenter skills

A mentor will get back to you with the information on the process.

### Trained Presenters

Thanks go to these wonderful people:

<!-- ALL-CONTRIBUTORS-LIST:START - Do not remove or modify this section -->
<!-- prettier-ignore -->

<table>
<tr>
    <td align="center"><a href="">
        <img src="https://avatars0.githubusercontent.com/u/5479675?s=400&v=4" width="100px;" alt="Jeremy Likness"/><br />
        <sub><b>Jeremy Likness</b></sub></a>
        <!-- <br />
            <a href="https://github.com/neilpeterson/ignite-tour-fy20/commits?author=neilpeterson" title="talk">🎨</a>
            <a href="https://github.com/neilpeterson/ignite-tour-fy20/commits?author=neilpeterson" title="design">📖</a>  -->
    </td>
    <td align="center"><a href="">
        <img src="https://avatars1.githubusercontent.com/u/4922457?s=400&v=4" width="100px;" alt="Laurent Bugnion"/><br />
        <sub><b>Laurent Bugnion</b></sub></a>
        <!-- <br />
            <a href="https://github.com/neilpeterson/ignite-tour-fy20/commits?author=fboucher" title="talk">📢</a>
            <a href="https://github.com/neilpeterson/ignite-tour-fy20/commits?author=fboucher" title="Documentation">📖</a>  -->
    </td>
</tr></table>

<!-- ALL-CONTRIBUTORS-LIST:END -->
