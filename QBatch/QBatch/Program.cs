using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Components;

namespace QBatch
{
    class Program
    {
        static List<string> lines = new List<string>();
        static bool debug = false;
        static List<int> breakpoints = new List<int>();
        static int currentline = 1;

        static string[] heading = {"Interpreter Program",Environment.UserName,"No Copyright",Environment.CurrentDirectory};

        static Components.Program current
        {
            get
            {
                return new Components.Program(heading.Concat(lines.ToArray()).ToArray());
            }
        }

        static void ConsoleInterface()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("QBATCH " + Components.Information.CurrentVersion + " (last edit date: "+Components.Information.release.ToLongDateString()+")\n(C) Michael Wang 2019.\nType HELP for a list of all the QBatch Interpreter commands. For a  QBATCH programming guide, refer to the help documentation that came with QBATCH.");
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(currentline.ToString().PadRight(4,'>'));
                string input = Console.ReadLine().ToLower();
                string[] args = input.Split(' ');
                Console.ForegroundColor = ConsoleColor.Cyan;
                if (input == "help")
                {
                    Console.WriteLine("If no command is found, QBATCH will add it to the lines of code as reffered to in the command helps bellow.");
                    Console.WriteLine("Command Name:        Function:");
                    Console.WriteLine("HELP                 Gets Help.");
                    Console.WriteLine("RUN                  Runs all the lines of code.");
                    Console.WriteLine("CLEAR                Clears all the lines of code.");
                    Console.WriteLine("CD                   Sets the working directory for the program.");
                    Console.WriteLine("DEBUG ON             Turns debugging on.");
                    Console.WriteLine("DEBUG OFF            Turns debugging off.");
                    Console.WriteLine("BREAKPOINT           Adds or removes a breakpoint.");
                    Console.WriteLine("CLT                  Clears the terminal.");
                }
                else if (input == "run")
                {
                    try
                    {
                        Executor executor = new Executor();
                        executor.Debug = debug;
                        executor.breakpoints = breakpoints;
                        executor.RunProgram(current);
                        Console.WriteLine("The program has executed succesfully.");
                    }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("An error in your code was found\nError: " + ex.Message);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                else if (input == "clear")
                {
                    lines.Clear();
                    currentline = 1;
                }
                else if (input == "debug on")
                {
                    Console.WriteLine("Debugging enabled. Breakpoints can now be hit.");
                    debug = true;
                }
                else if (input == "debug off")
                {
                    Console.WriteLine("Debugging disabled.");
                    debug = false;
                }
                else if (args[0] == "breakpoint")
                {
                    if (args.Length == 2)
                    {
                        try
                        {
                            int line = int.Parse(args[1]);
                            if(current.codelines[line-1] == "pass" || current.codelines[line-1] == "")
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Error. Cannot place a breakpoint at a blank or pass.");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            else if (breakpoints.Contains(line-1))
                            {
                                breakpoints.Remove(line);
                                Console.WriteLine("Breakpoint removed at line " + line + ".");
                            }
                            else
                            {
                                breakpoints.Add(line-1);
                                Console.WriteLine("Breakpoint created at line " + line + ".");
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Enter in a line number");
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Insufficient or to many arguments");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                else if (args[0] == "cd")
                {
                    if (args.Length == 2)
                    {
                        heading[3] = args[1];
                        Console.WriteLine("Working directory set to " + args[1] + ".");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Insufficient or to many arguments");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                else if (input == "clt") 
                {
                    Console.Clear();
                }
                else
                {
                    lines.Add(input);
                    currentline++;
                }
            }
        }

        static void Main(string[] args)
        {
            Console.Title = "QBatch";
            if(args.Length >= 1)
            {
                try
                {
                    Components.Program torun = new Components.Program(args[0]);
                    Executor executor = new Executor();
                    if(args.Length == 2 && args[1] != "nodebug")
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        executor.Debug = true;
                        List<string> bp = args[1].Split(',').ToList();
                        Console.WriteLine("Debugging is now enabled.");
                        foreach(string b in bp)
                        {
                            try
                            {
                                executor.breakpoints.Add(int.Parse(b)-1);
                                Console.WriteLine("Adding Breakpoint at line " + b);
                                Console.ForegroundColor = ConsoleColor.Red;
                                if(torun.codelines[int.Parse(b)-1] == "")
                                {
                                    Console.WriteLine("Invalid Line: " + b + "\nCannot place breakpoint at a blank line.");
                                }
                                Console.ForegroundColor = ConsoleColor.Cyan;
                            }
                            catch
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Invalid Line: "+b);
                                Console.ForegroundColor = ConsoleColor.Cyan;
                            }
                        }
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    try
                    {
                        executor.RunProgram(torun);
                    }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("An error occured.\nMsg: " + ex.Message);
                        Console.WriteLine("Application Name: " + torun.name);
                        Console.WriteLine("Publisher: " + torun.author);
                        Console.WriteLine(torun.copyright);
                        Console.WriteLine("Based on the info above, you may want to notify the publisher of the application.\n\nPress ANY KEY to exit...");
                        Console.ReadKey();
                    }
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("No Assembly Bindings were detected!\nThis isn't a QBatch batch file executable program. QBATCH assembly information wasn't found. If you wrote the program using QBATCH IDE, consider pressing the MakeASM button. Otheerwise if you are sure this is a QBATCH program, this program may be a library To use a library, use #import to access its methods.\nFile Path: "+args[0]+ "\n\nPress ANY KEY to exit...");
                    Console.ReadKey();
                }
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                ConsoleInterface();
            }
        }
    }
}
