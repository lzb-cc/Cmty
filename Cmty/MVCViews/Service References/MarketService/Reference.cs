﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVCViews.MarketService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="GoodsInfo", Namespace="http://schemas.datacontract.org/2004/07/Services.cnts")]
    [System.SerializableAttribute()]
    public partial class GoodsInfo : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime AddDateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string BuyerField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CommentsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DespField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int MoneyField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PicUrlField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SellerField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StatusField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TypeField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime AddDate {
            get {
                return this.AddDateField;
            }
            set {
                if ((this.AddDateField.Equals(value) != true)) {
                    this.AddDateField = value;
                    this.RaisePropertyChanged("AddDate");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Buyer {
            get {
                return this.BuyerField;
            }
            set {
                if ((object.ReferenceEquals(this.BuyerField, value) != true)) {
                    this.BuyerField = value;
                    this.RaisePropertyChanged("Buyer");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Comments {
            get {
                return this.CommentsField;
            }
            set {
                if ((object.ReferenceEquals(this.CommentsField, value) != true)) {
                    this.CommentsField = value;
                    this.RaisePropertyChanged("Comments");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Desp {
            get {
                return this.DespField;
            }
            set {
                if ((object.ReferenceEquals(this.DespField, value) != true)) {
                    this.DespField = value;
                    this.RaisePropertyChanged("Desp");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Money {
            get {
                return this.MoneyField;
            }
            set {
                if ((this.MoneyField.Equals(value) != true)) {
                    this.MoneyField = value;
                    this.RaisePropertyChanged("Money");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PicUrl {
            get {
                return this.PicUrlField;
            }
            set {
                if ((object.ReferenceEquals(this.PicUrlField, value) != true)) {
                    this.PicUrlField = value;
                    this.RaisePropertyChanged("PicUrl");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Seller {
            get {
                return this.SellerField;
            }
            set {
                if ((object.ReferenceEquals(this.SellerField, value) != true)) {
                    this.SellerField = value;
                    this.RaisePropertyChanged("Seller");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Status {
            get {
                return this.StatusField;
            }
            set {
                if ((object.ReferenceEquals(this.StatusField, value) != true)) {
                    this.StatusField = value;
                    this.RaisePropertyChanged("Status");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Type {
            get {
                return this.TypeField;
            }
            set {
                if ((object.ReferenceEquals(this.TypeField, value) != true)) {
                    this.TypeField = value;
                    this.RaisePropertyChanged("Type");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="MarketService.IMarketService")]
    public interface IMarketService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMarketService/UserAddGoods", ReplyAction="http://tempuri.org/IMarketService/UserAddGoodsResponse")]
        CommonLib.ReturnState UserAddGoods(MVCViews.MarketService.GoodsInfo model);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMarketService/UserAddGoods", ReplyAction="http://tempuri.org/IMarketService/UserAddGoodsResponse")]
        System.Threading.Tasks.Task<CommonLib.ReturnState> UserAddGoodsAsync(MVCViews.MarketService.GoodsInfo model);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMarketService/GetGoodsInfoBySellerAndDate", ReplyAction="http://tempuri.org/IMarketService/GetGoodsInfoBySellerAndDateResponse")]
        MVCViews.MarketService.GoodsInfo GetGoodsInfoBySellerAndDate(string seller, System.DateTime date);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMarketService/GetGoodsInfoBySellerAndDate", ReplyAction="http://tempuri.org/IMarketService/GetGoodsInfoBySellerAndDateResponse")]
        System.Threading.Tasks.Task<MVCViews.MarketService.GoodsInfo> GetGoodsInfoBySellerAndDateAsync(string seller, System.DateTime date);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMarketService/GetGoodsInfoById", ReplyAction="http://tempuri.org/IMarketService/GetGoodsInfoByIdResponse")]
        MVCViews.MarketService.GoodsInfo GetGoodsInfoById(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMarketService/GetGoodsInfoById", ReplyAction="http://tempuri.org/IMarketService/GetGoodsInfoByIdResponse")]
        System.Threading.Tasks.Task<MVCViews.MarketService.GoodsInfo> GetGoodsInfoByIdAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMarketService/GetGoodsInfoListBySeller", ReplyAction="http://tempuri.org/IMarketService/GetGoodsInfoListBySellerResponse")]
        MVCViews.MarketService.GoodsInfo[] GetGoodsInfoListBySeller(string seller);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMarketService/GetGoodsInfoListBySeller", ReplyAction="http://tempuri.org/IMarketService/GetGoodsInfoListBySellerResponse")]
        System.Threading.Tasks.Task<MVCViews.MarketService.GoodsInfo[]> GetGoodsInfoListBySellerAsync(string seller);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMarketService/GetGoodsInfoListByBuyer", ReplyAction="http://tempuri.org/IMarketService/GetGoodsInfoListByBuyerResponse")]
        MVCViews.MarketService.GoodsInfo[] GetGoodsInfoListByBuyer(string buyer);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMarketService/GetGoodsInfoListByBuyer", ReplyAction="http://tempuri.org/IMarketService/GetGoodsInfoListByBuyerResponse")]
        System.Threading.Tasks.Task<MVCViews.MarketService.GoodsInfo[]> GetGoodsInfoListByBuyerAsync(string buyer);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMarketService/GetGoodsInfoOnSale", ReplyAction="http://tempuri.org/IMarketService/GetGoodsInfoOnSaleResponse")]
        MVCViews.MarketService.GoodsInfo[] GetGoodsInfoOnSale();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMarketService/GetGoodsInfoOnSale", ReplyAction="http://tempuri.org/IMarketService/GetGoodsInfoOnSaleResponse")]
        System.Threading.Tasks.Task<MVCViews.MarketService.GoodsInfo[]> GetGoodsInfoOnSaleAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMarketService/GetGoodsInfoByStatus", ReplyAction="http://tempuri.org/IMarketService/GetGoodsInfoByStatusResponse")]
        MVCViews.MarketService.GoodsInfo[] GetGoodsInfoByStatus(string status);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMarketService/GetGoodsInfoByStatus", ReplyAction="http://tempuri.org/IMarketService/GetGoodsInfoByStatusResponse")]
        System.Threading.Tasks.Task<MVCViews.MarketService.GoodsInfo[]> GetGoodsInfoByStatusAsync(string status);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMarketService/SetGoodsInfoStatusById", ReplyAction="http://tempuri.org/IMarketService/SetGoodsInfoStatusByIdResponse")]
        CommonLib.ReturnState SetGoodsInfoStatusById(int id, string status);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMarketService/SetGoodsInfoStatusById", ReplyAction="http://tempuri.org/IMarketService/SetGoodsInfoStatusByIdResponse")]
        System.Threading.Tasks.Task<CommonLib.ReturnState> SetGoodsInfoStatusByIdAsync(int id, string status);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMarketService/GetAllGoodsInfo", ReplyAction="http://tempuri.org/IMarketService/GetAllGoodsInfoResponse")]
        MVCViews.MarketService.GoodsInfo[] GetAllGoodsInfo();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMarketService/GetAllGoodsInfo", ReplyAction="http://tempuri.org/IMarketService/GetAllGoodsInfoResponse")]
        System.Threading.Tasks.Task<MVCViews.MarketService.GoodsInfo[]> GetAllGoodsInfoAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMarketService/HasMember", ReplyAction="http://tempuri.org/IMarketService/HasMemberResponse")]
        bool HasMember(MVCViews.MarketService.GoodsInfo model);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMarketService/HasMember", ReplyAction="http://tempuri.org/IMarketService/HasMemberResponse")]
        System.Threading.Tasks.Task<bool> HasMemberAsync(MVCViews.MarketService.GoodsInfo model);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMarketService/SetGoodsInfoSaleStatusAndBuyerById", ReplyAction="http://tempuri.org/IMarketService/SetGoodsInfoSaleStatusAndBuyerByIdResponse")]
        CommonLib.ReturnState SetGoodsInfoSaleStatusAndBuyerById(int id, string staus, string buyer);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMarketService/SetGoodsInfoSaleStatusAndBuyerById", ReplyAction="http://tempuri.org/IMarketService/SetGoodsInfoSaleStatusAndBuyerByIdResponse")]
        System.Threading.Tasks.Task<CommonLib.ReturnState> SetGoodsInfoSaleStatusAndBuyerByIdAsync(int id, string staus, string buyer);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMarketService/RemoveGoodsInfo", ReplyAction="http://tempuri.org/IMarketService/RemoveGoodsInfoResponse")]
        CommonLib.ReturnState RemoveGoodsInfo(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMarketService/RemoveGoodsInfo", ReplyAction="http://tempuri.org/IMarketService/RemoveGoodsInfoResponse")]
        System.Threading.Tasks.Task<CommonLib.ReturnState> RemoveGoodsInfoAsync(int id);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IMarketServiceChannel : MVCViews.MarketService.IMarketService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class MarketServiceClient : System.ServiceModel.ClientBase<MVCViews.MarketService.IMarketService>, MVCViews.MarketService.IMarketService {
        
        public MarketServiceClient() {
        }
        
        public MarketServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public MarketServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MarketServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MarketServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public CommonLib.ReturnState UserAddGoods(MVCViews.MarketService.GoodsInfo model) {
            return base.Channel.UserAddGoods(model);
        }
        
        public System.Threading.Tasks.Task<CommonLib.ReturnState> UserAddGoodsAsync(MVCViews.MarketService.GoodsInfo model) {
            return base.Channel.UserAddGoodsAsync(model);
        }
        
        public MVCViews.MarketService.GoodsInfo GetGoodsInfoBySellerAndDate(string seller, System.DateTime date) {
            return base.Channel.GetGoodsInfoBySellerAndDate(seller, date);
        }
        
        public System.Threading.Tasks.Task<MVCViews.MarketService.GoodsInfo> GetGoodsInfoBySellerAndDateAsync(string seller, System.DateTime date) {
            return base.Channel.GetGoodsInfoBySellerAndDateAsync(seller, date);
        }
        
        public MVCViews.MarketService.GoodsInfo GetGoodsInfoById(int id) {
            return base.Channel.GetGoodsInfoById(id);
        }
        
        public System.Threading.Tasks.Task<MVCViews.MarketService.GoodsInfo> GetGoodsInfoByIdAsync(int id) {
            return base.Channel.GetGoodsInfoByIdAsync(id);
        }
        
        public MVCViews.MarketService.GoodsInfo[] GetGoodsInfoListBySeller(string seller) {
            return base.Channel.GetGoodsInfoListBySeller(seller);
        }
        
        public System.Threading.Tasks.Task<MVCViews.MarketService.GoodsInfo[]> GetGoodsInfoListBySellerAsync(string seller) {
            return base.Channel.GetGoodsInfoListBySellerAsync(seller);
        }
        
        public MVCViews.MarketService.GoodsInfo[] GetGoodsInfoListByBuyer(string buyer) {
            return base.Channel.GetGoodsInfoListByBuyer(buyer);
        }
        
        public System.Threading.Tasks.Task<MVCViews.MarketService.GoodsInfo[]> GetGoodsInfoListByBuyerAsync(string buyer) {
            return base.Channel.GetGoodsInfoListByBuyerAsync(buyer);
        }
        
        public MVCViews.MarketService.GoodsInfo[] GetGoodsInfoOnSale() {
            return base.Channel.GetGoodsInfoOnSale();
        }
        
        public System.Threading.Tasks.Task<MVCViews.MarketService.GoodsInfo[]> GetGoodsInfoOnSaleAsync() {
            return base.Channel.GetGoodsInfoOnSaleAsync();
        }
        
        public MVCViews.MarketService.GoodsInfo[] GetGoodsInfoByStatus(string status) {
            return base.Channel.GetGoodsInfoByStatus(status);
        }
        
        public System.Threading.Tasks.Task<MVCViews.MarketService.GoodsInfo[]> GetGoodsInfoByStatusAsync(string status) {
            return base.Channel.GetGoodsInfoByStatusAsync(status);
        }
        
        public CommonLib.ReturnState SetGoodsInfoStatusById(int id, string status) {
            return base.Channel.SetGoodsInfoStatusById(id, status);
        }
        
        public System.Threading.Tasks.Task<CommonLib.ReturnState> SetGoodsInfoStatusByIdAsync(int id, string status) {
            return base.Channel.SetGoodsInfoStatusByIdAsync(id, status);
        }
        
        public MVCViews.MarketService.GoodsInfo[] GetAllGoodsInfo() {
            return base.Channel.GetAllGoodsInfo();
        }
        
        public System.Threading.Tasks.Task<MVCViews.MarketService.GoodsInfo[]> GetAllGoodsInfoAsync() {
            return base.Channel.GetAllGoodsInfoAsync();
        }
        
        public bool HasMember(MVCViews.MarketService.GoodsInfo model) {
            return base.Channel.HasMember(model);
        }
        
        public System.Threading.Tasks.Task<bool> HasMemberAsync(MVCViews.MarketService.GoodsInfo model) {
            return base.Channel.HasMemberAsync(model);
        }
        
        public CommonLib.ReturnState SetGoodsInfoSaleStatusAndBuyerById(int id, string staus, string buyer) {
            return base.Channel.SetGoodsInfoSaleStatusAndBuyerById(id, staus, buyer);
        }
        
        public System.Threading.Tasks.Task<CommonLib.ReturnState> SetGoodsInfoSaleStatusAndBuyerByIdAsync(int id, string staus, string buyer) {
            return base.Channel.SetGoodsInfoSaleStatusAndBuyerByIdAsync(id, staus, buyer);
        }
        
        public CommonLib.ReturnState RemoveGoodsInfo(int id) {
            return base.Channel.RemoveGoodsInfo(id);
        }
        
        public System.Threading.Tasks.Task<CommonLib.ReturnState> RemoveGoodsInfoAsync(int id) {
            return base.Channel.RemoveGoodsInfoAsync(id);
        }
    }
}
