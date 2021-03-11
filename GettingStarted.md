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
using (var client = new SinumerikClient("s840d.sl://192.168.0.80")) {
    client.Connect();

    var position = client.ReadValue("/Channel/MachineAxis/measPos1[u1, 1]");
    Console.WriteLine($"Current Position of Axis 1 is {position} mm");
}
```
