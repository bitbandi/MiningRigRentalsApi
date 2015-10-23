@ECHO OFF
SETLOCAL

set BUILD_VERSION=0.1

IF NOT DEFINED DevEnvDir (
	IF DEFINED vs140comntools ( 
		CALL "%vs140comntools%\vsvars32.bat"
	)
)

nuget restore MiningRigRentalsApi.sln

msbuild MiningRigRentalsApi\MiningRigRentalsApi.csproj
if %errorlevel% neq 0 exit /b %errorlevel%
