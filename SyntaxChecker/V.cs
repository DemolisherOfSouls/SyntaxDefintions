using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

using Duration = System.TimeSpan;
using Entry = System.Collections.Generic.KeyValuePair<string, int>;
using RegEx = System.Text.RegularExpressions.Regex;
using RO = System.Text.RegularExpressions.RegexOptions;

namespace SyntaxChecker;

public class RegExPart
{
  private static ushort next = 1;
  private static IList<string> rxNames = new List<string>();
  private static IList<RegExPart> rxValues = new List<RegExPart>();

  public static ushort Add (string name, string rx, RO opt = RO.CultureInvariant & RO.Multiline)
  {
    var x = new RegExPart(rx, opt);
    rxNames.Add(name);
    rxValues.Add(x);
    return x.id;
  }

  private RegEx exp;
  private ushort id;
  private bool executed = false;
  private MatchCollection lastmc;

  public RegExPart (string rx, RO opt, int ticks = 200)
  {
    id = next++;
    exp = new RegEx(rx, opt, new Duration(ticks));
  }

  public bool Test (string s)
  {
    return exp.IsMatch(s);
  }

  public void Execute (string s)
  {
    lastmc = exp.Matches(s);
    executed = true;
  }
}

internal static class V
{
  eeee
  internal class ACS
  {
    static Entry c = new ("type","(?'type'int|void|str|bool|char)");

    private static List<Entry> type = new()
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
