using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using SHOP.Module.BusinessObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace ShopBanGiay.Module.BusinessObjects
{
    [DefaultClassOptions]
    //[ImageName("BO_Contact")]
    [NavigationItem(false)]
    [System.ComponentModel.DisplayName("Chi Tiết Đơn Hàng")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class OrderDetails : BaseObject
    {
        public OrderDetails(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }
        private Orders _Order;
        [XafDisplayName("Đơn Hàng")]
        [Association("Order-OrderDetails")]
        public Orders Order
        {
            get { return _Order; }
            set { SetPropertyValue(nameof(Order), ref _Order, value); }
        }

        private SanPham _Sanpham;
        [XafDisplayName("Sản Phẩm")]
        [Association("SP-Detail")]
        public SanPham Sanpham
        {
            get { return _Sanpham; }
            set { SetPropertyValue(nameof(Sanpham), ref _Sanpham, value); }
        }

        private double _Quantity;
        [XafDisplayName("Số Lượng")]
        public double Quantity
        {
            get { return _Quantity; }
            set
            {
                bool isModified = SetPropertyValue(nameof(Quantity), ref _Quantity, value);
                if (isModified && !IsLoading && !IsDeleted && !IsSaving)
                {
                    Tinhdong();
                }
            }
        }

        private decimal _UnitPrice;
        [XafDisplayName("Đơn Giá")]
        [ModelDefault("DisplayFormat", "{0:### ### ###}")]
        public decimal UnitPrice
        {
            get { return _UnitPrice; }
            set
            {
                bool isModified = SetPropertyValue(nameof(UnitPrice), ref _UnitPrice, value);
                if (isModified && !IsLoading && !IsDeleted && !IsSaving)
                {
                    Tinhdong();
                }
            }
        }
        private double _Discount;
        [XafDisplayName("Chiết Khấu(%)")]

        public double Discount
        {
            get { return _Discount; }
            set
            {
                bool isModified = SetPropertyValue(nameof(Discount), ref _Discount, value);
                if (isModified && !IsLoading && !IsDeleted && !IsSaving)
                {
                    Tinhdong();
                }
            }
        }

        private double _Vat;
        [XafDisplayName("VAT(%)")]
        public double Vat
        {
            get { return _Vat; }
            set
            {
                bool isModified = SetPropertyValue(nameof(Vat), ref _Vat, value);
                if (isModified && !IsLoading && !IsDeleted && !IsSaving)
                {
                    Tinhdong();
                }
            }
        }
        private decimal _Thanhtien;
        [XafDisplayName("Thành tiền"), ModelDefault("AllowEdit", "false")]
        [ModelDefault("DisplayFormat", "{0:### ### ###}")]
        public decimal Thanhtien
        {
            get { return _Thanhtien; }
            set { SetPropertyValue<decimal>(nameof(Thanhtien), ref _Thanhtien, value); }
        }

        private void Tinhdong()
        {
            decimal tien = 0;
            tien = (decimal)Quantity * UnitPrice;
            decimal tienck = (decimal)(Discount / 100) * tien;
            tien -= tienck;
            decimal tienvat = (decimal)(Vat / 100) * tien;
            tien += tienvat;
            Thanhtien = tien;
        }
    }
}