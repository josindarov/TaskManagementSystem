FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["TaskManagementSystem.API/TaskManagementSystem.API.csproj", "TaskManagementSystem.API/"]
COPY ["TaskManagementSystem.Infrastructure/TaskManagementSystem.Infrastructure.csproj", "TaskManagementSystem.Infrastructure/"]
COPY ["TaskManagementSystem.Application/TaskManagementSystem.Application.csproj", "TaskManagementSystem.Application/"]
COPY ["TaskManagementSystem.Domain/TaskManagementSystem.Domain.csproj", "TaskManagementSystem.Domain/"]
RUN dotnet restore "TaskManagementSystem.API/TaskManagementSystem.API.csproj"
COPY . .
WORKDIR "/src/TaskManagementSystem.API"
RUN dotnet build "TaskManagementSystem.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "TaskManagementSystem.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TaskManagementSystem.API.dll"]
