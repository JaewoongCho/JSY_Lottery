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
        readonly private SqliteConnection ConfigConn;
        readonly private SqliteConnection BenefitConn;

        public FrmConfig(ref SqliteConnection configConn, ref SqliteConnection benefitConnection)
        {
            InitializeComponent();
            this.ConfigConn = configConn;
            this.BenefitConn = benefitConnection;
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
            DataGridViewComboBoxColumn col5 = new()
            {
                Name = "col5",
                HeaderText = "소리파일"
            };
            DgvBenefit.Columns.Add(col5);
            // Config대로 일단 데이터 넣기
            LoadConfig();
            LoadBenefit();
        }

        private void LoadConfig()
        {
            string sql = "SELECT * FROM tbConfig";
            SqliteCommand cmd = new(sql, ConfigConn);
            SqliteDataReader rdr = cmd.ExecuteReader();

            string paperFontFamily = "맑은 고딕";
            string marqueeFontFamily = "맑은 고딕";
            string listFontFamily = "맑은 고딕";
            string resultFontFamily = "맑은 고딕";
            float paperFontSize = 10F, marqueeFontSize = 16F, listFontSize = 10F, resultFontSize = 10F;
            bool paperFontBold = false, paperFontItalic = false, paperFontUnderline = false, paperFontStrikeout = false;
            bool marqueeFontBold = false, marqueeFontItalic = false, marqueeFontUnderline = false, marqueeFontStrikeout = false;
            bool listFontBold = false, listFontItalic = false, listFontUnderline = false, listFontStrikeout = false;
            bool resultFontBold = false, resultFontItalic = false, resultFontUnderline = false, resultFontStrikeout = false;
            Color color;
            int rgb;

            while (rdr.Read())
            {
                string name = rdr.GetString(0);

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
                        if(int.TryParse(rdr.GetString(1), out rgb))
                        {
                            color = Color.FromArgb(rgb);
                        }
                        else
                        {
                            color = Color.White;
                        }
                        ClgBoard.Color = color;
                        BtnBColor.BackColor = color;
                        break;
                    case "paperColor":
                        if (int.TryParse(rdr.GetString(1), out rgb))
                        {
                            color = Color.FromArgb(rgb);
                        }
                        else
                        {
                            color = Color.White;
                        }
                        ClgPaper.Color = color;
                        BtnPColor.BackColor = color;
                        break;
                    case "marqueeColor":
                        if (int.TryParse(rdr.GetString(1), out rgb))
                        {
                            color = Color.FromArgb(rgb);
                        }
                        else
                        {
                            color = Color.Black;
                        }
                        ClgMarquee.Color = color;
                        BtnMColor.BackColor = color;
                        break;
                    case "paperFontColor":
                        if (int.TryParse(rdr.GetString(1), out rgb))
                        {
                            color = Color.FromArgb(rgb);
                        }
                        else
                        {
                            color = Color.White;
                        }
                        ClgPFont.Color = color;
                        BtnPFont.BackColor = color;
                        break;
                    case "paperFontFamily":
                        paperFontFamily = rdr.GetString(1);
                        break;
                    case "paperFontSize":
                        paperFontSize = rdr.GetFloat(1);
                        break;
                    case "paperFontBold":
                        paperFontBold = rdr.GetString(1) == "True";
                        break;
                    case "paperFontItelic":
                        paperFontItalic = rdr.GetString(1) == "True";
                        break;
                    case "paperFontUnderline":
                        paperFontUnderline = rdr.GetString(1) == "True";
                        break;
                    case "paperFontStrike":
                        paperFontStrikeout = rdr.GetString(1) == "True";
                        break;
                    case "marqueeFontColor":
                        if (int.TryParse(rdr.GetString(1), out rgb))
                        {
                            color = Color.FromArgb(rgb);
                        }
                        else
                        {
                            color = Color.White;
                        }
                        ClgMFont.Color = color;
                        BtnMFont.BackColor = color;
                        break;
                    case "marqueeFontFamily":
                        marqueeFontFamily = rdr.GetString(1);
                        break;
                    case "marqueeFontSize":
                        marqueeFontSize = rdr.GetFloat(1);
                        break;
                    case "marqueeFontBold":
                        marqueeFontBold = rdr.GetString(1) == "True";
                        break;
                    case "marqueeFontItelic":
                        marqueeFontItalic = rdr.GetString(1) == "True";
                        break;
                    case "marqueeFontUnderline":
                        marqueeFontUnderline = rdr.GetString(1) == "True";
                        break;
                    case "marqueeFontStrike":
                        marqueeFontStrikeout = rdr.GetString(1) == "True";
                        break;
                    // -- 추가분
                    case "listFontColor":
                        if (int.TryParse(rdr.GetString(1), out rgb))
                        {
                            color = Color.FromArgb(rgb);
                        }
                        else
                        {
                            color = Color.Black;
                        }
                        ClgLFont.Color = color;
                        BtnLFont.BackColor = color;
                        break;
                    case "listFontFamily":
                        listFontFamily = rdr.GetString(1);
                        break;
                    case "listFontSize":
                        listFontSize = rdr.GetFloat(1);
                        break;
                    case "listFontBold":
                        listFontBold = rdr.GetString(1) == "True";
                        break;
                    case "listFontItelic":
                        listFontItalic = rdr.GetString(1) == "True";
                        break;
                    case "listFontUnderline":
                        listFontUnderline = rdr.GetString(1) == "True";
                        break;
                    case "listFontStrike":
                        listFontStrikeout = rdr.GetString(1) == "True";
                        break;
                    case "listColor":
                        if (int.TryParse(rdr.GetString(1), out rgb))
                        {
                            color = Color.FromArgb(rgb);
                        }
                        else
                        {
                            color = Color.White;
                        }
                        ClgList.Color = color;
                        BtnLColor.BackColor = color;
                        break;
                    case "resultFontColor":
                        if (int.TryParse(rdr.GetString(1), out rgb))
                        {
                            color = Color.FromArgb(rgb);
                        }
                        else
                        {
                            color = Color.White;
                        }
                        ClgRFont.Color = color;
                        BtnRFont.BackColor = color;
                        break;
                    case "resultFontFamily":
                        resultFontFamily = rdr.GetString(1);
                        break;
                    case "resultFontSize":
                        resultFontSize = rdr.GetFloat(1);
                        break;
                    case "resultFontBold":
                        resultFontBold = rdr.GetString(1) == "True";
                        break;
                    case "resultFontItelic":
                        resultFontItalic = rdr.GetString(1) == "True";
                        break;
                    case "resultFontUnderline":
                        resultFontUnderline = rdr.GetString(1) == "True";
                        break;
                    case "resultFontStrike":
                        resultFontStrikeout = rdr.GetString(1) == "True";
                        break;
                    case "resultColor":
                        if (int.TryParse(rdr.GetString(1), out rgb))
                        {
                            color = Color.FromArgb(rgb);
                        }
                        else
                        {
                            color = Color.Black;
                        }
                        ClgResult.Color = color;
                        BtnRColor.BackColor = color;
                        break;
                }
            }

            Font paperFont = new(paperFontFamily, paperFontSize, (paperFontBold ? FontStyle.Bold : FontStyle.Regular) |
                (paperFontItalic ? FontStyle.Italic : FontStyle.Regular) | (paperFontUnderline ? FontStyle.Underline : FontStyle.Regular) |
                (paperFontStrikeout ? FontStyle.Strikeout : FontStyle.Regular));
            TxtPFont.Font = new(paperFont.FontFamily, 9F, paperFont.Style);
            FlgPaper.Font = paperFont;

            Font marqueeFont = new(marqueeFontFamily, marqueeFontSize, (marqueeFontBold ? FontStyle.Bold : FontStyle.Regular) |
                (marqueeFontItalic ? FontStyle.Italic : FontStyle.Regular) | (marqueeFontUnderline ? FontStyle.Underline : FontStyle.Regular) |
                (marqueeFontStrikeout ? FontStyle.Strikeout : FontStyle.Regular));
            TxtMFont.Font = new(marqueeFont.FontFamily, 9F, marqueeFont.Style);
            FlgMarquee.Font = marqueeFont;

            Font listFont = new(listFontFamily, listFontSize, (listFontBold ? FontStyle.Bold : FontStyle.Regular) |
                (listFontItalic ? FontStyle.Italic : FontStyle.Regular) | (listFontUnderline ? FontStyle.Underline : FontStyle.Regular) |
                (listFontStrikeout ? FontStyle.Strikeout : FontStyle.Regular));
            TxtLFont.Font = new(listFont.FontFamily, 9F, marqueeFont.Style);
            FlgList.Font = listFont;

            Font resultFont = new(resultFontFamily, resultFontSize, (resultFontBold ? FontStyle.Bold : FontStyle.Regular) |
                (resultFontItalic ? FontStyle.Italic : FontStyle.Regular) | (resultFontUnderline ? FontStyle.Underline : FontStyle.Regular) |
                (resultFontStrikeout ? FontStyle.Strikeout : FontStyle.Regular));
            TxtRFont.Font = new(resultFont.FontFamily, 9F, resultFont.Style);
            FlgResult.Font = resultFont;
        }

        private void LoadBenefit()
        {
            string sql = "SELECT * FROM tbBenefit";
            SqliteCommand cmd = new(sql, BenefitConn);
            SqliteDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                DataGridViewRow dgvRow = new DataGridViewRow();
                dgvRow.CreateCells(DgvBenefit);
                dgvRow.Cells[0].Value = rdr.GetInt32(0);
                dgvRow.Cells[1].Value = rdr.GetString(0);
                dgvRow.Cells[2].Value = rdr.GetInt32(0);
                dgvRow.Cells[3].Value = rdr.GetString(0);

                string soundFile = rdr[4] is System.DBNull ? "" : rdr.GetString(4);

                if (dgvRow.Cells[4] is DataGridViewComboBoxCell cCell)
                {
                    DirectoryInfo soundDir = new(Application.StartupPath + @"sound");
                    foreach (FileInfo file in soundDir.GetFiles())
                    {
                        cCell.Items.Add(file.Name);
                    }

                    if (soundFile != "")
                    {
                        cCell.Value = (new FileInfo(soundFile)).Name;
                    }
                }

                DgvBenefit.Rows.Add(dgvRow);
            }
        }

        private void TxtPFont_Click(object sender, EventArgs e)
        {
            if (FlgPaper.ShowDialog(this) == DialogResult.OK)
            {
                Font txtFont = new(FlgPaper.Font.FontFamily, 9F, FlgPaper.Font.Style);
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
                Font txtFont = new(FlgMarquee.Font.FontFamily, 9F, FlgMarquee.Font.Style);
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

        private void BtnOK_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("변경하신 내용을 적용하시겠습니까?", "환경설정 적용확인", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // 일단 디비에 저장하고
                // 설정부분
                // 기존거 삭제
                string sql = "DELETE FROM tbConfig";
                SqliteCommand cmd = new(sql, ConfigConn);
                cmd.ExecuteNonQuery();

                Font paperFont = FlgPaper.Font;
                Font marqueeFont = FlgMarquee.Font;
                Font listFont = FlgList.Font;
                Font resultFont = FlgResult.Font;

                sql = "INSERT INTO tbConfig(configValue, configName) VALUES(@param1, @param2)";
                cmd = new(sql, ConfigConn);

                cmd.Parameters.Clear();
                cmd.Parameters.Add(new("@param1", ClgPFont.Color.ToArgb().ToString()));
                cmd.Parameters.Add(new("@param2", "paperFontColor"));
                cmd.ExecuteNonQuery();

                cmd.Parameters.Clear();
                cmd.Parameters.Add(new("@param1", paperFont.FontFamily.Name));
                cmd.Parameters.Add(new("@param2", "paperFontFamily"));
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
                cmd = new SqliteCommand(sql, BenefitConn);
                cmd.ExecuteNonQuery();

                for (int row = 0; row < DgvBenefit.Rows.Count; row++)
                {
                    if (row == DgvBenefit.NewRowIndex)
                    {
                        continue;
                    }
                    string insertSql = "INSERT INTO tbBenefit(seq, benefit_name, benefit_count, benefit_desc, benefit_sound) VALUES(@p1, @p2, @p3, @p4, @p5)";

                    cmd = new SqliteCommand(insertSql, BenefitConn);
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new SqliteParameter("@p1", DgvBenefit.Rows[row].Cells[0].Value));
                    cmd.Parameters.Add(new SqliteParameter("@p2", DgvBenefit.Rows[row].Cells[1].Value));
                    cmd.Parameters.Add(new SqliteParameter("@p3", DgvBenefit.Rows[row].Cells[2].Value));
                    cmd.Parameters.Add(new SqliteParameter("@p4", DgvBenefit.Rows[row].Cells[3].Value));

                    try
                    {
                        DataGridViewComboBoxCell cb = (DataGridViewComboBoxCell)DgvBenefit.Rows[row].Cells[4];
                        string soundFile = cb.Value?.ToString() ?? string.Empty;

                        if (!string.IsNullOrEmpty(soundFile))
                        {
                            string soundPath = Application.StartupPath + @"sound\" + soundFile;
                            cmd.Parameters.Add(new SqliteParameter("@p5", soundPath));
                        }
                        else
                        {
                            cmd.Parameters.Add(new SqliteParameter("@p5", ""));
                        }
                    }
                    catch(Exception)
                    {
                        cmd.Parameters.Add(new SqliteParameter("@p5", ""));
                    }
                    cmd.ExecuteNonQuery();
                }

                // 메인의 어플라이 부르고
                ((FrmMain)Owner).ApplyConfig();

                // 창닫기
                Close();
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
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
                Font txtFont = new(FlgPaper.Font.FontFamily, 9F, FlgPaper.Font.Style);
                TxtRFont.Font = txtFont;
            }
        }

        private void TxtLFont_Click(object sender, EventArgs e)
        {
            if (FlgList.ShowDialog(this) == DialogResult.OK)
            {
                Font txtFont = new(FlgPaper.Font.FontFamily, 9F, FlgPaper.Font.Style);
                TxtLFont.Font = txtFont;
            }
        }
    }
}
