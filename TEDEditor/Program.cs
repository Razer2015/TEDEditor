﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace TEDEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args[0].Equals("-read", StringComparison.CurrentCultureIgnoreCase))
            {
                if (args.Length < 2)
                    PrintInfo();

                if (File.Exists(args[1]))
                {
                    FileInfo fi = new FileInfo(args[1]);
                    using (FileStream fs = new FileStream(fi.FullName, FileMode.Open, FileAccess.Read))
                    {
                        EndianBinReader reader = new EndianBinReader(fs);
                        TED.Read(reader);
#if DEBUG
                        // Visualize
                        GUI gui = new GUI(TED.GetHeights());
                        gui.ShowDialog();
                        return;
#endif
                        if (args.Length >= 3)
                            TED.SaveHeights(args[2]);
                        else
                            TED.SaveHeights(Path.GetFileNameWithoutExtension(fi.FullName) + ".csv");
                    }
                }
            }
            else if (args[0].Equals("-write", StringComparison.CurrentCultureIgnoreCase))
            {
                if (args.Length < 3)
                    PrintInfo();

                if (File.Exists(args[1]))
                {
                    FileInfo fi = new FileInfo(args[1]);
                    using (FileStream fs = new FileStream(fi.FullName, FileMode.Open, FileAccess.Read))
                    {
                        EndianBinReader reader = new EndianBinReader(fs);
                        TED.Read(reader);
                        if (!TED.ReadHeights(args[2]))
                            return;
                        if (args.Length >= 3)
                            File.WriteAllBytes(args[3], TED.Write());
                        else
                            File.WriteAllBytes(Path.GetFileNameWithoutExtension(fi.FullName) + "_newHeights.ted", TED.Write());
                    }
                }
            }
        }

        static void PrintInfo()
        {
            var versionInfo = FileVersionInfo.GetVersionInfo(Assembly.GetEntryAssembly().Location);
            var version = versionInfo.FileVersion;
            var companyName = versionInfo.CompanyName;
            var desc = versionInfo.FileDescription;
            var copyright = versionInfo.LegalCopyright;

            Assembly assembly = Assembly.GetExecutingAssembly();
            var descriptionAttribute = assembly.GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false).OfType<AssemblyDescriptionAttribute>().FirstOrDefault();

            Console.WriteLine(String.Empty);
            Console.WriteLine("+--------------+-----------------------------------------------+");
            Console.WriteLine("| " + companyName + " | " + descriptionAttribute.Description + " " + version + " |");
            Console.WriteLine("+--------------+-----------------------------------------------+");
            Console.WriteLine(Environment.NewLine);

            Console.WriteLine("Example: TEDEditor.exe -read extracted.ted");
            Console.WriteLine("Example: TEDEditor.exe -write extracted.ted newheights.csv newted.ted");
        }
    }
}