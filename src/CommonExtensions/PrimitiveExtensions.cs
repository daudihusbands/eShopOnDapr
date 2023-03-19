using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace CommonExtensions
{

    public static class PrimitiveExtensions
    {


        public static string ToTrueFalse(this bool val)
        {
            return val ? "True" : "False";
        }
        public static string ToYesNo(this bool val)
        {
            return val ? "Yes" : "No";
        }
        public static string ToBit(this string str) => str.ToUpper() == "YES" || str.ToUpper() == "Y" ? "1" : "0";
        public static string ToBit(this bool val) => val ? "1" : "0";

        public static string ValueOrNull(this string str, string defaultValue = null) => !string.IsNullOrWhiteSpace(str) ? str : defaultValue ?? null;
        public static string ValueOrDbNull(this object obj, object defaultValue = null) => obj == null || obj is DBNull || string.IsNullOrWhiteSpace(obj.ToString()) || string.Equals(obj.ToString(), "n/a", StringComparison.OrdinalIgnoreCase) ? (string)defaultValue ?? null : (string)obj;
        public static string ToTitleCase(this string str)
        {
            var textInfo = new CultureInfo("en-US", false).TextInfo;
            return textInfo.ToTitleCase(str); //War And Peace
        }
    }
    //public enum UpdateFieldStrategy { PreserveFirst, PreserveSecond }
    //public static class PrimitiveExtensions
    //{

    //    public static string ValueOrNull(this string str, string defaultValue = null) => !string.IsNullOrWhiteSpace(str) ? str : defaultValue ?? null;
    //    public static string ValueOrDbNull(this object obj, object defaultValue = null) => (obj == null || obj is DBNull || string.IsNullOrWhiteSpace(obj.ToString()) || string.Equals(obj.ToString(), "n/a", StringComparison.OrdinalIgnoreCase)) ? ((string)defaultValue ?? null) : (string)obj;


    //    public static string ToOrdinal(this int? num)
    //    {
    //        if (!num.HasValue) return string.Empty;
    //        if (num <= 0) return num.ToString();

    //        switch (num % 100)
    //        {
    //            case 11:
    //            case 12:
    //            case 13:
    //                return num + "th";
    //        }

    //        switch (num % 10)
    //        {
    //            case 1:
    //                return num + "st";
    //            case 2:
    //                return num + "nd";
    //            case 3:
    //                return num + "rd";
    //            default:
    //                return num + "th";
    //        }

    //    }
    //    public static void UpdateField<T, TProperty>(this T obj, T other, Expression<Func<T, TProperty>> fieldSelector, UpdateFieldStrategy updateFieldStrategy)
    //    {
    //        var myValue = fieldSelector.Compile().Invoke(obj);
    //        var otherValue = fieldSelector.Compile().Invoke(other);
    //        var action = GetSetter(fieldSelector);
    //        switch (updateFieldStrategy)
    //        {
    //            case UpdateFieldStrategy.PreserveFirst:
    //                if (myValue != null)
    //                    return;
    //                break;
    //            case UpdateFieldStrategy.PreserveSecond:
    //                if (otherValue != null)
    //                {
    //                    action.Invoke(obj, otherValue);
    //                    return;
    //                }
    //                break;
    //            default:
    //                break;
    //        }
    //        if (myValue == null && otherValue != null)
    //        {
    //            action.Invoke(obj, otherValue);
    //        }

    //    }

    //    public static TProperty ChooseNewValue<T, TProperty>(this T obj, Expression<Func<T, TProperty>> fieldSelector, TProperty newValue, UpdateFieldStrategy updateFieldStrategy)
    //    {
    //        var myValue = fieldSelector.Compile().Invoke(obj);
    //        return obj.ChooseNewValue(myValue, newValue, updateFieldStrategy);


    //    }

    //    public static TProperty ChooseNewValue<T, TProperty>(this T obj, TProperty oldValue, TProperty newValue, UpdateFieldStrategy updateFieldStrategy)
    //    {
    //        var myValue = oldValue;
    //        switch (updateFieldStrategy)
    //        {
    //            case UpdateFieldStrategy.PreserveFirst:
    //                if (myValue != null)
    //                    return myValue;
    //                break;
    //            case UpdateFieldStrategy.PreserveSecond:
    //                if (newValue != null)
    //                {
    //                    return newValue;
    //                }
    //                break;
    //            default:
    //                break;
    //        }
    //        if (myValue == null && newValue != null)
    //        {
    //            return newValue;
    //        }
    //        return myValue;

    //    }
    //    /// <summary>
    //    /// Convert a lambda expression for a getter into a setter
    //    /// </summary>
    //    public static Action<T, TProperty> GetSetter<T, TProperty>(Expression<Func<T, TProperty>> expression)
    //    {
    //        var memberExpression = (MemberExpression)expression.Body;
    //        var property = (PropertyInfo)memberExpression.Member;
    //        var setMethod = property.GetSetMethod();

    //        var parameterT = Expression.Parameter(typeof(T), "x");
    //        var parameterTProperty = Expression.Parameter(typeof(TProperty), "y");

    //        var newExpression =
    //            Expression.Lambda<Action<T, TProperty>>(
    //                Expression.Call(parameterT, setMethod, parameterTProperty),
    //                parameterT,
    //                parameterTProperty
    //            );

    //        return newExpression.Compile();
    //    }
    //    public static string ToEmptyPlaceholder(this string val)
    //    {
    //        var emptyStr = "--NONE--";
    //        return !string.IsNullOrEmpty(val.ToNullSafeString()) ? val : emptyStr;

    //    }

    //    public static string ValueOrNull(this string str) => !string.IsNullOrWhiteSpace(str) ? str : null;

    //    public static bool IsNullOrEmpty(this Guid? val)
    //    {
    //        if (val == null)
    //            return true;
    //        if (val.HasValue && val.Value == Guid.Empty)
    //            return true;
    //        return false;
    //    }
    //    public static IEnumerable<string> RemoveEmptyStrings(this IEnumerable<string> list)
    //    {
    //        return list.Where(x => !string.IsNullOrEmpty(x));
    //    }
    //    public static bool Contains(this string source, string toCheck, StringComparison comp)
    //    {
    //        return source.IndexOf(toCheck, comp) >= 0;
    //    }

    //    public static void ReplaceIfNotNull<T>(this object destination, T source)
    //    {
    //        if (source is string && !string.IsNullOrEmpty(source.ToString()))
    //        { destination = source; return; }

    //        if (source != null)
    //            destination = source;
    //    }
    //    public static Type GetTypeEx(this object target)
    //    {
    //        return target.GetType().UnProxy();
    //    }
    //    public static Type UnProxy(this Type type)
    //    {
    //        var typeName = type.Name;
    //        if (typeName.EndsWith("Proxy"))
    //            type = type.BaseType;
    //        return type;
    //    }
    //    public static string ToNullSafeString(this object value)
    //    {
    //        return value == null ? string.Empty : value.ToString();
    //    }
    //    /// <summary>
    //    /// Returns words separated by capital letters
    //    /// MyPropertyName becomes My Property Name
    //    /// </summary>
    //    /// <param name="value"></param>
    //    /// <returns></returns>
    //    public static string ToSeparatedWords(this string value)
    //    {
    //        if (value != null)
    //            return Regex.Replace(value, "([A-Z][a-z]?)", " $1").Trim();
    //        return value;
    //    }

    //    /// <summary>
    //    /// Returns words separated by capital letters
    //    /// MyPropertyName becomes My Property Name
    //    /// </summary>
    //    /// <param name="str"></param>
    //    /// <returns></returns>
    //    public static string Wordify(this string str)
    //    {
    //        var newString = "";
    //        foreach (var c in str)
    //        {
    //            newString += char.IsUpper(c) ? " " + c : c.ToString();
    //        }
    //        return newString;
    //    }

    //    public static string ToInitials(this string str)
    //    {
    //        return string.Join("", str
    //            .ToTitleCase()
    //            .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
    //            .Select(x => x.Substring(0, 1)));
    //    }


    //    public static string ToTitleCase(this string str)
    //    {
    //        var textInfo = new CultureInfo("en-US", false).TextInfo;
    //        return textInfo.ToTitleCase(str); //War And Peace
    //    }
    //    public static string StripSpace(this string str)
    //    {
    //        return str.Trim().Replace(" ", "");
    //    }
    //    public static string ToPascalCase(this string str)
    //    {
    //        return str.ToTitleCase();
    //    }

    //    public static string RemovePattern(this string value, string patternToRemove)
    //    {
    //        if (string.IsNullOrEmpty(value)) return string.Empty;
    //        var regex = new Regex(patternToRemove);
    //        var result = value;
    //        foreach (Match match in regex.Matches(value))
    //        {
    //            result = result.Replace(match.Value, string.Empty);
    //        }
    //        return result;
    //    }
    //    /// <summary>
    //    /// Removes all html tags from string and leaves only plain text
    //    /// Removes content of <xml></xml> and <style></style> tags as aim to get text content not markup /meta data.
    //    /// </summary>
    //    /// <param name="input"></param>
    //    /// <returns></returns>
    //    public static string HtmlStrip(this string input)
    //    {
    //        if (string.IsNullOrEmpty(input))
    //            return string.Empty;

    //        input = Regex.Replace(input, "<style>(.|\n)*?</style>", string.Empty);
    //        input = Regex.Replace(input, @"<xml>(.|\n)*?</xml>", string.Empty); // remove all <xml></xml> tags and anything inbetween.  
    //        return Regex.Replace(input, @"<(.|\n)*?>", string.Empty); // remove any tags but not there content "<p>bob<span> johnson</span></p>" becomes "bob johnson"
    //    }

    //    public static bool HasPattern(this string value, string patternToMatch)
    //    {
    //        return value.GetPattern(patternToMatch).Count() > 0;
    //    }

    //    public static IEnumerable<string> GetPattern(this string value, string patternToMatch)
    //    {
    //        if (string.IsNullOrEmpty(value)) yield return value;

    //        var regex = new Regex(patternToMatch);
    //        foreach (Match match in regex.Matches(value))
    //        {
    //            yield return match.Value;
    //        }
    //    }


    //    public static string ToNullSafeJoinedString(this IEnumerable<object> list, string separator)
    //    {
    //        var safe = list.Where(i => i != null && !string.IsNullOrEmpty(i.ToString()));
    //        var result = string.Join(separator, safe.Select(i => i.ToString().Trim(separator.ToCharArray())).ToArray());
    //        //result = result.TrimStart(separator.ToCharArray()).TrimEnd(separator.ToCharArray());
    //        return result;
    //    }

    //    public static bool InSensitiveLike(this string value, string other)
    //    {
    //        return value.IndexOf(other, StringComparison.OrdinalIgnoreCase) != -1;
    //    }
    //    public static string TrimStart(this string value, string toRemove)
    //    {
    //        return value.RemovePattern("^" + toRemove);
    //    }
    //    public static string TrimEnd(this string value, string toRemove)
    //    {
    //        return value.RemovePattern("$" + toRemove);
    //    }
    //    public static string SanitizeForEnum(this string value, string replaceWith = "")
    //    {
    //        var illegals = new string[] { " ", "-", "/", ",", ":", ";", @"\", "&", "." };
    //        foreach (var illegal in illegals)
    //            value = value.Replace(illegal, replaceWith);
    //        return value;

    //    }
    //    public static string ToFileName(this string value, string replaceWith = "_")
    //    {
    //        var illegals = new string[] { "<", ">", "/", "\"", ":", "|", @"\", "?", "*", "#", "`" };
    //        foreach (var illegal in illegals)
    //            value = value.Replace(illegal, replaceWith);
    //        return value;

    //    }
    //    public static string ToEmailPrefix(this IEnumerable<string> list, string replaceWith = ".")
    //    {
    //        var names = list
    //            .Where(x => !string.IsNullOrWhiteSpace(x))
    //            .Select(x => x.Trim().Replace(" ", ""));
    //        var joined = string.Join(replaceWith, names);
    //        if (string.IsNullOrEmpty(joined))
    //            return string.Empty;

    //        joined = joined.ToFileName(replaceWith);

    //        return joined;
    //    }
    //    public static bool HasValue(this string s)
    //    {
    //        return !string.IsNullOrEmpty(s);
    //    }
    //    public static string RemoveIllegalChars(this string value, IEnumerable<string> illegals, string replaceWith = "")
    //    {

    //        foreach (var illegal in illegals)
    //            value = value.Replace(illegal, replaceWith);
    //        return value;

    //    }



    //    public static IEnumerable<string> ToSearchParameters(this string input)
    //    {
    //        return
    //            input
    //            .Split(new string[] { ",", ":", ";", "/", "\\", "|" }, StringSplitOptions.RemoveEmptyEntries)
    //            .Select(n => n.Trim());
    //    }



    //    public static bool IsHtmlEmpty(this string text)
    //    {
    //        if (string.IsNullOrEmpty(text))
    //            return true;
    //        var blacklist = new List<string> { "<p></p>", "<p/>", "<br/>", "<br>" };
    //        var stripped = text.Replace(" ", string.Empty)
    //            .Replace("&#160;", string.Empty)
    //            .Trim();
    //        return blacklist.Contains(stripped);
    //    }

    //    public static string ToYesNo(this bool val)
    //    {
    //        return val ? "Yes" : "No";
    //    }
    //    public static string ToBit(this string str) => str.ToUpper() == "YES" || str.ToUpper() == "Y" ? "1" : "0";
    //    public static string ToBit(this bool val) => val ? "1" : "0";

    //    public static string ToTrueFalse(this bool val)
    //    {
    //        return val ? "True" : "False";
    //    }


    //}


    ///// <summary>
    ///// Methods to remove HTML from strings.
    ///// </summary>
    //public static class HtmlRemoval
    //{
    //    /// <summary>
    //    /// Remove HTML from string with Regex.
    //    /// </summary>
    //    public static string StripTagsRegex(this string source)
    //    {
    //        return Regex.Replace(source, "<.*?>", string.Empty);
    //    }

    //    /// <summary>
    //    /// Compiled regular expression for performance.
    //    /// </summary>
    //    static readonly Regex _htmlRegex = new Regex("<.*?>", RegexOptions.Compiled);

    //    /// <summary>
    //    /// Remove HTML from string with compiled Regex.
    //    /// </summary>
    //    public static string StripTagsRegexCompiled(this string source)
    //    {
    //        return _htmlRegex.Replace(source, string.Empty);
    //    }

    //    /// <summary>
    //    /// Remove HTML tags from string using char array.
    //    /// </summary>
    //    public static string StripTagsCharArray(this string source)
    //    {
    //        var array = new char[source.Length];
    //        var arrayIndex = 0;
    //        var inside = false;

    //        for (var i = 0; i < source.Length; i++)
    //        {
    //            var let = source[i];
    //            if (let == '<')
    //            {
    //                inside = true;
    //                continue;
    //            }
    //            if (let == '>')
    //            {
    //                inside = false;
    //                continue;
    //            }
    //            if (!inside)
    //            {
    //                array[arrayIndex] = let;
    //                arrayIndex++;
    //            }
    //        }
    //        return new string(array, 0, arrayIndex);
    //    }
    //}

    //public static class FormattableObject
    //{
    //    public static string ToString(this object anObject, string aFormat)
    //    {
    //        return anObject.ToString(aFormat, null);
    //    }

    //    public static string ToString(this object anObject, string aFormat, IFormatProvider formatProvider)
    //    {
    //        var sb = new StringBuilder();
    //        var type = anObject.GetType();
    //        var reg = new Regex(@"({)([^}]+)(})", RegexOptions.IgnoreCase);
    //        var mc = reg.Matches(aFormat);
    //        var startIndex = 0;
    //        foreach (Match m in mc)
    //        {
    //            var g = m.Groups[2]; //it's second in the match between { and }
    //            var length = g.Index - startIndex - 1;
    //            sb.Append(aFormat.Substring(startIndex, length));

    //            var toGet = string.Empty;
    //            var toFormat = string.Empty;
    //            var formatIndex = g.Value.IndexOf(":"); //formatting would be to the right of a :
    //            if (formatIndex == -1) //no formatting, no worries
    //            {
    //                toGet = g.Value;
    //            }
    //            else //pickup the formatting
    //            {
    //                toGet = g.Value.Substring(0, formatIndex);
    //                toFormat = g.Value.Substring(formatIndex + 1);
    //            }

    //            //first try properties
    //            var retrievedProperty = type.GetProperty(toGet);
    //            Type retrievedType = null;
    //            object retrievedObject = null;
    //            if (retrievedProperty != null)
    //            {
    //                retrievedType = retrievedProperty.PropertyType;
    //                retrievedObject = retrievedProperty.GetValue(anObject, null);
    //            }
    //            else //try fields
    //            {
    //                var retrievedField = type.GetField(toGet);
    //                if (retrievedField != null)
    //                {
    //                    retrievedType = retrievedField.FieldType;
    //                    retrievedObject = retrievedField.GetValue(anObject);
    //                }
    //            }

    //            if (retrievedType != null) //Cool, we found something
    //            {
    //                var result = string.Empty;
    //                if (toFormat == string.Empty) //no format info
    //                {
    //                    result = retrievedType.InvokeMember("ToString",
    //                      BindingFlags.Public | BindingFlags.NonPublic |
    //                      BindingFlags.Instance | BindingFlags.InvokeMethod | BindingFlags.IgnoreCase
    //                      , null, retrievedObject, null) as string;
    //                }
    //                else //format info
    //                {
    //                    result = retrievedType.InvokeMember("ToString",
    //                      BindingFlags.Public | BindingFlags.NonPublic |
    //                      BindingFlags.Instance | BindingFlags.InvokeMethod | BindingFlags.IgnoreCase
    //                      , null, retrievedObject, new object[] { toFormat, formatProvider }) as string;
    //                }
    //                sb.Append(result);
    //            }
    //            else //didn't find a property with that name, so be gracious and put it back
    //            {
    //                sb.Append("{");
    //                sb.Append(g.Value);
    //                sb.Append("}");
    //            }
    //            startIndex = g.Index + g.Length + 1;
    //        }
    //        if (startIndex < aFormat.Length) //include the rest (end) of the string
    //        {
    //            sb.Append(aFormat.Substring(startIndex));
    //        }
    //        return sb.ToString();
    //    }
    //}

    //public static class ObjectToDictionaryHelper
    //{
    //    public static IDictionary<string, object> ToDictionary(this object source)
    //    {
    //        return source.ToDictionary<object>();
    //    }

    //    public static IDictionary<string, T> ToDictionary<T>(this object source)
    //    {
    //        if (source == null) ThrowExceptionWhenSourceArgumentIsNull();

    //        var dictionary = new Dictionary<string, T>();
    //        foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(source))
    //        {
    //            object value = property.GetValue(source);
    //            if (IsOfType<T>(value))
    //            {
    //                dictionary.Add(property.Name, (T)value);
    //            }
    //        }
    //        return dictionary;
    //    }

    //    private static bool IsOfType<T>(object value)
    //    {
    //        return value is T;
    //    }

    //    private static void ThrowExceptionWhenSourceArgumentIsNull()
    //    {
    //        throw new NullReferenceException("Unable to convert anonymous object to a dictionary. The source anonymous object is null.");
    //    }
    //}
}
