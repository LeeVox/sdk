# LeeVox.Sdk
SDK for .Net Core

## Purpose
This is collection of useful functions for lazy developers (like me).

## Status

### Build
| Windows  | Ubuntu | macOS  |
| ---      | ---    | ---    |
| [![Build Status](https://github.com/leevox/sdk/workflows/windows/badge.svg)](https://github.com/LeeVox/sdk/actions) | [![Build Status](https://github.com/leevox/sdk/workflows/ubuntu/badge.svg)](https://github.com/LeeVox/sdk/actions) | [![Build Status](https://github.com/leevox/sdk/workflows/macos/badge.svg)](https://github.com/LeeVox/sdk/actions) |

### Code Coverage
[![codecov](https://codecov.io/gh/LeeVox/sdk/branch/master/graph/badge.svg)](https://codecov.io/gh/LeeVox/sdk/branch/master)

## Table of Content

* `Text` extensions
  * [Common extensions for `System.String`](docs/Text/StringExtensions.md)
    * `SafeTrim()`
      safely trim a `System.String`, returns `string.Empty` in case of `null`.

    * `IsEqual()`
      `IsEqualIgnoreCase()`
      `IsOrdinalEqual()`
      `IsOrdinalEqualIgnoreCase()`
      determines whether a `System.String` has same value to another `System.String`.

    * `Contains()`
      `OrdinalContains()`
      determines whether a `System.String` contains another `System.String`.

  * [Parsing extensions for `System.String`](docs/Text/StringParseExtensions.md)
    * `ParseTo<TResult>()`
      try to convert the specified `System.String` to `Nullable<TResult>` type using `Convert.ChangeType` function.

    * `ParseToBoolean()`
      `ParseToInt()`
      `ParseToDateTime()`
      `...`
      try to convert the specified `System.String` to primitive data types.

* `Threading` extensions
  * [Common extensions for `System.Threading.Tasks.Task`](docs/Threading/TaskExtensions.md)
    * `WaitAndReturn()`: waits for the `System.Threading.Tasks.Task` to complete execution, then returns its result.