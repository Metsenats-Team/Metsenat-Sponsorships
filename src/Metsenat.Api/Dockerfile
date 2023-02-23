
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/Metsenat.Api/Metsenat.Api.csproj", "Metsenat.Api/"]
COPY ["src/Metsenat.Common/Metsenat.Common.csproj", "Metsenat.Common/"]
COPY ["src/Metsenat.Data/Metsenat.Data.csproj", "Metsenat.Data/"]
COPY ["src/Metsenat.BLL/Metsenat.BLL.csproj", "Metsenat.BLL/"]
COPY ["src/Metsenat.Test/Metsenat.Test.csproj", "Metsenat.Test/"]
RUN dotnet restore "Metsenat.Api/Metsenat.Api.csproj"
COPY . .
WORKDIR "/src/src/Metsenat.Api.Api"
RUN dotnet build "Metsenat.Api.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Metsenat.Api.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Metsenat.Api.dll"]