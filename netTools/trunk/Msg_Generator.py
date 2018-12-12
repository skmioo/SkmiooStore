#!/usr/bin/python
#-*- coding: utf-8 -*-

#生成Java和CSharp所需要的Message文件

import os
import sys
import string

print "delete old dir and files ..."
#os.system("rd /s/q .\\protofiles\\com")
#os.system("del /s/q .\\protofiles\\*.cs")
#exit()

logFile=open(".\\logs\\generator.log", 'w')
sys.stdout=logFile
##########################java generate java Message files begin ##########################
for filename in os.listdir("./protofiles"):
	print "++++++++++++++protofile:[" + filename+"] is beginning++++++++++++++"		
	proto_file = ("./protofiles/" + filename ).replace('\n','')		
	print("proto_file:"+proto_file)
	#os.system("protoc.exe --java_out=.\\protofiles\\ PBMessage.proto")
	os.system("protoc.exe -I=.\protofiles --java_out=.\\protofiles\\ "+proto_file)
	print "protoc.exe -I=.\protofiles --java_out=.\\protofiles\\ "+proto_file
	print "Generated success!![" +proto_file +"]"
##########################java generate java Message files begin ##########################

##########################cs   generate   cs Message files begin ##########################
	cs_filename=(filename.split('.')[0] +".cs").replace('\n','')	
	print "cs_filename:"+ cs_filename
	os.system("CodeEngine.exe -i:"+ proto_file +" -o:.\\protofiles\\"+cs_filename+" -c:csharp")
	print "Generated success!![" +cs_filename +"]"
	#CodeEngine.exe -i:PBMessage.proto -o:PBMessage.cs -c:csharp
##########################cs   generate   cs Message files end   ##########################

###-----------------------added the following at 2-14-5-4 by liguofang------------
##########################c++   generate   cs Message files begin ##########################
	print("begin generate cplus file proto_file:"+proto_file)
	os.system("protoc.exe -I=.\protofiles --cpp_out=.\\protofiles\\ "+proto_file)
	print "Generated cplus files success!![" +proto_file +"]"
logFile.close()	
##########################cs   generate   cs Message files end   ##########################




