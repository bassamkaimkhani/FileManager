using Manager.Model;
using Syroot.Windows.IO;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Manager.Commmands;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;
using System.Windows;
using System.Windows.Media;

namespace Manager.viewmodel
{
    class FileManagerViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(sender: this, e: new PropertyChangedEventArgs(propertyName));
        }

       // readonly ResourceDictionary _icondictionary = System.Windows.Application.LoadComponent(new Uri("/Manager/Icons.xaml", UriKind.RelativeOrAbsolute)) as ResourceDictionary;
    
        public string PreviousDirectory { get; set; }
        public string CurrentDirectory { get; set; }
        public string NextDirectory { get; set; }
        public string SeletedDriveSize { get; set; }
        public string SelectedFolderDetails { get; set; }
        public ObservableCollection<FileMangerModel> FavouriteFolders { get; set; }
        public ObservableCollection<FileMangerModel> RemoteFolders { get; set; }
        public ObservableCollection<FileMangerModel> ConnectedDevices { get; set; }
        public ObservableCollection<FileMangerModel> LibraryFolders { get; set; }
        public ObservableCollection<FileMangerModel> NavigationFolderFiles { get; set; }
        internal ReadOnlyCollection<string> tempFolderCollection;

        private BackgroundWorker bgGetFilesBackGroundWorker = new BackgroundWorker()
        {
            WorkerReportsProgress = true,
            WorkerSupportsCancellation=true
        };
        void LoadDirectory(FileMangerModel fileMangerModel)
        {
            NavigationFolderFiles.Clear();
            tempFolderCollection = null;
            if (!bgGetFilesBackGroundWorker.IsBusy) return;
            bgGetFilesBackGroundWorker.CancelAsync();
            bgGetFilesBackGroundWorker.RunWorkerAsync(fileMangerModel);
        }
        
        private void BgGetFilesBackGroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            var fileOrFolder = (FileMangerModel)e.Argument;
        }

        private void BgGetFilesBackGroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void BgGetFilesBackGroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
        }
        public FileManagerViewModel()
        {
            RemoteFolders = new ObservableCollection<FileMangerModel>()
            {
                new FileMangerModel
                {
                    name = "OneDrive",
                    isDirectory = true,
                    path=Environment.GetEnvironmentVariable("OneDriveComsumer")
                 
                },
                new FileMangerModel
                {
                    name = "Google Drive",
                    isDirectory = true,
                    path=""

                },
            };
            LibraryFolders = new ObservableCollection<FileMangerModel>()
            {
                new FileMangerModel
                {
                    name = "Desktop",
                    isDirectory = true,
                    path=Environment.GetFolderPath(Environment.SpecialFolder.Desktop)


                },
                 new FileMangerModel
                {
                    name = "Documents",
                    isDirectory = true,
                    path=Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                },
                   new FileMangerModel
                {
                    name = "Downloads",
                    isDirectory = true,
                    path= new KnownFolder(KnownFolderType.Downloads).Path
                },
            };
            ConnectedDevices = new ObservableCollection<FileMangerModel>();
            foreach(var drive in DriveInfo.GetDrives())
            {
                var Name = string.IsNullOrEmpty(drive.VolumeLabel) ? "Local Drive" : drive.VolumeLabel;
                ConnectedDevices.Add(new FileMangerModel()
                {
                    name = $"{Name}({drive.Name.Replace(oldValue: @"\", newValue: "")})",
                    path = drive.RootDirectory.FullName,
                    isDirectory = true,

                }) ;
            };
            CurrentDirectory = @"C:\";
            OnPropertyChanged(nameof(CurrentDirectory));
            NavigationFolderFiles = new ObservableCollection<FileMangerModel>();
            bgGetFilesBackGroundWorker.DoWork += BgGetFilesBackGroundWorker_DoWork;
            bgGetFilesBackGroundWorker.ProgressChanged += BgGetFilesBackGroundWorker_ProgressChanged;
            bgGetFilesBackGroundWorker.RunWorkerCompleted += BgGetFilesBackGroundWorker_RunWorkerCompleted;

        }


        private ICommand _openSettingCommand;
        public ICommand openSettingCommand
        {
            get
            {
                return _openSettingCommand ?? (_openSettingCommand = new Commands(() => Process.Start("ms settings: home")));
            }
        }
    }
}
