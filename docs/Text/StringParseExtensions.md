# Parsing extensions for `System.String`

## ParseTo<TResult> methods
Try to convert the specified `System.String` to `Nullable<TResult>` type using `Convert.ChangeType` function.

__Overloads__
* [ParseTo<TResult>()](#ParseToTResult)
* [ParseTo<TResult>(IFormatProvider)](#ParseToTResultIFormatProvider)
* [ParseTo<TResult>(TResult)](#ParseToTResultTResult)
* [ParseTo<TResult>(IFormatProvider, TResult)](ParseToTResultIFormatProviderTResult)

---
### ParseTo<TResult>()
Try to convert the specified <c>System.String</c> to <c>Nullable<TResult></c> type using <c>Convert.ChangeType</c> function.
* Returns `null` if the conversion fails.

```csharp
public static TResult? ParseTo<TResult>(this string text);
```

---
### ParseTo<TResult>(IFormatProvider)
Try to convert the specified <c>System.String</c> to <c>Nullable<TResult></c> type using <c>Convert.ChangeType</c> function and a <c>FormatProvider</c>.
* Returns `null` if the conversion fails.

```csharp
public static TResult? ParseTo<TResult>(this string text, IFormatProvider provider);
```

---
### ParseTo<TResult>(TResult)
Try to convert the specified <c>System.String</c> to <c>Nullable<TResult></c> type using <c>Convert.ChangeType</c> function.
* Returns `returnValueIfError` if the conversion fails.

```csharp
public static TResult? ParseTo<TResult>(this string text, TResult returnValueIfError);
```

---
### ParseTo<TResult>(IFormatProvider, TResult)
Try to convert the specified <c>System.String</c> to <c>Nullable<TResult></c> type using <c>Convert.ChangeType</c> function and a <c>FormatProvider</c>.
* Returns `returnValueIfError` if the conversion fails.

```csharp
public static TResult? ParseTo<TResult>(this string text, IFormatProvider provider, TResult returnValueIfError);
```

## ParseToBoolean methods
Try to convert the specified `System.String` to `System.Boolean` type using `bool.TryParse` function.

__Overloads__
* [ParseToBoolean()](#ParseToBoolean)
* [ParseToBoolean(bool)](#ParseToBooleanBool)

---
### ParseToBoolean()
Try to convert the specified `System.String` to `System.Boolean` type using `bool.TryParse` function.
* Returns `null` if the conversion fails.

```csharp
public static bool? ParseToBoolean(this string text);
```

---
### ParseToBoolean(bool)
Try to convert the specified `System.String` to `System.Boolean` type using `bool.TryParse` function.
* Returns `returnValueIfError` if the conversion fails.

```csharp
public static bool ParseToBoolean(this string text, bool returnValueIfError);
```

## ParseToByte methods
Try to convert the specified `System.String` to `System.Byte` type using `byte.TryParse` function.

__Overloads__
* [ParseToByte()](#ParseToByte)
* [ParseToByte(NumberStyles, IFormatProvider)](#ParseToByteNumberStylesIFormatProvider)
* [ParseToByte(byte)](#ParseToByteByte)
* [ParseToByte(NumberStyles, IFormatProvider, byte)](#ParseToByteNumberStylesIFormatProviderByte)

---
### ParseToByte()
Try to convert the specified `System.String` to `System.Byte` type using `byte.TryParse` function.
* Returns `null` if the conversion fails.

```csharp
public static byte? ParseToByte(this string text);
```

---
### ParseToByte(NumberStyles, IFormatProvider)
Try to convert the specified `System.String` to `System.Byte` type using `byte.TryParse` function and number formats.
* Returns `null` if the conversion fails.

```csharp
public static byte? ParseToByte(this string text, NumberStyles styles, IFormatProvider provider);
```

---
### ParseToByte(byte)
Try to convert the specified `System.String` to `System.Byte` type using `byte.TryParse` function.
* Returns `returnValueIfError` if the conversion fails.

```csharp
public static byte ParseToByte(this string text, byte returnValueIfError);
```

---
### ParseToByte(NumberStyles, IFormatProvider, byte)
Try to convert the specified `System.String` to `System.Byte` type using `byte.TryParse` function and number formats.
* Returns `returnValueIfError` if the conversion fails.

```csharp
public static byte ParseToByte(this string text, NumberStyles styles, IFormatProvider provider, byte returnValueIfError);
```

## ParseToInt methods
Try to convert the specified `System.String` to `System.Int32` type using `int.TryParse` function.

__Overloads__
* [ParseToInt()](#ParseToInt)
* [ParseToInt(NumberStyles, IFormatProvider)](#ParseToIntNumberStylesIFormatProvider)
* [ParseToInt(int)](#ParseToIntInt)
* [ParseToInt(NumberStyles, IFormatProvider, int)](#ParseToIntNumberStylesIFormatProviderInt)

---
### ParseToInt()
Try to convert the specified `System.String` to `System.Int32` type using `int.TryParse` function.
* Returns `null` if the conversion fails.

```csharp
public static int? ParseToInt(this string text);
```

---
### ParseToInt(NumberStyles, IFormatProvider)
Try to convert the specified `System.String` to `System.Int32` type using `int.TryParse` function and number formats.
* Returns `null` if the conversion fails.

```csharp
public static int? ParseToInt(this string text, NumberStyles styles, IFormatProvider provider);
```

---
### ParseToInt(int)
Try to convert the specified `System.String` to `System.Int32` type using `int.TryParse` function.
* Returns `returnValueIfError` if the conversion fails.

```csharp
public static int ParseToInt(this string text, int returnValueIfError);
```

---
### ParseToInt(NumberStyles, IFormatProvider, int)
Try to convert the specified `System.String` to `System.Int32` type using `int.TryParse` function and number formats.
* Returns `returnValueIfError` if the conversion fails.

```csharp
public static int ParseToInt(this string text, NumberStyles styles, IFormatProvider provider, int returnValueIfError);
```

## ParseToLong methods
Try to convert the specified `System.String` to `System.Int64` type using `long.TryParse` function.

__Overloads__
* [ParseToLong()](#ParseToLong)
* [ParseToLong(NumberStyles, IFormatProvider)](#ParseToLongNumberStylesIFormatProvider)
* [ParseToLong(long)](#ParseToLongLong)
* [ParseToLong(NumberStyles, IFormatProvider, long)](#ParseToLongNumberStylesIFormatProviderLong)

---
### ParseToLong()
Try to convert the specified `System.String` to `System.Int64` type using `long.TryParse` function.
* Returns `null` if the conversion fails.

```csharp
public static long? ParseToLong(this string text);
```

---
### ParseToLong(NumberStyles, IFormatProvider)
Try to convert the specified `System.String` to `System.Int64` type using `long.TryParse` function and number formats.
* Returns `null` if the conversion fails.

```csharp
public static long? ParseToLong(this string text, NumberStyles styles, IFormatProvider provider);
```

---
### ParseToLong(long)
Try to convert the specified `System.String` to `System.Int64` type using `long.TryParse` function.
* Returns `returnValueIfError` if the conversion fails.

```csharp
public static long ParseToLong(this string text, long returnValueIfError);
```

---
### ParseToLong(NumberStyles, IFormatProvider, long)
Try to convert the specified `System.String` to `System.Int64` type using `long.TryParse` function and number formats.
* Returns `returnValueIfError` if the conversion fails.

```csharp
public static long ParseToLong(this string text, NumberStyles styles, IFormatProvider provider, long returnValueIfError);
```

## ParseToFloat methods
Try to convert the specified `System.String` to `System.Float` type using `float.TryParse` function.

__Overloads__
* [ParseToFloat()](#ParseToFloat)
* [ParseToFloat(NumberStyles, IFormatProvider)](#ParseToFloatNumberStylesIFormatProvider)
* [ParseToFloat(float)](#ParseToFloatFloat)
* [ParseToFloat(NumberStyles, IFormatProvider, float)](#ParseToFloatNumberStylesIFormatProviderFloat)

---
### ParseToFloat()
Try to convert the specified `System.String` to `System.Float` type using `float.TryParse` function.
* Returns `null` if the conversion fails.

```csharp
public static float? ParseToFloat(this string text);
```

---
### ParseToFloat(NumberStyles, IFormatProvider)
Try to convert the specified `System.String` to `System.Float` type using `float.TryParse` function and number formats.
* Returns `null` if the conversion fails.

```csharp
public static float? ParseToFloat(this string text, NumberStyles styles, IFormatProvider provider);
```

---
### ParseToFloat(float)
Try to convert the specified `System.String` to `System.Float` type using `float.TryParse` function.
* Returns `returnValueIfError` if the conversion fails.

```csharp
public static float ParseToFloat(this string text, float returnValueIfError);
```

---
### ParseToFloat(NumberStyles, IFormatProvider, float)
Try to convert the specified `System.String` to `System.Float` type using `float.TryParse` function and number formats.
* Returns `returnValueIfError` if the conversion fails.

```csharp
public static float ParseToFloat(this string text, NumberStyles styles, IFormatProvider provider, float returnValueIfError);
```

## ParseToDouble methods
Try to convert the specified `System.String` to `System.Double` type using `double.TryParse` function.

__Overloads__
* [ParseToDouble()](#ParseToDouble)
* [ParseToDouble(NumberStyles, IFormatProvider)](#ParseToDoubleNumberStylesIFormatProvider)
* [ParseToDouble(double)](#ParseToDoubleDouble)
* [ParseToDouble(NumberStyles, IFormatProvider, double)](#ParseToDoubleNumberStylesIFormatProviderDouble)

---
### ParseToDouble()
Try to convert the specified `System.String` to `System.Double` type using `double.TryParse` function.
* Returns `null` if the conversion fails.

```csharp
public static double? ParseToDouble(this string text);
```

---
### ParseToDouble(NumberStyles, IFormatProvider)
Try to convert the specified `System.String` to `System.Double` type using `double.TryParse` function and number formats.
* Returns `null` if the conversion fails.

```csharp
public static double? ParseToDouble(this string text, NumberStyles styles, IFormatProvider provider);
```

---
### ParseToDouble(double)
Try to convert the specified `System.String` to `System.Double` type using `double.TryParse` function.
* Returns `returnValueIfError` if the conversion fails.

```csharp
public static double ParseToDouble(this string text, double returnValueIfError);
```

---
### ParseToDouble(NumberStyles, IFormatProvider, double)
Try to convert the specified `System.String` to `System.Double` type using `double.TryParse` function and number formats.
* Returns `returnValueIfError` if the conversion fails.

```csharp
public static double ParseToDouble(this string text, NumberStyles styles, IFormatProvider provider, double returnValueIfError);
```

## ParseToDecimal methods
Try to convert the specified `System.String` to `System.Decimal` type using `decimal.TryParse` function.

__Overloads__
* [ParseToDecimal()](#ParseToDecimal)
* [ParseToDecimal(NumberStyles, IFormatProvider)](#ParseToDecimalNumberStylesIFormatProvider)
* [ParseToDecimal(decimal)](#ParseToDecimalDecimal)
* [ParseToDecimal(NumberStyles, IFormatProvider, decimal)](#ParseToDecimalNumberStylesIFormatProviderDecimal)

---
### ParseToDecimal()
Try to convert the specified `System.String` to `System.Decimal` type using `decimal.TryParse` function.
* Returns `null` if the conversion fails.

```csharp
public static decimal? ParseToDecimal(this string text);
```

---
### ParseToDecimal(NumberStyles, IFormatProvider)
Try to convert the specified `System.String` to `System.Decimal` type using `decimal.TryParse` function and number formats.
* Returns `null` if the conversion fails.

```csharp
public static decimal? ParseToDecimal(this string text, NumberStyles styles, IFormatProvider provider);
```

---
### ParseToDecimal(decimal)
Try to convert the specified `System.String` to `System.Decimal` type using `decimal.TryParse` function.
* Returns `returnValueIfError` if the conversion fails.

```csharp
public static decimal ParseToDecimal(this string text, decimal returnValueIfError);
```

---
### ParseToDecimal(NumberStyles, IFormatProvider, decimal)
Try to convert the specified `System.String` to `System.Decimal` type using `decimal.TryParse` function and number formats.
* Returns `returnValueIfError` if the conversion fails.

```csharp
public static decimal ParseToDecimal(this string text, NumberStyles styles, IFormatProvider provider, decimal returnValueIfError);
```

## ParseToDateTime methods
Try to convert the specified `System.String` to `System.DateTime` type using `DateTime.TryParse` function.

__Overloads__
* [ParseToDateTime()](#ParseToDateTime)
* [ParseToDateTime(DateTimeStyles, IFormatProvider)](#ParseToDateTimeDateTimeStylesIFormatProvider)
* [ParseToDateTime(DateTime)](#ParseToDateTimeDateTime)
* [ParseToDateTime(DateTimeStyles, IFormatProvider, DateTime)](#ParseToDateTimeDateTimeStylesIFormatProviderDateTime)

---
### ParseToDateTime()
Try to convert the specified `System.String` to `System.DateTime` type using `DateTime.TryParse` function.
* Returns `null` if the conversion fails.

```csharp
public static DateTime? ParseToDateTime(this string text);
```

---
### ParseToDateTime(NumberStyles, IFormatProvider)
Try to convert the specified `System.String` to `System.DateTime` type using `DateTime.TryParse` function and DateTime formats.
* Returns `null` if the conversion fails.

```csharp
public static DateTime? ParseToDateTime(this string text, DateTimeStyles styles, IFormatProvider provider);
```

---
### ParseToDateTime(DateTime)
Try to convert the specified `System.String` to `System.DateTime` type using `DateTime.TryParse` function.
* Returns `returnValueIfError` if the conversion fails.

```csharp
public static DateTime ParseToDateTime(this string text, DateTime returnValueIfError);
```

---
### ParseToDateTime(DateTimeStyles, IFormatProvider, DateTime)
Try to convert the specified `System.String` to `System.DateTime` type using `DateTime.TryParse` function and DateTime formats.
* Returns `returnValueIfError` if the conversion fails.

```csharp
public static DateTime ParseToDateTime(this string text, DateTimeStyles styles, IFormatProvider provider, DateTime returnValueIfError);
```