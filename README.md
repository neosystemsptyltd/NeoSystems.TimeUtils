# NeoSystems.TimeUtils

A .NET Standard library with a collection of `DateTime` and `TimeSpan` extension methods that provide additional functionalities like converting `DateTime` to Unix timestamps and `TimeSpan` to human-readable strings.

## Features

- Convert `DateTime` to Unix timestamps (in seconds and milliseconds).
- Convert `TimeSpan` to a simplified, human-readable string (e.g., "a minute", "2 hours", "3 days").
- Convert `TimeSpan` to an expanded, human-readable string with customizable time units (e.g., "1 year 2 months 3 days").
- Add milliseconds, seconds, minutes, hours, days, weeks, months, and years to a `TimeSpan`.

## Usage

### Converting DateTime to Unix Timestamps

```csharp
using NeoSystems.TimeUtils;

DateTime dt = new DateTime(2023, 1, 1);
long unixTimestamp = dt.ToUnixTime(); // 1672531200
long unixTimestampMilliseconds = dt.ToUnixTimeMilliseconds(); // 1672531200000
```

### Converting TimeSpan to Human-Readable Strings

```csharp
using NeoSystems.TimeUtils;

TimeSpan ts = new TimeSpan(1, 2, 3, 4);
string simple = ts.ToHumanReadableSimple(); // "a day"

TimeSpan ts2 = new TimeSpan(365, 0, 0, 0);
string expanded = ts2.ToHumanReadableExpanded(); // "1 year"
```

### Adding Time to a TimeSpan

```csharp
using NeoSystems.TimeUtils;

TimeSpan ts = new TimeSpan(1, 0, 0);
ts = ts.AddHours(2); // 3 hours
ts = ts.AddDays(1); // 1 day and 3 hours
```

## Installation

To install the package, run the following command in the .NET CLI:

```
dotnet add package NeoSystems.TimeUtils
```
