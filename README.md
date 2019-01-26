# To Run The Application
This application can be run either not logged in or logged in. There are two users stored in the system (see below). 

Username: John Doe
Password: Secrets123$

Username: Admin
Password: Secrets123$

You will see additional admin navigation buttons if you are logged in as 'Admin'.

## Build and Restore

This application is built using DotNetCore 2.2, and Visual Studio 2017.  To build and run this application from the command line, please run the following:

```
dotnet restore
```
```
dotnet build
```
```
dotnet ef database update
```
```
dotnet run
```

## SendGrid Configuration
This application requires that a SendGrid API key be set before it can be run.  You'll need to provision an API key from your SendGrid account prior to setting this.  Enter the API key in place of the {YOUR KEY VALUE HERE} placeholder in the command below:

```
dotnet user-secrets set "SendGrid:Key" "{YOUR KEY VALUE HERE}"
```

## Braintree Configuration
This application requires that a Braintree API key be set before it can be run.  You'll need to provision an API key from your Braintree account prior to setting this.  Enter the appropriate values below:

```
dotnet user-secrets set "Braintree:Environment" "sandbox"
dotnet user-secrets set "Braintree:MerchantId" "st8...."
dotnet user-secrets set "Braintree:PublicKey" "8os8...."
dotnet user-secrets set "Braintree:PrivateKey" "gd5b5....."
```

## SmartyStreets Configuration
This application requires that a SmartySteets Token and ID be set before it can be run.  You'll need to provision an API Key from your SmartyStreets account prior to setting this.  Enter the appropriate values below:


```
dotnet user-secrets set "SmartyStreets:AuthId" "a47..."
dotnet user-secrets set "SmartyStreets:AuthToken" "g76a..."
```