#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
EXPOSE 80
EXPOSE 443
WORKDIR /src
COPY ["src/Gambali.InternalTalent.WebApi/Gambali.InternalTalent.WebApi.csproj", "Gambali.InternalTalent.WebApi/"]
COPY ["src/Gambali.InternalTalent.Crosscutting/Gambali.InternalTalent.Crosscutting.csproj", "Gambali.InternalTalent.Crosscutting/"]
COPY ["src/Gambali.InternalTalent.Application/Gambali.InternalTalent.Application.csproj", "Gambali.InternalTalent.Application/"]
COPY ["src/Gambali.InternalTalent.Domain/Gambali.InternalTalent.Domain.csproj", "Gambali.InternalTalent.Domain/"]
COPY ["src/Gambali.InternalTalent.Infra/Gambali.InternalTalent.Infra.csproj", "Gambali.InternalTalent.Infra/"]

RUN dotnet restore "Gambali.InternalTalent.WebApi/Gambali.InternalTalent.WebApi.csproj"

COPY ./src .

WORKDIR "/src/Gambali.InternalTalent.WebApi"
RUN dotnet build "Gambali.InternalTalent.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Gambali.InternalTalent.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Gambali.InternalTalent.WebApi.dll"]

