 # DotnetToolBuilderApi  ![Docker Pulls](https://img.shields.io/docker/pulls/breinerde/dotnettoolbuilder.api)


This is an API to create easy and clean .Net Tools using the [DotNetToolBuilder](https://renepeuser.visualstudio.com/DotNetToolBuilder).


## Azure

[![Deploy To Azure](https://raw.githubusercontent.com/Azure/azure-quickstart-templates/master/1-CONTRIBUTION-GUIDE/images/deploytoazure.svg?sanitize=true)](https://portal.azure.com/#create/Microsoft.Template/uri/https%3A%2F%2Fraw.githubusercontent.com%2FBreinerDe%2Fdotnettoolbuilder.api%2Fmain%2FAzure%2Fazuredeploy.json%3Ftoken%3DALF6BHSPCPPTZNCRL2YMP5TABWXEU)
[![Visualize](https://raw.githubusercontent.com/Azure/azure-quickstart-templates/master/1-CONTRIBUTION-GUIDE/images/visualizebutton.svg?sanitize=true)](http://armviz.io/#/?load=https%3A%2F%2Fraw.githubusercontent.com%2FBreinerDe%2Fdotnettoolbuilder.api%2Fmain%2FAzure%2Fazuredeploy.json%3Ftoken%3DALF6BHSPCPPTZNCRL2YMP5TABWXEU)



You can deploy an instance of this API to you own Azure Resources.
This tempolate will deploy the following Resources:

* App Service Plan
* Azure Web App running the dotnettoolbuilder.api container from [Dockerhub ](https://hub.docker.com/r/breinerde/dotnettoolbuilder.api)


## Docker 

```
docker pull breinerde/dotnettoolbuilder.api
```


## Prerequisites

* .Net 5
* Docker
* [DotNetToolBuilder](https://www.nuget.org/packages/DotNetTool.Builder/)





