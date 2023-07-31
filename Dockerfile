FROM mcr.microsoft.com/mssql/server:2022-latest

COPY ./entrypoint.sh /
COPY ./init.sql /scripts/

RUN chmod +x /entrypoint.sh

CMD /entrypoint.sh
