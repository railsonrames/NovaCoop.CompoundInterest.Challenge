#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["NovaCoop.ComputeInterest.API/NovaCoop.ComputeInterest.API.csproj", "NovaCoop.ComputeInterest.API/"]
RUN dotnet restore "NovaCoop.ComputeInterest.API/NovaCoop.ComputeInterest.API.csproj"
COPY . .
WORKDIR "/src/NovaCoop.ComputeInterest.API"
RUN dotnet build "NovaCoop.ComputeInterest.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NovaCoop.ComputeInterest.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NovaCoop.ComputeInterest.API.dll"]