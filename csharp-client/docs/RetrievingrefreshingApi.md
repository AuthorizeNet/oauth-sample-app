# IO.Swagger.Api.RetrievingRefreshingApi

All URIs are relative to *https://accesstest.authorize.net/oauth/v1*

Method | HTTP request | Description
------------- | ------------- | -------------
[**GetToken**](RetrievingRefreshingApi.md#gettoken) | **POST** /token | 


<a name="gettoken"></a>
# **GetToken**
> InlineResponse200 GetToken (string grantType, string clientId, string code = null, string clientSecret = null, string refreshToken = null, int? platform = null)



Use the authorization code that you obtained in step 2 to retrieve an access token, which expires after one hour, and a refresh token, which expires after one year, from our /token RESTful endpoint.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class GetTokenExample
    {
        public void main()
        {
            var apiInstance = new RetrievingRefreshingApi();
            var grantType = grantType_example;  // string | 
            var clientId = clientId_example;  // string | 
            var code = code_example;  // string |  (optional) 
            var clientSecret = clientSecret_example;  // string |  (optional) 
            var refreshToken = refreshToken_example;  // string |  (optional) 
            var platform = 56;  // int? |  (optional) 

            try
            {
                InlineResponse200 result = apiInstance.GetToken(grantType, clientId, code, clientSecret, refreshToken, platform);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling RetrievingRefreshingApi.GetToken: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **grantType** | **string**|  | 
 **clientId** | **string**|  | 
 **code** | **string**|  | [optional] 
 **clientSecret** | **string**|  | [optional] 
 **refreshToken** | **string**|  | [optional] 
 **platform** | **int?**|  | [optional] 

### Return type

[**InlineResponse200**](InlineResponse200.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/x-www-form-urlencoded
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

