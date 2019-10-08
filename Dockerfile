# Use the dot net core SDK for the build stage
FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build
# Set the working directory
WORKDIR /app
# Copy *.csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore
# Copy everything else and build app
COPY . ./
RUN dotnet publish -c Release -o out

# Use the dot net core ASP.NET image for the runtime
FROM mcr.microsoft.com/dotnet/core/aspnet:2.2 AS runtime
# Set the working directory
WORKDIR /app
# Copy the built app from the build stage
COPY --from=build /app/out ./
# Set permissions and run as a non-root user
RUN chown -R www-data:www-data ./ && chmod -R 0500 ./ && chmod -R 0700 *.dll
USER www-data:www-data
# Expose the app port
EXPOSE 50001
# Set the entrypoint
ENTRYPOINT ["dotnet", "projects-service.dll"]
