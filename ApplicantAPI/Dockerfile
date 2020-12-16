FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
LABEL maintainer="Tributech team"
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["ApplicantAPI.App/ApplicantAPI.App.csproj", "ApplicantAPI.App/"]
RUN dotnet restore "ApplicantAPI.App/ApplicantAPI.App.csproj"
COPY . .
WORKDIR "/src/ApplicantAPI.App"
RUN dotnet build "ApplicantAPI.App.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ApplicantAPI.App.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ApplicantAPI.App.dll"]