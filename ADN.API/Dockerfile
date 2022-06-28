#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["ADN.API/ADN.API.csproj", "ADN.API/"]
COPY ["ADN.DT/ADN.DT.csproj", "ADN.DT/"]
COPY ["ADN.BM/ADN.BM.csproj", "ADN.BM/"]
COPY ["ADN.SUP/ADN.SUP.csproj", "ADN.SUP/"]
COPY ["ADN.DM/ADN.DM.csproj", "ADN.DM/"]
RUN dotnet restore "ADN.API/ADN.API.csproj"
COPY . .
WORKDIR "/src/ADN.API"
RUN dotnet build "ADN.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ADN.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ADN.API.dll"]