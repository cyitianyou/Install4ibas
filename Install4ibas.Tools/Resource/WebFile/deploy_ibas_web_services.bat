@echo off
setlocal EnableDelayedExpansion
echo ********************************************************************************  
echo           deploy_ibas_web_services 
echo                         by niuren.zhu  
echo                         2014.10.22
echo ����ibas������Ϊweb����ʹ��˵��
echo     1. ���ñ�����������ibasTools������֤����7Zip\7zip.exe��
echo     2. �½��ļ��У������˽ű������С�
echo     3. ���нű����ű����ʼ������Ҫ���ļ��С�
echo     4. ��http://ibas-dev.avatech.com.cn:8866 ���ط���������~packagesĿ¼�¡�
echo     5. ���нű���ģ��ͻᱻ��ѹ�����ļ����С�
echo     6. iis���½���վ�����Ѹ�Ŀ¼ָ�������ļ��С�
echo     7. ��iis��վ�е�ģ��Ŀ¼���Ҽ�����˵���ѡ��תΪӦ�ó���
echo     8. �޸�SystemCenterĿ¼�µ�ServiceInformations.config�������ģ����Ϣ��
echo     9. ʹ��BTulz.Transform����ģ������ṹ��xml�ļ���ÿ��ģ���DataStructures�ļ����¡�
echo    10. ִ��DataStructures\SQLs\�ļ����µ�sql�ű���ע�����ݿ�ƽ̨��

echo  ��ע��
echo      SystemCenter�µ�DataStructures��ִ��basis�ļ������ݣ���ִ��system���ݣ���ִ��sqls�ű���
echo      svc�ļ��޷�����������%WINDIR%\Microsoft.NET\Framework\v4.0.30319\aspnet_regiis.exe -i��
echo ********************************************************************************    
REM hh�������ȡСʱ���ܳ��ֿո������(�賿1�㵽����9��%time:~0,2%������ֿո�)  
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

echo ������־ - %OPNAME% > %LOGFILE%
echo ****************************************************** >> %LOGFILE%
echo ��ʼ���нű�/%OPNAME%
echo ��ʼ�����л���
if exist %WORK_FOLDER%Tools\7zip\7z.exe SET ibasTools=%WORK_FOLDER%Tools
if not exist "%ibasTools%\7zip\7z.exe" SET MY_ERROR=YES
if not exist "%ibasTools%\7zip\7z.exe" echo ����û�����ý�ѹ����  >> %LOGFILE%
if not exist "%ibasTools%\7zip\7z.exe" echo ����û�����ý�ѹ���ߣ������û�������ibasTools������֤����"%ibasTools%\7zip\7z.exe"��
if not exist "%ibasTools%\7zip\7z.exe" PAUSE

if %MY_ERROR%==YES GOTO END
:CHECK_DONE
echo ��ʼ�������Ŀ¼ - %PACKAGES_FOLDER%
if not exist %PACKAGES_FOLDER% md %PACKAGES_FOLDER% >> %LOGFILE%
echo >%PACKAGES_FOLDER%\��������ڴ�Ŀ¼
if not exist %PACKAGES_TEMP_FOLDER% md %PACKAGES_TEMP_FOLDER% >> %LOGFILE%
if not exist %PACKAGES_BACKUP_FOLDER% md %PACKAGES_BACKUP_FOLDER% >> %LOGFILE%
echo >%PACKAGES_BACKUP_FOLDER%\���������Ŀ¼
if not exist %MY_PACKAGES_BACKUP_FOLDER% md %MY_PACKAGES_BACKUP_FOLDER% >> %LOGFILE%

echo ���������л���

:DEPLOY_MODULES
if not exist %PACKAGES_FOLDER%\ibas_4_modules_published_*.zip GOTO DEPLOY_SHELL
for /f %%m in ('dir /a /b %PACKAGES_FOLDER%\ibas_4_modules_published_*.zip') DO (
echo ���ڴ���������%%m
REM ȡģ�����ƣ��˴������漰�ӳٴ�������
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
echo ���ڴ���������%%m

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


REM ����ģ��Ŀ������
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

REM ������Ȩ�ļ�������wcf����
for /f %%u in ('dir /a:d /b %WORK_FOLDER%') DO (
if exist %WORK_FOLDER%\license.txt copy /y %WORK_FOLDER%\license.txt %%u\ >> %LOGFILE%
)

REM ����iis�������
SET IIS_SITE_NAME=%WORK_FOLDER%
SET IIS_APPPOOL_NAME=%IIS_SITE_NAME%
SET IIS_APPCMD=%WINDIR%\System32\inetsrv\appcmd.exe
if not exist %IIS_APPCMD% GOTO END_IIS
if not exist %WORK_FOLDER%\web.config GOTO END_IIS
for /f "delims=" %%i in ('cd') do SET IIS_SITE_NAME=%%~ni
SET IIS_APPPOOL_NAME=%IIS_SITE_NAME%
GOTO NOT_CREATE_SITE
REM ������վ
%IIS_APPCMD% add apppool /name:%IIS_APPPOOL_NAME% >> %LOGFILE%
%IIS_APPCMD% add site /name:%IIS_SITE_NAME% /physicalPath:%WORK_FOLDER% >> %LOGFILE%

:END_SITE
REM ����Ӧ�ó���
for /f %%u in ('dir /a:d /b %WORK_FOLDER%') DO (
echo ����Ӧ�ó��� %%u
if not %%u==~packages if not %%u==Tools %IIS_APPCMD% add app /site.name:%IIS_SITE_NAME% /path:/%%u /physicalPath:%WORK_FOLDER%%%u >> %LOGFILE%
)
:NOT_CREATE_SITE
echo ������վ��%IIS_SITE_NAME%
echo ������վ��%IIS_SITE_NAME% >> %LOGFILE%
%IIS_APPCMD% stop site /site.name:%IIS_SITE_NAME% >> %LOGFILE% && %IIS_APPCMD% start site /site.name:%IIS_SITE_NAME% >> %LOGFILE%
echo ����Ӧ�ó���أ�%IIS_APPPOOL_NAME%
echo ����Ӧ�ó���أ�%IIS_APPPOOL_NAME% >> %LOGFILE%
%IIS_APPCMD% stop apppool /apppool.name:%IIS_APPPOOL_NAME% >> %LOGFILE% && %IIS_APPCMD% start apppool /apppool.name:%IIS_APPPOOL_NAME% >> %LOGFILE%

:END_IIS

REM ������վ����ļ�
if not exist %WORK_FOLDER%\index.html call :CREATE_INDEX_HTML

echo �������нű�/%OPNAME%
REM start notepad.exe %LOGFILE%
GOTO :EOF
REM ��վ����ļ�����
:CREATE_INDEX_HTML
echo ^<html^> >%WORK_FOLDER%\index.html
echo ^<head^> >>%WORK_FOLDER%\index.html
echo ^<title^>ibas^</title^> >>%WORK_FOLDER%\index.html
echo ^<script language="javascript" type="text/javascript"^>window.location.href="SystemCenter/main.html";^</script^> >>%WORK_FOLDER%\index.html
echo ^</head^> >>%WORK_FOLDER%\index.html
echo ^<body^> >>%WORK_FOLDER%\index.html
echo ^</body^> >>%WORK_FOLDER%\index.html
echo ^</html^> >>%WORK_FOLDER%\index.html
