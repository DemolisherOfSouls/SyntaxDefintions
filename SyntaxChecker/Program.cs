
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace SyntaxChecker;

internal class Program
{
  [STAThread]
  private static int Main (string[] args)
  {
    foreach ( string s in Directory.GetFiles(V.Root) )
    {

      bool IsXML = s.EndsWith("xml");
      bool IsJSON = s.EndsWith("json");

      if ( IsXML || IsJSON )
      {
        V.Streamer = File.OpenText(s);
      }
      else
      {
        continue;
      }

      string stringfile = V.Streamer.ReadToEnd();

      if ( IsXML )
      {
        List<List<string>> KeywordList = new ();
        MatchCollection keywords = V.RegExNppKeywords.Matches(stringfile);
        //int gnum = V.RegExNppKeywords.GroupNumberFromName("group");
        //int knum = V.RegExNppKeywords.GroupNumberFromName("keyword");
        foreach ( Match match in keywords )
        {
          CaptureCollection captures = match.Captures;
          List <string> caplist = captures.ToList();
          foreach ( Capture c in captures )
          {

            caplist.Add(c.Value);
          }
          KeywordList.Add(caplist);
        }

        //Generate
        //string output = "";
      }
    }

    return 0;
  }
}
