namespace IDE
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.CodeGroupBox = new System.Windows.Forms.GroupBox();
            this.CursorPositionOutput = new System.Windows.Forms.Label();
            this.CodeInput = new System.Windows.Forms.TextBox();
            this.RunAndDeployGroupBox = new System.Windows.Forms.GroupBox();
            this.EditDebugArguments = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.Open = new System.Windows.Forms.Button();
            this.Save = new System.Windows.Forms.Button();
            this.RunCode = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.EditorGroupBox = new System.Windows.Forms.GroupBox();
            this.AddVariable = new System.Windows.Forms.Button();
            this.MakeAssembly = new System.Windows.Forms.Button();
            this.AutoAddMethod = new System.Windows.Forms.Button();
            this.CodeGroupBox.SuspendLayout();
            this.RunAndDeployGroupBox.SuspendLayout();
            this.EditorGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // CodeGroupBox
            // 
            this.CodeGroupBox.Controls.Add(this.CursorPositionOutput);
            this.CodeGroupBox.Controls.Add(this.CodeInput);
            this.CodeGroupBox.Location = new System.Drawing.Point(1, 67);
            this.CodeGroupBox.Name = "CodeGroupBox";
            this.CodeGroupBox.Size = new System.Drawing.Size(787, 411);
            this.CodeGroupBox.TabIndex = 3;
            this.CodeGroupBox.TabStop = false;
            this.CodeGroupBox.Text = "Code";
            // 
            // CursorPositionOutput
            // 
            this.CursorPositionOutput.AutoSize = true;
            this.CursorPositionOutput.Location = new System.Drawing.Point(6, 395);
            this.CursorPositionOutput.Name = "CursorPositionOutput";
            this.CursorPositionOutput.Size = new System.Drawing.Size(35, 13);
            this.CursorPositionOutput.TabIndex = 1;
            this.CursorPositionOutput.Text = "label1";
            // 
            // CodeInput
            // 
            this.CodeInput.Location = new System.Drawing.Point(6, 19);
            this.CodeInput.Multiline = true;
            this.CodeInput.Name = "CodeInput";
            this.CodeInput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.CodeInput.Size = new System.Drawing.Size(775, 373);
            this.CodeInput.TabIndex = 0;
            this.CodeInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CodeInput_KeyDown);
            // 
            // RunAndDeployGroupBox
            // 
            this.RunAndDeployGroupBox.Controls.Add(this.EditDebugArguments);
            this.RunAndDeployGroupBox.Controls.Add(this.button1);
            this.RunAndDeployGroupBox.Controls.Add(this.Open);
            this.RunAndDeployGroupBox.Controls.Add(this.Save);
            this.RunAndDeployGroupBox.Controls.Add(this.RunCode);
            this.RunAndDeployGroupBox.Location = new System.Drawing.Point(1, 1);
            this.RunAndDeployGroupBox.Name = "RunAndDeployGroupBox";
            this.RunAndDeployGroupBox.Size = new System.Drawing.Size(434, 60);
            this.RunAndDeployGroupBox.TabIndex = 4;
            this.RunAndDeployGroupBox.TabStop = false;
            this.RunAndDeployGroupBox.Text = "RunAndDeploy";
            // 
            // EditDebugArguments
            // 
            this.EditDebugArguments.Location = new System.Drawing.Point(330, 19);
            this.EditDebugArguments.Name = "EditDebugArguments";
            this.EditDebugArguments.Size = new System.Drawing.Size(100, 23);
            this.EditDebugArguments.TabIndex = 7;
            this.EditDebugArguments.Text = "EditDebugArgs";
            this.EditDebugArguments.UseVisualStyleBackColor = true;
            this.EditDebugArguments.Click += new System.EventHandler(this.EditDebugArguments_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(249, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "OpenShell";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Open
            // 
            this.Open.Location = new System.Drawing.Point(168, 19);
            this.Open.Name = "Open";
            this.Open.Size = new System.Drawing.Size(75, 23);
            this.Open.TabIndex = 5;
            this.Open.Text = "Open";
            this.Open.UseVisualStyleBackColor = true;
            this.Open.Click += new System.EventHandler(this.Open_Click);
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(87, 19);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(75, 23);
            this.Save.TabIndex = 4;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // RunCode
            // 
            this.RunCode.Location = new System.Drawing.Point(6, 19);
            this.RunCode.Name = "RunCode";
            this.RunCode.Size = new System.Drawing.Size(75, 23);
            this.RunCode.TabIndex = 3;
            this.RunCode.Text = "Run";
            this.RunCode.UseVisualStyleBackColor = true;
            this.RunCode.Click += new System.EventHandler(this.RunCode_Click);
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 10;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // EditorGroupBox
            // 
            this.EditorGroupBox.Controls.Add(this.AddVariable);
            this.EditorGroupBox.Controls.Add(this.MakeAssembly);
            this.EditorGroupBox.Controls.Add(this.AutoAddMethod);
            this.EditorGroupBox.Location = new System.Drawing.Point(441, 1);
            this.EditorGroupBox.Name = "EditorGroupBox";
            this.EditorGroupBox.Size = new System.Drawing.Size(347, 60);
            this.EditorGroupBox.TabIndex = 5;
            this.EditorGroupBox.TabStop = false;
            this.EditorGroupBox.Text = "Editor";
            // 
            // AddVariable
            // 
            this.AddVariable.Location = new System.Drawing.Point(169, 19);
            this.AddVariable.Name = "AddVariable";
            this.AddVariable.Size = new System.Drawing.Size(75, 23);
            this.AddVariable.TabIndex = 2;
            this.AddVariable.Text = "AddVariable";
            this.AddVariable.UseVisualStyleBackColor = true;
            this.AddVariable.Click += new System.EventHandler(this.AddVariable_Click);
            // 
            // MakeAssembly
            // 
            this.MakeAssembly.Location = new System.Drawing.Point(7, 19);
            this.MakeAssembly.Name = "MakeAssembly";
            this.MakeAssembly.Size = new System.Drawing.Size(75, 23);
            this.MakeAssembly.TabIndex = 1;
            this.MakeAssembly.Text = "MakeAsm";
            this.MakeAssembly.UseVisualStyleBackColor = true;
            this.MakeAssembly.Click += new System.EventHandler(this.MakeAssembly_Click);
            // 
            // AutoAddMethod
            // 
            this.AutoAddMethod.Location = new System.Drawing.Point(88, 19);
            this.AutoAddMethod.Name = "AutoAddMethod";
            this.AutoAddMethod.Size = new System.Drawing.Size(75, 23);
            this.AutoAddMethod.TabIndex = 0;
            this.AutoAddMethod.Text = "AddMethod";
            this.AutoAddMethod.UseVisualStyleBackColor = true;
            this.AutoAddMethod.Click += new System.EventHandler(this.AutoAddMethod_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 478);
            this.Controls.Add(this.EditorGroupBox);
            this.Controls.Add(this.RunAndDeployGroupBox);
            this.Controls.Add(this.CodeGroupBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Text = "QBatch IDE";
            this.CodeGroupBox.ResumeLayout(false);
            this.CodeGroupBox.PerformLayout();
            this.RunAndDeployGroupBox.ResumeLayout(false);
            this.EditorGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox CodeGroupBox;
        private System.Windows.Forms.TextBox CodeInput;
        private System.Windows.Forms.GroupBox RunAndDeployGroupBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button Open;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Button RunCode;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button EditDebugArguments;
        private System.Windows.Forms.Label CursorPositionOutput;
        private System.Windows.Forms.GroupBox EditorGroupBox;
        private System.Windows.Forms.Button AutoAddMethod;
        private System.Windows.Forms.Button MakeAssembly;
        private System.Windows.Forms.Button AddVariable;
    }
}

