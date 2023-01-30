#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["API.BOBERTO.SERVICES.WEB/API.BOBERTO.SERVICES.WEB.csproj", "API.BOBERTO.SERVICES.WEB/"]
COPY ["API.BOBERTO.SERVICES.APPLICATION.MESSAGES/API.BOBERTO.SERVICES.APPLICATION.MESSAGES.csproj", "API.BOBERTO.SERVICES.APPLICATION.MESSAGES/"]
COPY ["API.BOBERTO.SERVICES.APPLICATION/API.BOBERTO.SERVICES.APPLICATION.csproj", "API.BOBERTO.SERVICES.APPLICATION/"]
COPY ["API.BOBERTO.SERVICES.INTEGRATIONS/API.BOBERTO.SERVICES.INTEGRATIONS.csproj", "API.BOBERTO.SERVICES.INTEGRATIONS/"]
RUN dotnet restore "API.BOBERTO.SERVICES.WEB/API.BOBERTO.SERVICES.WEB.csproj"
COPY . .
WORKDIR "/src/API.BOBERTO.SERVICES.WEB"
RUN dotnet build "API.BOBERTO.SERVICES.WEB.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "API.BOBERTO.SERVICES.WEB.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "API.BOBERTO.SERVICES.WEB.dll"]