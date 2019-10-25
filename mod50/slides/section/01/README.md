# Section 1: Intro & Foundations of Incident Response

| [README](/ops20/README.md) | [Slides](/ops20/slides/README.md) | [Demos](/ops20/demos/README.md) | [Deployment](/ops20/deployment/README.md) | 
|--------|-------|------------|-----------|

| [Transcript](../../script/OPS20_Speaking_Script.md) | [Video](https://globaleventcdn.blob.core.windows.net/assets/ops/ops20/video/02_Presentation_Section_One.mp4) | [Powerpoint](https://globaleventcdn.blob.core.windows.net/assets/ops/ops20/slides/OPS20_Responding_to_Incidents_Oct3.pptx) | [Tools](/ops20/tools/README.md) |
|------------|-------|------------|-------|

|   | Duration | Video |
|----------|----------|-------|
|**1 - Intro & Foundations of Incident Response**|16 minutes |[Link](https://globaleventcdn.blob.core.windows.net/assets/ops/ops20/video/02_Presentation_Section_One.mp4)
| [2 - Remediation Improvements (Context & Guidance)](../../section/02/README.md)|6 minutes  |[Link](https://globaleventcdn.blob.core.windows.net/assets/ops/ops20/video/02_Presentation_Section_Two.mp4)
| [3 - Tools to Reduce the Time To Recover ](../../section/03/README.md)|1 minute   |[Link](https://globaleventcdn.blob.core.windows.net/assets/ops/ops20/video/02_Presentation_Section_Three.mp4)
|[4 - Summary & Closing](../../section/04/README.md)|2 minutes  |[Link](https://globaleventcdn.blob.core.windows.net/assets/ops/ops20/video/02_Presentation_Section_Four.mp4)
|Total       |25 minutes|[Link](https://coming.soon) 



## Slides:

*Slides 1 - 46*

Estimated time: 16 minutes




## Key Section 1 Takeaways:

We want to make the audience aware of core principles of incident management:

- Rosters (teams)
- Roles
- Rotations

## Rosters

Rosters are discussed on slide 24 & 25.

Rosters are made up of multiple engineers.

Rosters can also contain multiple rotations.

## Roles

Roles are discussed on slides 26 - 31

The specific roles presented are:

- First Responder
- Secondary Responder
- Subject Matter Experts
- Incident Commander
- Scribe
- Communications Coordinator

### **Primary Responder**

The first role we need to talk about is the “Primary Responder” – the Primary “On-call” engineer.

### **Secondary Responder**

Then we have the secondary responder – who is there as back up -

Another engineer who can step in if  the primary responder is unavailable or unreachable

### **Subject Matter Experts**

It’s very common within on-call rosters to identify subject matter experts, so that early responders know who to escalate to quickly.

These people shouldn't be on call all the time, of course, but we do want to be able to identify who is our database expert. 

Who is our front-end expert?

Who are the people that we can reach out to if our primary and secondary responders aren't able to diagnose and resolve the issue themselves.

### **Incident Commander**

Another important role to identify, in many cases, is the incident commander.

An incident commander can be very helpful when you've got a large-scale outage that effects a
lot of different components or requires coordination across many teams and different systems.

An incident commander will be that person who coordinates a lot of the conversation and the effort regarding the response and remediation activities.

An incident commander is great for making sure that engineers stay focused and they're working on their own remediation efforts.

People aren’t stepping on each other or undoing each others work. 

It's good to have a central person who can keep tabs on what's going on and who's doing what.

### **Scribe**

That takes us to our next role – the scribe

The scribe’s role is to document the conversation in as much detail as possible.

Teams commonly use phone bridges, conference calls, or video chat to get everyone together and try to understand what's
going on, which can certainly help create space for the conversation.

However, it is difficult for us to go through and understand in detail what the engineers were saying and doing unless it is transcribed.

As a result, a scribe is that person who can help us document as much as possible to review later.

What were people saying, doing, feeling, and even experiencing? 

It’s all data to be analyzed – but only if we capture it.

### **Communication Coordinator**

The last role I want to touch on is the Communication Coordinator.

The Communication Coordinator is meant to be the person working in conjunction with the incident commander to share more
information beyond those who are in the firefight actively working to recover from the incident itself.

That could be customers. It could be the sales and marketing teams. Maybe your customer support.

There are many people within an organization who need to be made aware of what’s taking place and the status around how things are progressing.

It's always good to put someone in charge of managing that communication and making sure that other stakeholders are aware of what's happening and what’s being done.

## Rotations

Slides 32 - 33

A rotation is a scheduled shift.

Engineers takes the “on-call” responsibility for their own specific recurring rotation.

### **Types**

There are many different types of shifts that you can create – some more common than others.

**24 x 7** is a rotation where engineers will be “on-call” for several days in a row. However, most “Elite/High performers" would agree that rotations longer than 3 or 4 days is detrimental to the overall health of engineering staff and therefore the entire system.

**Follow the sun** shifts are nice for distributed teams. These allow for engineers to schedule their “on-call” shifts only during their normal working office hours. As they end their day and go home, engineers in a different time zone can take over.

And of course there are many ways to **customize** shifts, especially for weekends when engineers need more flexibility. Engineers should be able to easily hand off the role to someone when non-work-related conflicts arise.
