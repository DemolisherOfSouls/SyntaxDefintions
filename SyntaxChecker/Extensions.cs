using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SyntaxChecker;
public enum EscapeOptions
{
  BS  = 1, //Backslash
  DQ  = 2, //Double Quote
  SQ  = 4  //Single Quote
}
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

  public static Dictionary<string, CaptureCollection> ToDictionary (this GroupCollection groupCollection)
  {
    Dictionary<string, CaptureCollection> dic = new();
    foreach ( Group group in groupCollection )
    {
      dic.Add(group.Name, group.Captures);
    }
    return dic;
  }

  public static List<string> ToList (this CaptureCollection captureCollection)
  {
    List<string> list = new();
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

  public static bool IsNullOrEmpty (this string s)
  {
    return String.IsNullOrEmpty(s);
  }

  public static string ReplaceList (this string s, IList<string> old, IList<string> replacement, bool ignoreCase = false)
  {
    var defRep = StringComparison.Ordinal;
    if ( ignoreCase )
      defRep = StringComparison.OrdinalIgnoreCase;

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

      s = s.Replace(old[i], replacement[i], defRep);

    }
    return s;
  }

  public static string Escape (this string current, EscapeOptions opt = EscapeOptions.BS)
  {
    var BSPrepender = new MatchEvaluator((Match m) => @"\" + m.Value)

    if ( current is null )
      return null;

    if ( opt.HasFlag(EscapeOptions.BS) )
    {
      Regex BSReplacer = new (@"(?<!\\)(\\[ntvrb0f])");
      current = BSReplacer.Replace(current, BSPrepender);
    }

    if ( opt.HasFlag(EscapeOptions.SQ) )
    {
      Regex SQReplacer = new (@"(?<!\\)'");
      current = SQReplacer.Replace(current, BSPrepender);
    }

    if ( opt.HasFlag(EscapeOptions.DQ) )
    {
      Regex SQReplacer = new (@"(?<!\\)""");
      current = SQReplacer.Replace(current, BSPrepender);
    }

    if ( opt == EscapeOptions.SQ )
    {

    }

    return current;
  }
}
