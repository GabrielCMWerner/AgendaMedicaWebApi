#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["AgendaMedica.WebApi/AgendaMedica.WebApi.csproj", "AgendaMedica.WebApi/"]
COPY ["AgendaMedica.Aplicacao/AgendaMedica.Aplicacao.csproj", "AgendaMedica.Aplicacao/"]
COPY ["AgendaMedica.Dominio/AgendaMedica.Dominio.csproj", "AgendaMedica.Dominio/"]
COPY ["AgendaMedica.Infra.Orm/AgendaMedica.Infra.Orm.csproj", "AgendaMedica.Infra.Orm/"]
RUN dotnet restore "AgendaMedica.WebApi/AgendaMedica.WebApi.csproj"
COPY . .
WORKDIR "/src/AgendaMedica.WebApi"
RUN dotnet build "AgendaMedica.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AgendaMedica.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AgendaMedica.WebApi.dll"]