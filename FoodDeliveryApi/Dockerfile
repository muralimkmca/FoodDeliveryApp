#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["FoodDeliveryApi/FoodDeliveryApi.csproj", "FoodDeliveryApi/"]
RUN dotnet restore "FoodDeliveryApi/FoodDeliveryApi.csproj"
COPY . .
WORKDIR "/src/FoodDeliveryApi"
RUN dotnet build "FoodDeliveryApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FoodDeliveryApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FoodDeliveryApi.dll"]