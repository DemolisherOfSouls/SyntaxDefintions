using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SyntaxChecker;

/// <summary>
/// Container class to store extensions
/// </summary>
public static class Extensions
{

  public static string Assemble (this List<string> list, string delim, string pre, string post)
  {
    string assembled = pre;

    if ( list.Count == 0 )
    {
      throw new IndexOutOfRangeException("Extentions.Generate: List is Empty");
    }
    if ( list.Count == 1 )
    {
      assembled = pre + list[0] + post;
    }
    else
    {
      for ( int i = 0; i < list.Count; i++ )
      {
        assembled += list[i];
        if ( i < list.Count - 2 )
        {
          assembled += delim;
        }
      }
      assembled += post;
    }
    return assembled;
  }

  public static List<string> ToList (this CaptureCollection captureCollection)
  {
    List<string> list = new ();
    foreach ( Capture capture in captureCollection )
    {
      list.Add(capture.Value);
    }
    return list;
  }

  public static string TranslateToRegex (this string s)
  {
    //TODO: Add Translate Function
    return s;
  }

  /// <summary>
  /// Checks if the string is null or empty.
  /// </summary>
  /// <param name="s">This string</param>
  /// <returns><see langword="true"/> if the string is null or empty, <see langword="false"/> otherwise.</returns>
  public static bool IsNullOrEmpty (this string s)
  {
    return String.IsNullOrEmpty(s);
  }

  public static string ReplaceList (this string s, List<string> old, List<string> replacement, bool ignoreCase = false)
  {

    if ( s.IsNullOrEmpty() )
    {
      return s;
    }

    if ( old is null )
    {
      throw new ArgumentNullException(nameof(old));
    }

    if ( replacement is null )
    {
      throw new ArgumentNullException(nameof(replacement));
    }

    if ( old.Count != replacement.Count )
    {
      throw new ArgumentOutOfRangeException(nameof(replacement), replacement.Count, "Invalid number of items in replacement list");
    }

    for ( int i = 0; i < old.Count; i++ )
    {
      s = s.Replace(old[i], replacement[i], ignoreCase ? StringComparison.CurrentCultureIgnoreCase : StringComparison.CurrentCulture);
    }


    return s;
  }

  public enum EscapeOptions
  {
    EscapeBackSlashOnly = 0,
    EscapeForJSON = 1,
    EscapeForXML = 2,
  }

  public static string PrependBS (Match match)
  {
    return @"\" + match.Value;
  }

  /// <summary>
  /// Escapes the string with the style specified
  /// </summary>
  /// <param name="current">This string</param>
  /// <param name="opt">Options flags</param>
  /// <returns>The escaped string</returns>
  public static string Escape (this string current, EscapeOptions opt)
  {
    if ( current.IsNullOrEmpty() )
    {
      return current;
    }

    Regex BSReplacer = new (@"(?<!\\)(\\[ntvrb0f])");
    MatchEvaluator BSPrepender = new (PrependBS);

    if ( opt == EscapeOptions.EscapeForJSON )
    {
      current = BSReplacer.Replace(current, BSPrepender);
    }

    return current;
  }

}
