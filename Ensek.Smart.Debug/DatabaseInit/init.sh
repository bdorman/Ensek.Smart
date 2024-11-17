#!/bin/bash

/opt/mssql-tools18/bin/sqlcmd -S host.docker.internal -U SA -P $SA_PASSWORD -C -i init.sql

sleep 60