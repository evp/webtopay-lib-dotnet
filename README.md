#WebToPay Lib DotNet

##What is WebToPay Lib DotNet?
WebToPay Lib DotNet is a library that will allow you to make payment requests to the Paysera website.

##Sections
* [Requirements](#requirements)
* [Directory structure](#directory-structure)
* [Installation](#installation)
* [Code samples](#code-samples)
* [Contact Us](#contacts)

##Requirements
* .NET Framework 3.5

##Directory structure
The project directory is divided into three parts
* bin/ - a compiled library DLL file
* example/ - a ready to use example
* src/ - the source of the library


##Installation
* Use `git clone https://github.com/evp/webtopay-lib-dotnet.git` to obtain the newest version of the library.
* Copy the EVP.WebToPay.ClientAPI.dll located in the bin directory to your project folder.
* Add a reference to the API DLL + Add a using EVP.WebToPay.ClientAPI statement anywhere you wish to use the library.

You have successfully installed the WebToPay Lib DotNet library!


##Code samples
Before making a request you are to create an instance of the Client class.
```c#
int projectId = 0;
string signPassword = "32_character_sign_password";
Client client = new Client(projectId, signPassword);
```
Be sure to replace *projectId* and *signPassword* placeholder values with the actual data.

After creating the client object you can now create a new Micro/Macro request
```c#
public MacroRequest NewMacroRequest();
public MicroAnswer NewMicroAnswer();
```

After creating a new request, it is important that you specify the request parameters
```c#
string siteUrl = Request.Url.GetLeftPart(UriPartial.Authority);

request.OrderId = "ORDER0001";
request.Amount = 1000;
request.Currency = "EUR";
request.Country = "LT";
request.AcceptUrl = siteUrl + "/Accept.aspx";
request.CancelUrl = siteUrl + "/Cancel.aspx";
request.CallbackUrl = siteUrl + "/MacroCallback.aspx";
```

You can additionally set the ```request.Test = true;``` if you wish to test the request.

Once the request has been built, you may build the request URL and redirect your client
```c#
string redirectUrl = client.BuildRequestUrl(request);
Response.Redirect(redirectUrl);
```

##Contacts
If you have any further questions feel free to contact us:

"Paysera LT", UAB    
Pilaitės pr. 16  
LT-04352 Vilnius    
Email: support@paysera.com    
Tel. +370 5 207 1558 
