﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace voxReader
{
    class Layer : WorldChunk
    {
        public string name;
        public int x;
        internal override void ProcessTaggedData(BinaryReader dataReader, Dictionary<string, string> tags)
        {
            name = tags["_name"];
            x = dataReader.ReadInt32();
        }
    }
}
