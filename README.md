# LeeVox.Sdk
SDK for .Net Core

## Purpose
This is collection of useful functions for lazy developers (like me).

## Status
|               | master   | test     | dev      |
| ---           | ---      | ---      | ---      |
| Windows       | [![Build Status](https://dev.azure.com/leevox/sdk/_apis/build/status/windows-ci?branchName=master)](https://dev.azure.com/leevox/sdk/_build) | [![Build Status](https://dev.azure.com/leevox/sdk/_apis/build/status/windows-ci?branchName=test)](https://dev.azure.com/leevox/sdk/_build) | [![Build Status](https://dev.azure.com/leevox/sdk/_apis/build/status/windows-ci?branchName=dev)](https://dev.azure.com/leevox/sdk/_build) |
| Linux         | [![Build Status](https://dev.azure.com/leevox/sdk/_apis/build/status/linux-ci?branchName=master)](https://dev.azure.com/leevox/sdk/_build) | [![Build Status](https://dev.azure.com/leevox/sdk/_apis/build/status/linux-ci?branchName=test)](https://dev.azure.com/leevox/sdk/_build) | [![Build Status](https://dev.azure.com/leevox/sdk/_apis/build/status/linux-ci?branchName=dev)](https://dev.azure.com/leevox/sdk/_build) |
| macOS         | [![Build Status](https://dev.azure.com/leevox/sdk/_apis/build/status/osx-ci?branchName=master)](https://dev.azure.com/leevox/sdk/_build) | [![Build Status](https://dev.azure.com/leevox/sdk/_apis/build/status/osx-ci?branchName=test)](https://dev.azure.com/leevox/sdk/_build) | [![Build Status](https://dev.azure.com/leevox/sdk/_apis/build/status/osx-ci?branchName=dev)](https://dev.azure.com/leevox/sdk/_build) |
| Code Coverage | [![codecov](https://codecov.io/gh/LeeVox/sdk/branch/master/graph/badge.svg)](https://codecov.io/gh/LeeVox/sdk) | [![codecov](https://codecov.io/gh/LeeVox/sdk/branch/test/graph/badge.svg)](https://codecov.io/gh/LeeVox/sdk) | [![codecov](https://codecov.io/gh/LeeVox/sdk/branch/dev/graph/badge.svg)](https://codecov.io/gh/LeeVox/sdk) |


## Table of Content

* `Text` extensions
  * [`System.String`](docs/Text/StringExtensions.md)
    * `SafeTrim()`: safely trim a `System.String`, returns `string.Empty` in case of `null`.
* `Threading` extensions
  * [`System.Threading.Tasks.Task`](docs/Threading/TaskExtensions.md)
    * `WaitAndReturn()`: waits for the `System.Threading.Tasks.Task` to complete execution, then returns its result.