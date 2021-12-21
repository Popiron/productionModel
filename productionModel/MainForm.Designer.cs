
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
            this.resultBox = new System.Windows.Forms.GroupBox();
            this.solutionTextBox = new System.Windows.Forms.RichTextBox();
            this.clearTextBoxButton = new System.Windows.Forms.Button();
            this.outputTextBox = new System.Windows.Forms.RichTextBox();
            this.backwardOutputButton = new System.Windows.Forms.Button();
            this.controlPanel.SuspendLayout();
            this.outputBox.SuspendLayout();
            this.resultBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // controlPanel
            // 
            this.controlPanel.Controls.Add(this.backwardOutputButton);
            this.controlPanel.Controls.Add(this.dFactsBox);
            this.controlPanel.Controls.Add(this.directOutputButton);
            this.controlPanel.Controls.Add(this.checkedFactsBox);
            this.controlPanel.Location = new System.Drawing.Point(6, 6);
            this.controlPanel.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.controlPanel.Name = "controlPanel";
            this.controlPanel.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.controlPanel.Size = new System.Drawing.Size(215, 424);
            this.controlPanel.TabIndex = 0;
            this.controlPanel.TabStop = false;
            this.controlPanel.Text = "Найстройки";
            // 
            // dFactsBox
            // 
            this.dFactsBox.FormattingEnabled = true;
            this.dFactsBox.Location = new System.Drawing.Point(3, 174);
            this.dFactsBox.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.dFactsBox.Name = "dFactsBox";
            this.dFactsBox.ScrollAlwaysVisible = true;
            this.dFactsBox.Size = new System.Drawing.Size(211, 148);
            this.dFactsBox.TabIndex = 2;
            // 
            // directOutputButton
            // 
            this.directOutputButton.Location = new System.Drawing.Point(11, 388);
            this.directOutputButton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.directOutputButton.Name = "directOutputButton";
            this.directOutputButton.Size = new System.Drawing.Size(188, 28);
            this.directOutputButton.TabIndex = 1;
            this.directOutputButton.Text = "Прямой вывод";
            this.directOutputButton.UseVisualStyleBackColor = true;
            this.directOutputButton.Click += new System.EventHandler(this.directOutputButton_Click);
            // 
            // checkedFactsBox
            // 
            this.checkedFactsBox.FormattingEnabled = true;
            this.checkedFactsBox.Location = new System.Drawing.Point(3, 18);
            this.checkedFactsBox.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.checkedFactsBox.Name = "checkedFactsBox";
            this.checkedFactsBox.ScrollAlwaysVisible = true;
            this.checkedFactsBox.Size = new System.Drawing.Size(211, 148);
            this.checkedFactsBox.TabIndex = 0;
            // 
            // outputBox
            // 
            this.outputBox.Controls.Add(this.resultBox);
            this.outputBox.Controls.Add(this.clearTextBoxButton);
            this.outputBox.Controls.Add(this.outputTextBox);
            this.outputBox.Location = new System.Drawing.Point(225, 6);
            this.outputBox.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.outputBox.Name = "outputBox";
            this.outputBox.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.outputBox.Size = new System.Drawing.Size(279, 424);
            this.outputBox.TabIndex = 1;
            this.outputBox.TabStop = false;
            this.outputBox.Text = "Вывод";
            // 
            // resultBox
            // 
            this.resultBox.Controls.Add(this.solutionTextBox);
            this.resultBox.Location = new System.Drawing.Point(3, 232);
            this.resultBox.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.resultBox.Name = "resultBox";
            this.resultBox.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.resultBox.Size = new System.Drawing.Size(272, 154);
            this.resultBox.TabIndex = 3;
            this.resultBox.TabStop = false;
            this.resultBox.Text = "Решение";
            // 
            // solutionTextBox
            // 
            this.solutionTextBox.Location = new System.Drawing.Point(3, 18);
            this.solutionTextBox.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.solutionTextBox.Name = "solutionTextBox";
            this.solutionTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.solutionTextBox.Size = new System.Drawing.Size(268, 126);
            this.solutionTextBox.TabIndex = 1;
            this.solutionTextBox.Text = "";
            // 
            // clearTextBoxButton
            // 
            this.clearTextBoxButton.Location = new System.Drawing.Point(41, 388);
            this.clearTextBoxButton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.clearTextBoxButton.Name = "clearTextBoxButton";
            this.clearTextBoxButton.Size = new System.Drawing.Size(188, 28);
            this.clearTextBoxButton.TabIndex = 2;
            this.clearTextBoxButton.Text = "Очистить";
            this.clearTextBoxButton.UseVisualStyleBackColor = true;
            this.clearTextBoxButton.Click += new System.EventHandler(this.clearTextBoxButton_Click);
            // 
            // outputTextBox
            // 
            this.outputTextBox.Location = new System.Drawing.Point(3, 18);
            this.outputTextBox.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.outputTextBox.Name = "outputTextBox";
            this.outputTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.outputTextBox.Size = new System.Drawing.Size(274, 213);
            this.outputTextBox.TabIndex = 0;
            this.outputTextBox.Text = "";
            // 
            // backwardOutputButton
            // 
            this.backwardOutputButton.Location = new System.Drawing.Point(11, 358);
            this.backwardOutputButton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.backwardOutputButton.Name = "backwardOutputButton";
            this.backwardOutputButton.Size = new System.Drawing.Size(188, 28);
            this.backwardOutputButton.TabIndex = 3;
            this.backwardOutputButton.Text = "Обратный вывод";
            this.backwardOutputButton.UseVisualStyleBackColor = true;
            this.backwardOutputButton.Click += new System.EventHandler(this.backwardOutputButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 435);
            this.Controls.Add(this.outputBox);
            this.Controls.Add(this.controlPanel);
            this.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
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
        private System.Windows.Forms.Button backwardOutputButton;
    }
}

