using System.IO;
using System.Text.RegularExpressions;

using RO = System.Text.RegularExpressions.RegexOptions;

namespace SyntaxChecker;

internal class V {

  protected internal static string Root => Directory.GetCurrentDirectory();
  protected internal static RO DefaultRXOpt => RO.Multiline | RO.ExplicitCapture | RO.IgnorePatternWhitespace | RO.Singleline;

  protected internal static StreamReader Streamer;
  protected internal static Regex RegExDraftsJSONIntact = new ("\\A\\s*(\\{|\\[|\"\\w+\"\\s*\\:\\s*)", DefaultRXOpt);
  protected internal static Regex RegExNppKeywords = new ("(<Keywords name=\"(?'group'Keywords\\d)\">)(\\s?(?'keyword'\\S+)*?)(<\\/Keywords>)", V.DefaultRXOpt);
  protected internal static string CommonSubroutines = "(?(DEFINE)" + "" + ")";
  protected internal static Regex ACSFunction = new ("(?x)[\\s](function)\\s+ (?'type'int|void|str|bool)\\s+ (?'func'\\w+)\\s* \\( \\s* ( (&type) \\s+ (\\w+) \\s* (, \\s* (&type) \\s+ (\\w+ ) \\s*)* | void) \\s* \\) \\s* \\{{ [^\\{{\\}}]*? ", DefaultRXOpt);

  //&"(?mx)^[\t\x20]*(?'item_type'function)\s+ (?'return_type'(?'type'int|str|bool)|void) \s+ (?'func_name'\w+)\s* \( \s* (?'param_def' (?&type) \s+ (?'param_name1'\w+) \s* (?:, \s* (?&type) \s+ (?'param_name2'\w+ ) \s*)* | void) \s* \) \s* \{ \s*(?'func_body'([^\{\}]|(\{[^\{\}]*+\}))*)\s*+\}"
}