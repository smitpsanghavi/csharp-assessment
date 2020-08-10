# C# Programming Test

This repository contains a simple .Net Core Xunit test project. It has 13 test cases defined, 12 of which are initially failing. There are five places marked in the C# code files which need to be completed in order to get all tests to pass (look for _TODO_ and/or `NotImplementedException`).

The project uses some data files (contained in the repo) to preform tests against. It contains references to the `CsvHelper` and `Newtonsoft.Json` packages.

## Run Tests using .Net Core SDK

    dotnet test

Initial output will be similar to:

```
PS D:\src\csharp-assessment> dotnet test
Test run for D:\src\csharp-assessment\bin\Debug\netcoreapp3.1\csharp-assessment.dll(.NETCoreApp,Version=v3.1)
Microsoft (R) Test Execution Command Line Tool Version 16.7.0
Copyright (c) Microsoft Corporation.  All rights reserved.

Starting test execution, please wait...

A total of 1 test files matched the specified pattern.
[xUnit.net 00:00:00.46]     csharp_assessment.JsonTests.Test_GetPosition(id: "2", x: 1233, y: 0, width: 47, height: 59, z: 37000) [FAIL]
[xUnit.net 00:00:00.47]     csharp_assessment.JsonTests.Test_GetPosition(id: "1", x: 0, y: 300, width: 60, height: 60, z: 41000) [FAIL]
[xUnit.net 00:00:00.47]     csharp_assessment.JsonTests.Test_GetObjectNames(id: "1", expectedNames: ["icon", "outline", "fill", "text"]) [FAIL]
[xUnit.net 00:00:00.47]     csharp_assessment.JsonTests.Test_GetObjectNames(id: "2", expectedNames: ["icon", "fill"]) [FAIL]
[xUnit.net 00:00:00.47]     csharp_assessment.JsonTests.Test_GetTitle(id: "1", expectedTitle: "Button P5") [FAIL]
[xUnit.net 00:00:00.47]     csharp_assessment.JsonTests.Test_GetTitle(id: "2", expectedTitle: "Slicers - Close Button") [FAIL]
[xUnit.net 00:00:00.47]     csharp_assessment.CsvTests.Aggregate_promotions [FAIL]
[xUnit.net 00:00:00.48]     csharp_assessment.CsvTests.Test_LookupPromotionDiscount(region: "Asia", date: "2007-12-01", expectedDiscount: 0.15) [FAIL]
  X csharp_assessment.JsonTests.Test_GetPosition(id: "2", x: 1233, y: 0, width: 47, height: 59, z: 37000) [5ms]
  Error Message:
   System.NotImplementedException : The method or operation is not implemented.
  Stack Trace:
     at csharp_assessment.JsonTests.GetPosition(JObject config) in D:\src\csharp-assessment\UnitTest1.cs:line 102
   at csharp_assessment.JsonTests.Test_GetPosition(String id, Int32 x, Int32 y, Int32 width, Int32 height, Int32 z) in D:\src\csharp-assessment\UnitTest1.cs:line 122
  X csharp_assessment.JsonTests.Test_GetPosition(id: "1", x: 0, y: 300, width: 60, height: 60, z: 41000) [4ms]
  Error Message:
   System.NotImplementedException : The method or operation is not implemented.
  Stack Trace:
     at csharp_assessment.JsonTests.GetPosition(JObject config) in D:\src\csharp-assessment\UnitTest1.cs:line 102
   at csharp_assessment.JsonTests.Test_GetPosition(String id, Int32 x, Int32 y, Int32 width, Int32 height, Int32 z) in D:\src\csharp-assessment\UnitTest1.cs:line 122
  X csharp_assessment.JsonTests.Test_GetObjectNames(id: "1", expectedNames: ["icon", "outline", "fill", "text"]) [< 1ms]
  Error Message:
   System.NotImplementedException : The method or operation is not implemented.
  Stack Trace:
     at csharp_assessment.JsonTests.GetObjectNames(JObject config) in D:\src\csharp-assessment\UnitTest1.cs:line 114
   at csharp_assessment.JsonTests.Test_GetObjectNames(String id, String[] expectedNames) in D:\src\csharp-assessment\UnitTest1.cs:line 151
  X csharp_assessment.JsonTests.Test_GetObjectNames(id: "2", expectedNames: ["icon", "fill"]) [< 1ms]
  Error Message:
   System.NotImplementedException : The method or operation is not implemented.
  Stack Trace:
     at csharp_assessment.JsonTests.GetObjectNames(JObject config) in D:\src\csharp-assessment\UnitTest1.cs:line 114
   at csharp_assessment.JsonTests.Test_GetObjectNames(String id, String[] expectedNames) in D:\src\csharp-assessment\UnitTest1.cs:line 151
  X csharp_assessment.JsonTests.Test_GetTitle(id: "1", expectedTitle: "Button P5") [< 1ms]
  Error Message:
   System.NotImplementedException : The method or operation is not implemented.
  Stack Trace:
     at csharp_assessment.JsonTests.GetTitle(JObject config) in D:\src\csharp-assessment\UnitTest1.cs:line 108
   at csharp_assessment.JsonTests.Test_GetTitle(String id, String expectedTitle) in D:\src\csharp-assessment\UnitTest1.cs:line 136
  X csharp_assessment.JsonTests.Test_GetTitle(id: "2", expectedTitle: "Slicers - Close Button") [< 1ms]
  Error Message:
   System.NotImplementedException : The method or operation is not implemented.
  Stack Trace:
     at csharp_assessment.JsonTests.GetTitle(JObject config) in D:\src\csharp-assessment\UnitTest1.cs:line 108
   at csharp_assessment.JsonTests.Test_GetTitle(String id, String expectedTitle) in D:\src\csharp-assessment\UnitTest1.cs:line 136
  X csharp_assessment.CsvTests.Aggregate_promotions [55ms]
  Error Message:
   Assert.Equal() Failure
Expected: 3.51
Actual:   0.0
  Stack Trace:
     at csharp_assessment.CsvTests.Aggregate_promotions() in D:\src\csharp-assessment\UnitTest1.cs:line 68
  X csharp_assessment.CsvTests.Test_LookupPromotionDiscount(region: "Asia", date: "2007-12-01", expectedDiscount: 0.15) [< 1ms]
  Error Message:
   System.NotImplementedException : The method or operation is not implemented.
  Stack Trace:
     at csharp_assessment.CsvTests.LookupPromotionDiscount(String region, DateTime date) in D:\src\csharp-assessment\UnitTest1.cs:line 37
   at csharp_assessment.CsvTests.Test_LookupPromotionDiscount(String region, String date, Nullable`1 expectedDiscount) in D:\src\csharp-assessment\UnitTest1.cs:line 48
