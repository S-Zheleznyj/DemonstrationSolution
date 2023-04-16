#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ProcessMeApp/ProcessMeApp.csproj", "ProcessMeApp/"]
RUN dotnet restore "ProcessMeApp/ProcessMeApp.csproj"
COPY . .
WORKDIR "/src/ProcessMeApp"
RUN dotnet build "ProcessMeApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ProcessMeApp.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProcessMeApp.dll"]