#!/bin/sh
clear
hr="=========================="
args=$1

if [ -z $args ]; then
    args="build"
fi

case $args in
  "build")
  echo -e "\n$hr\nBuilding .....\n$hr\n"
  dotnet build
  ;;

  "clean")
    echo -e "\n$hr\nCleaning .....\n$hr\n"
    dotnet clean
  ;;

  "test")
    echo -e "\n$hr\nRunning Unit Tests .....\n$hr\n"
    dotnet test
  ;;

  "run")
    echo -e "\n$hr\nExecuting .....\n$hr\n"
    dotnet run --project conApp
  ;;

  *)
  echo -e "\nUsage build <build|clean|test|run>\n"
  exit
  ;;
esac

echo -e "\n======= Completed =======\n"
