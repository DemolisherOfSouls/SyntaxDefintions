@echo off

cd "G:\My Drive\Projects\Notepad++\userDefineLangs"
xcopy *.xml "G:\My Drive\Projects\Visual Studio\SyntaxDefintions\Notepad++ Syntax\" /y
cd Storage
xcopy *.xml "G:\My Drive\Projects\Visual Studio\SyntaxDefintions\Notepad++ Syntax\" /y
cd "..\"