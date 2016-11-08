@echo off
setlocal EnableDelayedExpansion
echo ********************************************************************************  
echo           deploy_ibas_web_services 
echo                         by niuren.zhu  
echo                         2014.10.22
echo 部署ibas发布包为web服务，使用说明
echo     1. 配置本机环境变量ibasTools，并保证存在7Zip\7zip.exe。
echo     2. 新建文件夹，拷贝此脚本到其中。
echo     3. 运行脚本，脚本会初始化所需要的文件夹。
echo     4. 从http://ibas-dev.avatech.com.cn:8866 下载发布包到，~packages目录下。
echo     5. 运行脚本，模块就会被解压到此文件夹中。
echo     6. iis中新建网站，并把根目录指定到此文件夹。
echo     7. 将iis网站中的模块目录，右键激活菜单，选择转为应用程序。
echo     8. 修改SystemCenter目录下的ServiceInformations.config配置相关模块信息。
echo     9. 使用BTulz.Transform创建模块所需结构，xml文件在每个模块的DataStructures文件夹下。
echo    10. 执行DataStructures\SQLs\文件夹下的sql脚本，注意数据库平台。

echo  备注：
echo      SystemCenter下的DataStructures先执行basis文件夹内容，再执行system内容，再执行sqls脚本。
echo      svc文件无法解析，运行%WINDIR%\Microsoft.NET\Framework\v4.0.30319\aspnet_regiis.exe -i。
echo ********************************************************************************    
REM hh用来解决取小时可能出现空格的问题(凌晨1点到早上9点%time:~0,2%都会出现空格)  
SET h=%time:~0,2%
SET hh=%h: =0%
SET WORK_FOLDER=%~dp0

SET OPNAME=%date:~0,4%%date:~5,2%%date:~8,2%_%hh%%time:~3,2%%time:~6,2%
SET LOGFILE=%WORK_FOLDER%deploy_ibas_web_services_%OPNAME%.txt
SET PACKAGES_FOLDER=%WORK_FOLDER%~packages
SET PACKAGES_TEMP_FOLDER=%WORK_FOLDER%~packages\temp
SET PACKAGES_BACKUP_FOLDER=%WORK_FOLDER%~packages\backup
SET MY_PACKAGES_BACKUP_FOLDER=%WORK_FOLDER%~packages\backup\%OPNAME%
SET MY_PACKAGES_FOLDER=%WORK_FOLDER%
SET MY_ERROR=NO
SET SYSTEM_CENTER=%WORK_FOLDER%SystemCenter
SET INTEGRATION_SERVICES=%WORK_FOLDER%BusinessDataIntegration\Services

echo 部署日志 - %OPNAME% > %LOGFILE%
echo ****************************************************** >> %LOGFILE%
echo 开始运行脚本/%OPNAME%
echo 开始检运行环境
if exist %WORK_FOLDER%Tools\7zip\7z.exe SET ibasTools=%WORK_FOLDER%Tools
if not exist "%ibasTools%\7zip\7z.exe" SET MY_ERROR=YES
if not exist "%ibasTools%\7zip\7z.exe" echo 错误：没有配置解压工具  >> %LOGFILE%
if not exist "%ibasTools%\7zip\7z.exe" echo 错误：没有配置解压工具，请配置环境变量ibasTools，并保证存在"%ibasTools%\7zip\7z.exe"。
if not exist "%ibasTools%\7zip\7z.exe" PAUSE

if %MY_ERROR%==YES GOTO END
:CHECK_DONE
echo 开始检查程序包目录 - %PACKAGES_FOLDER%
if not exist %PACKAGES_FOLDER% md %PACKAGES_FOLDER% >> %LOGFILE%
echo >%PACKAGES_FOLDER%\程序包放在此目录
if not exist %PACKAGES_TEMP_FOLDER% md %PACKAGES_TEMP_FOLDER% >> %LOGFILE%
if not exist %PACKAGES_BACKUP_FOLDER% md %PACKAGES_BACKUP_FOLDER% >> %LOGFILE%
echo >%PACKAGES_BACKUP_FOLDER%\程序包备份目录
if not exist %MY_PACKAGES_BACKUP_FOLDER% md %MY_PACKAGES_BACKUP_FOLDER% >> %LOGFILE%

echo 结束检运行环境

