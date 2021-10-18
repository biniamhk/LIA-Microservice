#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["PlanService/PlanService/PlanService.csproj", "PlanService/PlanService/"]
RUN dotnet restore "PlanService/PlanService/PlanService.csproj"
COPY . .
WORKDIR "/src/PlanService/PlanService"
RUN dotnet build "PlanService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PlanService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PlanService.dll"]