namespace DrawIntoImage
{
    partial class Main
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
            this.bInit = new System.Windows.Forms.Button();
            this.lHint = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bInit
            // 
            this.bInit.Location = new System.Drawing.Point(25, 10);
            this.bInit.Name = "bInit";
            this.bInit.Size = new System.Drawing.Size(163, 23);
            this.bInit.TabIndex = 0;
            this.bInit.Text = "Inicializovat hrací pole";
            this.bInit.UseVisualStyleBackColor = true;
            this.bInit.Click += new System.EventHandler(this.bInit_Click);
            // 
            // lHint
            // 
            this.lHint.AutoSize = true;
            this.lHint.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lHint.Location = new System.Drawing.Point(21, 45);
            this.lHint.Name = "lHint";
            this.lHint.Size = new System.Drawing.Size(396, 24);
            this.lHint.TabIndex = 1;
            this.lHint.Text = "Kliknutím na šahovnici vykreslete obrázek";
            this.lHint.Visible = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 621);
            this.Controls.Add(this.lHint);
            this.Controls.Add(this.bInit);
            this.Name = "Main";
            this.Text = "Ukázka kreslení do obrázku";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bInit;
        private System.Windows.Forms.Label lHint;
    }
}

