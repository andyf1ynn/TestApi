Assumptions:
1) The numeric input will be within the range of an int32
2) SSL Certificates and DNS Zone routing is already configured
3) Source repository will be Azure Devops Git.

Notes
1) The api is publically available on an Azure Web App running .net core 3.1. https://demo-api-esh.azurewebsites.net/test?input=63
2) Solution DataAccess Repository is in memory and for demonstration purposes, it is not covered by unit tets

Deployment
In all cases create a CI pipeline to run appropriate build, security, quality and test tasks before copying a build artifact to the correct location.
1) Azure App Service:
 a - From visual studio using cloud explorer, ensure the visual studio login matches a valid login for the Azure tenant/subscription which will host the WebApi solution. 
     Provision a web app in Azure using an appropriate arm template in the Azure Portal.
 b - Azure Devops pipeline with a Resource Group update or terraform apply task and appropriate service connectio.
 https://docs.microsoft.com/en-us/azure/devops/pipelines/tasks/deploy/azure-rm-web-app-deployment?view=azure-devops

2) Azure Kubernetes Service
 a - Provision an AKS service manually in the Azure Portal or create and run an Azure Devops pipeline with a Resource Group update or terraform apply task and appropriate service connection.
 a - Deploy docker image to a container registry (Docker or Azure container registry) using an CD pipeline, push docker image to AKS service

2) IIS On prem or cloud hosted
  a - Recommended webserver - Windows Server 2019. Create and Azure Devops CD pipeline with IIS Deploy task which deploys the appropriate build artifact.
    The CD pipeline should confiugure the website, IP and HTTPS settings. 
    https://docs.microsoft.com/en-us/azure/devops/pipelines/tasks/deploy/iis-web-app-deployment-on-machine-group?view=azure-devops

3) Linux Server
  a - Run a CD pipeline to deploy the build artifact to the appropriate web server.
    https://docs.microsoft.com/en-us/azure/devops/pipelines/apps/cd/azure/deploy-arm-template?view=azure-devops