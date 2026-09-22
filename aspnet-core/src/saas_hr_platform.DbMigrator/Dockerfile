FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY . .
RUN dotnet restore src/saas_hr_platform.DbMigrator/saas_hr_platform.DbMigrator.csproj
RUN dotnet publish src/saas_hr_platform.DbMigrator/saas_hr_platform.DbMigrator.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT [ "dotnet", "saas_hr_platform.DbMigrator.dll" ]