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

#install dotnet sdk 3.1 till dotnet toolbuilder is awailable for dotnet 5
RUN apt update
RUN apt install -y sudo
RUN wget https://packages.microsoft.com/config/debian/10/packages-microsoft-prod.deb -O packages-microsoft-prod.deb && \
	sudo dpkg -i packages-microsoft-prod.deb
RUN apt update
RUN sudo apt install -y dotnet-sdk-3.1

RUN dotnet tool install --global "DotNetTool.Builder" --version 0.9.6
ENV PATH "$PATH:/root/.dotnet/tools"
ENV ASPNETCORE_URLS="http://+;https://+"
RUN echo $PATH
ENTRYPOINT ["dotnet", "Dotnet.ToolBuilder.Api.dll"]