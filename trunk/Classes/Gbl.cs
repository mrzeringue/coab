using System;
using System.Collections.Generic;


namespace Classes
{
    public delegate void spellDelegate(out bool arg_0, byte arg_4, byte arg_6);
    public delegate void spellDelegate2();
    public delegate void spellDelegateX(byte arg_0, object affect, Player player);


    public enum SoundType
    {
        PC,
        Tandy,
        None
    }

    public class money
    {
        public const int copper = 0;
        public const int silver = 1;
        public const int electrum = 2;
        public const int gold = 3;
        public const int platum = 4;
        public const int gem = 5;
        public const int jewelry = 6;

        public static string[] names = { "Copper", "Silver", "Electrum", "Gold", "Platinum", "Gems", "Jewelry" };

        public static int[] per_copper = { 1, 10, 100, 200, 1000 };
    }

    /// <summary>
    /// Summary description for Class1.
    /// </summary>
    public class gbl
    {
        public const ushort action_struct_size = 0x16;
        public const ushort char_struct_size = 0x1a6;

        public static byte byte_1642C;
        public static byte byte_1645A;

        public const sbyte byte_16E1C = 4;
        public const sbyte byte_16E1E = 3;
        public const sbyte byte_16E20 = 3;
        public const sbyte byte_16E22 = 3;
        public const byte byte_16E24 = 1;
        public const sbyte byte_16E26 = 1;
        public const sbyte byte_16E28 = 1;
        public const sbyte byte_16E2A = 0;
        public const byte byte_16E2C = 0;
        public const sbyte byte_16E2E = 4;

        public const int unk_189B4_count = 64; /* 64 is a guess */
        public static Struct_189B4[] unk_189B4 = { 
            new Struct_189B4( 1 , 0 , 0xFF, 0),
            new Struct_189B4( 0xFF , 1 , 2 , 0 ),
            new Struct_189B4( 0xFF , 1 , 2 , 1 ),
            new Struct_189B4( 0xFF , 1 , 2 , 2 ),
            new Struct_189B4(  0xFF,  1,  2, 3 ),
            new Struct_189B4(  1 , 1 ,  0 ,  4 ),
            new Struct_189B4(  0xFF , 1 ,  2 , 5 ),
            new Struct_189B4 ( 0xff, 1, 2, 6 ),
            new Struct_189B4 ( 0xff, 1, 2, 7 ),
            new Struct_189B4 ( 1, 1, 0, 8 ),
            new Struct_189B4 ( 0xff, 1, 2, 9 ),
            new Struct_189B4 ( 1, 1, 0, 0x0A ),
            new Struct_189B4 ( 0xff, 1, 2, 0x0B ),
            new Struct_189B4 ( 1, 1, 0, 0x0C ),
            new Struct_189B4 ( 0xff, 1, 2, 0x0D ),
            new Struct_189B4 ( 1, 1, 0, 0x0E ),
            new Struct_189B4 ( 0xff, 1, 2, 0x0F ),
            new Struct_189B4 ( 1, 1, 0, 0x10 ),
            new Struct_189B4 ( 0xff, 1, 2, 0x11 ),
            new Struct_189B4 ( 0xff, 1, 2, 0x12 ),
            new Struct_189B4 ( 0xff, 1, 2, 0x13 ),
            new Struct_189B4 ( 0xff, 1, 2, 0x14 ),
            new Struct_189B4 ( 0xff, 1, 2, 0x15 ),
            new Struct_189B4 ( 1, 1, 0, 0x16 ),
            new Struct_189B4 ( 1, 1, 0, 0x17 ),
            new Struct_189B4 ( 0xff, 1, 2, 0x18 ),
            new Struct_189B4 ( 2, 2, 0, 0x22 ),
            new Struct_189B4 ( 1, 1, 0, 0x23 ),
            new Struct_189B4 ( 1, 1, 0, 0x24 ),
            new Struct_189B4 ( 1, 1, 0, 0x25 ),
            new Struct_189B4 ( 1, 1, 0, 0x26 ),
            new Struct_189B4 ( 1, 1, 0, 0x27 ),
            new Struct_189B4 ( 0xff, 1, 2, 0 ),
            new Struct_189B4 ( 0xff, 1, 2, 1 ),
            new Struct_189B4 ( 0xff, 1, 2, 2 ),
            new Struct_189B4 ( 0xff, 1, 2, 3 ),
            new Struct_189B4 ( 0xff, 1, 2, 4 ),
            new Struct_189B4 ( 1, 1, 0, 5 ),
            new Struct_189B4 ( 1, 1, 0, 6 ),
            new Struct_189B4 ( 1, 1, 0, 7 ),
            new Struct_189B4 ( 1, 1, 0, 8 ),
            new Struct_189B4 ( 1, 1, 0, 9 ),
            new Struct_189B4 ( 0xff, 1, 2, 0x0A ),
            new Struct_189B4 ( 0xff, 1, 2, 0x0B ),
            new Struct_189B4 ( 1, 1, 0, 0x0C ),
            new Struct_189B4 ( 1, 1, 0, 0x0D ),
            new Struct_189B4 ( 1, 1, 0, 0x0E ),
            new Struct_189B4 ( 1, 1, 0, 0x0F ),
            new Struct_189B4 ( 2, 1, 0, 0x10 ),
            new Struct_189B4 ( 2, 1, 0, 0x11 ),
            new Struct_189B4 ( 2, 1, 0, 0x12 ),
            new Struct_189B4 ( 2, 1, 0, 0x13 ),
            new Struct_189B4 ( 2, 1, 0, 0x14 ),
            new Struct_189B4 ( 2, 1, 0, 0x15 ),
            new Struct_189B4 ( 1, 1, 0, 0x16 ),
            new Struct_189B4 ( 1, 1, 0, 0x17 ),
            new Struct_189B4 ( 1, 1, 0, 0x18 ),
            new Struct_189B4 ( 1, 1, 0, 0x19 ),
            new Struct_189B4 ( 2, 1, 0, 0x1A ),
            new Struct_189B4 ( 2, 1, 0, 0x1B ),
            new Struct_189B4 ( 4, 0, 0, 0x1C ),
            new Struct_189B4 ( 4, 0, 0, 0x1D ),
            new Struct_189B4 ( 4, 0, 0, 0x1E ),
            new Struct_189B4 ( 4, 0, 0, 0x1F ),
            new Struct_189B4 ( 1, 1, 0, 0x20 ),
            new Struct_189B4 ( 1, 1, 0, 0x21 ),
            new Struct_189B4 ( 0, 0, 0xff, 0xff ),
            new Struct_189B4 ( 0xff, 0xff, 0xff, 0xff ),
            new Struct_189B4 ( 0, 0, 0, 1 ),
            new Struct_189B4 ( 0xff, 0xff, 0xff, 0xff ),
            new Struct_189B4 ( 0, 0, 1, 0 ),
            new Struct_189B4 ( 0xff, 0xff, 0xff, 0xff ),
            new Struct_189B4 ( 0, 0, 1, 0 ),
            new Struct_189B4 ( 0, 1, 1, 1 )
        };


