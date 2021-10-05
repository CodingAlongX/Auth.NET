FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["RazorAuth/RazorAuth.csproj", "RazorAuth/"]
RUN dotnet restore "RazorAuth/RazorAuth.csproj"
COPY . .
WORKDIR "/src/RazorAuth"
RUN dotnet build "RazorAuth.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RazorAuth.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RazorAuth.dll"]
