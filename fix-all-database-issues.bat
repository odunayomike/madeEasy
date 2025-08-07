@echo off
echo SoftlightCBS Database Fix-All Script
echo ====================================
echo.
echo This script will fix all known database issues for the SoftlightCBS application:
echo - Fix login authentication stored procedures
echo - Create missing tables and stored procedures
echo - Resolve parameter mismatches
echo - Test all critical database components
echo.
pause
echo.
echo Running database fixes...
dotnet run --project fix-all-database-issues.csproj
echo.
echo Fix-all script completed!
pause