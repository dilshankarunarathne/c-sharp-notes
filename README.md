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

```cs
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
```

</details>

All these attributes are for assembly identification or assembly manifest. 

Under references tab, you will be able to see any assemblies that the project is referencing.  

There will be an `App.config` XML file where the application's configurations will be saved. Sometimes, you might want to save connection strings to a database or you might want to save some settings for the application. All that should be end up here.  

There is also an **Object Browser** in VS. We can use it to look at various namespace and their member definitions in our project or in any library-framework we're using. 

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

# Variables & Data Types 

![](assets/02-data-types.png)  

Each C# types maps to their corresponding .Net types. When we compile our application, the compiler will convert our C# types into their equivalent .NET types.  

Double is the default floating point data type in C#. If we want a float or a decimal, we need to explicitly tell the compiler that by post-fixing the value with `f` or `m`.  

C# don't have overflow checking. If we increment a number out of its type range at runtime, it will overflow. For example, if we increment a `byte` variable's value from 255 to 255+1, it's final value would be set to 0.  
If we don't want overflowing to happen, we need to use the `checked` keyword and enclose our operation within a block. In that case, the value will not overflow, instead it will throw an exception. 

```cs
checked 
{
	byte number = 255;
	number = number + 1;
}
```

<br /> 

There is a `var` keyword in C#. Instead of explicitly specifying the data type, we can use this keyword. 

We can use **format strings** in C# for easier console outputs. 
```cs
Console.WriteLine("Byte Min:{0} and Max:{1}", byte.MinValue, byte.MaxValue);
```

We can declare constant values using `const` keyword. This keyword comes before the data type. 

## Type Conversion 

There are times that you need to temporarily convert the value of a variable to a different type. Note that this conversion does not impact the original variable since C# is a statically-typed language, which in simple term means: *once you declare the type of a variable, you cannot change it*. But you may need to convert the "value" of a variable as part of assigning that value to a variable of a different type.  

There are a few conversion scenarios: 
* If types are compatible (e.g. integral numbers and real numbers) and the target type is bigger, you don't need to do anything. The value will be automatically converted by the runtime and stored in the target type.
```cs
byte b = 1;
int i = b;
```
Here because b is a byte and takes only 1 byte of memory, we can easily convert it to an int, which takes 4 bytes. So we don't need to do anything. 
* If the target type, however, is smaller than the source type, the compiler will generate an error. The reason for that is that overflow may happen as part of the conversion. For example, if you have an int with the value 1000, you cannot store it in a byte because the max value a byte can store is 255. In this case, some of the bits will be lost in memory. And that's the reason compiler warns you about these scenarios. If you're sure that no bits will be lost as part of the conversion, you can tell the compiler that you're aware of the overflow and would still like the conversion to
happen. In this case, you use a cast:
```cs
int i = 1;
byte b = (byte)i;
```
In this example, our int holds the value 1, which can perfectly be stored in a byte. So, we use a cast to tell the compiler to ignore the overflow. A cast means prefixing the variable with the target type. So here we are casting the variable i to a byte in the second line.
* Finally, if the source and target type are not compatible (eg a string and a number), you need to use the Convert class.
```cs
string s = “1234”;
int i = Convert.ToInt32(s);
```

**Convert** class has a number of methods for converting values to various types. `ToByte()`, `ToInt16()`, `ToInt32()`,`ToInt64()`.  
All primitive types have `Parse()` methods. 
```cs
string s = "1";
int i = Convert.ToInt32(s);
int j = int.Parse(s);
```

```cs
try 
{
	var number = "1234";
	byte b = Convert.ToByte(number);
	Console.WriteLine(b);
}
catch (Exception)
{
	Console.WriteLine("The number could not be converted to byte.");
}
```

# Classes 

Classes are building blocks of our applications. A class combines related variables (also called fields, attributes or properties) and functions (methods) together.  
Note: fields and properties are technically different in C# but conceptually they mean the same thing. They represent attributes about a class.  
An object is an instance of a class. At runtime, many objects collaborate with each other to provide some functionality. 
Note that even though there is a slight different between the word Class and Object, these words are often used interchangeably.  
To create a class:
```cs
public class Person
{
	public string Name;

	public void Introduce()
	{
		Console.WriteLine(“My name is “ + Name);
	}
}
```

Here, public is what we call an access modifier. It determines whether a class is visible to other classes or not.  
Here void means this method does not return a value.  
To create an object, we use the new operator:
```cs
Person person = new Person();
```
A cleaner way of writing the same code is:
```cs
var person = new Person();
```

