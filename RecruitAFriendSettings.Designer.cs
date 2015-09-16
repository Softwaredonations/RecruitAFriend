namespace RecruitAFriend
{
    partial class RecruitAFriendSettings
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabGeneral = new System.Windows.Forms.TabPage();
            this.groupBoxAccept = new System.Windows.Forms.GroupBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.tabParty = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioShareMountYes = new System.Windows.Forms.RadioButton();
            this.radioShareMountNo = new System.Windows.Forms.RadioButton();
            this.tabCommands = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.numericUpDownGrantLevels = new System.Windows.Forms.NumericUpDown();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.tabQuestBlacklisting = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LeaderTB = new System.Windows.Forms.TextBox();
            this.FollowerTB = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabGeneral.SuspendLayout();
            this.groupBoxAccept.SuspendLayout();
            this.tabParty.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabCommands.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGrantLevels)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.button1);
            this.splitContainer1.Panel2MinSize = 50;
            this.splitContainer1.Size = new System.Drawing.Size(418, 227);
            this.splitContainer1.SplitterDistance = 176;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 2;
            this.splitContainer1.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabGeneral);
            this.tabControl1.Controls.Add(this.tabParty);
            this.tabControl1.Controls.Add(this.tabCommands);
            this.tabControl1.Controls.Add(this.tabQuestBlacklisting);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(418, 176);
            this.tabControl1.TabIndex = 1;
            // 
            // tabGeneral
            // 
            this.tabGeneral.Controls.Add(this.groupBoxAccept);
            this.tabGeneral.Controls.Add(this.checkBox3);
            this.tabGeneral.Controls.Add(this.checkBox2);
            this.tabGeneral.Controls.Add(this.checkBox1);
            this.tabGeneral.Location = new System.Drawing.Point(4, 22);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tabGeneral.Size = new System.Drawing.Size(410, 150);
            this.tabGeneral.TabIndex = 0;
            this.tabGeneral.Text = "General";
            this.tabGeneral.UseVisualStyleBackColor = true;
            // 
            // groupBoxAccept
            // 
            this.groupBoxAccept.Controls.Add(this.FollowerTB);
            this.groupBoxAccept.Controls.Add(this.LeaderTB);
            this.groupBoxAccept.Controls.Add(this.label2);
            this.groupBoxAccept.Controls.Add(this.label1);
            this.groupBoxAccept.Location = new System.Drawing.Point(272, 6);
            this.groupBoxAccept.Name = "groupBoxAccept";
            this.groupBoxAccept.Size = new System.Drawing.Size(128, 126);
            this.groupBoxAccept.TabIndex = 6;
            this.groupBoxAccept.TabStop = false;
            this.groupBoxAccept.Enter += new System.EventHandler(this.groupBoxAccept_Enter);
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox3.Location = new System.Drawing.Point(17, 20);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(174, 21);
            this.checkBox3.TabIndex = 2;
            this.checkBox3.Text = "Accept Party Invitations";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox2.Location = new System.Drawing.Point(17, 47);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(136, 21);
            this.checkBox2.TabIndex = 1;
            this.checkBox2.Text = "Accept Summons";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(20, 111);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(171, 21);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "Accept Granted Levels";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // tabParty
            // 
            this.tabParty.Controls.Add(this.groupBox1);
            this.tabParty.Location = new System.Drawing.Point(4, 22);
            this.tabParty.Name = "tabParty";
            this.tabParty.Padding = new System.Windows.Forms.Padding(3);
            this.tabParty.Size = new System.Drawing.Size(680, 341);
            this.tabParty.TabIndex = 1;
            this.tabParty.Text = "Party";
            this.tabParty.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioShareMountYes);
            this.groupBox1.Controls.Add(this.radioShareMountNo);
            this.groupBox1.Location = new System.Drawing.Point(26, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(145, 100);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Share Multiplayer Mounts";
            // 
            // radioShareMountYes
            // 
            this.radioShareMountYes.AutoSize = true;
            this.radioShareMountYes.Location = new System.Drawing.Point(22, 59);
            this.radioShareMountYes.Name = "radioShareMountYes";
            this.radioShareMountYes.Size = new System.Drawing.Size(43, 17);
            this.radioShareMountYes.TabIndex = 3;
            this.radioShareMountYes.TabStop = true;
            this.radioShareMountYes.Text = "Yes";
            this.radioShareMountYes.UseVisualStyleBackColor = true;
            // 
            // radioShareMountNo
            // 
            this.radioShareMountNo.AutoSize = true;
            this.radioShareMountNo.Location = new System.Drawing.Point(22, 36);
            this.radioShareMountNo.Name = "radioShareMountNo";
            this.radioShareMountNo.Size = new System.Drawing.Size(39, 17);
            this.radioShareMountNo.TabIndex = 2;
            this.radioShareMountNo.TabStop = true;
            this.radioShareMountNo.Text = "No";
            this.radioShareMountNo.UseVisualStyleBackColor = true;
            // 
            // tabCommands
            // 
            this.tabCommands.Controls.Add(this.panel1);
            this.tabCommands.Controls.Add(this.button2);
            this.tabCommands.Location = new System.Drawing.Point(4, 22);
            this.tabCommands.Name = "tabCommands";
            this.tabCommands.Size = new System.Drawing.Size(680, 341);
            this.tabCommands.TabIndex = 2;
            this.tabCommands.Text = "Commands";
            this.tabCommands.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.checkBox7);
            this.panel1.Controls.Add(this.numericUpDownGrantLevels);
            this.panel1.Controls.Add(this.checkBox6);
            this.panel1.Controls.Add(this.checkBox5);
            this.panel1.Controls.Add(this.checkBox4);
            this.panel1.Location = new System.Drawing.Point(17, 22);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(213, 190);
            this.panel1.TabIndex = 5;
            // 
            // checkBox7
            // 
            this.checkBox7.AutoSize = true;
            this.checkBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox7.Location = new System.Drawing.Point(15, 117);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(139, 21);
            this.checkBox7.TabIndex = 8;
            this.checkBox7.Text = "Divide Bag Space";
            this.checkBox7.UseVisualStyleBackColor = true;
            // 
            // numericUpDownGrantLevels
            // 
            this.numericUpDownGrantLevels.BackColor = System.Drawing.Color.Green;
            this.numericUpDownGrantLevels.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownGrantLevels.ForeColor = System.Drawing.Color.Lime;
            this.numericUpDownGrantLevels.Location = new System.Drawing.Point(125, 82);
            this.numericUpDownGrantLevels.Maximum = new decimal(new int[] {
            41,
            0,
            0,
            0});
            this.numericUpDownGrantLevels.Name = "numericUpDownGrantLevels";
            this.numericUpDownGrantLevels.Size = new System.Drawing.Size(71, 23);
            this.numericUpDownGrantLevels.TabIndex = 7;
            this.numericUpDownGrantLevels.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox6.Location = new System.Drawing.Point(15, 82);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(108, 21);
            this.checkBox6.TabIndex = 6;
            this.checkBox6.Text = "Grant Levels";
            this.checkBox6.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox5.Location = new System.Drawing.Point(15, 49);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(126, 21);
            this.checkBox5.TabIndex = 5;
            this.checkBox5.Text = "Summon Friend";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox4.Location = new System.Drawing.Point(15, 17);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(113, 21);
            this.checkBox4.TabIndex = 4;
            this.checkBox4.Text = "Invite to Party";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(17, 218);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(213, 35);
            this.button2.TabIndex = 4;
            this.button2.Text = "Execute";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // tabQuestBlacklisting
            // 
            this.tabQuestBlacklisting.Location = new System.Drawing.Point(4, 22);
            this.tabQuestBlacklisting.Name = "tabQuestBlacklisting";
            this.tabQuestBlacklisting.Size = new System.Drawing.Size(680, 341);
            this.tabQuestBlacklisting.TabIndex = 3;
            this.tabQuestBlacklisting.Text = "Quest Blacklisting";
            this.tabQuestBlacklisting.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(248, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(155, 35);
            this.button1.TabIndex = 3;
            this.button1.Text = "Save Settings";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Friend";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Leader";
            // 
            // LeaderTB
            // 
            this.LeaderTB.Location = new System.Drawing.Point(6, 42);
            this.LeaderTB.Name = "LeaderTB";
            this.LeaderTB.Size = new System.Drawing.Size(110, 20);
            this.LeaderTB.TabIndex = 7;
            // 
            // FollowerTB
            // 
            this.FollowerTB.Location = new System.Drawing.Point(6, 86);
            this.FollowerTB.Name = "FollowerTB";
            this.FollowerTB.Size = new System.Drawing.Size(110, 20);
            this.FollowerTB.TabIndex = 8;
            // 
            // RecruitAFriendSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 227);
            this.Controls.Add(this.splitContainer1);
            this.Name = "RecruitAFriendSettings";
            this.Text = "RecruitAFriendSettings";
            this.Load += new System.EventHandler(this.RecruitAFriendSettings_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabGeneral.ResumeLayout(false);
            this.tabGeneral.PerformLayout();
            this.groupBoxAccept.ResumeLayout(false);
            this.groupBoxAccept.PerformLayout();
            this.tabParty.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabCommands.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGrantLevels)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabGeneral;
        private System.Windows.Forms.TabPage tabParty;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabPage tabCommands;
        private System.Windows.Forms.TabPage tabQuestBlacklisting;
        private System.Windows.Forms.GroupBox groupBoxAccept;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioShareMountYes;
        private System.Windows.Forms.RadioButton radioShareMountNo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NumericUpDown numericUpDownGrantLevels;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox checkBox7;
        private System.Windows.Forms.TextBox FollowerTB;
        private System.Windows.Forms.TextBox LeaderTB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}