//namespace SyntaxDefinitions;

using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

using RO = System.Text.RegularExpressions.RegexOptions

string root = Directory.GetCurrentDirectory();
StreamReader stream;

RO RXOpt = RO.Multiline | RO.ExplicitCapture | RO.IgnorePatternWhitespace | RO.Singleline;

Regex RegExDraftsJSONIntact = new ("\\A\\s*(\\{|\\[|\"\\w+\"\\s*\\:\\s*)", RXOpt);
Regex RegExNppKeywords = new ("(<Keywords name=\"(?'group'Keywords\\d)\">)(\\s?(?'keyword'\\S+)*?)(<\\/Keywords>)", RXOpt);
string CommonSubroutines = "";
Regex ACSFunction = new ("(?x)[\\s](function)\\s+ (?'type'int|void|str|bool)\\s+ (?'func'\\w+)\\s* \\( \\s* ( (&type) \\s+ (\\w+) \\s* (, \\s* (&type) \\s+ (\\w+ ) \\s*)* | void) \\s* \\) \\s* \\{{ [^\\{{\\}}]*? ");
//&"(?mx)^[\t\x20]*(?'item_type'function)\s+ (?'return_type'(?'type'int|str|bool)|void) \s+ (?'func_name'\w+)\s* \( \s* (?'param_def' (?&type) \s+ (?'param_name1'\w+) \s* (?:, \s* (?&type) \s+ (?'param_name2'\w+ ) \s*)* | void) \s* \) \s* \{ \s*(?'func_body'([^\{\}]|(\{[^\{\}]*+\}))*)\s*+\}"

foreach ( string s in Directory.GetFiles(root) ) {

  bool IsXML = s.EndsWith("xml");
  bool IsJSON = s.EndsWith("json");

  if ( IsXML || IsJSON )
    stream = File.OpenText(s);
  else
    continue;

  string stringfile = stream.ReadToEnd();

  if ( IsXML ) {
    List<List<string>> KeywordList = new ();
    MatchCollection keywords = RegExNppKeywords.Matches(stringfile);
    int gnum = RegExNppKeywords.GroupNumberFromName("group");
    int knum = RegExNppKeywords.GroupNumberFromName("keyword");
    foreach ( Match match in keywords ) {
      CaptureCollection captures = match.Captures;
      foreach ( Capture c in captures ) {
        c.Value
      }
    }
  }
}

System.Console.WriteLine("Hello, World!");
