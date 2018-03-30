# OAuth Sample Application

This repository contains a sample application which demonstrates connecting to Authorize.Net using the OAuth 2.0 authentication standard.

## **How to Use the Sample Application?**

- Clone or download this repository.
- Open solution OAuthDemo.sln in Visual Studio and set OAuthDemo as StartUp project
- Run OAuthDemo.sln from Visual studio to launch the application. Application runs on local IIS server.

![alt text](https://github.com/AuthorizeNet/oauth-sample-app/blob/master/OAuthDemo/Screenshots/Image1.png )

- ClientId and ClientSecret values can be obtained by contacting Authorize.Net support team at [affiliate@authorize.net](mailto:affiliate@authorize.net) and providing a RedirectUri(This is the page that the merchant is redirected back to after granting permissions) for your application.

Sample ClientId and ClientSecret shown in the below screen can be used for the demo purpose and can later be replaced in the code with newly obtained ClientId and ClientSecret.

File - DemoModel.cs

public Demo()

        {

            ClientId = &quot;4dp5b7gRqk&quot;;

            ClientSecret = &quot;fa3a5b16753d09b24bb44243605a4a98&quot;;

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
 ![alt text](screenshots/filename.png "Description goes here")
- Click Allow. Page will be redirected to [https://developer.authorize.net](https://developer.authorize.net) with generated authorization code in the url. Copy the authorization code to obtain access and refresh token.

![alt text](https://github.com/AuthorizeNet/oauth-sample-app/blob/master/OAuthDemo/Screenshots/Image5.png )

- Go back to OAuth demo application. Click Continue. Use the authorization code obtained from previous step. Click Submit Token Request.

![alt text](https://github.com/AuthorizeNet/oauth-sample-app/blob/master/OAuthDemo/Screenshots/Image6.png )

-  Access Token and Refresh Token will be part of Response.Copy Access Token from Response. Click Continue.

![alt text](https://github.com/AuthorizeNet/oauth-sample-app/blob/master/OAuthDemo/Screenshots/Image7.png )

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

![alt text](https://github.com/AuthorizeNet/oauth-sample-app/blob/master/OAuthDemo/Screenshots/Image8.png )

![alt text](https://github.com/AuthorizeNet/oauth-sample-app/blob/master/OAuthDemo/Screenshots/Image9.png )

- To retrieve a new pair of tokens, use the refresh token obtained in Retrieve step.

![alt text](https://github.com/AuthorizeNet/oauth-sample-app/blob/master/OAuthDemo/Screenshots/Image10.png )

- Use the refreshed Access Token for subsequent requests.

![alt text](https://github.com/AuthorizeNet/oauth-sample-app/blob/master/OAuthDemo/Screenshots/Image11.png )

- To revoke permissions. Click Redirect to Revoke.

Refresh Token is revoked immediately. Any previously issued Access Token will be valid till they expire.

![alt text](https://github.com/AuthorizeNet/oauth-sample-app/blob/master/OAuthDemo/Screenshots/Image12.png )

- Click Revoke Permissions

![alt text](https://github.com/AuthorizeNet/oauth-sample-app/blob/master/OAuthDemo/Screenshots/Image13.png )

- Click Revoke Permissions



Note: If the OAuthDemo application is running on a network which is behind a proxy, you may have to add below settings in the  web.config file of the OAuth Demo application project to access the API endpoint.

&lt;system.net&gt;

                    &lt;defaultProxyuseDefaultCredentials=&quot;true&quot;enabled=&quot;true&quot;&gt;

                    &lt;/defaultProxy&gt;

&lt;/system.net&gt;
