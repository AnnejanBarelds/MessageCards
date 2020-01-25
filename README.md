# MessageCards
Just a small library to help create MessageCards (useful for use with Microsoft Teams web connectors because they don't support Adaptive Cards).

## Features
The current (initial) version 0.9.8 contains a near-complete model to help .NET devs create actionable messages that conform to the legacy [MessageCards specification](https://docs.microsoft.com/en-us/outlook/actionable-messages/message-card-reference). It's intended for use with Microsoft Teams webhooks, because webhooks still don't support the new Adaptive Cards format (and may never do).

The use case that led to this library is the requirement to post monitoring alerts and such to Teams to Teams using C#.

Possible missing elements (such as InvokeAddInCommand or Image) are missing because they're not required in this use case. On the plus side, this use case also had led us to include features such as building a deep URL to an Azure Log Analytics blade with a user-specified query. Support for Kibana may be added in the future as well.

So think of this library not so much as a way to facilitate an ancient way to create actionable cards, but as a way to post rich monitoring and alerting events to Microsoft Teams.
