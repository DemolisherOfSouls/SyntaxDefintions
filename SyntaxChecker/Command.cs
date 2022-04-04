
using System;

namespace SyntaxChecker;

internal class Command
{
  public string Name { get; private set; }
  public Delegate Action { get; private set; }

  Command () : this("Undefined") { }
  Command (string s) : this(s, null) { }
  Command (string s, Delegate d)
  {
    Name = s;
    Action = d;
  }

  public void Execute (object caller, string[] args)
  {
    Action.Method.Invoke(caller, args);
  }
}
