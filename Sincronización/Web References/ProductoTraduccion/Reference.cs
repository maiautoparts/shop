﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// Microsoft.VSDesigner generó automáticamente este código fuente, versión=4.0.30319.42000.
// 
#pragma warning disable 1591

namespace Sincronización.ProductoTraduccion {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.79.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="ProductoTraduccion_Binding", Namespace="urn:microsoft-dynamics-schemas/page/productotraduccion")]
    public partial class ProductoTraduccion_Service : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback ReadOperationCompleted;
        
        private System.Threading.SendOrPostCallback ReadByRecIdOperationCompleted;
        
        private System.Threading.SendOrPostCallback ReadMultipleOperationCompleted;
        
        private System.Threading.SendOrPostCallback IsUpdatedOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetRecIdFromKeyOperationCompleted;
        
        private System.Threading.SendOrPostCallback CreateOperationCompleted;
        
        private System.Threading.SendOrPostCallback CreateMultipleOperationCompleted;
        
        private System.Threading.SendOrPostCallback UpdateOperationCompleted;
        
        private System.Threading.SendOrPostCallback UpdateMultipleOperationCompleted;
        
        private System.Threading.SendOrPostCallback DeleteOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public ProductoTraduccion_Service() {
            this.Url = global::Sincronización.Properties.Settings.Default.Sincronización_ProductoTraduccion_ProductoTraduccion_Service;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event ReadCompletedEventHandler ReadCompleted;
        
        /// <remarks/>
        public event ReadByRecIdCompletedEventHandler ReadByRecIdCompleted;
        
        /// <remarks/>
        public event ReadMultipleCompletedEventHandler ReadMultipleCompleted;
        
        /// <remarks/>
        public event IsUpdatedCompletedEventHandler IsUpdatedCompleted;
        
        /// <remarks/>
        public event GetRecIdFromKeyCompletedEventHandler GetRecIdFromKeyCompleted;
        
        /// <remarks/>
        public event CreateCompletedEventHandler CreateCompleted;
        
        /// <remarks/>
        public event CreateMultipleCompletedEventHandler CreateMultipleCompleted;
        
        /// <remarks/>
        public event UpdateCompletedEventHandler UpdateCompleted;
        
        /// <remarks/>
        public event UpdateMultipleCompletedEventHandler UpdateMultipleCompleted;
        
        /// <remarks/>
        public event DeleteCompletedEventHandler DeleteCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:microsoft-dynamics-schemas/page/productotraduccion:Read", RequestNamespace="urn:microsoft-dynamics-schemas/page/productotraduccion", ResponseElementName="Read_Result", ResponseNamespace="urn:microsoft-dynamics-schemas/page/productotraduccion", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("ProductoTraduccion")]
        public ProductoTraduccion Read(string Item_No, string Variant_Code, string Language_Code) {
            object[] results = this.Invoke("Read", new object[] {
                        Item_No,
                        Variant_Code,
                        Language_Code});
            return ((ProductoTraduccion)(results[0]));
        }
        
        /// <remarks/>
        public void ReadAsync(string Item_No, string Variant_Code, string Language_Code) {
            this.ReadAsync(Item_No, Variant_Code, Language_Code, null);
        }
        
        /// <remarks/>
        public void ReadAsync(string Item_No, string Variant_Code, string Language_Code, object userState) {
            if ((this.ReadOperationCompleted == null)) {
                this.ReadOperationCompleted = new System.Threading.SendOrPostCallback(this.OnReadOperationCompleted);
            }
            this.InvokeAsync("Read", new object[] {
                        Item_No,
                        Variant_Code,
                        Language_Code}, this.ReadOperationCompleted, userState);
        }
        
        private void OnReadOperationCompleted(object arg) {
            if ((this.ReadCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ReadCompleted(this, new ReadCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:microsoft-dynamics-schemas/page/productotraduccion:ReadByRecId", RequestNamespace="urn:microsoft-dynamics-schemas/page/productotraduccion", ResponseElementName="ReadByRecId_Result", ResponseNamespace="urn:microsoft-dynamics-schemas/page/productotraduccion", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("ProductoTraduccion")]
        public ProductoTraduccion ReadByRecId(string recId) {
            object[] results = this.Invoke("ReadByRecId", new object[] {
                        recId});
            return ((ProductoTraduccion)(results[0]));
        }
        
        /// <remarks/>
        public void ReadByRecIdAsync(string recId) {
            this.ReadByRecIdAsync(recId, null);
        }
        
        /// <remarks/>
        public void ReadByRecIdAsync(string recId, object userState) {
            if ((this.ReadByRecIdOperationCompleted == null)) {
                this.ReadByRecIdOperationCompleted = new System.Threading.SendOrPostCallback(this.OnReadByRecIdOperationCompleted);
            }
            this.InvokeAsync("ReadByRecId", new object[] {
                        recId}, this.ReadByRecIdOperationCompleted, userState);
        }
        
        private void OnReadByRecIdOperationCompleted(object arg) {
            if ((this.ReadByRecIdCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ReadByRecIdCompleted(this, new ReadByRecIdCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:microsoft-dynamics-schemas/page/productotraduccion:ReadMultiple", RequestNamespace="urn:microsoft-dynamics-schemas/page/productotraduccion", ResponseElementName="ReadMultiple_Result", ResponseNamespace="urn:microsoft-dynamics-schemas/page/productotraduccion", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlArrayAttribute("ReadMultiple_Result")]
        [return: System.Xml.Serialization.XmlArrayItemAttribute(IsNullable=false)]
        public ProductoTraduccion[] ReadMultiple([System.Xml.Serialization.XmlElementAttribute("filter")] ProductoTraduccion_Filter[] filter, string bookmarkKey, int setSize) {
            object[] results = this.Invoke("ReadMultiple", new object[] {
                        filter,
                        bookmarkKey,
                        setSize});
            return ((ProductoTraduccion[])(results[0]));
        }
        
        /// <remarks/>
        public void ReadMultipleAsync(ProductoTraduccion_Filter[] filter, string bookmarkKey, int setSize) {
            this.ReadMultipleAsync(filter, bookmarkKey, setSize, null);
        }
        
        /// <remarks/>
        public void ReadMultipleAsync(ProductoTraduccion_Filter[] filter, string bookmarkKey, int setSize, object userState) {
            if ((this.ReadMultipleOperationCompleted == null)) {
                this.ReadMultipleOperationCompleted = new System.Threading.SendOrPostCallback(this.OnReadMultipleOperationCompleted);
            }
            this.InvokeAsync("ReadMultiple", new object[] {
                        filter,
                        bookmarkKey,
                        setSize}, this.ReadMultipleOperationCompleted, userState);
        }
        
        private void OnReadMultipleOperationCompleted(object arg) {
            if ((this.ReadMultipleCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ReadMultipleCompleted(this, new ReadMultipleCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:microsoft-dynamics-schemas/page/productotraduccion:IsUpdated", RequestNamespace="urn:microsoft-dynamics-schemas/page/productotraduccion", ResponseElementName="IsUpdated_Result", ResponseNamespace="urn:microsoft-dynamics-schemas/page/productotraduccion", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("IsUpdated_Result")]
        public bool IsUpdated(string Key) {
            object[] results = this.Invoke("IsUpdated", new object[] {
                        Key});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void IsUpdatedAsync(string Key) {
            this.IsUpdatedAsync(Key, null);
        }
        
        /// <remarks/>
        public void IsUpdatedAsync(string Key, object userState) {
            if ((this.IsUpdatedOperationCompleted == null)) {
                this.IsUpdatedOperationCompleted = new System.Threading.SendOrPostCallback(this.OnIsUpdatedOperationCompleted);
            }
            this.InvokeAsync("IsUpdated", new object[] {
                        Key}, this.IsUpdatedOperationCompleted, userState);
        }
        
        private void OnIsUpdatedOperationCompleted(object arg) {
            if ((this.IsUpdatedCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.IsUpdatedCompleted(this, new IsUpdatedCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:microsoft-dynamics-schemas/page/productotraduccion:GetRecIdFromKey", RequestNamespace="urn:microsoft-dynamics-schemas/page/productotraduccion", ResponseElementName="GetRecIdFromKey_Result", ResponseNamespace="urn:microsoft-dynamics-schemas/page/productotraduccion", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("GetRecIdFromKey_Result")]
        public string GetRecIdFromKey(string Key) {
            object[] results = this.Invoke("GetRecIdFromKey", new object[] {
                        Key});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void GetRecIdFromKeyAsync(string Key) {
            this.GetRecIdFromKeyAsync(Key, null);
        }
        
        /// <remarks/>
        public void GetRecIdFromKeyAsync(string Key, object userState) {
            if ((this.GetRecIdFromKeyOperationCompleted == null)) {
                this.GetRecIdFromKeyOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetRecIdFromKeyOperationCompleted);
            }
            this.InvokeAsync("GetRecIdFromKey", new object[] {
                        Key}, this.GetRecIdFromKeyOperationCompleted, userState);
        }
        
        private void OnGetRecIdFromKeyOperationCompleted(object arg) {
            if ((this.GetRecIdFromKeyCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetRecIdFromKeyCompleted(this, new GetRecIdFromKeyCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:microsoft-dynamics-schemas/page/productotraduccion:Create", RequestNamespace="urn:microsoft-dynamics-schemas/page/productotraduccion", ResponseElementName="Create_Result", ResponseNamespace="urn:microsoft-dynamics-schemas/page/productotraduccion", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void Create(ref ProductoTraduccion ProductoTraduccion) {
            object[] results = this.Invoke("Create", new object[] {
                        ProductoTraduccion});
            ProductoTraduccion = ((ProductoTraduccion)(results[0]));
        }
        
        /// <remarks/>
        public void CreateAsync(ProductoTraduccion ProductoTraduccion) {
            this.CreateAsync(ProductoTraduccion, null);
        }
        
        /// <remarks/>
        public void CreateAsync(ProductoTraduccion ProductoTraduccion, object userState) {
            if ((this.CreateOperationCompleted == null)) {
                this.CreateOperationCompleted = new System.Threading.SendOrPostCallback(this.OnCreateOperationCompleted);
            }
            this.InvokeAsync("Create", new object[] {
                        ProductoTraduccion}, this.CreateOperationCompleted, userState);
        }
        
        private void OnCreateOperationCompleted(object arg) {
            if ((this.CreateCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.CreateCompleted(this, new CreateCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:microsoft-dynamics-schemas/page/productotraduccion:CreateMultiple", RequestNamespace="urn:microsoft-dynamics-schemas/page/productotraduccion", ResponseElementName="CreateMultiple_Result", ResponseNamespace="urn:microsoft-dynamics-schemas/page/productotraduccion", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void CreateMultiple([System.Xml.Serialization.XmlArrayItemAttribute(IsNullable=false)] ref ProductoTraduccion[] ProductoTraduccion_List) {
            object[] results = this.Invoke("CreateMultiple", new object[] {
                        ProductoTraduccion_List});
            ProductoTraduccion_List = ((ProductoTraduccion[])(results[0]));
        }
        
        /// <remarks/>
        public void CreateMultipleAsync(ProductoTraduccion[] ProductoTraduccion_List) {
            this.CreateMultipleAsync(ProductoTraduccion_List, null);
        }
        
        /// <remarks/>
        public void CreateMultipleAsync(ProductoTraduccion[] ProductoTraduccion_List, object userState) {
            if ((this.CreateMultipleOperationCompleted == null)) {
                this.CreateMultipleOperationCompleted = new System.Threading.SendOrPostCallback(this.OnCreateMultipleOperationCompleted);
            }
            this.InvokeAsync("CreateMultiple", new object[] {
                        ProductoTraduccion_List}, this.CreateMultipleOperationCompleted, userState);
        }
        
        private void OnCreateMultipleOperationCompleted(object arg) {
            if ((this.CreateMultipleCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.CreateMultipleCompleted(this, new CreateMultipleCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:microsoft-dynamics-schemas/page/productotraduccion:Update", RequestNamespace="urn:microsoft-dynamics-schemas/page/productotraduccion", ResponseElementName="Update_Result", ResponseNamespace="urn:microsoft-dynamics-schemas/page/productotraduccion", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void Update(ref ProductoTraduccion ProductoTraduccion) {
            object[] results = this.Invoke("Update", new object[] {
                        ProductoTraduccion});
            ProductoTraduccion = ((ProductoTraduccion)(results[0]));
        }
        
        /// <remarks/>
        public void UpdateAsync(ProductoTraduccion ProductoTraduccion) {
            this.UpdateAsync(ProductoTraduccion, null);
        }
        
        /// <remarks/>
        public void UpdateAsync(ProductoTraduccion ProductoTraduccion, object userState) {
            if ((this.UpdateOperationCompleted == null)) {
                this.UpdateOperationCompleted = new System.Threading.SendOrPostCallback(this.OnUpdateOperationCompleted);
            }
            this.InvokeAsync("Update", new object[] {
                        ProductoTraduccion}, this.UpdateOperationCompleted, userState);
        }
        
        private void OnUpdateOperationCompleted(object arg) {
            if ((this.UpdateCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.UpdateCompleted(this, new UpdateCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:microsoft-dynamics-schemas/page/productotraduccion:UpdateMultiple", RequestNamespace="urn:microsoft-dynamics-schemas/page/productotraduccion", ResponseElementName="UpdateMultiple_Result", ResponseNamespace="urn:microsoft-dynamics-schemas/page/productotraduccion", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void UpdateMultiple([System.Xml.Serialization.XmlArrayItemAttribute(IsNullable=false)] ref ProductoTraduccion[] ProductoTraduccion_List) {
            object[] results = this.Invoke("UpdateMultiple", new object[] {
                        ProductoTraduccion_List});
            ProductoTraduccion_List = ((ProductoTraduccion[])(results[0]));
        }
        
        /// <remarks/>
        public void UpdateMultipleAsync(ProductoTraduccion[] ProductoTraduccion_List) {
            this.UpdateMultipleAsync(ProductoTraduccion_List, null);
        }
        
        /// <remarks/>
        public void UpdateMultipleAsync(ProductoTraduccion[] ProductoTraduccion_List, object userState) {
            if ((this.UpdateMultipleOperationCompleted == null)) {
                this.UpdateMultipleOperationCompleted = new System.Threading.SendOrPostCallback(this.OnUpdateMultipleOperationCompleted);
            }
            this.InvokeAsync("UpdateMultiple", new object[] {
                        ProductoTraduccion_List}, this.UpdateMultipleOperationCompleted, userState);
        }
        
        private void OnUpdateMultipleOperationCompleted(object arg) {
            if ((this.UpdateMultipleCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.UpdateMultipleCompleted(this, new UpdateMultipleCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:microsoft-dynamics-schemas/page/productotraduccion:Delete", RequestNamespace="urn:microsoft-dynamics-schemas/page/productotraduccion", ResponseElementName="Delete_Result", ResponseNamespace="urn:microsoft-dynamics-schemas/page/productotraduccion", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("Delete_Result")]
        public bool Delete(string Key) {
            object[] results = this.Invoke("Delete", new object[] {
                        Key});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void DeleteAsync(string Key) {
            this.DeleteAsync(Key, null);
        }
        
        /// <remarks/>
        public void DeleteAsync(string Key, object userState) {
            if ((this.DeleteOperationCompleted == null)) {
                this.DeleteOperationCompleted = new System.Threading.SendOrPostCallback(this.OnDeleteOperationCompleted);
            }
            this.InvokeAsync("Delete", new object[] {
                        Key}, this.DeleteOperationCompleted, userState);
        }
        
        private void OnDeleteOperationCompleted(object arg) {
            if ((this.DeleteCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.DeleteCompleted(this, new DeleteCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:microsoft-dynamics-schemas/page/productotraduccion")]
    public partial class ProductoTraduccion {
        
        private string keyField;
        
        private string item_NoField;
        
        private string variant_CodeField;
        
        private string language_CodeField;
        
        private string descriptionField;
        
        private string description_2Field;
        
        /// <comentarios/>
        public string Key {
            get {
                return this.keyField;
            }
            set {
                this.keyField = value;
            }
        }
        
        /// <comentarios/>
        public string Item_No {
            get {
                return this.item_NoField;
            }
            set {
                this.item_NoField = value;
            }
        }
        
        /// <comentarios/>
        public string Variant_Code {
            get {
                return this.variant_CodeField;
            }
            set {
                this.variant_CodeField = value;
            }
        }
        
        /// <comentarios/>
        public string Language_Code {
            get {
                return this.language_CodeField;
            }
            set {
                this.language_CodeField = value;
            }
        }
        
        /// <comentarios/>
        public string Description {
            get {
                return this.descriptionField;
            }
            set {
                this.descriptionField = value;
            }
        }
        
        /// <comentarios/>
        public string Description_2 {
            get {
                return this.description_2Field;
            }
            set {
                this.description_2Field = value;
            }
        }
    }
    
    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:microsoft-dynamics-schemas/page/productotraduccion")]
    public partial class ProductoTraduccion_Filter {
        
        private ProductoTraduccion_Fields fieldField;
        
        private string criteriaField;
        
        /// <comentarios/>
        public ProductoTraduccion_Fields Field {
            get {
                return this.fieldField;
            }
            set {
                this.fieldField = value;
            }
        }
        
        /// <comentarios/>
        public string Criteria {
            get {
                return this.criteriaField;
            }
            set {
                this.criteriaField = value;
            }
        }
    }
    
    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:microsoft-dynamics-schemas/page/productotraduccion")]
    public enum ProductoTraduccion_Fields {
        
        /// <comentarios/>
        Item_No,
        
        /// <comentarios/>
        Variant_Code,
        
        /// <comentarios/>
        Language_Code,
        
        /// <comentarios/>
        Description,
        
        /// <comentarios/>
        Description_2,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.79.0")]
    public delegate void ReadCompletedEventHandler(object sender, ReadCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.79.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ReadCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ReadCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public ProductoTraduccion Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((ProductoTraduccion)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.79.0")]
    public delegate void ReadByRecIdCompletedEventHandler(object sender, ReadByRecIdCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.79.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ReadByRecIdCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ReadByRecIdCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public ProductoTraduccion Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((ProductoTraduccion)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.79.0")]
    public delegate void ReadMultipleCompletedEventHandler(object sender, ReadMultipleCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.79.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ReadMultipleCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ReadMultipleCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public ProductoTraduccion[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((ProductoTraduccion[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.79.0")]
    public delegate void IsUpdatedCompletedEventHandler(object sender, IsUpdatedCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.79.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class IsUpdatedCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal IsUpdatedCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.79.0")]
    public delegate void GetRecIdFromKeyCompletedEventHandler(object sender, GetRecIdFromKeyCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.79.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetRecIdFromKeyCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetRecIdFromKeyCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.79.0")]
    public delegate void CreateCompletedEventHandler(object sender, CreateCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.79.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class CreateCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal CreateCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public ProductoTraduccion ProductoTraduccion {
            get {
                this.RaiseExceptionIfNecessary();
                return ((ProductoTraduccion)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.79.0")]
    public delegate void CreateMultipleCompletedEventHandler(object sender, CreateMultipleCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.79.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class CreateMultipleCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal CreateMultipleCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public ProductoTraduccion[] ProductoTraduccion_List {
            get {
                this.RaiseExceptionIfNecessary();
                return ((ProductoTraduccion[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.79.0")]
    public delegate void UpdateCompletedEventHandler(object sender, UpdateCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.79.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class UpdateCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal UpdateCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public ProductoTraduccion ProductoTraduccion {
            get {
                this.RaiseExceptionIfNecessary();
                return ((ProductoTraduccion)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.79.0")]
    public delegate void UpdateMultipleCompletedEventHandler(object sender, UpdateMultipleCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.79.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class UpdateMultipleCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal UpdateMultipleCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public ProductoTraduccion[] ProductoTraduccion_List {
            get {
                this.RaiseExceptionIfNecessary();
                return ((ProductoTraduccion[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.79.0")]
    public delegate void DeleteCompletedEventHandler(object sender, DeleteCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.79.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class DeleteCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal DeleteCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591