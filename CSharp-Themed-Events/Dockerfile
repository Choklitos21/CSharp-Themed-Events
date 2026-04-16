#FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
#USER $APP_UID
#WORKDIR /app
#EXPOSE 8080
#EXPOSE 8081
#
#FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
#ARG BUILD_CONFIGURATION=Release
#WORKDIR /src
#COPY ["CSharp-Themed-Events/CSharp-Themed-Events.csproj", "CSharp-Themed-Events/"]
#RUN dotnet restore "CSharp-Themed-Events/CSharp-Themed-Events.csproj"
#COPY . .
#WORKDIR "/src/CSharp-Themed-Events"
#RUN dotnet build "./CSharp-Themed-Events.csproj" -c $BUILD_CONFIGURATION -o /app/build
#
#FROM build AS publish
#ARG BUILD_CONFIGURATION=Release
#RUN dotnet publish "./CSharp-Themed-Events.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "CSharp-Themed-Events.dll"]

# Etapa 1: Build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Copiar csproj y restaurar dependencias
COPY *.csproj ./
RUN dotnet restore

# Copiar todo el código
COPY . ./

# Publicar la aplicación
RUN dotnet publish -c Release -o /out

# Etapa 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app

# Copiar desde la etapa build
COPY --from=build /out .

# Exponer puerto
EXPOSE 8080

# Comando de inicio
ENTRYPOINT ["dotnet", "CSharp-Themed-Events.dll"]
