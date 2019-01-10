using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Files
{
    class Folder : ViewBaseModel
    {
        private List<File> fileList;

        private string _strFolderName = string.Empty;
        private string _strFolderPath = string.Empty;

        public Folder(string folderPath)
        {
            _strFolderPath = folderPath;
            _strFolderName = CreateFolderName(folderPath);
            try
            {
                fileList = CreateFileObjects(folderPath);
            }
            catch(UnauthorizedAccessException)
            {
                Console.WriteLine("Unauthorized Access");
            }
                    
        }

        public List<File> FileList
        {
            get { return fileList; }
            set
            {
                fileList = value;
                OnPropertyChanged("FileList");
            }
        }

        public string FolderName
        {
            get { return _strFolderName;}
            set { _strFolderName = value; }
        }

        private string CreateFolderName(string folderPath)
        {
            return folderPath.Substring(folderPath.LastIndexOf('\\') + 1);
        }

        private List<File> CreateFileObjects(string FolderPath)
        {
            List<string> fls = Directory.GetFiles(FolderPath).ToList();
            return fls.Select(filePath => new File(filePath)).ToList();
        }
    }
}
