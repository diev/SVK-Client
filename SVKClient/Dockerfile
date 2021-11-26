#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SVKClient/SVKClient.csproj", "SVKClient/"]
RUN dotnet restore "SVKClient/SVKClient.csproj"
COPY . .
WORKDIR "/src/SVKClient"
RUN dotnet build "SVKClient.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SVKClient.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SVKClient.dll"]