# Introduction to C# and .NET 

C# is a programming language. Before C#, there were two languages in the C family - C and C++. With either of C/C++ languages, when we compile our application - the compiler translates our code into the native machine code.  
With languages like Java, the compilation outputs into an intermediate bytecode. With this theory, our compiled output would not be dependent on the hardware.  
And, C# has the same technique. When we compile C# source code, it translates into **IL** code which stands for *Intermediate Language*.  
But now we need something that translates the IL code, into the native language that can run on the machine. And that is the job of CLR. So, CLR is essentially an application that translates IL code into machine code by **JIT**ting.  

.NET is a framework for building applications on Windows. This framework is not limited to C#. There are many languages that can target .NET framework and build applications with it.  
The .NET framework consists of two main components. 
1. CLR - Common Language Runtime 
2. Class Library 

# Application Architecture 

At very high level, the architecture of a C# application consists of classes. A class is a container that can hold some data - which is also called attributes, and functions which is also called methods.  
These functions/methods add behavior by execution/doing-things for us.  
Data represents the state of the application.  

As the number of classes in our application grows, we need a way to organize these classes. That's why we need **namespaces**. A namespace is a container for related classes.  
In a real-world application, as these namespaces grow - we need another way of partitioning our application. That's where we use an **Assembly**. An assembly is a container for related namespaces. Physically, it's a file on the disk - which can either be an executable (EXE) or a dynamicaly linked library (DLL). So, when we compile an application - the compiler will build one or more assemblies depending on how we partition our code. 

# The Visual Studio IDE 

VS is highly recommended for C# developing.  

![](assets/01-vs-ide.png)  

In its solution explorer, You will be able to see `AssemblyInfo.cs` file. It contains all the information for an assembly that can be created with your project. If you ever think of distributing an assembly, you should probably fill all the details in there.  

<details>
<summary><code>AssemblyInfo.cs</code></summary>
<code class="language-c">
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("MyApplication")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("MyApplication")]
[assembly: AssemblyCopyright("Copyright ©  2022")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible
// to COM components.  If you need to access a type in this assembly from
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("69cc4d47-fe93-4767-8131-cc5fe73a4a50")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]
</code>
</details>

All these attributes are for assembly identification or assembly manifest. 

Under references tab, you will be able to see any assemblies that the project is referencing.  

There will be an `App.config` XML file where the application's configurations will be saved. Sometimes, you might want to save connection strings to a database or you might want to save some settings for the application. All that should be end up here.  

# Basic C# 

We write classes for our application in some namespace. If we want to use classes from other namespaces in our application - we can use the `using` keyword to refer to them. 

```cs
using System;

namespace MyApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
        	Console.WriteLine("Hello, World!");
        }
    }
}
``` 

The class `Console` can be used to read data from the console or to write data to it. 

