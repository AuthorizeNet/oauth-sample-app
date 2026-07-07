# OAuth Sample Application

This repository contains a **sample / educational application** that demonstrates how to integrate with the Authorize.Net **OAuth 2.0 sandbox** flow from an ASP.NET MVC application. It is **not a production application**, **not a hosted service**, and **not part of the main Authorize.Net product**. It is intended for developers who want to see, build, and run an OAuth 2.0 reference integration **locally** while learning the Authorize.Net APIs.

> ### ⚠️ Scope & Intended Use
>
> - **Purpose:** Educational reference / integration showcase only.
> - **Deployment:** Designed to be cloned and run **locally** (Visual Studio + IIS Express). It is _not_ deployed to any hosted environment, and the project ships with no production URL or production endpoint.
> - **Backend target:** Authorize.Net **Sandbox only** (`https://sandbox.authorize.net`). There is no production URL anywhere in the codebase.
> - **Data:** Uses an attached `LocalDb` (`(LocalDb)\MSSQLLocalDB`) on the developer's own machine. No shared database, no production data.
> - **Credentials:** Sample / placeholder values only (e.g., `[YOUR_CLIENT_ID]`, `[YOUR_CLIENT_SECRET]`). Real credentials must be obtained by the developer from the Authorize.Net Sandbox portal and used **only locally** in `Web.config` `<appSettings>`.

## **How to Use the Sample Application?**

- Clone or download this repository.
- Open solution OAuthDemo.sln in Visual Studio and set OAuthDemo as StartUp project.
- Open `OAuthDemo/Web.config` and **replace the `[YOUR_CLIENT_ID]` and `[YOUR_CLIENT_SECRET]` placeholders** with values you obtain from the Authorize.Net Sandbox portal (see below).
- Run OAuthDemo.sln from Visual studio to launch the application. Application runs on the local IIS Express server.

