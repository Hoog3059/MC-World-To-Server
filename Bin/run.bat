@echo off  
title SERVER
echo Ignore the first java error messages!!
java -Xmx1024M -XX:MaxPermSize=128M -jar server.jar -o false
PAUSE