:DEPLOY_MODULES
if not exist %PACKAGES_FOLDER%\ibas_4_modules_published_*.zip GOTO DEPLOY_SHELL
for /f %%m in ('dir /a /b %PACKAGES_FOLDER%\ibas_4_modules_published_*.zip') DO (
echo 正在处理程序包：%%m
REM 取模块名称，此处变量涉及延迟处理问题
SET MY_PACKAGES_FOLDER=%%~nm
SET MY_PACKAGES_NAME=!MY_PACKAGES_FOLDER:~48,99!
SET MY_PACKAGES_FOLDER=%WORK_FOLDER%!MY_PACKAGES_FOLDER:~48,99!
SET CODE_MOUDLE_FOLDER=%ibasSourceCode%\BizSys.!MY_PACKAGES_NAME!\0401\Release

if not exist %PACKAGES_TEMP_FOLDER% md %PACKAGES_TEMP_FOLDER% >> %LOGFILE%
if exist %PACKAGES_TEMP_FOLDER%\*.* del /f /s /q %PACKAGES_TEMP_FOLDER%\*.* >> %LOGFILE%
%ibasTools%\7zip\7z.exe x %PACKAGES_FOLDER%\%%m -o%PACKAGES_TEMP_FOLDER%\ -aoa >> %LOGFILE%

if not exist !CODE_MOUDLE_FOLDER! md !CODE_MOUDLE_FOLDER! >> %LOGFILE%
if exist !CODE_MOUDLE_FOLDER!\*.* del /f /s /q !CODE_MOUDLE_FOLDER!\*.* >> %LOGFILE%
%ibasTools%\7zip\7z.exe x %PACKAGES_FOLDER%\%%m -o!CODE_MOUDLE_FOLDER!\ -aoa >> %LOGFILE%

if exist %PACKAGES_TEMP_FOLDER%\Services\ if not exist !MY_PACKAGES_FOLDER! md !MY_PACKAGES_FOLDER! >> %LOGFILE%
if exist %PACKAGES_TEMP_FOLDER%\Services\ if exist %PACKAGES_TEMP_FOLDER%\Services\ xcopy /s /y %PACKAGES_TEMP_FOLDER%\Services\*.* !MY_PACKAGES_FOLDER! >> %LOGFILE%
if exist %PACKAGES_TEMP_FOLDER%\Services\ if exist !MY_PACKAGES_FOLDER!\web.config del /f /s /q !MY_PACKAGES_FOLDER!\web.config >> %LOGFILE%

if exist %PACKAGES_TEMP_FOLDER%\DataStructures\ if not exist !MY_PACKAGES_FOLDER! md !MY_PACKAGES_FOLDER! >> %LOGFILE%
if exist %PACKAGES_TEMP_FOLDER%\DataStructures\ if not exist !MY_PACKAGES_FOLDER!\DataStructures md !MY_PACKAGES_FOLDER!\DataStructures >> %LOGFILE%
if exist %PACKAGES_TEMP_FOLDER%\DataStructures\ if exist %PACKAGES_TEMP_FOLDER%\DataStructures\ xcopy /s /y %PACKAGES_TEMP_FOLDER%\DataStructures\*.* !MY_PACKAGES_FOLDER!\DataStructures >> %LOGFILE%

if not exist %SYSTEM_CENTER%\ClientBin md %SYSTEM_CENTER%\ClientBin
if not exist !MY_PACKAGES_FOLDER! copy /y %PACKAGES_TEMP_FOLDER%\BSUi.*.zip %SYSTEM_CENTER%\ClientBin >> %LOGFILE%

if not exist %INTEGRATION_SERVICES% md %INTEGRATION_SERVICES%
if exist %PACKAGES_TEMP_FOLDER%\BizSys.!MY_PACKAGES_NAME!.Integration.B1.zip %ibasTools%\7zip\7z.exe x %PACKAGES_TEMP_FOLDER%\BizSys.!MY_PACKAGES_NAME!.Integration.B1.zip -o%INTEGRATION_SERVICES%\ -aoa >> %LOGFILE%

if exist %PACKAGES_TEMP_FOLDER%\extraServices\ xcopy /s /y %PACKAGES_TEMP_FOLDER%\extraServices\*.*  >> %LOGFILE%

if exist %PACKAGES_FOLDER%\%%m move /y %PACKAGES_FOLDER%\%%m %MY_PACKAGES_BACKUP_FOLDER%\ >> %LOGFILE%

if exist %PACKAGES_TEMP_FOLDER%\*.* del /f /s /q %PACKAGES_TEMP_FOLDER%\*.* >> %LOGFILE%
if exist %PACKAGES_TEMP_FOLDER% rd /s /q %PACKAGES_TEMP_FOLDER% >> %LOGFILE%

if exist %SYSTEM_CENTER%\Libraries\BOBas.BusinessObjectsCommon.DB.*.zip for /f %%l in ('dir /a /b %SYSTEM_CENTER%\Libraries\BOBas.BusinessObjectsCommon.DB.*.zip') DO (
if exist !MY_PACKAGES_FOLDER!\bin %ibasTools%\7zip\7z.exe x %SYSTEM_CENTER%\Libraries\%%l -o!MY_PACKAGES_FOLDER!\bin -aoa >> %LOGFILE%
)

)

