FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

ENV PATH $PATH:/root/.dotnet/tools
RUN dotnet tool install --global dotnet-ef

FROM build as final

WORKDIR /src
COPY Ensek.Smart.Data/ .

RUN dotnet build

CMD dotnet-ef database update --project "/src" --no-build --connection "Data Source=host.docker.internal;Initial Catalog=Smart;User Id=sa;Password=${SA_PASSWORD};TrustServerCertificate=true"