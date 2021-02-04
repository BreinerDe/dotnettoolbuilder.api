FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build-env

EXPOSE 80
EXPOSE 443
# Copy everything  and build
WORKDIR /app
COPY . .
RUN dotnet restore
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim
COPY --from=build-env ./app/out .

RUN dotnet tool install --global DotNetTool.Builder --version 9.0.0
ENV PATH "$PATH:/root/.dotnet/tools"
ENV ASPNETCORE_URLS="http://+;https://+"
RUN echo $PATH
ENTRYPOINT ["dotnet", "Dotnet.ToolBuilder.Api.dll"]