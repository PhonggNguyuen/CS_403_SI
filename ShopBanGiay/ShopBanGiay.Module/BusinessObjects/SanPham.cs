using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using ShopBanGiay.Module.BusinessObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace SHOP.Module.BusinessObjects
{
    [DefaultClassOptions]
    [System.ComponentModel.DisplayName("Sản Phẩm")]
    //[ImageName("product")]
    [DefaultProperty("TenSP")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class SanPham : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        // Use CodeRush to create XPO classes and properties with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/118557
        public SanPham(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }
        private DanhMucSP _DanhMuc;
        [Association]
        [XafDisplayName("Tên Danh Mục")]
        public DanhMucSP DanhMuc
        {
            get { return _DanhMuc; }
            set { SetPropertyValue<DanhMucSP>(nameof(DanhMuc), ref _DanhMuc, value); }
        }
        private string _Masp;
        [XafDisplayName("Mã"), Size(20)]
        [RuleRequiredField("Yeucau MaSP", DefaultContexts.Save, "Phải có MÃ sản phẩm")]
        [RuleUniqueValue, Indexed(Unique = true)]
        public string Masp
        {
            get { return _Masp; }
            set { SetPropertyValue<string>(nameof(Masp), ref _Masp, value); }
        }
        private string _TenSP;
        [XafDisplayName("Tên hàng"), Size(255)]
        public string TenSP
        {
            get { return _TenSP; }
            set { SetPropertyValue<string>(nameof(TenSP), ref _TenSP, value); }
        }
        private string _Dvt;
        [XafDisplayName("Dvt"), Size(10)]
        public string Dvt
        {
            get { return _Dvt; }
            set { SetPropertyValue<string>(nameof(Dvt), ref _Dvt, value); }
        }

        private double _Vat;
        [XafDisplayName("Vat")]
        public double Vat
        {
            get { return _Vat; }
            set { SetPropertyValue<double>(nameof(Vat), ref _Vat, value); }
        }

        private decimal _Giaban;
        [XafDisplayName("Giá bán")]
        [ModelDefault("DisplayFormat", "{0:### ### ###}")]
        public decimal Giaban
        {
            get { return _Giaban; }
            set { SetPropertyValue<decimal>(nameof(Giaban), ref _Giaban, value); }
        }
        private int _Size;
        [XafDisplayName("Size Giày")]
        public int Size
        {
            get { return _Size; }
            set { SetPropertyValue<int>(nameof(Size), ref _Size, value); }
        }
        private double _Soton;
        [XafDisplayName("Số lượng tồn"), ModelDefault("AllowEdit", "false")]
        [ModelDefault("DisplayFormat", "{0:### ### ###}")]
        public double Soton
        {
            get { return _Soton; }
            set { SetPropertyValue<double>(nameof(Soton), ref _Soton, value); }
        }

        private decimal _Giatriton;
        [XafDisplayName("Giá trị tồn"), ModelDefault("AllowEdit", "false")]
        [ModelDefault("DisplayFormat", "{0:### ### ###}")]
        public decimal Giatriton
        {
            get { return _Giatriton; }
            set { SetPropertyValue<decimal>(nameof(Giatriton), ref _Giatriton, value); }
        }
        private string _Ghichu;
        [XafDisplayName("Ghi chú"), Size(255)]
        public string Ghichu
        {
            get { return _Ghichu; }
            set { SetPropertyValue<string>(nameof(Ghichu), ref _Ghichu, value); }
        }
<<<<<<< HEAD

        [DevExpress.Xpo.Aggregated, Association("SP-Detail")]
        [XafDisplayName("Chi Tiết Sản Phẩm")]
        public XPCollection<OrderDetails> OrderDetailss
        {
            get { return GetCollection<OrderDetails>(nameof(OrderDetailss)); }
        }
        [DevExpress.Xpo.Aggregated, Association("nhap")]
        [XafDisplayName("Nhập")]
        public XPCollection<HDNhapCT> HDNhapCTs
        {
            get { return GetCollection<HDNhapCT>(nameof(HDNhapCTs)); }
        }
        [DevExpress.Xpo.Aggregated, Association("xuat")]
        [XafDisplayName("Xuất")]
        public XPCollection<HDXuatCT> HDXuatCTs
        {
            get { return GetCollection<HDXuatCT>(nameof(HDXuatCTs)); }
        }
=======
>>>>>>> 0492b960c926b21c42e8cd1aaaa0fc018017c254
    }
}