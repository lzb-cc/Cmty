﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVCViews.AccountService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="RegisterView", Namespace="http://schemas.datacontract.org/2004/07/Services")]
    [System.SerializableAttribute()]
    public partial class RegisterView : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string EmailField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PasswordField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TelField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UserNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int UserTypeField;
        
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
        public string Email {
            get {
                return this.EmailField;
            }
            set {
                if ((object.ReferenceEquals(this.EmailField, value) != true)) {
                    this.EmailField = value;
                    this.RaisePropertyChanged("Email");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Password {
            get {
                return this.PasswordField;
            }
            set {
                if ((object.ReferenceEquals(this.PasswordField, value) != true)) {
                    this.PasswordField = value;
                    this.RaisePropertyChanged("Password");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Tel {
            get {
                return this.TelField;
            }
            set {
                if ((object.ReferenceEquals(this.TelField, value) != true)) {
                    this.TelField = value;
                    this.RaisePropertyChanged("Tel");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string UserName {
            get {
                return this.UserNameField;
            }
            set {
                if ((object.ReferenceEquals(this.UserNameField, value) != true)) {
                    this.UserNameField = value;
                    this.RaisePropertyChanged("UserName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int UserType {
            get {
                return this.UserTypeField;
            }
            set {
                if ((this.UserTypeField.Equals(value) != true)) {
                    this.UserTypeField = value;
                    this.RaisePropertyChanged("UserType");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="AccountService.IAccountService")]
    public interface IAccountService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAccountService/Register", ReplyAction="http://tempuri.org/IAccountService/RegisterResponse")]
        CommonLib.ReturnState Register([System.ServiceModel.MessageParameterAttribute(Name="register")] MVCViews.AccountService.RegisterView register1);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAccountService/Register", ReplyAction="http://tempuri.org/IAccountService/RegisterResponse")]
        System.Threading.Tasks.Task<CommonLib.ReturnState> RegisterAsync(MVCViews.AccountService.RegisterView register);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IAccountServiceChannel : MVCViews.AccountService.IAccountService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class AccountServiceClient : System.ServiceModel.ClientBase<MVCViews.AccountService.IAccountService>, MVCViews.AccountService.IAccountService {
        
        public AccountServiceClient() {
        }
        
        public AccountServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public AccountServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AccountServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AccountServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public CommonLib.ReturnState Register(MVCViews.AccountService.RegisterView register1) {
            return base.Channel.Register(register1);
        }
        
        public System.Threading.Tasks.Task<CommonLib.ReturnState> RegisterAsync(MVCViews.AccountService.RegisterView register) {
            return base.Channel.RegisterAsync(register);
        }
    }
}
