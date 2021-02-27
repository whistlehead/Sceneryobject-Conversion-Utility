namespace SceneryobjectConversionUtility
{
    partial class ConfirmOverwrite
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
            this.exists_btn_cancel = new System.Windows.Forms.Button();
            this.exists_btn_continue = new System.Windows.Forms.Button();
            this.exists_cmb_behaviour = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // exists_btn_cancel
            // 
            this.exists_btn_cancel.Location = new System.Drawing.Point(207, 57);
            this.exists_btn_cancel.Name = "exists_btn_cancel";
            this.exists_btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.exists_btn_cancel.TabIndex = 0;
            this.exists_btn_cancel.Text = "Cancel";
            this.exists_btn_cancel.UseVisualStyleBackColor = true;
            this.exists_btn_cancel.Click += new System.EventHandler(this.exists_btn_cancel_click);
            // 
            // exists_btn_continue
            // 
            this.exists_btn_continue.Location = new System.Drawing.Point(126, 57);
            this.exists_btn_continue.Name = "exists_btn_continue";
            this.exists_btn_continue.Size = new System.Drawing.Size(75, 23);
            this.exists_btn_continue.TabIndex = 1;
            this.exists_btn_continue.Text = "Continue";
            this.exists_btn_continue.UseVisualStyleBackColor = true;
            this.exists_btn_continue.Click += new System.EventHandler(this.exists_btn_continue_click);
            // 
            // exists_cmb_behaviour
            // 
            this.exists_cmb_behaviour.FormattingEnabled = true;
            this.exists_cmb_behaviour.Items.AddRange(new object[] {
            "Export new files and overwrite SCO",
            "Export new files and do not overwrite SCO"});
            this.exists_cmb_behaviour.Location = new System.Drawing.Point(12, 30);
            this.exists_cmb_behaviour.Name = "exists_cmb_behaviour";
            this.exists_cmb_behaviour.Size = new System.Drawing.Size(270, 21);
            this.exists_cmb_behaviour.TabIndex = 2;
            this.exists_cmb_behaviour.SelectedIndexChanged += new System.EventHandler(this.exists_cmb_behaviour_selectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(270, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Sceneryobject already exists. Please choose behaviour:";
            // 
            // ConfirmOverwrite
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 89);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.exists_cmb_behaviour);
            this.Controls.Add(this.exists_btn_continue);
            this.Controls.Add(this.exists_btn_cancel);
            this.Name = "ConfirmOverwrite";
            this.Text = "ConfirmOverwrite";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button exists_btn_cancel;
        private System.Windows.Forms.Button exists_btn_continue;
        private System.Windows.Forms.ComboBox exists_cmb_behaviour;
        private System.Windows.Forms.Label label1;
    }
}