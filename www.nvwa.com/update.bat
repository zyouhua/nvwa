@echo off
rmdir /S /Q ICSharpCode.TextEditor
rmdir /S /Q WinFormsUI
del /S /Q *.dll
del /F /S /Q *.dll
del /F /S /Q /A:H *.dll
del /S /Q *.pdb
del /F /S /Q *.pdb
del /F /S /Q /A:H *.pdb
del /S /Q *.cache
del /F /S /Q *.cache
del /F /S /Q /A:H *.cache
del /S /Q *.exe
del /F /S /Q *.exe
del /F /S /Q /A:H *.exe
del /S /Q *.FileListAbsolute.txt
del /F /S /Q *.FileListAbsolute.txt
del /F /S /Q /A:H *.FileListAbsolute.txt
del /S /Q *.csproj.user
del /F /S /Q *.csproj.user
del /F /S /Q /A:H *.csproj.user
del /S /Q *.suo
del /F /S /Q *.suo
del /F /S /Q /A:H *.suo
del /S /Q *.tlog
del /F /S /Q *.tlog
del /F /S /Q /A:H *.tlog
del /S /Q *.pidb
del /F /S /Q *.pidb
del /F /S /Q /A:H *.pidb
del /S /Q Thumbs.db
del /F /S /Q Thumbs.db
del /F /S /Q /A:H Thumbs.db
del /S /Q *.userprefs
del /F /S /Q *.userprefs
del /F /S /Q /A:H *.userprefs
del /S /Q AssemblyInfo.cs
del /F /S /Q AssemblyInfo.cs
del /F /S /Q /A:H AssemblyInfo.cs
del /S /Q *.cd
del /F /S /Q *.cd
del /F /S /Q /A:H *.cd
del /S /Q *.csproj
del /F /S /Q *.csproj
del /F /S /Q /A:H *.csproj
del /S /Q *.sln
del /F /S /Q *.sln
del /F /S /Q /A:H *.sln
for /f "delims=" %%a in ('dir /s /b /ad bin Properties obj') do (
echo É¾³ý%%a
rd /s /q "%%a"
)
pause
@echo on
