using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace WebProgramingMatTroiBeTho.Models.Models.SanPham
{
    public class SanPhamDB:BasicDB
    {
        public SanPhamDB() : base() { }

        public List<SanPham> GetSanPhamList(ref string err, string searchString)
        {
            List<SanPham> list = new List<SanPham>();
            if(searchString == null)
            {
                searchString = "";
            }
            var dataReader = data.MyExecuteReader(ref err, "PSH_Select_SanPham", CommandType.StoredProcedure, new SqlParameter("@searchString", searchString));
            if(dataReader != null)
            {
                while (dataReader.Read())
                {
                    list.Add(
                        new SanPham()
                        {
                            MaSP = dataReader["MaSP"].ToString(),
                            TenSP = dataReader["TenSP"].ToString(),
                            DonGia = double.Parse(dataReader["DonGia"].ToString()),
                            SoLuong = int.Parse(dataReader["SoLuong"].ToString()),
                            ChiTietSanPham = dataReader["ChiTietSanPham"].ToString(),
                            LoaiSP = dataReader["LoaiSP"].ToString(),
                            TinhTrang = bool.Parse(dataReader["TinhTrang"].ToString()),
                            HinhAnh = dataReader["HinhAnh"].ToString()
                        });
                }
            }
            return list;
        }
        public List<SanPham> GetSanPhamDanhMuc(ref string err, string loai)
        {
            List<SanPham> ls = new List<SanPham>();
            var dataReader = data.MyExecuteReader(ref err, "PSH_Select_SanPhamLoai", CommandType.StoredProcedure, new SqlParameter("@searchString", loai));
            if(dataReader!= null)
            {
                while (dataReader.Read())
                {
                    ls.Add(new SanPham {
                        MaSP = dataReader["MaSP"].ToString(),
                        TenSP = dataReader["TenSP"].ToString(),
                        DonGia = double.Parse(dataReader["DonGia"].ToString()),
                        SoLuong = int.Parse(dataReader["SoLuong"].ToString()),
                        ChiTietSanPham = dataReader["ChiTietSanPham"].ToString(),
                        LoaiSP = dataReader["LoaiSP"].ToString(),
                        TinhTrang = bool.Parse(dataReader["TinhTrang"].ToString()),
                        HinhAnh = dataReader["HinhAnh"].ToString()
                    });
                }
            }
            return ls;
        }
        /// Phúc ADMIN: 
        public SanPham XemChiTietSP(ref string err, string id)
        {
            SqlDataReader dataReader = data.MyExecuteReader(ref err, "PSH_Select_SanPhamByID", CommandType.StoredProcedure,
                new SqlParameter("@id", id));
            SanPham sanPham = new SanPham();
            if (dataReader != null)
            {
                while (dataReader.Read())
                {
                    sanPham = new SanPham()
                    {
                        MaSP = dataReader["MaSP"].ToString(),
                        TenSP = dataReader["TenSP"].ToString(),
                        DonGia = double.Parse(dataReader["DonGia"].ToString()),
                        SoLuong = int.Parse(dataReader["SoLuong"].ToString()),
                        ChiTietSanPham = dataReader["ChiTietSanPham"].ToString(),
                        LoaiSP = dataReader["LoaiSP"].ToString(),
                        TinhTrang = bool.Parse(dataReader["TinhTrang"].ToString()),
                        HinhAnh = dataReader["HinhAnh"].ToString()
                    };
                }
            }
            return sanPham;
        }

        public bool InsertUpdateSanPham(ref string err, ref int rows, SanPham sanPham)
        {
            SqlParameter[] param = new SqlParameter[]{
                new SqlParameter("@id",sanPham.MaSP),
                    new SqlParameter("@TenSP",sanPham.TenSP),
                    new SqlParameter("@IDAnh",sanPham.HinhAnh),
                      new SqlParameter("@DonGia",sanPham.DonGia),
                        new SqlParameter("@SoLuong",sanPham.SoLuong),
                          new SqlParameter("@ChiTietSanPham",sanPham.ChiTietSanPham),
                            new SqlParameter("@LoaiSP",sanPham.LoaiSP),
                            new SqlParameter("@TinhTrang",sanPham.TinhTrang)
            };
            return data.MyExecteNonQuery(ref err, ref rows, "NHP_SanPham_ADD", CommandType.StoredProcedure, param);
        }
        public bool DeleteSanPham(ref string err, ref int rows, SanPham sanPham)
        {
            SqlParameter[] param = new SqlParameter[]{
                new SqlParameter("@id",sanPham.MaSP)
            };
            return data.MyExecteNonQuery(ref err, ref rows, "NHP_SanPham_DeleteByID", CommandType.StoredProcedure, param);
        }
    }
}
