FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /
COPY . ./
RUN dotnet publish -c Release -o publish

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runenv
ENV ASPNETCORE_ENVIRONMENT Production
WORKDIR /
COPY --from=build /publish .

ENTRYPOINT ["dotnet", "PetStore.API.dll", "--urls", "http://*:5000"]
EXPOSE 5000