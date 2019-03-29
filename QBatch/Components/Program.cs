using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Components
{
    public class Program
    {
        public string name = "";
        public string author = "";
        public string copyright = "";
        public string directory = "";
        public string[] codelines = {};

        public Program(string filepath)
        {
            string[] datalines = File.ReadAllLines(filepath);
            name = datalines[0];
            author = datalines[1];
            copyright = datalines[2];
            directory = datalines[3];
            directory = directory.Replace("[username]", Environment.UserName);
            directory = directory.Replace("[documents]", Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
            directory = directory.Replace("[desktop]", Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
            directory = directory.Replace("[programs]", Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles));
            List<string> codelines = new List<string>();

            for (int i = 4; i < datalines.Length; i++)
            {
                codelines.Add(datalines[i]);
            }
            this.codelines = codelines.ToArray();
        }

        public Program(string[] datalines)
        {
            name = datalines[0];
            author = datalines[1];
            copyright = datalines[2];
            directory = datalines[3];
            directory = directory.Replace("[username]", Environment.UserName);
            directory = directory.Replace("[documents]", Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
            directory = directory.Replace("[desktop]", Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
            directory = directory.Replace("[programs]", Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles));
            List<string> codelines = new List<string>();

            for (int i = 4; i < datalines.Length; i++)
            {
                codelines.Add(datalines[i]);
            }
            this.codelines = codelines.ToArray();
        }
    }
}
