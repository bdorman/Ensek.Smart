FROM mcr.microsoft.com/mssql/server:2022-latest

ENV ACCEPT_EULA=Y
ENV MSSQL_PID=Developer
ENV MSSQL_TCP_PORT=1433

ADD --chmod=777 healthcheck.sh healthcheck.sh

ENTRYPOINT [ "/opt/mssql/bin/sqlservr", "--accept-eula"]