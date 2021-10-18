#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Mock/Mock.csproj", "Mock/"]
RUN dotnet restore "Mock/Mock.csproj"
COPY . .
WORKDIR "/src/Mock"
RUN dotnet build "Mock.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Mock.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Mock.dll"]
