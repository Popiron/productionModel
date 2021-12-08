
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
            this.checkedFactsBox = new System.Windows.Forms.CheckedListBox();
            this.directOutputButton = new System.Windows.Forms.Button();
            this.outputBox = new System.Windows.Forms.GroupBox();
            this.outputTextBox = new System.Windows.Forms.RichTextBox();
            this.clearTextBoxButton = new System.Windows.Forms.Button();
            this.controlPanel.SuspendLayout();
            this.outputBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // controlPanel
            // 
            this.controlPanel.Controls.Add(this.directOutputButton);
            this.controlPanel.Controls.Add(this.checkedFactsBox);
            this.controlPanel.Location = new System.Drawing.Point(12, 12);
            this.controlPanel.Name = "controlPanel";
            this.controlPanel.Size = new System.Drawing.Size(400, 905);
            this.controlPanel.TabIndex = 0;
            this.controlPanel.TabStop = false;
            this.controlPanel.Text = "Найстройки";
            // 
            // checkedFactsBox
            // 
            this.checkedFactsBox.FormattingEnabled = true;
            this.checkedFactsBox.Location = new System.Drawing.Point(6, 38);
            this.checkedFactsBox.Name = "checkedFactsBox";
            this.checkedFactsBox.ScrollAlwaysVisible = true;
            this.checkedFactsBox.Size = new System.Drawing.Size(388, 760);
            this.checkedFactsBox.TabIndex = 0;
            // 
            // directOutputButton
            // 
            this.directOutputButton.Location = new System.Drawing.Point(21, 828);
            this.directOutputButton.Name = "directOutputButton";
            this.directOutputButton.Size = new System.Drawing.Size(350, 60);
            this.directOutputButton.TabIndex = 1;
            this.directOutputButton.Text = "Прямой вывод";
            this.directOutputButton.UseVisualStyleBackColor = true;
            // 
            // outputBox
            // 
            this.outputBox.Controls.Add(this.clearTextBoxButton);
            this.outputBox.Controls.Add(this.outputTextBox);
            this.outputBox.Location = new System.Drawing.Point(418, 12);
            this.outputBox.Name = "outputBox";
            this.outputBox.Size = new System.Drawing.Size(518, 905);
            this.outputBox.TabIndex = 1;
            this.outputBox.TabStop = false;
            this.outputBox.Text = "Вывод";
            // 
            // outputTextBox
            // 
            this.outputTextBox.Location = new System.Drawing.Point(6, 38);
            this.outputTextBox.Name = "outputTextBox";
            this.outputTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.outputTextBox.Size = new System.Drawing.Size(506, 764);
            this.outputTextBox.TabIndex = 0;
            this.outputTextBox.Text = "";
            // 
            // clearTextBoxButton
            // 
            this.clearTextBoxButton.Location = new System.Drawing.Point(76, 828);
            this.clearTextBoxButton.Name = "clearTextBoxButton";
            this.clearTextBoxButton.Size = new System.Drawing.Size(350, 60);
            this.clearTextBoxButton.TabIndex = 2;
            this.clearTextBoxButton.Text = "Очистить";
            this.clearTextBoxButton.UseVisualStyleBackColor = true;
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox controlPanel;
        private System.Windows.Forms.Button directOutputButton;
        private System.Windows.Forms.CheckedListBox checkedFactsBox;
        private System.Windows.Forms.GroupBox outputBox;
        private System.Windows.Forms.Button clearTextBoxButton;
        private System.Windows.Forms.RichTextBox outputTextBox;
    }
}

