#Build
FROM mcr.microsoft.com/dotnet/sdk:8.0@sha256:306301580fcaa5b445180e759db59309979002d1000669cb4cf58a567d0014bc AS build

WORKDIR /src

COPY . .

RUN dotnet restore

RUN dotnet publish src/JtlDemo.Rest.Host/JtlDemo.Rest.Host.csproj \
    --configuration Release \
    --output /app/publish \
    --no-restore

#Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0@sha256:b0beb9cc1dee1c1b0749796110d4734292071b814207ad0d4f40611f7db04f7b AS runtime

WORKDIR /app

COPY --from=build /app/publish .

EXPOSE 8080

USER $APP_UID

HEALTHCHECK --interval=30s --timeout=5s --start-period=10s --retries=3 \
    CMD ["bash", "-c", "exec 3<>/dev/tcp/127.0.0.1/8080 && printf 'GET /healthz HTTP/1.1\r\nHost: localhost\r\nConnection: close\r\n\r\n' >&3 && read -r _ status _ <&3 && [ \"$status\" = \"200\" ]"]

ENTRYPOINT ["dotnet", "JtlDemo.Rest.Host.dll"]