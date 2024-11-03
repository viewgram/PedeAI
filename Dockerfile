# Etapa 1: Construção da aplicação
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copia o arquivo de solução e os arquivos de projeto para o contêiner
COPY *.sln ./
COPY src/PedeAI.WebAPI/*.csproj ./src/PedeAI.WebAPI/
COPY src/PedeAI.Application/*.csproj ./src/PedeAI.Application/
COPY src/PedeAI.Domain/*.csproj ./src/PedeAI.Domain/
COPY src/PedeAI.Infrastructure/*.csproj ./src/PedeAI.Infrastructure/

# Restaura as dependências do projeto
RUN dotnet restore

# Copia todos os arquivos restantes e compila o projeto
COPY . .
WORKDIR /app/src/PedeAI.WebAPI
RUN dotnet publish -c Release -o /app/publish

# Etapa 2: Criação da imagem final para execução
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

# Expor a porta 80 para a API
EXPOSE 80

# Comando de entrada para iniciar a aplicação
ENTRYPOINT ["dotnet", "PedeAI.WebAPI.dll"]
