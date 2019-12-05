# MOD30: Director's Cut Walkthrough

This section provides commentary on the entirety of the presentation, including the demos.

*View the [Setup documentation](setup.md) to prepare for the demos.*

## <a name="intro"></a>Introduction, Slides 1 - 5, less than 5 minutes

- Basic introduction with overview of what will be covered and introduction of Tailwind Traders.
- There is a resources slide, take a 10 second pause for pictures, remind audience there will be another chance to take photos later.
- Recommended to get through quickly to conserve time

##  <a name="serverless"></a> Introduction to Serverless, Slides 5 - 22, less than 7 minutes

- Walkthrough of the evolution of platforms leads to introduction of Serverless
  1. On Premise and the challenges of managing hardware
  2. IaaS and the challenges of virtualization
  3. PaaS and the challenges of managing server utilization
  4. Serverless focuses on the app
- Notice how the number of questions reduced to just one
- What is Serverless?:
    - These three points describe serverless architecture
    - "What is an abstraction of servers?"
      - Servers are still there, but they're not your responsibility. (See slide notes for more)
    - Code runs based on some event, and will automatically scale to meet high demand
    - You only pay for the time your code runs, which is cost effective!

⚠ 
- Don't spend too long on evolution, very easy to lose track of time if you have an anecdote to go with this.
- Set of transitional slides, make sure their timings match speaking

## Demo 1: Serverless for Elastic Scale, Slide 12 ([Watch 📽](https://globaleventcdn.blob.core.windows.net/assets/mod/mod30/MOD30_Demo1.mp4))

*This demo includes one of Azure's serverless services, called Azure Functions. This will walk through a basic HTTP triggered function and use the NPM module Artillery to watch autoscaling happen in real time.*

1. Use the empty `mod30-demo` variant of the function
2. Create an In-portal HTTP Trigger (not the WebHook quick start, use "More templates...")
3. Mention function security types and choose `anonymous`
  *The main difference is that Anonymous doesn't require an authorization key. Mention this is ok for demos and smaller projects like this but may not be ideal in a production environment.*
4. In another tab, open application insights (`-demo`) -> Live Metrics Stream (collapse outgoing requests and overall health)

  *This is a large page, so **highly** recommended to collapse  outgoing requests and overall health to minimize scrolling.*

5. Hit the endpoint either via Test or copy/paste URL in a new tab and show the live metric on Live Metrics Stream. Copy/paste method is preferred so you can capture the endpoint and use in the command line.
6. Point out the "servers" running.
7. Run `artillery quick --count 100 -n 100 {endpoint}`

  *TIP: Have this command ready in your command lind history, with the endpoint name you intend to choose. See example in Dry run*

8. Go back to Live Metrics Stream and show auto-scale working, response times, etc.
 *Go ahead and close this tab after demo ends to save some space.*

## <a name="servercont"></a> Intro to Serverless Cont': Azure Serverless Platform Components, Slides 13 - 18, about 2 minutes

- Walkthrough of Azure's serverless offerings
- Don't spend too long here, other services will be mentioned later

## <a name="func"></a>  Azure Functions, Slides 18-22, about 5 minutes
- Triggers and bindings are the "secret sauce", good to define here
  - Triggers: Causes function to run/code to execute.
  - Bindings: How to connect resources to functions.
  - Why is this important? No need to hardcode anything

## Demo 2: Thumbnails with Functions, Slide 23 ([Watch 📽](https://globaleventcdn.blob.core.windows.net/assets/mod/mod30/MOD30_Demo2.mp4))

*In this demo we'll use an Azure Function to create a thumbnail of an image we will upload to the mobile app's wishlist.*

> **Important Note**: the demo as designed will only work with files using the `.jpg` (not `.jpeg`, `.png` etc.) extension. This should be handled by the app but in case you are testing it manually, keep this in mind.

1. Show the code for `MakeThumbnailHttp`

  *This is written in C#. Might be good to mention that the code is already deployed, good place to mention tooling for local development, testing, and deployment with Functions.*

*Function is line 29-59:
Line 41: Checks if blob was found
Line 49: Calls `MakeThumb` (Line 197 - end) to create thumbnail*

1. Take a picture in the app and save it
2. Navigate to the `wishlist` container in the storage account

*This will be the storage account you created in [setup](./setup.md).*

