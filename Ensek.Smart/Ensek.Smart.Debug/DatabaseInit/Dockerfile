FROM mcr.microsoft.com/mssql/server:2022-latest

ADD --chmod=777 healthcheck.sh healthcheck.sh

ADD --chmod=777 init.sh init.sh
ADD --chmod=777 init.sql init.sql
ADD --chmod=777 init.sql init.sql

ENTRYPOINT ["/bin/bash", "/init.sh"]