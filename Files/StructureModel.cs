using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Files
{
    class StructureModel : ViewBaseModel
    {
        private List<Drive> drives;
        private List<string> drivesNames = Directory.GetLogicalDrives().ToList();

        public List<Drive> CreateDriveObjects(List<string> drvNms)
        {
            return drvNms.Select(drive => new Drive(drive)).ToList();
        }

        public StructureModel()
        {
            Drives = CreateDriveObjects(drivesNames);
        }

        public List<Drive> Drives
        {
            get { return drives; }
            set
            {
                drives = value;
                OnPropertyChanged("Drives");
            }

        }
    }
}
