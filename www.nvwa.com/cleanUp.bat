@echo off
del /F /S /Q *.dll
del /F /S /Q *.pdb
del /F /S /Q *.cache
del /F /S /Q *.exe
del /F /S /Q *.FileListAbsolute.txt
del /F /S /Q *.csproj.user
del /F /S /Q *.suo
del /F /S /Q *.tlog
del /F /S /Q *.pidb
del /F /S /Q Thumbs.db
del /F /S /Q /A:H *.dll
del /F /S /Q /A:H *.pdb
del /F /S /Q /A:H *.cache
del /F /S /Q /A:H *.exe
del /F /S /Q /A:H *.FileListAbsolute.txt
del /F /S /Q /A:H *.csproj.user
del /F /S /Q /A:H *.suo
del /F /S /Q /A:H *.tlog
del /F /S /Q *.pidb
del /F /S /Q /A:H Thumbs.db
del /F /S /Q /A:H *.userprefs
pause
@echo on
