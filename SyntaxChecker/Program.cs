
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml;

namespace SyntaxChecker;

internal class Program
{
  private static void LoadSettings ()
  {
    CodeArea = "Program.LoadSettings()";
    XmlReader reader = XmlReader.Create("Syntax.config");

    while ( reader.Read() )
    {

    }
  }

  public static string LastInput { get; private set; }
  public static string CodeArea { get; internal set; }



  /// <summary>
  /// Displays a message and requests user text input
  /// </summary>
  /// <param name="message">Message to display</param>
  public static void GetLine (string message = "Enter Command:")
  {
    Console.WriteLine(message);
    Console.Write(">");
    LastInput = Console.ReadLine();
  }

  private static void CheckSyntaxes ()
  {
    CodeArea = "Program.CheckSyntaxes()";
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
  }

  [STAThread]
  private static int Main (string[] args)
  {
    CodeArea = $"Program.Main({args})";

    return 0;
  }
}
