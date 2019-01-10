using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Files
{
    class File : ViewBaseModel
    {
        private string _strFileName = string.Empty;

        public string FileName
        {
            get { return _strFileName; }
            set
            {
                _strFileName = value;
                OnPropertyChanged("FileName");
            }
        }

        public File(string filePath)
        {
            _strFileName = CreateFileName(filePath);
        }

        private string CreateFileName(string filePath)
        {
            return filePath.Substring(filePath.LastIndexOf('\\') + 1);
        }
    }
}
