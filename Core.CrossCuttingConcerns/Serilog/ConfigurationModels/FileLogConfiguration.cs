using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Serilog.ConfigurationModels;

public class FileLogConfiguration
{
    public string FolderPath { get; set; }

    public FileLogConfiguration(string folderPath)
    {
        FolderPath = folderPath;
    }

    public FileLogConfiguration()
    {
        FolderPath = string.Empty;
    }
}
