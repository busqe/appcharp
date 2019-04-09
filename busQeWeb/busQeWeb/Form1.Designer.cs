namespace busQeWeb
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnPesquisa = new System.Windows.Forms.Button();
            this.txtPesquisa = new System.Windows.Forms.TextBox();
            this.btnFechar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblPesquisar = new System.Windows.Forms.Label();
            this.btnOpcao1 = new System.Windows.Forms.Button();
            this.btnOpcao2 = new System.Windows.Forms.Button();
            this.btnOpcao3 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPesquisa
            // 
            this.btnPesquisa.BackgroundImage = global::busQeWeb.Properties.Resources.q_icon_48;
            this.btnPesquisa.Location = new System.Drawing.Point(626, 26);
            this.btnPesquisa.Margin = new System.Windows.Forms.Padding(0);
            this.btnPesquisa.Name = "btnPesquisa";
            this.btnPesquisa.Size = new System.Drawing.Size(48, 48);
            this.btnPesquisa.TabIndex = 0;
            this.btnPesquisa.UseVisualStyleBackColor = true;
            this.btnPesquisa.Click += new System.EventHandler(this.btnPesquisa_Click);
            // 
            // txtPesquisa
            // 
            this.txtPesquisa.Location = new System.Drawing.Point(29, 27);
            this.txtPesquisa.Name = "txtPesquisa";
            this.txtPesquisa.Size = new System.Drawing.Size(590, 20);
            this.txtPesquisa.TabIndex = 1;
            this.txtPesquisa.TextChanged += new System.EventHandler(this.txtPesquisa_TextChanged);
            // 
            // btnFechar
            // 
            this.btnFechar.Location = new System.Drawing.Point(646, 94);
            this.btnFechar.Margin = new System.Windows.Forms.Padding(0);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(28, 24);
            this.btnFechar.TabIndex = 3;
            this.btnFechar.Text = "X";
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnOpcao3);
            this.panel1.Controls.Add(this.btnOpcao2);
            this.panel1.Controls.Add(this.btnOpcao1);
            this.panel1.Location = new System.Drawing.Point(289, 76);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(330, 42);
            this.panel1.TabIndex = 4;
            // 
            // lblPesquisar
            // 
            this.lblPesquisar.AutoSize = true;
            this.lblPesquisar.Location = new System.Drawing.Point(30, 96);
            this.lblPesquisar.Name = "lblPesquisar";
            this.lblPesquisar.Size = new System.Drawing.Size(53, 13);
            this.lblPesquisar.TabIndex = 2;
            this.lblPesquisar.Text = "Pesquisar";
            // 
            // btnOpcao1
            // 
            this.btnOpcao1.Location = new System.Drawing.Point(12, 10);
            this.btnOpcao1.Name = "btnOpcao1";
            this.btnOpcao1.Size = new System.Drawing.Size(100, 30);
            this.btnOpcao1.TabIndex = 0;
            this.btnOpcao1.Text = "...";
            this.btnOpcao1.UseVisualStyleBackColor = true;
            this.btnOpcao1.Click += new System.EventHandler(this.btnOpcao1_Click);
            // 
            // btnOpcao2
            // 
            this.btnOpcao2.Location = new System.Drawing.Point(118, 10);
            this.btnOpcao2.Name = "btnOpcao2";
            this.btnOpcao2.Size = new System.Drawing.Size(100, 30);
            this.btnOpcao2.TabIndex = 1;
            this.btnOpcao2.Text = "...";
            this.btnOpcao2.UseVisualStyleBackColor = true;
            this.btnOpcao2.Click += new System.EventHandler(this.btnOpcao2_Click);
            // 
            // btnOpcao3
            // 
            this.btnOpcao3.Location = new System.Drawing.Point(224, 10);
            this.btnOpcao3.Name = "btnOpcao3";
            this.btnOpcao3.Size = new System.Drawing.Size(100, 30);
            this.btnOpcao3.TabIndex = 2;
            this.btnOpcao3.Text = "...";
            this.btnOpcao3.UseVisualStyleBackColor = true;
            this.btnOpcao3.Click += new System.EventHandler(this.btnOpcao3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 121);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.lblPesquisar);
            this.Controls.Add(this.txtPesquisa);
            this.Controls.Add(this.btnPesquisa);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "busQe Web";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPesquisa;
        private System.Windows.Forms.TextBox txtPesquisa;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblPesquisar;
        private System.Windows.Forms.Button btnOpcao1;
        private System.Windows.Forms.Button btnOpcao3;
        private System.Windows.Forms.Button btnOpcao2;
    }
}

