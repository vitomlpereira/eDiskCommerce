FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["DiskCommerce.Service/DiskCommerce.Service.csproj", "DiskCommerce.Service/"]
COPY ["DiskCommerce.Infrascructure.Database/DiskCommerce.Database.csproj", "DiskCommerce.Infrascructure.Database/"]
COPY ["DiskCommerce.Model/DiskCommerce.Domain.csproj", "DiskCommerce.Model/"]
COPY ["DiskCommerce.Commom/DiskCommerce.Commom.csproj", "DiskCommerce.Commom/"]
COPY ["DiskCommerce.Cross.IoC/DiskCommerce.Cross.IoC.csproj", "DiskCommerce.Cross.IoC/"]
COPY ["DiskCommerce.Infrastructure.ExternalServices.Spotify/DiskCommerce.ExternalServices.Spotify.csproj", "DiskCommerce.Infrastructure.ExternalServices.Spotify/"]
RUN dotnet restore "DiskCommerce.Service/DiskCommerce.Service.csproj"
COPY . .
WORKDIR "/src/DiskCommerce.Service"
RUN dotnet build "DiskCommerce.Service.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "DiskCommerce.Service.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "DiskCommerce.Service.dll"]