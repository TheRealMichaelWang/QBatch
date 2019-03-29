using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Components
{
    public class Variable
    {
        public string name;
        public string type;
        public string rawvalue;

        public Variable(string type,string name,string rawvalue)
        {
            this.name = name;
            this.type = type;
            this.rawvalue = rawvalue;
        }

        public string GetValue(string arguments)
        {
            if(type == "arr")
            {
                if (arguments == "length")
                {
                    return rawvalue.Split(',').Length.ToString();
                }
                else
                {
                    return rawvalue.Split(',')[int.Parse(arguments)];
                }
            }
            if(type == "var")
            {
                if(arguments == "tolower")
                {
                    return rawvalue.ToLower();
                }
                if(arguments == "toupper")
                {
                    return rawvalue.ToUpper();
                }
                if(arguments == "isint")
                {
                    try
                    {
                        int.Parse(rawvalue);
                        return "true";
                    }
                    catch
                    {
                        return "false";
                    }
                }
                return rawvalue;
            }
            throw new Exception("Invalid type.");
        }

        public void SetValue(string value,string arguments)
        {
            if (type == "arr")
            {
                List<string> arr = new List<string>(rawvalue.Split(','));
                if (value == "deleteat")
                {
                    arr.RemoveAt(int.Parse(arguments));
                }
                else if(arguments == "add")
                {
                    arr.Add(value);
                }
                else
                {
                    arr[int.Parse(arguments)] = value;
                }
                string temp = arr[0];
                for (int i = 1; i < arr.Count; i++)
                {
                    temp = temp + "," + arr[i];
                }
                rawvalue = temp;
            }
            else if (type == "var")
            {
                rawvalue = value;
            }
            else
            {
                throw new Exception("Invalid Type");
            }
        }
    }

    public class VariableManager
    {
        List<Variable> variables = new List<Variable>();

        public VariableManager()
        {

        }

        public string GetValue(string name, string arguments)
        {
            foreach (Variable variable in variables)
            {
                if (variable.name == name)
                {
                    return variable.GetValue(arguments);
                }
            }
            throw new Exception("The variable " + name + " doesn't exist.");
        }

        public void SetValue(string name, string value, string arguments)
        {
            foreach (Variable variable in variables)
            {
                if (variable.name == name)
                {
                    variable.SetValue(value, arguments);
                    return;
                }
            }
            throw new Exception("The variable " + name + " doesn't exist.");
        }

        public void DeclareVariable(string type,string name,string value)
        {
            foreach (Variable variable in variables)
            {
                if (variable.name == name)
                {
                    throw new Exception("The variable " + name + " already exists");
                }
            }
            variables.Add(new Variable(type, name, value));
        }

        public void PrintVariableValues()
        {
            foreach(Variable variable in variables)
            {
                Console.WriteLine("Name: ".PadRight(15) + "Type".PadRight(5) + "Raw Value".PadRight(50));
                Console.WriteLine(variable.name.PadRight(15) + variable.type.PadRight(5) + variable.rawvalue.PadRight(50));
            }
        }
    }
}
