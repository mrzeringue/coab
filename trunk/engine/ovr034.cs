using Classes;

namespace engine
{
    class ovr034
    {
        internal static void Load24x24Set(byte arg_0, byte arg_2, byte arg_4, string arg_6)
        {
            DaxBlock var_104;
            string var_100;

            var_100 = arg_6;

            if (arg_2 > 0x30)
            {
                seg051.Write(0, "Start range error in Load24x24Set", gbl.known01_02);
                seg051.WriteLn(gbl.known01_02);
                seg043.print_and_exit();
            }

            var_104 = null;
            seg040.load_dax(ref var_104, 0, 0, arg_4, var_100);

            int var_106 = arg_0 * var_104.bpp;
            int var_108 = arg_2 * var_104.bpp;

            if (gbl.dword_1C8F8 != null)
            {
                for (int i = 0; i < var_106; i++)
                {
                    gbl.dword_1C8F8.data[var_108 + i] = var_104.data[i];
                }
            }

            seg040.free_dax_block(ref var_104);
            seg043.clear_keyboard();

        }


        internal static void sub_760F7(int arg_0, int arg_2, int rowY, int colX)
        {
            if (arg_2 > 0x7f)
            {
                seg040.OverlayUnbounded(gbl.dword_1C8FC, arg_2, arg_2 & 0x7F, rowY, colX);
            }
            else
            {
                seg040.OverlayUnbounded(gbl.dword_1C8F8, arg_0, arg_2+1, rowY, colX);
            }
        }


        internal static void free_icon(byte arg_0)
        {
            if (gbl.combat_icons[arg_0, 0] != null)
            {
                seg040.free_dax_block(ref gbl.combat_icons[arg_0, 0]);
            }

            if (gbl.combat_icons[arg_0, 1] != null)
            {
                seg040.free_dax_block(ref gbl.combat_icons[arg_0, 1]);
            }
        }


        internal static void chead_cbody_comspr_icon(byte arg_0, byte arg_2, string arg_4)
        {
            string var_102;
            string var_100;

            var_100 = arg_4;

            string sub = seg051.Copy(5, 0, var_100);
            if (sub == "CHEAD" ||
                sub == "CBODY")
            {
                if (seg051.UpCase(var_100[var_100.Length - 1]) == 'T')
                {
                    arg_2 += 0x40;
                }

                var_100 = seg051.Copy(var_100.Length - 1, 0, var_100);

                seg040.load_dax(ref gbl.combat_icons[arg_0, 0], 0, 1, arg_2, var_100);
                seg040.load_dax(ref gbl.combat_icons[arg_0, 1], 0, 1, (byte)(arg_2 + 0x80), var_100);
            }
            else if (var_100 == "COMSPR" || var_100 == "ICON")
            {
                seg040.load_dax(ref gbl.combat_icons[arg_0, 0], 0, 1, arg_2, var_100);
                seg040.load_dax(ref gbl.combat_icons[arg_0, 1], 0, 1, (byte)(arg_2 + 0x80), var_100);

                if (var_100 == "ICON")
                {
                    seg040.DaxBlockRecolor(gbl.combat_icons[arg_0, 0], 0, 0, gbl.unk_16E50, gbl.unk_16E30);
                    seg040.DaxBlockRecolor(gbl.combat_icons[arg_0, 1], 0, 0, gbl.unk_16E50, gbl.unk_16E30);
                }
            }
            else
            {
                seg051.Str(1, out var_102, 0, gbl.game_area);
                seg040.load_dax(ref gbl.combat_icons[arg_0, 0], 0, 1, arg_2, var_100 + var_102);
                seg040.DaxBlockRecolor(gbl.combat_icons[arg_0, 0], 0, 0, gbl.unk_16E40, gbl.unk_16E30);

                seg040.load_dax(ref gbl.combat_icons[arg_0, 1], 0, 1, (byte)(arg_2 + 0x80), var_100 + var_102);
                seg040.DaxBlockRecolor(gbl.combat_icons[arg_0, 1], 0, 0, gbl.unk_16E40, gbl.unk_16E30);
            }

            seg043.clear_keyboard();
        }


        internal static void draw_combat_icon(int iconIndex, int iconState, byte arg_4, int tileY, int tileX) /* sub_76504 */
        {
            //TODO workout what arg_4 is for?
            DaxBlock icon = gbl.combat_icons[iconIndex, iconState];

            if (icon != null)
            {
                if (arg_4 > 3)
                {
                    DaxBlock flipped;
                    seg040.init_dax_block(out flipped, 1, 1, 3, 0x18);
                    seg040.flipIconLeftToRight(flipped, icon);
                    icon = flipped;
                }

                seg040.draw_picture(icon, (tileY * 3) + 1, (tileX * 3) + 1, 0);
            }
        }
    }
}