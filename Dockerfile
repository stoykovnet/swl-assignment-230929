FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /
COPY . ./
RUN dotnet publish -c Release -o publish

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runenv
ENV ASPNETCORE_ENVIRONMENT Production
WORKDIR /
COPY --from=build /publish .

# Install the new relic agent
RUN apt-get update && apt-get install -y wget ca-certificates gnupg \
&& echo 'deb http://apt.newrelic.com/debian/ newrelic non-free' | tee /etc/apt/sources.list.d/newrelic.list \
&& wget https://download.newrelic.com/548C16BF.gpg \
&& apt-key add 548C16BF.gpg \
&& apt-get update \
&& apt-get install -y newrelic-dotnet-agent \
&& rm -rf /var/lib/apt/lists/*

# Enable the new relic agent
ENV CORECLR_ENABLE_PROFILING=1 \
CORECLR_PROFILER={36032161-FFC0-4B61-B559-F6C5D41BAE5A} \
CORECLR_NEWRELIC_HOME=/usr/local/newrelic-dotnet-agent \
CORECLR_PROFILER_PATH=/usr/local/newrelic-dotnet-agent/libNewRelicProfiler.so \
NEW_RELIC_LICENSE_KEY=eu01xx8fc042cf2311a07db90004da61ac1aNRAL \
NEW_RELIC_APP_NAME=<REPO_NAME>

ENTRYPOINT ["dotnet", "RepoTemplate.API.dll", "--urls", "http://*:5000"]
EXPOSE 5000