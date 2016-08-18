namespace TEDEditor
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct PDIDATETIME32
    {
        private uint abc;
        public void SetDateTime(DateTime a)
        {
            this.abc = 0;
            if (a.Year > 0x7b2)
            {
                this.abc |= (uint)((a.Year - 0x7b2) << 0x1a);
            }
            this.abc |= (uint)(a.Month << 0x16);
            this.abc |= (uint)(a.Day << 0x11);
            this.abc |= (uint)(a.Hour << 12);
            this.abc |= (uint)(a.Minute << 6);
            this.abc |= (uint)a.Second;
        }

        public DateTime GetDateTime()
        {
            return new DateTime((((int)(this.abc >> 0x1a)) & 0x3f) + 0x7b2, ((int)(this.abc >> 0x16)) & 15, ((int)(this.abc >> 0x11)) & 0x1f, ((int)(this.abc >> 12)) & 0x1f, ((int)(this.abc >> 6)) & 0x3f, ((int)this.abc) & 0x3f);
        }

        public uint GetRawData()
        {
            return this.abc;
        }

        public void SetRawData(uint a)
        {
            this.abc = a;
        }
    }
}
