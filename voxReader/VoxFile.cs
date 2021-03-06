﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace voxReader
{
    class VoxFile : IEnumerable<Chunk>
    {
        public Chunk Main;

        public IEnumerator<Chunk> GetEnumerator()
        {
            return ((IEnumerable<Chunk>)Main).GetEnumerator();
        }

        internal void ReadStream(FileStream stream)
        {
            BinaryReader binaryReader = new BinaryReader(stream, Encoding.ASCII);
            var tag = new string(binaryReader.ReadChars(4));
            var version = binaryReader.ReadInt32();
            Main = new Chunk();
            Main.Decode(binaryReader);
            Console.WriteLine(tag);
        }

        internal void WriteStream(FileStream stream)
        {
            BinaryWriter binaryWriter = new BinaryWriter(stream, Encoding.ASCII);
            binaryWriter.Write("VOX ".ToCharArray());
            binaryWriter.Write(150);
            binaryWriter.Write(Main.ToByteArray());
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<Chunk>)Main).GetEnumerator();
        }
    }
}
