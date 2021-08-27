FROM mcr.microsoft.com/dotnet/core/sdk:3.1 as build
WORKDIR /app

COPY ./Luna_Project_AspNet-Web-API/*.csproj ./Luna_Project_AspNet-Web-API/
COPY ./Luna_Project_AspNet-Web-API.Core/*.csproj ./Luna_Project_AspNet-Web-API.Core/
COPY ./Luna_Project_AspNet-Web-API.Data/*csproj ./Luna_Project_AspNet-Web-API.Data/
COPY ./Luna_Project_AspNet-Web-API.Service/*csproj ./Luna_Project_AspNet-Web-API.Service/
COPY ./Luna_Project_AspNet-Web-API.Web/*csproj ./Luna_Project_AspNet-Web-API.Web/
COPY *.sln .

RUN dotnet restore
COPY . .
RUN dotnet publish ./Luna_Project_AspNet-Web-API/*csproj -o /publish/

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 as runtime
WORKDIR /app
COPY --from=build /publish .
ENV ASPNETCORE_URLS="http://*:5000"
ENTRYPOINT ["dotnet","Luna_Project_AspNet-Web-API.dll"]