#!/usr/bin/python
#-*- coding: utf-8 -*-

#生成Java和CSharp所需要的MessageID文件
#添加C++所需要的MessageID文件：HOpCode.h

import os
import sys
import string

## 生成PBMessageID.java 和 PacketDistributed.cs 以及PBMessageID.cs
start_index = 0
logFile=open(".\\logs\\generator.log", 'w')
logFile.truncate()

##-------------java 方法 code 生成----------
def generateOpCode(lines,start_index,java_class_name):
	for line in lines:		
		if line.startswith("message"):
			text = line.split(' ')
			if text[1].find("\n") > 0:
				message_name = text[1].split("\n")
			else:
				message_name = text[1]
			newCSharpFile.write( "\t\t%s = %s,\n" % (message_name[0],start_index))
			newJavaFile.write( "\t@ProbuffMsg(className=\"com.mile.common.message." +java_class_name+"."+message_name[0]+"\")\n")
			newJavaFile.write( "\tpublic static final short %s = %s;\n" % (message_name[0],start_index))
			start_index = start_index + 1
			print message_name[0]	
	
##-------------java 方法 code 生成结束----------
##-------------c++ 方法 code 生成----------
def generateCPlusOpCode(lines,start_index):
	for line in lines:		
		if line.startswith("message"):
			text = line.split(' ')
			if text[1].find("\n") > 0:
				message_name = text[1].split("\n")
			else:
				message_name = text[1]			
			newCPlusFile.write( "\t\t %s = %s,\n" % (message_name[0],start_index))
			#LWServerRegist = 9001,
			newCPlusFile.write("\t")
			start_index = start_index + 1
			print message_name[0]	
	
##-------------c++ 方法 code 生成结束----------
#-------------------------临时添加Enum在这里开始-------------------------
def generateEnum(lines):
	inEnum = False
	for line in lines:
		if line.find("enum ") > 0:
			inEnum = True
			newCSharpFile.write( "\tpublic %s" % (line))
			print line
		elif inEnum == True:
			if line.find("}") > 0:
				inEnum = False
			if line.find(";") > 0:
				line = line.split(';')
				line = "%s,\n" % (line[0])
			newCSharpFile.write( "\t%s" % (line))
			print line
#-------------------------临时添加Enum在这里结束-------------------------
#-------------------------临时添加PacketDistributed在这里开始-------------------------
def generateCsPacket(lines):		
	#遍历生成case
	for line in lines:
		if line.startswith("message"):
			text = line.split(' ')
			if text[1].find("\n") > 0:
				message_name = text[1].split("\n")
			else:
				message_name = text[1]
			PacketDistributedFile.write( "\t\t\tcase MessageID.%s: { packet = new %s();}break;\n" % (message_name[0],message_name[0]))
	
	
#-------------------------临时添加PacketDistributed在这里结束-------------------------
#############################################begin############################################
#-------------------------临时添加PacketDistributed在这里开始-------------------------
java_class_name = "HOpCodeEx.java"
cplus_class_name = "HOpCode.h" ## c++文件
cs_class_name = "MessageID.cs"
PacketDistributed_class_name = "PacketDistributed.cs"
if os.path.exists(PacketDistributed_class_name):
	os.remove(PacketDistributed_class_name)
#-------------------------临时添加PacketDistributed在这里结束-------------------------

# 1、初始化CS文件
newCSharplines = []
newCSharpFile = open(cs_class_name,"wb") 
newCSharpFile.write("//Auto Generate File, Do NOT Modify!!!!!!!!!!!!!!!\n")
newCSharpFile.write("using System;\n")
newCSharpFile.write("namespace com.mile.common.message \n")
newCSharpFile.write("{\n")
newCSharpFile.write("\tpublic enum MessageID\n")
newCSharpFile.write("\t{\n")

# 2、初始化JAVA文件

newJavaFile = open(java_class_name,"wb") 
newJavaFile.write("package com.mile.common.message;\n")
newJavaFile.write("import com.mile.mlf.annotation.ProbuffMsg;\n")
newJavaFile.write("//Auto Generate File, Do NOT Modify!!!!!!!!!!!!!!!\n")
newJavaFile.write("import com.mile.mlf.net.packet.HOpCode;\n")
newJavaFile.write("public class HOpCodeEx extends HOpCode {\n")


# 3、初始化C++文件
newCPlusFile = open(cplus_class_name,"wb") 
newCPlusFile.write("//Auto Generate File, Do NOT Modify!!!!!!!!!!!!!!!\n")
newCPlusFile.write("namespace protobuf \n")
newCPlusFile.write("{ \n")
newCPlusFile.write("namespace message \n")
newCPlusFile.write("{ \n")
newCPlusFile.write("\t enum MessageID \n")
newCPlusFile.write("\t\t{ \n")

