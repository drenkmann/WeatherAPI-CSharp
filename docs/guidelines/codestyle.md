# Code Style
Generally, please follow the code <a href="https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions" target="_blank">guidelines</a> set by Microsoft.
The most important parts are also listed below.

## Naming conventions
- Async functions that retrieve data from the API should follow the naming scheme GetWeather{endpoint}Async
- All functions and classes should follow PascalCase (e.g. GetWeatherCurrentAsync)
- All internal/private variables should follow camelCase, prefixed with an underscore _ (e.g. _apiKey)
- All public variables should follow PascalCase

## Type conventions
- Where possible and sensible, use var instead of explicit typing
```csharp
var _apiKey = "API-KEY"; // Do this
string _apiKey = "API-KEY"; // Not this
```

## Layout conventions
- Use BSD style brackets
```csharp
// Do this
if (condition)
{
	DoStuff();
}
// Not this
if (condition) {
	DoStuff();
}
```
- Single line if statements can be used without brackets
```csharp
// This is ok
if (condition)
	DoStuff();
```
- Using directives should be placed at the beginning of the file
- Namespaces should be used file wide (`namespace TheNamespace;`)

## Documentation and commenting conventions
- All public or protected members should be documented
- Functions should be documented using XML comments with a summary, return type (if not void), and any given parameters
```csharp
/// <summary>Does stuff</summary>
/// <param name="abc">A string that does stuff</param>
/// <returns>A string modified with <paramref name="abc" /></returns>
public string DoStuff(string abc)
```
- Other class members should be documented with `<value>Short description</value>`
