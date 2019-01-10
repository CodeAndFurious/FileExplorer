using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace Files
{
    class Drive : ViewBaseModel
    {
        private string _strDriveName = string.Empty;

        private List<Folder> folderList;
        //private List<File> fileList;

        public Drive(string driveName)
        {
            _strDriveName = driveName;
            folderList = CreateFolderObjects(driveName);
            //fileList = CreateFileObjects(driveName);
        }

        public List<Folder> FolderList
        {
            get { return folderList; }
            set
            {
                folderList = value;
                OnPropertyChanged("FolderList");
            }
        }

//        public List<File> FileList
//        {
//            get { return fileList; }
//            set
//            {
//                fileList = value;
//                OnPropertyChanged("FileList");
//            }
//        }

        public string DriveName
        {
            get { return _strDriveName; }
            set { _strDriveName = value; }
        }

        private List<Folder> CreateFolderObjects(string drive)
        {
                List<string> fldrs = Directory.GetDirectories(drive.Substring(drive.Length - 1 )).ToList();
                return fldrs.Select(folder => new Folder(folder)).ToList();
        }

        private List<File> CreateFileObjects(string drive)
        {
            List<string> fls = Directory.GetFiles(drive.Substring(drive.Length - 1)).ToList();
            return fls.Select(file => new File(file)).ToList();
        }

    }
}
