﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MediaLibraryEditor.WPF.MusicVideoServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="MusicArtist", Namespace="http://schemas.datacontract.org/2004/07/MediaLibrary.WCF")]
    [System.SerializableAttribute()]
    public partial class MusicArtist : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DescriptionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Guid idField;
        
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
        public string Description {
            get {
                return this.DescriptionField;
            }
            set {
                if ((object.ReferenceEquals(this.DescriptionField, value) != true)) {
                    this.DescriptionField = value;
                    this.RaisePropertyChanged("Description");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Guid id {
            get {
                return this.idField;
            }
            set {
                if ((this.idField.Equals(value) != true)) {
                    this.idField = value;
                    this.RaisePropertyChanged("id");
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="MusicGenre", Namespace="http://schemas.datacontract.org/2004/07/MediaLibrary.WCF")]
    [System.SerializableAttribute()]
    public partial class MusicGenre : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DescriptionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Guid idField;
        
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
        public string Description {
            get {
                return this.DescriptionField;
            }
            set {
                if ((object.ReferenceEquals(this.DescriptionField, value) != true)) {
                    this.DescriptionField = value;
                    this.RaisePropertyChanged("Description");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Guid id {
            get {
                return this.idField;
            }
            set {
                if ((this.idField.Equals(value) != true)) {
                    this.idField = value;
                    this.RaisePropertyChanged("id");
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="MusicVideoClip", Namespace="http://schemas.datacontract.org/2004/07/MediaLibrary.WCF")]
    [System.SerializableAttribute()]
    public partial class MusicVideoClip : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ArtistField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int DurationField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string GenreField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SongNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Guid idField;
        
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
        public string Artist {
            get {
                return this.ArtistField;
            }
            set {
                if ((object.ReferenceEquals(this.ArtistField, value) != true)) {
                    this.ArtistField = value;
                    this.RaisePropertyChanged("Artist");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Duration {
            get {
                return this.DurationField;
            }
            set {
                if ((this.DurationField.Equals(value) != true)) {
                    this.DurationField = value;
                    this.RaisePropertyChanged("Duration");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Genre {
            get {
                return this.GenreField;
            }
            set {
                if ((object.ReferenceEquals(this.GenreField, value) != true)) {
                    this.GenreField = value;
                    this.RaisePropertyChanged("Genre");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string SongName {
            get {
                return this.SongNameField;
            }
            set {
                if ((object.ReferenceEquals(this.SongNameField, value) != true)) {
                    this.SongNameField = value;
                    this.RaisePropertyChanged("SongName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Guid id {
            get {
                return this.idField;
            }
            set {
                if ((this.idField.Equals(value) != true)) {
                    this.idField = value;
                    this.RaisePropertyChanged("id");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="MusicVideoServiceReference.IMusicVideoService")]
    public interface IMusicVideoService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMusicVideoService/GetArtists", ReplyAction="http://tempuri.org/IMusicVideoService/GetArtistsResponse")]
        MediaLibraryEditor.WPF.MusicVideoServiceReference.MusicArtist[] GetArtists();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMusicVideoService/UpdateArtist", ReplyAction="http://tempuri.org/IMusicVideoService/UpdateArtistResponse")]
        void UpdateArtist(System.Guid id, string description);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMusicVideoService/AddArtist", ReplyAction="http://tempuri.org/IMusicVideoService/AddArtistResponse")]
        void AddArtist(System.Guid id, string description);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMusicVideoService/DeleteArtist", ReplyAction="http://tempuri.org/IMusicVideoService/DeleteArtistResponse")]
        void DeleteArtist(System.Guid id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMusicVideoService/GetGenres", ReplyAction="http://tempuri.org/IMusicVideoService/GetGenresResponse")]
        MediaLibraryEditor.WPF.MusicVideoServiceReference.MusicGenre[] GetGenres();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMusicVideoService/UpdateGenre", ReplyAction="http://tempuri.org/IMusicVideoService/UpdateGenreResponse")]
        void UpdateGenre(System.Guid id, string description);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMusicVideoService/AddGenre", ReplyAction="http://tempuri.org/IMusicVideoService/AddGenreResponse")]
        void AddGenre(System.Guid id, string description);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMusicVideoService/DeleteGenre", ReplyAction="http://tempuri.org/IMusicVideoService/DeleteGenreResponse")]
        void DeleteGenre(System.Guid id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMusicVideoService/GetVideoClip", ReplyAction="http://tempuri.org/IMusicVideoService/GetVideoClipResponse")]
        MediaLibraryEditor.WPF.MusicVideoServiceReference.MusicVideoClip GetVideoClip(System.Guid id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMusicVideoService/SearchVideoClips", ReplyAction="http://tempuri.org/IMusicVideoService/SearchVideoClipsResponse")]
        MediaLibraryEditor.WPF.MusicVideoServiceReference.MusicVideoClip[] SearchVideoClips(string filter);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMusicVideoService/GetAllVideoClips", ReplyAction="http://tempuri.org/IMusicVideoService/GetAllVideoClipsResponse")]
        MediaLibraryEditor.WPF.MusicVideoServiceReference.MusicVideoClip[] GetAllVideoClips();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMusicVideoService/UpdateVideoClip", ReplyAction="http://tempuri.org/IMusicVideoService/UpdateVideoClipResponse")]
        void UpdateVideoClip(MediaLibraryEditor.WPF.MusicVideoServiceReference.MusicVideoClip clip);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMusicVideoService/AddVideoClip", ReplyAction="http://tempuri.org/IMusicVideoService/AddVideoClipResponse")]
        void AddVideoClip(MediaLibraryEditor.WPF.MusicVideoServiceReference.MusicVideoClip clip);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMusicVideoService/DeleteVideoClip", ReplyAction="http://tempuri.org/IMusicVideoService/DeleteVideoClipResponse")]
        void DeleteVideoClip(System.Guid id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMusicVideoService/GetClipImage", ReplyAction="http://tempuri.org/IMusicVideoService/GetClipImageResponse")]
        byte[] GetClipImage(System.Guid id);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IMusicVideoServiceChannel : MediaLibraryEditor.WPF.MusicVideoServiceReference.IMusicVideoService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class MusicVideoServiceClient : System.ServiceModel.ClientBase<MediaLibraryEditor.WPF.MusicVideoServiceReference.IMusicVideoService>, MediaLibraryEditor.WPF.MusicVideoServiceReference.IMusicVideoService {
        
        public MusicVideoServiceClient() {
        }
        
        public MusicVideoServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public MusicVideoServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MusicVideoServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MusicVideoServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public MediaLibraryEditor.WPF.MusicVideoServiceReference.MusicArtist[] GetArtists() {
            return base.Channel.GetArtists();
        }
        
        public void UpdateArtist(System.Guid id, string description) {
            base.Channel.UpdateArtist(id, description);
        }
        
        public void AddArtist(System.Guid id, string description) {
            base.Channel.AddArtist(id, description);
        }
        
        public void DeleteArtist(System.Guid id) {
            base.Channel.DeleteArtist(id);
        }
        
        public MediaLibraryEditor.WPF.MusicVideoServiceReference.MusicGenre[] GetGenres() {
            return base.Channel.GetGenres();
        }
        
        public void UpdateGenre(System.Guid id, string description) {
            base.Channel.UpdateGenre(id, description);
        }
        
        public void AddGenre(System.Guid id, string description) {
            base.Channel.AddGenre(id, description);
        }
        
        public void DeleteGenre(System.Guid id) {
            base.Channel.DeleteGenre(id);
        }
        
        public MediaLibraryEditor.WPF.MusicVideoServiceReference.MusicVideoClip GetVideoClip(System.Guid id) {
            return base.Channel.GetVideoClip(id);
        }
        
        public MediaLibraryEditor.WPF.MusicVideoServiceReference.MusicVideoClip[] SearchVideoClips(string filter) {
            return base.Channel.SearchVideoClips(filter);
        }
        
        public MediaLibraryEditor.WPF.MusicVideoServiceReference.MusicVideoClip[] GetAllVideoClips() {
            return base.Channel.GetAllVideoClips();
        }
        
        public void UpdateVideoClip(MediaLibraryEditor.WPF.MusicVideoServiceReference.MusicVideoClip clip) {
            base.Channel.UpdateVideoClip(clip);
        }
        
        public void AddVideoClip(MediaLibraryEditor.WPF.MusicVideoServiceReference.MusicVideoClip clip) {
            base.Channel.AddVideoClip(clip);
        }
        
        public void DeleteVideoClip(System.Guid id) {
            base.Channel.DeleteVideoClip(id);
        }
        
        public byte[] GetClipImage(System.Guid id) {
            return base.Channel.GetClipImage(id);
        }
    }
}
