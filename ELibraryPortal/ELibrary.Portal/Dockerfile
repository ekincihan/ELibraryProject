FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ELibrary.Portal/ELibrary.Portal.csproj ELibrary.Portal/
COPY ELibrary.API/ELibrary.API.csproj ELibrary.API/
COPY ELibrary.DAL/ELibrary.DAL.csproj ELibrary.DAL/
COPY ELibrary.Entities/ELibrary.Entities.csproj ELibrary.Entities/
COPY ELibrary.Core/ELibrary.Core.csproj ELibrary.Core/
RUN dotnet restore ELibrary.Portal/ELibrary.Portal.csproj
COPY . .
WORKDIR /src/ELibrary.Portal
RUN dotnet build ELibrary.Portal.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish ELibrary.Portal.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ELibrary.Portal.dll"]
