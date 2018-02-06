@ECHO OFF

ECHO Uninstalling Oracle.ManagedDataAccess.Entityframework
"C:\Program Files (x86)\Microsoft SDKs\windows\v10.0A\bin\NETFX 4.6 Tools\gacutil.exe" -u Oracle.ManagedDataAccess.EntityFramework /nologo
ECHO.

ECHO Uninstalling Oracle.ManagedDataAccess
"C:\Program Files (x86)\Microsoft SDKs\windows\v10.0A\bin\NETFX 4.6 Tools\gacutil.exe" -u Oracle.ManagedDataAccess /nologo
ECHO.

pause