*Optionally, you can use the [Storage Explorer tool](https://azure.microsoft.com/en-us/features/storage-explorer/) to do this*

3. Show the image and copy the full URL to the clipboard
4. Navigate to the `mod30-app` function and expand, drill into `MakeThumbnailHttp`
5. Open the "test" tab and change the body to:
    `{ "blob": "{url}" }`
6.  Run and show the execution
7.  Navigate back to the `wishlist` container in the storage account and show the thumbnail

*Thumbnail will have the _thumb suffix at the end of its name*

## <a name="ev"></a> Event Grid, Slides 24 - 38, about 5 minutes
- Event Grid allows you to manage all events in one place.
- What makes it so different from Event Hubs and Service Bus?
  - Service Bus is meant to deliver messages
  - Event Hubs is for events and its data (streaming data)
  - Event grid can sit in the middle between these two. Check out [this doc](https://docs.microsoft.com/en-us/azure/event-grid/compare-messaging-services) for deeper explanation.

## Demo 3: Trigger Function with Event Grid Event, Slide 38 ([Watch 📽](https://globaleventcdn.blob.core.windows.net/assets/mod/mod30/MOD30_Demo3.mp4))

*In this demo we will use Event Grid to automatically create thumbnails of uploaded images from the app.*

1. Show the code for `MakeThumbnailEventGrid`.

*Line 61-72. Mention how we will see line 66's log message later. (Step 11)*

2. Navigate to storage and show events blade. Mention the different ways to set up subscriptions.
3. Navigate to the `mod30-app` function and expand, drill into `MakeThumbnailEventGrid`
4. Click "Add event grid subscription" and add the details of the storage account.
5. Give it a name like "WishlistSubscription"
6. Select topic type `Storage Accounts`
7. Select the `mod30demostorage` storage account
8. Filter to just the `Blob Created` event
9.  Wait for subscription to confirm.
10. Expand the function logs and keep those open.
11. Upload a new image from the app and show it processed in the event grid.
12. Navigate to storage and show the thumbnail.

As a bonus, you can show the "events" in storage to display the subscription and related metrics at.

## <a href="./#la"></a>Logic Apps, Slides 40 - 45 about 5 minutes

- Main talking points are ease of integrations and large number of services to connect to. See slide notes for details.

## Demo 4: Social Media Integration with Logic Apps, Slide 45 ([Watch 📽](https://globaleventcdn.blob.core.windows.net/assets/mod/mod30/MOD30_Demo4.mp4))

*In this demo, we'll be using a logic app that will send a notification to our app when a new Tweet is posted.*

1. Navigate to the logic app and explain the steps. Point out how there is no code at all to authenticate with and/or search Twitter. It's just a simple step.

*No API keys or additional setup, you just need your Twitter username and password to set it up.*

2. Do not expand the variables and reveal the token secret.

*You can just mention that these are secret keys for creating the notification.*

3. Open the HTTP post and show how it is possible to build URL, headers, and even payload.
4. Tweet
5. Enable the logic app and run the trigger

*You can change the interval to 1 minute, if desired.*

6. Show the push notification

*Consider disabling this logic app after demo if your Tweet search criteria will return a lot of tweets.*

## <a href="cog"></a> Cognitive Services, Slides 46-49, about 5 minutes

- Main point: you don't have to know all the algorithms, statistical analysis, etc to use cognitive services. Most are as straightforward as a basic API call.

## Demo 5: Automatic Image Captioning with Cognitive Services, Slide 48 ([Watch 📽](https://globaleventcdn.blob.core.windows.net/assets/mod/mod30/MOD30_Demo5.mp4))

*In this demo, we're going to use a logic app that will automatically caption new pictures added to the app's wishlist.*

1. Navigate to the `mod30-caption` logic app
2. Open the Logic app designer
3. Walk through the various steps and explain how one step feeds into the next with variables
4. Expand the condition

*Mention that this logic makes sure we're not captioning thumbnails.*

5. Add a step to connect with the `UpdateDescription` function _after_ the `Describe Image Content` step.
6. Show the code for `Update Description` function.

*Lines 124-163. Line 145-151 identifies the blob from its url. Line 154-155 updates its description in its metadata. "This means that this function will expect a blob url and the description from Custom Vision." is a good lead in to next step.*

7. Set the `blob` to the URL of the blob and `description` to the generated caption.

```json

{
    "blob": "[url variable]",
    "description": "[description]" OR "[Captions caption text]" 
}

```

*1. Make sure to enclose both values in quotes, you may get an error if you do not.*

*2. "Captions caption text" will add a for each loop, this because custom vision can return more than one caption if doing batches of images. In this case it will always be one.*
   
8. Save, then **enable** the logic app in the Overview
9. Upload a new image and show the automated caption

## <a href="close"></a> Closing, Slides 50 - end, 5 mins
- Last chance for resources