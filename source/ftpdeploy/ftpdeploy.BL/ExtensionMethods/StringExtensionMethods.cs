namespace ftpdeploy.BL.ExtensionMethods;

public static class StringExtensionMethods {
    public static int ToInt(this string value, int defaultValue = 0) {
        if (Int32.TryParse(value, out int _valueAsInt)) {
            return _valueAsInt;
        }

        return defaultValue;
    }
}