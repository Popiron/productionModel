
namespace productionModel
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.controlPanel = new System.Windows.Forms.GroupBox();
            this.dFactsBox = new System.Windows.Forms.CheckedListBox();
            this.directOutputButton = new System.Windows.Forms.Button();
            this.checkedFactsBox = new System.Windows.Forms.CheckedListBox();
            this.outputBox = new System.Windows.Forms.GroupBox();
            this.clearTextBoxButton = new System.Windows.Forms.Button();
            this.outputTextBox = new System.Windows.Forms.RichTextBox();
            this.resultBox = new System.Windows.Forms.GroupBox();
            this.solutionTextBox = new System.Windows.Forms.RichTextBox();
            this.controlPanel.SuspendLayout();
            this.outputBox.SuspendLayout();
            this.resultBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // controlPanel
            // 
            this.controlPanel.Controls.Add(this.dFactsBox);
            this.controlPanel.Controls.Add(this.directOutputButton);
            this.controlPanel.Controls.Add(this.checkedFactsBox);
            this.controlPanel.Location = new System.Drawing.Point(12, 12);
            this.controlPanel.Name = "controlPanel";
            this.controlPanel.Size = new System.Drawing.Size(400, 905);
            this.controlPanel.TabIndex = 0;
            this.controlPanel.TabStop = false;
            this.controlPanel.Text = "Найстройки";
            // 
            // dFactsBox
            // 
            this.dFactsBox.FormattingEnabled = true;
            this.dFactsBox.Location = new System.Drawing.Point(6, 372);
            this.dFactsBox.Name = "dFactsBox";
            this.dFactsBox.ScrollAlwaysVisible = true;
            this.dFactsBox.Size = new System.Drawing.Size(388, 328);
            this.dFactsBox.TabIndex = 2;
            // 
            // directOutputButton
            // 
            this.directOutputButton.Location = new System.Drawing.Point(21, 828);
            this.directOutputButton.Name = "directOutputButton";
            this.directOutputButton.Size = new System.Drawing.Size(350, 60);
            this.directOutputButton.TabIndex = 1;
            this.directOutputButton.Text = "Прямой вывод";
            this.directOutputButton.UseVisualStyleBackColor = true;
            this.directOutputButton.Click += new System.EventHandler(this.directOutputButton_Click);
            // 
            // checkedFactsBox
            // 
            this.checkedFactsBox.FormattingEnabled = true;
            this.checkedFactsBox.Location = new System.Drawing.Point(6, 38);
            this.checkedFactsBox.Name = "checkedFactsBox";
            this.checkedFactsBox.ScrollAlwaysVisible = true;
            this.checkedFactsBox.Size = new System.Drawing.Size(388, 328);
            this.checkedFactsBox.TabIndex = 0;
            // 
            // outputBox
            // 
            this.outputBox.Controls.Add(this.resultBox);
            this.outputBox.Controls.Add(this.clearTextBoxButton);
            this.outputBox.Controls.Add(this.outputTextBox);
            this.outputBox.Location = new System.Drawing.Point(418, 12);
            this.outputBox.Name = "outputBox";
            this.outputBox.Size = new System.Drawing.Size(518, 905);
            this.outputBox.TabIndex = 1;
            this.outputBox.TabStop = false;
            this.outputBox.Text = "Вывод";
            // 
            // clearTextBoxButton
            // 
            this.clearTextBoxButton.Location = new System.Drawing.Point(76, 828);
            this.clearTextBoxButton.Name = "clearTextBoxButton";
            this.clearTextBoxButton.Size = new System.Drawing.Size(350, 60);
            this.clearTextBoxButton.TabIndex = 2;
            this.clearTextBoxButton.Text = "Очистить";
            this.clearTextBoxButton.UseVisualStyleBackColor = true;
            this.clearTextBoxButton.Click += new System.EventHandler(this.clearTextBoxButton_Click);
            // 
            // outputTextBox
            // 
            this.outputTextBox.Location = new System.Drawing.Point(6, 38);
            this.outputTextBox.Name = "outputTextBox";
            this.outputTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.outputTextBox.Size = new System.Drawing.Size(506, 450);
            this.outputTextBox.TabIndex = 0;
            this.outputTextBox.Text = "";
            // 
            // resultBox
            // 
            this.resultBox.Controls.Add(this.solutionTextBox);
            this.resultBox.Location = new System.Drawing.Point(6, 494);
            this.resultBox.Name = "resultBox";
            this.resultBox.Size = new System.Drawing.Size(506, 328);
            this.resultBox.TabIndex = 3;
            this.resultBox.TabStop = false;
            this.resultBox.Text = "Решение";
            // 
            // solutionTextBox
            // 
            this.solutionTextBox.Location = new System.Drawing.Point(6, 38);
            this.solutionTextBox.Name = "solutionTextBox";
            this.solutionTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.solutionTextBox.Size = new System.Drawing.Size(494, 264);
            this.solutionTextBox.TabIndex = 1;
            this.solutionTextBox.Text = "";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 929);
            this.Controls.Add(this.outputBox);
            this.Controls.Add(this.controlPanel);
            this.Name = "MainForm";
            this.Text = "Main";
            this.controlPanel.ResumeLayout(false);
            this.outputBox.ResumeLayout(false);
            this.resultBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox controlPanel;
        private System.Windows.Forms.Button directOutputButton;
        private System.Windows.Forms.CheckedListBox checkedFactsBox;
        private System.Windows.Forms.GroupBox outputBox;
        private System.Windows.Forms.Button clearTextBoxButton;
        private System.Windows.Forms.RichTextBox outputTextBox;
        private System.Windows.Forms.CheckedListBox dFactsBox;
        private System.Windows.Forms.GroupBox resultBox;
        private System.Windows.Forms.RichTextBox solutionTextBox;
    }
}

