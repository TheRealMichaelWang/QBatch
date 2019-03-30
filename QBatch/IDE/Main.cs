using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IDE
{
    public partial class Main : Form
    {
        string filepath = "untitled program";
        string debugargs = "nodebug";
        FileInfo current
        {
            get
            {
                return new FileInfo(filepath);
            }
        }

        public Main()
        {
            InitializeComponent();
            if(Environment.GetCommandLineArgs().Length == 2)
            { 
                filepath = Environment.GetCommandLineArgs()[1];
                CodeInput.Lines = File.ReadAllLines(filepath);
            }
        }
        
        private void RunCode_Click(object sender, EventArgs e)
        {
            if(!File.Exists(filepath))
            {
                MessageBox.Show("Source must be saved.", "IDE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Save_Click(null, null);
            }
            try
            {
                Process.Start(Environment.CurrentDirectory + "\\QBatch.exe","\""+filepath+ "\" \""+debugargs+ "\"");
            }
            catch
            {
                MessageBox.Show("QBatch interpreter not found!", "IDE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if(saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                filepath = saveFileDialog.FileName;
                File.WriteAllLines(filepath,CodeInput.Lines);
            }
        }

        private void Open_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filepath = openFileDialog.FileName;
                CodeInput.Lines = File.ReadAllLines(filepath);
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            this.Text = "QBatch IDE  -" + current.Name;
            this.CursorPositionOutput.Text = "CurrentLine in Program: " + (this.CodeInput.GetLineFromCharIndex(this.CodeInput.GetFirstCharIndexOfCurrentLine())-3) + "  Current Line in File: "+ this.CodeInput.GetLineFromCharIndex(this.CodeInput.GetFirstCharIndexOfCurrentLine());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(Environment.CurrentDirectory + "//QBatch.exe");
            }
            catch
            {
                MessageBox.Show("QBatch interpreter not found!", "IDE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EditDebugArguments_Click(object sender, EventArgs e)
        {
            Prompt prompt = new Prompt("Enter Debug Arguments (enter nodebug for no debugging)",debugargs);
            if(prompt.Canceled == false)
            {
                debugargs = prompt.Output;
            }
            else
            {
                debugargs = "nodebug";
            }
        }

        private void AutoAddMethod_Click(object sender, EventArgs e)
        {
            Prompt prompt = new Prompt("New method name:","");
            if (!prompt.Canceled)
            {
                CodeInput.Text = CodeInput.Text.Insert(this.CodeInput.GetFirstCharIndexOfCurrentLine(), "\r\n#method " + prompt.Output + "\r\n\r\n#endmethod " + prompt.Output);
            }
        }

        private void MakeAssembly_Click(object sender, EventArgs e)
        {
            Prompt prompt1 = new Prompt("Program Name",current.Name);
            Prompt prompt2 = new Prompt("Author Name", Environment.UserName);
            Prompt prompt3 = new Prompt("Copyright", "(C) " + Environment.UserName + " " + DateTime.Now.Year);
            Prompt prompt4 = new Prompt("Program Working Directory", current.DirectoryName);
            CodeInput.Text = prompt1.Output + "\r\n" + prompt2.Output + "\r\n" + prompt3.Output + "\r\n" + prompt4.Output + "\r\n\r\n" + CodeInput.Text;
        }

        private void AddVariable_Click(object sender, EventArgs e)
        {
            Prompt prompt = new Prompt("Variable Name","");
            
            if (!prompt.Canceled)
            {
                CodeInput.Text = CodeInput.Text.Insert(this.CodeInput.GetFirstCharIndexOfCurrentLine(), "#declarevar var " + prompt.Output + " null\r\n");
            }
        }

        private void CodeInput_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Control == true)
            {
                if(e.KeyCode == Keys.O)
                {
                    AddVariable_Click(null, null);
                }
                else if(e.KeyCode == Keys.M)
                {
                    AutoAddMethod_Click(null, null);
                }
            }
            if(e.KeyCode == Keys.F5)
            {
                RunCode_Click(null, null);
            }
        }
    }
}