:DEPLOY_SHELL
SET MY_PACKAGES_FOLDER=%SYSTEM_CENTER%
SET CODE_SHELL_FOLDER=%ibasSourceCode%\BusinessSystemShell\04\Release
if not exist %MY_PACKAGES_FOLDER% md %MY_PACKAGES_FOLDER% >> %LOGFILE%
if not exist %MY_PACKAGES_FOLDER%\DataStructures md %MY_PACKAGES_FOLDER%\DataStructures >> %LOGFILE%
if not exist %MY_PACKAGES_FOLDER%\Libraries md %MY_PACKAGES_FOLDER%\Libraries >> %LOGFILE%
if exist %MY_PACKAGES_FOLDER%\ServiceInformations.config copy /y %MY_PACKAGES_FOLDER%\ServiceInformations.config %MY_PACKAGES_FOLDER%\my.ServiceInformations.config >> %LOGFILE%
if exist %MY_PACKAGES_FOLDER%\ClientBin\ServiceReferences.ClientConfig copy /y %MY_PACKAGES_FOLDER%\ClientBin\ServiceReferences.ClientConfig %MY_PACKAGES_FOLDER%\ClientBin\my.ServiceReferences.ClientConfig >> %LOGFILE%

if not exist %PACKAGES_FOLDER%\ibas_4_shell_published_*.zip GOTO END
for /f %%m in ('dir /a /b %PACKAGES_FOLDER%\ibas_4_shell_published_*.zip') DO (
echo 正在处理程序包：%%m

if not exist %PACKAGES_TEMP_FOLDER% md %PACKAGES_TEMP_FOLDER% >> %LOGFILE%
if exist %PACKAGES_TEMP_FOLDER%\*.* del /f /s /q %PACKAGES_TEMP_FOLDER%\*.* >> %LOGFILE%
%ibasTools%\7zip\7z.exe x %PACKAGES_FOLDER%\%%m -o%PACKAGES_TEMP_FOLDER%\ -aoa >> %LOGFILE%

if not exist %CODE_SHELL_FOLDER% md %CODE_SHELL_FOLDER% >> %LOGFILE%
if exist %CODE_SHELL_FOLDER%\*.* del /f /s /q %CODE_SHELL_FOLDER%\*.* >> %LOGFILE%
%ibasTools%\7zip\7z.exe x %PACKAGES_FOLDER%\%%m -o%CODE_SHELL_FOLDER%\ -aoa >> %LOGFILE%

if exist %PACKAGES_TEMP_FOLDER%\Services\ xcopy /s /y %PACKAGES_TEMP_FOLDER%\Services\*.* %MY_PACKAGES_FOLDER% >> %LOGFILE%
if exist %MY_PACKAGES_FOLDER%\web.config if not exist %WORK_FOLDER%\web.config copy /y %MY_PACKAGES_FOLDER%\web.config %WORK_FOLDER% >> %LOGFILE%
if exist %MY_PACKAGES_FOLDER%\web.config del /f /s /q %MY_PACKAGES_FOLDER%\web.config >> %LOGFILE%

if exist %MY_PACKAGES_FOLDER%\clientaccesspolicy.xml if not exist %WORK_FOLDER%\clientaccesspolicy.xml copy /y %MY_PACKAGES_FOLDER%\clientaccesspolicy.xml %WORK_FOLDER% >> %LOGFILE%
if exist %MY_PACKAGES_FOLDER%\CrossDomain.xml if not exist %WORK_FOLDER%\CrossDomain.xml copy /y %MY_PACKAGES_FOLDER%\CrossDomain.xml %WORK_FOLDER% >> %LOGFILE%

if exist %PACKAGES_TEMP_FOLDER%\DataStructures\ xcopy /s /y %PACKAGES_TEMP_FOLDER%\DataStructures\*.* %MY_PACKAGES_FOLDER%\DataStructures >> %LOGFILE%
if exist %PACKAGES_TEMP_FOLDER%\BOBas.BusinessObjectsCommon.DB.*.zip copy /y %PACKAGES_TEMP_FOLDER%\BOBas.BusinessObjectsCommon.DB.*.zip %MY_PACKAGES_FOLDER%\Libraries >> %LOGFILE%

if exist %PACKAGES_TEMP_FOLDER%\Setup.BusinessSystemCenter.B1.Bundle.zip copy /y %PACKAGES_TEMP_FOLDER%\Setup.BusinessSystemCenter.B1.Bundle.zip %MY_PACKAGES_FOLDER%\ClientBin >> %LOGFILE%

if exist %PACKAGES_FOLDER%\%%m move /y %PACKAGES_FOLDER%\%%m %MY_PACKAGES_BACKUP_FOLDER%\ >> %LOGFILE%

if exist %PACKAGES_TEMP_FOLDER%\*.* del /f /s /q %PACKAGES_TEMP_FOLDER%\*.* >> %LOGFILE%
if exist %PACKAGES_TEMP_FOLDER% rd /s /q %PACKAGES_TEMP_FOLDER% >> %LOGFILE%

for /f %%l in ('dir /a /b %SYSTEM_CENTER%\Libraries\BOBas.BusinessObjectsCommon.DB.*.zip') DO (
if exist %MY_PACKAGES_FOLDER%\bin %ibasTools%\7zip\7z.exe x %SYSTEM_CENTER%\Libraries\%%l -o%MY_PACKAGES_FOLDER%\bin -aoa >> %LOGFILE%
)

)
if exist %MY_PACKAGES_FOLDER%\my.ServiceInformations.config copy /y %MY_PACKAGES_FOLDER%\my.ServiceInformations.config %MY_PACKAGES_FOLDER%\ServiceInformations.config >> %LOGFILE%
if exist %MY_PACKAGES_FOLDER%\ClientBin\my.ServiceReferences.ClientConfig copy /y %MY_PACKAGES_FOLDER%\ClientBin\my.ServiceReferences.ClientConfig %MY_PACKAGES_FOLDER%\ClientBin\ServiceReferences.ClientConfig >> %LOGFILE%