We use the new operator to allocate memory to an object. In C# you don’t have to worry about de-allocating the memory. CLR has a component called Garbage Collector, which automatically removes unused objects from memory. 

## The Static Modifier 

When applied to a class member (field or method), makes that member accessible only via the class, not any objects.  
We use static members in situations where we want only one instance of that member to exist in memory. As an example, the Main method in every program is declared as static, because we need only one entry point to the application.  
In the real-world, it’s best to stay away from static as much as you can because that makes writing automated tests for applications hard. 

# Structs 

A struct (structure) is a type similar to a class. It combines related fields and methods together.
```cs
public struct RgbColor
{
	public int Red;
	public int Green;
	public int Blue;
}
```
Use structs only when creating small lightweight objects. That is for a subtle performance optimization. In the real-world, 99% of the time, you create new types using classes, not structures.  
In .NET, all primitive types are declared as a structure. They are small and lightweight. The biggest primitive type doesn’t take more than 16 bytes. 

# Arrays 

An array is a data structure that is used to store a collection of variables of the same type. For example, instead of declaring three int variables (that are related), we can create an int array like this:
```cs
int[] numbers = new int[3];
```

An array in C# is actually an instance of the Array class. So, that’s why here we have to use the new operator to allocate memory to this object.  
Here, the number 3 specifies the size of the array. Once an array is created, its size cannot be changed. If you need a list with dynamic size, you need to use the List class.  
To access elements in an array, we use the square bracket notation:
```cs
numbers[0] = 1;
```

Note that in C# arrays are zero-indexed. So the first element has index 0.

# Strings 

A string is a sequence of characters. In C# a string is surrounded by double quotes, whereas a character is surrounded by a single quote.
```cs
string name = “Mosh”;
char ch = ‘A’;
```

There are a few different ways to create a string:  
* Using a string literal:
```cs
string firstName = “Mosh”;
```
* Using concatenation: useful if you wanna combine two or more strings.
```cs
string name = firstName + “ “ + lastName;
```
* Using `string.Format`: cleaner than concatenating multiple strings since you can see the output.
```cs
string name = string.Format(“{0} {1}”, firstName, lastName);
```
* Using `string.Join`: useful when you have an array and would like to join all elements of that array with a character:
```cs
var numbers = new int[3] { 1, 2, 3 }
string list = string.Join(“,”, numbers);
```

<br />

C# strings are immutable, which means once you create them, you cannot change their value or any of their characters. The String class has a few methods for modifying strings, but all these methods return a new string and do not modify the original string. 

### String vs string 

Remember, all types in C# map to a type in .NET Framework. So, the “string” type in C# (all lowercase), maps to the String class in .NET, which means we can declare a string in either of the following ways:
```cs
string name;
String name;
```

The only difference is that if you use the `String` type, you need to import the `System` namespace on top of the file, because that’s where the `String` class is defined. 
```cs
using System;
```

### Escape Characters 

There are few special characters in C# called escape characters:
<pre>
\n New line
\t Tab
\\ The \ character itself
\’ The ‘ (single quote) character
\" The “ (double quote) character
</pre>
So if you want to have a new line in your string, you use \n.  
Since the backslash character is used to prefix escape characters, if you want to use the backslash character itself in your string (eg path to a folder), you need to prefix it with another backslash:
```cs
string path = “c:\\folder\\file.txt”;
```

### Verbatim Strings 

Sometimes if there are many escape characters in a string, that string becomes hard to read and understand.
```cs
var message = “Hi John\nLook at the following path:c:\\folder1\\folder2”; 
```

Note the \n and double backslashes (\\) here. We can re-write this string using a verbatim string. We simply prefix our string with an @ sign, and get rid of escape characters:
```cs
var message = @“Hi John
Look at the following path:
c:\folder1\folder2”;
```

# Reference Types and Value Types 

In C#, we have two main types from which we can create new types: classes and structures (structs).  
Classes are Reference Types while structures are Value Types.

## Value Types 

When you copy a value type to another variable, a copy of the value stored in the source variable is taken and stored in the target variable. Hence, these two variables will be independent.
```cs
var i = 10;
var j = i;
j++;
```
Here, incrementing j does not impact i. 

In practical terms, it means: if you pass an argument to a method and that argument is a value type, its value will be copied. So any modifications made to that argument in the method will be lost upon returning from that method.  

