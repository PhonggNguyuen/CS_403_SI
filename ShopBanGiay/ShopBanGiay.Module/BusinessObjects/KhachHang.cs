﻿using DevExpress.Data.Filtering;
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
<<<<<<< HEAD
    //[ImageName("BO_Contact")]
    [System.ComponentModel.DisplayName("Khách Hàng")]
    [DefaultProperty("TenKh")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class KhachHang : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        // Use CodeRush to create XPO classes and properties with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/118557
=======
    [System.ComponentModel.DisplayName("Khách Hàng")]
    [DefaultProperty("TenKh")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    public class KhachHang : BaseObject
    {
>>>>>>> 8da419b3f344287931898d903e68c6d2f79e7516
        public KhachHang(Session session)
            : base(session)
        {
        }
<<<<<<< HEAD
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }
        private NhomKhach _Nhom;
        [XafDisplayName("Nhóm")]
        [Association]
        public NhomKhach Nhom
        {
            get { return _Nhom; }
            set { SetPropertyValue<NhomKhach>(nameof(Nhom), ref _Nhom, value); }
=======

        public override void AfterConstruction()
        {
            base.AfterConstruction();
>>>>>>> 8da419b3f344287931898d903e68c6d2f79e7516
        }

        private string _TenKh;
        [XafDisplayName("Tên Khách Hàng"), Size(255)]
        public string TenKh
        {
            get { return _TenKh; }
<<<<<<< HEAD
            set { SetPropertyValue<string>(nameof(TenKh), ref _TenKh, value); }
=======
            set { SetPropertyValue(nameof(TenKh), ref _TenKh, value); }
>>>>>>> 8da419b3f344287931898d903e68c6d2f79e7516
        }

        private string _Diachi;
        [XafDisplayName("Địa Chỉ"), Size(255)]
        public string Diachi
        {
            get { return _Diachi; }
<<<<<<< HEAD
            set { SetPropertyValue<string>(nameof(Diachi), ref _Diachi, value); }
        }

        private string _Dienthoai;
        [XafDisplayName("Số Điện Thoại"), Size(10)]
        public string Dienthoai
        {
            get { return _Dienthoai; }
            set { SetPropertyValue<string>(nameof(Dienthoai), ref _Dienthoai, value); }
        }
=======
            set { SetPropertyValue(nameof(Diachi), ref _Diachi, value); }
        }

        private string _Dienthoai;
        [XafDisplayName("Số Điện Thoại"), Size(20)]
        public string Dienthoai
        {
            get { return _Dienthoai; }
            set { SetPropertyValue(nameof(Dienthoai), ref _Dienthoai, value); }
        }

>>>>>>> 8da419b3f344287931898d903e68c6d2f79e7516
        private string _Email;
        [XafDisplayName("Email"), Size(255)]
        public string Email
        {
            get { return _Email; }
<<<<<<< HEAD
            set { SetPropertyValue<string>(nameof(Email), ref _Email, value); }
        }

        private string _Ghichu;
        [XafDisplayName("Ghi chú"), Size(255)]
        public string Ghichu
        {
            get { return _Ghichu; }
            set { SetPropertyValue<string>(nameof(Ghichu), ref _Ghichu, value); }
        }
        [DevExpress.Xpo.Aggregated, Association("khach-thu")]
        [XafDisplayName("Phiếu Thu")]
        public XPCollection<PhieuThu> Phieuthus
        {
            get { return GetCollection<PhieuThu>(nameof(Phieuthus)); }
        }

        
    
       
=======
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
>>>>>>> 8da419b3f344287931898d903e68c6d2f79e7516
    }
}