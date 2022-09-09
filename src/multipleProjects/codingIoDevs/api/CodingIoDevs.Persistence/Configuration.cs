using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace CodingIoDevs.Persistence;

public static class Configuration
{
    public static string ConnectionString
    {
        get
        {
            ConfigurationManager configurationManager = new();
            configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../CodingIoDevs.WebAPI"));
            configurationManager.AddJsonFile("appsettings.json");

            return configurationManager.GetConnectionString("CodingIoDevs");
        }
    }
}