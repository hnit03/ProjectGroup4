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
            ds = SinhVienDAO.LoadSinhVienToComboBox();
            cboMaSV.DataSource = ds.Tables[0];
            cboMaSV.DisplayMember = "MASV";
            cboMaSV.ValueMember = "MASV";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
 

 //           DataRow selectedRow = ds.Tables[0].Rows[rowIndex];
  //          txtSurName.Text = selectedRow["HOSV"].ToString();
    //        txtName.Text = selectedRow["TENSV"].ToString();
      //      txtDOB.Text = selectedRow["NGAYSINH"].ToString(); 
        //    txtSex.Text = selectedRow["GIOITINH"].ToString();
          //  txtCourseCode.Text = selectedRow["MAKH"].ToString();
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