if exist %MY_PACKAGES_FOLDER%\ClientBin\ServiceReferences.ClientConfig if exist %MY_PACKAGES_FOLDER%\ClientBin\BSUi.BusinessSystemCenter.Silverlight.xap %ibasTools%\7Zip\7z.exe a -tzip %MY_PACKAGES_FOLDER%\ClientBin\BSUi.BusinessSystemCenter.Silverlight.xap -r %MY_PACKAGES_FOLDER%\ClientBin\ServiceReferences.ClientConfig >> %LOGFILE%
if exist %MY_PACKAGES_FOLDER%\ClientBin\BSUi.BusinessSystemCenter.WinCE.exe.config if exist %MY_PACKAGES_FOLDER%\ClientBin\BSUi.BusinessSystemCenter.WinCE.zip %ibasTools%\7Zip\7z.exe a -tzip %MY_PACKAGES_FOLDER%\ClientBin\BSUi.BusinessSystemCenter.WinCE.zip -r %MY_PACKAGES_FOLDER%\ClientBin\BSUi.BusinessSystemCenter.WinCE.exe.config >> %LOGFILE%
if exist %MY_PACKAGES_FOLDER%\ClientBin\BSUi.BusinessSystemCenter.B1Addon.x64.exe.config if exist %MY_PACKAGES_FOLDER%\ClientBin\BSUi.BusinessSystemCenter.B1Addon.zip %ibasTools%\7Zip\7z.exe a -tzip %MY_PACKAGES_FOLDER%\ClientBin\BSUi.BusinessSystemCenter.B1Addon.zip -r %MY_PACKAGES_FOLDER%\ClientBin\BSUi.BusinessSystemCenter.B1Addon.x64.exe.config >> %LOGFILE%
if exist %MY_PACKAGES_FOLDER%\ClientBin\BSUi.BusinessSystemCenter.B1Addon.x86.exe.config if exist %MY_PACKAGES_FOLDER%\ClientBin\BSUi.BusinessSystemCenter.B1Addon.zip %ibasTools%\7Zip\7z.exe a -tzip %MY_PACKAGES_FOLDER%\ClientBin\BSUi.BusinessSystemCenter.B1Addon.zip -r %MY_PACKAGES_FOLDER%\ClientBin\BSUi.BusinessSystemCenter.B1Addon.x86.exe.config >> %LOGFILE%


