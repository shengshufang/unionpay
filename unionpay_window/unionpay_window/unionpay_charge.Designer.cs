namespace unionpay_window
{
    partial class unionpay_charge
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(unionpay_charge));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label_intime_c = new System.Windows.Forms.Label();
            this.label_outtime_c = new System.Windows.Forms.Label();
            this.label7_sumtime = new System.Windows.Forms.Label();
            this.label_cartype_c = new System.Windows.Forms.Label();
            this.label_area_c = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label_lincensenum_c = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label_chargenum = new System.Windows.Forms.Label();
            this.button_charge = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label_intime_c
            // 
            resources.ApplyResources(this.label_intime_c, "label_intime_c");
            this.label_intime_c.Name = "label_intime_c";
            // 
            // label_outtime_c
            // 
            resources.ApplyResources(this.label_outtime_c, "label_outtime_c");
            this.label_outtime_c.Name = "label_outtime_c";
            // 
            // label7_sumtime
            // 
            resources.ApplyResources(this.label7_sumtime, "label7_sumtime");
            this.label7_sumtime.Name = "label7_sumtime";
            // 
            // label_cartype_c
            // 
            resources.ApplyResources(this.label_cartype_c, "label_cartype_c");
            this.label_cartype_c.Name = "label_cartype_c";
            // 
            // label_area_c
            // 
            resources.ApplyResources(this.label_area_c, "label_area_c");
            this.label_area_c.Name = "label_area_c";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // label_lincensenum_c
            // 
            resources.ApplyResources(this.label_lincensenum_c, "label_lincensenum_c");
            this.label_lincensenum_c.Name = "label_lincensenum_c";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // label_chargenum
            // 
            resources.ApplyResources(this.label_chargenum, "label_chargenum");
            this.label_chargenum.Name = "label_chargenum";
            // 
            // button_charge
            // 
            resources.ApplyResources(this.button_charge, "button_charge");
            this.button_charge.Name = "button_charge";
            this.button_charge.UseVisualStyleBackColor = true;
            this.button_charge.Click += new System.EventHandler(this.button_charge_Click);
            // 
            // unionpay_charge
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button_charge);
            this.Controls.Add(this.label_chargenum);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label_lincensenum_c);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label_area_c);
            this.Controls.Add(this.label_cartype_c);
            this.Controls.Add(this.label7_sumtime);
            this.Controls.Add(this.label_outtime_c);
            this.Controls.Add(this.label_intime_c);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "unionpay_charge";
            this.Load += new System.EventHandler(this.unionpay_charge_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button_charge;
        public System.Windows.Forms.Label label_intime_c;
        public System.Windows.Forms.Label label_lincensenum_c;
        public System.Windows.Forms.Label label_outtime_c;
        public System.Windows.Forms.Label label7_sumtime;
        public System.Windows.Forms.Label label_cartype_c;
        public System.Windows.Forms.Label label_area_c;
        public System.Windows.Forms.Label label_chargenum;
    }
}