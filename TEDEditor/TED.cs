using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace TEDEditor
{
    public class TED
    {
        public static UInt64 magic = 5139792810303815680;
        public static int version;
        public static uint sceneryIndex;
        public static float RoadWidth;
        public static float TrackWidthA;
        public static float TrackWidthB;
        public static float StartingPoint;
        public static DateTime PDIDateTime;
        public static bool IsLoopCourse;
        public static int pad_1;
        public static int pad_2;
        public static float homeStraightLength;
        public static float elevationDifference;
        public static int CornerCount;
        public static float FinishLine;
        public static float StartLine;
        public static int CP_offset;
        public static int CP_count;
        public static int reserved1_offset;
        public static int reserved1_count;
        public static int reserved2_offset;
        public static int reserved2_count;
        public static int reserved3_offset;
        public static int reserved3_count;
        public static int Bank_offset;
        public static int Bank_count;
        public static int Height_offset;
        public static int Height_count;
        public static int CheckPoint_offset;
        public static int CheckPoint_count;
        public static int Road_offset;
        public static int Road_count;
        public static int Decoration_offset;
        public static int Decoration_count;
        public static byte[] New_TED;

        //private static bool debugging = false;

        public static bool Read(BinaryReader reader, bool load = true)
        {
            if (reader.ReadUInt64() != 5139792810303815680)
                return false;
            version = reader.ReadInt32();
            sceneryIndex = reader.ReadUInt32();
            RoadWidth = reader.ReadSingle();
            TrackWidthA = reader.ReadSingle();
            TrackWidthB = reader.ReadSingle();
            StartingPoint = reader.ReadSingle();
            PDIDATETIME32 datetime = new PDIDATETIME32();
            datetime.SetRawData(reader.ReadUInt32());
            PDIDateTime = datetime.GetDateTime();
            IsLoopCourse = Convert.ToBoolean(reader.ReadInt32());
            pad_1 = reader.ReadInt32();
            pad_2 = reader.ReadInt32();
            homeStraightLength = reader.ReadSingle();
            elevationDifference = reader.ReadSingle();
            CornerCount = reader.ReadInt32();
            FinishLine = reader.ReadSingle();
            StartLine = reader.ReadSingle();
            reader.ReadInt32();
            reader.ReadInt32();
            CP_offset = reader.ReadInt32();
            CP_count = reader.ReadInt32();
            reserved1_offset = reader.ReadInt32();
            reserved1_count = reader.ReadInt32();
            reserved2_offset = reader.ReadInt32();
            reserved2_count = reader.ReadInt32();
            reserved3_offset = reader.ReadInt32();
            reserved3_count = reader.ReadInt32();
            Bank_offset = reader.ReadInt32();
            Bank_count = reader.ReadInt32();
            Height_offset = reader.ReadInt32();
            Height_count = reader.ReadInt32();
            CheckPoint_offset = reader.ReadInt32();
            CheckPoint_count = reader.ReadInt32();
            Road_offset = reader.ReadInt32();
            Road_count = reader.ReadInt32();
            Decoration_offset = reader.ReadInt32();
            Decoration_count = reader.ReadInt32();

            if (load)
            {
                ReadCP(reader);
                ReadBank(reader);
                ReadHeight(reader);
                ReadCheckPoint(reader);
                ReadRoad(reader);
                ReadDecoration(reader);
            }
            return true;
        }

        #region CP
        public struct Load_CP
        {
            public UInt32 FORM_TYPE;
            public float x;
            public float y;
            public float x2;
            public float y2;
        }

        public static Load_CP[] cps;

        public static bool ReadCP(BinaryReader reader)
        {
            // Read CP Data
            reader.BaseStream.Seek(CP_offset, SeekOrigin.Begin);
            cps = new Load_CP[CP_count];
            for (int i = 0; i < CP_count; i++)
            {
                cps[i].FORM_TYPE = reader.ReadUInt32();
                cps[i].x = reader.ReadSingle();
                cps[i].y = reader.ReadSingle();
                cps[i].x2 = reader.ReadSingle();
                cps[i].y2 = reader.ReadSingle();
            }
            return (true);
        }

        public static uint WriteCP(ref EndianBinWriter writer)
        {
            // Write CP Data
            int count = 0;
            //writer.BaseStream.Seek(CP_offset, SeekOrigin.Begin);
            for (int i = 0; i < CP_count; i++)
            {
                writer.Write(cps[i].FORM_TYPE);
                writer.Write(cps[i].x);
                writer.Write(cps[i].y);
                writer.Write(cps[i].x2);
                writer.Write(cps[i].y2);
                count = i;
            }
            return ((uint)count + 1);
        }
        #endregion

        #region BANK
        public struct Load_Bank
        {
            public float m_bank;
            public float m_shiftPrev;
            public float m_shiftNext;
            public uint m_divCount;
            public int m_divStart;
            public float m_vpos;
            public float m_vlen;
        }

        public static Load_Bank[] banks;

        public static bool ReadBank(BinaryReader reader)
        {
            // Read Bank Data
            reader.BaseStream.Seek(Bank_offset, SeekOrigin.Begin);
            banks = new Load_Bank[Bank_count];
            for (int i = 0; i < Bank_count; i++)
            {
                banks[i].m_bank = reader.ReadSingle();
                banks[i].m_shiftPrev = reader.ReadSingle();
                banks[i].m_shiftNext = reader.ReadSingle();
                banks[i].m_divCount = reader.ReadUInt32();
                banks[i].m_divStart = reader.ReadInt32();
                banks[i].m_vpos = reader.ReadSingle();
                banks[i].m_vlen = reader.ReadSingle();
            }
            return (true);
        }

        public static uint WriteBank(ref EndianBinWriter writer)
        {
            // Write Bank Data
            int count = 0;
            // writer.BaseStream.Seek(Bank_offset, SeekOrigin.Begin);
            for (int i = 0; i < Bank_count; i++)
            {
                writer.Write(banks[i].m_bank);
                writer.Write(banks[i].m_shiftPrev);
                writer.Write(banks[i].m_shiftNext);
                writer.Write(banks[i].m_divCount);
                writer.Write(banks[i].m_divStart);
                writer.Write(banks[i].m_vpos);
                writer.Write(banks[i].m_vlen);
                count = i;
            }
            return ((uint)count + 1);
        }
        #endregion

        #region HEIGHT
        public struct Load_Height
        {
            public float m_Height;
        }

        public static Load_Height[] heights;

        public static bool ReadHeight(BinaryReader reader)
        {
            // Read Height Data
            reader.BaseStream.Seek(Height_offset, SeekOrigin.Begin);
            heights = new Load_Height[Height_count];
            for (int i = 0; i < Height_count; i++)
            {
                heights[i].m_Height = reader.ReadSingle();
            }
            return (true);
        }

        public static uint WriteHeight(ref EndianBinWriter writer)
        {
            // Write Height Data
            int count = 0;
            //writer.BaseStream.Seek(Height_offset, SeekOrigin.Begin);
            for (int i = 0; i < Height_count; i++)
            {
                writer.Write(heights[i].m_Height);
                count = i;
            }
            return ((uint)count + 1);
        }

        private static float getHeight(int index)
        {
            return (heights[index].m_Height);
        }
        #endregion

        #region CHECKPOINT
        public struct Load_CheckPoint
        {
            public float VposIncludeHeight;
        }

        public static Load_CheckPoint[] checkpoints;

        public static bool ReadCheckPoint(BinaryReader reader)
        {
            // Read CheckPoint Data
            reader.BaseStream.Seek(CheckPoint_offset, SeekOrigin.Begin);
            checkpoints = new Load_CheckPoint[CheckPoint_count];
            for (int i = 0; i < CheckPoint_count; i++)
            {
                checkpoints[i].VposIncludeHeight = reader.ReadSingle();
            }
            return (true);
        }

        public static uint WriteCheckPoint(ref EndianBinWriter writer)
        {
            // Write CheckPoint Data
            int count = 0;
            //writer.BaseStream.Seek(CheckPoint_offset, SeekOrigin.Begin);
            for (int i = 0; i < CheckPoint_count; i++)
            {
                writer.Write(checkpoints[i].VposIncludeHeight);
                count = i;
            }
            return ((uint)count + 1);
        }
        #endregion

        #region ROAD
        public struct Load_Road
        {
            public UInt64 uuid;
            public int flag;
            public float vposIncludeHeight;
            public float vposIncludeHeight2;
        }

        public static Load_Road[] roads;

        public static bool ReadRoad(BinaryReader reader)
        {
            // Read Road Data
            reader.BaseStream.Seek(Road_offset, SeekOrigin.Begin);
            roads = new Load_Road[Road_count];
            for (int i = 0; i < Road_count; i++)
            {
                roads[i].uuid = reader.ReadUInt64();
                roads[i].flag = reader.ReadInt32();
                roads[i].vposIncludeHeight = reader.ReadSingle();
                roads[i].vposIncludeHeight2 = reader.ReadSingle();
            }
            return (true);
        }

        public static uint WriteRoad(ref EndianBinWriter writer)
        {
            // Write Road Data
            int count = 0;
            //writer.BaseStream.Seek(Road_offset, SeekOrigin.Begin);
            for (int i = 0; i < Road_count; i++)
            {
                writer.Write(roads[i].uuid);
                writer.Write(roads[i].flag);
                writer.Write(roads[i].vposIncludeHeight);
                writer.Write(roads[i].vposIncludeHeight2);
                count = i;
            }
            return ((uint)count + 1);
        }
        #endregion

        #region DECORATION
        public struct Load_Decoration
        {
            public UInt64 m_arr_Cliff;
            public UInt32 decoratedRailRotx;
            public float vposIncludeHeight;
            public float vposIncludeHeight2;
            public UInt32 mItemTrack;
        }

        public static Load_Decoration[] decorations;

        public static bool ReadDecoration(BinaryReader reader)
        {
            // Read Decoration Data
            reader.BaseStream.Seek(Decoration_offset, SeekOrigin.Begin);
            decorations = new Load_Decoration[Decoration_count];
            for (int i = 0; i < Decoration_count; i++)
            {
                decorations[i].m_arr_Cliff = reader.ReadUInt64();
                decorations[i].decoratedRailRotx = reader.ReadUInt32();
                decorations[i].vposIncludeHeight = reader.ReadSingle();
                decorations[i].vposIncludeHeight2 = reader.ReadSingle();
                decorations[i].mItemTrack = reader.ReadUInt32();
            }
            return (true);
        }

        public static uint WriteDecoration(ref EndianBinWriter writer)
        {
            // Write Decoration Data
            int count = 0;
            //writer.BaseStream.Seek(Decoration_offset, SeekOrigin.Begin);
            for (int i = 0; i < Decoration_count; i++)
            {
                writer.Write(decorations[i].m_arr_Cliff);
                writer.Write(decorations[i].decoratedRailRotx);
                writer.Write(decorations[i].vposIncludeHeight);
                writer.Write(decorations[i].vposIncludeHeight2);
                writer.Write(decorations[i].mItemTrack);
                count = i + 1;
            }
            return ((uint)count);
        }
        #endregion

        public static byte[] Write()
        {
            DateTime now = DateTime.Now;
            string ID = "GT6TED";
            uint Version = 104;
            int offset_1 = 76;
            int offset_2 = 80;
            string encoding = "utf-8";

            MemoryStream memoryStream = new MemoryStream();
            EndianBinWriter endianBinWriter = new EndianBinWriter(memoryStream);
            endianBinWriter.BaseStream.Seek(0, SeekOrigin.Begin);
            byte[] bytes = Encoding.GetEncoding(encoding).GetBytes(ID);
            endianBinWriter.Write(bytes, 0, (int)bytes.Length);
            endianBinWriter.Write((ushort)0);
            endianBinWriter.Write(Version);

            endianBinWriter.Write(sceneryIndex);
            endianBinWriter.Write(RoadWidth);
            endianBinWriter.Write(TrackWidthA);
            endianBinWriter.Write(TrackWidthB);
            endianBinWriter.Write(StartingPoint);
            PDIDATETIME32 pDIDATETIME32 = new PDIDATETIME32();
            pDIDATETIME32.SetDateTime(now);
            endianBinWriter.Write(pDIDATETIME32.GetRawData());

            endianBinWriter.Write(Convert.ToUInt32(IsLoopCourse));
            endianBinWriter.Write(pad_1);
            endianBinWriter.Write(pad_2);
            endianBinWriter.Write(homeStraightLength);
            endianBinWriter.Write(elevationDifference);
            endianBinWriter.Write(CornerCount);
            endianBinWriter.Write(FinishLine);
            endianBinWriter.Write(StartLine);
            endianBinWriter.Write(0);
            endianBinWriter.Write(0);

            memoryStream.Seek((long)(offset_1 + offset_2), SeekOrigin.Begin);
            uint CP_offset = ((uint)memoryStream.Position);
            uint CP_count = WriteCP(ref endianBinWriter);
            uint r_1_offset = ((uint)memoryStream.Position);
            uint r_1_count = 0;
            uint r_2_offset = ((uint)memoryStream.Position);
            uint r_2_count = 0;
            uint r_3_offset = ((uint)memoryStream.Position);
            uint r_3_count = 0;
            uint Bank_offset = ((uint)memoryStream.Position);
            uint Bank_count = WriteBank(ref endianBinWriter);
            uint Height_offset = ((uint)memoryStream.Position);
            uint Height_count = WriteHeight(ref endianBinWriter);
            uint CheckPoint_offset = ((uint)memoryStream.Position);
            uint CheckPoint_count = WriteCheckPoint(ref endianBinWriter);
            //if (CheckPoint_offset == 0)
            //{
            //    float num24 = ((float)(num9 + (!StaticObj.get_IsLoopCourse() ? num8 : num6))) / 2f;
            //    writer.Write(num24);
            //    CheckPoint_offset = 1;
            //    Debug.Log("checkPoint:" + num24);
            //}
            uint Road_offset = ((uint)memoryStream.Position);
            uint Road_count = WriteRoad(ref endianBinWriter);
            uint Decoration_offset = ((uint)memoryStream.Position);
            uint Decoration_count = WriteDecoration(ref endianBinWriter);

            memoryStream.Seek((long)offset_1, SeekOrigin.Begin);
            endianBinWriter.Write(CP_offset);
            endianBinWriter.Write(CP_count);
            endianBinWriter.Write(r_1_offset);
            endianBinWriter.Write(r_1_count);
            endianBinWriter.Write(r_2_offset);
            endianBinWriter.Write(r_2_count);
            endianBinWriter.Write(r_3_offset);
            endianBinWriter.Write(r_3_count);
            endianBinWriter.Write(Bank_offset);
            endianBinWriter.Write(Bank_count);
            endianBinWriter.Write(Height_offset);
            endianBinWriter.Write(Height_count);
            endianBinWriter.Write(CheckPoint_offset);
            endianBinWriter.Write(CheckPoint_count);
            endianBinWriter.Write(Road_offset);
            endianBinWriter.Write(Road_count);
            endianBinWriter.Write(Decoration_offset);
            endianBinWriter.Write(Decoration_count);
            New_TED = memoryStream.ToArray();
            memoryStream.Close();

            return (New_TED);
        }

        public static bool SaveHeights(string filename = "heights.csv", Boolean header = false, float zScale = 1.0F)
        {
            using (StreamWriter sw = new StreamWriter(filename))
            {
                if (header)
                    sw.WriteLine("X;Y");

                int count = 0;
                List<float> zValues = new List<float>();
                for (int i = 0; i < banks.Length; i++)
                {
                    // Write vertices
                    float base_point = ((banks[i].m_vlen / banks[i].m_divCount));
                    for (int j = 1; j < (banks[i].m_divCount + 1); j++)
                    {
                        if (i == 0 && j == 1)
                        {
                            float p3 = getHeight((banks[i].m_divStart));
                            float test = (p3 * zScale);

                            zValues.Add(p3);

                            sw.WriteLine("{0};{1}", (0.0F).ToString().Replace(",", "."), (p3 * zScale).ToString("G9").Replace(",", "."));
                            count++;
                        }
                        float point2 = (base_point * j) + banks[i].m_vpos;
                        float point3 = getHeight((banks[i].m_divStart + j));
                        sw.WriteLine("{0};{1}", point2.ToString().Replace(",", "."), (point3 * zScale).ToString("G9").Replace(",", "."));

                        zValues.Add(point3);

                        count++;
                    }
                }
                System.Diagnostics.Debug.WriteLine(zValues.Max().ToString("F9"));
                System.Diagnostics.Debug.WriteLine(zValues.Min().ToString("F9"));
                System.Diagnostics.Debug.WriteLine(((zValues.Max()) - (zValues.Min())).ToString("F9"));
            }
            return (true);
        }

        public static bool ReadHeights(string input_path, float zScale = 1.0F)
        {
            List<Vertex> vertices = new List<Vertex>();
            if (!File.Exists(input_path))
            {
                Console.WriteLine("File doesn't exits: {0}", input_path);
                return (false);
            }

            String[] lines = File.ReadAllLines(input_path);
            foreach (String line in lines)
            {
                String[] splitted = line.Split(';');
                if (splitted.Length == 2)
                    vertices.Add(new Vertex() { X = double.Parse(splitted[0], CultureInfo.InvariantCulture.NumberFormat), Y = double.Parse(splitted[1], CultureInfo.InvariantCulture.NumberFormat) });
            }

            if (vertices.Count != heights.Length)
            {
                Console.WriteLine("Heights count isn't equal ({0}/{1})", vertices.Count, heights.Length);
                return (false);
            }

            for (int i = 0; i < Height_count; i++)
            {
                float new_height = (float)vertices[i].Y;
                heights[i].m_Height = (new_height * zScale);
            }

            return (true);
        }

        public static Vertex[] GetHeights(float zScale = 1.0F)
        {
            List<Vertex> vertices = new List<Vertex>();

            int count = 0;
            List<float> zValues = new List<float>();
            for (int i = 0; i < banks.Length; i++)
            {
                // Write vertices
                float base_point = ((banks[i].m_vlen / banks[i].m_divCount));
                for (int j = 1; j < (banks[i].m_divCount + 1); j++)
                {
                    if (i == 0 && j == 1)
                    {
                        float p3 = getHeight((banks[i].m_divStart));
                        float test = (p3 * zScale);

                        zValues.Add(p3);

                        //sw.WriteLine("{0};{1}", (0.0F).ToString().Replace(",", "."), (p3 * zScale).ToString("G9").Replace(",", "."));
                        vertices.Add(new Vertex() { X = 0.0F, Y = 0.0F, Z = p3 * zScale });
                        count++;
                    }
                    float point2 = (base_point * j) + banks[i].m_vpos;
                    float point3 = getHeight((banks[i].m_divStart + j));
                    //sw.WriteLine("{0};{1}", point2.ToString().Replace(",", "."), (point3 * zScale).ToString("G9").Replace(",", "."));
                    vertices.Add(new Vertex() { X = 0.0F, Y = point2, Z = point3 * zScale });

                    zValues.Add(point3);

                    count++;
                }
            }
            System.Diagnostics.Debug.WriteLine(zValues.Max().ToString("F9"));
            System.Diagnostics.Debug.WriteLine(zValues.Min().ToString("F9"));
            System.Diagnostics.Debug.WriteLine(((zValues.Max()) - (zValues.Min())).ToString("F9"));

            return (vertices.ToArray());
        }

        public static bool SetHeights(Vertex[] new_heights, float zScale = 1.0F)
        {
            if(heights.Length != new_heights.Length)
            {
                Console.WriteLine("Heights count isn't equal ({0}/{1})", heights.Length, new_heights.Length);
                return (false);
            }
            for (int i = 0; i < heights.Length; i++)
                heights[i].m_Height = (float)new_heights[i].Z;

            return (true);
        }
    }
}
