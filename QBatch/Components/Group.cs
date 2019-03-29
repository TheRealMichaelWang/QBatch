using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Components
{
    public class Group
    {
        public string[] lines;
        public string name;

        public Group(string[] allines,string name)
        {
            this.name = name;
            List<string> tohave = new List<string>();
            bool adding = false;
            bool found = false;
            foreach (string line in allines)
            {
                if(line == "#endmethod " + name)
                {
                    adding = false;
                    break;
                }
                if(adding)
                {
                    tohave.Add(line);
                }
                if(line == "#method "+name)
                {
                    if(found)
                    {
                        throw new Exception("#method '"+name+"' has already been found.");
                    }
                    adding = true;
                    found = true;
                }
            }
            if(adding)
            {
                throw new Exception("No #endmethod was found for the method '"+name+"'.");
            }
            lines = tohave.ToArray();
            if(lines.Contains("call "+name))
            {
                throw new Exception("Recursive function '"+name+"'detected.");
            }
            if(!found)
            {
                throw new Exception("Method '" + name + "' was never found");
            }
        }
    }
}
