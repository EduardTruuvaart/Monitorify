﻿using System.IO;
using Microsoft.Extensions.Configuration;

namespace OfflineDetector.Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var currentDirectoryPath = Directory.GetCurrentDirectory();

            var builder = new ConfigurationBuilder()
                .SetBasePath(currentDirectoryPath)
                .AddJsonFile("urls.json", optional: false, reloadOnChange: false);
            IConfigurationRoot configuration = builder.Build();
            IConfigurationSection section = configuration.GetSection("test");

            System.Console.ReadLine();
        }
    }
}
