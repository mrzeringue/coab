using Classes;

namespace engine
{
    class ovr028
    {
        static byte[] unk_16D5A = { 
            0x04,0x0C,0x15,0x0B,0x1D,0x14,0x26,0x15,
            0x1E,0x1F,0x19,0x25,0x1C,0x1D,0x03,0x0C,
            0x19,0x1D,0x1D,0x21,0x13,0x10,0x09,0x10,
            0x14,0x15,0x19,0x19,0x1A,0x1F,0x25,0x22, 0x0F };

        static byte[] unk_16D7A = {
            0x0F,0x08,0x0B,0x04,0x0A,0x04,0x01,0x02,
            0x0D,0x0F,0x03,0x05,0x02,0x08,0x0C,0x0D,
            0x0A,0x0C,0x09,0x09,0x08,0x06,0x06,0x03,
            0x02,0x02,0x03,0x02,0x03,0x04,0x02,0x01, 0x00 };

        static short loc_X; // word_1EF9C
        static short loc_Y; // word_1EF9E

        internal static void sub_6E005()
        {
            loc_X = unk_16D5A[gbl.area_ptr.field_342];
            loc_Y = unk_16D7A[gbl.area_ptr.field_342];
        }


        internal static void sub_6E02E()
        {
            // hack to stop ega code barfing, need to work out
            // is only displayed when world map is displayed
            //seg040.ega_01(gbl.dword_1C8F4, loc_Y, loc_X);
            seg040.draw_picture(gbl.dword_1EFA0, loc_Y, loc_X, 0);
        }


        internal static void sub_6E05D()
        {
            seg040.draw_picture(gbl.dword_1C8F4, loc_Y, loc_X, 0);
        }
    }
}
