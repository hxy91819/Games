namespace SimpleChess
{
    partial class FrmChess
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnStart = new System.Windows.Forms.Button();
            this.pnlControl = new System.Windows.Forms.Panel();
            this.pnlChessBoard = new System.Windows.Forms.Panel();
            this.btnLeftUp = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnLeftDown = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnRightDown = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnRightUp = new System.Windows.Forms.Button();
            this.tmrLazyLoad = new System.Windows.Forms.Timer(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.richTextBoxLog = new System.Windows.Forms.RichTextBox();
            this.pnlControl.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(28, 14);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(126, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "开始游戏";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // pnlControl
            // 
            this.pnlControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlControl.Controls.Add(this.btnRightUp);
            this.pnlControl.Controls.Add(this.btnRight);
            this.pnlControl.Controls.Add(this.btnRightDown);
            this.pnlControl.Controls.Add(this.btnDown);
            this.pnlControl.Controls.Add(this.btnLeftDown);
            this.pnlControl.Controls.Add(this.btnUp);
            this.pnlControl.Controls.Add(this.btnLeft);
            this.pnlControl.Controls.Add(this.btnLeftUp);
            this.pnlControl.Controls.Add(this.btnStart);
            this.pnlControl.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlControl.Location = new System.Drawing.Point(379, 0);
            this.pnlControl.Name = "pnlControl";
            this.pnlControl.Size = new System.Drawing.Size(179, 373);
            this.pnlControl.TabIndex = 1;
            // 
            // pnlChessBoard
            // 
            this.pnlChessBoard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlChessBoard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChessBoard.Location = new System.Drawing.Point(0, 0);
            this.pnlChessBoard.Name = "pnlChessBoard";
            this.pnlChessBoard.Size = new System.Drawing.Size(726, 373);
            this.pnlChessBoard.TabIndex = 2;
            // 
            // btnLeftUp
            // 
            this.btnLeftUp.Location = new System.Drawing.Point(28, 233);
            this.btnLeftUp.Name = "btnLeftUp";
            this.btnLeftUp.Size = new System.Drawing.Size(40, 40);
            this.btnLeftUp.TabIndex = 1;
            this.btnLeftUp.Text = "↖";
            this.btnLeftUp.UseVisualStyleBackColor = true;
            // 
            // btnLeft
            // 
            this.btnLeft.Location = new System.Drawing.Point(28, 275);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(40, 40);
            this.btnLeft.TabIndex = 2;
            this.btnLeft.Text = "←";
            this.btnLeft.UseVisualStyleBackColor = true;
            // 
            // btnUp
            // 
            this.btnUp.Location = new System.Drawing.Point(70, 233);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(40, 40);
            this.btnUp.TabIndex = 3;
            this.btnUp.Text = "↑";
            this.btnUp.UseVisualStyleBackColor = true;
            // 
            // btnLeftDown
            // 
            this.btnLeftDown.Location = new System.Drawing.Point(28, 318);
            this.btnLeftDown.Name = "btnLeftDown";
            this.btnLeftDown.Size = new System.Drawing.Size(40, 40);
            this.btnLeftDown.TabIndex = 4;
            this.btnLeftDown.Text = "↙";
            this.btnLeftDown.UseVisualStyleBackColor = true;
            // 
            // btnDown
            // 
            this.btnDown.Location = new System.Drawing.Point(70, 318);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(40, 40);
            this.btnDown.TabIndex = 6;
            this.btnDown.Text = "↓";
            this.btnDown.UseVisualStyleBackColor = true;
            // 
            // btnRightDown
            // 
            this.btnRightDown.Location = new System.Drawing.Point(112, 318);
            this.btnRightDown.Name = "btnRightDown";
            this.btnRightDown.Size = new System.Drawing.Size(40, 40);
            this.btnRightDown.TabIndex = 7;
            this.btnRightDown.Text = "↘";
            this.btnRightDown.UseVisualStyleBackColor = true;
            // 
            // btnRight
            // 
            this.btnRight.Location = new System.Drawing.Point(112, 275);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(40, 40);
            this.btnRight.TabIndex = 8;
            this.btnRight.Text = "→";
            this.btnRight.UseVisualStyleBackColor = true;
            // 
            // btnRightUp
            // 
            this.btnRightUp.Location = new System.Drawing.Point(112, 233);
            this.btnRightUp.Name = "btnRightUp";
            this.btnRightUp.Size = new System.Drawing.Size(40, 40);
            this.btnRightUp.TabIndex = 9;
            this.btnRightUp.Text = "↗";
            this.btnRightUp.UseVisualStyleBackColor = true;
            // 
            // tmrLazyLoad
            // 
            this.tmrLazyLoad.Tick += new System.EventHandler(this.tmrLazyLoad_Tick);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.richTextBoxLog);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(558, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(168, 373);
            this.panel2.TabIndex = 11;
            // 
            // richTextBoxLog
            // 
            this.richTextBoxLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxLog.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxLog.Name = "richTextBoxLog";
            this.richTextBoxLog.ReadOnly = true;
            this.richTextBoxLog.Size = new System.Drawing.Size(166, 371);
            this.richTextBoxLog.TabIndex = 0;
            this.richTextBoxLog.Text = "";
            // 
            // frmChess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 373);
            this.Controls.Add(this.pnlControl);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlChessBoard);
            this.Name = "frmChess";
            this.Text = "简易棋子游戏";
            this.Load += new System.EventHandler(this.frmChess_Load);
            this.pnlControl.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Panel pnlControl;
        private System.Windows.Forms.Panel pnlChessBoard;
        private System.Windows.Forms.Button btnRightUp;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Button btnRightDown;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnLeftDown;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Button btnLeftUp;
        private System.Windows.Forms.Timer tmrLazyLoad;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RichTextBox richTextBoxLog;
    }
}