REM 更新模块的框架引用
for /f %%u in ('dir /a:d /b %WORK_FOLDER%') DO (
if exist %%u\bin\BOBas.BusinessObjectsCommon.dll if exist %MY_PACKAGES_FOLDER%\bin\BOBas.BusinessObjectsCommon.dll copy /y %MY_PACKAGES_FOLDER%\bin\BOBas.BusinessObjectsCommon.dll %%u\bin\ >> %LOGFILE%
if exist %%u\bin\BSBas.BusinessSystemCommon.dll if exist %MY_PACKAGES_FOLDER%\bin\BSBas.BusinessSystemCommon.dll copy /y %MY_PACKAGES_FOLDER%\bin\BSBas.BusinessSystemCommon.dll %%u\bin\ >> %LOGFILE%
if exist %%u\bin\BOLS.BusinessSystemCenter.dll if exist %MY_PACKAGES_FOLDER%\bin\BOLS.BusinessSystemCenter.dll copy /y %MY_PACKAGES_FOLDER%\bin\BOLS.BusinessSystemCenter.dll %%u\bin\ >> %LOGFILE%
if exist %%u\bin\BORep.BusinessSystemCenter.dll if exist %MY_PACKAGES_FOLDER%\bin\BORep.BusinessSystemCenter.dll copy /y %MY_PACKAGES_FOLDER%\bin\BORep.BusinessSystemCenter.dll %%u\bin\ >> %LOGFILE%

for /f %%l in ('dir /a /b %SYSTEM_CENTER%\Libraries\BOBas.BusinessObjectsCommon.DB.*.zip') DO (
if exist %%u\bin %ibasTools%\7zip\7z.exe x %SYSTEM_CENTER%\Libraries\%%l -o%%u\bin -aoa >> %LOGFILE%
)
)

:END

REM 更新授权文件到所有wcf服务
for /f %%u in ('dir /a:d /b %WORK_FOLDER%') DO (
if exist %WORK_FOLDER%\license.txt copy /y %WORK_FOLDER%\license.txt %%u\ >> %LOGFILE%
)

REM 更新iis相关配置
SET IIS_SITE_NAME=%WORK_FOLDER%
SET IIS_APPPOOL_NAME=%IIS_SITE_NAME%
SET IIS_APPCMD=%WINDIR%\System32\inetsrv\appcmd.exe
if not exist %IIS_APPCMD% GOTO END_IIS
if not exist %WORK_FOLDER%\web.config GOTO END_IIS
for /f "delims=" %%i in ('cd') do SET IIS_SITE_NAME=%%~ni
SET IIS_APPPOOL_NAME=%IIS_SITE_NAME%
GOTO NOT_CREATE_SITE
REM 创建网站
%IIS_APPCMD% add apppool /name:%IIS_APPPOOL_NAME% >> %LOGFILE%
%IIS_APPCMD% add site /name:%IIS_SITE_NAME% /physicalPath:%WORK_FOLDER% >> %LOGFILE%

:END_SITE
REM 创建应用程序
for /f %%u in ('dir /a:d /b %WORK_FOLDER%') DO (
echo 创建应用程序 %%u
if not %%u==~packages if not %%u==Tools %IIS_APPCMD% add app /site.name:%IIS_SITE_NAME% /path:/%%u /physicalPath:%WORK_FOLDER%%%u >> %LOGFILE%
)
:NOT_CREATE_SITE
echo 重启网站：%IIS_SITE_NAME%
echo 重启网站：%IIS_SITE_NAME% >> %LOGFILE%
%IIS_APPCMD% stop site /site.name:%IIS_SITE_NAME% >> %LOGFILE% && %IIS_APPCMD% start site /site.name:%IIS_SITE_NAME% >> %LOGFILE%
echo 重启应用程序池：%IIS_APPPOOL_NAME%
echo 重启应用程序池：%IIS_APPPOOL_NAME% >> %LOGFILE%
%IIS_APPCMD% stop apppool /apppool.name:%IIS_APPPOOL_NAME% >> %LOGFILE% && %IIS_APPCMD% start apppool /apppool.name:%IIS_APPPOOL_NAME% >> %LOGFILE%

:END_IIS

REM 创建网站入口文件
if not exist %WORK_FOLDER%\index.html call :CREATE_INDEX_HTML

echo 结束运行脚本/%OPNAME%
REM start notepad.exe %LOGFILE%
GOTO :EOF
REM 网站入口文件内容
:CREATE_INDEX_HTML
echo ^<html^> >%WORK_FOLDER%\index.html
echo ^<head^> >>%WORK_FOLDER%\index.html
echo ^<title^>ibas^</title^> >>%WORK_FOLDER%\index.html
echo ^<script language="javascript" type="text/javascript"^>window.location.href="SystemCenter/main.html";^</script^> >>%WORK_FOLDER%\index.html
echo ^</head^> >>%WORK_FOLDER%\index.html
echo ^<body^> >>%WORK_FOLDER%\index.html
echo ^</body^> >>%WORK_FOLDER%\index.html
echo ^</html^> >>%WORK_FOLDER%\index.html
