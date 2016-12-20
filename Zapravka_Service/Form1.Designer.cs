namespace Zapravka_Service
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.rbColumn1 = new System.Windows.Forms.RichTextBox();
            this.rbColumn2 = new System.Windows.Forms.RichTextBox();
            this.rbParking = new System.Windows.Forms.RichTextBox();
            this.rbInspection = new System.Windows.Forms.RichTextBox();
            this.rbStat = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
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
            this.label5.BackColor = System.Drawing.SystemColors.Window;
            this.label5.Name = "label5";
            // 
            // btnStart
            // 
            resources.ApplyResources(this.btnStart, "btnStart");
            this.btnStart.Name = "btnStart";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            resources.ApplyResources(this.btnStop, "btnStop");
            this.btnStop.Name = "btnStop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // rbColumn1
            // 
            resources.ApplyResources(this.rbColumn1, "rbColumn1");
            this.rbColumn1.Name = "rbColumn1";
            // 
            // rbColumn2
            // 
            resources.ApplyResources(this.rbColumn2, "rbColumn2");
            this.rbColumn2.Name = "rbColumn2";
            this.rbColumn2.TextChanged += new System.EventHandler(this.rbColumn2_TextChanged);
            // 
            // rbParking
            // 
            resources.ApplyResources(this.rbParking, "rbParking");
            this.rbParking.Name = "rbParking";
            // 
            // rbInspection
            // 
            resources.ApplyResources(this.rbInspection, "rbInspection");
            this.rbInspection.Name = "rbInspection";
            this.rbInspection.TextChanged += new System.EventHandler(this.rbInspection_TextChanged);
            // 
            // rbStat
            // 
            resources.ApplyResources(this.rbStat, "rbStat");
            this.rbStat.Name = "rbStat";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Zapravka_Service.Properties.Resources._3d_proektirovanie_1;
            this.Controls.Add(this.label6);
            this.Controls.Add(this.rbStat);
            this.Controls.Add(this.rbInspection);
            this.Controls.Add(this.rbParking);
            this.Controls.Add(this.rbColumn2);
            this.Controls.Add(this.rbColumn1);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.RichTextBox rbColumn1;
        private System.Windows.Forms.RichTextBox rbColumn2;
        private System.Windows.Forms.RichTextBox rbParking;
        private System.Windows.Forms.RichTextBox rbInspection;
        private System.Windows.Forms.RichTextBox rbStat;
        private System.Windows.Forms.Label label6;
    }
}

