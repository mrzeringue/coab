using Classes;
using Logging;

namespace engine
{
    public class seg043
    {
        static bool in_print_and_exit = false;
        public static void print_and_exit()
        {
            if (in_print_and_exit == false)
            {
                in_print_and_exit = true;

                gbl.soundType = gbl.soundTypeBackup;

                seg044.sound_sub_120E0(gbl.sound_FF_188BC);

                Logger.Close();            

                seg001.EngineStop();
            }
        }


        static void DebugPlayerAffects(Player player)
        {
            foreach(Affect affect in player.affects)
            {
                Logger.Debug("who: {0}  sp#: {1} - {2}", player.name, (int)affect.type, affect.type);
            }
        }

        internal static byte GetInputKey()
        {
            byte key;

            if (gbl.inDemo == true)
            {
                if (seg049.KEYPRESSED() == true)
                {
                    key = seg049.READKEY();
                }
                else
                {
                    key = 0;
                }
            }
            else
            {
                key = seg049.READKEY();
            }

            if (key == 0x13)
            {
                if (gbl.soundType == SoundType.PC)
                {
                    gbl.soundTypeBackup = gbl.soundType;
                    seg044.sound_sub_120E0(gbl.sound_0_188BE);
                    gbl.soundType = SoundType.None;
                }
                else if (gbl.soundTypeBackup == SoundType.PC)
                {
                    gbl.soundType = gbl.soundTypeBackup;
                    seg044.sound_sub_120E0(gbl.sound_1_188C0);
                }
            }

            if (Cheats.allow_keyboard_exit && key == 3)
            {
                print_and_exit();
            }

            if (key != 0)
            {
                while (seg049.KEYPRESSED() == true)
                {
                    key = seg049.READKEY();
                }
            }

            return key;
        }

        public static void DumpPlayerAffects()
        {
            foreach (Player player in gbl.player_next_ptr)
            {
                DebugPlayerAffects(player);
            }
        }

        public static void ToggleCommandDebugging()
        {    
            gbl.printCommands = !gbl.printCommands;

            if (gbl.printCommands == true)
            {
                Logger.Debug(System.DateTime.Now.ToString());
            }
        }

        internal static void clear_keyboard()
        {
            while (seg049.KEYPRESSED() == true)
            {
                GetInputKey();
            }
        }


        internal static void clear_one_keypress()
        {
            if (seg049.KEYPRESSED() == true)
            {
                GetInputKey();
            }
        }
    }
}
