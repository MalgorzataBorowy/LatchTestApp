namespace LatchApp
{
    partial class Navigation
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
            this.label1 = new System.Windows.Forms.Label();
            this.btn_AddData = new System.Windows.Forms.Button();
            this.btn_ViewData = new System.Windows.Forms.Button();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "What do you want to do?";
            // 
            // btn_AddData
            // 
            this.btn_AddData.Location = new System.Drawing.Point(26, 90);
            this.btn_AddData.Name = "btn_AddData";
            this.btn_AddData.Size = new System.Drawing.Size(85, 30);
            this.btn_AddData.TabIndex = 1;
            this.btn_AddData.Text = "Add data";
            this.btn_AddData.UseVisualStyleBackColor = true;
            this.btn_AddData.Click += new System.EventHandler(this.btn_AddData_Click);
            // 
            // btn_ViewData
            // 
            this.btn_ViewData.Location = new System.Drawing.Point(26, 135);
            this.btn_ViewData.Name = "btn_ViewData";
            this.btn_ViewData.Size = new System.Drawing.Size(85, 30);
            this.btn_ViewData.TabIndex = 2;
            this.btn_ViewData.Text = "View data";
            this.btn_ViewData.UseVisualStyleBackColor = true;
            this.btn_ViewData.Click += new System.EventHandler(this.btn_ViewData_Click);
            // 
            // btn_Exit
            // 
            this.btn_Exit.Location = new System.Drawing.Point(159, 235);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(85, 30);
            this.btn_Exit.TabIndex = 3;
            this.btn_Exit.Text = "Exit";
            this.btn_Exit.UseVisualStyleBackColor = true;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // Navigation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(256, 277);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.btn_ViewData);
            this.Controls.Add(this.btn_AddData);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(274, 324);
            this.MinimumSize = new System.Drawing.Size(274, 324);
            this.Name = "Navigation";
            this.Text = "LatchApp";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_AddData;
        private System.Windows.Forms.Button btn_ViewData;
        private System.Windows.Forms.Button btn_Exit;
    }
}