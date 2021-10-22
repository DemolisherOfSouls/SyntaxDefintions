//namespace SyntaxDefinitions;

using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;


string root = Directory.GetCurrentDirectory();
StreamReader stream;

RegexOptions RXOpt = RegexOptions.Multiline | RegexOptions.ExplicitCapture | RegexOptions.IgnorePatternWhitespace;

Regex RegExDraftsJSONIntact = new ("\\A\\s*(\\{|\\[|\"\\w+\"\\s*\\:\\s*)", RXOpt);
Regex RegExNppKeywords = new ("(<Keywords name=\"(?'group'Keywords\\d)\">)(\\s?(?'keyword'\\S+)*?)(<\\/Keywords>)", RXOpt);

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
    foreach ( Match match in keywords ) {
      var thissection = match.Groups;
    }
  }
}

System.Console.WriteLine("Hello, World!");