Remember: Primitive types are structures so they are value types. Any custom structure you define will also be a value type. 

## Reference Types 

With a reference type, however, the reference (or memory address) of the object is copied to the target variable. This means: if you copy a reference type to another variable, any changes you make to the object referenced by either of these variables, will be visible through the other variable. 
```cs
var array1 = new int[3] { 1, 2, 3 };
var array2 = array1;
array2[0] = 0;
```

Here, both array1 and array2 reference (or point) the same array object in memory. So, after the third line, the first element of both array1 and array2 will be 0. 

Remember: arrays and strings are classes, so they are reference types. Any custom classes you define will also be a value type.

# Enums 

An enum is a data type that represents a set of name/value pairs. Use enums when you need to define multiple related constants. 
```cs
public enum ShippingMethod
{
	Regular = 1,
	Express = 2
}
```
Now we can declare a variable of type ShippingMethod enum and use the dot notation to initialize it: 
```cs
var method = ShippingMethod.Express;
``` 

Enums are internally integers. So you can easily cast them to and from an int: 
```cs
var methodId = 1;
var method = (ShippingMethod)methodId;
var method = ShippingMethod.Express;
var methodId = (int)method;
```

To convert an enum to a string use the ToString method. Every object in C# has this method and can be converted to a string: 
```cs
var method = ShippingMethod.Express;
var methodName = method.ToString(); 
``` 

To convert a string to an enum (called parsing), use `Enum.Parse`: 

```cs
var method = (ShippingMethod)Enum.Parse(typeof(ShippingMethod),
methodName);
```

# Conditional Statements 

```cs
if (condition) 
{
	someStatement 
}
else if (anotherCondition)
{
	anotherStatement
}
else 
{
	yetAnotherStatement
}
```

```cs
switch(role)
{
	case Role.Admin:
		...
		break;
	case Role.User:
		...
		break;
	default:
		...
		break;
}
```

# Iteration Statements 

```cs
for (var i = 0; i < 10; i++)
{
	...
}
```

```cs
foreach (var item in collection)
{
	...
}
```

```cs
while (i < 10)
{
	...
	i++;
}
```

```cs
do
{
	...
	i++;
} while (i < 10);
```

# Random 

We can use the `Random` class to generate random numbers. 

```cs
using System;

namespace CSharpFundementals 
{
    class Program 
    {
        static void Main(string[] args) 
        {
            var random = new Random();
            
            const int passwordLength = 10;

            var buffer = new char[passwordLength];
            for (int i = 0; i < passwordLength; i++)
            {
                buffer[i] = (char) ('a' + random.Next(0, 26));
            }

            var password = new string(buffer);

            Console.WriteLine(password);
        }
    }
}
```

# Arrays 

## Single Dimentional Arrays 

```cs
var numbers = new int[10];
var numbers = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
```

## Multi Dimentional Arrays 

There are two types of multi dimentional arrays in C#. 

1. Rectangular  
   Each sub array has the same number of elements.  
   For example, if you have a 3x3 matrix, you have 3 sub arrays, each with 3 elements.  
   Example: rectangular 2D array:
   ```cs
   var matrix = new int[3, 3];
   var matrix = new int[3, 3] 
   { 
		{ 1, 2, 3 }, 
		{ 4, 5, 6 }, 
		{ 7, 8, 9 } 
   };
   ```

   Example: rectangular 3D array:
   ```cs
   var matrix = new int[3, 3, 3];
   var matrix = new int[3, 3, 3] 
   {
		{ { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } },
		{ { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } },
		{ { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } }
	};
	```
2. Jagged  
   Sub arrays can have different number of elements.  
   Example: jagged 2D array:
   ```cs
   var matrix = new int[3][];
   var matrix = new int[3][] 
   {
		new int[] { 1, 2, 3 },
		new int[] { 4, 5, 6, 9 },
		new int[] { 7, 8 }
	};
	```

In C#, all arrays map to the **Array** type defined in the System namespace of .NET framework. This Array class has a property called `Length` and methods such as `Clear()`, `Copy()`, `IndexOf()`, `LastIndexOf()`, `Reverse()`, `Sort()`, `ToString()`, `Trim()`, `TrimEnd()`, `TrimStart()` and `ToArray()`.  

# Lists 

Lists in C# are similar to Arrays, but they have a dynamic size.  
List is a generic type. It can be used to store any type of data. We need to specify the type parameter inside the angle brackets. 
```cs
var numbers = new List<int>();
var numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
```

