echo on
echo  

echo beign to run python scripts....
python ID_Generator.py
python Msg_Generator.py


echo delete old files....
rem del .\message_output\server\*.java
del .\message_output\client\*.cs
del .\message_output\serverCplus\*.cc
del .\message_output\serverCplus\*.h


echo begin to copy Message class...
copy /y .\protofiles\*.cs .\message_output\client\*.cs
@rem copy /y .\protofiles\com\mile\common\message\*.java .\message_output\server\*.java
@rem copy /y .\message_output\server\*.java ..\..\.\Server\trunk\qmqj_parent\game-common\src\main\java\com\mile\common\message\*.java

copy /y .\protofiles\*.cc .\message_output\serverCplus\*.cc
copy /y .\protofiles\*.h .\message_output\serverCplus\*.h
copy /y .\*.h .\message_output\serverCplus\*.h


echo begin to copy Id class...
copy /y .\*.cs .\message_output\client\*.cs
@rem copy /y .\*.java .\message_output\server\*.java
@rem copy /y .\*.java ..\..\.\Server\trunk\qmqj_parent\game-common\src\main\java\com\mile\common\message\*.java

echo begin del generated temp files...
del *.cs
del *.java
del *.h

rd /s/q .\protofiles\com
del .\protofiles\*.cs
@rem
del .\protofiles\*.cc
del .\protofiles\*.h

rd /s/q ProtocolCommon


pause