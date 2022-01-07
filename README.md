HowTo
Open Pipelines.sln and run the application.

You have to define parameters in the Config.cs file

Following parameters has to be defined:
- Personal Access Token
- Azure Dev Ops Organization Name
- Azure DevOps Project Id (guid)

- Path To Save Variable Groups
- Path To Save Release Definitions
- Path To Save Build Definitions

This small application using Azure DevOps REST API's to get all variable groups, pipelines(builds) and releases from your 
Azure DevOps and stores it on disk in json format. It's useful because than you can keep all these json files in the source control
and run different analyses f.ex. to find variable group which is not in use anymore and so on.


To get definition of all pipelines(builds) has to use REST
```
https://dev.azure.com/{AzureDevOpsOrganizationName}/{AzureDevOpsProjectId}/_apis/build/definitions/
```
Detail of one pipeline(build)
```
https://dev.azure.com/{AzureDevOpsOrganizationName}/{AzureDevOpsProjectId}/_apis/build/definitions/2
```

To get definition of all releases has to use REST
```
https://vsrm.dev.azure.com/{AzureDevOpsOrganizationName}/{AzureDevOpsProjectId}/_apis/Release/definitions/
```
Detail of one release
```
https://vsrm.dev.azure.com/{AzureDevOpsOrganizationName}/{AzureDevOpsProjectId}/_apis/Release/definitions/1
```

Documentation REST Azure DevOps
```
https://docs.microsoft.com/en-us/rest/api/azure/devops/?view=azure-devops-rest-6.1
```
Get all variable groups
```
https://dev.azure.com/{AzureDevOpsOrganizationName}/{AzureDevOpsProjectId}/_apis/distributedtask/variablegroups
```
Get one variable group
```
https://dev.azure.com/{AzureDevOpsOrganizationName}/{AzureDevOpsProjectId}/_apis/distributedtask/variablegroups/1
```

 Add new variable to the variable group
f.ex. add variable name Environment with value PRE, remember to find the group id in the json file 

 ```
az pipelines variable-group variable create --group-id 11 --name Environment --value Production       
 ```
 
Get definitions for all releases, doesn't include variable group names

 ```
 az pipelines release list --project ProjectName >>.\AllReleases.json
 ```

 Get the details of a release.
```
az pipelines release show --project ProjectName --id 6
```