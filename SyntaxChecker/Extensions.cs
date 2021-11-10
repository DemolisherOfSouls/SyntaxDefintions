using System;
using System.Collections.Generic;

namespace SyntaxChecker;

public static class Extensions
{

  public static string Assemble (this List<string> list, string delim, string pre, string post) {
    string assembled = pre;

    if ( list.Count == 0 ) {
      throw new IndexOutOfRangeException("Extentions.Generate: List is Empty");
    }
    if ( list.Count == 1 ) {
      assembled = pre + list[0] + post;
    }
    else {
      for ( int i = 0; i < list.Count; i++ ) {
        assembled += list[i];
        if ( i < list.Count - 2 ) {
          assembled += delim;
        }
      }
      assembled += post;
    }
    return assembled;
  }

  public static string TranslateToRegex (this string s) {
    return s;
  }
}
