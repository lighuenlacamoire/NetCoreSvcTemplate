#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["GaliciaSeguros.Template.DDD.API/GaliciaSeguros.Template.DDD.API.csproj", "GaliciaSeguros.Template.DDD.API/"]
RUN dotnet restore "GaliciaSeguros.Template.DDD.API/GaliciaSeguros.Template.DDD.API.csproj"
COPY . .
WORKDIR "/src/GaliciaSeguros.Template.DDD.API"
RUN dotnet build "GaliciaSeguros.Template.DDD.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GaliciaSeguros.Template.DDD.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GaliciaSeguros.Template.DDD.API.dll"]