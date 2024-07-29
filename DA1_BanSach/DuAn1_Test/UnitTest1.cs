using NUnit.Framework;
using System;
using WF.BLL.Service;
using WF.DAL.Models;
using WF.DAL.Reposistoris;

namespace DuAn1_Test
{
    [TestFixture]
    public class Tests
    {
        private NhanVien _nv;
        private NhanVienService _service;

        [SetUp]
        public void Setup()
        {
            _nv = new NhanVien();
            _service = new NhanVienService();
        }

        [Test]
        public void ThemMoiTest()
        {
            _nv = new NhanVien("nv10", "luuVanThao", null, "NhanVien1", "NhanVien1", "NhanVien1@gmail.com",
                "087654325678", DateTime.Parse("2003-08-11"), "Nam", "Hà Nội", "0874325674", "Dang Lam", "Nhan Vien");

            var result = _service.Them(_nv);

        }
    }
}
