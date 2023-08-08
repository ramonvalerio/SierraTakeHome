# Usar uma imagem oficial do Node.js baseada em Debian
FROM node:18

# Definir o diretório de trabalho no container
WORKDIR /app

# Copiar o arquivo package.json e package-lock.json (se disponível)
COPY package.json .

# Instalar as dependências da aplicação
RUN npm install

# Copiar o restante dos arquivos da aplicação para o container
COPY . .

# Expor a porta que o app Node.js vai rodar (altere conforme necessário)
EXPOSE 5173

# Comando para rodar a aplicação em modo dev
CMD [ "npm", "run", "dev" ]
