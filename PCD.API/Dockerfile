# Base image for development with .NET SDK
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS dev

# Set working directory
WORKDIR /app

# Expose ports (same as your app)
EXPOSE 8080
EXPOSE 8081

# Copy only csproj files and restore dependencies first (for caching)
COPY ["PCD.API/PCD.API.csproj", "PCD.API/"]
COPY ["PCD.ApplicationServices/PCD.ApplicationServices.csproj", "PCD.ApplicationServices/"]
COPY ["PCD.Infrastructure/PCD.Infrastructure.csproj", "PCD.Infrastructure/"]
COPY ["PCD.Repository/PCD.Repository.csproj", "PCD.Repository/"]
COPY ["PCD.Data/PCD.Data.csproj", "PCD.Data/"]
RUN dotnet restore "./PCD.API/PCD.API.csproj"

# Copy the rest of the code
COPY . .

# Set environment variables for development
ENV DOTNET_USE_POLLING_FILE_WATCHER=1 \
    DOTNET_RUNNING_IN_CONTAINER=true \
    DOTNET_USE_DESIGN_TIME_BUILD=true

# Set working directory to API project
WORKDIR "/app/PCD.API"

# Default entrypoint for dev: run with watch for live reload
ENTRYPOINT ["dotnet", "watch", "run", "--urls", "http://0.0.0.0:8080;http://0.0.0.0:8081"]
