//namespace SyntaxDefinitions;

using System.IO;
using System.Text.RegularExpressions;


string root = Directory.GetCurrentDirectory();
StreamReader stream;

foreach ( string s in Directory.GetFiles(root) ) {

  if ( s.EndsWith("xml") || s.EndsWith("json") )
    stream = File.OpenText(s);
  else
    continue;

  string stringfile = stream.ReadToEnd();

  var RXOpt = RegexOptions.Multiline | RegexOptions.ExplicitCapture | RegexOptions.IgnorePatternWhitespace;

  Regex RegExDraftsJSONIntact = new Regex("" +
    "\\A", RXOpt) {

  };
}

System.Console.WriteLine("Hello, World!");
