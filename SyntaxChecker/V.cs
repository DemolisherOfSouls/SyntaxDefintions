using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

using Duration = System.TimeSpan;
using Entry = System.Collections.Generic.KeyValuePair<string, string>;
using RegEx = System.Text.RegularExpressions.Regex;
using RO = System.Text.RegularExpressions.RegexOptions;

namespace SyntaxChecker;

public class RegExPart
{
  private static ushort next = 1;
  private RegEx exp;
  private ushort id;

  public RegExPart (string rx, RO opt = RO.CultureInvariant & RO.Multiline, int ticks = 200)
  {
    id = next++;
    exp = new RegEx(rx, opt, new Duration(ticks));
  }

  public bool Test (string s)
  {
    return exp.IsMatch(s);
  }

  public List<List<string>> Execute (string s)
  {
    List<List<string>> list = new ();
    MatchCollection mc = exp.Matches(s);
    for ( int im = 0; im < mc.Count; im++ )
    {
      Match m = mc[im];
      list.Add(new List<string>());
      for ( int ic = 0; im < m.Captures.Count; ic++ )
      {
        Capture c = m.Captures[ic];
        list[im].Add(c.Value);
      }
    }
    return list;
  }
}

internal class V
{
  protected internal class ACS
  {
    static Entry c = new ("type","(?'type'int|void|str|bool|char)");

    private static Entry[] type =
    {
      c,
      new Entry("type","(?'type'int|void|str|bool|char)")
    };
    private const string identifier = "(?'identifier'[a-zA-Z_]\\w*)";


    public static string Definition = "(?(DEFINE)" + type + ")";

  }

  protected internal static string Root => Directory.GetCurrentDirectory();
  protected internal static RO DefaultRXOpt => RO.Multiline | RO.ExplicitCapture | RO.IgnorePatternWhitespace | RO.Singleline;

  protected internal static StreamReader Streamer;
  protected internal static Regex RegExDraftsJSONIntact = new ("\\A\\s*(\\{|\\[|\"\\w+\"\\s*\\:\\s*)", DefaultRXOpt);
  protected internal static Regex RegExNppKeywords = new ("(<Keywords name=\"(?'group'Keywords\\d)\">)(\\s?(?'keyword'\\S+)*?)(<\\/Keywords>)", V.DefaultRXOpt);


  protected internal static Regex ACSFunction = new ("(?x)[\\s](function)\\s+ (?'type'int|void|str|bool|char)\\s+ (?'func'\\w+)\\s* \\( \\s* ( (&type) \\s+ (\\w+) \\s* (, \\s* (&type) \\s+ (\\w+ ) \\s*)* | void) \\s* \\) \\s* \\{{ [^\\{{\\}}]*? ", DefaultRXOpt);

  //&"(?mx)^[\t\x20]*(?'item_type'function)\s+ (?'return_type'(?'type'int|str|bool)|void) \s+ (?'func_name'\w+)\s* \( \s* (?'param_def' (?&type) \s+ (?'param_name1'\w+) \s* (?:, \s* (?&type) \s+ (?'param_name2'\w+ ) \s*)* | void) \s* \) \s* \{ \s*(?'func_body'([^\{\}]|(\{[^\{\}]*+\}))*)\s*+\}"
}
