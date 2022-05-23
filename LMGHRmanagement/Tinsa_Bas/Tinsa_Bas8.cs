using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Oracle.ManagedDataAccess.Client;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace LMGHRmanagement
{
    public partial class Tinsa_Bas8 : Form
    {
        string cs = "Data Source=222.237.134.74:1522/Ora7;User Id=edu;Password=edu1234;";

        public Tinsa_Bas8()
        {
            InitializeComponent();

            #region 인사기본사항 초기화
            this.dataGridView1.Columns.Add("bas_empno", "사원번호");
            this.dataGridView1.Columns.Add("bas_resno", "주민등록번호");
            this.dataGridView1.Columns["bas_resno"].Visible = false;
            this.dataGridView1.Columns.Add("bas_name", "성명(한글)");
            this.dataGridView1.Columns.Add("bas_cname", "성명(한자)");
            this.dataGridView1.Columns["bas_cname"].Visible = false;
            this.dataGridView1.Columns.Add("bas_ename", "성명(영문)");
            this.dataGridView1.Columns["bas_ename"].Visible = false;
            this.dataGridView1.Columns.Add("bas_fix", "성별");
            this.dataGridView1.Columns["bas_fix"].Visible = false;
            this.dataGridView1.Columns.Add("bas_zip", "우편번호");
            this.dataGridView1.Columns["bas_zip"].Visible = false;
            this.dataGridView1.Columns.Add("bas_addr", "주소");
            this.dataGridView1.Columns["bas_addr"].Visible = false;
            this.dataGridView1.Columns.Add("bas_hdpno", "연락처(휴대폰)");
            this.dataGridView1.Columns["bas_hdpno"].Visible = false;
            this.dataGridView1.Columns.Add("bas_telno", "연락처(집)");
            this.dataGridView1.Columns["bas_telno"].Visible = false;
            this.dataGridView1.Columns.Add("bas_email", "이메일주소");
            this.dataGridView1.Columns["bas_email"].Visible = false;
            this.dataGridView1.Columns.Add("bas_mil_sta", "병역(복무구분)");
            this.dataGridView1.Columns["bas_mil_sta"].Visible = false;
            this.dataGridView1.Columns.Add("bas_mil_mil", "병역(군별)");
            this.dataGridView1.Columns["bas_mil_mil"].Visible = false;
            this.dataGridView1.Columns.Add("bas_mil_rnk", "병역(계급)");
            this.dataGridView1.Columns["bas_mil_rnk"].Visible = false;
            this.dataGridView1.Columns.Add("bas_mar", "결혼여부");
            this.dataGridView1.Columns["bas_mar"].Visible = false;
            this.dataGridView1.Columns.Add("bas_acc_bank", "계좌사항(은행명)");
            this.dataGridView1.Columns["bas_acc_bank"].Visible = false;
            this.dataGridView1.Columns.Add("bas_acc_name", "계좌사항(예금주)");
            this.dataGridView1.Columns["bas_acc_name"].Visible = false;
            this.dataGridView1.Columns.Add("bas_acc_no", "계좌사항(계좌번호)");
            this.dataGridView1.Columns["bas_acc_no"].Visible = false;
            this.dataGridView1.Columns.Add("bas_cont", "계약구분");
            this.dataGridView1.Columns["bas_cont"].Visible = false;
            this.dataGridView1.Columns.Add("bas_emp_sdate", "계약시작일");
            this.dataGridView1.Columns["bas_emp_sdate"].Visible = false;
            this.dataGridView1.Columns.Add("bas_emp_edate", "계약종료일");
            this.dataGridView1.Columns["bas_emp_edate"].Visible = false;
            this.dataGridView1.Columns.Add("bas_entdate", "입사일자");
            this.dataGridView1.Columns["bas_entdate"].Visible = false;
            this.dataGridView1.Columns.Add("bas_resdate", "퇴사일자");
            this.dataGridView1.Columns["bas_resdate"].Visible = false;
            this.dataGridView1.Columns.Add("bas_levdate", "휴직일자");
            this.dataGridView1.Columns["bas_levdate"].Visible = false;
            this.dataGridView1.Columns.Add("bas_reidate", "복직일자");
            this.dataGridView1.Columns["bas_reidate"].Visible = false;
            this.dataGridView1.Columns.Add("bas_dptdate", "현부서일자");
            this.dataGridView1.Columns["bas_dptdate"].Visible = false;
            this.dataGridView1.Columns.Add("bas_jkpdate", "현직급일자");
            this.dataGridView1.Columns["bas_jkpdate"].Visible = false;
            this.dataGridView1.Columns.Add("bas_posdate", "현직책일자");
            this.dataGridView1.Columns["bas_posdate"].Visible = false;
            this.dataGridView1.Columns.Add("bas_wsta", "재직상태");
            this.dataGridView1.Columns["bas_wsta"].Visible = false;
            this.dataGridView1.Columns.Add("bas_sts", "신분구분");
            this.dataGridView1.Columns["bas_sts"].Visible = false;
            this.dataGridView1.Columns.Add("bas_pos", "직급(현재)");
            this.dataGridView1.Columns.Add("bas_dut", "직책(현재)");
            this.dataGridView1.Columns["bas_dut"].Visible = false;
            this.dataGridView1.Columns.Add("bas_dept", "부서(현재)");
            this.dataGridView1.Columns.Add("bas_rmk", "참고사항");
            this.dataGridView1.Columns["bas_rmk"].Visible = false;
            this.dataGridView1.Columns.Add("img_image", "사진");
            this.dataGridView1.Columns["img_image"].Visible = false;
            #endregion

            #region 가족사항 초기화
            this.dataGridView3.Columns.Add("fam_empno", "사원번호");
            this.dataGridView3.Columns.Add("fam_rel", "관계");
            this.dataGridView3.Columns.Add("fam_name", "성명");
            this.dataGridView3.Columns.Add("fam_bth", "생년월일");
            this.dataGridView3.Columns.Add("fam_ltg", "동거여부");
            #endregion

            #region 학력사항 초기화
            this.dataGridView4.Columns.Add("edu_empno", "사원번호");
            this.dataGridView4.Columns.Add("edu_loe", "학력구분");
            this.dataGridView4.Columns.Add("edu_entdate", "입학일자");
            this.dataGridView4.Columns.Add("edu_gradate", "졸업일자");
            this.dataGridView4.Columns.Add("edu_schnm", "학교명");
            this.dataGridView4.Columns.Add("edu_dept", "학과(전공)");
            this.dataGridView4.Columns.Add("edu_degree", "학위");
            this.dataGridView4.Columns.Add("edu_grade", "성적");
            this.dataGridView4.Columns.Add("edu_gra", "졸업구분");
            this.dataGridView4.Columns.Add("edu_last", "최종여부");
            #endregion

            #region 상벌사항 초기화
            this.dataGridView5.Columns.Add("award_empno", "사원번호");
            this.dataGridView5.Columns.Add("award_date", "수여일자");
            this.dataGridView5.Columns.Add("award_no", "수여번호");
            this.dataGridView5.Columns.Add("award_kind", "수상종별");
            this.dataGridView5.Columns.Add("award_organ", "수여자(시행처)");
            this.dataGridView5.Columns.Add("award_content", "수상내용");
            this.dataGridView5.Columns.Add("award_inout", "내외구분");
            this.dataGridView5.Columns.Add("award_pos", "직급(당시)");
            this.dataGridView5.Columns.Add("award_dept", "소속(당시)");
            #endregion

            #region 경력사항 초기화
            this.dataGridView6.Columns.Add("CAR_EMPNO", "사원번호");
            this.dataGridView6.Columns.Add("CAR_COM", "근무처명");
            this.dataGridView6.Columns.Add("CAR_REGION", "소재지");
            this.dataGridView6.Columns.Add("CAR_YYYYMM_F", "근무시작월");
            this.dataGridView6.Columns.Add("CAR_YYYYMM_T", "근무종료월");
            this.dataGridView6.Columns.Add("CAR_POS", "최종직급");
            this.dataGridView6.Columns.Add("CAR_DEPT", "담당부서");
            this.dataGridView6.Columns.Add("CAR_REASON", "퇴직/이직사유");
            #endregion

            #region 자격면허 초기화
            this.dataGridView7.Columns.Add("LIC_EMPNO", "사원번호");
            this.dataGridView7.Columns.Add("LIC_NAME", "자격증명");
            this.dataGridView7.Columns.Add("LIC_GRADE", "급수");
            this.dataGridView7.Columns.Add("LIC_ACQDATE", "취득일");
            this.dataGridView7.Columns.Add("LIC_ORGAN", "발급기관");
            #endregion

            #region 외국어 초기화
            this.dataGridView8.Columns.Add("FORL_EMPNO", "사원번호");
            this.dataGridView8.Columns.Add("FORL_NAME", "외국어자격명");
            this.dataGridView8.Columns.Add("FORL_SCORE", "점수");
            this.dataGridView8.Columns.Add("FORL_ACQDATE", "취득일");
            this.dataGridView8.Columns.Add("FORL_ORGAN", "발급기관");
            #endregion

            #region 데이터그리드뷰1 더블클릭
            this.dataGridView1.CellDoubleClick += new DataGridViewCellEventHandler(DataGridViewDoubleClickEvent);
            #endregion

            #region 텍스트 박스 포커스 이벤트
            search_bas_pos.GotFocus += new EventHandler(BasPosGotFoucsEvent);
            search_bas_dept.GotFocus += new EventHandler(BasDeptGotFoucsEvent);
            #endregion

            tabControl1.Click += new EventHandler(TabControlClickEvent);


        }

        private void TabControlClickEvent(object sender, EventArgs e)
        {
            dataGridView6.Rows.Clear();
            dataGridView7.Rows.Clear();
            dataGridView8.Rows.Clear();
            if (tabControl1.SelectedTab.Text == "가족사항") { FmiLoad(); return; }
            if (tabControl1.SelectedTab.Text == "학력사항") { EduLoad(); return; }
            if (tabControl1.SelectedTab.Text == "상벌사항") { AwardLoad(); return; }
            if (tabControl1.SelectedTab.Text == "경력사항") { CarLoad(); return; }
            if (tabControl1.SelectedTab.Text == "자격면허") { LicLoad(); return; }
            if (tabControl1.SelectedTab.Text == "외국어") { ForlLoad(); return; }
        }

        private void ForlLoad()
        {
            dataGridView8.Rows.Clear();
            string sql = SqlCommand.Tinsa_Bas8_Select6;
            using (OracleConnection connection = new OracleConnection(cs))
            {
                connection.Open();
                using (OracleCommand command = new OracleCommand())
                {
                    command.Connection = connection;
                    command.CommandText = sql;
                    command.Parameters.Add("bas_empno", dataGridView1.SelectedRows[0].Cells["bas_empno"].Value);
                    OracleDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                    while (reader.Read()) DataGridView7SelectLoad(reader);
                }
            }
        }

        private void DataGridView7SelectLoad(OracleDataReader reader)
        {
            var index = this.dataGridView8.Rows.Add();
            var cells = this.dataGridView8.Rows[index].Cells;

            cells["forl_empno"].Value = reader["forl_empno"].ToString();
            cells["forl_name"].Value = reader["forl_name"].ToString();
            cells["forl_score"].Value = reader["forl_score"].ToString();
            cells["forl_acqdate"].Value = reader["forl_acqdate"].ToString();
            cells["forl_organ"].Value = reader["forl_organ"].ToString();
        }

        private void LicLoad()
        {
            dataGridView7.Rows.Clear();
            string sql = SqlCommand.Tinsa_Bas8_Select5;
            using (OracleConnection connection = new OracleConnection(cs))
            {
                connection.Open();
                using (OracleCommand command = new OracleCommand())
                {
                    command.Connection = connection;
                    command.CommandText = sql;
                    command.Parameters.Add("bas_empno", dataGridView1.SelectedRows[0].Cells["bas_empno"].Value);
                    OracleDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                    while (reader.Read()) DataGridView6SelectLoad(reader);
                }
            }
        }

        private void DataGridView6SelectLoad(OracleDataReader reader)
        {
            var index = this.dataGridView7.Rows.Add();
            var cells = this.dataGridView7.Rows[index].Cells;

            cells["lic_empno"].Value = reader["lic_empno"].ToString();
            cells["lic_name"].Value = reader["lic_name"].ToString();
            cells["lic_grade"].Value = reader["lic_grade"].ToString();
            cells["lic_acqdate"].Value = reader["lic_acqdate"].ToString();
            cells["lic_organ"].Value = reader["lic_organ"].ToString();
        }

        private void CarLoad()
        {
            dataGridView6.Rows.Clear();
            string sql = SqlCommand.Tinsa_Bas8_Select4;
            using (OracleConnection connection = new OracleConnection(cs))
            {
                connection.Open();
                using (OracleCommand command = new OracleCommand())
                {
                    command.Connection = connection;
                    command.CommandText = sql;
                    command.Parameters.Add("bas_empno", dataGridView1.SelectedRows[0].Cells["bas_empno"].Value);
                    OracleDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                    while (reader.Read()) DataGridView5SelectLoad(reader);
                }
            }
        }

        private void DataGridView5SelectLoad(OracleDataReader reader)
        {
            var index = this.dataGridView6.Rows.Add();
            var cells = this.dataGridView6.Rows[index].Cells;

            cells["car_empno"].Value = reader["car_empno"].ToString();
            cells["car_com"].Value = reader["car_com"].ToString();
            cells["car_region"].Value = reader["car_region"].ToString();
            cells["car_yyyymm_f"].Value = reader["car_yyyymm_f"].ToString();
            cells["car_yyyymm_t"].Value = reader["car_yyyymm_t"].ToString();
            cells["car_pos"].Value = reader["car_pos"].ToString();
            cells["car_dept"].Value = reader["car_dept"].ToString();
            cells["car_reason"].Value = reader["car_reason"].ToString();
        }

        private void AwardLoad()
        {
            dataGridView5.Rows.Clear();
            string sql = SqlCommand.Tinsa_Bas8_Select3;
            using (OracleConnection connection = new OracleConnection(cs))
            {
                connection.Open();
                using (OracleCommand command = new OracleCommand())
                {
                    command.Connection = connection;
                    command.CommandText = sql;
                    command.Parameters.Add("bas_empno", dataGridView1.SelectedRows[0].Cells["bas_empno"].Value);
                    OracleDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                    while (reader.Read()) DataGridView4SelectLoad(reader);
                }
            }
        }

        private void DataGridView4SelectLoad(OracleDataReader reader)
        {
            var index = this.dataGridView5.Rows.Add();
            var cells = this.dataGridView5.Rows[index].Cells;

            cells["award_empno"].Value = reader["award_empno"].ToString();
            cells["award_date"].Value = reader["award_date"].ToString();
            cells["award_no"].Value = reader["award_no"].ToString();
            cells["award_kind"].Value = reader["award_kind"].ToString();
            cells["award_organ"].Value = reader["award_organ"].ToString();
            cells["award_content"].Value = reader["award_content"].ToString();
            cells["award_inout"].Value = reader["award_inout"].ToString();
            cells["award_pos"].Value = reader["award_pos"].ToString();
            cells["award_dept"].Value = reader["award_dept"].ToString();
        }

        private void EduLoad()
        {
            dataGridView4.Rows.Clear();

            string sql = SqlCommand.Tinsa_Bas8_Select2;
            using (OracleConnection connection = new OracleConnection(cs))
            {
                connection.Open();
                using (OracleCommand command = new OracleCommand())
                {
                    command.Connection = connection;
                    command.CommandText = sql;
                    command.Parameters.Add("bas_empno", dataGridView1.SelectedRows[0].Cells["bas_empno"].Value);
                    OracleDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                    while (reader.Read()) DataGridView3SelectLoad(reader);
                }
            }
        }

        private void FmiLoad()
        {
            dataGridView3.Rows.Clear();

            string sql = SqlCommand.Tinsa_Bas8_Select1;
            using (OracleConnection connection = new OracleConnection(cs))
            {
                connection.Open();
                using (OracleCommand command = new OracleCommand())
                {
                    command.Connection = connection;
                    command.CommandText = sql;
                    command.Parameters.Add("bas_empno", dataGridView1.SelectedRows[0].Cells["bas_empno"].Value);
                    OracleDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                    while (reader.Read()) DataGridView2SelectLoad(reader);
                }
            }
        }

        private void DataGridView3SelectLoad(OracleDataReader reader)
        {
            var index = this.dataGridView4.Rows.Add();
            var cells = this.dataGridView4.Rows[index].Cells;

            cells["edu_empno"].Value = reader["edu_empno"].ToString();
            cells["edu_loe"].Value = reader["edu_loe"].ToString();
            cells["edu_entdate"].Value = reader["edu_entdate"].ToString();
            cells["edu_gradate"].Value = reader["edu_gradate"].ToString();
            cells["edu_schnm"].Value = reader["edu_schnm"].ToString();
            cells["edu_dept"].Value = reader["edu_dept"].ToString();
            cells["edu_degree"].Value = reader["edu_degree"].ToString();
            cells["edu_grade"].Value = reader["edu_grade"].ToString();
            cells["edu_gra"].Value = reader["edu_gra"].ToString();
            cells["edu_last"].Value = reader["edu_last"].ToString();
        }

        private void BasDeptGotFoucsEvent(object sender, EventArgs e)
        {
            string sql = @"select dept_name from lmg_tinsa_dept";

            using (OracleConnection con = new OracleConnection(cs))
            {
                con.Open();
                using (OracleCommand cmd = new OracleCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = sql;
                    OracleDataReader rd = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (rd.Read())
                    {
                        search_bas_dept.Items.Add(rd.GetString(0).ToString());
                    }
                }
            }
        }

        private void BasPosGotFoucsEvent(object sender, EventArgs e)
        {
            string sql = @"select cd_codnms from lmg_tinsa_cd where cd_grpcd = 'RNK'";

            using (OracleConnection con = new OracleConnection(cs))
            {
                con.Open();
                using (OracleCommand cmd = new OracleCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = sql;
                    OracleDataReader rd = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (rd.Read())
                    {
                        search_bas_pos.Items.Add(rd.GetString(0).ToString());
                    }
                }
            }
        }

        private void DataGridViewDoubleClickEvent(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex.Equals(-1)) return;
            var row = this.dataGridView1.Rows[e.RowIndex];
            this.InsertDataGridViewRowValue(row);
            #region 그리드뷰 row 클리어
            this.dataGridView3.Rows.Clear();
            this.dataGridView4.Rows.Clear();
            this.dataGridView5.Rows.Clear();
            this.dataGridView6.Rows.Clear();
            this.dataGridView7.Rows.Clear();
            this.dataGridView8.Rows.Clear();
            #endregion

            if (tabControl1.SelectedTab.Text == "가족사항") { FmiLoad(); return; }
            if (tabControl1.SelectedTab.Text == "학력사항") { EduLoad(); return; }
            if (tabControl1.SelectedTab.Text == "상벌사항") { AwardLoad(); return; }
            if (tabControl1.SelectedTab.Text == "경력사항") { CarLoad(); return; }
            if (tabControl1.SelectedTab.Text == "자격면허") { LicLoad(); return; }
            if (tabControl1.SelectedTab.Text == "외국어") { ForlLoad(); return; }
            //this.ValidationChecking(row);
        }

        private void InsertDataGridViewRowValue(DataGridViewRow row)
        {
            img_image.Image = null;

            var cells = row.Cells;

            this.bas_empno.Text = cells["bas_empno"].Value?.ToString();
            this.bas_resno.Text = cells["bas_resno"].Value?.ToString();
            this.bas_name.Text = cells["bas_name"].Value?.ToString();
            this.bas_cname.Text = cells["bas_cname"].Value?.ToString();
            this.bas_ename.Text = cells["bas_ename"].Value?.ToString();
            this.bas_fix.Text = cells["bas_fix"].Value?.ToString();
            this.bas_zip.Text = cells["bas_zip"].Value?.ToString();
            this.bas_addr.Text = cells["bas_addr"].Value?.ToString();
            this.bas_hdpno.Text = cells["bas_hdpno"].Value?.ToString();
            this.bas_telno.Text = cells["bas_telno"].Value?.ToString();
            this.bas_email.Text = cells["bas_email"].Value?.ToString();
            this.bas_mil_sta.Text = cells["bas_mil_sta"].Value?.ToString();
            if (cells["bas_mil_mil"].Value?.ToString() == null) { bas_mil_mil.Text = "선택"; return; }
            this.bas_mil_mil.Text = cells["bas_mil_mil"].Value?.ToString();
            this.bas_mil_rnk.Text = cells["bas_mil_rnk"].Value?.ToString();
            this.bas_mar.Text = cells["bas_mar"].Value?.ToString();
            this.bas_acc_bank.Text = cells["bas_acc_bank"].Value?.ToString();
            this.bas_acc_name.Text = cells["bas_acc_name"].Value?.ToString();
            this.bas_acc_no.Text = cells["bas_acc_no"].Value?.ToString();

            ImageRead();
            //this.bas_cont.Text = cells["bas_cont"].Value?.ToString();
            //this.bas_emp_sdate.Text = cells["bas_emp_sdate"].Value?.ToString();
            //this.bas_emp_edate.Text = cells["bas_emp_edate"].Value?.ToString();
            //this.bas_entdate.Text = cells["bas_entdate"].Value?.ToString();
            //this.bas_resdate.Text = cells["bas_resdate"].Value?.ToString();
            //this.bas_levdate.Text = cells["bas_levdate"].Value?.ToString();
            //this.bas_reidate.Text = cells["bas_reidate"].Value?.ToString();
            //this.bas_dptdate.Text = cells["bas_dptdate"].Value?.ToString();
            //this.bas_jkpdate.Text = cells["bas_jkpdate"].Value?.ToString();
            //this.bas_posdate.Text = cells["bas_posdate"].Value?.ToString();
            //this.bas_wsta.Text = cells["bas_wsta"].Value?.ToString();
            //this.bas_sts.Text = cells["bas_sts"].Value?.ToString();
            //this.bas_pos.Text = cells["bas_pos"].Value?.ToString();
            //this.bas_dut.Text = cells["bas_dut"].Value?.ToString();
            //this.bas_dept.Text = cells["bas_dept"].Value?.ToString();
            //this.bas_rmk.Text = cells["bas_rmk"].Value?.ToString();
        }

        private void ImageRead()
        {
            int rowindex = dataGridView1.CurrentCell.RowIndex;

            OracleConnection conn = new OracleConnection(cs);
            conn.Open();
            OracleCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select img_image from lmg_tinsa_image where img_empno = :img_empno";
            cmd.Parameters.Add("img_empno", this.bas_empno.Text);
            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (!dr.IsDBNull(0))
                {
                    byte[] imgByte = (byte[])dr["img_image"];

                    MemoryStream memoryStream = new MemoryStream(imgByte);
                    img_image.Image = new Bitmap(memoryStream);
                }
            }
            conn.Close();
        }

        private void DataLoadBtn_Click(object sender, EventArgs e)
        {
            //new Oracleparameter("parameter", $"%{parameter}%");
            //TextBoxValuesClear();
            #region 그리드뷰 row 클리어
            this.dataGridView1.Rows.Clear();
            this.dataGridView3.Rows.Clear();
            this.dataGridView4.Rows.Clear();
            this.dataGridView5.Rows.Clear();
            this.dataGridView6.Rows.Clear();
            this.dataGridView7.Rows.Clear();
            this.dataGridView8.Rows.Clear();
            #endregion

            var TargetControl = sender as Control;
            TargetControl.Text = string.Empty;
            DataLoadBtn.Text = "조회";

            string sql = SqlCommand.Tinsa_Bas8_Select;
            using (OracleConnection connection = new OracleConnection(cs))
            {
                connection.Open();
                using (OracleCommand command = new OracleCommand())
                {
                    command.Connection = connection;
                    command.CommandText = sql;
                    command.Parameters.Add("bas_empno", $"%{search_bas_empno.Text}%");
                    command.Parameters.Add("bas_name", $"%{search_bas_name.Text}%");
                    command.Parameters.Add("bas_pos", $"%{search_bas_pos.Text}%");
                    command.Parameters.Add("bas_dept", $"%{search_bas_dept.Text}%");
                    OracleDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                    while (reader.Read()) DataGridViewSelectDataLoad(reader);
                }
            }
        }

        private void DataGridView2SelectLoad(OracleDataReader reader)
        {
            var index = this.dataGridView3.Rows.Add();
            var cells = this.dataGridView3.Rows[index].Cells;

            cells["fam_empno"].Value = reader["fam_empno"].ToString();
            cells["fam_rel"].Value = reader["cd_code"] + ":" + reader["cd_codnms"];
            cells["fam_name"].Value = reader["fam_name"].ToString();
            cells["fam_bth"].Value = reader["fam_bth"].ToString();
            cells["fam_ltg"].Value = reader["fam_ltg"].ToString();
        }

        private void DataGridViewSelectDataLoad(OracleDataReader reader)
        {
            var index = this.dataGridView1.Rows.Add();
            var cells = this.dataGridView1.Rows[index].Cells;

            cells["bas_empno"].Value = reader["bas_empno"].ToString();
            cells["bas_resno"].Value = reader["bas_resno"].ToString();
            cells["bas_name"].Value = reader["bas_name"].ToString();
            cells["bas_cname"].Value = reader["bas_cname"].ToString();
            cells["bas_ename"].Value = reader["bas_ename"].ToString();
            cells["bas_fix"].Value = reader["bas_fix"].ToString();
            cells["bas_zip"].Value = reader["bas_zip"].ToString();
            cells["bas_addr"].Value = reader["bas_addr"].ToString();
            cells["bas_hdpno"].Value = reader["bas_hdpno"].ToString();
            cells["bas_telno"].Value = reader["bas_telno"].ToString();
            cells["bas_email"].Value = reader["bas_email"].ToString();
            cells["bas_mil_sta"].Value = reader["bas_mil_sta"].ToString();
            cells["bas_mil_mil"].Value = reader["bas_mil_mil"].ToString();
            cells["bas_mil_rnk"].Value = reader["bas_mil_rnk"].ToString();
            cells["bas_mar"].Value = reader["bas_mar"].ToString();
            cells["bas_acc_bank"].Value = reader["bas_acc_bank"].ToString();
            cells["bas_acc_name"].Value = reader["bas_acc_name"].ToString();
            cells["bas_acc_no"].Value = reader["bas_acc_no"].ToString();
            cells["bas_cont"].Value = reader["bas_cont"].ToString();
            cells["bas_emp_sdate"].Value = reader["bas_emp_sdate"].ToString();
            cells["bas_emp_edate"].Value = reader["bas_emp_edate"].ToString();
            cells["bas_entdate"].Value = reader["bas_entdate"].ToString();
            cells["bas_resdate"].Value = reader["bas_resdate"].ToString();
            cells["bas_levdate"].Value = reader["bas_levdate"].ToString();
            cells["bas_reidate"].Value = reader["bas_reidate"].ToString();
            cells["bas_dptdate"].Value = reader["bas_dptdate"].ToString();
            cells["bas_jkpdate"].Value = reader["bas_jkpdate"].ToString();
            cells["bas_posdate"].Value = reader["bas_posdate"].ToString();
            cells["bas_wsta"].Value = reader["bas_wsta"].ToString();
            cells["bas_sts"].Value = reader["bas_sts"].ToString();
            cells["bas_pos"].Value = reader["bas_pos"].ToString();
            cells["bas_dut"].Value = reader["bas_dut"].ToString();
            cells["bas_dept"].Value = reader["bas_dept"].ToString();
            cells["bas_rmk"].Value = reader["bas_rmk"].ToString();
            cells["img_image"].Value = reader["img_image"].ToString();
        }
    }
}
