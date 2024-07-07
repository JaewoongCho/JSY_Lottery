using Microsoft.Data.Sqlite;
using Microsoft.VisualBasic;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Media;
using System.Text;
using WMPLib;

namespace JSY_Lottery
{
    public partial class FrmMain : Form
    {
        private int pX;
        private int pY;
        private int maxPapers;
        private int cols, rows;
        private bool first_draw = true;
        private float defaultFontSize = 12F;
        public SqliteConnection configConn;
        public SqliteConnection benefitConn;
        private ArrayList benefits = new ArrayList();
        private ArrayList openedPaper = new ArrayList();
        private ArrayList closedPaper = new ArrayList();
        private bool isRandomCount = false;

        private Color boardColor = Color.White;
        private Color paperColor = Color.White;
        private Color marqueeColor = Color.Black;
        private Color paperFontColor = Color.Black;
        private Color marqueeFontColor = Color.White;
        private Color listColor = Color.White;
        private Color listFontColor = Color.Black;
        private Color resultColor = Color.White;
        private Color resultFontColor = Color.Black;
        private string marqueeText = "흐름글 테스트 입니다...";
        private int marqueeSpeed = 10;
        private Font paperFont = new Font("맑은 고딕", 10F);
        private Font marqueeFont = new Font("맑은 고딕", 16F);
        private Font listFont = new Font("맑은 고딕", 10F);
        private Font resultFont = new Font("맑은 고딕", 10F);
        private WindowsMediaPlayer wmp = new WindowsMediaPlayer();

        Dictionary<int, ArrayList> dic = new Dictionary<int, ArrayList>();
        Dictionary<string, int> benefitDic = new Dictionary<string, int>();

        private void CheckConfigFile()
        {
            DirectoryInfo dirInfo = new DirectoryInfo(Application.StartupPath + @"resources");

            if(!dirInfo.Exists )
            {
                dirInfo.Create();
            }

            FileInfo configInfo = new FileInfo(Application.StartupPath + @"resources\lottery_config.db");
            FileInfo benefitInfo = new FileInfo(Application.StartupPath + @"resources\lottery_benefit.db");

            if (configInfo.Exists == false)
            {
                MessageBox.Show("Config 파일이 없어 새로 생성합니다.", "프로그램 실행 정보", MessageBoxButtons.OK);
                // DB 생성하고
                File.WriteAllBytes(configInfo.FullName, new byte[0]);
            }

            if (benefitInfo.Exists == false)
            {
                MessageBox.Show("Benefit 파일이 없어 새로 생성합니다.", "프로그램 실행 정보", MessageBoxButtons.OK);
                // DB 생성하고
                File.WriteAllBytes(benefitInfo.FullName, new byte[0]);
            }
        }

        public static bool tableAlreadyExists(SqliteConnection openConnection, string tableName)
        {
            var sql =
            "SELECT name FROM sqlite_master WHERE type='table' AND name='" + tableName + "';";
            if (openConnection.State == System.Data.ConnectionState.Open)
            {
                SqliteCommand command = new SqliteCommand(sql, openConnection);
                SqliteDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Close();
                    return true;
                }
                reader.Close();
            }
            return false;
        }


        private void CheckTables()
        {
            if(!tableAlreadyExists(configConn, "tbConfig"))
            {
                string sql = "CREATE TABLE \"tbConfig\"(\"configName\"  TEXT,\"configValue\"    TEXT)";
                // you could also write sql = "CREATE TABLE IF NOT EXISTS highscores ..."
                SqliteCommand cmd = new SqliteCommand(sql, configConn);
                cmd.ExecuteNonQuery();
            }

            if(!tableAlreadyExists(benefitConn, "tbBenefit"))
            {
                string sql = "CREATE TABLE \"tbBenefit\" (\"seq\"	INTEGER,\"benefit_name\"	TEXT,\"benefit_count\"	INTEGER,\"benefit_desc\"	TEXT, \"benefit_sound\"	TEXT)";
                SqliteCommand cmd = new SqliteCommand(sql, benefitConn);
                cmd.ExecuteNonQuery();
            }
        }

