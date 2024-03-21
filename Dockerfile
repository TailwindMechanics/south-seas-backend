# Use the Microsoft's official .NET Core SDK image to build the project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["south-seas-backend.csproj", "./"]
RUN dotnet restore "south-seas-backend.csproj"
COPY . .
RUN dotnet publish "south-seas-backend.csproj" -c Release -o /app/publish

# Use the official ASP.NET Core runtime image to run the application
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "south-seas-backend.dll"]