![alt text](https://github.com/AuthorizeNet/oauth-sample-app/blob/master/OAuthDemo/Screenshots/Image1.png)

### Obtaining your sandbox `ClientId` and `ClientSecret`

You must use **your own** Authorize.Net **sandbox** credentials. This repository deliberately does **not** ship working credentials.

1. Sign in to the Authorize.Net sandbox: **https://sandbox.authorize.net**
2. Navigate to **Account → Settings → Security Settings → API Credentials & Keys**.
3. Generate / copy your **Client ID** and **Client Secret**.
4. Provide a **RedirectUri** (the page the merchant is redirected back to after granting permissions) when registering your application.
5. Place the values into `OAuthDemo/Web.config`:

```xml
<add key="ClientId" value="[YOUR_CLIENT_ID]" />
<add key="ClientSecret" value="[YOUR_CLIENT_SECRET]" />
```

> If you have any questions on credentialing, you can reach the Authorize.Net partner team at [affiliate@authorize.net](mailto:affiliate@authorize.net).

`OAuthDemo/Models/DemoModels.cs` reads these values via `ConfigurationManager.AppSettings["ClientId"]` / `["ClientSecret"]`. The application falls back to an empty string if the key is missing — there are no hardcoded credentials anywhere in the source tree.

```csharp
public Demo()
{
    ClientId     = ConfigurationManager.AppSettings["ClientId"]     ?? "";
    ClientSecret = ConfigurationManager.AppSettings["ClientSecret"] ?? "";
    // …
}
```

![alt text](https://github.com/AuthorizeNet/oauth-sample-app/blob/master/OAuthDemo/Screenshots/Image2.png )

- Click Continue to go to the next step to obtain OAuth code.

![alt text](https://github.com/AuthorizeNet/oauth-sample-app/blob/master/OAuthDemo/Screenshots/Image3.png )

- ClientId and RedirectUri values are used to get OAuth code.
- Check/Uncheck Read and Write boxes to specify the level of access that the application is requesting.
- State value is echoed back in the response to protect against malicious interception.
- Sub value should be oauth.

- Click Redirect to Authorize.net

![alt text](https://github.com/AuthorizeNet/oauth-sample-app/blob/master/OAuthDemo/Screenshots/Image4.png )


- Login with your Authorize.net credentials to allow access.
![alt text](https://github.com/AuthorizeNet/oauth-sample-app/blob/master/OAuthDemo/Screenshots/Image5.png )
- Click Allow. Page will be redirected to [https://developer.authorize.net](https://developer.authorize.net) with generated authorization code in the url. Copy the authorization code to obtain access and refresh token.

![alt text](https://github.com/AuthorizeNet/oauth-sample-app/blob/master/OAuthDemo/Screenshots/Image6.png )

- Go back to OAuth demo application. Click Continue. Use the authorization code obtained from previous step. Click Submit Token Request.

![alt text](https://github.com/AuthorizeNet/oauth-sample-app/blob/master/OAuthDemo/Screenshots/Image7.png )

-  Access Token and Refresh Token will be part of Response.Copy Access Token from Response. Click Continue.

![alt text](https://github.com/AuthorizeNet/oauth-sample-app/blob/master/OAuthDemo/Screenshots/Image8.png )

Sample Response-

{

  &quot;access\_token&quot;: &quot;eyJraWQiOiI5YzIwNzk0MGJiNzhkODc5MDAwMDAwMDA1NGNjY2Q2NyIsImFsZyI6IlJTMjU2In0.eyJqdGkiOiJkYmM0YzMyYS1jN2FhLTQ5ZTgtYmY3NS02NzI2Y2VjMmNjYzAiLCJzY29wZXMiOlsicmVhZCIsIndyaXRlIl0sImlhdCI6MTUyMjEwNDUwOTE4MCwiYXNzb2NpYXRlZF9pZCI6IjM4MDQiLCJjbGllbnRfaWQiOiI0ZHA1YjdnUnFrIiwibWVyY2hhbnRfaWQiOiI2NDg4NzkiLCJhZGRpdGlvbmFsSW5mbyI6IntcImFwaUxvZ2luSWRcIjpcIjJrS2h0RWQzMlQgICAgICAgICAgXCIsXCJyb3V0aW5nSWRcIjpcIiQkMmtLaHRFZDMyVCQkXCJ9IiwiZXhwaXJlc19pbiI6MTUyMjEzMzMwOTE4MCwiZ3JhbnRfdHlwZSI6ImF1dGhvcml6YXRpb25fY29kZSJ9.O90k3olrVYXj61m4\_m0OfSFvJcy7mTcl4qb6rsrsSBlt3hwcOFYgItfseKqVMLr6lTilHxtmCzwpPVwjQ7hp3UbNMTtEtp8WBj68Va\_B7Va0q1ylK7gJDqubI9tpeX16DVLHBbLxK0TSRz2xnqluwTHZng6WIQh4LDGboawYzplcNhr4wakJdlPeIrnVsRdnxIbneGV2eF52zvq9ZC1kTYXwVVMNZ-3Z8QThZsk8JW8\_eMdDcFJEU0XU9euoPOoQpIc9D9PcV\_UfZDp7m6jkrswIpfeMLLKlWnljbuzipqsYB7YtUYzhqENqpdSyL3M\_kSsDVOA321wxRzuDY6hXsA&quot;,

  &quot;token\_type&quot;: &quot;bearer&quot;,

  &quot;refresh\_token&quot;: &quot;eyJraWQiOiI5YzIwNzk0MGJiNzhkODc5MDAwMDAwMDA1NGNjY2Q2NyIsImFsZyI6IlJTMjU2In0.eyJqdGkiOiIzMDY1MDg2Yy1iYTlmLTQ1NzctYmQ0Ny1mM2E3M2JjZjYwN2UiLCJzY29wZXMiOlsicmVhZCIsIndyaXRlIl0sImlhdCI6MTUyMjEwNDUwOTE2NCwiYXNzb2NpYXRlZF9pZCI6IjM4MDQiLCJjbGllbnRfaWQiOiI0ZHA1YjdnUnFrIiwibWVyY2hhbnRfaWQiOiI2NDg4NzkiLCJhZGRpdGlvbmFsSW5mbyI6IntcImFwaUxvZ2luSWRcIjpcIjJrS2h0RWQzMlQgICAgICAgICAgXCIsXCJyb3V0aW5nSWRcIjpcIiQkMmtLaHRFZDMyVCQkXCJ9IiwiZXhwaXJlc19pbiI6MTUyMjEzMzMwOTE2NCwidG9rZW5fdHlwZSI6InJlZnJlc2hfdG9rZW4iLCJncmFudF90eXBlIjoiYXV0aG9yaXphdGlvbl9jb2RlIn0.inttrtVxgrlq-NusLxmbNNJDcLE69BtFACjwxVo1rByuWHX9pVy4FDrKy\_SB8p\_yX1TlB\_RX0EmwojYY0gGQspP5F9H2ozPJoZaQoJM5idAYIHh38oduJEHTrBLNDjqWpAf4TBNKoSJlqvi5w9\_0uun5G9r7b-MMt9cMrKaKOyDbLuJ51I7OOqUDUh3kS0RQa8BJmPRkTIRrAH\_VKbaBL3sxyz-vdBMxsc5ILbWxOKnFn\_azcTt1ORLzoBTP6BJFaTIpMdxCvruf8M\_isJhbsJKQwaUa7yu89JJ0yXbEKVSFRZhlnwn0RaTgo7foxqX-9emG1dh5SdFAfgV7gZD9YA&quot;,

  &quot;expires\_in&quot;: 28799,

  &quot;scope&quot;: &quot;read write&quot;,

  &quot;refresh\_token\_expires\_in&quot;: 28799,

  &quot;client\_status&quot;: &quot;active&quot;

}

- Use the Access Token to authenticate transactions. Test Write and Read transaction APIs using Access Token.

![alt text](https://github.com/AuthorizeNet/oauth-sample-app/blob/master/OAuthDemo/Screenshots/Image9.png )

![alt text](https://github.com/AuthorizeNet/oauth-sample-app/blob/master/OAuthDemo/Screenshots/Image10.png )

- To retrieve a new pair of tokens, use the refresh token obtained in Retrieve step.

![alt text](https://github.com/AuthorizeNet/oauth-sample-app/blob/master/OAuthDemo/Screenshots/Image11.png )

- Use the refreshed Access Token for subsequent requests.

![alt text](https://github.com/AuthorizeNet/oauth-sample-app/blob/master/OAuthDemo/Screenshots/Image12.png )

- To revoke permissions. Click Redirect to Revoke.

Refresh Token is revoked immediately. Any previously issued Access Token will be valid till they expire.

![alt text](https://github.com/AuthorizeNet/oauth-sample-app/blob/master/OAuthDemo/Screenshots/Image13.png )

- Click Revoke Permissions

![alt text](https://github.com/AuthorizeNet/oauth-sample-app/blob/master/OAuthDemo/Screenshots/Image14.png )

- Click Revoke Permissions



Note: If the OAuthDemo application is running on a network which is behind a proxy, you may have to add the settings below to the `Web.config` file of the OAuth Demo application project to access the API endpoint.

```xml
<system.net>
  <defaultProxy useDefaultCredentials="true" enabled="true">
  </defaultProxy>
</system.net>
```
