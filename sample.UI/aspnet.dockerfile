FROM mcr.microsoft.com/dotnet/sdk:3.1
WORKDIR /code
COPY . .
RUN  dotnet restore . 

RUN dotnet publish -o /app 

WORKDIR /app
#WORKDIR /app/publish
# ASPNETCORE_URLS required for the dotnet core in container
ENV ASPNETCORE_URLS=http://+:80
ENV ASPNETCORE_ENVIRONMENT=Development
EXPOSE 80
ENTRYPOINT [ "dotnet","sample.UI.dll" ]




