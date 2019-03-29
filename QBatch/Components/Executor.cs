using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace Components
{
    public class Executor
    {
        VariableManager variables;
        public bool Paused = false;
        public bool Debug = false;
        public List<int> breakpoints = new List<int>();

        public Executor()
        {
            variables = new VariableManager();
        }

        public void ExecuteCommand(string command, Program program)
        {
            if (command == "" || command == "pass")
            {
                return;
            }
            string[] args = command.Split(' ');
            if (args[0] == "writeline" || args[0] == "write" || args[0] == "title" || args[0] == "forecolor" || args[0] == "backcolor" || args[0] == "mkfile" || args[0] == "delfile" || args[0] == "start" || args[0] == "mkdir" || args[0] == "deldir")
            {
                string[] value1args = args[1].Split(':');
                string value1;
                if (value1args[0] == "raw")
                {
                    value1 = value1args[1];
                }
                else if (value1args[0] == "var")
                {
                    value1 = variables.GetValue(value1args[1], value1args[2]);
                }
                else
                {
                    throw new Exception("QB Invalid type.");
                }
                if (args[0] == "writeline")
                {
                    Console.WriteLine(value1);
                }
                if (args[0] == "write")
                {
                    Console.Write(value1);
                }
                if (args[0] == "title")
                {
                    Console.Title = value1;
                }
                if (args[0] == "forecolor")
                {
                    if (value1 == "red")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else if (value1 == "yellow")
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    else if (value1 == "green")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else if (value1 == "blue")
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }
                    else if (value1 == "white")
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (value1 == "black")
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    else
                    {
                        throw new Exception("The color " + value1 + "doesn't exist in '" + command + "'.");
                    }
                }
                if (args[0] == "backcolor")
                {
                    if (value1 == "red")
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                    }
                    else if (value1 == "yellow")
                    {
                        Console.BackgroundColor = ConsoleColor.Yellow;
                    }
                    else if (value1 == "green")
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                    }
                    else if (value1 == "blue")
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                    }
                    else if (value1 == "white")
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                    }
                    else if (value1 == "black")
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    else
                    {
                        throw new Exception("The color " + value1 + "doesn't exist in '" + command + "'.");
                    }
                }
                if (args[0] == "mkfile")
                {
                    File.Create(program.directory + "\\" + value1).Close();
                }
                if (args[0] == "delfile")
                {
                    File.Delete(program.directory + "\\" + value1);
                }
                if (args[0] == "start")
                {
                    Process.Start(program.directory + "\\" + value1);
                }
                if (args[0] == "mkdir")
                {
                    Directory.CreateDirectory(program.directory + "\\" + value1);
                }
                if (args[0] == "deldir")
                {
                    Directory.Delete(program.directory + "\\" + value1);
                }
            }
            else if (args[0] == "filecopy" || args[0] == "dirmove" || args[0] == "filewrite")
            {
                string[] value1args = args[1].Split(':');
                string value1;
                if (value1args[0] == "raw")
                {
                    value1 = value1args[1];
                }
                else if (value1args[0] == "var")
                {
                    value1 = variables.GetValue(value1args[1], value1args[2]);
                }
                else
                {
                    throw new Exception("QB Invalid type.");
                }
                string[] value2args = args[2].Split(':');
                string value2;
                if (value2args[0] == "raw")
                {
                    value2 = value2args[1];
                }
                else if (value1args[0] == "var")
                {
                    value2 = variables.GetValue(value2args[1], value2args[2]);
                }
                else
                {
                    throw new Exception("QB Invalid type.");
                }
                if (args[0] == "filecopy")
                {
                    File.Copy(program.directory + "\\" + value1, value2);
                }
                if (args[0] == "dirmove")
                {
                    Directory.Move(program.directory + "\\" + value1, value2);
                }
                if (args[0] == "filewrite")
                {
                    File.WriteAllText(program.directory + "\\" + value1, value2);
                }
            }
            else if (args[0] == "#declarevar")
            {
                variables.DeclareVariable(args[1], args[2], args[3]);
            }
            else if (args[0] == "readkey")
            {
                Console.ReadKey();
            }
            else if (args[0] == "consoleclear")
            {
                Console.Clear();
            }
            else if (args[0] == "call")
            {
                RunGroup(new Group(program.codelines, args[1]), program);
            }
            else if (args[1] == "=")
            {
                string[] toset = args[0].Split(':');
                if (args[2] == "input")
                {
                    variables.SetValue(toset[0], Console.ReadLine(), toset[1]);
                    return;
                }
                else if (args[2] == "confirm")
                {
                    Console.WriteLine("Are you sure?(y/n/yes/no)");
                    string input = Console.ReadLine();
                    if (input == "y" || input == "yes")
                    {
                        variables.SetValue(toset[0], "yes", toset[1]);
                    }
                    else if (input == "n" || input == "no")
                    {
                        variables.SetValue(toset[0], "no", toset[1]);
                    }
                    else
                    {
                        variables.SetValue(toset[0], "?", toset[1]);
                    }
                    return;
                }
                else if (args[2] == "readfile")
                {
                    string[] value1args = args[3].Split(':');
                    string value1;
                    if (value1args[0] == "raw")
                    {
                        value1 = value1args[1];
                    }
                    else if (value1args[0] == "var")
                    {
                        value1 = variables.GetValue(value1args[1], value1args[2]);
                    }
                    else
                    {
                        throw new Exception("Invalid type.");
                    }
                    variables.SetValue(toset[0], File.ReadAllText(program.directory + "\\" + value1), toset[1]);
                }
                else if (args.Length == 3)
                {
                    string[] value1args = args[2].Split(':');
                    string value1;
                    if (value1args[0] == "raw")
                    {
                        value1 = value1args[1];
                    }
                    else if (value1args[0] == "var")
                    {
                        value1 = variables.GetValue(value1args[1], value1args[2]);
                    }
                    else
                    {
                        throw new Exception("Invalid type.");
                    }
                    variables.SetValue(toset[0], value1, toset[1]);
                    return;
                }
                else if (args[3] == "+" || args[3] == "-" || args[3] == "*" || args[3] == "/" || args[3] == "%" ||args[3] == "^" || args[3] == "rad")
                {
                    if (args.Length != 5)
                    {
                        throw new Exception("Insufficient arguments");
                    }
                    string[] value1args = args[2].Split(':');
                    string[] value2args = args[4].Split(':');
                    int value1 = 0;
                    int value2 = 0;

                    if (value1args[0] == "raw")
                    {
                        value1 = int.Parse(value1args[1]);
                    }
                    else if (value1args[0] == "var")
                    {
                        value1 = int.Parse(variables.GetValue(value1args[1], value1args[2]));
                    }
                    else
                    {
                        throw new Exception("Invalid type.");
                    }
                    if (value2args[0] == "raw")
                    {
                        value2 = int.Parse(value2args[1]);
                    }
                    else if (value2args[0] == "var")
                    {
                        value2 = int.Parse(variables.GetValue(value2args[1], value2args[2]));
                    }
                    else
                    {
                        throw new Exception("Invalid type.");
                    }
                    if (args[3] == "+")
                    {
                        variables.SetValue(toset[0], (value1 + value2).ToString(), toset[1]);
                        return;
                    }
                    else if (args[3] == "-")
                    {
                        variables.SetValue(toset[0], (value1 - value2).ToString(), toset[1]);
                        return;
                    }
                    else if (args[3] == "*")
                    {
                        variables.SetValue(toset[0], (value1 * value2).ToString(), toset[1]);
                        return;
                    }
                    else if (args[3] == "/")
                    {
                        variables.SetValue(toset[0], (value1 / value2).ToString(), toset[1]);
                        return;
                    }
                    else if (args[3] == "%")
                    {
                        variables.SetValue(toset[0], (value1 - value2).ToString(), toset[1]);
                        return;
                    }
                    else if(args[3] == "^")
                    {
                        variables.SetValue(toset[0], (value1 ^ value2).ToString(), toset[1]);
                        return;
                    }
                }
                else if (args[3] == "cnstr")
                {
                    string[] value1args = args[2].Split(':');
                    string[] value2args = args[4].Split(':');
                    string value1 = null;
                    string value2 = null;

                    if (value1args[0] == "raw")
                    {
                        value1 = value1args[1];
                    }
                    else if (value1args[0] == "var")
                    {
                        value1 = variables.GetValue(value1args[1], value1args[2]);
                    }
                    else
                    {
                        throw new Exception("Invalid type.");
                    }
                    if (value2args[0] == "raw")
                    {
                        value2 = value2args[1];
                    }
                    else if (value2args[0] == "var")
                    {
                        value2 = variables.GetValue(value2args[1], value2args[2]);
                    }
                    else
                    {
                        throw new Exception("Invalid type.");
                    }
                    variables.SetValue(toset[0], value1 + value2, toset[1]);
                    return;
                }
                else
                {
                    throw new Exception("That function doesn't exist.");
                }
            }
            else
            {
                throw new Exception("Unrecognized command");
            }
        }

        public bool VerifyCondition(string[] args)
        {
            if(args[1] == "true")
            {
                return true;
            }
            string[] value1args = args[1].Split(':');
            string[] value2args = args[3].Split(':');
            string value1 = null;
            string value2 = null;

            if (value1args[0] == "raw")
            {
                value1 = value1args[1];
            }
            else if (value1args[0] == "var")
            {
                value1 = variables.GetValue(value1args[1], value1args[2]);
            }
            else
            {
                throw new Exception("Invalid type.");
            }
            if (value2args[0] == "raw")
            {
                value2 = value2args[1];
            }
            else if (value2args[0] == "var")
            {
                value2 = variables.GetValue(value2args[1], value2args[2]);
            }
            else
            {
                throw new Exception("Invalid type.");
            }

            if (args[2] == "==")
            {
                if(value1 == value2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            if(args[2] == "!=")
            {
                if(value1 != value2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            throw new Exception("Invalid Condition Syntax.");
        }

        public void RunGroup(Group group,Program program)
        {
            for (int i = 0; i < group.lines.Length; i++)
            {
                foreach(int breakpoint in breakpoints)
                {
                    if(program.codelines[breakpoint] == group.lines[i])
                    {
                        Paused = true;
                    }
                }
                if(Paused)
                {
                    ConsoleColor consoleColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    if(Debug)
                    {
                        Console.WriteLine("Just-In-Time Debugger");
                        Console.WriteLine("Line Number in Method: " + i);
                        Console.WriteLine("Line Text: " + group.lines[i]);
                        Console.WriteLine("Current Method: " + group.name);
                        Console.WriteLine("Current Program: " + program.name);
                        Console.WriteLine("\nVariable Watch:\n");
                        variables.PrintVariableValues();
                    }
                    else
                    {
                        Console.WriteLine("Paused...");
                    }
                    Console.WriteLine("Press ENTER to continue");
                    Console.ForegroundColor = consoleColor;
                    Console.ReadKey();
                    Paused = false;
                }
                string[] args = group.lines[i].Split(' ');
                if (args[0] == "if")
                {
                    if (VerifyCondition(args))
                    {
                        ExecuteCommand(group.lines[i + 1],program);
                    }
                    i = i + 1;
                }
                else if(args[0] == "while")
                {
                    while(VerifyCondition(args))
                    {
                        ExecuteCommand(group.lines[i + 1], program);
                    }
                    i = i + 1;
                }
                else if(args[0] == "repeat")
                {
                    int howmany = int.Parse(args[1]);
                    for (int x = 0; x < howmany; x++)
                    {
                        ExecuteCommand(group.lines[i + 1], program);
                    }
                    i = i + 1;
                }
                else
                {
                    ExecuteCommand(group.lines[i],program);
                }
            }
        }
        public void RunProgram(Program program)
        {
            foreach(string line in program.codelines)
            {
                string[] args = line.Split(' ');
                if(args[0] == "#import")
                {
                    string[] newlines = File.ReadAllLines(program.directory + "\\" + args[1]);
                    program.codelines = program.codelines.Concat(newlines).ToArray();
                }
            }
            RunGroup(new Group(program.codelines, "main"), program);
        }
    }
}
