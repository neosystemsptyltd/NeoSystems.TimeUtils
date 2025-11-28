# TODO: Project Review

This document outlines identified problems and potential new features for the `NeoSystems.TimeUtils` project.

## Problems / Bugs

1.  **`FuzzyAdd` Implementation Issues:**
    *   **Logic Flaw:** If the input string is a number without a suffix (e.g., "10"), the method defaults to `Years` and removes the last character (thinking it's a suffix). "10" becomes "1 Year". This is incorrect behavior.
    *   **Input Validation:** The method relies on `int.Parse` without `TryParse`, which will throw an exception for invalid numeric formats.
    *   **String Parsing:** Using `EndsWith` and `Substring` is fragile. `Substring` can throw if the string is empty (though `Trim` is called, empty strings might still cause issues if not handled carefully).
    *   **Composite Strings:** Does not support composite values like "1d 2h".

2.  **Imprecise Date Calculations in `TimeSpanExtensions`:**
    *   **Inconsistent Year Length:** `ToHumanReadableSimple` and `ToHumanReadableExpanded` assume a year is exactly 365 days. `AddYears` uses 365.25 days.
    *   **Fixed Month Length:** `AddMonths` and `ToHumanReadableSimple` assume a month is always 30 days. This can lead to significant drift when dealing with actual calendar dates.

3.  **Coding Standards & Naming Conventions:**
    *   **Property Naming:** The `TimeUnits` class uses lowercase property names (`years`, `months`, etc.), violating C# PascalCase naming conventions.
    *   **Namespace:** The `TimeUnits` class is defined in the global namespace instead of `NeoSystems.TimeUtils`.
    *   **Enum Handling:** `TimeUnitEnum.Unknown` exists but `FuzzyAdd` defaults to `Years` before checking validation, making `Unknown` less effective.

4.  **Localization & Hardcoding:**
    *   Human-readable strings ("one second", "yesterday", etc.) are hardcoded in English, making localization difficult.

## Possible New Features

1.  **Robust `FuzzyAdd`:**
    *   Support for composite fuzzy strings (e.g., "1d 2h 30m").
    *   Support for weeks ("w" suffix).
    *   Better error handling using `TryParse`.

2.  **Date Range Utilities:**
    *   Features to handle date ranges, intersections, and unions.

3.  **Business Days Calculation:**
    *   Methods to add/subtract business days, skipping weekends and holidays.

4.  **Fluent API Improvements:**
    *   Enhance the fluent interface for more natural date manipulation chaining.

5.  **improved Localization:**
    *   Refactor `ToHumanReadable` methods to support localization or custom resource strings.
