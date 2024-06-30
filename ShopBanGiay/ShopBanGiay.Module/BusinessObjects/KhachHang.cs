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
    [System.ComponentModel.DisplayName("Khách Hàng")]
    [DefaultProperty("TenKh")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    public class KhachHang : BaseObject
    {
        public KhachHang(Session session)
            : base(session)
        {
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        private string _TenKh;
        [XafDisplayName("Tên Khách Hàng"), Size(255)]
        public string TenKh
        {
            get { return _TenKh; }
            set { SetPropertyValue(nameof(TenKh), ref _TenKh, value); }
        }

        private string _Diachi;
        [XafDisplayName("Địa Chỉ"), Size(255)]
        public string Diachi
        {
            get { return _Diachi; }
            set { SetPropertyValue(nameof(Diachi), ref _Diachi, value); }
        }

        private string _Dienthoai;
        [XafDisplayName("Số Điện Thoại"), Size(20)]
        public string Dienthoai
        {
            get { return _Dienthoai; }
            set { SetPropertyValue(nameof(Dienthoai), ref _Dienthoai, value); }
        }

        private string _Email;
        [XafDisplayName("Email"), Size(255)]
        public string Email
        {
            get { return _Email; }
            set { SetPropertyValue(nameof(Email), ref _Email, value); }
        }

        private string _Ghichu;
        [XafDisplayName("Ghi Chú"), Size(255)]
        public string Ghichu
        {
            get { return _Ghichu; }
            set { SetPropertyValue(nameof(Ghichu), ref _Ghichu, value); }
        }

        [DevExpress.Xpo.Aggregated, Association("khach-order")]
        [XafDisplayName("Đơn Hàng")]
        public XPCollection<Orders> Orders
        {
            get { return GetCollection<Orders>(nameof(Orders)); }
        }
    }
}