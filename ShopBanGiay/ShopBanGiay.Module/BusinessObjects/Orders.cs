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
    [System.ComponentModel.DisplayName("Đơn Hàng")]
    [DefaultProperty("OrderNumber")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    public class Orders : BaseObject
    {
        public Orders(Session session)
            : base(session)
        {
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
            if (Session.IsNewObject(this))
            {
                OrderDate = DateTime.Now;
            }
        }
        protected override void OnSaving()
        {
            base.OnSaving();
            Tinhtong();
        }
        private KhachHang _KhachHang;
        [XafDisplayName("Khách Hàng")]
        [Association("khach-order")]
        public KhachHang KhachHang
        {
            get { return _KhachHang; }
            set { SetPropertyValue(nameof(KhachHang), ref _KhachHang, value); }
        }

        private DateTime _OrderDate;
        [XafDisplayName("Ngày Đặt Hàng")]
        [ModelDefault("EditMask", "dd/MM/yyyy HH:mm")]
        [ModelDefault("DisplayFormat", "{0:dd/MM/yyyy HH:mm}")]
        public DateTime OrderDate
        {
            get { return _OrderDate; }
            set { SetPropertyValue(nameof(OrderDate), ref _OrderDate, value); }
        }

        private string _OrderNumber;
        [XafDisplayName("Số Đơn Hàng"), Size(20)]
        public string OrderNumber
        {
            get { return _OrderNumber; }
            set { SetPropertyValue(nameof(OrderNumber), ref _OrderNumber, value); }
        }

        private string _Status;
        [XafDisplayName("Trạng Thái"), Size(50)]
        public string Status
        {
            get { return _Status; }
            set { SetPropertyValue(nameof(Status), ref _Status, value); }
        }

        private string _Notes;
        [XafDisplayName("Ghi Chú"), Size(255)]
        public string Notes
        {
            get { return _Notes; }
            set { SetPropertyValue(nameof(Notes), ref _Notes, value); }
        }

        [DevExpress.Xpo.Aggregated, Association("Order-OrderDetails")]
        [XafDisplayName("Chi Tiết Đơn Hàng")]
        public XPCollection<OrderDetails> OrderDetailss
        {
            get { return GetCollection<OrderDetails>(nameof(OrderDetailss)); }
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
            foreach (OrderDetails dong in OrderDetailss)
            {
                tong += dong.Thanhtien;
            }
            Tongtien = tong;
        }
    }
}