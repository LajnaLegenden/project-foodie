#!/bin/bash
sudo curl -sL https://deb.nodesource.com/setup_16.x | bash -
sudo apt-get install -y nodejs

npm i
dotnet restore
dotnet tool restore
