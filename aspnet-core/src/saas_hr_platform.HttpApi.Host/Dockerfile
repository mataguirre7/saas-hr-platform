FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# node and yarn required by `abp install-libs` to populate wwwroot/libs
RUN apt-get update \
    && apt-get install -y curl \
    && curl -fsSL https://deb.nodesource.com/setup_24.x | bash - \
    && apt-get install -y nodejs \
    && npm install -g yarn \
    && rm -rf /var/lib/apt/lists/*

# ABP CLI (provides `abp install-libs`)
RUN dotnet tool install -g Volo.Abp.Studio.Cli
ENV PATH="${PATH}:/root/.dotnet/tools"

COPY . .

RUN dotnet restore src/saas_hr_platform.HttpApi.Host/saas_hr_platform.HttpApi.Host.csproj

# generate client-side libs into wwwroot/libs
RUN abp install-libs src/saas_hr_platform.HttpApi.Host/saas_hr_platform.HttpApi.Host.csproj

RUN dotnet publish src/saas_hr_platform.HttpApi.Host/saas_hr_platform.HttpApi.Host.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 8080
ENTRYPOINT [ "dotnet", "saas_hr_platform.HttpApi.Host.dll" ]