        public FrmMain()
        {
            InitializeComponent();
            pX = this.PnlMarquee.Width;
            pY = (this.PnlMarquee.Height - this.LblMarquee.Font.Height) / 2;

            CheckConfigFile();
            SQLitePCL.raw.SetProvider(new SQLitePCL.SQLite3Provider_e_sqlite3());
            configConn = new SqliteConnection("Data Source=" + Application.StartupPath + @"resources\lottery_config.db");
            configConn.Open();
            benefitConn = new SqliteConnection("Data Source=" + Application.StartupPath + @"resources\lottery_benefit.db");
            benefitConn.Open();

            CheckTables();
        }

        private void drawMarquee()
        {
            this.TmrMarquee.Stop();
            LblMarquee.Text = marqueeText;
            this.LblMarquee.Location = new Point(this.PnlMarquee.Width, pY);
            this.LblMarquee.Font = marqueeFont;
            this.LblMarquee.ForeColor = marqueeFontColor;
            this.PnlMarquee.BackColor = marqueeColor;
            this.TmrMarquee.Interval = marqueeSpeed;
            this.TmrMarquee.Start();
        }

        private void drawBenefit()
        {
            dic.Clear();

            string sql = "SELECT benefit_name, benefit_count, benefit_desc, benefit_sound  FROM tbBenefit ORDER BY seq ASC";
            SqliteCommand cmd = new SqliteCommand(sql, benefitConn);
            SqliteDataReader rdr = cmd.ExecuteReader();
            int rowCount = 0;
            maxPapers = 0;
            benefitDic.Clear();
            while (rdr.Read())
            {
                ArrayList arrayList = new ArrayList()
                {
                    rdr[0], rdr[1], rdr[2], (rdr[3] is DBNull ? "" : rdr[3])
                };
                dic.Add(rowCount++, arrayList);
                maxPapers += Convert.ToInt32(rdr[1]);
                for (int i = 0; i < Convert.ToInt32(rdr[1]); i++)
                {
                    benefits.Add(rdr[0]);
                }
                benefitDic.Add(rdr[0].ToString(), 0);
            }

            int benefitCount = dic.Count;

            DataTable benefitDt = new DataTable();
            benefitDt.Columns.Add("경품명", typeof(string));
            benefitDt.Columns.Add("개수", typeof(string));
            benefitDt.Columns.Add("경품설명", typeof(string));

            foreach (int key in dic.Keys)
            {
                ArrayList lst = dic[key];
                if (lst is not null)
                {
                    // 여기에 한번 다시 추가해보자.
                    DataRow dr = benefitDt.NewRow();
                    dr[0] = lst[0].ToString();
                    dr[1] = lst[1].ToString() + "개";
                    dr[2] = lst[2].ToString();
                    benefitDt.Rows.Add(dr);
                }
            }

            DgvBenefit.DataSource = benefitDt;
            DgvBenefit.DefaultCellStyle.Font = listFont;
            DgvBenefit.DefaultCellStyle.ForeColor = listFontColor;
            DgvBenefit.DefaultCellStyle.BackColor = listColor;
            DgvBenefit.BackgroundColor = listColor;
            DgvBenefit.DefaultCellStyle.SelectionForeColor = listFontColor;
            DgvBenefit.DefaultCellStyle.SelectionBackColor = listColor;
            DgvBenefit.Refresh();
        }