There are methods such as `Add()`, `AddRange()`, `Remove()`, `RemoveAt()`, `IndexOf()`, `Contains()` and field named `count` in the **List** class.  

# Date-Time & TimeSpan 

There is a `DateTime` structure in the System namespace of .NET framework. It is a struct that represents a date and time.  
There are a number of ways to create a DateTime object. 
```cs
var dateTime = new DateTime(2015, 1, 1);

var now = DateTime.Now;
var today = DateTime.Today;
var utcNow = DateTime.UtcNow;
var unixEpoch = DateTime.UnixEpoch;

Console.WriteLine("Hour: " + now.hour);
Console.WriteLine("Minute: " + now.minute);
```

DateTime objects in C# are immutable. They cannot be changed.  
To modify them, we need to create a new object. And there are methods to modify. 
```cs
var now = DateTime.Now;

var tomorrow = now.AddDays(1);
var yesterday = now.AddDays(-1);

Console.WriteLine(now.ToLongDateString());
Console.WriteLine(now.ToShortDateString());
Console.WriteLine(now.ToLongTimeString());
Console.WriteLine(now.ToShortTimeString());

Console.WriteLine(now.ToString("yyyy-MM-dd HH:mm:ss"));
```

We can specify the format of the string using the `ToString()` method.  

--------------------------------------------------------------------------------------------------------------------

There is also a type called `TimeSpan` that represents a duration of time. There are a few different ways to create a TimeSpan object.  
The simplest way is to use the `new` operator. One of the overloaded constructors takes a number of hours, minutes and seconds as arguments. 
```cs
var timeSpan = new TimeSpan(1, 2, 3);
var timeSpan1 = new TimeSpan(1, 0, 0);	// 1 hour, 0 represents minutes, 0 represents seconds 
```

A more readable way to create a TimeSpan object is to use the `TimeSpan.FromHours()`, `TimeSpan.FromMinutes()` and `TimeSpan.FromSeconds()` static methods.  
```cs
var timeSpan = TimeSpan.FromHours(1);
```

There is another way to create a TimeSpan object. If you have two DateTime objects, you can use the `Subtract()` method to get the duration between them. 
```cs
var start = DateTime.Now;
var end = DateTime.Now.AddHours(1);
var duration = end.Subtract(start);	// or: var duration = end - start 
Console.WriteLine("Duration: " + duration.ToString());
```

There is yet another way to create a TimeSpan object. It is called `TimeSpan.Parse()`. It takes a string as an argument and returns a TimeSpan object. 

<br />

TimeSpan objects has properties such as `TotalHours`, `TotalMinutes`, `TotalSeconds` and `TotalMilliseconds`.  
Also it has properties such as `Hours`, `Minutes`, `Seconds` and `Milliseconds`.  
For example, if you have a TimeSpan object with a duration of 1 hour, 2 minutes and 3 seconds, the `Minutes` property will return the value 2. That's the number of minutes we've added for the duration. But, if we query `TotalMinutes` property, it will return the value `62.05`.  

Similar to DateTime objects, TimeSpan objects are immutable. They cannot be changed. But they provide methods to modify their value `Add()` and `Subtract()`. Both of these methods return a new TimeSpan object. These methods takes a TimeSpan object as an argument. 
```cs
var timeSpan = TimeSpan.FromHours(1);
var timeSpan1 = timeSpan.Add(TimeSpan.FromMinutes(2));
var timeSpan2 = timeSpan.Subtract(TimeSpan.FromSeconds(3));
``` 

<br />

They can be converted to strings using the `ToString()` method and from strings to TimeSpan objects using the `Parse()` method. 
```cs
var timeSpan = TimeSpan.FromHours(1);
Console.WriteLine(timeSpan.ToString());	// don't have to include the `ToString()` method in the code - implicit conversion

var timeSpan1 = TimeSpan.Parse("1:2:3");
Console.WriteLine(timeSpan1.ToString());
```

# More about Strings 

String is an immutable class in the .NET framework. It is a class that represents a string of characters. 

## Formatting 

ToLower() and ToUpper() methods can be used to convert a string to lowercase or uppercase. There is also a `ToTitleCase()` method that converts a string to title case.  
There is also a `Trim()` method that removes leading and trailing whitespace from a string. There is also a `TrimStart()` and `TrimEnd()` methods that removes leading and trailing whitespace from a string.  

## Searching 







