FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["TaskManagementSystem.Client/TaskManagementSystem.Client.csproj", "TaskManagementSystem.Client/"]
RUN dotnet restore "TaskManagementSystem.Client/TaskManagementSystem.Client.csproj"
COPY . .
WORKDIR "/src/TaskManagementSystem.Client"
RUN dotnet build "TaskManagementSystem.Client.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "TaskManagementSystem.Client.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TaskManagementSystem.Client.dll"]
