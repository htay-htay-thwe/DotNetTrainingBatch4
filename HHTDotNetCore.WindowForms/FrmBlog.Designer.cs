namespace HHTDotNetCore.WindowForms
{
    partial class FrmBlog
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
            btnSave = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtTitle = new TextBox();
            txtAuthor = new TextBox();
            txtContent = new TextBox();
            btnCancel = new Button();
            btnUpdate = new Button();
            SuspendLayout();
            // 
            // btnSave
            // 
            btnSave.BackColor = SystemColors.MenuHighlight;
            btnSave.ForeColor = SystemColors.Control;
            btnSave.Location = new Point(378, 328);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(112, 34);
            btnSave.TabIndex = 0;
            btnSave.Text = "&Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Visible = false;
            btnSave.Click += btnSave_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(246, 70);
            label1.Name = "label1";
            label1.Size = new Size(48, 25);
            label1.TabIndex = 1;
            label1.Text = "Title:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(246, 132);
            label2.Name = "label2";
            label2.Size = new Size(71, 25);
            label2.TabIndex = 2;
            label2.Text = "Author:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(238, 196);
            label3.Name = "label3";
            label3.Size = new Size(79, 25);
            label3.TabIndex = 3;
            label3.Text = "Content:";
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(346, 67);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(233, 31);
            txtTitle.TabIndex = 4;
            // 
            // txtAuthor
            // 
            txtAuthor.Location = new Point(346, 129);
            txtAuthor.Name = "txtAuthor";
            txtAuthor.Size = new Size(233, 31);
            txtAuthor.TabIndex = 5;
            // 
            // txtContent
            // 
            txtContent.Location = new Point(346, 190);
            txtContent.Multiline = true;
            txtContent.Name = "txtContent";
            txtContent.Size = new Size(233, 110);
            txtContent.TabIndex = 6;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.Brown;
            btnCancel.ForeColor = SystemColors.ButtonFace;
            btnCancel.Location = new Point(519, 328);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(112, 34);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "C&ancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.Lime;
            btnUpdate.ForeColor = SystemColors.ActiveCaptionText;
            btnUpdate.Location = new Point(378, 328);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(112, 34);
            btnUpdate.TabIndex = 8;
            btnUpdate.Text = "&Update";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // FrmBlog
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnUpdate);
            Controls.Add(btnCancel);
            Controls.Add(txtContent);
            Controls.Add(txtAuthor);
            Controls.Add(txtTitle);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnSave);
            Name = "FrmBlog";
            Text = "Update";
            Load += FrmBlog_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSave;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtTitle;
        private TextBox txtAuthor;
        private TextBox txtContent;
        private Button btnCancel;
        private Button btnUpdate;
    }
}
