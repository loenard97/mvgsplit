namespace LiveSplit.UI.Components
{
    partial class MVGSplitSettings
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.topLevelLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.chkTwoRows = new System.Windows.Forms.CheckBox();
            this.decimalGroupBox = new System.Windows.Forms.GroupBox();
            this.decimalLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.rdoDecimalZero = new System.Windows.Forms.RadioButton();
            this.rdoDecimalOne = new System.Windows.Forms.RadioButton();
            this.rdoDecimalTwo = new System.Windows.Forms.RadioButton();
            this.topLevelLayoutPanel.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.decimalGroupBox.SuspendLayout();
            this.decimalLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // topLevelLayoutPanel
            // 
            this.topLevelLayoutPanel.AutoSize = true;
            this.topLevelLayoutPanel.ColumnCount = 1;
            this.topLevelLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.topLevelLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.topLevelLayoutPanel.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.topLevelLayoutPanel.Controls.Add(this.decimalGroupBox, 0, 1);
            this.topLevelLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.topLevelLayoutPanel.Name = "topLevelLayoutPanel";
            this.topLevelLayoutPanel.RowCount = 2;
            this.topLevelLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.topLevelLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.topLevelLayoutPanel.Size = new System.Drawing.Size(282, 212);
            this.topLevelLayoutPanel.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.chkTwoRows, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(200, 100);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // chkTwoRows
            // 
            this.chkTwoRows.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.chkTwoRows.AutoSize = true;
            this.chkTwoRows.Location = new System.Drawing.Point(3, 41);
            this.chkTwoRows.MinimumSize = new System.Drawing.Size(100, 0);
            this.chkTwoRows.Name = "chkTwoRows";
            this.chkTwoRows.Size = new System.Drawing.Size(194, 17);
            this.chkTwoRows.TabIndex = 0;
            this.chkTwoRows.Text = "Display 2 Rows";
            this.chkTwoRows.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.chkTwoRows.UseVisualStyleBackColor = true;
            // 
            // decimalGroupBox
            // 
            this.decimalGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.decimalGroupBox.AutoSize = true;
            this.decimalGroupBox.Controls.Add(this.decimalLayoutPanel);
            this.decimalGroupBox.Location = new System.Drawing.Point(3, 109);
            this.decimalGroupBox.Name = "decimalGroupBox";
            this.decimalGroupBox.Size = new System.Drawing.Size(276, 100);
            this.decimalGroupBox.TabIndex = 1;
            this.decimalGroupBox.TabStop = false;
            this.decimalGroupBox.Text = "Decimal Points";
            // 
            // decimalLayoutPanel
            // 
            this.decimalLayoutPanel.AutoSize = true;
            this.decimalLayoutPanel.ColumnCount = 3;
            this.decimalLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.decimalLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.decimalLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.decimalLayoutPanel.Controls.Add(this.rdoDecimalZero, 0, 0);
            this.decimalLayoutPanel.Controls.Add(this.rdoDecimalOne, 1, 0);
            this.decimalLayoutPanel.Controls.Add(this.rdoDecimalTwo, 2, 0);
            this.decimalLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.decimalLayoutPanel.Location = new System.Drawing.Point(3, 16);
            this.decimalLayoutPanel.Name = "decimalLayoutPanel";
            this.decimalLayoutPanel.RowCount = 1;
            this.decimalLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.decimalLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.decimalLayoutPanel.Size = new System.Drawing.Size(270, 81);
            this.decimalLayoutPanel.TabIndex = 0;
            // 
            // rdoDecimalZero
            // 
            this.rdoDecimalZero.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.rdoDecimalZero.AutoSize = true;
            this.rdoDecimalZero.Location = new System.Drawing.Point(3, 32);
            this.rdoDecimalZero.MinimumSize = new System.Drawing.Size(70, 0);
            this.rdoDecimalZero.Name = "rdoDecimalZero";
            this.rdoDecimalZero.Size = new System.Drawing.Size(84, 17);
            this.rdoDecimalZero.TabIndex = 1;
            this.rdoDecimalZero.TabStop = true;
            this.rdoDecimalZero.Text = "Zero (1%)";
            this.rdoDecimalZero.UseVisualStyleBackColor = true;
            this.rdoDecimalZero.CheckedChanged += new System.EventHandler(this.rdoDecimalZero_CheckedChanged);
            // 
            // rdoDecimalOne
            // 
            this.rdoDecimalOne.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.rdoDecimalOne.AutoSize = true;
            this.rdoDecimalOne.Location = new System.Drawing.Point(93, 32);
            this.rdoDecimalOne.Name = "rdoDecimalOne";
            this.rdoDecimalOne.Size = new System.Drawing.Size(84, 17);
            this.rdoDecimalOne.TabIndex = 2;
            this.rdoDecimalOne.TabStop = true;
            this.rdoDecimalOne.Text = "One (1.1%)";
            this.rdoDecimalOne.UseVisualStyleBackColor = true;
            this.rdoDecimalOne.CheckedChanged += new System.EventHandler(this.rdoDecimalOne_CheckedChanged);
            // 
            // rdoDecimalTwo
            // 
            this.rdoDecimalTwo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.rdoDecimalTwo.AutoSize = true;
            this.rdoDecimalTwo.Location = new System.Drawing.Point(183, 32);
            this.rdoDecimalTwo.Name = "rdoDecimalTwo";
            this.rdoDecimalTwo.Size = new System.Drawing.Size(84, 17);
            this.rdoDecimalTwo.TabIndex = 3;
            this.rdoDecimalTwo.TabStop = true;
            this.rdoDecimalTwo.Text = "Two (1.11%)";
            this.rdoDecimalTwo.UseVisualStyleBackColor = true;
            this.rdoDecimalTwo.CheckedChanged += new System.EventHandler(this.rdoDecimalTwo_CheckedChanged);
            // 
            // ResetChanceSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.topLevelLayoutPanel);
            this.Name = "ResetChanceSettings";
            this.Size = new System.Drawing.Size(285, 215);
            this.Load += new System.EventHandler(this.ResetChanceSettings_Load);
            this.topLevelLayoutPanel.ResumeLayout(false);
            this.topLevelLayoutPanel.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.decimalGroupBox.ResumeLayout(false);
            this.decimalGroupBox.PerformLayout();
            this.decimalLayoutPanel.ResumeLayout(false);
            this.decimalLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel topLevelLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.CheckBox chkTwoRows;
        private System.Windows.Forms.GroupBox decimalGroupBox;
        private System.Windows.Forms.TableLayoutPanel decimalLayoutPanel;
        private System.Windows.Forms.RadioButton rdoDecimalZero;
        private System.Windows.Forms.RadioButton rdoDecimalOne;
        private System.Windows.Forms.RadioButton rdoDecimalTwo;
    }
}