# 4、初始化CS文件 PacketDistributedFile
PacketDistributedFile = open(PacketDistributed_class_name,"wb") 
PacketDistributedFile.write("//Auto Generate File, Do NOT Modify!!!!!!!!!!!!!!!\n")
PacketDistributedFile.write(
'''
using System.IO;
using System;
using System.Net.Sockets;
using Google.ProtocolBuffers;
using com.mile.common.message;

	public abstract class PacketDistributed\n
	{

		public static PacketDistributed CreatePacket(MessageID packetID)
		{
			PacketDistributed packet = null;
			switch (packetID)
			{
'''	)
# 3、遍历生成ID##################循环开始################################
	
for filename in os.listdir("./protofiles"):
	suffix = filename.split('.')[1]
	if suffix!= "proto":	
		print filename + " ignored..."
		continue
	print "++++++++++++++protofile:[" + filename+"] process is beginning++++++++++++++"
	proto_file = open("./protofiles/" + filename,"r")
	lines = proto_file.readlines()
	for line in lines:
		#Index = (line.split(','))
		#print Index	
		if line.find('@module=') != -1 and line.find('StartIndex=') != -1 and line.find('classname=') != -1:
			Index = (line.split(','))
			print Index			
			module = Index[0].split('=')[1]			
			startIndex = Index[1].split('=')[1]
			start_index = string.atoi(startIndex)
			
			class_name = Index[2].split('=')[1]		
				
			java_class_name = (filename+"").split('.')[0]
			print "====module:[" + module + "],start_index:[" + startIndex+"],java_class_name:[" + java_class_name+"]"
			#cs_class_name = (class_name).replace('\n','')						
			#generateOpcode(java_class_name,cs_class_name,lines, start_index)
			break		
	#-----循环生成------
	generateOpCode(lines,start_index,java_class_name)
	generateCPlusOpCode(lines,start_index)
	#generateEnum(lines)
	generateCsPacket(lines)
	
	print "++++++++++++++protofile:[" + filename+"] process is success++++++++++++++"		
	if start_index == 0:
		print 'exit with error,StartIndex must be set!!!'
		exit()
	#关闭protofile文件
	proto_file.close()

	
#java文件结束
newJavaFile.write("\n}\n")
newJavaFile.close()
# c++文件结束
newCPlusFile.write("\n		};\n")
newCPlusFile.write("\n}\n")
newCPlusFile.write("\n}\n")
newCPlusFile.close()

#c sharp文件结束
newCSharpFile.write("\n\t}\n")	
##重新循环文件生成枚举 begin
for filename in os.listdir("./protofiles"):
	suffix = filename.split('.')[1]
	if suffix!= "proto":	
		print filename + " ignored..."
		continue
	print "++++++++++++++protofile:[" + filename+"] process is beginning++++++++++++++"
	proto_file = open("./protofiles/" + filename,"r")
	lines = proto_file.readlines()	
	generateEnum(lines)
##重新循环文件生成枚举 end

newCSharpFile.write("\n\t}\n")	
newCSharpFile.close()
#c shart distributedPacket 文件结束
PacketDistributedFile.write(
'''
		}
		if (null != packet)
		{
			packet.packetID = packetID;
		}
		//netActionTime = DateTime.Now.ToFileTimeUtc();
		return packet;
	}
   
	public byte[] ToByteArray()
	{
		//Check must init
		if (!IsInitialized())
		{
			throw InvalidProtocolBufferException.ErrorMsg("Request data have not set");
		}
		byte[] data = new byte[SerializedSize()];
		CodedOutputStream output = CodedOutputStream.CreateInstance(data);
		WriteTo(output);
		output.CheckNoSpaceLeft();
		return data;
	}
	public PacketDistributed ParseFrom(byte[] data)
	{
		CodedInputStream input = CodedInputStream.CreateInstance(data);
		PacketDistributed inst = MergeFrom(input,this);
		input.CheckLastTagWas(0);
		return inst;
	}

	public abstract int SerializedSize();
	public abstract void WriteTo(CodedOutputStream data);
	public abstract PacketDistributed MergeFrom(CodedInputStream input,PacketDistributed _Inst);
	public abstract bool IsInitialized();

	protected MessageID packetID;

	public MessageID getMessageID()
	{ 
		return packetID;
	}
}
'''
	)
PacketDistributedFile.close()
logFile.close()		
# 3、遍历生成ID##################循环结束################################
