# tdd_playground

1. Install Templates NUnit in addition to VS default NUnit .NET Core template.
2. Modify assemblyInfo.cs or any .cs file in a project to expose internal parts to testing environment:
   using System.Runtime.CompilerServices;
   [assembly: InternalsVisibleTo("UnitTestsAssembly")]
3. Use AxoCover for test coverage.