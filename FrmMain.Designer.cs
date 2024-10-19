namespace JSY_Lottery
{
    partial class FrmMain
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            TlpMarquee = new TableLayoutPanel();
            PnlMBack = new Panel();
            PnlMarquee = new Panel();
            LblMarquee = new Label();
            TlpTools = new TableLayoutPanel();
            label3 = new Label();
            panel7 = new Panel();
            BtnReset = new Button();
            BtnConfig = new Button();
            BtnReverseAll = new Button();
            StrRandom = new TextBox();
            BtnReverse = new Button();
            PnlBack = new Panel();
            TlpLottery = new TableLayoutPanel();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel5 = new Panel();
            tableLayoutPanel2 = new TableLayoutPanel();
            panel1 = new Panel();
            panel2 = new Panel();
            label1 = new Label();
            PnlBenefits = new Panel();
            DgvBenefit = new DataGridView();
            panel6 = new Panel();
            tableLayoutPanel3 = new TableLayoutPanel();
            panel3 = new Panel();
            panel4 = new Panel();
            label2 = new Label();
            RtxResult = new RichTextBox();
            TmrMarquee = new System.Windows.Forms.Timer(components);
            ImgList = new ImageList(components);
            TlpMarquee.SuspendLayout();
            PnlMBack.SuspendLayout();
            PnlMarquee.SuspendLayout();
            TlpTools.SuspendLayout();
            panel7.SuspendLayout();
            PnlBack.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel5.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            PnlBenefits.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DgvBenefit).BeginInit();
            panel6.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            SuspendLayout();
            // 
            // TlpMarquee
            // 
            TlpMarquee.ColumnCount = 2;
            TlpMarquee.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80F));
            TlpMarquee.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            TlpMarquee.Controls.Add(PnlMBack, 0, 0);
            TlpMarquee.Controls.Add(TlpTools, 1, 0);
            TlpMarquee.Controls.Add(PnlBack, 0, 1);
            TlpMarquee.Controls.Add(tableLayoutPanel1, 1, 1);
            TlpMarquee.Dock = DockStyle.Fill;
            TlpMarquee.Location = new Point(0, 0);
            TlpMarquee.Name = "TlpMarquee";
            TlpMarquee.RowCount = 2;
            TlpMarquee.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));
            TlpMarquee.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            TlpMarquee.Size = new Size(1384, 921);
            TlpMarquee.TabIndex = 0;
            // 
            // PnlMBack
            // 
            PnlMBack.BackColor = Color.Yellow;
            PnlMBack.Controls.Add(PnlMarquee);
            PnlMBack.Dock = DockStyle.Fill;
            PnlMBack.Location = new Point(0, 0);
            PnlMBack.Margin = new Padding(0);
            PnlMBack.Name = "PnlMBack";
            PnlMBack.Padding = new Padding(5);
            PnlMBack.Size = new Size(1107, 80);
            PnlMBack.TabIndex = 0;
            // 
            // PnlMarquee
            // 
            PnlMarquee.BackColor = Color.Black;
            PnlMarquee.BackgroundImage = Properties.Resources.led;
            PnlMarquee.Controls.Add(LblMarquee);
            PnlMarquee.Dock = DockStyle.Fill;
            PnlMarquee.Location = new Point(5, 5);
            PnlMarquee.Margin = new Padding(0);
            PnlMarquee.Name = "PnlMarquee";
            PnlMarquee.Size = new Size(1097, 70);
            PnlMarquee.TabIndex = 1;
            // 
            // LblMarquee
            // 
            LblMarquee.AutoSize = true;
            LblMarquee.BackColor = Color.Transparent;
            LblMarquee.Font = new Font("맑은 고딕", 18F, FontStyle.Regular, GraphicsUnit.Point);
            LblMarquee.ForeColor = SystemColors.Control;
            LblMarquee.Location = new Point(700, 31);
            LblMarquee.Name = "LblMarquee";
            LblMarquee.Size = new Size(38, 32);
            LblMarquee.TabIndex = 0;
            LblMarquee.Text = "　";
            // 
            // TlpTools
            // 
            TlpTools.ColumnCount = 3;
            TlpTools.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            TlpTools.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            TlpTools.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 23F));
            TlpTools.Controls.Add(label3, 0, 1);
            TlpTools.Controls.Add(panel7, 0, 2);
            TlpTools.Controls.Add(StrRandom, 1, 1);
            TlpTools.Controls.Add(BtnReverse, 2, 1);
            TlpTools.Dock = DockStyle.Fill;
            TlpTools.Location = new Point(1107, 0);
            TlpTools.Margin = new Padding(0);
            TlpTools.Name = "TlpTools";
            TlpTools.RowCount = 3;
            TlpTools.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            TlpTools.RowStyles.Add(new RowStyle(SizeType.Absolute, 23F));
            TlpTools.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            TlpTools.Size = new Size(277, 80);
            TlpTools.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Fill;
            label3.Location = new Point(3, 27);
            label3.Name = "label3";
            label3.Size = new Size(94, 23);
            label3.TabIndex = 0;
            label3.Text = "랜덤갯수 입력 :";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel7
            // 
            TlpTools.SetColumnSpan(panel7, 3);
            panel7.Controls.Add(BtnReset);
            panel7.Controls.Add(BtnConfig);
            panel7.Controls.Add(BtnReverseAll);
            panel7.Dock = DockStyle.Fill;
            panel7.Location = new Point(0, 50);
            panel7.Margin = new Padding(0);
            panel7.Name = "panel7";
            panel7.Size = new Size(277, 30);
            panel7.TabIndex = 1;
            // 
            // BtnReset
            // 
            BtnReset.BackgroundImage = Properties.Resources.vector_grid;
            BtnReset.BackgroundImageLayout = ImageLayout.Stretch;
            BtnReset.Location = new Point(32, 3);
            BtnReset.Name = "BtnReset";
            BtnReset.Size = new Size(23, 23);
            BtnReset.TabIndex = 2;
            BtnReset.UseVisualStyleBackColor = true;
            BtnReset.Click += BtnReset_Click;
            // 
            // BtnConfig
            // 
            BtnConfig.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BtnConfig.BackgroundImage = Properties.Resources.system;
            BtnConfig.BackgroundImageLayout = ImageLayout.Stretch;
            BtnConfig.Location = new Point(254, 2);
            BtnConfig.Name = "BtnConfig";
            BtnConfig.Size = new Size(23, 23);
            BtnConfig.TabIndex = 1;
            BtnConfig.UseVisualStyleBackColor = true;
            BtnConfig.Click += BtnConfig_Click;
            // 
            // BtnReverseAll
            // 
            BtnReverseAll.BackgroundImage = Properties.Resources.mActionReload;
            BtnReverseAll.BackgroundImageLayout = ImageLayout.Stretch;
            BtnReverseAll.Location = new Point(3, 2);
            BtnReverseAll.Name = "BtnReverseAll";
            BtnReverseAll.Size = new Size(23, 23);
            BtnReverseAll.TabIndex = 0;
            BtnReverseAll.UseVisualStyleBackColor = true;
            BtnReverseAll.Click += BtnReverseAll_Click;
            // 
            // StrRandom
            // 
            StrRandom.Dock = DockStyle.Fill;
            StrRandom.Location = new Point(100, 27);
            StrRandom.Margin = new Padding(0);
            StrRandom.Name = "StrRandom";
            StrRandom.Size = new Size(154, 23);
            StrRandom.TabIndex = 2;
            StrRandom.KeyDown += StrRandom_KeyDown;
            // 
            // BtnReverse
            // 
            BtnReverse.BackgroundImage = Properties.Resources.mActionRefresh;
            BtnReverse.BackgroundImageLayout = ImageLayout.Stretch;
            BtnReverse.Location = new Point(254, 27);
            BtnReverse.Margin = new Padding(0);
            BtnReverse.Name = "BtnReverse";
            BtnReverse.Size = new Size(23, 23);
            BtnReverse.TabIndex = 3;
            BtnReverse.UseVisualStyleBackColor = true;
            BtnReverse.Click += BtnReverse_Click;
            // 
            // PnlBack
            // 
            PnlBack.BackColor = Color.SaddleBrown;
            PnlBack.BackgroundImage = Properties.Resources.wood;
            PnlBack.BackgroundImageLayout = ImageLayout.Stretch;
            PnlBack.Controls.Add(TlpLottery);
            PnlBack.Dock = DockStyle.Fill;
            PnlBack.Location = new Point(0, 80);
            PnlBack.Margin = new Padding(0);
            PnlBack.Name = "PnlBack";
            PnlBack.Padding = new Padding(10);
            PnlBack.Size = new Size(1107, 841);
            PnlBack.TabIndex = 3;
            // 
            // TlpLottery
            // 
            TlpLottery.BackColor = Color.DarkGreen;
            TlpLottery.BackgroundImageLayout = ImageLayout.None;
            TlpLottery.ColumnCount = 1;
            TlpLottery.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            TlpLottery.Dock = DockStyle.Fill;
            TlpLottery.Location = new Point(10, 10);
            TlpLottery.Margin = new Padding(0);
            TlpLottery.Name = "TlpLottery";
            TlpLottery.RowCount = 1;
            TlpLottery.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            TlpLottery.Size = new Size(1087, 821);
            TlpLottery.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(panel5, 0, 0);
            tableLayoutPanel1.Controls.Add(PnlBenefits, 0, 1);
            tableLayoutPanel1.Controls.Add(panel6, 0, 2);
            tableLayoutPanel1.Controls.Add(RtxResult, 0, 3);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(1107, 80);
            tableLayoutPanel1.Margin = new Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 58F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 58F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(277, 841);
            tableLayoutPanel1.TabIndex = 4;
            // 
            // panel5
            // 
            panel5.Controls.Add(tableLayoutPanel2);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(0, 0);
            panel5.Margin = new Padding(0);
            panel5.Name = "panel5";
            panel5.Padding = new Padding(5);
            panel5.Size = new Size(277, 58);
            panel5.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.BackColor = Color.Silver;
            tableLayoutPanel2.ColumnCount = 3;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 48F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 48F));
            tableLayoutPanel2.Controls.Add(panel1, 0, 0);
            tableLayoutPanel2.Controls.Add(panel2, 2, 0);
            tableLayoutPanel2.Controls.Add(label1, 1, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(5, 5);
            tableLayoutPanel2.Margin = new Padding(0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(267, 48);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.BackgroundImage = Properties.Resources.pray;
            panel1.BackgroundImageLayout = ImageLayout.Stretch;
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(0);
            panel1.Name = "panel1";
            panel1.Size = new Size(48, 48);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.BackgroundImage = Properties.Resources.luck;
            panel2.BackgroundImageLayout = ImageLayout.Stretch;
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(219, 0);
            panel2.Margin = new Padding(0);
            panel2.Name = "panel2";
            panel2.Size = new Size(48, 48);
            panel2.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("맑은 고딕", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(51, 0);
            label1.Name = "label1";
            label1.Size = new Size(165, 48);
            label1.TabIndex = 2;
            label1.Text = "경품목록";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // PnlBenefits
            // 
            PnlBenefits.AutoScroll = true;
            PnlBenefits.Controls.Add(DgvBenefit);
            PnlBenefits.Dock = DockStyle.Fill;
            PnlBenefits.Location = new Point(3, 61);
            PnlBenefits.Name = "PnlBenefits";
            PnlBenefits.Size = new Size(271, 356);
            PnlBenefits.TabIndex = 2;
            // 
            // DgvBenefit
            // 
            DgvBenefit.AllowUserToAddRows = false;
            DgvBenefit.BackgroundColor = SystemColors.Control;
            DgvBenefit.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvBenefit.ColumnHeadersVisible = false;
            DgvBenefit.Dock = DockStyle.Fill;
            DgvBenefit.EditMode = DataGridViewEditMode.EditProgrammatically;
            DgvBenefit.Location = new Point(0, 0);
            DgvBenefit.Margin = new Padding(0);
            DgvBenefit.Name = "DgvBenefit";
            DgvBenefit.ReadOnly = true;
            DgvBenefit.RowHeadersVisible = false;
            DgvBenefit.RowTemplate.Height = 25;
            DgvBenefit.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvBenefit.Size = new Size(271, 356);
            DgvBenefit.TabIndex = 1;
            // 
            // panel6
            // 
            panel6.Controls.Add(tableLayoutPanel3);
            panel6.Dock = DockStyle.Fill;
            panel6.Location = new Point(0, 420);
            panel6.Margin = new Padding(0);
            panel6.Name = "panel6";
            panel6.Padding = new Padding(5);
            panel6.Size = new Size(277, 58);
            panel6.TabIndex = 3;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.BackColor = Color.LightGray;
            tableLayoutPanel3.ColumnCount = 3;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 48F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 48F));
            tableLayoutPanel3.Controls.Add(panel3, 0, 0);
            tableLayoutPanel3.Controls.Add(panel4, 2, 0);
            tableLayoutPanel3.Controls.Add(label2, 1, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(5, 5);
            tableLayoutPanel3.Margin = new Padding(0);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Size = new Size(267, 48);
            tableLayoutPanel3.TabIndex = 1;
            // 
            // panel3
            // 
            panel3.BackgroundImage = Properties.Resources.pray;
            panel3.BackgroundImageLayout = ImageLayout.Stretch;
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 0);
            panel3.Margin = new Padding(0);
            panel3.Name = "panel3";
            panel3.Size = new Size(48, 48);
            panel3.TabIndex = 0;
            // 
            // panel4
            // 
            panel4.BackgroundImage = Properties.Resources.luck;
            panel4.BackgroundImageLayout = ImageLayout.Stretch;
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(219, 0);
            panel4.Margin = new Padding(0);
            panel4.Name = "panel4";
            panel4.Size = new Size(48, 48);
            panel4.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("맑은 고딕", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(51, 0);
            label2.Name = "label2";
            label2.Size = new Size(165, 48);
            label2.TabIndex = 2;
            label2.Text = "당첨결과";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // RtxResult
            // 
            RtxResult.BorderStyle = BorderStyle.None;
            RtxResult.Dock = DockStyle.Fill;
            RtxResult.Location = new Point(8, 486);
            RtxResult.Margin = new Padding(8);
            RtxResult.Name = "RtxResult";
            RtxResult.ReadOnly = true;
            RtxResult.Size = new Size(261, 347);
            RtxResult.TabIndex = 4;
            RtxResult.Text = "";
            RtxResult.WordWrap = false;
            // 
            // TmrMarquee
            // 
            TmrMarquee.Interval = 10;
            TmrMarquee.Tick += TmrMarquee_Tick;
            // 
            // ImgList
            // 
            ImgList.ColorDepth = ColorDepth.Depth8Bit;
            ImgList.ImageSize = new Size(16, 16);
            ImgList.TransparentColor = Color.Transparent;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1384, 921);
            Controls.Add(TlpMarquee);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(1400, 960);
            Name = "FrmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "JSY Lottery";
            Load += FrmMain_Load;
            Resize += FrmMain_Resize;
            TlpMarquee.ResumeLayout(false);
            PnlMBack.ResumeLayout(false);
            PnlMarquee.ResumeLayout(false);
            PnlMarquee.PerformLayout();
            TlpTools.ResumeLayout(false);
            TlpTools.PerformLayout();
            panel7.ResumeLayout(false);
            PnlBack.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            panel5.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            PnlBenefits.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DgvBenefit).EndInit();
            panel6.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel TlpMarquee;
        private Panel PnlMarquee;
        private TableLayoutPanel TlpTools;
        private Panel PnlBack;
        private TableLayoutPanel TlpLottery;
        private Label LblMarquee;
        private System.Windows.Forms.Timer TmrMarquee;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel3;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Label label1;
        private Label label2;
        private ImageList ImgList;
        private Panel PnlBenefits;
        private Panel PnlMBack;
        private Panel panel5;
        private Panel panel6;
        private RichTextBox RtxResult;
        private Label label3;
        private Panel panel7;
        private TextBox StrRandom;
        private Button BtnReverse;
        private Button BtnReverseAll;
        private Button BtnConfig;
        private Button BtnReset;
        private DataGridView DgvBenefit;
    }
}
