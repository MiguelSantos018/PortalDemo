#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/Arq.PortalDemo.Migrator/Arq.PortalDemo.Migrator.csproj", "src/Arq.PortalDemo.Migrator/"]
COPY ["src/Arq.PortalDemo.EntityFrameworkCore/Arq.PortalDemo.EntityFrameworkCore.csproj", "src/Arq.PortalDemo.EntityFrameworkCore/"]
COPY ["src/Arq.PortalDemo.Core/Arq.PortalDemo.Core.csproj", "src/Arq.PortalDemo.Core/"]
COPY ["src/Arq.PortalDemo.Core.Shared/Arq.PortalDemo.Core.Shared.csproj", "src/Arq.PortalDemo.Core.Shared/"]
RUN dotnet restore "src/Arq.PortalDemo.Migrator/Arq.PortalDemo.Migrator.csproj"
COPY . .
WORKDIR "/src/src/Arq.PortalDemo.Migrator"
RUN dotnet build "Arq.PortalDemo.Migrator.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Arq.PortalDemo.Migrator.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Arq.PortalDemo.Migrator.dll", "-s"]
