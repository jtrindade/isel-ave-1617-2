NOTE:

Compilation fails in F# with .NET Core 1.1

To correct the problem, edit the following file:

.nuget/packages/dotnet-compile-fsc/1.0.0-preview2-020000/lib/netcoreapp1.0/dotnet-compile-fsc.runtimeconfig.json

In this file, set version to "1.1.0" (instead of "1.0.0").

Compilation should then succeed.

-------

The base folder .nuget should be found in:

[Windows] %UserProfile%\.nuget
[Linux]   ~/.nuget


