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

At very high level, the architecture of a C# application consists of classes.  
A class is a container that can hold some data - which is also called attributes, and functions which is also called methods.  
These functions/methods add behavior by execution/doing-things for us.  
Data represents the state of the application.  

As the number of classes in our application grows, we need a way to organize these classes. That's why we need **namespaces**. A namespace is a container for related classes.  
In a real-world application, as these namespaces grow - we need another way of partitioning our application. That's where we use an **Assembly**. An assembly is a container for related namespaces. Physically, it's a file on the disk - which can either be an executable (EXE) or a dynamicaly linked library (DLL).  



