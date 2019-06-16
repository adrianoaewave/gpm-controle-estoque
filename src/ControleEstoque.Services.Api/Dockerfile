FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["ControleEstoque.Services.Api/ControleEstoque.Services.Api.csproj", "ControleEstoque.Services.Api/"]
RUN dotnet restore "ControleEstoque.Services.Api/ControleEstoque.Services.Api.csproj"
COPY . .
WORKDIR "/src/ControleEstoque.Services.Api"
RUN dotnet build "ControleEstoque.Services.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "ControleEstoque.Services.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ControleEstoque.Services.Api.dll"]
