using System;
using System.ComponentModel;

namespace SceneryobjectConversionUtility
{
    partial class Form1
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
            this.btn_browseOMSI = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pic_browseBlender = new System.Windows.Forms.PictureBox();
            this.pic_browseXconv = new System.Windows.Forms.PictureBox();
            this.pic_browseOMSI = new System.Windows.Forms.PictureBox();
            this.lbl_browseXconv = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_browseXconv = new System.Windows.Forms.Button();
            this.lbl_browseBlender = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_browseBlender = new System.Windows.Forms.Button();
            this.lbl_browseOMSI = new System.Windows.Forms.Label();
            this.ofd_browseOMSI = new System.Windows.Forms.OpenFileDialog();
            this.ofd_browseBlender = new System.Windows.Forms.OpenFileDialog();
            this.ofd_browseXconv = new System.Windows.Forms.OpenFileDialog();
            this.ofd_browseSketchUp = new System.Windows.Forms.OpenFileDialog();
            this.btn_convert = new System.Windows.Forms.Button();
            this.tbx_fileName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbx_getFileNameFromFile = new System.Windows.Forms.CheckBox();
            this.lbl_fileName = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbl_browseSource = new System.Windows.Forms.Label();
            this.btn_browseSource = new System.Windows.Forms.Button();
            this.ofd_browseSource = new System.Windows.Forms.OpenFileDialog();
            this.fbd_browseTexture = new System.Windows.Forms.FolderBrowserDialog();
            this.btn_browseOutput = new System.Windows.Forms.Button();
            this.lbl_browseOutput = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.fbd_browseOutput = new System.Windows.Forms.FolderBrowserDialog();
            this.rdb_groups1 = new System.Windows.Forms.RadioButton();
            this.rdb_groups2 = new System.Windows.Forms.RadioButton();
            this.rdb_groups3 = new System.Windows.Forms.RadioButton();
            this.rdb_groups4 = new System.Windows.Forms.RadioButton();
            this.label9 = new System.Windows.Forms.Label();
            this.tbx_groups4 = new System.Windows.Forms.TextBox();
            this.tbx_groups3 = new System.Windows.Forms.TextBox();
            this.tbx_groups2 = new System.Windows.Forms.TextBox();
            this.tbx_groups1 = new System.Windows.Forms.TextBox();
            this.pnl_groups = new System.Windows.Forms.Panel();
            this.rdb_groups0 = new System.Windows.Forms.RadioButton();
            this.cbx_includeTransparency = new System.Windows.Forms.CheckBox();
            this.cbx_yUp = new System.Windows.Forms.CheckBox();
            this.cbx_getFriendlynameFromFile = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tbx_friendlyname = new System.Windows.Forms.TextBox();
            this.cbx_prefixTexture = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_browseBlender)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_browseXconv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_browseOMSI)).BeginInit();
            this.pnl_groups.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_browseOMSI
            // 
            this.btn_browseOMSI.Location = new System.Drawing.Point(451, 22);
            this.btn_browseOMSI.Name = "btn_browseOMSI";
            this.btn_browseOMSI.Size = new System.Drawing.Size(83, 29);
            this.btn_browseOMSI.TabIndex = 0;
            this.btn_browseOMSI.Text = "Browse";
            this.btn_browseOMSI.UseVisualStyleBackColor = true;
            this.btn_browseOMSI.Click += new System.EventHandler(this.Btn_browseOMSI_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "OMSI 2:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Click += new System.EventHandler(this.Label1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pic_browseBlender);
            this.groupBox1.Controls.Add(this.pic_browseXconv);
            this.groupBox1.Controls.Add(this.pic_browseOMSI);
            this.groupBox1.Controls.Add(this.lbl_browseXconv);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btn_browseXconv);
            this.groupBox1.Controls.Add(this.lbl_browseBlender);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btn_browseBlender);
            this.groupBox1.Controls.Add(this.lbl_browseOMSI);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btn_browseOMSI);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(541, 134);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "System Parameters";
            this.groupBox1.Enter += new System.EventHandler(this.GroupBox1_Enter);
            // 
            // pic_browseBlender
            // 
            this.pic_browseBlender.BackColor = System.Drawing.Color.Red;
            this.pic_browseBlender.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pic_browseBlender.Location = new System.Drawing.Point(415, 92);
            this.pic_browseBlender.Name = "pic_browseBlender";
            this.pic_browseBlender.Size = new System.Drawing.Size(30, 29);
            this.pic_browseBlender.TabIndex = 14;
            this.pic_browseBlender.TabStop = false;
            this.pic_browseBlender.Click += new System.EventHandler(this.Pic_browseBlender_Click);
            // 
            // pic_browseXconv
            // 
            this.pic_browseXconv.BackColor = System.Drawing.Color.Red;
            this.pic_browseXconv.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pic_browseXconv.Location = new System.Drawing.Point(415, 57);
            this.pic_browseXconv.Name = "pic_browseXconv";
            this.pic_browseXconv.Size = new System.Drawing.Size(30, 29);
            this.pic_browseXconv.TabIndex = 13;
            this.pic_browseXconv.TabStop = false;
            this.pic_browseXconv.Click += new System.EventHandler(this.Pic_browseXconv_Click);
            // 
            // pic_browseOMSI
            // 
            this.pic_browseOMSI.BackColor = System.Drawing.Color.Red;
            this.pic_browseOMSI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pic_browseOMSI.Location = new System.Drawing.Point(415, 22);
            this.pic_browseOMSI.Name = "pic_browseOMSI";
            this.pic_browseOMSI.Size = new System.Drawing.Size(30, 29);
            this.pic_browseOMSI.TabIndex = 4;
            this.pic_browseOMSI.TabStop = false;
            this.pic_browseOMSI.Click += new System.EventHandler(this.Pic_browseOMSI_Click);
            // 
            // lbl_browseXconv
            // 
            this.lbl_browseXconv.AutoSize = true;
            this.lbl_browseXconv.Location = new System.Drawing.Point(90, 65);
            this.lbl_browseXconv.MaximumSize = new System.Drawing.Size(330, 26);
            this.lbl_browseXconv.Name = "lbl_browseXconv";
            this.lbl_browseXconv.Size = new System.Drawing.Size(69, 13);
            this.lbl_browseXconv.TabIndex = 9;
            this.lbl_browseXconv.Text = "Not Selected";
            this.lbl_browseXconv.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_browseXconv.Click += new System.EventHandler(this.Lbl_browseXconv_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "omsiXconv:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_browseXconv
            // 
            this.btn_browseXconv.Location = new System.Drawing.Point(451, 57);
            this.btn_browseXconv.Name = "btn_browseXconv";
            this.btn_browseXconv.Size = new System.Drawing.Size(83, 29);
            this.btn_browseXconv.TabIndex = 1;
            this.btn_browseXconv.Text = "Browse";
            this.btn_browseXconv.UseVisualStyleBackColor = true;
            this.btn_browseXconv.Click += new System.EventHandler(this.Btn_browseXconv_Click);
            // 
            // lbl_browseBlender
            // 
            this.lbl_browseBlender.AutoSize = true;
            this.lbl_browseBlender.Location = new System.Drawing.Point(90, 100);
            this.lbl_browseBlender.MaximumSize = new System.Drawing.Size(330, 26);
            this.lbl_browseBlender.Name = "lbl_browseBlender";
            this.lbl_browseBlender.Size = new System.Drawing.Size(69, 13);
            this.lbl_browseBlender.TabIndex = 6;
            this.lbl_browseBlender.Text = "Not Selected";
            this.lbl_browseBlender.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_browseBlender.Click += new System.EventHandler(this.Lbl_browseBlender_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Blender 2.79:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_browseBlender
            // 
            this.btn_browseBlender.Location = new System.Drawing.Point(451, 92);
            this.btn_browseBlender.Name = "btn_browseBlender";
            this.btn_browseBlender.Size = new System.Drawing.Size(83, 29);
            this.btn_browseBlender.TabIndex = 2;
            this.btn_browseBlender.Text = "Browse";
            this.btn_browseBlender.UseVisualStyleBackColor = true;
            this.btn_browseBlender.Click += new System.EventHandler(this.Btn_browseBlender_Click);
            // 
            // lbl_browseOMSI
            // 
            this.lbl_browseOMSI.AutoSize = true;
            this.lbl_browseOMSI.Location = new System.Drawing.Point(90, 30);
            this.lbl_browseOMSI.MaximumSize = new System.Drawing.Size(330, 26);
            this.lbl_browseOMSI.Name = "lbl_browseOMSI";
            this.lbl_browseOMSI.Size = new System.Drawing.Size(69, 13);
            this.lbl_browseOMSI.TabIndex = 3;
            this.lbl_browseOMSI.Text = "Not Selected";
            this.lbl_browseOMSI.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_browseOMSI.Click += new System.EventHandler(this.Lbl_browseOMSI_Click);
            // 
            // ofd_browseOMSI
            // 
            this.ofd_browseOMSI.FileName = "Omsi.exe";
            this.ofd_browseOMSI.Filter = "OMSI 2 Executable|Omsi.exe";
            this.ofd_browseOMSI.FileOk += new System.ComponentModel.CancelEventHandler(this.Ofd_browseOMSI_FileOk);
            // 
            // ofd_browseBlender
            // 
            this.ofd_browseBlender.FileName = "blender.exe";
            this.ofd_browseBlender.Filter = "Blender Executable|blender.exe";
            this.ofd_browseBlender.FileOk += new System.ComponentModel.CancelEventHandler(this.Ofd_browseBlender_FileOk);
            // 
            // ofd_browseXconv
            // 
            this.ofd_browseXconv.FileName = "omsiXconv.exe";
            this.ofd_browseXconv.Filter = "OMSI X Converter Executable|omsiXconv.exe";
            this.ofd_browseXconv.FileOk += new System.ComponentModel.CancelEventHandler(this.Ofd_browseXconv_FileOk);
            // 
            // ofd_browseSketchUp
            // 
            this.ofd_browseSketchUp.FileName = "SketchUp.exe";
            this.ofd_browseSketchUp.Filter = "SketchUp Executable|SketchUp.exe";
            this.ofd_browseSketchUp.FileOk += new System.ComponentModel.CancelEventHandler(this.Ofd_browseSketchUp_FileOk);
            // 
            // btn_convert
            // 
            this.btn_convert.Enabled = false;
            this.btn_convert.Location = new System.Drawing.Point(20, 502);
            this.btn_convert.Name = "btn_convert";
            this.btn_convert.Size = new System.Drawing.Size(522, 42);
            this.btn_convert.TabIndex = 15;
            this.btn_convert.Text = "Convert";
            this.btn_convert.UseVisualStyleBackColor = true;
            this.btn_convert.Click += new System.EventHandler(this.Btn_Convert_Click);
            // 
            // tbx_fileName
            // 
            this.tbx_fileName.Location = new System.Drawing.Point(101, 279);
            this.tbx_fileName.MaxLength = 64;
            this.tbx_fileName.Name = "tbx_fileName";
            this.tbx_fileName.Size = new System.Drawing.Size(356, 20);
            this.tbx_fileName.TabIndex = 7;
            this.tbx_fileName.TextChanged += new System.EventHandler(this.Tbx_ModelName);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 282);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "File Name:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Click += new System.EventHandler(this.Label2_Click);
            // 
            // cbx_getFileNameFromFile
            // 
            this.cbx_getFileNameFromFile.AutoSize = true;
            this.cbx_getFileNameFromFile.Enabled = false;
            this.cbx_getFileNameFromFile.Location = new System.Drawing.Point(463, 281);
            this.cbx_getFileNameFromFile.Name = "cbx_getFileNameFromFile";
            this.cbx_getFileNameFromFile.Size = new System.Drawing.Size(82, 17);
            this.cbx_getFileNameFromFile.TabIndex = 8;
            this.cbx_getFileNameFromFile.Text = "Get from file";
            this.cbx_getFileNameFromFile.UseVisualStyleBackColor = true;
            this.cbx_getFileNameFromFile.CheckedChanged += new System.EventHandler(this.Cbx_getNameFromFile);
            // 
            // lbl_fileName
            // 
            this.lbl_fileName.AutoSize = true;
            this.lbl_fileName.Location = new System.Drawing.Point(98, 302);
            this.lbl_fileName.Name = "lbl_fileName";
            this.lbl_fileName.Size = new System.Drawing.Size(43, 13);
            this.lbl_fileName.TabIndex = 19;
            this.lbl_fileName.Text = "Not Set";
            this.lbl_fileName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_fileName.Click += new System.EventHandler(this.Lbl_FileName_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 160);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Source File:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label7.Click += new System.EventHandler(this.Label7_Click);
            // 
            // lbl_browseSource
            // 
            this.lbl_browseSource.AutoSize = true;
            this.lbl_browseSource.Location = new System.Drawing.Point(101, 160);
            this.lbl_browseSource.MaximumSize = new System.Drawing.Size(340, 26);
            this.lbl_browseSource.Name = "lbl_browseSource";
            this.lbl_browseSource.Size = new System.Drawing.Size(69, 13);
            this.lbl_browseSource.TabIndex = 16;
            this.lbl_browseSource.Text = "Not Selected";
            this.lbl_browseSource.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_browseSource.Click += new System.EventHandler(this.Lbl_browseSource_Click);
            // 
            // btn_browseSource
            // 
            this.btn_browseSource.Location = new System.Drawing.Point(463, 152);
            this.btn_browseSource.Name = "btn_browseSource";
            this.btn_browseSource.Size = new System.Drawing.Size(83, 29);
            this.btn_browseSource.TabIndex = 4;
            this.btn_browseSource.Text = "Browse";
            this.btn_browseSource.UseVisualStyleBackColor = true;
            this.btn_browseSource.Click += new System.EventHandler(this.Btn_browseSource_Click);
            // 
            // ofd_browseSource
            // 
            this.ofd_browseSource.Filter = "All types(*.blend;*.dae)|*.blend;*.dae|Blender|*.blend|COLLADA|*.dae";
            this.ofd_browseSource.FileOk += new System.ComponentModel.CancelEventHandler(this.Ofd_browseSource_FileOk);
            // 
            // fbd_browseTexture
            // 
            this.fbd_browseTexture.HelpRequest += new System.EventHandler(this.Fbd_browseTexture_HelpRequest);
            // 
            // btn_browseOutput
            // 
            this.btn_browseOutput.Location = new System.Drawing.Point(459, 451);
            this.btn_browseOutput.Name = "btn_browseOutput";
            this.btn_browseOutput.Size = new System.Drawing.Size(83, 29);
            this.btn_browseOutput.TabIndex = 14;
            this.btn_browseOutput.Text = "Browse";
            this.btn_browseOutput.UseVisualStyleBackColor = true;
            this.btn_browseOutput.Click += new System.EventHandler(this.Btn_browseOutput_Click);
            // 
            // lbl_browseOutput
            // 
            this.lbl_browseOutput.AutoSize = true;
            this.lbl_browseOutput.Location = new System.Drawing.Point(98, 459);
            this.lbl_browseOutput.MaximumSize = new System.Drawing.Size(340, 26);
            this.lbl_browseOutput.Name = "lbl_browseOutput";
            this.lbl_browseOutput.Size = new System.Drawing.Size(69, 13);
            this.lbl_browseOutput.TabIndex = 27;
            this.lbl_browseOutput.Text = "Not Selected";
            this.lbl_browseOutput.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_browseOutput.Click += new System.EventHandler(this.Lbl_browseOutput_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(17, 459);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 13);
            this.label10.TabIndex = 26;
            this.label10.Text = "Output Folder:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label10.Click += new System.EventHandler(this.Label10_Click);
            // 
            // rdb_groups1
            // 
            this.rdb_groups1.AutoSize = true;
            this.rdb_groups1.Location = new System.Drawing.Point(5, 22);
            this.rdb_groups1.Name = "rdb_groups1";
            this.rdb_groups1.Size = new System.Drawing.Size(31, 17);
            this.rdb_groups1.TabIndex = 41;
            this.rdb_groups1.Text = "1";
            this.rdb_groups1.UseVisualStyleBackColor = true;
            this.rdb_groups1.CheckedChanged += new System.EventHandler(this.Rdb_groups1_CheckedChanged_1);
            // 
            // rdb_groups2
            // 
            this.rdb_groups2.AutoSize = true;
            this.rdb_groups2.Location = new System.Drawing.Point(5, 46);
            this.rdb_groups2.Name = "rdb_groups2";
            this.rdb_groups2.Size = new System.Drawing.Size(31, 17);
            this.rdb_groups2.TabIndex = 42;
            this.rdb_groups2.Text = "2";
            this.rdb_groups2.UseVisualStyleBackColor = true;
            this.rdb_groups2.CheckedChanged += new System.EventHandler(this.Rdb_groups2_CheckedChanged);
            // 
            // rdb_groups3
            // 
            this.rdb_groups3.AutoSize = true;
            this.rdb_groups3.Location = new System.Drawing.Point(5, 72);
            this.rdb_groups3.Name = "rdb_groups3";
            this.rdb_groups3.Size = new System.Drawing.Size(31, 17);
            this.rdb_groups3.TabIndex = 43;
            this.rdb_groups3.Text = "3";
            this.rdb_groups3.UseVisualStyleBackColor = true;
            this.rdb_groups3.CheckedChanged += new System.EventHandler(this.Rdb_groups3_CheckedChanged);
            // 
            // rdb_groups4
            // 
            this.rdb_groups4.AutoSize = true;
            this.rdb_groups4.Location = new System.Drawing.Point(5, 98);
            this.rdb_groups4.Name = "rdb_groups4";
            this.rdb_groups4.Size = new System.Drawing.Size(31, 17);
            this.rdb_groups4.TabIndex = 44;
            this.rdb_groups4.Text = "4";
            this.rdb_groups4.UseVisualStyleBackColor = true;
            this.rdb_groups4.CheckedChanged += new System.EventHandler(this.Rdb_groups4_CheckedChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(17, 328);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 13);
            this.label9.TabIndex = 33;
            this.label9.Text = "Groups:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label9.Click += new System.EventHandler(this.Label9_Click);
            // 
            // tbx_groups4
            // 
            this.tbx_groups4.Enabled = false;
            this.tbx_groups4.Location = new System.Drawing.Point(144, 425);
            this.tbx_groups4.MaxLength = 64;
            this.tbx_groups4.Name = "tbx_groups4";
            this.tbx_groups4.Size = new System.Drawing.Size(313, 20);
            this.tbx_groups4.TabIndex = 13;
            this.tbx_groups4.TextChanged += new System.EventHandler(this.Tbx_groups4_TextChanged);
            // 
            // tbx_groups3
            // 
            this.tbx_groups3.Enabled = false;
            this.tbx_groups3.Location = new System.Drawing.Point(144, 399);
            this.tbx_groups3.MaxLength = 64;
            this.tbx_groups3.Name = "tbx_groups3";
            this.tbx_groups3.Size = new System.Drawing.Size(313, 20);
            this.tbx_groups3.TabIndex = 12;
            this.tbx_groups3.TextChanged += new System.EventHandler(this.Tbx_groups3_TextChanged);
            // 
            // tbx_groups2
            // 
            this.tbx_groups2.Enabled = false;
            this.tbx_groups2.Location = new System.Drawing.Point(144, 373);
            this.tbx_groups2.MaxLength = 64;
            this.tbx_groups2.Name = "tbx_groups2";
            this.tbx_groups2.Size = new System.Drawing.Size(313, 20);
            this.tbx_groups2.TabIndex = 11;
            this.tbx_groups2.TextChanged += new System.EventHandler(this.Tbx_groups2_TextChanged);
            // 
            // tbx_groups1
            // 
            this.tbx_groups1.Enabled = false;
            this.tbx_groups1.Location = new System.Drawing.Point(144, 349);
            this.tbx_groups1.MaxLength = 64;
            this.tbx_groups1.Name = "tbx_groups1";
            this.tbx_groups1.Size = new System.Drawing.Size(313, 20);
            this.tbx_groups1.TabIndex = 10;
            this.tbx_groups1.TextChanged += new System.EventHandler(this.Tbx_groups1_TextChanged);
            // 
            // pnl_groups
            // 
            this.pnl_groups.Controls.Add(this.rdb_groups0);
            this.pnl_groups.Controls.Add(this.rdb_groups4);
            this.pnl_groups.Controls.Add(this.rdb_groups1);
            this.pnl_groups.Controls.Add(this.rdb_groups2);
            this.pnl_groups.Controls.Add(this.rdb_groups3);
            this.pnl_groups.Location = new System.Drawing.Point(99, 328);
            this.pnl_groups.Name = "pnl_groups";
            this.pnl_groups.Size = new System.Drawing.Size(39, 123);
            this.pnl_groups.TabIndex = 9;
            this.pnl_groups.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel1_Paint);
            // 
            // rdb_groups0
            // 
            this.rdb_groups0.AutoSize = true;
            this.rdb_groups0.Checked = true;
            this.rdb_groups0.Location = new System.Drawing.Point(5, -2);
            this.rdb_groups0.Name = "rdb_groups0";
            this.rdb_groups0.Size = new System.Drawing.Size(31, 17);
            this.rdb_groups0.TabIndex = 40;
            this.rdb_groups0.TabStop = true;
            this.rdb_groups0.Text = "0";
            this.rdb_groups0.UseVisualStyleBackColor = true;
            this.rdb_groups0.CheckedChanged += new System.EventHandler(this.Rdb_groups0_CheckedChanged);
            // 
            // cbx_includeTransparency
            // 
            this.cbx_includeTransparency.AutoSize = true;
            this.cbx_includeTransparency.Location = new System.Drawing.Point(101, 210);
            this.cbx_includeTransparency.Name = "cbx_includeTransparency";
            this.cbx_includeTransparency.Size = new System.Drawing.Size(277, 17);
            this.cbx_includeTransparency.TabIndex = 6;
            this.cbx_includeTransparency.Text = "Include transparency (may cause render order issues)";
            this.cbx_includeTransparency.UseVisualStyleBackColor = true;
            this.cbx_includeTransparency.CheckedChanged += new System.EventHandler(this.cbx_includeTransparency_CheckedChanged);
            // 
            // cbx_yUp
            // 
            this.cbx_yUp.AutoSize = true;
            this.cbx_yUp.Location = new System.Drawing.Point(101, 187);
            this.cbx_yUp.Name = "cbx_yUp";
            this.cbx_yUp.Size = new System.Drawing.Size(216, 17);
            this.cbx_yUp.TabIndex = 34;
            this.cbx_yUp.Text = "Y-Up (Check if models appear sideways)";
            this.cbx_yUp.UseVisualStyleBackColor = true;
            this.cbx_yUp.CheckedChanged += new System.EventHandler(this.Cbx_yUp_CheckedChanged);
            // 
            // cbx_getFriendlynameFromFile
            // 
            this.cbx_getFriendlynameFromFile.AutoSize = true;
            this.cbx_getFriendlynameFromFile.Enabled = false;
            this.cbx_getFriendlynameFromFile.Location = new System.Drawing.Point(463, 258);
            this.cbx_getFriendlynameFromFile.Name = "cbx_getFriendlynameFromFile";
            this.cbx_getFriendlynameFromFile.Size = new System.Drawing.Size(82, 17);
            this.cbx_getFriendlynameFromFile.TabIndex = 36;
            this.cbx_getFriendlynameFromFile.Text = "Get from file";
            this.cbx_getFriendlynameFromFile.UseVisualStyleBackColor = true;
            this.cbx_getFriendlynameFromFile.CheckedChanged += new System.EventHandler(this.Cbx_getFriendlynameFromFile);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(17, 259);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 13);
            this.label11.TabIndex = 37;
            this.label11.Text = "Friendlyname:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbx_friendlyname
            // 
            this.tbx_friendlyname.Location = new System.Drawing.Point(101, 256);
            this.tbx_friendlyname.MaxLength = 64;
            this.tbx_friendlyname.Name = "tbx_friendlyname";
            this.tbx_friendlyname.Size = new System.Drawing.Size(356, 20);
            this.tbx_friendlyname.TabIndex = 35;
            this.tbx_friendlyname.TextChanged += new System.EventHandler(this.tbx_friendlyname_TextChanged);
            // 
            // cbx_prefixTexture
            // 
            this.cbx_prefixTexture.AutoSize = true;
            this.cbx_prefixTexture.Location = new System.Drawing.Point(101, 233);
            this.cbx_prefixTexture.Name = "cbx_prefixTexture";
            this.cbx_prefixTexture.Size = new System.Drawing.Size(204, 17);
            this.cbx_prefixTexture.TabIndex = 38;
            this.cbx_prefixTexture.Text = "Prefix texture names with object name";
            this.cbx_prefixTexture.UseVisualStyleBackColor = true;
            this.cbx_prefixTexture.CheckedChanged += new System.EventHandler(this.cbx_prefixTexture_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 569);
            this.Controls.Add(this.cbx_prefixTexture);
            this.Controls.Add(this.cbx_getFriendlynameFromFile);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.tbx_friendlyname);
            this.Controls.Add(this.cbx_yUp);
            this.Controls.Add(this.cbx_includeTransparency);
            this.Controls.Add(this.pnl_groups);
            this.Controls.Add(this.tbx_groups1);
            this.Controls.Add(this.tbx_groups2);
            this.Controls.Add(this.tbx_groups3);
            this.Controls.Add(this.tbx_groups4);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btn_browseOutput);
            this.Controls.Add(this.lbl_browseOutput);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btn_browseSource);
            this.Controls.Add(this.lbl_browseSource);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lbl_fileName);
            this.Controls.Add(this.cbx_getFileNameFromFile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbx_fileName);
            this.Controls.Add(this.btn_convert);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Form1";
            this.Text = "OMSI 2 Sceneryobject Creation Utility";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_browseBlender)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_browseXconv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_browseOMSI)).EndInit();
            this.pnl_groups.ResumeLayout(false);
            this.pnl_groups.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_browseOMSI;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbl_browseOMSI;
        private System.Windows.Forms.OpenFileDialog ofd_browseOMSI;
        private System.Windows.Forms.Label lbl_browseBlender;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_browseBlender;
        private System.Windows.Forms.OpenFileDialog ofd_browseBlender;
        private System.Windows.Forms.Label lbl_browseXconv;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_browseXconv;
        private System.Windows.Forms.OpenFileDialog ofd_browseXconv;
        private System.Windows.Forms.OpenFileDialog ofd_browseSketchUp;
        private System.Windows.Forms.PictureBox pic_browseOMSI;
        private System.Windows.Forms.PictureBox pic_browseBlender;
        private System.Windows.Forms.PictureBox pic_browseXconv;
        private System.Windows.Forms.Button btn_convert;
        private System.Windows.Forms.TextBox tbx_fileName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cbx_getFileNameFromFile;
        private System.Windows.Forms.Label lbl_fileName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbl_browseSource;
        private System.Windows.Forms.Button btn_browseSource;
        private System.Windows.Forms.OpenFileDialog ofd_browseSource;
        private System.Windows.Forms.FolderBrowserDialog fbd_browseTexture;
        private System.Windows.Forms.Button btn_browseOutput;
        private System.Windows.Forms.Label lbl_browseOutput;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.FolderBrowserDialog fbd_browseOutput;
        private System.Windows.Forms.RadioButton rdb_groups1;
        private System.Windows.Forms.RadioButton rdb_groups2;
        private System.Windows.Forms.RadioButton rdb_groups3;
        private System.Windows.Forms.RadioButton rdb_groups4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbx_groups4;
        private System.Windows.Forms.TextBox tbx_groups3;
        private System.Windows.Forms.TextBox tbx_groups2;
        private System.Windows.Forms.TextBox tbx_groups1;
        private System.Windows.Forms.Panel pnl_groups;
        private System.Windows.Forms.RadioButton rdb_groups0;
        private System.Windows.Forms.CheckBox cbx_includeTransparency;
        private System.Windows.Forms.CheckBox cbx_yUp;
        private System.Windows.Forms.CheckBox cbx_getFriendlynameFromFile;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbx_friendlyname;
        private System.Windows.Forms.CheckBox cbx_prefixTexture;
    }
}

