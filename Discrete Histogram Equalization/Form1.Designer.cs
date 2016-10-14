namespace Discrete_Histogram_Equalization
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.Source = new System.Windows.Forms.PictureBox();
            this.Answer = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.MinPixel = new System.Windows.Forms.TextBox();
            this.MaxPixel = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Source_R = new System.Windows.Forms.PictureBox();
            this.Source_G = new System.Windows.Forms.PictureBox();
            this.Source_B = new System.Windows.Forms.PictureBox();
            this.Answer_B = new System.Windows.Forms.PictureBox();
            this.Answer_G = new System.Windows.Forms.PictureBox();
            this.Answer_R = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Source)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Answer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Source_R)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Source_G)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Source_B)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Answer_B)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Answer_G)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Answer_R)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Source
            // 
            this.Source.Location = new System.Drawing.Point(12, 12);
            this.Source.Name = "Source";
            this.Source.Size = new System.Drawing.Size(400, 400);
            this.Source.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Source.TabIndex = 0;
            this.Source.TabStop = false;
            // 
            // Answer
            // 
            this.Answer.Location = new System.Drawing.Point(12, 524);
            this.Answer.Name = "Answer";
            this.Answer.Size = new System.Drawing.Size(400, 400);
            this.Answer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Answer.TabIndex = 1;
            this.Answer.TabStop = false;
            this.Answer.Click += new System.EventHandler(this.Answer_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(337, 458);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Histogram";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MinPixel
            // 
            this.MinPixel.Location = new System.Drawing.Point(99, 460);
            this.MinPixel.Name = "MinPixel";
            this.MinPixel.Size = new System.Drawing.Size(50, 22);
            this.MinPixel.TabIndex = 3;
            this.MinPixel.Text = "0";
            // 
            // MaxPixel
            // 
            this.MaxPixel.Location = new System.Drawing.Point(235, 460);
            this.MaxPixel.Name = "MaxPixel";
            this.MaxPixel.Size = new System.Drawing.Size(54, 22);
            this.MaxPixel.TabIndex = 4;
            this.MaxPixel.Text = "255";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 463);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "Min Pixel";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(177, 460);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "Max Pixel";
            // 
            // Source_R
            // 
            this.Source_R.Location = new System.Drawing.Point(448, 11);
            this.Source_R.Name = "Source_R";
            this.Source_R.Size = new System.Drawing.Size(300, 300);
            this.Source_R.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Source_R.TabIndex = 7;
            this.Source_R.TabStop = false;
            // 
            // Source_G
            // 
            this.Source_G.Location = new System.Drawing.Point(448, 317);
            this.Source_G.Name = "Source_G";
            this.Source_G.Size = new System.Drawing.Size(300, 300);
            this.Source_G.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Source_G.TabIndex = 8;
            this.Source_G.TabStop = false;
            // 
            // Source_B
            // 
            this.Source_B.Location = new System.Drawing.Point(448, 623);
            this.Source_B.Name = "Source_B";
            this.Source_B.Size = new System.Drawing.Size(300, 300);
            this.Source_B.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Source_B.TabIndex = 9;
            this.Source_B.TabStop = false;
            // 
            // Answer_B
            // 
            this.Answer_B.Location = new System.Drawing.Point(780, 623);
            this.Answer_B.Name = "Answer_B";
            this.Answer_B.Size = new System.Drawing.Size(300, 300);
            this.Answer_B.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Answer_B.TabIndex = 12;
            this.Answer_B.TabStop = false;
            // 
            // Answer_G
            // 
            this.Answer_G.Location = new System.Drawing.Point(780, 317);
            this.Answer_G.Name = "Answer_G";
            this.Answer_G.Size = new System.Drawing.Size(300, 300);
            this.Answer_G.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Answer_G.TabIndex = 11;
            this.Answer_G.TabStop = false;
            // 
            // Answer_R
            // 
            this.Answer_R.Location = new System.Drawing.Point(780, 11);
            this.Answer_R.Name = "Answer_R";
            this.Answer_R.Size = new System.Drawing.Size(300, 300);
            this.Answer_R.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Answer_R.TabIndex = 10;
            this.Answer_R.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 941);
            this.Controls.Add(this.Answer_B);
            this.Controls.Add(this.Answer_G);
            this.Controls.Add(this.Answer_R);
            this.Controls.Add(this.Source_B);
            this.Controls.Add(this.Source_G);
            this.Controls.Add(this.Source_R);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MaxPixel);
            this.Controls.Add(this.MinPixel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Answer);
            this.Controls.Add(this.Source);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Source)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Answer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Source_R)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Source_G)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Source_B)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Answer_B)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Answer_G)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Answer_R)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.PictureBox Source;
        private System.Windows.Forms.PictureBox Answer;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox MinPixel;
        private System.Windows.Forms.TextBox MaxPixel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox Source_R;
        private System.Windows.Forms.PictureBox Source_G;
        private System.Windows.Forms.PictureBox Source_B;
        private System.Windows.Forms.PictureBox Answer_B;
        private System.Windows.Forms.PictureBox Answer_G;
        private System.Windows.Forms.PictureBox Answer_R;
    }
}

