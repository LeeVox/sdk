# LeeVox.Sdk
SDK for .Net Core

## Purpose
This is collection of useful functions for lazy developers (like me).

## Table of Content

* `Text` extensions
  * [`System.String`](docs/Text/StringExtensions.md)
    * `SafeTrim()`: safely trim a `System.String`, returns `string.Empty` in case of `null`.
* `Threading` extensions
  * [`System.Threading.Tasks.Task`](docs/Threading/TaskExtensions.md)
    * `WaitAndReturn()`: waits for the `System.Threading.Tasks.Task` to complete execution, then returns its result.