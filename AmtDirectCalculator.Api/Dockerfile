#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY AmtDirectCalculator.Api/AmtDirectCalculator.Api.csproj AmtDirectCalculator.Api/
COPY AmtDirectCalculator.Core/AmtDirectCalculator.Core.csproj AmtDirectCalculator.Core/
COPY AmtDirectCalculator.SharedKernel/AmtDirectCalculator.SharedKernel.csproj AmtDirectCalculator.SharedKernel/
COPY AmtDirectCalculator.Infrastructure/AmtDirectCalculator.Infrastructure.csproj AmtDirectCalculator.Infrastructure/
RUN dotnet restore "AmtDirectCalculator.Api/AmtDirectCalculator.Api.csproj"
COPY . .
WORKDIR "/src/AmtDirectCalculator.Api"
RUN dotnet build "AmtDirectCalculator.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AmtDirectCalculator.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AmtDirectCalculator.Api.dll"]
