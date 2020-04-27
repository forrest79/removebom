=== THIS REPOSITORY IS NO LONGER MAINTAINED ===


RemoveBOM © Jakub Trmota, 2012 (https://forrest79.net)


This program remove BOM header from UTF-8 files. Windows version, both GUI and command-line, Linux version with command-line version only.


HOW TO USE:
===========
GUI version:
------------
Just drag and drop file(s) or directory(ies) to list and all files are checked and when have BOM header, the header is removed. You can choose test only mode, make backup of processed files, files extension and list BOM only/all files.

Command-line version:
---------------------
rmbom [--test|-t] [--backup|-b] [--all|-a] [--extension|-e <extension>] <path>

  <path>                   path to file or directory to process
  --test                   test only for BOM header
  --backup                 backup file before remove BOM header
  --all                    list all files (defaul is only files with BOM header)
  --extension <extension>  process only files with <extension> (default is all files)


HOW TO COMPILE:
===============
GUI version:
------------
Open "RemoveBOM-VS\RemoveBOM.sln" in Visual Studion 2008 and above. Compile, executable file (RemoveBOM.exe) can be found in "bin" directory.

Command-line version:
---------------------
Windows: Open "build\RemoveBOM-CPP.sln" in Visual Studion 2008 and above. Compile, executable files (rmbom.exe or rmbom-debug.exe) can be found in "bin" directory.
Linux: Run "make" in "build" directory. Executable file (rmbom) can be found in "bin" directory.


HISTORY
=======
3.0.0 [2012-05-21] - File checking run in background thread and can be stopped. You can choose file extension.
2.0.0 [2009-10-08] - Add option for list only BOM files and for testing files for having BOM.
1.0.0 [2008-11-21] - First public version.


REQUIREMENTS
============
You need .NET Framework 2 to run GUI version this application (http://www.microsoft.com/downloads/details.aspx?familyid=0856eacb-4362-4b0d-8edd-aab15c5e04f5&displaylang=en).


LICENSE
=======
RemoveBOM is distributed under New BSD license. See license.txt.


https://github.com/forrest79/removebom
