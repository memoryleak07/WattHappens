FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["WattHappens.Web/WattHappens.Web.csproj", "WattHappens.Web/"]
COPY ["WattHappens.Application/WattHappens.Application.csproj", "WattHappens.Application/"]
COPY ["WattHappens.Infrastructure/WattHappens.Infrastructure.csproj", "WattHappens.Infrastructure/"]
COPY ["WattHappens.Domain/WattHappens.Domain.csproj", "WattHappens.Domain/"]
RUN dotnet restore "WattHappens.Web/WattHappens.Web.csproj"
COPY . .
WORKDIR "/src/WattHappens.Web"
RUN dotnet build "WattHappens.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "WattHappens.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WattHappens.Web.dll"]
