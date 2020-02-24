# MOD30: Demo Walkthrough

*View the [Setup documentation](setup.md) to prepare for these demos.*

## Demo 1: Serverless for Elastic Scale ([Watch 📽](https://globaleventcdn.blob.core.windows.net/assets/mod/mod30/MOD30_Demo1.mp4))

1. Use the empty `mod30-demo` variant of the Function App
2. Create an In-portal HTTP Trigger (not the WebHook quick start, use "More templates...")
3. Mention Function App security types and choose anonymous
4. In another tab, open Application Insights (`-demo`) and show Live Metrics Stream (collapse Outgoing Requests and Overall Health)
5. Hit the HTTP Trigger endpoint either via Test or copy/paste URL in a new tab and show the live metric on Live Metrics Stream. Copy/paste method is preferred so you can capture the HTTP endpoint and use in the command line.
6. Point out the "servers" running.
7. Run `artillery quick --count 100 -n 100 {endpoint}`
8. Go back to Live Metrics Stream and show auto-scale working, response times, etc.

## Demo 2: Thumbnails with Functions ([Watch 📽](https://globaleventcdn.blob.core.windows.net/assets/mod/mod30/MOD30_Demo2.mp4))

> **Important Note**: the demo as designed will only work with files using the `.jpg` (not `.jpeg`, `.png` etc.) extension. This should be handled by the app but in case you are testing it manually, keep this in mind.

1. Show the code for `MakeThumbnailHttp` Azure Function
2. Take a picture in the Mobile App (or upload using Storage Explorer)
3. Navigate to the `wishlist` Container in the Storage Account
4. Show the image and copy the full URL to the clipboard
5. Navigate to the `mod30-app` Function App and open the `MakeThumbnailHttp` Function
6. Open the "Test" tab (on the right of the screen) and change the body (replace `url` with the blob's URL in the clipboard):

    `{ "blob": "url" }`
7.  Run and show the execution
8.  Navigate back to the `wishlist` Container in the Storage Account and show the thumbnail

## Demo 3: Trigger Function with Event Grid Event ([Watch 📽](https://globaleventcdn.blob.core.windows.net/assets/mod/mod30/MOD30_Demo3.mp4))

1. Show the code for `MakeThumbnailEventGrid` Azure Function
2. Navigate to the Storage Account and show Events blade. Mention the different ways to set up Subscriptions
3. Navigate to the `mod30-app` Azure Function open the `MakeThumbnailEventGrid` Function
4. Click "Add event grid subscription" and add the details of the Storage Account
5. Give it a name like "WishlistSubscription"
6. Topic Type is `Storage Accounts`
6. Select the `mod30demostorage` storage account
7. Filter to just the `Blob Created` event
8. Wait for Subscription to confirm.
9. Expand the Azure Function Logs pane (bottom of screen) and keep it open.
10. Upload a new image from the Mobile App (or upload using Storage Explorer) and show it processed in the Event Grid
11. Navigate to Storage Account and show the thumbnail.

As a bonus, you can show the "events" in storage to display the subscription and related metrics.

## Demo 4: Social Media Integration with Logic Apps ([Watch 📽](https://globaleventcdn.blob.core.windows.net/assets/mod/mod30/MOD30_Demo4.mp4))

1. Navigate to the logic app and explain the steps. Point out how there is no code at all to authenticate with and/or search Twitter. It's just a simple step.
2. Do not expand the variables and reveal the token secret.
3. Open the HTTP post and show how it is possible to build URL, headers, and even payload
4. Tweet
5. Enable the logic app and run the trigger
6. Show the push notification

## Demo 5: Automatic Image Captioning with Cognitive Services ([Watch 📽](https://globaleventcdn.blob.core.windows.net/assets/mod/mod30/MOD30_Demo5.mp4))

1. Navigate to the `mod30-caption` Logic App
2. Open the Logic App in the Designer
3. Walk through the various steps and explain how one step feeds into the next with variables
4. Expand the condition
5. Add a step to connect with the `UpdateDescription` Azure Function _after_ the `Describe Image Content` step:
   1. Click 'Add an action'
   2. Search for 'Azure Functions' and click on the 'Azure Functions' result that shows
   3. Select the `mod30-app` Azure Function and wait for Actions to be populated
   4. Select `UpdateDescription'
6. Show the code for `UpdateDescription` Azure Function
7. Set the `blob` to the URL (Parse JSON > url) of the blob and `description` (Describe Image Content > Captions Caption Text) to the generated caption (replace [] in below snippet with Logic App Dynamic content)
```json

{
    "blob": "[url]",
    "description": "[Captions Caption Text]" 
}

```
8. The Logic App Designer wil automatically insert a `For each` Action
8. Save, then **enable** the Logic App in the Overview blade in the Portal
9. Upload a new image and show the automated caption using Storage Explorer.
