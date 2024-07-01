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
    [System.ComponentModel.DisplayName("Hóa Đơn Nhập")]
    [DefaultProperty("SoCT")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    public class HDNhap : BaseObject
    {
        public HDNhap(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            if (Session.IsNewObject(this))
            {
                NgayCT = DateTime.Now;
            }
        }
        protected override void OnSaving()
        {
            base.OnSaving();
            Tinhtong();
        }

        private NhaCungCap _Khach;
        [XafDisplayName("Nhà Cung Cấp")]
        [Association("NCC-nhap")]
        public NhaCungCap Khach
        {
            get { return _Khach; }
            set { SetPropertyValue<NhaCungCap>(nameof(Khach), ref _Khach, value); }
        }

        private NhanVien _Ketoan;
        [XafDisplayName("Kế toán")]
        [Association("kt-nhap")]
        public NhanVien Ketoan
        {
            get { return _Ketoan; }
            set { SetPropertyValue<NhanVien>(nameof(Ketoan), ref _Ketoan, value); }
        }

        private string _SoCT;
        [XafDisplayName("Số CT"), Size(20), RuleUniqueValue]
        public string SoCT
        {
            get { return _SoCT; }
            set { SetPropertyValue<string>(nameof(SoCT), ref _SoCT, value); }
        }

        private DateTime _NgayCT;
        [XafDisplayName("Ngày CT")]
        [ModelDefault("EditMask", "dd/MM/yyyy HH:mm")]
        [ModelDefault("DisplayFormat", "{0:dd/MM/yyyy HH:mm}")]
        public DateTime NgayCT
        {
            get { return _NgayCT; }
            set { SetPropertyValue<DateTime>(nameof(NgayCT), ref _NgayCT, value); }
        }

        private string _SoHD;
        [XafDisplayName("Số HĐ"), Size(20)]
        public string SoHD
        {
            get { return _SoHD; }
            set { SetPropertyValue<string>(nameof(SoHD), ref _SoHD, value); }
        }

        private DateTime _NgayHD;
        [XafDisplayName("Ngày HĐ")]
        [ModelDefault("EditMask", "dd/MM/yyyy HH:mm")]
        [ModelDefault("DisplayFormat", "{0:dd/MM/yyyy HH:mm}")]
        public DateTime NgayHD
        {
            get { return _NgayHD; }
            set { SetPropertyValue<DateTime>(nameof(NgayHD), ref _NgayHD, value); }
        }

        private string _Ghichu;
        [XafDisplayName("Ghi chú"), Size(255)]
        public string Ghichu
        {
            get { return _Ghichu; }
            set { SetPropertyValue<string>(nameof(Ghichu), ref _Ghichu, value); }
        }

        [DevExpress.Xpo.Aggregated, Association("HDNhap-HDNhapCTs")]
        [XafDisplayName("Hàng nhập")]
        public XPCollection<HDNhapCT> HDNhapCTs
        {
            get { return GetCollection<HDNhapCT>(nameof(HDNhapCTs)); }
        }

        private decimal _Tongtien;
        [XafDisplayName("Tổng tiền"), ModelDefault("AllowEdit", "false")]
        [ModelDefault("DisplayFormat", "{0:### ### ###}")]
        public decimal Tongtien
        {
            get { return _Tongtien; }
            set { SetPropertyValue<decimal>(nameof(Tongtien), ref _Tongtien, value); }
        }

        public void Tinhtong()
        {
            decimal tong = 0;
            foreach (HDNhapCT dong in HDNhapCTs)
            {
                tong += dong.Thanhtien;
            }
            Tongtien = tong;
        }
    }
}
