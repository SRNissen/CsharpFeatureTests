FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["StrongTypeTest/StrongTypeTest.csproj", "StrongTypeTest/"]
RUN dotnet restore "StrongTypeTest/StrongTypeTest.csproj"
COPY . .
WORKDIR "/src/StrongTypeTest"
RUN dotnet build "StrongTypeTest.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "StrongTypeTest.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StrongTypeTest.dll"]
