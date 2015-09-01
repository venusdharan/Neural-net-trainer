namespace NeuralNetTrainer
{
    partial class BinarySplitForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BinarySplitForm));
            this.backgroundWorkerTrainer = new System.ComponentModel.BackgroundWorker();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.backgroundWorkerSignal = new System.ComponentModel.BackgroundWorker();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.fILEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eXITToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sESSIONToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sTARTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sTOPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oPENERRORLOGGERToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lEARNINGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sTARTToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.sTOPToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.hELPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aBOUTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sERVERToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sTARTToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.sTOPToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.rECOGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sTARTToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.sTOPToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.rANDOMIZEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lOADTEMPLATEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cREATEERRORLOGFILEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aPPENDTOERRORLOGFILEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "feed forward network files (*.ffn)|*.ffn";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.CheckPathExists = false;
            this.saveFileDialog1.DefaultExt = "ffn";
            this.saveFileDialog1.RestoreDirectory = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(386, 34);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(244, 20);
            this.textBox1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(351, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Error";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Elapsed Milliseconds";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(126, 34);
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(219, 20);
            this.textBox6.TabIndex = 16;
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.zedGraphControl1.AutoScroll = true;
            this.zedGraphControl1.IsAntiAlias = true;
            this.zedGraphControl1.IsAutoScrollRange = true;
            this.zedGraphControl1.Location = new System.Drawing.Point(9, 63);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(996, 571);
            this.zedGraphControl1.TabIndex = 18;
            // 
            // fILEToolStripMenuItem
            // 
            this.fILEToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadFileToolStripMenuItem,
            this.saveFileToolStripMenuItem,
            this.cREATEERRORLOGFILEToolStripMenuItem,
            this.aPPENDTOERRORLOGFILEToolStripMenuItem,
            this.eXITToolStripMenuItem});
            this.fILEToolStripMenuItem.Name = "fILEToolStripMenuItem";
            this.fILEToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.fILEToolStripMenuItem.Text = "FILE";
            // 
            // loadFileToolStripMenuItem
            // 
            this.loadFileToolStripMenuItem.Name = "loadFileToolStripMenuItem";
            this.loadFileToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.loadFileToolStripMenuItem.Text = "LOAD FILE";
            this.loadFileToolStripMenuItem.Click += new System.EventHandler(this.loadFileToolStripMenuItem_Click);
            // 
            // saveFileToolStripMenuItem
            // 
            this.saveFileToolStripMenuItem.Name = "saveFileToolStripMenuItem";
            this.saveFileToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.saveFileToolStripMenuItem.Text = "SAVE FILE";
            this.saveFileToolStripMenuItem.Click += new System.EventHandler(this.saveFileToolStripMenuItem_Click);
            // 
            // eXITToolStripMenuItem
            // 
            this.eXITToolStripMenuItem.Name = "eXITToolStripMenuItem";
            this.eXITToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.eXITToolStripMenuItem.Text = "EXIT";
            this.eXITToolStripMenuItem.Click += new System.EventHandler(this.eXITToolStripMenuItem_Click);
            // 
            // sESSIONToolStripMenuItem
            // 
            this.sESSIONToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sTARTToolStripMenuItem,
            this.sTOPToolStripMenuItem,
            this.oPENERRORLOGGERToolStripMenuItem});
            this.sESSIONToolStripMenuItem.Name = "sESSIONToolStripMenuItem";
            this.sESSIONToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.sESSIONToolStripMenuItem.Text = "SESSION";
            // 
            // sTARTToolStripMenuItem
            // 
            this.sTARTToolStripMenuItem.Name = "sTARTToolStripMenuItem";
            this.sTARTToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.sTARTToolStripMenuItem.Text = "START";
            this.sTARTToolStripMenuItem.Click += new System.EventHandler(this.sTARTToolStripMenuItem_Click);
            // 
            // sTOPToolStripMenuItem
            // 
            this.sTOPToolStripMenuItem.Name = "sTOPToolStripMenuItem";
            this.sTOPToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.sTOPToolStripMenuItem.Text = "STOP";
            this.sTOPToolStripMenuItem.Click += new System.EventHandler(this.sTOPToolStripMenuItem_Click);
            // 
            // oPENERRORLOGGERToolStripMenuItem
            // 
            this.oPENERRORLOGGERToolStripMenuItem.Name = "oPENERRORLOGGERToolStripMenuItem";
            this.oPENERRORLOGGERToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.oPENERRORLOGGERToolStripMenuItem.Text = "OPEN ERROR LOGGER";
            this.oPENERRORLOGGERToolStripMenuItem.Click += new System.EventHandler(this.oPENERRORLOGGERToolStripMenuItem_Click);
            // 
            // lEARNINGToolStripMenuItem
            // 
            this.lEARNINGToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sTARTToolStripMenuItem1,
            this.sTOPToolStripMenuItem1,
            this.rANDOMIZEToolStripMenuItem,
            this.lOADTEMPLATEToolStripMenuItem});
            this.lEARNINGToolStripMenuItem.Name = "lEARNINGToolStripMenuItem";
            this.lEARNINGToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.lEARNINGToolStripMenuItem.Text = "LEARNING";
            // 
            // sTARTToolStripMenuItem1
            // 
            this.sTARTToolStripMenuItem1.Name = "sTARTToolStripMenuItem1";
            this.sTARTToolStripMenuItem1.Size = new System.Drawing.Size(166, 22);
            this.sTARTToolStripMenuItem1.Text = "START";
            this.sTARTToolStripMenuItem1.Click += new System.EventHandler(this.sTARTToolStripMenuItem1_Click);
            // 
            // sTOPToolStripMenuItem1
            // 
            this.sTOPToolStripMenuItem1.Name = "sTOPToolStripMenuItem1";
            this.sTOPToolStripMenuItem1.Size = new System.Drawing.Size(166, 22);
            this.sTOPToolStripMenuItem1.Text = "STOP";
            this.sTOPToolStripMenuItem1.Click += new System.EventHandler(this.sTOPToolStripMenuItem1_Click);
            // 
            // hELPToolStripMenuItem
            // 
            this.hELPToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aBOUTToolStripMenuItem});
            this.hELPToolStripMenuItem.Name = "hELPToolStripMenuItem";
            this.hELPToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.hELPToolStripMenuItem.Text = "HELP";
            // 
            // aBOUTToolStripMenuItem
            // 
            this.aBOUTToolStripMenuItem.Name = "aBOUTToolStripMenuItem";
            this.aBOUTToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aBOUTToolStripMenuItem.Text = "ABOUT";
            this.aBOUTToolStripMenuItem.Click += new System.EventHandler(this.aBOUTToolStripMenuItem_Click);
            // 
            // sERVERToolStripMenuItem
            // 
            this.sERVERToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sTARTToolStripMenuItem2,
            this.sTOPToolStripMenuItem2});
            this.sERVERToolStripMenuItem.Name = "sERVERToolStripMenuItem";
            this.sERVERToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.sERVERToolStripMenuItem.Text = "SERVER";
            // 
            // sTARTToolStripMenuItem2
            // 
            this.sTARTToolStripMenuItem2.Name = "sTARTToolStripMenuItem2";
            this.sTARTToolStripMenuItem2.Size = new System.Drawing.Size(152, 22);
            this.sTARTToolStripMenuItem2.Text = "START";
            // 
            // sTOPToolStripMenuItem2
            // 
            this.sTOPToolStripMenuItem2.Name = "sTOPToolStripMenuItem2";
            this.sTOPToolStripMenuItem2.Size = new System.Drawing.Size(152, 22);
            this.sTOPToolStripMenuItem2.Text = "STOP";
            // 
            // rECOGToolStripMenuItem
            // 
            this.rECOGToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sTARTToolStripMenuItem3,
            this.sTOPToolStripMenuItem3});
            this.rECOGToolStripMenuItem.Name = "rECOGToolStripMenuItem";
            this.rECOGToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.rECOGToolStripMenuItem.Text = "RECOG";
            // 
            // sTARTToolStripMenuItem3
            // 
            this.sTARTToolStripMenuItem3.Name = "sTARTToolStripMenuItem3";
            this.sTARTToolStripMenuItem3.Size = new System.Drawing.Size(152, 22);
            this.sTARTToolStripMenuItem3.Text = "START";
            this.sTARTToolStripMenuItem3.Click += new System.EventHandler(this.sTARTToolStripMenuItem3_Click);
            // 
            // sTOPToolStripMenuItem3
            // 
            this.sTOPToolStripMenuItem3.Name = "sTOPToolStripMenuItem3";
            this.sTOPToolStripMenuItem3.Size = new System.Drawing.Size(152, 22);
            this.sTOPToolStripMenuItem3.Text = "STOP";
            this.sTOPToolStripMenuItem3.Click += new System.EventHandler(this.sTOPToolStripMenuItem3_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fILEToolStripMenuItem,
            this.sESSIONToolStripMenuItem,
            this.lEARNINGToolStripMenuItem,
            this.sERVERToolStripMenuItem,
            this.rECOGToolStripMenuItem,
            this.hELPToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1017, 24);
            this.menuStrip1.TabIndex = 19;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // rANDOMIZEToolStripMenuItem
            // 
            this.rANDOMIZEToolStripMenuItem.Name = "rANDOMIZEToolStripMenuItem";
            this.rANDOMIZEToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.rANDOMIZEToolStripMenuItem.Text = "RANDOMIZE";
            this.rANDOMIZEToolStripMenuItem.Click += new System.EventHandler(this.rANDOMIZEToolStripMenuItem_Click);
            // 
            // lOADTEMPLATEToolStripMenuItem
            // 
            this.lOADTEMPLATEToolStripMenuItem.Name = "lOADTEMPLATEToolStripMenuItem";
            this.lOADTEMPLATEToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.lOADTEMPLATEToolStripMenuItem.Text = "LOAD TEMPLATE";
            this.lOADTEMPLATEToolStripMenuItem.Click += new System.EventHandler(this.lOADTEMPLATEToolStripMenuItem_Click);
            // 
            // cREATEERRORLOGFILEToolStripMenuItem
            // 
            this.cREATEERRORLOGFILEToolStripMenuItem.Name = "cREATEERRORLOGFILEToolStripMenuItem";
            this.cREATEERRORLOGFILEToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.cREATEERRORLOGFILEToolStripMenuItem.Text = "CREATE ERROR LOG FILE";
            this.cREATEERRORLOGFILEToolStripMenuItem.Click += new System.EventHandler(this.cREATEERRORLOGFILEToolStripMenuItem_Click);
            // 
            // aPPENDTOERRORLOGFILEToolStripMenuItem
            // 
            this.aPPENDTOERRORLOGFILEToolStripMenuItem.Name = "aPPENDTOERRORLOGFILEToolStripMenuItem";
            this.aPPENDTOERRORLOGFILEToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.aPPENDTOERRORLOGFILEToolStripMenuItem.Text = "APPEND TO ERROR LOG FILE";
            this.aPPENDTOERRORLOGFILEToolStripMenuItem.Click += new System.EventHandler(this.aPPENDTOERRORLOGFILEToolStripMenuItem_Click);
            // 
            // BackPropogation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1017, 661);
            this.Controls.Add(this.zedGraphControl1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "BackPropogation";
            this.Text = "BackPropogation";
            this.Load += new System.EventHandler(this.BackPropogation_Load);
            this.ResizeBegin += new System.EventHandler(this.BackPropogation_ResizeBegin);
            this.ResizeEnd += new System.EventHandler(this.BackPropogation_ResizeEnd);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorkerTrainer;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.ComponentModel.BackgroundWorker backgroundWorkerSignal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox6;
        private ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.ToolStripMenuItem fILEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eXITToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sESSIONToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sTARTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sTOPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oPENERRORLOGGERToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lEARNINGToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sTARTToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem sTOPToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem hELPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aBOUTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sERVERToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sTARTToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem sTOPToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem rECOGToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sTARTToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem sTOPToolStripMenuItem3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem rANDOMIZEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cREATEERRORLOGFILEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aPPENDTOERRORLOGFILEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lOADTEMPLATEToolStripMenuItem;
    }
}