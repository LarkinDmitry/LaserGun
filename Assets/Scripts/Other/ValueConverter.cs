static class ValueConverter
{
    public static float StringToFloat(string s)
    {
        char separator = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0];
        return float.Parse(s.Replace(".", separator.ToString()));
    }
}