# Train The Trainer - MOD30: Demo Walkthrough

*View the [Setup documentation](setup.md) to prepare for these demos.*

## Demo 1: Serverless for Elastic Scale ([Watch 📽](https://globaleventcdn.blob.core.windows.net/assets/mod/mod30/MOD30_Demo1.mp4))

1. Use the empty `mod30-demo` variant of the function
2. Create an In-portal HTTP Trigger (not the WebHook quick start, use "More templates...")
3. Mention function security types and choose anonymous
4. In another tab, open application insights (`-demo`) -> Live Metrics Stream (collapse outgoing requests and overall health)
5. Hit the endpoint either via Test or copy/paste URL in a new tab and show the live metric on Live Metrics Stream. Copy/paste method is preferred so you can capture the endpoint and use in the command line.
6. Point out the "servers" running.
7. Run `artillery quick --count 100 -n 100 {endpoint}`
8. Go back to Live Metrics Stream and show auto-scale working, response times, etc.

## Demo 2: Thumbnails with Functions ([Watch 📽](https://globaleventcdn.blob.core.windows.net/assets/mod/mod30/MOD30_Demo2.mp4))

> **Important Note**: the demo as designed will only work with files using the `.jpg` (not `.jpeg`, `.png` etc.) extension. This should be handled by the app but in case you are testing it manually, keep this in mind.

1. Show the code for `MakeThumbnailHttp`
2. Take a picture in the app and save it
3. Navigate to the `wishlist` container in the storage account
4. Show the image and copy the full URL to the clipboard
5. Navigate to the `mod30-app` function and expand, drill into `MakeThumbnailHttp`
6. Open the "test" tab and change the body to:

    `{ "blob": "{url}" }`
7.  Run and show the execution
8.  Navigate back to the `wishlist` container in the storage account and show the thumbnail

## Demo 3: Trigger Function with Event Grid Event

1. Show the code for `MakeThumbnailEventGrid`.
2. Navigate to storage and show events blade. Mention the different ways to set up subscriptions.
3. Navigate to the `mod30-app` function and expand, drill into `MakeThumbnailEventGrid`
4. Click "Add event grid subscription" and add the details of the storage account
5. Give it a name like "WishlistSubscription"
6. Topic Type is `Storage Accounts`
6. Select the `mod30demostorage` storage account
7. Filter to just the `Blob Created` event
8. Wait for subscription to confirm.
9. Expand the function logs and keep those open.
10. Upload a new image from the app and show it processed in the event grid
11. Navigate to storage and show the thumbnail.

As a bonus, you can show the "events" in storage to display the subscription and related metrics.

## Demo 4: Social Media Integration with Logic Apps

1. Navigate to the logic app and explain the steps. Point out how there is no code at all to authenticate with and/or search Twitter. It's just a simple step.
2. Do not expand the variables and reveal the token secret.
3. Open the HTTP post and show how it is possible to build URL, headers, and even payload
4. Tweet
5. Enable the logic app and run the trigger
6. Show the push notification

## Demo 5: Automatic Image Captioning with Cognitive Services

1. Navigate to the `mod30-caption` logic app
2. Open the Logic app designer
3. Walk through the various steps and explain how one step feeds into the next with variables
4. Expand the condition
5. Add a step to connect with the `UpdateDescription` function _after_ the `Describe Image Content` step.
6. Show the code for `Update Description` function.
7. Set the `blob` to the URL of the blob and `description` to the generated caption
8. Save, then **enable** the logic app in the Overview
9. Upload a new image and show the automated caption
