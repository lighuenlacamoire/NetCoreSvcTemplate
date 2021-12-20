#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/GaliciaSeguros.IaaS.Service.Template.DDD.API/GaliciaSeguros.IaaS.Service.Template.DDD.API.csproj", "src/GaliciaSeguros.IaaS.Service.Template.DDD.API/"]
RUN dotnet restore "src/GaliciaSeguros.IaaS.Service.Template.DDD.API/GaliciaSeguros.IaaS.Service.Template.DDD.API.csproj"
COPY . .
WORKDIR "/src/src/GaliciaSeguros.IaaS.Service.Template.DDD.API"
RUN dotnet build "GaliciaSeguros.IaaS.Service.Template.DDD.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GaliciaSeguros.IaaS.Service.Template.DDD.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GaliciaSeguros.IaaS.Service.Template.DDD.API.dll"]