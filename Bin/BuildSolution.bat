@ECHO OFF
Setlocal EnableDelayedExpansion
set MSBUILD4=%windir%\Microsoft.NET\Framework\v4.0.30319\msbuild
%MSBUILD4% %1 /nologo /m:%2 /t:rebuild /p:TargetFrameworkVersion=%3;TargetFrameworkProfile= /tv:%4 /clp:errorsonly 
::>> "c:/1.txt"
endlocal