        public const byte byte_1A114 = 1;
        /// <summary> seg600:3EBB </summary>
        public readonly static byte[] byte_1A1CB =  { 10, 15, 10, 10, 11, 12, 11 };
        public readonly static byte[] unk_1A1D3 = { 1, 2, 3, 4, 6, 7 }; // unk_1A1D3[0] == unk_1A1D2[1];

        /// <summary> seg600:3FFA </summary>
        public readonly static byte[,] unk_1A30A = { 
            { 0x12, 0x12, 0x64, 0x32, 3, 0x12, 3, 0x12, 3, 0x12, 3, 0x12, 3, 0x12}, 
            { 3, 2, 6, 0xE, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            { 7, 2, 5, 6, 0xD, 0xE, 0xF, 0x10, 0, 0, 0, 0, 0, 0},
            { 3, 2, 6, 0xE, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            { 0xD, 0, 2, 5, 6, 4, 8, 0xA, 9, 0xB, 0xD, 0xE, 0xF, 0x10},
            { 3, 2, 6, 0xE, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            { 6, 0, 2, 6, 8, 0xC, 0xE, 0, 0, 0, 0, 0, 0, 0},
            { 6, 0, 2, 5, 6, 3, 4, 0, 0, 0, 0, 0, 0, 0} };


        public static char byte_1AB06;
        public static bool stopVM = false; //byte_1AB08
        public static byte byte_1AB09;
        public static byte byte_1AB0A;
        public static byte byte_1AB0B;
        public static byte byte_1AB0C;
        public static byte byte_1AB0D;
        public static byte byte_1AB0E;
        public static byte byte_1AB14 = 0x73;
        public static bool byte_1AB16;
        public static byte byte_1AB18;
        public static byte byte_1AB19 = 0x40;
        public static byte byte_1AB1A; // not sure what's this is for.
        public static sbyte[] byte_1AD2C = { 0, 0 };
        public static sbyte[] byte_1AD2E = { 0, 0 };
        public static byte[] unk_1AD30 = { 0, 0 };
        public static byte[] byte_1AD32 = { 0, 0 };
        public static sbyte byte_1AD34 = 0x1A;
        public static sbyte byte_1AD35 = 0x74;
        public static byte byte_1AD36 = 0x1A;
        public static byte byte_1AD37 = 0x79;
        public static byte byte_1AD38 = 0x1A;
        public static byte byte_1AD39 = 0x8B;
        public static sbyte field_197;
        public static byte byte_1AD3C;
        public static byte byte_1AD3D;
        public static byte byte_1AD3E;
        public static byte byte_1AD44;
        public static bool byte_1AD48;
        public static byte byte_1ADFA;
        public static byte byte_1AE0A;
        public static byte byte_1AE1B;
        public static byte[] unk_1AE24 = new byte[0x48];
        public static byte byte_1AFDC;
        public static byte byte_1AFDD;
        public static byte byte_1AFDE;

        public static char byte_1B2BA;
        public static byte byte_1B2C0;
        public static bool DisplayFullTitleScreen; // byte_1B2C1
        public static byte last_game_state; // byte_1B2E4
        public static byte byte_1B2E9 = 0;
        public static byte byte_1B2EB;
        public static byte byte_1B2EE;
        public static byte byte_1B2EF;
        public static byte byte_1B2F0;
        public static byte byte_1B2F1;
        public static byte byte_1B2F2;

        public static byte byte_1BF12; // ??

        public static SoundType soundType; // byte_1BF14
        public static SoundType soundTypeBackup; // byte_1BF15

        public static string byte_1BF1a = "C:\\Games\\Coab\\Save\\";

        public static string byte_1BF1A
        {
            get
            {
                return byte_1BF1a;
            }
        }
        public static byte byte_1C01A;
        public static byte byte_1C01B;
        public static byte[] byte_1C8C2 = new byte[8];
        public static byte textXCol; // byte_1C8CA
        public static byte textYCol; // byte_1C8CB
        public static byte byte_1D1BB;
        public static byte byte_1D1C0;
        public static byte byte_1D1C4;
        public static byte byte_1D2BD;
        public static byte byte_1D2BE;
        public static byte byte_1D2BF;
        public static byte byte_1D2C0;
        public static byte byte_1D2C1;
        public static sbyte byte_1D2C2;
        public static byte byte_1D2C4;
        public static byte byte_1D2C5;
        public static byte byte_1D2C6;
        public static byte byte_1D2C7;
        public static bool byte_1D2C8;
        public static sbyte byte_1D2C9;
        public static byte byte_1D2CA;
        public static byte byte_1D2CB; // not used.
        public static byte byte_1D2CC;
        public static byte byte_1D2D1;
        public static byte byte_1D534;
        public static byte byte_1D535;
        public static byte byte_1D536;
        public static byte byte_1D537;
        public static bool mapAreaDisplay; //byte_1D538, Show Area Map
        public static sbyte mapPosX; // byte_1D539, 0 map left, + map right
        public static sbyte mapPosY; // byte_1D53A, 0 map top, +map bottom
        public static byte mapDirection; // byte_1D53B , 0 N, 2 E, 4 S, 6 W
        public static byte byte_1D53C;
        public static byte byte_1D53D;

        public static void wordSetArray_1D53A(int index, short value)
        {
            switch (index)
            {
                case 1: word_1D53E = value; break;
                case 2: word_1D542 = value; break;
                case 3: word_1D546 = value; break;
            }
        }

        public static short wordGetArray_1D53A(int index)
        {
            switch (index)
            {
                case 1: return word_1D53E;
                case 2: return word_1D542;
                case 3: return word_1D546;
                default: throw new System.NotSupportedException();
            }
        }

        public static void wordSetArray_1D53C(int index, short value)
        {
            switch (index)
            {
                case 1: word_1D540 = value; break;
                case 2: word_1D544 = value; break;
                case 3: word_1D548 = value; break;
            }
        }

        public static short wordGetArray_1D53C(int index)
        {
            switch (index)
            {
                case 1: return word_1D540;
                case 2: return word_1D544;
                case 3: return word_1D548;
                default: throw new System.NotSupportedException();
            }
        }

        public static short word_1D53E; // byte_1D53A[di] 1*4
        public static short word_1D540; // byte_1D53C[di] 1*4
        public static short word_1D542; // byte_1D53A[di] 2*4
        public static short word_1D544; // byte_1D53C[di] 2*4
        public static short word_1D546; // byte_1D53A[di] 3*4
        public static short word_1D548; // byte_1D53C[di] 3*4

        public static DaxArray byte_1D556;
        public static string byte_1D5A2;
        public static string byte_1D5AB;
        public static byte byte_1D5B4;
        public static byte byte_1D5B5;
        public static byte byte_1D5BA;
        public static byte byte_1D5BE;
        public static bool byte_1D5BF;
        public static byte byte_1D5C4;
        public static byte byte_1D75E;
        public static int byte_1D883;
        public static int byte_1D884;
        public static byte byte_1D88D;
        public static byte byte_1D8A8;
        public static byte byte_1D8AA;
        public static byte byte_1D8AC;
        public static byte byte_1D8B0;
        public static byte byte_1D8B6; // not used.
        public static byte byte_1D8B7;
        public static byte byte_1D8B8;
        public static byte[] byte_1D8B9 = new byte[0x48];
        public static byte byte_1D901;
        public static byte byte_1D902;
        public static byte byte_1D903;
        public static bool byte_1D904;
        public static bool byte_1D905;
        public static bool byte_1D90E;
        public static bool byte_1D90F;
        public static bool byte_1D910;
        public static byte byte_1D912;
        public static byte byte_1D913;
        public static byte byte_1D928;
        public static byte byte_1D92B;
        public static byte byte_1D92C;
        public static byte byte_1D92D;

        public static bool byte_1DA70;
        public static byte byte_1DA71;

        public static byte[] byte_1EE72 = new byte[2];
        public static byte byte_1EE7C;
        public static byte byte_1EE7D;
        public static bool byte_1EE7E;
        public static byte byte_1EE81;
        public static byte byte_1EE86;
        public static byte byte_1EE88;
        public static byte byte_1EE89;
        public static byte byte_1EE8A;
        public static byte byte_1EE8B;
        public static byte byte_1EE8C;
        public static byte byte_1EE8D;
        public static byte byte_1EE8E;
        public static byte byte_1EE8F;
        public static byte byte_1EE90;
        public static byte byte_1EE91;
        public static byte byte_1EE92;
        public static byte byte_1EE93;
        public static byte byte_1EE94;
        public static byte byte_1EE95;
        public static byte byte_1EE96;
        public static byte byte_1EE97;
        public static byte byte_1EE98;
        public static byte byte_1EE99;
        public static byte byte_1EF9A;
        public static byte byte_1EF9B;

        public static string byte_1EFA4;
        public static byte byte_1EFBA;

        public static short word_123C8 = 0;

        public const short word_16E08 = 5;
        public const short word_16E0A = 4;
        public const short word_16E0C = 6;
        public const short word_16E0E = 4;
        public const short word_16E10 = 2;
        public const short word_16E12 = 7;
        public const short word_16E14 = 2;
        public const short word_16E16 = 0;
        public const short word_16E18 = 9;
        public const short word_16E1A = 5;

        public const short word_188BC = 0x00ff;
        public const short word_188BE = 0;
        public const short word_188C0 = 1;
        public const short word_188C2 = 2;
        public const short word_188C4 = 3;
        public const short word_188C6 = 4;
        public const short word_188C8 = 5;
        public const short word_188CA = 6;
        public const short word_188CC = 7;
        public const short word_188CE = 8;
        public const short word_188D0 = 9;
        public const short word_188D2 = 0xa;
        public const short word_188D4 = 0xb;
        public const short word_188D6 = 0xc;
        public const short word_188D8 = 0xd;

        public readonly static short[] symbol_set_fix = { 0x0001, 0x002E, 0x0074, 0x00BA, 0x0100 };
        public const short word_1899C = 0x2D;

        public static RestTime word_1A13C;


        public static short dos_call_result; // seg600:47EE word_1AAFE
        public static ushort word_1AE0F;
        public static ushort word_1AE11;
        public static ushort word_1AE13;
        public static short word_1AE15;
        public static ushort word_1AE17;
        public static short word_1AE19;
        public static short word_1AFE0;


        public static ushort word_1B2D3;
        public static ushort word_1B2D5;
        public static ushort word_1B2D7;
        public static ushort word_1B2D9;
        public static ushort ecl_initial_entryPoint; // word_1B2DB
        public static short word_1B2EC;
        public static DaxBlock dword_1C8FC;
        public static DaxBlock dword_1D55C;
        public static DaxBlock word_1D5B6;
        public static short word_1D5BC;
        public static short word_1D5C0;
        public static short word_1D5C2;
        public static spellDelegate2[] word_1D5CE = new spellDelegate2[100];

        public static Player dword_1D87F;

        public static RestTime unk_1D890 = new RestTime();
        public static short word_1D8A6;
        public static short word_1D914;
        public static short word_1D916;
        public static short word_1D918; // above unk_1D89D

        public static ushort word_1EE76;
        public static ushort word_1EE78;
        public static ushort word_1EE7A;

        public static short word_1EFBC;

        public static object dword_1AAC8;
        public static Item[] unk_1AF18; // array 01-0x30; seg600:4C08
        public static byte[] unk_1AEC4; // unk_1AEC4[0x53]; seg600:4BB4
        public static Struct_1ADF6[] dword_1ADF6;
        public static StringList dword_1AE6C;
        public static DaxBlock dword_1C8F4;
        public static DaxBlock dword_1C8F8;
        public static Item dword_1D5C6;
        public static spellDelegate dword_1D5CA;
        public static DaxBlock dword_1D90A;
        public static int exp_to_add;

        public class class_1D91A
        {
            public ushort field_0;
            public class_1D91A field_2;
        }

        public static Stack<ushort> vmCallStack = new Stack<ushort>(); // dword_1D91A

        public static DaxBlock dword_1EFA0;
        public static object dword_1EFD2;


        public static Player player_ptr2;
        public static Player player_ptr;

        public static byte game_state;
        public static byte combat_type;
        public static ushort ecl_offset;



        public static byte command;
        public static Player player_next_ptr;
        public static Item item_ptr;
        public static Player spell_target;
        public static Player[] sp_target = new Player[256];
        // 744Bh[1] == sp_target[0]
        public static Player[] player_array = new Player[256];

        public class Struct_1D1C1
        {
            public byte field_0;
            public byte field_1;
            public byte field_2;

            public void Copy(Struct_1D1C1 source)
            {
                field_0 = source.field_0;
                field_1 = source.field_1;
                field_2 = source.field_2;
            }
        }

        public const int unk_1D1C1_count = 72;
        public static Struct_1D1C1[] unk_1D1C1; // seg600:6EB1 - 6EAEh[1] == unk_1D1C1[0]

        public class Struct_1C9CD
        {
            public int xPos; // 0x00
            public int yPos; // 0x01
            public byte field_2;
            public byte field_3;
        }

        public const int stru_1C9CD_count = 0xff;
        public static Struct_1C9CD[] stru_1C9CD; // seg600:66BD

        public static byte[, ,] unk_16620; // unk_16620 seg600:0310

        public static Player player_ptr01;
        public static Player player_ptr02;

        public static byte game_area;
        public static byte game_area_backup;

        public static Area1 area_ptr;
        public static Area2 area2_ptr;

        public static Struct_1B2CA stru_1B2CA;
        public static EclBlock ecl_ptr;
        public static byte[,] dax_8x8d1_201;
        public static byte[][] stru_1D52C;
        public static byte[] stru_1D530;

        public static DaxBlock[,] combat_icons;

        public static DaxBlock[] symbol_8x8_set; // seg600:65D0 - seg600:65E3 DaxBlock[5]

        public static Item item_pointer;

        public static int[] pooled_money = new int[7];

        public static bool[] item_find = new bool[6];

        public static byte game_speed_var;

        public static bool inDemo;
        public static bool AnimationsOn;
        public static bool PicsOn;
        public static bool something01;

        public static byte current_head_id;
        public static DaxBlock headX_dax;
        public static byte current_body_id;
        public static DaxBlock bodyX_dax;

        public static bool can_bash_door;
        public static bool can_pick_door;
        public static bool can_knock_door;


        public static short textWndXXX;

        public static byte saving_throw;
        public static bool save_made;
        public static bool gameFlag01;
        public static bool printCommands;

        public static DaxBlock sky_dax_250;
        public static DaxBlock sky_dax_251;
        public static DaxBlock sky_dax_252;

        public static string[] unk_1D972 = new string[15] { string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty };

        public const int cmdOppsLimit = 0x18;
        public static Opperation[] cmd_opps = new Opperation[cmdOppsLimit];

        public static Struct_19AEC[] unk_19AEC = {
            new Struct_19AEC(),
            new Struct_19AEC( 0,1,6,0,6,0,10,4,0,4,1,2,10,1,0,0),
            new Struct_19AEC( 0,1,6,0,6,0,10,0,0,4,2,1,10,3,1,0),
            new Struct_19AEC( 0,1,0,0,0,0,4,2,0,4,0,2,5,1,0,0),
            new Struct_19AEC( 0,1,-1,0,0,0,4,0,0,4,0,1,5,2,1,0),
            new Struct_19AEC( 0,1,3,0,10,0,0,1,0,4,5,2,1,0,0,0),
            new Struct_19AEC( 0,1,0,0,0,3,4,2,0,4,8,2,4,1,0,0),
            new Struct_19AEC( 0,1,0,0,0,3,4,2,0,4,9,2,4,1,0,0),
            new Struct_19AEC( 0,1,0,0,0,10,4,2,0,4,10,2,10,0,0,0),
            new Struct_19AEC( 2,1,0,0,0,0,4,0,0,4,0,1,1,2,1,0),
            new Struct_19AEC( 2,1,12,0,0,0,4,0,1,4,11,1,1,4,1,0),
            new Struct_19AEC( 2,1,0,0,0,2,0,1,0,4,5,2,1,0,0,0),
            new Struct_19AEC( 2,1,0,2,0,10,4,2,0,4,12,2,1,0,0,0),
            new Struct_19AEC( 2,1,0,2,0,10,4,2,1,4,12,2,1,0,1,0),
            new Struct_19AEC( 2,1,0,0,0,1,0,1,0,4,14,0,1,0,0,0),
            new Struct_19AEC( 2,1,6,4,0,0,4,0,0,4,0,1,1,4,1,0),
            new Struct_19AEC( 2,1,0,0,0,2,4,2,0,4,8,2,1,1,0,0),
            new Struct_19AEC( 2,1,0,0,0,2,4,2,0,4,9,2,1,1,0,0),
            new Struct_19AEC( 2,1,0,0,0,2,0,1,0,4,16,0,10,0,0,0),
            new Struct_19AEC( 2,1,0,0,0,5,0,1,0,4,17,2,1,2,0,0),
            new Struct_19AEC( 2,1,-1,0,0,0,4,0,0,4,0,1,1,2,1,0),
            new Struct_19AEC( 2,1,3,4,0,5,9,0,0,4,0x35,1,1,2,1,1),
            new Struct_19AEC( 0,2,0,0,0x1E,0,0,1,0,4,19,0,5,0,0,0),
            new Struct_19AEC( 0,2,6,0,4,1,6,0,1,4,0x34,1,5,6,1,0),
            new Struct_19AEC( 0,2,0,0,0,10,4,2,0,4,20,2,5,1,0,0),
            new Struct_19AEC( 0,2,12,0,0,2,0x1F,0,3,4,21,1,5,4,1,1),
            new Struct_19AEC( 0,2,0,0,0,0x3C,4,2,0,4,0x16,2,1,0,0,0),
            new Struct_19AEC( 0,2,3,0,0,0,0xF0,0,0,4,0x33,1,5,0,1,0),
            new Struct_19AEC( 0,2,3,0,0,1,0,1,0,4,0x17,2,5,1,0,0),
            new Struct_19AEC( 2,2,0,4,0,5,0,1,0,4,0x18,2,2,1,0,0),
            new Struct_19AEC( 2,2,0,0,0,0,4,2,0,4,0x19,2,2,2,0,0),
            new Struct_19AEC( 2,2,0,0,0,0,0,0,0,4,0,0,1,0,0,0),
            new Struct_19AEC( 2,2,0,0,0,2,0,1,0,4,0x1C,2,2,3,0,0),
            new Struct_19AEC( 2,2,1,1,0,1,4,0,1,4,0x1D,1,2,2,1,0),
            new Struct_19AEC( 2,2,3,0,0,1,9,0,3,0,0x1E,1,2,5,1,1),
            new Struct_19AEC( 2,2,0,0,0,0x3C,0,2,0,4,0x26,0,10,0,0,0),
            new Struct_19AEC( 3,7,4,0,0,0,8,4,1,4,0,2,0,2,0,0),
            new Struct_19AEC( 0,3,0,0,0,0,4,2,0,4,0,2,10,0,0,0),
            new Struct_19AEC( 0,3,-1,0,0,0,4,0,1,4,0x21,1,10,3,1,0),
            new Struct_19AEC( 0,3,0,0,0,0,0,2,0,4,0,0,100,0,0,0),
            new Struct_19AEC( 0,3,-1,0,0,0,4,0,1,4,0x22,1,100,4,1,0),
            new Struct_19AEC( 0,3,6,0,0,0,9,2,0,4,0,2,4,3,1,1),
            new Struct_19AEC( 0,3,0,0,0,1,0,4,0,4,0x31,2,6,5,0,0),
            new Struct_19AEC( 0,3,0,0,0,0,4,2,0,4,0,2,6,0,0,0),
            new Struct_19AEC( 0,3,-1,0,0,10,4,0,1,4,0x24,1,6,5,1,0),
            new Struct_19AEC( 2,3,0,0,0,1,0,0,0,4,0x25,1,1,2,0,0),
            new Struct_19AEC( 2,3,12,0,0,1,9,2,0,4,0,2,3,2,1,1),
            new Struct_19AEC( 2,3,10,1,0,0,11,0,2,4,0,1,3,7,1,3),
            new Struct_19AEC( 2,3,6,0,3,1,10,4,0,4,0x27,2,3,3,0,0),
            new Struct_19AEC( 2,3,12,0,0,2,7,0,1,4,0x34,1,3,6,1,0),
            new Struct_19AEC( 2,3,0,0,0,0,9,4,0,4,0x19,2,3,1,0,0),
            new Struct_19AEC( 2,3,4,1,0,0,8,0,2,4,0,1,3,6,1,0),
            new Struct_19AEC( 2,3,0,0,0,2,4,2,0,4,0x2D,2,3,1,0,0),
            new Struct_19AEC( 2,3,0,0,0,2,4,2,0,4,0x2E,2,3,2,0,0),
            new Struct_19AEC( 2,3,0,0,0,10,4,2,0,4,0x29,2,3,3,0,0),
            new Struct_19AEC( 2,3,9,1,3,1,10,0,0,4,0x2A,1,3,4,1,0),
            new Struct_19AEC( 0,7,0,0,0,0,4,2,0,4,0,2,6,0,0,0),
            new Struct_19AEC( 3,6,0,0,0,0,0,1,0,4,0x27,2,0,3,0,0),
            new Struct_19AEC( 0,4,0,0,0,0,4,2,0,4,0,2,7,1,0,0),
            new Struct_19AEC( 3,6,0,0,0,0,0,1,0,4,0x26,2,0,1,0,0),
            new Struct_19AEC( 3,6,4,4,0,0,4,0,2,4,0,1,0,7,1,0),
            new Struct_19AEC( 3,6,6,0,0,0,4,0,1,0,0x34,1,0,7,1,0),
            new Struct_19AEC( 3,6,0,0,0,0,0,1,0,4,0x27,2,0,1,0,0),
            new Struct_19AEC( 3,6,0,0,0,0,7,4,0,4,0x47,2,0,2,0,0),
            new Struct_19AEC( 3,6,7,0,0,0,11,0,2,4,0,1,0,7,1,3),
            new Struct_19AEC( 3,6,12,0,0,0,4,0,0,4,0,1,0,6,1,0),
            new Struct_19AEC( 0,4,0,0,0,0,4,0,0,4,0,1,7,5,1,0),
            new Struct_19AEC( 0,4,0,0,0,0,0,2,0,4,0,0,7,0,0,0),
            new Struct_19AEC( 0,4,0,0,0,0,4,0,1,0,0,1,7,6,1,0),
            new Struct_19AEC( 0,4,3,0,0,10,4,2,0,4,0x2D,2,7,2,0,0),
            new Struct_19AEC( 0,4,3,0,0,2,4,0,0,4,3,1,7,4,1,0),
            new Struct_19AEC( 0,5,0,0,0,0,4,2,0,4,0,2,8,2,0,0),
            new Struct_19AEC( 0,5,-1,0,0,0,4,0,1,4,0,1,8,6,1,0),
            new Struct_19AEC( 0,5,0,0,0,1,0,0,0,4,0x91,1,8,3,0,0),
            new Struct_19AEC( 0,5,6,0,0,0,4,0,2,4,0,1,8,6,1,0),
            new Struct_19AEC( 0,5,0,0,0,0,0,2,0,4,0,0,10,1,0,0),
            new Struct_19AEC( 0,5,3,0,0,0,4,0,1,4,0,1,10,7,1,0),
            new Struct_19AEC( 1,1,3,0,12,0,0,1,0,4,5,2,3,1,0,0),
            new Struct_19AEC( 1,1,8,0,10,0,11,0,1,4,0x88,1,3,3,1,0),
            new Struct_19AEC( 1,1,8,0,0,4,5,0,1,4,7,1,3,4,1,0),
            new Struct_19AEC( 1,1,-1,0,10,1,4,2,0,4,0x45,2,4,1,1,0),
            new Struct_19AEC( 2,4,6,0,0,0,5,0,1,4,11,1,4,6,1,0),
            new Struct_19AEC( 2,4,12,0,2,1,11,0,1,4,0x23,1,4,7,1,0),
            new Struct_19AEC( 2,4,0,3,0,0,8,0,0,4,0,1,1,0,1,0),
            new Struct_19AEC( 2,4,6,0,0,1,8,0,1,4,0x8E,1,4,6,1,0),
            new Struct_19AEC( 2,4,0,0,2,1,0,1,0,4,0,2,4,8,0,0),
            new Struct_19AEC( 2,4,0,1,0,1,4,0,1,4,0x1B,1,4,4,1,0),
            new Struct_19AEC( 2,4,0,1,0,0,10,0,0,4,0,1,4,7,1,0),
            new Struct_19AEC( 2,4,0,1,0,1,0,1,0,4,0x3F,2,4,5,0,0),
            new Struct_19AEC( 2,4,0,0,0,0,4,2,0,4,0,2,4,0,0,0),
            new Struct_19AEC( 3,5,1,0,0,0,0xF0,4,0,4,0x20,2,5,0,0,0),
            new Struct_19AEC( 2,5,2,0,0,1,9,0,0,4,0,2,5,5,1,0),
            new Struct_19AEC( 2,5,6,0,0,0,8,0,2,4,0,1,5,6,1,0),
            new Struct_19AEC( 2,5,16,0,0,0,4,0,1,4,0x44,1,5,6,1,0),
            new Struct_19AEC( 2,5,0,1,0,1,7,0,1,4,0x34,1,5,7,1,0),
            new Struct_19AEC( 3,6,0,0,0,0,0,1,0,4,0x49,2,10,1,0,0),
            new Struct_19AEC( 3,6,0,0,0,0,0,1,0,4,0x6D,2,10,1,0,0),
            new Struct_19AEC( 3,6,0,0,0,0,0,1,0,4,0x19,2,0,1,0,0),
            new Struct_19AEC( 3,6,3,0,0,0,11,0,1,4,0,1,0,1,1,0),
            new Struct_19AEC( 3,6,0,0,0,0,0,1,0,4,0,2,0,1,0,0),
            new Struct_19AEC( 2,4,0,0,0,10,4,0,1,4,0,1,4,4,1,0),
            new Struct_19AEC( 10,0,10,0,6,0,0x18,0,0x1E,0,12,0,0,1,0x28,0x28) }; /*,
new Struct_19AEC( 28h,28h,2Ah,2Ah,2Ah,2Ch,2Ch,2Ch,2Eh,2Eh,2Eh,28h,28h,28h,28h,2Ah),
new Struct_19AEC( 2Ah,2Ah,2Ch,2Ch,2Ch,2Eh,2Eh,2Eh,27h,28h,28h,2Ah,2Bh,2Ch,2Dh,2Eh),
new Struct_19AEC( 2Fh,30h,31h,32h,33h,28h,28h,28h,2Ah,2Bh,2Ch,2Dh,2Eh,2Fh,30h,31h),
new Struct_19AEC( 32h,33h,28h,28h,28h,2Ah,2Bh,2Ch,2Dh,2Eh,2Fh,30h,31h,32h,33h,27h),
new Struct_19AEC( 27h,27h,27h,27h,27h,29h,29h,29h,29h,29h,2Bh,2Bh,28h,28h,28h,28h),
new Struct_19AEC( 28h,29h,29h,29h,29h,2Ch,2Ch,2Ch,2Ch,28h,28h,28h,28h,2Ah,2Ah,2Ah),
new Struct_19AEC( 2Ch,2Ch,2Ch,2Eh,2Eh,2Eh,2,10h,8,40h,40h,1,4,20h,2,2),
new Struct_19AEC( 8,10h,20h,1,4,4,10h,10h,10h,20h,20h,20h,40h,40h,40h,0Ah),
new Struct_19AEC( 0Fh,0Ah,0Ah,0Bh,0Ch,0Bh,13h,1,2,3,4,6,7,1Eh,19h,14h),
new Struct_19AEC( 0Fh,0Ah,0Ah,55h,0,23h,1Dh,19h,15h,0Fh,0Ah,56h,0,28h,21h,1Eh),
new Struct_19AEC( 1Bh,14h,0Fh,57h,0,2Dh,25h,23h,21h,19h,0Fh,58h,14h,32h,2Ah,28h),
new Struct_19AEC( 28h,1Fh,14h,5Ah,19h,37h,2Fh,2Dh,2Fh,25h,14h,5Ch,1Eh,3Ch,34h,32h),
new Struct_19AEC( 37h,2Bh,19h,5Eh,23h,41h,39h,37h,3Eh,31h,19h,60h,28h,46h,3Eh,3Ch),
new Struct_19AEC( 46h,38h,1Eh,62h,2Dh,50h,43h,41h,4Eh,3Fh,1Eh,63h,32h,5Ah,48h,46h),
new Struct_19AEC( 56h,46h,23h,63h,3Ch,64h,4Dh,4Bh,5Eh,4Dh,23h,63h,41h,0,0Ah,0Fh),
new Struct_19AEC( 0,0,0,0F6h,0FBh,5,0FBh,0,5,0Ah,5,0,0,0,5,0Ah),
new Struct_19AEC( 5,5,0Ah,0F1h,0,0Ah,0,0,0,5,0,0,0,5,5,5),
new Struct_19AEC( 0Ah,0Fh,5,0F1h,0FBh,0FBh,5,5,0,0,5,5,0F6h,0,0,0),
new Struct_19AEC( 0,0,0,0,0,0F1h,0F6h,0F6h,0ECh,0F6h,0EDh,0FBh,0F6h,0F1h,0FBh,0FBh),
new Struct_19AEC( 0,0FBh,0F6h,0,0,0,0,0FBh,0,0,0,0,0,0,0,0),
new Struct_19AEC( 0,0,0,0,0,0,0,0,0,0FBh,0,0,0,5,0Ah,0),
new Struct_19AEC( 5,5,0Ah,0Fh,5,0Ah,0Ah,0Fh,14h,0Ah,0Ch,0Ch,8,8,12h,11h),
new Struct_19AEC( 63h,0,3,12h,3,12h,3,11h,0Ch,13h,3,10h,3,3,12h,10h),
new Struct_19AEC( 4Bh,0,8,12h,3,12h,7,13h,6,12h,8,12h,6,6,12h,0Fh),
new Struct_19AEC( 32h,0,7,12h,3,12h,3,12h,8,12h,3,12h,3,3,12h,11h) };*/



        public static Text unk_1EE9A = new Text(); // seg600:8B8A File/TEXT

        public static byte[] unk_1D89D = new byte[10]; // seg600:758D

        public static bool free_training;

        public static bool party_fled;

        public static Struct_1C020[] unk_1C020;
        public static short unk_1C8BC;
        public static Struct_1D183[] unk_1D183; // array[8] but 1 offset.
        public static Struct_1D1BC stru_1D1BC;

        public static byte[] unk_1AE70;

        public readonly static byte[] /*seg600:27D9*/ unk_18AE9 = { 0, 8, 2, 3, 4 };
        public readonly static byte[] /*seg600:27DA*/ unk_18AEA = { 8, 2, 3, 4, 8 };

        public readonly static byte[] /* seg600:27DD */ unk_18AED = { 4, 8, 0, 1, 2, 3, 4, 5, 6, 7 };

        public static Struct_1D885 stru_1D885;
        public static Struct_1D885 stru_1D889;

        public readonly static sbyte[] MapDirectionXDelta = /*unk_189A6 seg600:2696*/ {  0,  1, 1, 1, 0, -1, -1, -1, 0 };
        public readonly static sbyte[] MapDirectionYDelta = /*unk_189AF seg600:269F*/ { -1, -1, 0, 1, 1,  1,  0, -1, 0 };

        /// <summary>
        /// 0 - curse, 1 - pool, 2 - hillsfar
        /// </summary>
        public static byte import_from;

        public static byte friends_count;
        public static byte foe_count;

        public static Text known01_02;

        public static DaxBlock word_1B316; // seg600:5006

        public static bool unk_1AB07; // seg600:47F7

        public static spellDelegateX[] spell_jump_list;


        public static Struct_1A484[] unk_1A484 = new Struct_1A484[] { 
            new Struct_1A484(6, 6, 9, 0, 0, 0), 
            new Struct_1A484(0, 0, 0xC, 0, 0, 0xF), 
            new Struct_1A484(9, 0, 6, 6, 7, 0), 
            new Struct_1A484(0xC, 9, 0xD, 0, 9, 0x11),
            new Struct_1A484(0xD, 0xD, 0xE, 0, 0xE, 0),
            new Struct_1A484(0, 9, 6, 6, 0, 0),
            new Struct_1A484(6, 6, 0, 9, 0, 0),
            new Struct_1A484(0xF, 0, 0xF, 0xF, 0xB, 0),
            new Struct_1A484(9, 0, 9, 0, 0, 0),
            new Struct_1A484(9, 9, 9, 0, 0, 0), 
            new Struct_1A484(0, 0xD, 0xE, 0, 0xE, 0),
            new Struct_1A484(0, 9, 9, 0, 0, 0),
            new Struct_1A484(0, 0, 9, 9, 0, 0), 
            new Struct_1A484(9, 9, 0, 0, 0, 0), 
            new Struct_1A484(9, 0, 0, 9, 0, 0), 
            new Struct_1A484(9, 9, 0, 9, 0, 0), 
            new Struct_1A484(0, 9, 0, 9, 0, 0) };

        public static string unk_1B21A;
        public static string unk_1B26A;
        public static string unk_1B1C9;

        static Struct_1A35E stru_1A35E_0 = new Struct_1A35E(new SubStruct_1A35E[] {
            new SubStruct_1A35E(6, 2, 6), 
            new SubStruct_1A35E( 0x0c08, 0xe, 0),
            new SubStruct_1A35E(0, 0, 0), 
            new SubStruct_1A35E(0, 6, 0), 
            new SubStruct_1A35E(0x502, 6, 3), 
            new SubStruct_1A35E(4, 0, 0), 
            new SubStruct_1A35E(0, 0, 0) });

        static Struct_1A35E stru_1A35E_1 = new Struct_1A35E(new SubStruct_1A35E[] {
            new SubStruct_1A35E(0xfa, 2, 0x14), 
            new SubStruct_1A35E( 0, 0, 0),
            new SubStruct_1A35E(0x28, 5, 4), 
            new SubStruct_1A35E(0, 0, 0), 
            new SubStruct_1A35E(0, 0, 0), 
            new SubStruct_1A35E(0, 0, 0), 
            new SubStruct_1A35E(0x4B, 3, 6) });

        static Struct_1A35E stru_1A35E_2 = new Struct_1A35E(new SubStruct_1A35E[] {
            new SubStruct_1A35E(0x28a, 10, 10), 
            new SubStruct_1A35E( 0, 0, 0),
            new SubStruct_1A35E(0x82, 5, 6), 
            new SubStruct_1A35E(0, 0, 0), 
            new SubStruct_1A35E(0, 0, 0), 
            new SubStruct_1A35E(0x96, 5, 6), 
            new SubStruct_1A35E(0x64, 5, 6) });

        static Struct_1A35E stru_1A35E_3 = new Struct_1A35E(new SubStruct_1A35E[] {
            new SubStruct_1A35E(0x12C, 3, 0xC),
            new SubStruct_1A35E(0, 0, 0),
            new SubStruct_1A35E(0x3C, 5, 4),
            new SubStruct_1A35E(0, 0, 0),
            new SubStruct_1A35E(0, 0, 0), 
            new SubStruct_1A35E(0x64, 2, 0x0C),
            new SubStruct_1A35E(0x50, 5, 4)});

        static Struct_1A35E stru_1A35E_4 = new Struct_1A35E(new SubStruct_1A35E[] {
            new SubStruct_1A35E( 0x28, 2, 4),
            new SubStruct_1A35E( 0, 0, 0),
            new SubStruct_1A35E( 0x16, 3, 4),
            new SubStruct_1A35E( 0, 0, 0),
            new SubStruct_1A35E( 0, 0, 0),
            new SubStruct_1A35E( 0x1E, 2,  8),
            new SubStruct_1A35E( 0x16, 3, 8)});

        static Struct_1A35E stru_1A35E_5 = new Struct_1A35E(new SubStruct_1A35E[] {
            new SubStruct_1A35E(0, 0, 0),
            new SubStruct_1A35E( 0, 0, 0),
            new SubStruct_1A35E( 0x14, 3, 4),
            new SubStruct_1A35E( 0, 0, 0),
            new SubStruct_1A35E( 0, 0, 0),
            new SubStruct_1A35E( 0, 0, 0),
            new SubStruct_1A35E( 0x28, 2, 4)});

        static Struct_1A35E stru_1A35E_6 = new Struct_1A35E(new SubStruct_1A35E[] {
            new SubStruct_1A35E(0x14, 1, 4),
            new SubStruct_1A35E( 0, 0, 0),
            new SubStruct_1A35E( 0xD, 1, 4),
            new SubStruct_1A35E( 0, 0, 0),
            new SubStruct_1A35E( 0, 0, 0),
            new SubStruct_1A35E( 0, 0, 0),
            new SubStruct_1A35E( 0x14, 2, 4)});

        static Struct_1A35E stru_1A35E_7 = new Struct_1A35E(new SubStruct_1A35E[] {
            new SubStruct_1A35E( 0x12, 1, 4),
            new SubStruct_1A35E( 0x12, 1, 4),
            new SubStruct_1A35E( 0xF, 1, 4),
            new SubStruct_1A35E( 0x11, 1, 4),
            new SubStruct_1A35E( 0x14 , 1, 4),
            new SubStruct_1A35E( 0x18 , 2, 4),
            new SubStruct_1A35E( 0x12 , 1, 4)});

        public static Struct_1A35E[] unk_1A35E = new Struct_1A35E[] { stru_1A35E_0, stru_1A35E_1, stru_1A35E_2, stru_1A35E_3, stru_1A35E_4, stru_1A35E_5, stru_1A35E_6, stru_1A35E_7 };

        public static int[] playerScreenX = new int[256]; /* unk_1CAF0 */
        public static int[] playerScreenY = new int[256]; /* unk_1CB38 */

        public static byte[] unk_1AE0B = new byte[3];

        public static byte[] unk_16E30 = new byte[16]; // seg600:0B20
        public static byte[] unk_16E40 = new byte[16]; // seg600:0B30
        public static byte[] unk_16E50 = new byte[16]; // seg600:0B40

        public readonly static byte[,] unk_1A4EA = { 
            { 9,0,1,2,3,4,5,6,7,8},
            { 5,1,3,4,5,7,0,0,0,0},
            { 9,0,1,2,3,4,5,6,7,8},
            { 1,0,0,0,0,0,0,0,0,0},
            { 3,0,3,6,0,0,0,0,0,0},
            { 9,0,1,2,3,4,5,6,7,8},
            { 7,1,2,3,4,5,7,8,0,0},
            { 9,0,1,2,3,4,5,6,7,8},
            { 9,0,1,2,3,4,5,6,7,8},
            { 9,0,1,2,3,4,5,6,7,8},
            { 3,0,3,6,0,0,0,0,0,0},
            { 9,0,1,2,3,4,5,6,7,8},
            { 9,0,1,2,3,4,5,6,7,8},
            { 9,0,1,2,3,4,5,6,7,8},
            { 7,1,2,3,4,5,7,8,0,0},
            { 7,1,2,3,4,5,7,8,0,0},
            { 7,1,2,3,4,5,7,8,0,0} };


    }
}