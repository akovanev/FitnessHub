FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY src/ .
RUN dotnet restore "FitnessHub.Runner/FitnessHub.Runner.csproj"
COPY . .
WORKDIR /src/FitnessHub.Runner   
RUN dotnet build "FitnessHub.Runner.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FitnessHub.Runner.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FitnessHub.Runner.dll"]
