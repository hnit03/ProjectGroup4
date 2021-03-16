using ProjectGroup4.SinhVien;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectGroup4
{
    public partial class Form1 : Form
    {
        private DataSet ds;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadData();
        }

        public void loadData()
        {
            cboMaSV.Items.Add("Choose Student");
            cboMaSV.SelectedIndex = cboMaSV.FindStringExact("Choose Student");
            btnSearch.Enabled = false; 
            ds = SinhVienDAO.LoadSinhVienToComboBox();
            DataTable dt = ds.Tables[0];
            for (int i =0; i < dt.Rows.Count; i++)
            {
                cboMaSV.Items.Add(dt.Rows[i].Field<int>("MASV"));
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String studentCode = cboMaSV.Text;
            if(studentCode != null)
            {
                if(studentCode.Equals("Choose Student"))
                {
                    btnSearch.Enabled = false;
                    dgwKetQua.DataSource = null;
                    txtSurName.Text = "";
                    txtName.Text = "";
                    txtDOB.Text = "";
                    txtSex.Text = "";
                    txtCourseCode.Text = "";
                }
                else{
                    btnSearch.Enabled = true;
                }
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String studentCode = cboMaSV.Text;
            if (studentCode != null)
            {
                if(!studentCode.Equals("Choose Student")){
                    dgwKetQua.DataSource = SinhVienDAO.GetStudentResultByStudentCode(studentCode).Tables[0];
                    DataRow[] selectedRow = SinhVienDAO.GetStudentInformationByStudentCode(studentCode).Tables[0].Select(string.Format("MASV='{0}'", studentCode));
                    txtSurName.Text = selectedRow[0]["HOSV"].ToString();
                    txtName.Text = selectedRow[0]["TENSV"].ToString();
                    txtDOB.Text = selectedRow[0]["NGAYSINH"].ToString();
                    txtSex.Text = selectedRow[0]["GIOITINH"].ToString();
                    txtCourseCode.Text = selectedRow[0]["MAKH"].ToString();
                }
            }
        }
    }
}
