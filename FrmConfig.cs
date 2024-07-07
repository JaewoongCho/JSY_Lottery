using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JSY_Lottery
{
    public partial class FrmConfig : Form
    {
        private SqliteConnection _configConn;
        private SqliteConnection _benefitConn;
        public FrmConfig(ref SqliteConnection configConn, ref SqliteConnection benefitConnection)
        {
            InitializeComponent();
            _configConn = configConn;
            _benefitConn = benefitConnection;
        }

        private void FrmConfig_Load(object sender, EventArgs e)
        {
            // DataGridView 초기화
            DgvBenefit.Rows.Clear();
            DgvBenefit.Columns.Clear();
            DgvBenefit.Columns.Add("col1", "순번");
            DgvBenefit.Columns.Add("col2", "등수");
            DgvBenefit.Columns.Add("col3", "개수");
            DgvBenefit.Columns.Add("col4", "설명");
            DgvBenefit.Columns.Add("col5", "소리파일");
            // Config대로 일단 데이터 넣기
            loadConfig();
            loadBenefit();
        }

        private void loadConfig()
        {
            string sql = "SELECT * FROM tbConfig";
            SqliteCommand cmd = new SqliteCommand(sql, _configConn);
            SqliteDataReader rdr = cmd.ExecuteReader();

            string paperFontFamily = "맑은 고딕", marqueeFontFamily = "맑은 고딕", listFontFamily = "맑은 고딕", resultFontFamily = "맑은 고딕";
            float paperFontSize = 10F, marqueeFontSize = 16F, listFontSize = 10F, resultFontSize = 10F;
            bool paperFontBold = false, paperFontItalic = false, paperFontUnderline = false, paperFontStrikeout = false;
            bool marqueeFontBold = false, marqueeFontItalic = false, marqueeFontUnderline = false, marqueeFontStrikeout = false;
            bool listFontBold = false, listFontItalic = false, listFontUnderline = false, listFontStrikeout = false;
            bool resultFontBold = false, resultFontItalic = false, resultFontUnderline = false, resultFontStrikeout = false;
            Color boardColor = Color.White, paperColor = Color.White, marqueeColor = Color.Black,
                paperFontColor = Color.Black, marqueeFontColor = Color.White, listFontColor = Color.Black, listColor = Color.White,
                resultFontColor = Color.Black, resultColor = Color.White;

            while (rdr.Read())
            {
                string name = rdr.GetString(0);
                int color = -1;

                switch (name)
                {
                    case "marqueeText":
                        TxtMarquee.Text = rdr.GetString(1);
                        break;
                    case "marqueeSpeed":
                        TxtMSpeed.Text = rdr.GetInt32(1).ToString();
                        if(TxtMSpeed.Text == "")
                        {
                            TxtMSpeed.Text = "10";
                        }
                        break;
                    case "boardColor":
                        color = rdr.GetInt32(1);
                        boardColor = Color.FromArgb(color);
                        ClgBoard.Color = boardColor;
                        BtnBColor.BackColor = boardColor;
                        break;
                    case "paperColor":
                        color = rdr.GetInt32(1);
                        paperColor = Color.FromArgb(color);
                        ClgPaper.Color = paperColor;
                        BtnPColor.BackColor = paperColor;
                        break;
                    case "marqueeColor":
                        color = rdr.GetInt32(1);
                        marqueeColor = Color.FromArgb(color);
                        ClgMarquee.Color = marqueeColor;
                        BtnMColor.BackColor = marqueeColor;
                        break;
                    case "paperFontColor":
                        color = rdr.GetInt32(1);
                        paperFontColor = Color.FromArgb(color);
                        ClgPFont.Color = paperFontColor;
                        BtnPFont.BackColor = paperFontColor;
                        break;
                    case "paperFontFamily":
                        paperFontFamily = rdr.GetString(1);
                        break;
                    case "paperFontSize":
                        paperFontSize = rdr.GetFloat(1);
                        break;
                    case "paperFontBold":
                        paperFontBold = rdr.GetString(1) == "True" ? true : false;
                        break;
                    case "paperFontItelic":
                        paperFontItalic = rdr.GetString(1) == "True" ? true : false;
                        break;
                    case "paperFontUnderline":
                        paperFontUnderline = rdr.GetString(1) == "True" ? true : false;
                        break;
                    case "paperFontStrike":
                        paperFontStrikeout = rdr.GetString(1) == "True" ? true : false;
                        break;
                    case "marqueeFontColor":
                        color = rdr.GetInt32(1);
                        marqueeFontColor = Color.FromArgb(color);
                        ClgMFont.Color = marqueeFontColor;
                        BtnMFont.BackColor = marqueeFontColor;
                        break;
                    case "marqueeFontFamily":
                        marqueeFontFamily = rdr.GetString(1);
                        break;
                    case "marqueeFontSize":
                        marqueeFontSize = rdr.GetFloat(1);
                        break;
                    case "marqueeFontBold":
                        marqueeFontBold = rdr.GetString(1) == "True" ? true : false;
                        break;
                    case "marqueeFontItelic":
                        marqueeFontItalic = rdr.GetString(1) == "True" ? true : false;
                        break;
                    case "marqueeFontUnderline":
                        marqueeFontUnderline = rdr.GetString(1) == "True" ? true : false;
                        break;
                    case "marqueeFontStrike":
                        marqueeFontStrikeout = rdr.GetString(1) == "True" ? true : false;
                        break;
                    // -- 추가분
                    case "listFontColor":
                        color = rdr.GetInt32(1);
                        listFontColor = Color.FromArgb(color);
                        ClgLFont.Color = listFontColor;
                        BtnLFont.BackColor = listFontColor;
                        break;
                    case "listFontFamily":
                        listFontFamily = rdr.GetString(1);
                        break;
                    case "listFontSize":
                        listFontSize = rdr.GetFloat(1);
                        break;
                    case "listFontBold":
                        listFontBold = rdr.GetString(1) == "True" ? true : false;
                        break;
                    case "listFontItelic":
                        listFontItalic = rdr.GetString(1) == "True" ? true : false;
                        break;
                    case "listFontUnderline":
                        listFontUnderline = rdr.GetString(1) == "True" ? true : false;
                        break;
                    case "listFontStrike":
                        listFontStrikeout = rdr.GetString(1) == "True" ? true : false;
                        break;
                    case "listColor":
                        color = rdr.GetInt32(1);
                        listColor = Color.FromArgb(color);
                        ClgList.Color = listColor;
                        BtnLColor.BackColor = listColor;
                        break;
                    case "resultFontColor":
                        color = rdr.GetInt32(1);
                        resultFontColor = Color.FromArgb(color);
                        ClgRFont.Color = resultFontColor;
                        BtnRFont.BackColor = resultFontColor;
                        break;
                    case "resultFontFamily":
                        resultFontFamily = rdr.GetString(1);
                        break;
                    case "resultFontSize":
                        resultFontSize = rdr.GetFloat(1);
                        break;
                    case "resultFontBold":
                        resultFontBold = rdr.GetString(1) == "True" ? true : false;
                        break;
                    case "resultFontItelic":
                        resultFontItalic = rdr.GetString(1) == "True" ? true : false;
                        break;
                    case "resultFontUnderline":
                        resultFontUnderline = rdr.GetString(1) == "True" ? true : false;
                        break;
                    case "resultFontStrike":
                        resultFontStrikeout = rdr.GetString(1) == "True" ? true : false;
                        break;
                    case "resultColor":
                        color = rdr.GetInt32(1);
                        resultColor = Color.FromArgb(color);
                        ClgResult.Color = resultColor;
                        BtnRColor.BackColor = resultColor;
                        break;
                }
            }

            Font paperFont = new Font(paperFontFamily, paperFontSize, (paperFontBold ? FontStyle.Bold : FontStyle.Regular) |
                (paperFontItalic ? FontStyle.Italic : FontStyle.Regular) | (paperFontUnderline ? FontStyle.Underline : FontStyle.Regular) |
                (paperFontStrikeout ? FontStyle.Strikeout : FontStyle.Regular));
            Font txtFont = new Font(paperFont.FontFamily, 9F, paperFont.Style);
            TxtPFont.Font = txtFont;
            FlgPaper.Font = paperFont;

            Font marqueeFont = new Font(marqueeFontFamily, marqueeFontSize, (marqueeFontBold ? FontStyle.Bold : FontStyle.Regular) |
                (marqueeFontItalic ? FontStyle.Italic : FontStyle.Regular) | (marqueeFontUnderline ? FontStyle.Underline : FontStyle.Regular) |
                (marqueeFontStrikeout ? FontStyle.Strikeout : FontStyle.Regular));
            txtFont = new Font(marqueeFont.FontFamily, 9F, marqueeFont.Style);
            TxtMFont.Font = txtFont;
            FlgMarquee.Font = marqueeFont;

            Font listFont = new Font(listFontFamily, listFontSize, (listFontBold ? FontStyle.Bold : FontStyle.Regular) |
                (listFontItalic ? FontStyle.Italic : FontStyle.Regular) | (listFontUnderline ? FontStyle.Underline : FontStyle.Regular) |
                (listFontStrikeout ? FontStyle.Strikeout : FontStyle.Regular));
            txtFont = new Font(listFont.FontFamily, 9F, marqueeFont.Style);
            TxtLFont.Font = txtFont;
            FlgList.Font = listFont;

            Font resultFont = new Font(marqueeFontFamily, marqueeFontSize, (marqueeFontBold ? FontStyle.Bold : FontStyle.Regular) |
                (marqueeFontItalic ? FontStyle.Italic : FontStyle.Regular) | (marqueeFontUnderline ? FontStyle.Underline : FontStyle.Regular) |
                (marqueeFontStrikeout ? FontStyle.Strikeout : FontStyle.Regular));
            txtFont = new Font(resultFont.FontFamily, 9F, resultFont.Style);
            TxtRFont.Font = txtFont;
            FlgResult.Font = resultFont;
        }

        private void loadBenefit()
        {
            string sql = "SELECT * FROM tbBenefit";
            SqliteCommand cmd = new SqliteCommand(sql, _benefitConn);
            SqliteDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                int nRow = DgvBenefit.Rows.Add(rdr.GetInt32(0), rdr.GetString(1), rdr.GetInt32(2), rdr.GetString(3), null);
                string soundFile = rdr[4] is System.DBNull ? "" : rdr.GetString(4);

                DataGridViewComboBoxCell cCell = new DataGridViewComboBoxCell
                {
                    DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox
                };

                cCell.Items.Add("");
                DirectoryInfo soundDir = new DirectoryInfo(Application.StartupPath + @"sound");
                foreach (FileInfo file in soundDir.GetFiles())
                {
                    cCell.Items.Add(file.Name);
                }
                if (soundFile != "")
                {
                    cCell.Value = (new FileInfo(soundFile)).Name;
                }
                DgvBenefit.Rows[nRow].Cells[4] = cCell;
            }
        }

        private void TxtPFont_Click(object sender, EventArgs e)
        {
            if (FlgPaper.ShowDialog(this) == DialogResult.OK)
            {
                Font txtFont = new Font(FlgPaper.Font.FontFamily, 9F, FlgPaper.Font.Style);
                TxtPFont.Font = txtFont;
            }
        }

        private void BtnPColor_Click(object sender, EventArgs e)
        {
            if (ClgPaper.ShowDialog(this) == DialogResult.OK)
            {
                BtnPColor.BackColor = ClgPaper.Color;
            }
        }

        private void BtnBColor_Click(object sender, EventArgs e)
        {
            if (ClgBoard.ShowDialog(this) == DialogResult.OK)
            {
                BtnBColor.BackColor = ClgBoard.Color;
            }
        }

        private void TxtMFont_Click(object sender, EventArgs e)
        {
            if (FlgMarquee.ShowDialog(this) == DialogResult.OK)
            {
                Font txtFont = new Font(FlgMarquee.Font.FontFamily, 9F, FlgMarquee.Font.Style);
                TxtMFont.Font = txtFont;
            }
        }

        private void BtnMColor_Click(object sender, EventArgs e)
        {
            if (ClgMarquee.ShowDialog() == DialogResult.OK)
            {
                BtnMColor.BackColor = ClgMarquee.Color;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("변경하신 내용을 적용하시겠습니까?", "환경설정 적용확인", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // 일단 디비에 저장하고
                // 설정부분
                // 기존거 삭제
                string sql = "DELETE FROM tbConfig";
                SqliteCommand cmd = new SqliteCommand(sql, _configConn);
                cmd.ExecuteNonQuery();

                Font paperFont = FlgPaper.Font;
                Font marqueeFont = FlgMarquee.Font;
                Font listFont = FlgList.Font;
                Font resultFont = FlgResult.Font;

                sql = "INSERT INTO tbConfig(configValue, configName) VALUES(@param1, @param2)";
                cmd = new SqliteCommand(sql, _configConn);

                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqliteParameter("@param1", ClgPFont.Color.ToArgb().ToString()));
                cmd.Parameters.Add(new SqliteParameter("@param2", "paperFontColor"));
                cmd.ExecuteNonQuery();

                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqliteParameter("@param1", paperFont.FontFamily.Name));
                cmd.Parameters.Add(new SqliteParameter("@param2", "paperFontFamily"));
                cmd.ExecuteNonQuery();

                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqliteParameter("@param1", paperFont.Size.ToString()));
                cmd.Parameters.Add(new SqliteParameter("@param2", "paperFontSize"));
                cmd.ExecuteNonQuery();

                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqliteParameter("@param1", paperFont.Bold.ToString()));
                cmd.Parameters.Add(new SqliteParameter("@param2", "paperFontBold"));
                cmd.ExecuteNonQuery();

                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqliteParameter("@param1", paperFont.Italic.ToString()));
                cmd.Parameters.Add(new SqliteParameter("@param2", "paperFontItelic"));
                cmd.ExecuteNonQuery();

                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqliteParameter("@param1", paperFont.Underline.ToString()));
                cmd.Parameters.Add(new SqliteParameter("@param2", "paperFontUnderline"));
                cmd.ExecuteNonQuery();

                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqliteParameter("@param1", paperFont.Strikeout.ToString()));
                cmd.Parameters.Add(new SqliteParameter("@param2", "paperFontStrike"));
                cmd.ExecuteNonQuery();

                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqliteParameter("@param1", ClgPaper.Color.ToArgb().ToString()));
                cmd.Parameters.Add(new SqliteParameter("@param2", "paperColor"));
                cmd.ExecuteNonQuery();

                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqliteParameter("@param1", ClgBoard.Color.ToArgb().ToString()));
                cmd.Parameters.Add(new SqliteParameter("@param2", "boardColor"));
                cmd.ExecuteNonQuery();

                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqliteParameter("@param1", TxtMarquee.Text));
                cmd.Parameters.Add(new SqliteParameter("@param2", "marqueeText"));
                cmd.ExecuteNonQuery();

                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqliteParameter("@param1", ClgMFont.Color.ToArgb().ToString()));
                cmd.Parameters.Add(new SqliteParameter("@param2", "marqueeFontColor"));
                cmd.ExecuteNonQuery();

                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqliteParameter("@param1", marqueeFont.FontFamily.Name));
                cmd.Parameters.Add(new SqliteParameter("@param2", "marqueeFontFamily"));
                cmd.ExecuteNonQuery();

                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqliteParameter("@param1", marqueeFont.Size.ToString()));
                cmd.Parameters.Add(new SqliteParameter("@param2", "marqueeFontSize"));
                cmd.ExecuteNonQuery();

                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqliteParameter("@param1", marqueeFont.Bold.ToString()));
                cmd.Parameters.Add(new SqliteParameter("@param2", "marqueeFontFontBold"));
                cmd.ExecuteNonQuery();

                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqliteParameter("@param1", marqueeFont.Italic.ToString()));
                cmd.Parameters.Add(new SqliteParameter("@param2", "marqueeFontFontItelic"));
                cmd.ExecuteNonQuery();

                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqliteParameter("@param1", marqueeFont.Underline.ToString()));
                cmd.Parameters.Add(new SqliteParameter("@param2", "marqueeFontFontUnderline"));
                cmd.ExecuteNonQuery();

                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqliteParameter("@param1", marqueeFont.Strikeout.ToString()));
                cmd.Parameters.Add(new SqliteParameter("@param2", "marqueeFontFontStrike"));
                cmd.ExecuteNonQuery();

                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqliteParameter("@param1", ClgMarquee.Color.ToArgb().ToString()));
                cmd.Parameters.Add(new SqliteParameter("@param2", "marqueeColor"));
                cmd.ExecuteNonQuery();

                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqliteParameter("@param1", TxtMSpeed.Text));
                cmd.Parameters.Add(new SqliteParameter("@param2", "marqueeSpeed"));
                cmd.ExecuteNonQuery();

                //
                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqliteParameter("@param1", ClgLFont.Color.ToArgb().ToString()));
                cmd.Parameters.Add(new SqliteParameter("@param2", "listFontColor"));
                cmd.ExecuteNonQuery();

                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqliteParameter("@param1", listFont.FontFamily.Name));
                cmd.Parameters.Add(new SqliteParameter("@param2", "listFontFamily"));
                cmd.ExecuteNonQuery();

                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqliteParameter("@param1", listFont.Size.ToString()));
                cmd.Parameters.Add(new SqliteParameter("@param2", "listFontSize"));
                cmd.ExecuteNonQuery();

                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqliteParameter("@param1", listFont.Bold.ToString()));
                cmd.Parameters.Add(new SqliteParameter("@param2", "listFontBold"));
                cmd.ExecuteNonQuery();

                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqliteParameter("@param1", listFont.Italic.ToString()));
                cmd.Parameters.Add(new SqliteParameter("@param2", "listFontItelic"));
                cmd.ExecuteNonQuery();

                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqliteParameter("@param1", listFont.Underline.ToString()));
                cmd.Parameters.Add(new SqliteParameter("@param2", "listFontUnderline"));
                cmd.ExecuteNonQuery();

                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqliteParameter("@param1", listFont.Strikeout.ToString()));
                cmd.Parameters.Add(new SqliteParameter("@param2", "listFontStrike"));
                cmd.ExecuteNonQuery();

                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqliteParameter("@param1", ClgList.Color.ToArgb().ToString()));
                cmd.Parameters.Add(new SqliteParameter("@param2", "listColor"));
                cmd.ExecuteNonQuery();

                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqliteParameter("@param1", ClgRFont.Color.ToArgb().ToString()));
                cmd.Parameters.Add(new SqliteParameter("@param2", "resultFontColor"));
                cmd.ExecuteNonQuery();

                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqliteParameter("@param1", resultFont.FontFamily.Name));
                cmd.Parameters.Add(new SqliteParameter("@param2", "resultFontFamily"));
                cmd.ExecuteNonQuery();

                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqliteParameter("@param1", resultFont.Size.ToString()));
                cmd.Parameters.Add(new SqliteParameter("@param2", "resultFontSize"));
                cmd.ExecuteNonQuery();

                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqliteParameter("@param1", resultFont.Bold.ToString()));
                cmd.Parameters.Add(new SqliteParameter("@param2", "resultFontBold"));
                cmd.ExecuteNonQuery();

                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqliteParameter("@param1", resultFont.Italic.ToString()));
                cmd.Parameters.Add(new SqliteParameter("@param2", "resultFontItelic"));
                cmd.ExecuteNonQuery();

                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqliteParameter("@param1", resultFont.Underline.ToString()));
                cmd.Parameters.Add(new SqliteParameter("@param2", "resultFontUnderline"));
                cmd.ExecuteNonQuery();

                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqliteParameter("@param1", resultFont.Strikeout.ToString()));
                cmd.Parameters.Add(new SqliteParameter("@param2", "resultFontStrike"));
                cmd.ExecuteNonQuery();

                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqliteParameter("@param1", ClgResult.Color.ToArgb().ToString()));
                cmd.Parameters.Add(new SqliteParameter("@param2", "resultColor"));
                cmd.ExecuteNonQuery();

                // 상부분
                // 모두 지우고
                sql = "DELETE FROM tbBenefit";
                cmd = new SqliteCommand(sql, _benefitConn);
                cmd.ExecuteNonQuery();

                for (int row = 0; row < DgvBenefit.Rows.Count; row++)
                {
                    if (row == DgvBenefit.NewRowIndex)
                    {
                        continue;
                    }
                    string insertSql = "INSERT INTO tbBenefit(seq, benefit_name, benefit_count, benefit_desc, benefit_sound) VALUES(@p1, @p2, @p3, @p4, @p5)";

                    cmd = new SqliteCommand(insertSql, _benefitConn);
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new SqliteParameter("@p1", DgvBenefit.Rows[row].Cells[0].Value));
                    cmd.Parameters.Add(new SqliteParameter("@p2", DgvBenefit.Rows[row].Cells[1].Value));
                    cmd.Parameters.Add(new SqliteParameter("@p3", DgvBenefit.Rows[row].Cells[2].Value));
                    cmd.Parameters.Add(new SqliteParameter("@p4", DgvBenefit.Rows[row].Cells[3].Value));

                    try
                    {
                        DataGridViewComboBoxCell cb = (DataGridViewComboBoxCell)DgvBenefit.Rows[row].Cells[4];
                        string soundFile = cb.Value is null ? "" : cb.Value.ToString();

                        if (soundFile != "")
                        {
                            string soundPath = Application.StartupPath + @"sound\" + soundFile;
                            cmd.Parameters.Add(new SqliteParameter("@p5", soundPath));
                        }
                        else
                        {
                            cmd.Parameters.Add(new SqliteParameter("@p5", ""));
                        }
                    }
                    catch(Exception ex)
                    {
                        cmd.Parameters.Add(new SqliteParameter("@p5", ""));
                    }
                    int res = cmd.ExecuteNonQuery();
                }

                // 메인의 어플라이 부르고
                ((FrmMain)Owner).ApplyConfig();

                // 창닫기
                Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("변경하신 내용이 취소됩니다. 정말 취소하시겠습니까?", "환경설정 취소확인", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void BtnPFont_Click(object sender, EventArgs e)
        {
            if (ClgPFont.ShowDialog() == DialogResult.OK)
            {
                BtnPFont.BackColor = ClgPFont.Color;
            }
        }

        private void BtnMFont_Click(object sender, EventArgs e)
        {
            if (ClgMFont.ShowDialog() == DialogResult.OK)
            {
                BtnMFont.BackColor = ClgMFont.Color;
            }
        }

        private void BtnLFont_Click(object sender, EventArgs e)
        {
            if (ClgLFont.ShowDialog() == DialogResult.OK)
            {
                BtnLFont.BackColor = ClgLFont.Color;
            }
        }

        private void BtnLColor_Click(object sender, EventArgs e)
        {
            if (ClgList.ShowDialog() == DialogResult.OK)
            {
                BtnLColor.BackColor = ClgList.Color;
            }
        }

        private void BtnRFont_Click(object sender, EventArgs e)
        {
            if (ClgRFont.ShowDialog() == DialogResult.OK)
            {
                BtnRFont.BackColor = ClgRFont.Color;
            }
        }

        private void BtnRColor_Click(object sender, EventArgs e)
        {
            if (ClgResult.ShowDialog() == DialogResult.OK)
            {
                BtnRColor.BackColor = ClgResult.Color;
            }
        }

        private void TxtRFont_Click(object sender, EventArgs e)
        {
            if (FlgResult.ShowDialog(this) == DialogResult.OK)
            {
                Font txtFont = new Font(FlgPaper.Font.FontFamily, 9F, FlgPaper.Font.Style);
                TxtRFont.Font = txtFont;
            }
        }

        private void TxtLFont_Click(object sender, EventArgs e)
        {
            if (FlgList.ShowDialog(this) == DialogResult.OK)
            {
                Font txtFont = new Font(FlgPaper.Font.FontFamily, 9F, FlgPaper.Font.Style);
                TxtLFont.Font = txtFont;
            }
        }
    }
}
