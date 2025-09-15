@echo off   
color a   
@echo start regist TeeChart8.ocx  
cd /d %~dp0
copy TeeChart8.ocx  %SystemRoot%\SysWOW64\ /Y
regsvr32  "%SystemRoot%\SysWOW64\TeeChart8.ocx"  
echo Registration completed, press any key to exit
exit  