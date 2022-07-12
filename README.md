# Introduction 

This project demonstrates simple access to table storage, with unit test using a ProjectRepositoryFake to simulate access to the table storage. 

This project is setup based on the same structure as AzureDeploymentTemplate. Deployment can easily be setup using the AzureDeploymentTemplate project. See: [AzureDeploymentTemplate](https://github.com/12c-dk/AzureDeploymentTemplate)

## Debugging

Debugging locally can be done using Azurite. If using Visual studio 2022, Azurite can be started by navigating to the following path and executing Azurite.exe. 

```
C:\Program Files\Microsoft Visual Studio\2022\Professional\Common7\IDE\Extensions\Microsoft\Azure Storage Emulator
```

See Microsoft documentation for further details: 

[Use the Azurite emulator for local Azure Storage development](https://docs.microsoft.com/en-us/azure/storage/common/storage-use-azurite?tabs=visual-studio)

**Sample request for GetProject:**

Make GET call to: http://localhost:7071/api/GetProject

```json
{
	"ProjectId":"A01"
}
```

Expected response:
```json
{
	"name": "Sampleproject",
	"title": "Sample title",
	"partitionKey": "project",
	"rowKey": "A01",
	"timestamp": "2022-07-09T22:32:16.526+02:00",
	"eTag": "W/\"datetime'2022-07-09T20%3A32%3A16.5260000Z'\""
}
```

## Pull request checklist

- Check that unit tests succeed
- Test that F5 debug works
- Test that testing.http sample requests return OK responses while function app runs locally [Testing http](src\AzureFunctions.Api.Tests\testing.http)
- Check for ToDo tasks to be solved. 
- Go through Resharper suggestions

## Todo

