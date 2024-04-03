#!/bin/bash
RESULTS_FOLDER="TestResults/"

dotnet test -c Release --no-build --logger trx --results-directory "$RESULTS_FOLDER"  || echo "Tests failed"
exitCode=$?

if [ $exitCode -ne 0 ]; then
  echo "Exiting 1 due to unexpected $exitCode error from dotnet test."
  exit 1
else
  dotnet tool install --global dotnet-coverage
  dotnet-coverage collect "dotnet test" -f xml -o "coverage.xml"
  exit 0
fi