        private void initConfig()
        {
            string sql = "SELECT * FROM tbConfig";
            SqliteCommand cmd = new SqliteCommand(sql, configConn);
            SqliteDataReader rdr = cmd.ExecuteReader();

            string paperFontFamily = "맑은 고딕", marqueeFontFamily = "맑은 고딕", listFontFamily = "맑은 고딕", resultFontFamily = "맑은 고딕";
            float paperFontSize = 10F, marqueeFontSize = 16F, listFontSize = 10F, resultFontSize = 10F;
            bool paperFontBold = false, paperFontItalic = false, paperFontUnderline = false, paperFontStrikeout = false;
            bool marqueeFontBold = false, marqueeFontItalic = false, marqueeFontUnderline = false, marqueeFontStrikeout = false;
            bool listFontBold = false, listFontItalic = false, listFontUnderline = false, listFontStrikeout = false;
            bool resultFontBold = false, resultFontItalic = false, resultFontUnderline = false, resultFontStrikeout = false;

            while (rdr.Read())
            {
                string name = rdr.GetString(0);
                int color = -1;

                switch (name)
                {
                    case "marqueeText":
                        marqueeText = rdr.GetString(1);
                        break;
                    case "marqueeSpeed":
                        marqueeSpeed = rdr.GetInt32(1);
                        break;
                    case "boardColor":
                        color = rdr.GetInt32(1);
                        boardColor = Color.FromArgb(color);
                        TlpLottery.BackColor = boardColor;
                        break;
                    case "paperColor":
                        color = rdr.GetInt32(1);
                        paperColor = Color.FromArgb(color);
                        break;
                    case "paperFontColor":
                        color = rdr.GetInt32(1);
                        paperFontColor = Color.FromArgb(color);
                        break;
                    case "paperFontFamily":
                        paperFontFamily = rdr.GetString(1);
                        break;
                    case "paperFontSize":
                        paperFontSize = rdr.GetFloat(1);
                        break;
                    case "paperFontBold":
                        paperFontBold = rdr.GetBoolean(1);
                        break;
                    case "paperFontItelic":
                        paperFontItalic = rdr.GetBoolean(1);
                        break;
                    case "paperFontUnderline":
                        paperFontUnderline = rdr.GetBoolean(1);
                        break;
                    case "paperFontStrike":
                        paperFontStrikeout = rdr.GetBoolean(1);
                        break;
                    case "marqueeFontColor":
                        color = rdr.GetInt32(1);
                        marqueeFontColor = Color.FromArgb(color);
                        break;
                    case "marqueeFontFamily":
                        marqueeFontFamily = rdr.GetString(1);
                        break;
                    case "marqueeFontSize":
                        marqueeFontSize = rdr.GetFloat(1);
                        break;
                    case "marqueeFontBold":
                        marqueeFontBold = rdr.GetBoolean(1);
                        break;
                    case "marqueeFontItelic":
                        marqueeFontItalic = rdr.GetBoolean(1);
                        break;
                    case "marqueeFontUnderline":
                        marqueeFontUnderline = rdr.GetBoolean(1);
                        break;
                    case "marqueeFontStrike":
                        marqueeFontStrikeout = rdr.GetBoolean(1);
                        break;
                    case "marqueeColor":
                        color = rdr.GetInt32(1);
                        marqueeColor = Color.FromArgb(color);
                        break;
                    // -- 추가분
                    case "listColor":
                        color = rdr.GetInt32(1);
                        listColor = Color.FromArgb(color);
                        break;
                    case "listFontColor":
                        color = rdr.GetInt32(1);
                        listFontColor = Color.FromArgb(color);
                        break;
                    case "listFontFamily":
                        listFontFamily = rdr.GetString(1);
                        break;
                    case "listFontSize":
                        listFontSize = rdr.GetFloat(1);
                        break;
                    case "listFontBold":
                        listFontBold = rdr.GetBoolean(1);
                        break;
                    case "listFontItelic":
                        listFontItalic = rdr.GetBoolean(1);
                        break;
                    case "listFontUnderline":
                        listFontUnderline = rdr.GetBoolean(1);
                        break;
                    case "listFontStrike":
                        listFontStrikeout = rdr.GetBoolean(1);
                        break;
                    case "resultColor":
                        color = rdr.GetInt32(1);
                        resultColor = Color.FromArgb(color);
                        break;
                    case "resultFontColor":
                        color = rdr.GetInt32(1);
                        resultFontColor = Color.FromArgb(color);
                        break;
                    case "resultFontFamily":
                        resultFontFamily = rdr.GetString(1);
                        break;
                    case "resultFontSize":
                        resultFontSize = rdr.GetFloat(1);
                        break;
                    case "resultFontBold":
                        resultFontBold = rdr.GetBoolean(1);
                        break;
                    case "resultFontItelic":
                        resultFontItalic = rdr.GetBoolean(1);
                        break;
                    case "resultFontUnderline":
                        resultFontUnderline = rdr.GetBoolean(1);
                        break;
                    case "resultFontStrike":
                        resultFontStrikeout = rdr.GetBoolean(1);
                        break;
                }
            }

            paperFont = new Font(paperFontFamily, paperFontSize, (paperFontBold ? FontStyle.Bold : FontStyle.Regular) |
                (paperFontItalic ? FontStyle.Italic : FontStyle.Regular) | (paperFontUnderline ? FontStyle.Underline : FontStyle.Regular) |
                (paperFontStrikeout ? FontStyle.Strikeout : FontStyle.Regular));

            marqueeFont = new Font(marqueeFontFamily, marqueeFontSize, (marqueeFontBold ? FontStyle.Bold : FontStyle.Regular) |
                (marqueeFontItalic ? FontStyle.Italic : FontStyle.Regular) | (marqueeFontUnderline ? FontStyle.Underline : FontStyle.Regular) |
                (marqueeFontStrikeout ? FontStyle.Strikeout : FontStyle.Regular));

            listFont = new Font(listFontFamily, listFontSize, (listFontBold ? FontStyle.Bold : FontStyle.Regular) |
                (listFontItalic ? FontStyle.Italic : FontStyle.Regular) | (listFontUnderline ? FontStyle.Underline : FontStyle.Regular) |
                (listFontStrikeout ? FontStyle.Strikeout : FontStyle.Regular));

            resultFont = new Font(resultFontFamily, resultFontSize, (resultFontBold ? FontStyle.Bold : FontStyle.Regular) |
                (resultFontItalic ? FontStyle.Italic : FontStyle.Regular) | (resultFontUnderline ? FontStyle.Underline : FontStyle.Regular) |
                (resultFontStrikeout ? FontStyle.Strikeout : FontStyle.Regular));

            LblMarquee.Font = marqueeFont;
            LblMarquee.ForeColor = marqueeFontColor;

            RtxResult.Font = resultFont;
            RtxResult.ForeColor = resultFontColor;
            RtxResult.BackColor = resultColor;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            // DB에서 설정관련 정보 읽어와서 설정하기
            initConfig();

            // DB에서 일단 등수관련 정보 읽어오기
            drawBenefit();
            drawMarquee();
            DrawPapers();
            InitLotteryLayout();
        }

