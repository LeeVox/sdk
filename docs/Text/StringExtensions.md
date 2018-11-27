# Common extensions for `System.String`

## SafeTrim methods
Safely trim a `System.String`, returns `string.Empty` in case of `null`.

__Overloads__
* [SafeTrim()](#SafeTrim)
* [SafeTrim(char[])](#SafeTrimChar)

---
### SafeTrim()
Removes all leading and trailing white-space characters from the current `System.String` object, returns `string.Empty` in case of `null`.

```csharp
public static string SafeTrim(this string text);
```

this is shortcut to:
```csharp
return (text ?? string.Empty).Trim()
```

---
### SafeTrim(char[])
Removes all leading and trailing occurrences of a set of characters specified in an array from the current `System.String` object, returns `string.Empty` in case of `null`.

```csharp
public static string SafeTrim(this string text, params char[] trimChars);
```

this is shortcut to:
```csharp
return (text ?? string.Empty).Trim(trimChars)
```

## IsEqual methods
Determines whether a `System.String` has same value to another `System.String`.

__Overloads__
* [IsEqual(string)](#IsEqualString)
* [IsEqual(string, bool)](#IsEqualString-Bool)
* [IsEqual(string, StringComparison)](#IsEqualString-StringComparison)

* [IsOrdinalEqual(string)](#IsOrdinalEqualString)
* [IsOrdinalEqual(string, bool)](#IsOrdinalEqualString-Bool)

* [IsEqualIgnoreSpaces(string)](#IsEqualIgnoreSpacesString)
* [IsEqualIgnoreSpaces(string, bool)](#IsEqualIgnoreSpacesString-Bool)
* [IsEqualIgnoreSpaces(string, StringComparison)](#IsEqualIgnoreSpacesString-StringComparison)

* [IsOrdinalEqualIgnoreSpaces(string)](#IsOrdinalEqualIgnoreSpacesString)
* [IsOrdinalEqualIgnoreSpaces(string, bool)](#IsOrdinalEqualIgnoreSpacesString-Bool)

---
### IsEqual(string)
Determines whether a `System.String` has same value to another `System.String` using `StringComparison.CurrentCulture`.

```csharp
public static string IsEqual(this string a, string b);
```

---
### IsEqual(string, bool)
Determines whether a `System.String` has same value to another `System.String` using `StringComparison.CurrentCulture` with option to ignore case.

```csharp
public static string IsEqual(this string a, string b, bool ignoreCase);
```

---
### IsEqual(string, StringComparison)
Determines whether a `System.String` has same value to another `System.String` using specified `StringComparison`.

```csharp
public static string IsEqual(this string a, string b, StringComparison stringComparison);
```

---
### IsOrdinalEqual(string)
Determines whether a `System.String` has same value to another `System.String` using `StringComparison.Ordinal`.

```csharp
public static string IsOrdinalEqual(this string a, string b);
```

---
### IsOrdinalEqual(string, bool)
Determines whether a `System.String` has same value to another `System.String` using `StringComparison.Ordinal` with option to ignore case.

```csharp
public static string IsOrdinalEqual(this string a, string b, bool ignoreCase);
```

---
### IsEqualIgnoreSpaces(string)
Determines whether a `System.String` has same value (ignore trailing and leading spaces) to another `System.String` using `StringComparison.CurrentCulture`.

```csharp
public static string IsEqualIgnoreSpaces(this string a, string b);
```

---
### IsEqualIgnoreSpaces(string, bool)
Determines whether a `System.String` has same value (ignore trailing and leading spaces) to another `System.String` using `StringComparison.CurrentCulture` with option to ignore case.

```csharp
public static string IsEqualIgnoreSpaces(this string a, string b, bool ignoreCase);
```

---
### IsEqualIgnoreSpaces(string, StringComparison)
Determines whether a `System.String` has same value (ignore trailing and leading spaces) to another `System.String` using a specified `StringComparison`.

```csharp
public static string IsEqualIgnoreSpaces(this string a, string b, StringComparison stringComparison);
```

---
### IsOrdinalEqualIgnoreSpaces(string)
Determines whether a `System.String` has same value (ignore trailing and leading spaces) to another `System.String` using `StringComparison.Ordinal`.

```csharp
public static string IsOrdinalEqualIgnoreSpaces(this string a, string b);
```

---
### IsOrdinalEqualIgnoreSpaces(string, bool)
Determines whether a `System.String` has same value (ignore trailing and leading spaces) to another `System.String` using `StringComparison.Ordinal` with option to ignore case.

```csharp
public static string IsOrdinalEqualIgnoreSpaces(this string a, string b, bool ignoreCase);
```

## Contains methods
Determines whether a `System.String` contains another `System.String`.

__Overloads__
* [Contains(string, bool)](#ContainsString-Bool)
* [Contains(string, StringComparison)](#ContainsString-StringComparison)
* [OrdinalContains(string)](#OrdinalContainsString)
* [OrdinalContains(string, bool)](#OrdinalContainsString-Bool)

---
### Contains(string, bool)
Determines whether a `System.String` contains another `System.String` using `StringComparison.CurrentCulture` with option to ignore case.

```csharp
public static string Contains(this string text, string search, bool ignoreCase);
```

#### Exceptions
* `System.NullReferenceException`: if current string is null
* `System.NullReferenceException`: if search string is null

---
### Contains(string, StringComparison)
Determines whether a `System.String` contains another `System.String` using a specified `StringComparison`.

```csharp
public static string Contains(this string text, string search, StringComparison stringComparison);
```

#### Exceptions
* `System.NullReferenceException`: if current string is null
* `System.NullReferenceException`: if search string is null

---
### OrdinalContains(string)
Determines whether a `System.String` contains another `System.String` using `StringComparison.Ordinal`.

```csharp
public static string OrdinalContains(this string text, string search);
```

#### Exceptions
* `System.NullReferenceException`: if current string is null
* `System.NullReferenceException`: if search string is null

---
### OrdinalContains(string, bool)
Determines whether a `System.String` contains another `System.String` using `StringComparison.Ordinal` with option to ignore case.

```csharp
public static string OrdinalContains(this string text, string search, bool ignoreCase);
```

#### Exceptions
* `System.NullReferenceException`: if current string is null
* `System.NullReferenceException`: if search string is null