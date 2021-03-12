using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGroup4.SinhVien
{
    public class SinhVienDAO
    {
        public static DataSet LoadSinhVienToComboBox()
        {
            DataSet dsStudent = null;
            SqlConnection scon = DBUtils.GetSqlConnection();
            String sql = "SELECT MASV FROM SVIEN";

            try
            {
                scon.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, scon);
                dsStudent = new DataSet();
                adapter.Fill(dsStudent);
            }
            catch(Exception e)
            {
                e.ToString();
            }
            finally
            {
                scon.Close();
            }
            return dsStudent;
        }

        public static DataSet GetStudentResultByStudentCode(String maSV)
        {
            DataSet dsResult = null;
            SqlConnection scon = DBUtils.GetSqlConnection();
            String sql = "select m.MAMH, m.TENMH,kq.DIEM "
                            +"from KQUA kq,MHOC m "
                            +"where kq.MASV = "+ maSV +" and m.MAMH = kq.MAMH ";

            try
            {
                scon.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, scon);
                dsResult = new DataSet();
                adapter.Fill(dsResult);
            }
            catch (Exception e)
            {
                e.ToString();
            }
            finally
            {
                scon.Close();
            }
            return dsResult;
        }

        public static DataSet GetStudentInformationByStudentCode(String maSV)
        {
            DataSet dsResult = null;
            SqlConnection scon = DBUtils.GetSqlConnection();
            String sql = "select MASV,HOSV,TENSV,NGAYSINH,GIOITINH,MAKH "
                            + "from SVIEN "
                            + "where MASV = " + maSV;

            try
            {
                scon.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, scon);
                dsResult = new DataSet();
                adapter.Fill(dsResult);
            }
            catch (Exception e)
            {
                e.ToString();
            }
            finally
            {
                scon.Close();
            }
            return dsResult;
        }
    }
}
