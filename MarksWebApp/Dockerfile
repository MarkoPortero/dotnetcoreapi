FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["MarksWebApp.csproj", "./"]
COPY ./NuGet.Config ./
RUN dotnet restore "./MarksWebApp.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "MarksWebApp.csproj" -c Release -o /app/build --configfile ./NuGet.Config

FROM build AS publish
RUN dotnet publish "MarksWebApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MarksWebApp.dll"]
