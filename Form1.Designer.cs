namespace Breakout
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.canvas1 = new Breakout.Canvas();
            this.labelScore = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Showcard Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(813, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(272, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "Welcome to Breakout!";
            // 
            // canvas1
            // 
            this.canvas1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.canvas1.BackColor = System.Drawing.Color.Black;
            this.canvas1.Location = new System.Drawing.Point(0, 0);
            this.canvas1.Name = "canvas1";
            this.canvas1.Size = new System.Drawing.Size(760, 725);
            this.canvas1.TabIndex = 1;
            this.canvas1.Text = "canvas1";
            // 
            // labelScore
            // 
            this.labelScore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelScore.AutoSize = true;
            this.labelScore.Font = new System.Drawing.Font("Showcard Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelScore.Location = new System.Drawing.Point(886, 106);
            this.labelScore.Name = "labelScore";
            this.labelScore.Size = new System.Drawing.Size(99, 27);
            this.labelScore.TabIndex = 0;
            this.labelScore.Text = "Score: 0";
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listView1.Location = new System.Drawing.Point(776, 171);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(331, 543);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Address";
            this.columnHeader1.Width = 150;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Score";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1119, 726);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelScore);
            this.Controls.Add(this.canvas1);
            this.Name = "Form1";
            this.Text = "Breakout";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Canvas canvas1;
        private Label labelScore;
        private ListView listView1;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
    }
}