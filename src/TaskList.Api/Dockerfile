# Base image for the runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Build stage
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy and restore project dependencies
COPY ["src/TaskList.Api/TaskList.Api.csproj", "src/TaskList.Api/"]
COPY ["src/TaskList.Infrastructure/TaskList.Infrastructure.csproj", "src/TaskList.Infrastructure/"]
RUN dotnet restore "src/TaskList.Api/TaskList.Api.csproj"

# Copy the source files and build the project
COPY . .
WORKDIR "/src/src/TaskList.Api"
RUN dotnet build "TaskList.Api.csproj" -c Release -o /app/build

# Install EF Core tools
RUN dotnet tool install --global dotnet-ef
ENV PATH="${PATH}:/root/.dotnet/tools"

# Publish the application
FROM build AS publish
RUN dotnet publish "TaskList.Api.csproj" -c Release -o /app/publish

# Final runtime image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY --from=build /root/.dotnet/tools /root/.dotnet/tools
ENV PATH="${PATH}:/root/.dotnet/tools"

# Default entry point
ENTRYPOINT ["dotnet", "TaskList.Api.dll"]