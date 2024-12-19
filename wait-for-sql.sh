#!/bin/bash
set -e

host="$1"
shift
cmd="$@"

echo "Aguardando conexão com o banco de dados em $host..."

until /opt/mssql-tools/bin/sqlcmd -S $host -U sa -P "6o2yBy=^b7p<" -Q "SELECT 1" &>/dev/null; do
  echo "SQL Server ainda não está pronto. Tentando novamente em 2 segundos..."
  sleep 2
done

echo "SQL Server pronto! Executando comandos..."
exec $cmd