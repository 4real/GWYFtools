namespace HoleReordering
{
    partial class HoleReordering
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
            label1 = new Label();
            mapFilename = new TextBox();
            browseButton = new Button();
            reloadButton = new Button();
            unsavedChanges = new Label();
            saveButton = new Button();
            holes = new ListBox();
            label2 = new Label();
            upButton = new Button();
            downButton = new Button();
            label3 = new Label();
            numericUpDown1 = new NumericUpDown();
            openDialog = new OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 29);
            label1.Name = "label1";
            label1.Size = new Size(118, 20);
            label1.TabIndex = 0;
            label1.Text = "Course Map File:";
            // 
            // mapFilename
            // 
            mapFilename.Location = new Point(138, 26);
            mapFilename.Name = "mapFilename";
            mapFilename.Size = new Size(327, 27);
            mapFilename.TabIndex = 1;
            // 
            // browseButton
            // 
            browseButton.Location = new Point(481, 25);
            browseButton.Name = "browseButton";
            browseButton.Size = new Size(94, 29);
            browseButton.TabIndex = 2;
            browseButton.Text = "Browse...";
            browseButton.UseVisualStyleBackColor = true;
            // 
            // reloadButton
            // 
            reloadButton.Location = new Point(14, 76);
            reloadButton.Name = "reloadButton";
            reloadButton.Size = new Size(94, 29);
            reloadButton.TabIndex = 3;
            reloadButton.Text = "Reload";
            reloadButton.UseVisualStyleBackColor = true;
            // 
            // unsavedChanges
            // 
            unsavedChanges.AutoSize = true;
            unsavedChanges.Location = new Point(148, 80);
            unsavedChanges.Name = "unsavedChanges";
            unsavedChanges.Size = new Size(148, 20);
            unsavedChanges.TabIndex = 4;
            unsavedChanges.Text = "No unsaved changes.";
            // 
            // saveButton
            // 
            saveButton.Location = new Point(313, 76);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(118, 29);
            saveButton.TabIndex = 5;
            saveButton.Text = "Save Changes";
            saveButton.UseVisualStyleBackColor = true;
            // 
            // holes
            // 
            holes.FormattingEnabled = true;
            holes.Items.AddRange(new object[] { "Hole 1   Par 8", "Hole 2   Par 9", "Hole 3", "Hole 4", "Hole 5", "Hole 6", "Hole 7", "Hole 8", "Hole 9", "Hole 11 Par 3", "Hole 12", "Hole 13", "Hole 14", "Hole 15", "Hole 16", "Hole 17", "Hole 18" });
            holes.Location = new Point(16, 167);
            holes.Name = "holes";
            holes.Size = new Size(169, 344);
            holes.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(16, 144);
            label2.Name = "label2";
            label2.Size = new Size(86, 20);
            label2.TabIndex = 7;
            label2.Text = "Hole Order:";
            // 
            // upButton
            // 
            upButton.Location = new Point(191, 167);
            upButton.Name = "upButton";
            upButton.Size = new Size(153, 29);
            upButton.TabIndex = 8;
            upButton.Text = "Up";
            upButton.UseVisualStyleBackColor = true;
            // 
            // downButton
            // 
            downButton.Location = new Point(191, 204);
            downButton.Name = "downButton";
            downButton.Size = new Size(153, 29);
            downButton.TabIndex = 9;
            downButton.Text = "Down";
            downButton.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(194, 262);
            label3.Name = "label3";
            label3.Size = new Size(32, 20);
            label3.TabIndex = 10;
            label3.Text = "Par:";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(194, 285);
            numericUpDown1.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(150, 27);
            numericUpDown1.TabIndex = 11;
            numericUpDown1.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // openDialog
            // 
            openDialog.FileName = "Map";
            // 
            // HoleReordering
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(609, 544);
            Controls.Add(numericUpDown1);
            Controls.Add(label3);
            Controls.Add(downButton);
            Controls.Add(upButton);
            Controls.Add(label2);
            Controls.Add(holes);
            Controls.Add(saveButton);
            Controls.Add(unsavedChanges);
            Controls.Add(reloadButton);
            Controls.Add(browseButton);
            Controls.Add(mapFilename);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "HoleReordering";
            Text = "Golf With Your Friends Hole Reordering Tool";
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox mapFilename;
        private Button browseButton;
        private Button reloadButton;
        private Label unsavedChanges;
        private Button saveButton;
        private ListBox holes;
        private Label label2;
        private Button upButton;
        private Button downButton;
        private Label label3;
        private NumericUpDown numericUpDown1;
        private OpenFileDialog openDialog;
    }
}
