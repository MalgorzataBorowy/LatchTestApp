namespace LatchApp
{
    partial class AddData
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
            this.gbComponentAdd = new System.Windows.Forms.GroupBox();
            this.btnComponentAddConfirm = new System.Windows.Forms.Button();
            this.gbComponentStatus = new System.Windows.Forms.GroupBox();
            this.rbStatusCompPassed = new System.Windows.Forms.RadioButton();
            this.rbStatusCompNotPassed = new System.Windows.Forms.RadioButton();
            this.rbStatusCompNotTested = new System.Windows.Forms.RadioButton();
            this.gbComponentType = new System.Windows.Forms.GroupBox();
            this.rbType2Comp = new System.Windows.Forms.RadioButton();
            this.rbType1Comp = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gbTestAdd = new System.Windows.Forms.GroupBox();
            this.tbCommentsTest = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tbVideoLinkTest = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.nudCyclesTest = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.dtpEndTimeTest = new System.Windows.Forms.DateTimePicker();
            this.dtpDateTest = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cbLatchIDTest = new System.Windows.Forms.ComboBox();
            this.btnTestAddConfirm = new System.Windows.Forms.Button();
            this.gbStatusTest = new System.Windows.Forms.GroupBox();
            this.rbStatusPassedTest = new System.Windows.Forms.RadioButton();
            this.rbStatusNotPassedTest = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.gbLatchAdd = new System.Windows.Forms.GroupBox();
            this.btnLatchAddConfirm = new System.Windows.Forms.Button();
            this.gbLatchTypeAdd = new System.Windows.Forms.GroupBox();
            this.rbLatchLong = new System.Windows.Forms.RadioButton();
            this.rbLatchShort = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbComponentID = new System.Windows.Forms.ComboBox();
            this.btnFinishAdd = new System.Windows.Forms.Button();
            this.btnComponentAdd = new System.Windows.Forms.Button();
            this.btnLatchAdd = new System.Windows.Forms.Button();
            this.btnTestAdd = new System.Windows.Forms.Button();
            this.gbComponentAdd.SuspendLayout();
            this.gbComponentStatus.SuspendLayout();
            this.gbComponentType.SuspendLayout();
            this.gbTestAdd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCyclesTest)).BeginInit();
            this.gbStatusTest.SuspendLayout();
            this.gbLatchAdd.SuspendLayout();
            this.gbLatchTypeAdd.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbComponentAdd
            // 
            this.gbComponentAdd.Controls.Add(this.btnComponentAddConfirm);
            this.gbComponentAdd.Controls.Add(this.gbComponentStatus);
            this.gbComponentAdd.Controls.Add(this.gbComponentType);
            this.gbComponentAdd.Controls.Add(this.label2);
            this.gbComponentAdd.Controls.Add(this.label1);
            this.gbComponentAdd.Location = new System.Drawing.Point(6, 66);
            this.gbComponentAdd.Name = "gbComponentAdd";
            this.gbComponentAdd.Size = new System.Drawing.Size(578, 255);
            this.gbComponentAdd.TabIndex = 4;
            this.gbComponentAdd.TabStop = false;
            this.gbComponentAdd.Text = "Add Component";
            // 
            // btnComponentAddConfirm
            // 
            this.btnComponentAddConfirm.Location = new System.Drawing.Point(490, 216);
            this.btnComponentAddConfirm.Name = "btnComponentAddConfirm";
            this.btnComponentAddConfirm.Size = new System.Drawing.Size(82, 33);
            this.btnComponentAddConfirm.TabIndex = 9;
            this.btnComponentAddConfirm.Text = "Confirm";
            this.btnComponentAddConfirm.UseVisualStyleBackColor = true;
            this.btnComponentAddConfirm.Click += new System.EventHandler(this.btnComponentAddConfirm_Click);
            // 
            // gbComponentStatus
            // 
            this.gbComponentStatus.Controls.Add(this.rbStatusCompPassed);
            this.gbComponentStatus.Controls.Add(this.rbStatusCompNotPassed);
            this.gbComponentStatus.Controls.Add(this.rbStatusCompNotTested);
            this.gbComponentStatus.Location = new System.Drawing.Point(161, 76);
            this.gbComponentStatus.Name = "gbComponentStatus";
            this.gbComponentStatus.Size = new System.Drawing.Size(198, 103);
            this.gbComponentStatus.TabIndex = 8;
            this.gbComponentStatus.TabStop = false;
            // 
            // rbStatusCompPassed
            // 
            this.rbStatusCompPassed.AutoSize = true;
            this.rbStatusCompPassed.Location = new System.Drawing.Point(9, 44);
            this.rbStatusCompPassed.Name = "rbStatusCompPassed";
            this.rbStatusCompPassed.Size = new System.Drawing.Size(98, 21);
            this.rbStatusCompPassed.TabIndex = 5;
            this.rbStatusCompPassed.TabStop = true;
            this.rbStatusCompPassed.Text = "Passed (1)";
            this.rbStatusCompPassed.UseVisualStyleBackColor = true;
            // 
            // rbStatusCompNotPassed
            // 
            this.rbStatusCompNotPassed.AutoSize = true;
            this.rbStatusCompNotPassed.Location = new System.Drawing.Point(9, 71);
            this.rbStatusCompNotPassed.Name = "rbStatusCompNotPassed";
            this.rbStatusCompNotPassed.Size = new System.Drawing.Size(129, 21);
            this.rbStatusCompNotPassed.TabIndex = 6;
            this.rbStatusCompNotPassed.TabStop = true;
            this.rbStatusCompNotPassed.Text = "Not Passed (-1)";
            this.rbStatusCompNotPassed.UseVisualStyleBackColor = true;
            // 
            // rbStatusCompNotTested
            // 
            this.rbStatusCompNotTested.AutoSize = true;
            this.rbStatusCompNotTested.Location = new System.Drawing.Point(9, 17);
            this.rbStatusCompNotTested.Name = "rbStatusCompNotTested";
            this.rbStatusCompNotTested.Size = new System.Drawing.Size(146, 21);
            this.rbStatusCompNotTested.TabIndex = 7;
            this.rbStatusCompNotTested.TabStop = true;
            this.rbStatusCompNotTested.Text = "Not Tested Yet (0)";
            this.rbStatusCompNotTested.UseVisualStyleBackColor = true;
            // 
            // gbComponentType
            // 
            this.gbComponentType.Controls.Add(this.rbType2Comp);
            this.gbComponentType.Controls.Add(this.rbType1Comp);
            this.gbComponentType.Location = new System.Drawing.Point(161, 21);
            this.gbComponentType.Name = "gbComponentType";
            this.gbComponentType.Size = new System.Drawing.Size(198, 49);
            this.gbComponentType.TabIndex = 4;
            this.gbComponentType.TabStop = false;
            // 
            // rbType2Comp
            // 
            this.rbType2Comp.AutoSize = true;
            this.rbType2Comp.Location = new System.Drawing.Point(118, 17);
            this.rbType2Comp.Name = "rbType2Comp";
            this.rbType2Comp.Size = new System.Drawing.Size(73, 21);
            this.rbType2Comp.TabIndex = 1;
            this.rbType2Comp.TabStop = true;
            this.rbType2Comp.Text = "Type 2";
            this.rbType2Comp.UseVisualStyleBackColor = true;
            // 
            // rbType1Comp
            // 
            this.rbType1Comp.AutoSize = true;
            this.rbType1Comp.Location = new System.Drawing.Point(9, 17);
            this.rbType1Comp.Name = "rbType1Comp";
            this.rbType1Comp.Size = new System.Drawing.Size(73, 21);
            this.rbType1Comp.TabIndex = 0;
            this.rbType1Comp.TabStop = true;
            this.rbType1Comp.Text = "Type 1";
            this.rbType1Comp.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Status:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Component Type:";
            // 
            // gbTestAdd
            // 
            this.gbTestAdd.Controls.Add(this.tbCommentsTest);
            this.gbTestAdd.Controls.Add(this.label11);
            this.gbTestAdd.Controls.Add(this.tbVideoLinkTest);
            this.gbTestAdd.Controls.Add(this.label10);
            this.gbTestAdd.Controls.Add(this.nudCyclesTest);
            this.gbTestAdd.Controls.Add(this.label9);
            this.gbTestAdd.Controls.Add(this.dtpEndTimeTest);
            this.gbTestAdd.Controls.Add(this.dtpDateTest);
            this.gbTestAdd.Controls.Add(this.label8);
            this.gbTestAdd.Controls.Add(this.label7);
            this.gbTestAdd.Controls.Add(this.cbLatchIDTest);
            this.gbTestAdd.Controls.Add(this.btnTestAddConfirm);
            this.gbTestAdd.Controls.Add(this.gbStatusTest);
            this.gbTestAdd.Controls.Add(this.label5);
            this.gbTestAdd.Controls.Add(this.label6);
            this.gbTestAdd.Location = new System.Drawing.Point(17, 69);
            this.gbTestAdd.Name = "gbTestAdd";
            this.gbTestAdd.Size = new System.Drawing.Size(578, 255);
            this.gbTestAdd.TabIndex = 10;
            this.gbTestAdd.TabStop = false;
            this.gbTestAdd.Text = "Add Test";
            // 
            // tbCommentsTest
            // 
            this.tbCommentsTest.Location = new System.Drawing.Point(161, 170);
            this.tbCommentsTest.Name = "tbCommentsTest";
            this.tbCommentsTest.Size = new System.Drawing.Size(303, 22);
            this.tbCommentsTest.TabIndex = 20;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 173);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(78, 17);
            this.label11.TabIndex = 19;
            this.label11.Text = "Comments:";
            // 
            // tbVideoLinkTest
            // 
            this.tbVideoLinkTest.Location = new System.Drawing.Point(161, 141);
            this.tbVideoLinkTest.Name = "tbVideoLinkTest";
            this.tbVideoLinkTest.Size = new System.Drawing.Size(303, 22);
            this.tbVideoLinkTest.TabIndex = 18;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 144);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(78, 17);
            this.label10.TabIndex = 17;
            this.label10.Text = "Video Link:";
            // 
            // nudCyclesTest
            // 
            this.nudCyclesTest.Location = new System.Drawing.Point(161, 112);
            this.nudCyclesTest.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.nudCyclesTest.Name = "nudCyclesTest";
            this.nudCyclesTest.Size = new System.Drawing.Size(112, 22);
            this.nudCyclesTest.TabIndex = 16;
            this.nudCyclesTest.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 114);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 17);
            this.label9.TabIndex = 15;
            this.label9.Text = "Cycles:";
            // 
            // dtpEndTimeTest
            // 
            this.dtpEndTimeTest.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpEndTimeTest.Location = new System.Drawing.Point(161, 55);
            this.dtpEndTimeTest.Name = "dtpEndTimeTest";
            this.dtpEndTimeTest.Size = new System.Drawing.Size(112, 22);
            this.dtpEndTimeTest.TabIndex = 14;
            // 
            // dtpDateTest
            // 
            this.dtpDateTest.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateTest.Location = new System.Drawing.Point(161, 83);
            this.dtpDateTest.Name = "dtpDateTest";
            this.dtpDateTest.Size = new System.Drawing.Size(112, 22);
            this.dtpDateTest.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 88);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 17);
            this.label8.TabIndex = 12;
            this.label8.Text = "Date:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 60);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 17);
            this.label7.TabIndex = 11;
            this.label7.Text = "End Time:";
            // 
            // cbLatchIDTest
            // 
            this.cbLatchIDTest.FormattingEnabled = true;
            this.cbLatchIDTest.Location = new System.Drawing.Point(161, 27);
            this.cbLatchIDTest.Name = "cbLatchIDTest";
            this.cbLatchIDTest.Size = new System.Drawing.Size(112, 24);
            this.cbLatchIDTest.TabIndex = 10;
            // 
            // btnTestAddConfirm
            // 
            this.btnTestAddConfirm.Location = new System.Drawing.Point(490, 216);
            this.btnTestAddConfirm.Name = "btnTestAddConfirm";
            this.btnTestAddConfirm.Size = new System.Drawing.Size(82, 33);
            this.btnTestAddConfirm.TabIndex = 9;
            this.btnTestAddConfirm.Text = "Confirm";
            this.btnTestAddConfirm.UseVisualStyleBackColor = true;
            this.btnTestAddConfirm.Click += new System.EventHandler(this.btnTestAddConfirm_Click);
            // 
            // gbStatusTest
            // 
            this.gbStatusTest.Controls.Add(this.rbStatusPassedTest);
            this.gbStatusTest.Controls.Add(this.rbStatusNotPassedTest);
            this.gbStatusTest.Location = new System.Drawing.Point(161, 198);
            this.gbStatusTest.Name = "gbStatusTest";
            this.gbStatusTest.Size = new System.Drawing.Size(262, 47);
            this.gbStatusTest.TabIndex = 8;
            this.gbStatusTest.TabStop = false;
            // 
            // rbStatusPassedTest
            // 
            this.rbStatusPassedTest.AutoSize = true;
            this.rbStatusPassedTest.Location = new System.Drawing.Point(140, 17);
            this.rbStatusPassedTest.Name = "rbStatusPassedTest";
            this.rbStatusPassedTest.Size = new System.Drawing.Size(98, 21);
            this.rbStatusPassedTest.TabIndex = 5;
            this.rbStatusPassedTest.TabStop = true;
            this.rbStatusPassedTest.Text = "Passed (1)";
            this.rbStatusPassedTest.UseVisualStyleBackColor = true;
            // 
            // rbStatusNotPassedTest
            // 
            this.rbStatusNotPassedTest.AutoSize = true;
            this.rbStatusNotPassedTest.Location = new System.Drawing.Point(9, 17);
            this.rbStatusNotPassedTest.Name = "rbStatusNotPassedTest";
            this.rbStatusNotPassedTest.Size = new System.Drawing.Size(124, 21);
            this.rbStatusNotPassedTest.TabIndex = 7;
            this.rbStatusNotPassedTest.TabStop = true;
            this.rbStatusNotPassedTest.Text = "Not Passed (0)";
            this.rbStatusNotPassedTest.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 215);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 17);
            this.label5.TabIndex = 3;
            this.label5.Text = "Status:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 17);
            this.label6.TabIndex = 2;
            this.label6.Text = "Latch ID:";
            // 
            // gbLatchAdd
            // 
            this.gbLatchAdd.Controls.Add(this.btnLatchAddConfirm);
            this.gbLatchAdd.Controls.Add(this.gbLatchTypeAdd);
            this.gbLatchAdd.Controls.Add(this.label4);
            this.gbLatchAdd.Controls.Add(this.label3);
            this.gbLatchAdd.Controls.Add(this.cbComponentID);
            this.gbLatchAdd.Location = new System.Drawing.Point(12, 72);
            this.gbLatchAdd.Name = "gbLatchAdd";
            this.gbLatchAdd.Size = new System.Drawing.Size(578, 255);
            this.gbLatchAdd.TabIndex = 0;
            this.gbLatchAdd.TabStop = false;
            this.gbLatchAdd.Text = "Add Latch";
            // 
            // btnLatchAddConfirm
            // 
            this.btnLatchAddConfirm.Location = new System.Drawing.Point(490, 216);
            this.btnLatchAddConfirm.Name = "btnLatchAddConfirm";
            this.btnLatchAddConfirm.Size = new System.Drawing.Size(82, 33);
            this.btnLatchAddConfirm.TabIndex = 10;
            this.btnLatchAddConfirm.Text = "Confirm";
            this.btnLatchAddConfirm.UseVisualStyleBackColor = true;
            this.btnLatchAddConfirm.Click += new System.EventHandler(this.btnLatchAddConfirm_Click);
            // 
            // gbLatchTypeAdd
            // 
            this.gbLatchTypeAdd.Controls.Add(this.rbLatchLong);
            this.gbLatchTypeAdd.Controls.Add(this.rbLatchShort);
            this.gbLatchTypeAdd.Location = new System.Drawing.Point(161, 60);
            this.gbLatchTypeAdd.Name = "gbLatchTypeAdd";
            this.gbLatchTypeAdd.Size = new System.Drawing.Size(200, 38);
            this.gbLatchTypeAdd.TabIndex = 3;
            this.gbLatchTypeAdd.TabStop = false;
            // 
            // rbLatchLong
            // 
            this.rbLatchLong.AutoSize = true;
            this.rbLatchLong.Location = new System.Drawing.Point(76, 12);
            this.rbLatchLong.Name = "rbLatchLong";
            this.rbLatchLong.Size = new System.Drawing.Size(61, 21);
            this.rbLatchLong.TabIndex = 1;
            this.rbLatchLong.TabStop = true;
            this.rbLatchLong.Text = "Long";
            this.rbLatchLong.UseVisualStyleBackColor = true;
            // 
            // rbLatchShort
            // 
            this.rbLatchShort.AutoSize = true;
            this.rbLatchShort.Location = new System.Drawing.Point(7, 12);
            this.rbLatchShort.Name = "rbLatchShort";
            this.rbLatchShort.Size = new System.Drawing.Size(63, 21);
            this.rbLatchShort.TabIndex = 0;
            this.rbLatchShort.TabStop = true;
            this.rbLatchShort.Text = "Short";
            this.rbLatchShort.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "Latch Type:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Component ID:";
            // 
            // cbComponentID
            // 
            this.cbComponentID.FormattingEnabled = true;
            this.cbComponentID.Location = new System.Drawing.Point(161, 30);
            this.cbComponentID.Name = "cbComponentID";
            this.cbComponentID.Size = new System.Drawing.Size(121, 24);
            this.cbComponentID.TabIndex = 0;
            // 
            // btnFinishAdd
            // 
            this.btnFinishAdd.Location = new System.Drawing.Point(528, 333);
            this.btnFinishAdd.Name = "btnFinishAdd";
            this.btnFinishAdd.Size = new System.Drawing.Size(88, 36);
            this.btnFinishAdd.TabIndex = 1;
            this.btnFinishAdd.Text = "Finish";
            this.btnFinishAdd.UseVisualStyleBackColor = true;
            this.btnFinishAdd.Click += new System.EventHandler(this.btnFinishAdd_Click);
            // 
            // btnComponentAdd
            // 
            this.btnComponentAdd.Location = new System.Drawing.Point(23, 13);
            this.btnComponentAdd.Name = "btnComponentAdd";
            this.btnComponentAdd.Size = new System.Drawing.Size(129, 44);
            this.btnComponentAdd.TabIndex = 2;
            this.btnComponentAdd.Text = "Component";
            this.btnComponentAdd.UseVisualStyleBackColor = true;
            this.btnComponentAdd.Click += new System.EventHandler(this.btnComponentAdd_Click);
            // 
            // btnLatchAdd
            // 
            this.btnLatchAdd.Location = new System.Drawing.Point(158, 12);
            this.btnLatchAdd.Name = "btnLatchAdd";
            this.btnLatchAdd.Size = new System.Drawing.Size(129, 44);
            this.btnLatchAdd.TabIndex = 3;
            this.btnLatchAdd.Text = "Latch";
            this.btnLatchAdd.UseVisualStyleBackColor = true;
            this.btnLatchAdd.Click += new System.EventHandler(this.btnLatchAdd_Click);
            // 
            // btnTestAdd
            // 
            this.btnTestAdd.Location = new System.Drawing.Point(293, 13);
            this.btnTestAdd.Name = "btnTestAdd";
            this.btnTestAdd.Size = new System.Drawing.Size(129, 44);
            this.btnTestAdd.TabIndex = 4;
            this.btnTestAdd.Text = "Test";
            this.btnTestAdd.UseVisualStyleBackColor = true;
            this.btnTestAdd.Click += new System.EventHandler(this.btnTestAdd_Click);
            // 
            // AddData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 381);
            this.Controls.Add(this.gbComponentAdd);
            this.Controls.Add(this.gbLatchAdd);
            this.Controls.Add(this.gbTestAdd);
            this.Controls.Add(this.btnTestAdd);
            this.Controls.Add(this.btnLatchAdd);
            this.Controls.Add(this.btnComponentAdd);
            this.Controls.Add(this.btnFinishAdd);
            this.Name = "AddData";
            this.Text = "Form1";
            this.gbComponentAdd.ResumeLayout(false);
            this.gbComponentAdd.PerformLayout();
            this.gbComponentStatus.ResumeLayout(false);
            this.gbComponentStatus.PerformLayout();
            this.gbComponentType.ResumeLayout(false);
            this.gbComponentType.PerformLayout();
            this.gbTestAdd.ResumeLayout(false);
            this.gbTestAdd.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCyclesTest)).EndInit();
            this.gbStatusTest.ResumeLayout(false);
            this.gbStatusTest.PerformLayout();
            this.gbLatchAdd.ResumeLayout(false);
            this.gbLatchAdd.PerformLayout();
            this.gbLatchTypeAdd.ResumeLayout(false);
            this.gbLatchTypeAdd.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnFinishAdd;
        private System.Windows.Forms.Button btnComponentAdd;
        private System.Windows.Forms.Button btnLatchAdd;
        private System.Windows.Forms.Button btnTestAdd;
        private System.Windows.Forms.GroupBox gbComponentAdd;
        private System.Windows.Forms.GroupBox gbComponentType;
        private System.Windows.Forms.RadioButton rbType2Comp;
        private System.Windows.Forms.RadioButton rbType1Comp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbStatusCompNotTested;
        private System.Windows.Forms.RadioButton rbStatusCompNotPassed;
        private System.Windows.Forms.RadioButton rbStatusCompPassed;
        private System.Windows.Forms.GroupBox gbComponentStatus;
        private System.Windows.Forms.Button btnComponentAddConfirm;
        private System.Windows.Forms.GroupBox gbLatchAdd;
        private System.Windows.Forms.Button btnLatchAddConfirm;
        private System.Windows.Forms.GroupBox gbLatchTypeAdd;
        private System.Windows.Forms.RadioButton rbLatchLong;
        private System.Windows.Forms.RadioButton rbLatchShort;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbComponentID;
        private System.Windows.Forms.GroupBox gbTestAdd;
        private System.Windows.Forms.ComboBox cbLatchIDTest;
        private System.Windows.Forms.Button btnTestAddConfirm;
        private System.Windows.Forms.GroupBox gbStatusTest;
        private System.Windows.Forms.RadioButton rbStatusPassedTest;
        private System.Windows.Forms.RadioButton rbStatusNotPassedTest;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpEndTimeTest;
        private System.Windows.Forms.DateTimePicker dtpDateTest;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbCommentsTest;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbVideoLinkTest;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown nudCyclesTest;
        private System.Windows.Forms.Label label9;
    }
}