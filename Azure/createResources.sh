#/bin/bash

# Variables
appName="DotnetToolBuilderApi"
location="Westeurope"
dockerHubContainerPath="breinerde/dotnettoolbuilder.api:latest" 

# Create a Resource Group
az group create --name DotnetToolBuilderApiResourceGroup --location $location

# Create an App Service Plan
az appservice plan create --name DotnetToolBuilderApiPlan --resource-group DotnetToolBuilderApiResourceGroup --location $location

# Create a Web App
az webapp create --name DotnetToolBuilderApi --plan DotnetToolBuilderApiPlan --resource-group DotnetToolBuilderApiResourceGroup

# Configure Web App with a Custom Docker Container from Docker Hub
az webapp config container set --docker-custom-image-name "breinerde/dotnettoolbuilder.api:latest" --name "DotnetToolBuilderApi" --resource-group DotnetToolBuilderApiResourceGroup

# Copy the result of the following command into a browser to see the web app.
echo http://$appName.azurewebsites.net