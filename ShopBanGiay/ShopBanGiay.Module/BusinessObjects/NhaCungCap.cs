using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace ShopBanGiay.Module.BusinessObjects
{
    [DefaultClassOptions]
    [System.ComponentModel.DisplayName("Nhà Cung Cấp")]
    [DefaultProperty("TenNCC")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    public class NhaCungCap : BaseObject
    {
        public NhaCungCap(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        private NhomNCC _Nhom;
        [XafDisplayName("Nhóm")]
        public NhomNCC Nhom
        {
            get { return _Nhom; }
            set { SetPropertyValue<NhomNCC>(nameof(Nhom), ref _Nhom, value); }
        }

        private string _TenNCC;
        [XafDisplayName("Tên Nhà Cung Cấp"), Size(255)]
        public string TenNCC
        {
            get { return _TenNCC; }
            set { SetPropertyValue<string>(nameof(TenNCC), ref _TenNCC, value); }
        }

        private string _Diachi;
        [XafDisplayName("Địa Chỉ"), Size(255)]
        public string Diachi
        {
            get { return _Diachi; }
            set { SetPropertyValue<string>(nameof(Diachi), ref _Diachi, value); }
        }

        private string _Dienthoai;
        [XafDisplayName("Số Điện Thoại"), Size(10)]
        public string Dienthoai
        {
            get { return _Dienthoai; }
            set { SetPropertyValue<string>(nameof(Dienthoai), ref _Dienthoai, value); }
        }

        private string _Email;
        [XafDisplayName("Email"), Size(255)]
        public string Email
        {
            get { return _Email; }
            set { SetPropertyValue<string>(nameof(Email), ref _Email, value); }
        }

        private string _Ghichu;
        [XafDisplayName("Ghi chú"), Size(255)]
        public string Ghichu
        {
            get { return _Ghichu; }
            set { SetPropertyValue<string>(nameof(Ghichu), ref _Ghichu, value); }
        }

        [DevExpress.Xpo.Aggregated, Association("NCC-chi")]
        [XafDisplayName("Phiếu chi")]
        public XPCollection<PhieuChi> Phieuchis
        {
            get { return GetCollection<PhieuChi>(nameof(Phieuchis)); }
        }

        [DevExpress.Xpo.Aggregated, Association("NCC-thu")]
        [XafDisplayName("Phiếu Thu")]
        public XPCollection<PhieuThu> Phieuthus
        {
            get { return GetCollection<PhieuThu>(nameof(Phieuthus)); }
        }

        [DevExpress.Xpo.Aggregated, Association("NCC-nhap")]
        [XafDisplayName("Phiếu nhập")]
        public XPCollection<HDNhap> HDNhaps
        {
            get { return GetCollection<HDNhap>(nameof(HDNhaps)); }
        }

        [DevExpress.Xpo.Aggregated, Association("NCC-xuat")]
        [XafDisplayName("Phiếu xuất")]
        public XPCollection<HDXuat> HDXuats
        {
            get { return GetCollection<HDXuat>(nameof(HDXuats)); }
        }
    }
}