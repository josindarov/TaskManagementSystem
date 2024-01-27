# About Project

Project is sample TaskManagement system and users can add their assignments and edit.

# Requirements

To initialize this project you have to install .NET Core 7. After you clone this project you will need to install docker also. I suggest using [docker-desktop](https://www.docker.com/products/docker-desktop/) or [rancher desktop](https://docs.rancherdesktop.io/getting-started/installation/) for running docker compose on your machine.

# How to use
Spin up api and blazor client applications locally. Initial run takes time to download .NET Core SDK and Postgres docker images.

`docker-compose -f docker-compose.yml --build`

browse at : 
*api-* [http://localhost:8080/swagger](http://localhost:8080/swagger/index.html)
*blazor client application - [http://localhost:5284/](http://localhost:5284/)*

**FYI:**
*You will need to run blazor application outside of docker compose. Static web pages requires to setup web servers so for convenience, because of that you need to run the client application on your favouirite IDE or just run the following command inside `TaskManagementSystem/TaskManagementSystem.Client` folder : `dotnet run`*

# YouTube video link: [Demo video](https://youtu.be/c1DBF3q8e_I?si=-1ef5iU7iPlsiiij)

