# Getting started

## 1. Create Solution

```bash
dotnet new sln

mkdir NcApp
cd NcApp
dotnet new console
dotnet add package SinumerikNet.Advanced

cd ..
dotnet sln add ./NcApp/NcApp.csproj

```

## 2. Implement NC App

```csharp
var device = new SinumerikDevice("192.168.0.80");

using (var connection = device.CreateConnection()) {
    connection.Open();
    Console.WriteLine("Device connection is opened...");
    
    var position = connection.ReadDouble("/Channel/MachineAxis/measPos1[u1, 1]");
    Console.WriteLine($"Current Position of Axis 1 is {position} mm");
}
```
