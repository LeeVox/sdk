# Extensions for `System.Threading.Tasks.Task`

## System.Threading.Tasks.Task.WaitAndReturn methods
Waits for the `System.Threading.Tasks.Task` to complete execution, then returns its result.

__Overloads__
* [WaitAndReturn()](#WaitAndReturn)
* [WaitAndReturn(int)](#WaitAndReturnInt)
* [WaitAndReturn(int, TResult)](#WaitAndReturnInt-TResult)
* [WaitAndReturn(TimeSpan)](#WaitAndReturnTimeSpan)
* [WaitAndReturn(TimeSpan, TResult)](#WaitAndReturnTimeSpan-TResult)
* [WaitAndReturn(CancellationToken)](#WaitAndReturnCancellationToken)
* [WaitAndReturn(CancellationToken, TResult)](#WaitAndReturnCancellationToken-TResult)
* [WaitAndReturn(int, CancellationToken)](#WaitAndReturnInt-CancellationToken)
* [WaitAndReturn(int, CancellationToken, TResult)](#WaitAndReturnInt-CancellationToken-TResult)

---
### WaitAndReturn()
Waits for the `System.Threading.Tasks.Task` to complete execution, then returns its result.

```csharp
public static TResult WaitAndReturn<TResult>(this Task<TResult> task);
```

---
### WaitAndReturn(int)
Waits for the `System.Threading.Tasks.Task` to complete execution within a specified number of milliseconds, then returns its result.

```csharp
public static TResult WaitAndReturn<TResult>(this Task<TResult> task, int millisecondsTimeout);
```

#### Remarks
returns `default(TResult)` if timeout.

---
### WaitAndReturn(int, TResult)
Waits for the `System.Threading.Tasks.Task` to complete execution within a specified number of milliseconds, then returns its result.

```csharp
public static TResult WaitAndReturn<TResult>(this Task<TResult> task, int millisecondsTimeout, TResult returnValueIfTimeout);
```

#### Remarks
returns `returnValueIfTimeout` if timeout.

---
### WaitAndReturn(TimeSpan)
Waits for the `System.Threading.Tasks.Task` to complete execution within a specified time interval, then returns its result.

```csharp
public static TResult WaitAndReturn<TResult>(this Task<TResult> task, TimeSpan timeout);
```

#### Remarks
returns `default(TResult)` if timeout.

---
### WaitAndReturn(TimeSpan, TResult)
Waits for the `System.Threading.Tasks.Task` to complete execution within a specified time interval, then returns its result.

```csharp
public static TResult WaitAndReturn<TResult>(this Task<TResult> task, TimeSpan timeout, TResult returnValueIfTimeout);
```

#### Remarks
returns `returnValueIfTimeout` if timeout.

---
### WaitAndReturn(CancellationToken)
Waits for the `System.Threading.Tasks.Task` to complete execution or until cancellation token is canceled, then returns its result.

```csharp
public static TResult WaitAndReturn<TResult>(this Task<TResult> task, CancellationToken cancellationToken);
```

#### Remarks
returns `default(TResult)` if canceled.

---
### WaitAndReturn(CancellationToken, TResult)
Waits for the `System.Threading.Tasks.Task` to complete execution or until cancellation token is canceled, then returns its result.

```csharp
public static TResult WaitAndReturn<TResult>(this Task<TResult> task, CancellationToken cancellationToken, TResult returnValueIfCanceled);
```

#### Remarks
returns `returnValueIfCanceled` if canceled.

---
### WaitAndReturn(int, CancellationToken)
Waits for the `System.Threading.Tasks.Task` to complete execution within a specified number of milliseconds or until cancellation token is canceled, then returns its result.

```csharp
public static TResult WaitAndReturn<TResult>(this Task<TResult> task, int millisecondsTimeout, CancellationToken cancellationToken);
```

#### Remarks
returns `default(TResult)` if timeout or canceled.

---
### WaitAndReturn(int, CancellationToken, TResult)
Waits for the `System.Threading.Tasks.Task` to complete execution within a specified number of milliseconds or until cancellation token is canceled, then returns its result.

```csharp
public static TResult WaitAndReturn<TResult>(this Task<TResult> task, int millisecondsTimeout, CancellationToken cancellationToken, TResult returnValueIfTimeoutOrCanceled);
```

#### Remarks
returns `returnValueIfTimeoutOrCanceled` if timeout or canceled.

---