# IO.Swagger.Api.RetrievingrefreshingApi

All URIs are relative to *http://access.authorize.net/oauth/v1*

Method | HTTP request | Description
------------- | ------------- | -------------
[**GetToken**](RetrievingrefreshingApi.md#gettoken) | **POST** /token | 


<a name="gettoken"></a>
# **GetToken**
> InlineResponse200 GetToken (string grantType = null, string code = null, string clientId = null, string clientSecret = null, string refreshToken = null)



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
            
            var apiInstance = new RetrievingrefreshingApi();
            var grantType = grantType_example;  // string |  (optional) 
            var code = code_example;  // string |  (optional) 
            var clientId = clientId_example;  // string |  (optional) 
            var clientSecret = clientSecret_example;  // string |  (optional) 
            var refreshToken = refreshToken_example;  // string |  (optional) 

            try
            {
                InlineResponse200 result = apiInstance.GetToken(grantType, code, clientId, clientSecret, refreshToken);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling RetrievingrefreshingApi.GetToken: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **grantType** | **string**|  | [optional] 
 **code** | **string**|  | [optional] 
 **clientId** | **string**|  | [optional] 
 **clientSecret** | **string**|  | [optional] 
 **refreshToken** | **string**|  | [optional] 

### Return type

[**InlineResponse200**](InlineResponse200.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

