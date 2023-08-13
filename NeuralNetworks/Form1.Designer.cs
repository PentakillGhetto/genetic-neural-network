namespace NeuralNetworks
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
            this.PanelDrawingArea = new System.Windows.Forms.Panel();
            this.labelGenCount = new System.Windows.Forms.Label();
            this.labelBestDotStepCount = new System.Windows.Forms.Label();
            this.labelBestDotFintess = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // PanelDrawingArea
            // 
            this.PanelDrawingArea.Location = new System.Drawing.Point(0, 0);
            this.PanelDrawingArea.Name = "PanelDrawingArea";
            this.PanelDrawingArea.Size = new System.Drawing.Size(262, 249);
            this.PanelDrawingArea.TabIndex = 0;
            this.PanelDrawingArea.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelDrawingArea_Paint);
            // 
            // labelGenCount
            // 
            this.labelGenCount.AutoSize = true;
            this.labelGenCount.Location = new System.Drawing.Point(268, 9);
            this.labelGenCount.Name = "labelGenCount";
            this.labelGenCount.Size = new System.Drawing.Size(89, 13);
            this.labelGenCount.TabIndex = 1;
            this.labelGenCount.Text = "Поколение: N/A";
            // 
            // labelBestDotStepCount
            // 
            this.labelBestDotStepCount.AutoSize = true;
            this.labelBestDotStepCount.Location = new System.Drawing.Point(268, 33);
            this.labelBestDotStepCount.Name = "labelBestDotStepCount";
            this.labelBestDotStepCount.Size = new System.Drawing.Size(171, 13);
            this.labelBestDotStepCount.TabIndex = 2;
            this.labelBestDotStepCount.Text = "Кол-во шагов лучшей точки: N/A";
            // 
            // labelBestDotFintess
            // 
            this.labelBestDotFintess.AutoSize = true;
            this.labelBestDotFintess.Location = new System.Drawing.Point(268, 61);
            this.labelBestDotFintess.Name = "labelBestDotFintess";
            this.labelBestDotFintess.Size = new System.Drawing.Size(136, 13);
            this.labelBestDotFintess.TabIndex = 3;
            this.labelBestDotFintess.Text = "Fitness лучшей точки: N/A";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 290);
            this.Controls.Add(this.labelBestDotFintess);
            this.Controls.Add(this.labelBestDotStepCount);
            this.Controls.Add(this.labelGenCount);
            this.Controls.Add(this.PanelDrawingArea);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelDrawingArea_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PanelDrawingArea;
        private System.Windows.Forms.Label labelGenCount;
        private System.Windows.Forms.Label labelBestDotStepCount;
        private System.Windows.Forms.Label labelBestDotFintess;
    }
}