        private void TmrMarquee_Tick(object sender, EventArgs e)
        {
            if (pX <= (0 - this.LblMarquee.Width))
            {
                this.LblMarquee.Location = new Point(this.PnlMarquee.Width, pY);
                pX = this.PnlMarquee.Width;
            }
            else
            {
                this.LblMarquee.Location = new Point(pX, pY);
                pX -= 2;
            }
        }

        private void InitLotteryLayout()
        {
            foreach (Control obj in TlpLottery.Controls)
            {
                string text = obj.Text;
                var size = default(SizeF);
                obj.Font = new Font(obj.Font.Name, defaultFontSize, FontStyle.Bold);
                do
                {
                    using (var font = new Font(obj.Font.Name, obj.Font.SizeInPoints, FontStyle.Bold))
                    {
                        size = TextRenderer.MeasureText(text, font);

                        if (size.Width <= obj.Width)
                            obj.Text = text;
                        else
                        {
                            obj.Font = new Font(font.Name, font.SizeInPoints - 1f, FontStyle.Bold);
                        }
                    }
                } while (size.Width > obj.Width);
            }

            first_draw = false;
        }

        private void DrawPapers()
        {
            if(this.maxPapers == 0)
            {
                return;
            }

            int temp_cols = Convert.ToInt32(Math.Floor(Math.Sqrt(this.maxPapers)));
            int temp_rows = Convert.ToInt32(Math.Ceiling(this.maxPapers / (double)temp_cols));
            bool add_style = false;

            if (temp_rows != rows || temp_cols != cols)
            {
                // 새로 그려야 하므로 rowstyle과 columnstyle을 초기화
                TlpLottery.RowStyles.Clear();
                TlpLottery.ColumnStyles.Clear();
                add_style = true;
            }
            cols = Convert.ToInt32(Math.Floor(Math.Sqrt(this.maxPapers)));
            rows = Convert.ToInt32(Math.Ceiling(this.maxPapers / (double)cols));

            TlpLottery.RowCount = rows;
            TlpLottery.ColumnCount = cols;

            int countPaper = 0;
            Random rnd = new Random();

            float itemWidth = TlpLottery.Width / (float)cols;
            float itemHeight = TlpLottery.Height / (float)rows;

            closedPaper.Clear();
            openedPaper.Clear();

            for (int row = 0; row <= rows; row++)
            {
                Application.DoEvents();
                if(first_draw || add_style)
                {
                    float rowHeight = TlpLottery.Height / (float)rows / TlpLottery.Height * 100;
                    TlpLottery.RowStyles.Add(new RowStyle(SizeType.Percent, rowHeight));
                }
                for (int col = 0; col < cols; col++)
                {
                    Application.DoEvents();
                    countPaper++;
                    
                    float cellWidth = TlpLottery.Width / (float)cols / TlpLottery.Width * 100;

                    if (countPaper > this.maxPapers)
                    {
                        Label lbl = new Label
                        {
                            Text = ""
                        };
                    }
                    else
                    {
                        string paperName = "Paper" + countPaper;
                        closedPaper.Add(paperName);
                        Button btn = new Button
                        {
                            Name = paperName,
                            Width = TlpLottery.Width / cols,
                            Height = TlpLottery.Height / rows,
                            Text = Convert.ToString(countPaper),
                            Margin = new Padding(2, 2, 2, 2),
                            FlatStyle = FlatStyle.Popup,
                            ForeColor = paperFontColor,
                            BackColor = paperColor,
                            BackgroundImage = Properties.Resources.btn_back,
                            BackgroundImageLayout = ImageLayout.Stretch,
                            Dock = DockStyle.Fill,
                            Font = paperFont,
                            MaximumSize = new Size((int)itemWidth, (int)itemHeight)
                        };
                        btn.FlatAppearance.BorderSize = 0;
                        btn.FlatAppearance.MouseOverBackColor = btn.BackColor;
                        btn.Cursor = Cursors.Hand;

                        // 등수를 뽑고, arrayList를 만들어서 태그에다가 넣기
                        int numb = rnd.Next(benefits.Count);

                        string benefit = benefits[numb].ToString();
                        benefits.RemoveAt(numb);

                        btn.Tag = new ArrayList { benefit, false };
                        btn.Click += Btn_Click;

                        TlpLottery.Controls.Add(btn);
                    }
                    if (first_draw || add_style)
                    {
                        TlpLottery.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, (float)Math.Ceiling(cellWidth)));
                    }
                }
            }

            first_draw = false;
        }

        private void Btn_Click(object? sender, EventArgs e)
        {
            Button? b = (Button?)sender;
            ArrayList benefitValue = b.Tag as ArrayList;

            if (b is not null && !(bool)benefitValue[1])
            {
                // true로 변경하고 tag 업데이트
                benefitValue[1] = true;
                b.Tag = benefitValue;
                string text = benefitValue[0].ToString();
                b.Text = text;
                b.BackColor = Color.Silver;
                var size = default(SizeF);
                do
                {
                    using (var font = new Font(b.Font.Name, b.Font.SizeInPoints, FontStyle.Bold))
                    {
                        size = TextRenderer.MeasureText(text, font);

                        if (size.Width <= b.Width)
                            b.Text = text;
                        else
                        {
                            b.Font = new Font(font.Name, font.SizeInPoints - 1f, FontStyle.Bold);
                        }
                    }
                } while (size.Width > b.Width);

                closedPaper.Remove(b.Name);
                openedPaper.Add(b.Name);

                if (!isRandomCount)
                {
                    // 소리 재생
                    for (int i = 0; i < dic.Count; i++)
                    {
                        if (dic[i][0].ToString() == text)
                        {
                            string soundPath = dic[i][3].ToString();
                            if (soundPath != "")
                            {
                                Debug.WriteLine(soundPath);
                                wmp.URL = soundPath;
                                wmp.controls.play();
                            }
                            break;
                        }
                    }
                    // 결과판에 출력
                    StringBuilder sb = new StringBuilder();
                    sb.Append(text);
                    sb.Append(" (");
                    ArrayList lst = dic.Where(item => item.Value.Contains(text)).Select(value => value.Value).First();
                    sb.Append(lst[2]);
                    sb.Append(")");
                    RtxResult.Text = sb.ToString();
                }
                else
                {
                    if (benefitDic.ContainsKey(text))
                    {
                        benefitDic[text] += 1;
                    }
                    else
                    {
                        benefitDic.Add(text, 1);
                    }
                }
                
                for (int i = 0; i < DgvBenefit.RowCount; i++)
                {
                    if (DgvBenefit.Rows[i].Cells[0].Value.ToString() == text)
                    {
                        int nowCount = int.Parse(DgvBenefit.Rows[i].Cells[1].Value.ToString().Replace("개", ""));
                        DgvBenefit.Rows[i].Cells[1].Value = Convert.ToString(nowCount - 1) + "개";
                    }
                }
            }
        }

        private void FrmMain_Resize(object sender, EventArgs e)
        {
            // 글꼴만 맞춰주기
            if(this.WindowState != FormWindowState.Minimized)
            {
                foreach (Control obj in TlpLottery.Controls)
                {
                    string text = obj.Text;
                    var size = default(SizeF);
                    obj.Font = new Font(obj.Font.Name, defaultFontSize, FontStyle.Bold);
                    do
                    {
                        using (var font = new Font(obj.Font.Name, obj.Font.SizeInPoints, FontStyle.Bold))
                        {
                            size = TextRenderer.MeasureText(text, font);

                            if (size.Width <= obj.Width)
                                obj.Text = text;
                            else
                            {
                                obj.Font = new Font(font.Name, Math.Abs(font.SizeInPoints - 1f), FontStyle.Bold);
                            }
                        }
                    } while (size.Width > obj.Width);
                }
            }
        }

        private void BtnReverse_Click(object sender, EventArgs e)
        {
            if (StrRandom.Text.Trim().Length > 0)
            {
                if(!(int.TryParse(StrRandom.Text.Trim(), out int paperCount))) {
                    MessageBox.Show("입력 내용을 숫자로 바꿀 수 없습니다!", "뒤집기 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (closedPaper.Count < paperCount)
                {
                    MessageBox.Show("남아있는 뽑기가 입력된 개수보다 작습니다.", "뒤집기 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (int.TryParse(StrRandom.Text, out int val))
                {
                    if(val < 1)
                    {
                        MessageBox.Show("뒤집기는 최소 1개 이상이어야합니다.", "뒤집기 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if(MessageBox.Show($"{val}개를 뒤집을까요?", "뒤집기 확인", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return;
                    }
                    // val은 이미 숫자 있음
                    isRandomCount = true;
                    Random rnd = new Random();
                    foreach (string key in benefitDic.Keys)
                    {
                        benefitDic[key] = 0;
                    }

                    int openedCount = 0;
                    while(openedCount < paperCount)
                    {
                        Application.DoEvents();
                        Random paperRnd = new Random();
                        int p = paperRnd.Next(closedPaper.Count);
                        bool isClicked = true;
                        Control[] btn = TlpLottery.Controls.Find(closedPaper[p].ToString(), true);
                        ArrayList lst = btn[0].Tag as ArrayList;

                        if ((bool)lst[1] == false)
                        {
                            ((Button)btn[0]).PerformClick();
                            openedCount++;
                            Thread.Sleep(100);
                        }
                    }

                    isRandomCount = false;
                    RtxResult.Text = "";
                    foreach (string key in benefitDic.Keys)
                    {
                        if (benefitDic[key] != 0)
                        {
                            ArrayList lst = dic.Where(item => item.Value.Contains(key)).Select(value => value.Value).First();
                            RtxResult.AppendText(key + "(" + lst[2] + ") : " + benefitDic[key] + "개\r\n");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("갯수를 제대로 입력하세요", "뽑기 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("갯수를 입력하세요", "뽑기 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnReverseAll_Click(object sender, EventArgs e)
        {
            int paperCount = closedPaper.Count;
            for (int i = paperCount; i > 0; i--)
            {
                Application.DoEvents();
                Random paperRnd = new Random();
                int p = paperRnd.Next(closedPaper.Count);

                Control[] btn = TlpLottery.Controls.Find(closedPaper[p].ToString(), true);
                ((Button)btn[0]).PerformClick();
            }
        }

        private void BtnConfig_Click(object sender, EventArgs e)
        {
            FrmConfig frm = new FrmConfig(ref configConn, ref benefitConn);
            frm.Owner = this;
            frm.ShowDialog();
        }

        private void StrRandom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnReverse.PerformClick();
            }
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("뽑기판을 새로고치시겠습니까?", "새로고침 확인", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                closedPaper.Clear();
                openedPaper.Clear();
                dic.Clear();
                benefits.Clear();
                benefitDic.Clear();
                TlpLottery.Controls.Clear();
                RtxResult.Text = "";

                drawBenefit();
                DrawPapers();
                InitLotteryLayout();
            }
        }

        public void ApplyConfig()
        {
            initConfig();
            drawMarquee();

            if (MessageBox.Show("뽑기판을 새로고치시겠습니까?", "새로고침 확인", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                first_draw = true;

                // 먼저 모든 버튼을 지워보자
                for(int i = TlpLottery.Controls.Count - 1; i >= 0;i--)
                {
                    TlpLottery.Controls[i].Dispose();
                }

                TlpLottery.RowCount = 1;
                TlpLottery.ColumnCount = 1;

                RtxResult.Text = "";
                drawBenefit();
                DrawPapers();
                InitLotteryLayout();
            }
        }
    }
}
