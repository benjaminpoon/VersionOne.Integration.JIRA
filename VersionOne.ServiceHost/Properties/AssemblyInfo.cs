/*(c) Copyright 2012, VersionOne, Inc. All rights reserved. (c)*/
using System.Reflection;
using System.Runtime.InteropServices;

[assembly: AssemblyTitle("VersionOne.ServiceHost")]

#if !DEBUG
[assembly: AssemblyDelaySign(false)]
[assembly: AssemblyKeyFile("..\\..\\..\\..\\Common\\SigningKey\\VersionOne.snk")]
[assembly: AssemblyKeyName("")]
#endif
[assembly: AssemblyCompanyAttribute("VersionOne")]
[assembly: AssemblyCopyrightAttribute("Copyright � 2015")]
[assembly: ComVisibleAttribute(false)]
