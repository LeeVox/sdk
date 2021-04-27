dotnet tool install dotnet-reportgenerator-globaltool --tool-path tools
dotnet test -p:CollectCoverage=true -p:CoverletOutputFormat=cobertura -p:CoverletOutput=TestResults/Coverage/
tools/reportgenerator.exe "-reports:TestResults/*/*.xml" "-targetdir:TestResults"