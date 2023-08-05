using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace CNTT129.Models
{
    public class KETQUA
    {
        public string conf = WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        public string ID_KQ { get; set; }
        public string IDSV { get; set; }
        public string IDHK { get; set; }
        public string DIEM { get; set; }
        public string LOAI { get; set; }
        public string MASV { get; set; }
        public string TENSV { get; set; }
        public string CODE_LOP { get; set; }
        public string CODE_HK { get; set; }
        public string TEN_KHOA { get; set; }

        public int ketQuaSV(string idsv, string idhk)
        {
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd2 = new SqlCommand("select IIF(SUM(DIEM+DIEMMD) IS NULL, (SELECT DIEMMD FROM HOC_KI where ID_HK = " + idhk + "), SUM(DIEM+DIEMMD)) from KETQUA where IDSV = " + idsv + " and IDHK = " + idhk + "", con);
            cmd2.CommandType = CommandType.Text;
            con.Open();
            Object kq = cmd2.ExecuteScalar();
            int dr = kq == null ? 0 : int.Parse(kq.ToString());
            con.Close();
            return dr;
        }

        public int ketQuaSV(string idhk)
        {
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd2 = new SqlCommand("select Top 1 DIEMMD from KETQUA where IDHK = " + idhk + "", con);
            cmd2.CommandType = CommandType.Text;
            con.Open();
            Object kq = cmd2.ExecuteScalar();
            int dr = kq == null ? 0 : int.Parse(kq.ToString());
            con.Close();
            return dr;
        }

        public List<KETQUA> findReport(string khoa, string lop, string hoc_ky)
        {
            SqlConnection con = new SqlConnection(conf);
            List<KETQUA> listHK = new List<KETQUA>();
            var sql = "";
            var orther = "";
            if (khoa != "0")
            {
                sql += " and khoa.id_khoa = " + khoa;
            }
            if (lop != "")
            {
                sql += " and lop.ID_LOP = " + lop;
            }
            if (hoc_ky != "0")
            {
                sql += " and hoc_ki.id_hk = " + hoc_ky;
            }
            orther = " ORDER BY TENSV, khoa.id_khoa,lop.ID_LOP ";
            SqlCommand cmd2 = new SqlCommand("select SINHVIEN.MASV,SINHVIEN.TENSV,LOP.CODE_LOP,HOC_KI.CODE_HK,KHOA.TEN_KHOA,KETQUA.DIEM  from KETQUA,lop,hoc_ki,khoa,sinhvien where KETQUA.idsv = sinhvien.id_sv and sinhvien.IDLOP = lop.ID_LOP and khoa.id_khoa = lop.id_khoa and KETQUA.IDHK = hoc_ki.id_hk" + sql + orther, con);
            cmd2.CommandType = CommandType.Text;
            con.Open();
            SqlDataReader dr = cmd2.ExecuteReader();
            while (dr.Read())
            {
                KETQUA emp = new KETQUA();
                emp.MASV = dr.GetValue(0).ToString();
                emp.TENSV = dr.GetValue(1).ToString();
                emp.CODE_LOP = dr.GetValue(2).ToString();
                emp.CODE_HK = dr.GetValue(3).ToString();
                emp.TEN_KHOA = dr.GetValue(4).ToString();
                emp.DIEM = dr.GetValue(5).ToString();
                listHK.Add(emp);
            }
            con.Close();
            return listHK;
        }
    }
}