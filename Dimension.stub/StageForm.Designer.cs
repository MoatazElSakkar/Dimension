namespace Dimension.stub
{
    partial class StageForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StageForm));
            this.Render_btn = new System.Windows.Forms.Button();
            this.preview = new System.Windows.Forms.PictureBox();
            this.Logo_picBox = new System.Windows.Forms.PictureBox();
            this.StageSelector = new System.Windows.Forms.ComboBox();
            this.cubeTimer = new System.Windows.Forms.Timer(this.components);
            this.pyramidsTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.preview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Logo_picBox)).BeginInit();
            this.SuspendLayout();
            // 
            // Render_btn
            // 
            this.Render_btn.Location = new System.Drawing.Point(625, 402);
            this.Render_btn.Name = "Render_btn";
            this.Render_btn.Size = new System.Drawing.Size(75, 23);
            this.Render_btn.TabIndex = 0;
            this.Render_btn.Text = "Render";
            this.Render_btn.UseVisualStyleBackColor = true;
            this.Render_btn.Click += new System.EventHandler(this.Test_Click);
            // 
            // preview
            // 
            this.preview.Location = new System.Drawing.Point(12, 12);
            this.preview.Name = "preview";
            this.preview.Size = new System.Drawing.Size(720, 360);
            this.preview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.preview.TabIndex = 1;
            this.preview.TabStop = false;
            // 
            // Logo_picBox
            // 
            this.Logo_picBox.BackColor = System.Drawing.Color.Transparent;
            this.Logo_picBox.Image = global::Dimension.stub.Properties.Resources.DimensionLogo;
            this.Logo_picBox.Location = new System.Drawing.Point(12, 376);
            this.Logo_picBox.Name = "Logo_picBox";
            this.Logo_picBox.Size = new System.Drawing.Size(300, 75);
            this.Logo_picBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Logo_picBox.TabIndex = 2;
            this.Logo_picBox.TabStop = false;
            // 
            // StageSelector
            // 
            this.StageSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.StageSelector.FormattingEnabled = true;
            this.StageSelector.Location = new System.Drawing.Point(429, 403);
            this.StageSelector.Name = "StageSelector";
            this.StageSelector.Size = new System.Drawing.Size(190, 21);
            this.StageSelector.TabIndex = 3;
            // 
            // cubeTimer
            // 
            this.cubeTimer.Tick += new System.EventHandler(this.cubeTimer_Tick);
            // 
            // pyramidsTimer
            // 
            this.pyramidsTimer.Interval = 750;
            this.pyramidsTimer.Tag = "0";
            this.pyramidsTimer.Tick += new System.EventHandler(this.pyramidsTimer_Tick);
            // 
            // StageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 453);
            this.Controls.Add(this.StageSelector);
            this.Controls.Add(this.Logo_picBox);
            this.Controls.Add(this.preview);
            this.Controls.Add(this.Render_btn);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "StageForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Project Dimension Diagnostic Utility";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.preview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Logo_picBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Render_btn;
        private System.Windows.Forms.PictureBox preview;
        private System.Windows.Forms.PictureBox Logo_picBox;
        private System.Windows.Forms.ComboBox StageSelector;
        private System.Windows.Forms.Timer cubeTimer;
        private System.Windows.Forms.Timer pyramidsTimer;
    }
}

