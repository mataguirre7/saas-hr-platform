FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY . .

RUN dotnet restore src/saas_hr_platform.HttpApi.Host/saas_hr_platform.HttpApi.Host.csproj
RUN dotnet restore src/saas_hr_platform.HttpApi.Host/saas_hr_platform.HttpApi.Host.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 8080
ENTRYPOINT [ "dotnet", "saas_hr_platform.HttpApi.Host.dll" ]