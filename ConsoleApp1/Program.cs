using System;
using System.Collections;
using System.IO;
using CascStorageLib;
using CascStorageLib.Attributes;

namespace ConsoleApp1
{
    class Program
    {
        //public class SSDRec
        //{
        //    [Index]
        //    public int ID;
        //    public ushort SpecializationID;
        //    public uint[] SpellID;
        //}

        static void Main(string[] args)
        {
            var build = "8.1.0.28366";
            var dbcdir = @"Z:\DBCs\" + build + @"\dbfilesclient";

            //var rawType = DefinitionManager.CompileDefinition(Path.Combine(dbcdir, "specializationspellsdisplay.db2"), build);
            //var type = typeof(Storage<>).MakeGenericType(rawType);
            //var instance = (IDictionary)Activator.CreateInstance(type, Path.Combine(dbcdir, "specializationspellsdisplay.db2"));
            foreach (var file in Directory.GetFiles(dbcdir))
            {
                try
                {
                    var definition = DefinitionManager.CompileDefinition(file, build);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Failed to load " + Path.GetFileNameWithoutExtension(file) + ": " + e.Message + "\n" + e.StackTrace);
                }
            }

            Console.ReadLine();
        }
    }
}
