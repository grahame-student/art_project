
namespace art_project
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.picSurface = new System.Windows.Forms.PictureBox();
            this.tabContainer = new System.Windows.Forms.TableLayoutPanel();
            this.tmrRenderTick = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picSurface)).BeginInit();
            this.tabContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // picSurface
            // 
            this.picSurface.Location = new System.Drawing.Point(3, 3);
            this.picSurface.Name = "picSurface";
            this.picSurface.Size = new System.Drawing.Size(1333, 1000);
            this.picSurface.TabIndex = 0;
            this.picSurface.TabStop = false;
            this.picSurface.Paint += new System.Windows.Forms.PaintEventHandler(this.picSurface_Paint);
            // 
            // tabContainer
            // 
            this.tabContainer.AutoSize = true;
            this.tabContainer.ColumnCount = 1;
            this.tabContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tabContainer.Controls.Add(this.picSurface, 0, 0);
            this.tabContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabContainer.Location = new System.Drawing.Point(0, 0);
            this.tabContainer.Name = "tabContainer";
            this.tabContainer.RowCount = 1;
            this.tabContainer.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tabContainer.Size = new System.Drawing.Size(784, 561);
            this.tabContainer.TabIndex = 1;
            // 
            // tmrRenderTick
            // 
            this.tmrRenderTick.Enabled = true;
            this.tmrRenderTick.Interval = 20;
            this.tmrRenderTick.Tick += new System.EventHandler(this.tmrRenderTick_Tick);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.tabContainer);
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.picSurface)).EndInit();
            this.tabContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picSurface;
        private System.Windows.Forms.TableLayoutPanel tabContainer;
        private System.Windows.Forms.Timer tmrRenderTick;
    }
}

