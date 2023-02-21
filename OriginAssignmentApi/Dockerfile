FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /OriginAssignmentApi
COPY . ./

RUN dotnet restore
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /OriginAssignmentApi
COPY --from=build-env /OriginAssignmentApi/out .
ENTRYPOINT ["dotnet", "OriginAssignmentApi.dll"]
EXPOSE 80