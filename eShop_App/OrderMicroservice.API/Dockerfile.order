# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
ENV OrderConnectionDb="Server=tcp:rrferry.database.windows.net,1433;Initial Catalog=order-db;Persist Security Info=False;User ID=rrferry;Password=ThisisSQL1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
EXPOSE 8080


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["OrderMicroservice.API/OrderMicroservice.API.csproj", "OrderMicroservice.API/"]
COPY ["OrderMicroservice.Infrastructure/OrderMicroservice.Infrastructure.csproj", "OrderMicroservice.Infrastructure/"]
COPY ["OrderMicroservice.ApplicationCore/OrderMicroservice.ApplicationCore.csproj", "OrderMicroservice.ApplicationCore/"]
RUN dotnet restore "./OrderMicroservice.API/OrderMicroservice.API.csproj"
COPY . .
WORKDIR "/src/OrderMicroservice.API"
RUN dotnet build "./OrderMicroservice.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./OrderMicroservice.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OrderMicroservice.API.dll"]