[xUnit.net 00:00:00.51]     csharp_assessment.CsvTests.Test_LookupPromotionDiscount(region: "europe", date: "2008-01-01", expectedDiscount: 0.2) [FAIL]
[xUnit.net 00:00:00.51]     csharp_assessment.CsvTests.Test_LookupPromotionDiscount(region: "North America", date: "2009-09-30", expectedDiscount: 0.1) [FAIL]
[xUnit.net 00:00:00.51]     csharp_assessment.CsvTests.Test_LookupPromotionDiscount(region: "Asia", date: "2008-10-31", expectedDiscount: null) [FAIL]
[xUnit.net 00:00:00.51]     csharp_assessment.CsvTests.Test_LookupPromotionDiscount(region: "europe", date: "2007-05-01", expectedDiscount: null) [FAIL]
  X csharp_assessment.CsvTests.Test_LookupPromotionDiscount(region: "europe", date: "2008-01-01", expectedDiscount: 0.2) [< 1ms]
  Error Message:
   System.NotImplementedException : The method or operation is not implemented.
  Stack Trace:
     at csharp_assessment.CsvTests.LookupPromotionDiscount(String region, DateTime date) in D:\src\csharp-assessment\UnitTest1.cs:line 37
   at csharp_assessment.CsvTests.Test_LookupPromotionDiscount(String region, String date, Nullable`1 expectedDiscount) in D:\src\csharp-assessment\UnitTest1.cs:line 48
  X csharp_assessment.CsvTests.Test_LookupPromotionDiscount(region: "North America", date: "2009-09-30", expectedDiscount: 0.1) [< 1ms]
  Error Message:
   System.NotImplementedException : The method or operation is not implemented.
  Stack Trace:
     at csharp_assessment.CsvTests.LookupPromotionDiscount(String region, DateTime date) in D:\src\csharp-assessment\UnitTest1.cs:line 37
   at csharp_assessment.CsvTests.Test_LookupPromotionDiscount(String region, String date, Nullable`1 expectedDiscount) in D:\src\csharp-assessment\UnitTest1.cs:line 48
  X csharp_assessment.CsvTests.Test_LookupPromotionDiscount(region: "Asia", date: "2008-10-31", expectedDiscount: null) [< 1ms]
  Error Message:
   System.NotImplementedException : The method or operation is not implemented.
  Stack Trace:
     at csharp_assessment.CsvTests.LookupPromotionDiscount(String region, DateTime date) in D:\src\csharp-assessment\UnitTest1.cs:line 37
   at csharp_assessment.CsvTests.Test_LookupPromotionDiscount(String region, String date, Nullable`1 expectedDiscount) in D:\src\csharp-assessment\UnitTest1.cs:line 48
  X csharp_assessment.CsvTests.Test_LookupPromotionDiscount(region: "europe", date: "2007-05-01", expectedDiscount: null) [< 1ms]
  Error Message:
   System.NotImplementedException : The method or operation is not implemented.
  Stack Trace:
     at csharp_assessment.CsvTests.LookupPromotionDiscount(String region, DateTime date) in D:\src\csharp-assessment\UnitTest1.cs:line 37
   at csharp_assessment.CsvTests.Test_LookupPromotionDiscount(String region, String date, Nullable`1 expectedDiscount) in D:\src\csharp-assessment\UnitTest1.cs:line 48

Test Run Failed.
Total tests: 13
     Passed: 1
     Failed: 12
 Total time: 1.0397 Seconds
 ```