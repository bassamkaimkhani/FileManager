using Manager.Commmands;
using Manager.viewmodel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Input;
using System.Windows.Media;

namespace Manager.Model
{
    class FileMangerModel
    {

        public string name { get; set; }
        public string path { get; set; }
        public PathGeometry FileIcon { get; set; }
        public string fileSize { get; set; }
        public string FileExtension { get; set; }
        public string createdOn { get; set; }
        public string ModifiedOn { get; set; }
        public string accessedOn { get; set; }
        public bool isDirectory { get; set; }
        public bool isHidden { get; set; }
        public bool isReadOnly { get; set; }
        public bool isImage { get; set; }
        public bool isVideo { get; set; }
        internal string Type { get; set; }
        public string _type => isDirectory ? "Folder" : "File";

    }
}
