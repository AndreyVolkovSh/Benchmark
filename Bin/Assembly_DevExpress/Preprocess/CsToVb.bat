echo %1
@setlocal enableextensions
@cd /d "%~dp0"

powershell.exe  -NonInteractive -ExecutionPolicy Unrestricted  .\CsToVb.ps1 %1

exit