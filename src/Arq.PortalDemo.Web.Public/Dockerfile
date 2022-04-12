#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/Arq.PortalDemo.Web.Public/Arq.PortalDemo.Web.Public.csproj", "src/Arq.PortalDemo.Web.Public/"]
COPY ["src/Arq.PortalDemo.Web.Core/Arq.PortalDemo.Web.Core.csproj", "src/Arq.PortalDemo.Web.Core/"]
COPY ["src/Arq.PortalDemo.Application/Arq.PortalDemo.Application.csproj", "src/Arq.PortalDemo.Application/"]
COPY ["src/Arq.PortalDemo.Application.Shared/Arq.PortalDemo.Application.Shared.csproj", "src/Arq.PortalDemo.Application.Shared/"]
COPY ["src/Arq.PortalDemo.Core.Shared/Arq.PortalDemo.Core.Shared.csproj", "src/Arq.PortalDemo.Core.Shared/"]
COPY ["src/Arq.PortalDemo.Core/Arq.PortalDemo.Core.csproj", "src/Arq.PortalDemo.Core/"]
COPY ["src/Arq.PortalDemo.EntityFrameworkCore/Arq.PortalDemo.EntityFrameworkCore.csproj", "src/Arq.PortalDemo.EntityFrameworkCore/"]
COPY ["src/Arq.PortalDemo.GraphQL/Arq.PortalDemo.GraphQL.csproj", "src/Arq.PortalDemo.GraphQL/"]
RUN dotnet restore "src/Arq.PortalDemo.Web.Public/Arq.PortalDemo.Web.Public.csproj"
COPY . .
WORKDIR "/src/src/Arq.PortalDemo.Web.Public"
RUN dotnet build "Arq.PortalDemo.Web.Public.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Arq.PortalDemo.Web.Public.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Arq.PortalDemo.Web.Public.dll"]
