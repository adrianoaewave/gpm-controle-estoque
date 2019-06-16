FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["ControleEstoque.UI.Web/ControleEstoque.UI.Web.csproj", "ControleEstoque.UI.Web/"]
RUN dotnet restore "ControleEstoque.UI.Web/ControleEstoque.UI.Web.csproj"
COPY . .
WORKDIR "/src/ControleEstoque.UI.Web"
RUN dotnet build "ControleEstoque.UI.Web.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "ControleEstoque.UI.Web.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ControleEstoque.UI.Web.dll"]
