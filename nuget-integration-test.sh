#!/usr/bin/env bash

rm -rf ./packages
rm -rf ./tests/Raiqub.Generators.Comparable.NugetIntegrationTests/obj
rm -rf ./tests/Raiqub.Generators.Comparable.NugetIntegrationTests/bin

dotnet restore ./tests/Raiqub.Generators.Comparable.NugetIntegrationTests --packages ./packages --configfile nuget.integration-tests.config
dotnet build ./tests/Raiqub.Generators.Comparable.NugetIntegrationTests -c Release --packages ./packages --no-restore
dotnet test ./tests/Raiqub.Generators.Comparable.NugetIntegrationTests -c Release --no-build --no-restore