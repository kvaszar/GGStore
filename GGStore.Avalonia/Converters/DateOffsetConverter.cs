using System;
using System.Globalization;
using Avalonia.Data.Converters;

namespace GGStore.Avalonia.Converters;

public class DateOffsetConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        => new DateTimeOffset((DateOnly)value, TimeOnly.MinValue, TimeSpan.Zero);

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        => DateOnly.FromDateTime(((DateTimeOffset)value).Date);
}