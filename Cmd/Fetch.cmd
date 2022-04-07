@echo off
cd %Projects%
xcopy "Notepad++\userDefineLangs\*.xml" "SyntaxDefinitions\Notepad++\" /y
xcopy "Notepad++\userDefineLangs\Storage\*.xml" "SyntaxDefinitions\Notepad++\" /y

cd "C:\Users\taylo\iCloudDrive\iCloud~com~agiletortoise~Drafts5\Library\Syntaxes"
xcopy *.json "%Projects%\SyntaxDefinitions\Drafts Syntax\" /y