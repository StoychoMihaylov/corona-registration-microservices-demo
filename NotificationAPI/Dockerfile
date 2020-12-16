FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
LABEL maintainer="Tributech team"
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["NotificationAPI.App/NotificationAPI.App.csproj", "NotificationAPI.App/"]
RUN dotnet restore "NotificationAPI.App/NotificationAPI.App.csproj"
COPY . .
WORKDIR "/src/NotificationAPI.App"
RUN dotnet build "NotificationAPI.App.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NotificationAPI.App.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NotificationAPI.App.dll"]