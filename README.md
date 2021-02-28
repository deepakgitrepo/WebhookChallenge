### GitHub API Challenge
GitHub has a powerful API that enables developers to easily access GitHub data. Companies often ask us to craft solutions to their specific problems. A common request we receive is for branches to be automatically protected upon creation.
Please create a simple web service that listens for organization events to know when a repository has been created. When the repository is created please automate the protection of the master branch. Notify yourself with an @mention in an issue within the repository that outlines the protections that were added.

### [About webhooks](https://docs.github.com/en/developers/webhooks-and-events/webhooks)

Webhooks allow you to build or set up integrations, such as GitHub Apps or OAuth Apps, which subscribe to certain events on GitHub.com. When one of those events is triggered, we'll send a HTTP POST payload to the webhook's configured URL. Webhooks can be used to update an external issue tracker, trigger CI builds, update a backup mirror, or even deploy to your production server. You're only limited by your imagination.

[Microsoft ASP.NET WebHooks](https://docs.microsoft.com/en-us/aspnet/webhooks/) makes it easier to both send and receive WebHooks as part of your ASP.NET application:

On the receiving side, it provides a common model for receiving and processing WebHooks from any number of WebHook providers. It comes out of the box with support for Dropbox, GitHub, Bitbucket, MailChimp, PayPal, Pusher, Salesforce, Slack, Stripe, Trello,WordPress and Zendesk but it is easy to add support for more.

On the sending side it provides support for managing and storing subscriptions as well as for sending event notifications to the right set of subscribers. This allows you to define your own set of events that subscribers can subscribe to and notify them when things happens.

The two parts can be used together or apart depending on your scenario. If you only need to receive WebHooks from other services then you can use just the receiver part; if you only want to expose WebHooks for others to consume, then you can do just that.


**Note: This project is not yet complete, however, I've tried to showcase the flow here for receiving of the webhook event and after that creating a branch protection, issue and comment in that. For now, I hard coded the API calls in this, but definitely in future I will complete this project to automate the whole process of receiving the payload, extracting that to get the repo name, issue ID to add the comment and other factors.**

For this project, I haver performed below tasks:

    a) Created a organization in GitHub with GitHub account
    b) For the web service, I've used web hook project in .NET which is published to Azure webapp.
    c) Then in the project added [GitHub Nuget packages](https://www.nuget.org/packages/Microsoft.AspNet.WebHooks.Receivers.GitHub/) which provided great flexibility in webhook event handles and callbacks.
    d) Register the Github webhook event in App_start folder of the project.
    e) After this added webhook handler in the project in which to create a branch protection, issue creation in the repo and adding issue comment is written.
    f) Once this is done, we have to build the project and publish it again to Azure web app.
    g) For debugging purpose, I've used application insight which provides good amount of details on call backs, errors, events.

Below are some of the references:
https://docs.microsoft.com/en-us/aspnet/webhooks/
https://www.dotnetcurry.com/aspnet/1245/aspnet-webhooks-receive-webhooks-from-github
