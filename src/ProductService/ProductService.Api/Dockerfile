#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 5102
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["ProductService/ProductService.Api/ProductService.Api.csproj", "ProductService/ProductService.Api/"]
COPY ["ProductService/ProductService.Application/ProductService.Application.csproj", "ProductService/ProductService.Application/"]
COPY ["ProductService/ProductService.Core/ProductService.Core.csproj", "ProductService/ProductService.Core/"]
COPY ["ProductService/ProductService.Infrastructure/ProductService.Infrastructure.csproj", "ProductService/ProductService.Infrastructure/"]
COPY ["UserService/UserService.Application/UserService.Application.csproj", "UserService/UserService.Application/"]
COPY ["UserService/UserService.Core/UserService.Core.csproj", "UserService/UserService.Core/"]
RUN dotnet restore "ProductService/ProductService.Api/ProductService.Api.csproj"
COPY . .
WORKDIR "/src/ProductService/ProductService.Api"
RUN dotnet build "ProductService.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ProductService.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProductService.Api.dll"]
