using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace sspack
{
    /// <summary>
    ///  Export to mimic the json array format from TexturePacker.
    ///  Removed everything not used in my current project.
    /// </summary>
    public class JsonArrayMapExporter : IMapExporter
    {
        #region Implementation of IMapExporter

        public string MapExtension => "json";
        // sspack.exe C:\Temp\2\data /image:C:\Temp\2\6.png /map:C:\temp\2\6.json /mw:2048 /mh:2048 
        public void Save(string filename, Dictionary<string, Rectangle> map)
        {
            using (var writer = new StreamWriter(filename))
            {
                writer.WriteLine("{\"frames\": {");

                const int TODO = 0;
                const float TODOF = 0.5f;

                var last = map.LastOrDefault();
                foreach (var entry in map)
                {
                    var r = entry.Value;
                    writer.WriteLine($"\"{Path.GetFileName(entry.Key)}\":");
                    writer.WriteLine("{");
                    writer.WriteLine($"\"frame\":{{\"x\":{r.X},\"y\":{r.Y},\"w\":{r.Width},\"h\":{r.Height}}},");
                    // Not used writer.WriteLine($"\"rotated\":{(TODOB ? "true" : "false")}");
                    // Not used writer.WriteLine($"\"trimmed\":{(TODOB ? "true" : "false")}");
                    // Not used writer.WriteLine($"\"spriteSourceSize\":{{\"x\":{TODO},\"y\":{TODO},\"w\":{TODO},\"h\":{TODO}");
                    // Not used writer.WriteLine($"\"sourceSize\":{{\"x\":{TODO},\"y\":{TODO}");
                    writer.WriteLine($"\"pivot\":{{\"x\":{TODOF},\"y\":{TODOF}}}");
                    writer.Write("}");
                    if (!Equals(last, entry))
                    {
                        writer.WriteLine(",");
                    }
                }
                writer.WriteLine("}}");
            }
        }

        #endregion
    }
}