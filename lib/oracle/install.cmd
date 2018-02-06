@ECHO OFF

setlocal enableextensions
cd /d "%~dp0"

ECHO Installing oracle version of Oracle.ManagedDataAccess
"C:\Program Files (x86)\Microsoft SDKs\windows\v10.0A\bin\NETFX 4.6 Tools\gacutil.exe" -i %oracle_home%\odp.net\managed\common\Oracle.ManagedDataAccess.dll /f /nologo
ECHO.

ECHO Installing framework Oracle.ManagedDataAccess
"C:\Program Files (x86)\Microsoft SDKs\windows\v10.0A\bin\NETFX 4.6 Tools\gacutil.exe" -i Oracle.ManagedDataAccess.dll /f /nologo
ECHO.

ECHO Installing Oracle.ManagedDataAccess.EntityFramework
"C:\Program Files (x86)\Microsoft SDKs\windows\v10.0A\bin\NETFX 4.6 Tools\gacutil.exe" -i Oracle.ManagedDataAccess.EntityFramework.dll /f /nologo
ECHO.

pause
