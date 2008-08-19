using Classes;

namespace engine
{
    class ovr017
    {
        internal static void sub_4708B(ref StringList arg_2, ref StringList arg_6, short arg_A, short arg_C, short arg_E, string arg_10)
        {
            byte var_164;
            string var_163;
            File var_112 = new File();
            SearchRec var_90;
            StringList var_61 = null;
            StringList var_5D;
            StringList var_59 = null;
            StringList var_55;
            string var_51;

            var_51 = arg_10;

            var_55 = null;
            var_5D = null;
            byte[] data = new byte[16];

            seg046.FINDFIRST(out var_90, 0, var_51);

            while (gbl.FIND_result == 0)
            {
                var_112.Assign(gbl.SavePath + var_90.fileName);
                seg051.Reset(var_112);

                if (seg051.FileSize(var_112) == arg_A)
                {

                    var_55 = new StringList();
                    var_5D = new StringList();

                    seg051.Seek(arg_E, var_112);

                    seg051.BlockRead(16, data, var_112);
                    var_55.s = Sys.ArrayToString(data, 0, 16);

                    seg051.Seek(arg_C, var_112);

                    if (gbl.import_from == ImportSource.Hillsfar)
                    {
                        var_164 = 0;
                    }
                    else
                    {
                        seg051.BlockRead(1, data, var_112);
                        var_164 = data[0];
                    }

                    var_5D.s = var_90.fileName;

                    if (seg051.Copy(4, 9, var_90.fileName) == ".SAV")
                    {
                        var_163 = "from saved game " + var_90.fileName[7].ToString();
                    }
                    else
                    {
                        var_163 = string.Empty;
                    }

                    var_55.s += seg051.Copy(15 - var_55.s.Length, 1, "         ") + var_163;

                    bool found = false;
                    foreach(Player player_ptr in gbl.player_next_ptr)
                    {
                        string var_275 = seg051.Copy(15, 1, var_55.s);
                        string var_475 = string.Format("{0,-15}", player_ptr.name);

                        if (var_275 == var_475)
                        {
                            found = true;
                            break;
                        }
                    }

                    if (var_164 > 0x7F ||
                        found == true)
                    {
                        var_55 = null;
                        var_5D = null;
                    }

                    if (var_55 != null)
                    {
                        if (arg_6 == null)
                        {
                            arg_6 = var_55;
                            var_59 = arg_6;
                            arg_2 = var_5D;
                            var_61 = arg_2;
                        }
                        else
                        {
                            var_59.next = var_55;
                            var_59 = var_59.next;
                            var_61.next = var_5D;
                            var_61 = var_61.next;
                        }
                    }
                }

                seg051.Close(var_112);
                seg046.FINDNEXT(var_90);
            }
        }

        static byte[] unk_16818 = { 0, 0, 4 };
        static short[] unk_1681B = { 0xf7, 0x84, 0x13 };
        static short[] unk_16821 = { 0x01a6, 0x11d, 0xbc };

        internal static void sub_47465(out StringList arg_0, out StringList arg_4)
        {
            arg_4 = null;
            arg_0 = null;

            if (save() == true)
            {
                if (gbl.import_from == ImportSource.Curse)
                {
                    sub_4708B(ref arg_0, ref arg_4, unk_16821[0], unk_1681B[0], unk_16818[0], gbl.SavePath + "*.guy");
                }
                else if (gbl.import_from == ImportSource.Pool)
                {
                    sub_4708B(ref arg_0, ref arg_4, unk_16821[1], unk_1681B[1], unk_16818[1], gbl.SavePath + "*.cha");
                    sub_4708B(ref arg_0, ref arg_4, unk_16821[1], unk_1681B[1], unk_16818[1], gbl.SavePath + "*.sav");
                }
                else if (gbl.import_from == ImportSource.Hillsfar)
                {
                    sub_4708B(ref arg_0, ref  arg_4, unk_16821[2], unk_1681B[2], unk_16818[2], gbl.SavePath + "*.hil");
                }
            }
        }

        static Set unk_47635 = new Set(0x0001, new byte[] { 0x21 });

        internal static bool save()
        {
            SearchRec var_2E;
            short var_3;

            if (gbl.import_from == ImportSource.Curse)
            {
                try
                {
                    if (System.IO.Directory.Exists(gbl.SavePath) == false)
                    {
                        System.IO.Directory.CreateDirectory(gbl.SavePath);
                    }
                }
                catch (System.Exception ex)
                {
                    string s = "Unexpected error during save: " + ex.ToString();
                    seg041.displayAndDebug(s, 0, 14);

                    return false;
                }
            }
            else if (gbl.import_from == ImportSource.Pool)
            {
                do
                {
                    seg046.FINDFIRST(out var_2E, 16, gbl.SavePath);
                    var_3 = gbl.FIND_result;

                    if (var_3 != 0)
                    {
                        string text = "Unexpected error during save: " + var_3.ToString();
                        seg041.displayAndDebug(text, 0, 14);

                        return false;
                    }

                } while (var_3 != 0);
            }
            else if (gbl.import_from == ImportSource.Hillsfar)
            {
                do
                {
                    seg046.FINDFIRST(out var_2E, 16, seg051.Copy(gbl.SavePath.Length - 1, 1, gbl.SavePath));
                    var_3 = gbl.FIND_result;

                    if (var_3 != 0)
                    {
                        string s = "Unexpected error during save: " + var_3.ToString();
                        seg041.displayAndDebug(s, 0, 14);

                        return false;
                    }
                } while (var_3 != 0);
            }

            return true;
        }


        static void MergeIcons(DaxBlock destIcon, DaxBlock srcIcon) /* icon_xx */
        {
            for (int i = 0; i < srcIcon.bpp; i++)
            {
                byte a = destIcon.data[i];
                byte b = srcIcon.data[i];

                if (a == 16 && b == 16)
                {
                    destIcon.data[i] = 16;
                }
                else if (a == 16)
                {
                    destIcon.data[i] = b;
                }
                else if (b == 16)
                {
                    destIcon.data[i] = a;
                }
                else 
                {
                    destIcon.data[i] = (byte)(a | b);
                }

                //icon.data[i] = (byte)(((a == 16) ? (byte)0 : a) | ((b == 16) ? (byte)0 : b));

                a = destIcon.data_ptr[i];
                b = srcIcon.data_ptr[i];

                //TODO not sure about this...
                if (a == 16 && b == 16)
                {
                    destIcon.data_ptr[i] = 16;
                }
                else if (a == 16)
                {
                    destIcon.data_ptr[i] = b;
                }
                else if (b == 16)
                {
                    destIcon.data_ptr[i] = a;
                }
                else
                {
                    destIcon.data_ptr[i] = (byte)(a & b);
                }
                //icon.data_ptr[i] = (byte)(((a == 16) ? (byte)0xF : a) & ((b == 16) ? (byte)0xF : b));

                 // this worked when the data was packed, but now it's not...
                //icon.data[i] |= arg_4.data[i];
                //icon.data_ptr[i] &= arg_4.data_ptr[i];
            }
        }


        internal static void LoadPlayerCombatIcon(bool recolour) /* sub_47A90 */
        {
            seg042.set_game_area(1);

            Player player = gbl.player_ptr;

            char[] unk_16827 = new char[] { '\0', 'S', 'T' };

            ovr034.chead_cbody_comspr_icon(11, player.head_icon, "CHEAD" + unk_16827[player.icon_size].ToString());
            ovr034.chead_cbody_comspr_icon(player.icon_id, player.weapon_icon, "CBODY" + unk_16827[player.icon_size].ToString());

            MergeIcons(gbl.combat_icons[player.icon_id, 0], gbl.combat_icons[11, 0]);
            MergeIcons(gbl.combat_icons[player.icon_id, 1], gbl.combat_icons[11, 1]);

            if (recolour)
            {
                byte[] var_23 = new byte[16];
                byte[] var_13 = new byte[16];

                for (byte i = 0; i <= 15; i++)
                {
                    var_13[i] = i;
                    var_23[i] = i;
                }

                for (int i = 0; i < 6; i++)
                {
                    var_23[gbl.default_icon_colours[i]] = (byte)(player.icon_colours[i] & 0x0F);
                    var_23[gbl.default_icon_colours[i] + 8] = (byte)((player.icon_colours[i] & 0xF0) >> 4);
                }

                seg040.DaxBlockRecolor(gbl.combat_icons[player.icon_id, 0], 0, 0, var_23, var_13);
                seg040.DaxBlockRecolor(gbl.combat_icons[player.icon_id, 1], 0, 0, var_23, var_13);
            }

            ovr034.free_icon(11);
            seg042.restore_game_area();
            seg043.clear_keyboard();
        }


        internal static void remove_player_file(Player player)
        {
            string full_path = gbl.SavePath + seg042.clean_string(player.name);

            seg042.delete_file(full_path + ".guy");
            seg042.delete_file(full_path + ".swg");
            seg042.delete_file(full_path + ".fx");
        }

        internal static void sub_47DFC(string arg_0, Player player)
        {
            char input_key;
            File file = new File();

            gbl.import_from = ImportSource.Curse;

            do
            {
                if (save() == false)
                {
                    return;
                }

                int required_space = Player.StructSize;

                Item item = player.itemsPtr;

                while (item != null)
                {
                    required_space += Item.StructSize;
                    item = item.next;
                }

                Affect affect = player.affect_ptr;
                while (affect != null)
                {
                    required_space += 9;
                    affect = affect.next;
                }

                input_key = 'O';

                if (required_space > seg046.getDiskSpace((byte)(char.ToUpper(gbl.SavePath[0]) - 0x40)))
                {
                    seg041.displayAndDebug("Can't save.  No room on this disk.", 0, 14);

                    bool dummy_bool;
                    input_key = ovr027.displayInput(out dummy_bool, false, 0, 15, 10, 13, "Ok  Try another disk", "Lose character? ");
                }
            } while (input_key != 0x4F);

            string ext_text;
            string file_text;

            if (arg_0 == "")
            {
                ext_text = ".guy";
                file_text = seg042.clean_string(player.name);
            }
            else
            {
                ext_text = ".sav";
                file_text = arg_0;
            }

            input_key = 'N';

            while (input_key == 'N' &&
                arg_0.Length == 0 &&
                seg042.file_find(gbl.SavePath + file_text + ext_text) == true)
            {
                input_key = ovr027.yes_no(15, 10, 14, "Overwrite " + file_text + "? ");

                if (input_key == 'N')
                {
                    file_text = string.Empty;

                    while (file_text == string.Empty)
                    {
                        file_text = seg041.getUserInputString(8, 0, 10, "New file name: ");
                    }
                }
            }

            file.Assign(gbl.SavePath + file_text + ext_text);

            seg051.Rewrite(file);

            seg051.BlockWrite(Player.StructSize, player.ToByteArray(), file);
            seg051.Close(file);

            seg042.delete_file(gbl.SavePath + file_text + ".swg");

            if (player.itemsPtr != null)
            {

                file.Assign(gbl.SavePath + file_text + ".swg");
                seg051.Rewrite(file);
                Item item = player.itemsPtr;

                while (item != null)
                {
                    seg051.BlockWrite(Item.StructSize, item.ToByteArray(), file);
                    item = item.next;
                }

                seg051.Close(file);
            }

            seg042.delete_file(gbl.SavePath + file_text + ".fx");

            if (player.affect_ptr != null)
            {
                file.Assign(gbl.SavePath + file_text + ".fx");
                seg051.Rewrite(file);

                Affect affect = player.affect_ptr;
                while (affect != null)
                {
                    seg051.BlockWrite(Affect.StructSize, affect.ToByteArray(), file);

                    affect = affect.next;
                }

                seg051.Close(file);
            }
        }


        internal static bool sub_483AE(ref short bp_var_182, ref bool bp_var_1BC, string bp_var_1BB, string bp_var_2DF, string bp_var_2DA)
        {
            SearchRec var_2C;

            byte[] data = new byte[0x10];
            string var_3C = string.Empty;

            seg046.FINDFIRST(out var_2C, 0, gbl.SavePath + "*" + bp_var_2DF);

            while (gbl.FIND_result == 0 &&
                var_3C != bp_var_2DA)
            {
                File file;
                bp_var_1BC = seg042.find_and_open_file(out file, false, gbl.SavePath + var_2C.fileName);

                seg051.Seek(0, file);

                seg051.BlockRead(out bp_var_182, 0x10, data, file);
                var_3C = Sys.ArrayToString(data, 0, 0x10);

                seg051.Close(file);

                seg046.FINDNEXT(var_2C);
            }

            bool result = (var_3C == bp_var_2DA);
            return result;
        }


        internal static void load_pool_rad_player(Player player, PoolRadPlayer bp_var_1C0)
        {
            /* nested function, arg_0 is BP */

            player.race = (Race)bp_var_1C0.race;
            player.sex = bp_var_1C0.sex;

            int race = (int)player.race;
            for (int stat = 0; stat < 6; stat++)
            {
                player.stats[stat].tmp = bp_var_1C0.strength[stat];

                switch ((Stat)stat)
                {
                    case Stat.STR:
                        if (player.stats[stat].tmp < ovr018.racial_stats_limits[race].str_min[player.sex])
                        {
                            player.stats[stat].tmp = ovr018.racial_stats_limits[race].str_min[player.sex];
                        }

                        if (player.stats[stat].tmp > ovr018.racial_stats_limits[race].str_max[player.sex])
                        {
                            player.stats[stat].tmp = ovr018.racial_stats_limits[race].str_max[player.sex];
                        }
                        break;

                    case Stat.INT:
                        if (player.stats[stat].tmp < ovr018.racial_stats_limits[race].int_min)
                        {
                            player.stats[stat].tmp = ovr018.racial_stats_limits[race].int_min;
                        }

                        if (player.stats[stat].tmp > ovr018.racial_stats_limits[race].int_max)
                        {
                            player.stats[stat].tmp = ovr018.racial_stats_limits[race].int_max;
                        }
                        break;

                    case Stat.WIS:
                        if (player.stats[stat].tmp < ovr018.racial_stats_limits[race].wis_min)
                        {
                            player.stats[stat].tmp = ovr018.racial_stats_limits[race].wis_min;
                        }

                        if (player.stats[stat].tmp > ovr018.racial_stats_limits[race].wis_max)
                        {
                            player.stats[stat].tmp = ovr018.racial_stats_limits[race].wis_max;
                        }
                        break;

                    case Stat.DEX:
                        if (player.stats[stat].tmp < ovr018.racial_stats_limits[race].dex_min)
                        {
                            player.stats[stat].tmp = ovr018.racial_stats_limits[race].dex_min;
                        }

                        if (player.stats[stat].tmp > ovr018.racial_stats_limits[race].dex_max)
                        {
                            player.stats[stat].tmp = ovr018.racial_stats_limits[race].dex_max;
                        }
                        break;

                    case Stat.CON:
                        if (player.stats[stat].tmp < ovr018.racial_stats_limits[race].con_min)
                        {
                            player.stats[stat].tmp = ovr018.racial_stats_limits[race].con_min;
                        }

                        if (player.stats[stat].tmp > ovr018.racial_stats_limits[race].con_max)
                        {
                            player.stats[stat].tmp = ovr018.racial_stats_limits[race].con_max;
                        }
                        break;

                    case Stat.CHA:
                        if (player.stats[stat].tmp < ovr018.racial_stats_limits[race].cha_min)
                        {
                            player.stats[stat].tmp = ovr018.racial_stats_limits[race].cha_min;
                        }

                        if (player.stats[stat].tmp > ovr018.racial_stats_limits[race].cha_max)
                        {
                            player.stats[stat].tmp = ovr018.racial_stats_limits[race].cha_max;
                        }
                        break;
                }

                player.stats[stat].max = player.stats[stat].tmp;
            }

            player.tmp_str_00 = bp_var_1C0.strength_100;
            throw new System.NotSupportedException();//les	di, int ptr [bp+player.offset]
            throw new System.NotSupportedException();//mov	al, es:[di+119h]
            throw new System.NotSupportedException();//cbw
            throw new System.NotSupportedException();//mov	dx, ax
            throw new System.NotSupportedException();//les	di, int ptr [bp+player.offset]
            throw new System.NotSupportedException();//mov	al, es:[di+74h]
            throw new System.NotSupportedException();//cbw
            throw new System.NotSupportedException();//mov	di, ax
            throw new System.NotSupportedException();//mov	cl, 4
            throw new System.NotSupportedException();//shl	di, cl
            throw new System.NotSupportedException();//add	di, dx
            throw new System.NotSupportedException();//mov	al, [di+3F8Ch]
            throw new System.NotSupportedException();//les	di, int ptr [bp+player.offset]
            throw new System.NotSupportedException();//cmp	al, es:[di+10h]
            throw new System.NotSupportedException();//jbe	loc_48970
            throw new System.NotSupportedException();//les	di, int ptr [bp+player.offset]
            throw new System.NotSupportedException();//mov	al, es:[di+119h]
            throw new System.NotSupportedException();//cbw
            throw new System.NotSupportedException();//mov	dx, ax
            throw new System.NotSupportedException();//les	di, int ptr [bp+player.offset]
            throw new System.NotSupportedException();//mov	al, es:[di+74h]
            throw new System.NotSupportedException();//cbw
            throw new System.NotSupportedException();//mov	di, ax
            throw new System.NotSupportedException();//mov	cl, 4
            throw new System.NotSupportedException();//shl	di, cl
            throw new System.NotSupportedException();//add	di, dx
            throw new System.NotSupportedException();//mov	al, [di+3F8Ch]
            throw new System.NotSupportedException();//les	di, int ptr [bp+player.offset]
            throw new System.NotSupportedException();//mov	es:[di+10h], al
            throw new System.NotSupportedException();//loc_48970:

            player.max_str_00 = bp_var_1C0.strength_100;
            player.field_73 = bp_var_1C0.field_2D;
            player._class = (ClassId)bp_var_1C0._class;
            player.age = bp_var_1C0.age;
            player.hit_point_max = bp_var_1C0.hp_max;

            throw new System.NotSupportedException();//mov	di, [bp+arg_0]
            throw new System.NotSupportedException();//les	di, ss:[di-0x1C0]
            throw new System.NotSupportedException();//add	di, 0x33
            throw new System.NotSupportedException();//push	es
            throw new System.NotSupportedException();//push	di
            throw new System.NotSupportedException();//les	di, int ptr [bp+player.offset]
            throw new System.NotSupportedException();//add	di, 0x79
            throw new System.NotSupportedException();//push	es
            throw new System.NotSupportedException();//push	di
            throw new System.NotSupportedException();//mov	ax, 0x38
            throw new System.NotSupportedException();//push	ax
            throw new System.NotSupportedException();//call	Move(Any &,Any &,Word)
            throw new System.NotSupportedException();//les	di, int ptr [bp+player.offset]
            throw new System.NotSupportedException();//mov	byte ptr es:[di+9Ch], 0
            throw new System.NotSupportedException();//mov	di, [bp+arg_0]
            throw new System.NotSupportedException();//les	di, ss:[di-0x1C0]
            throw new System.NotSupportedException();//mov	al, es:[di+6Bh]
            throw new System.NotSupportedException();//les	di, int ptr [bp+player.offset]
            throw new System.NotSupportedException();//mov	es:[di+0DDh], al
            throw new System.NotSupportedException();//mov	di, [bp+arg_0]
            throw new System.NotSupportedException();//les	di, ss:[di-0x1C0]
            throw new System.NotSupportedException();//mov	al, es:[di+6Ch]
            throw new System.NotSupportedException();//les	di, int ptr [bp+player.offset]
            throw new System.NotSupportedException();//mov	es:[di+0DEh], al
            throw new System.NotSupportedException();//mov	di, [bp+arg_0]
            throw new System.NotSupportedException();//les	di, ss:[di-0x1C0]
            throw new System.NotSupportedException();//add	di, 0x6D
            throw new System.NotSupportedException();//push	es
            throw new System.NotSupportedException();//push	di
            throw new System.NotSupportedException();//les	di, int ptr [bp+player.offset]
            throw new System.NotSupportedException();//add	di, 0x0DF
            throw new System.NotSupportedException();//push	es
            throw new System.NotSupportedException();//push	di
            throw new System.NotSupportedException();//mov	ax, 5
            throw new System.NotSupportedException();//push	ax
            throw new System.NotSupportedException();//call	Move(Any &,Any &,Word)
            throw new System.NotSupportedException();//mov	di, [bp+arg_0]
            throw new System.NotSupportedException();//les	di, ss:[di-0x1C0]
            throw new System.NotSupportedException();//mov	al, es:[di+72h]
            throw new System.NotSupportedException();//les	di, int ptr [bp+player.offset]
            throw new System.NotSupportedException();//mov	es:[di+0E4h], al
            throw new System.NotSupportedException();//mov	di, [bp+arg_0]
            throw new System.NotSupportedException();//les	di, ss:[di-0x1C0]
            throw new System.NotSupportedException();//mov	al, es:[di+73h]
            throw new System.NotSupportedException();//les	di, int ptr [bp+player.offset]
            throw new System.NotSupportedException();//mov	es:[di+0E5h], al
            throw new System.NotSupportedException();//les	di, int ptr [bp+player.offset]
            throw new System.NotSupportedException();//mov	al, es:[di+0E5h]
            throw new System.NotSupportedException();//les	di, int ptr [bp+player.offset]
            throw new System.NotSupportedException();//mov	es:[di+0E6h], al
            throw new System.NotSupportedException();//mov	di, [bp+arg_0]
            throw new System.NotSupportedException();//les	di, ss:[di-0x1C0]
            throw new System.NotSupportedException();//mov	al, es:[di+74h]
            throw new System.NotSupportedException();//les	di, int ptr [bp+player.offset]
            throw new System.NotSupportedException();//mov	es:[di+0E7h], al
            throw new System.NotSupportedException();//mov	di, [bp+arg_0]
            throw new System.NotSupportedException();//les	di, ss:[di-0x1C0]
            throw new System.NotSupportedException();//mov	al, es:[di+75h]
            throw new System.NotSupportedException();//les	di, int ptr [bp+player.offset]
            throw new System.NotSupportedException();//mov	es:[di+0E8h], al
            throw new System.NotSupportedException();//mov	di, [bp+arg_0]
            throw new System.NotSupportedException();//les	di, ss:[di-0x1C0]
            throw new System.NotSupportedException();//mov	al, es:[di+76h]
            throw new System.NotSupportedException();//les	di, int ptr [bp+player.offset]
            throw new System.NotSupportedException();//mov	es:[di+0E9h], al
            throw new System.NotSupportedException();//mov	di, [bp+arg_0]
            throw new System.NotSupportedException();//les	di, ss:[di-0x1C0]
            throw new System.NotSupportedException();//add	di, 0x77
            throw new System.NotSupportedException();//push	es
            throw new System.NotSupportedException();//push	di
            throw new System.NotSupportedException();//les	di, int ptr [bp+player.offset]
            throw new System.NotSupportedException();//add	di, 0x0EA
            throw new System.NotSupportedException();//push	es
            throw new System.NotSupportedException();//push	di
            throw new System.NotSupportedException();//mov	ax, 8
            throw new System.NotSupportedException();//push	ax
            throw new System.NotSupportedException();//call	Move(Any &,Any &,Word)
            throw new System.NotSupportedException();//mov	di, [bp+arg_0]
            throw new System.NotSupportedException();//les	di, ss:[di-0x1C0]
            throw new System.NotSupportedException();//mov	al, es:[di+83h]
            throw new System.NotSupportedException();//les	di, int ptr [bp+player.offset]
            throw new System.NotSupportedException();//mov	es:[di+0F6h], al
            throw new System.NotSupportedException();//mov	di, [bp+arg_0]
            throw new System.NotSupportedException();//les	di, ss:[di-0x1C0]
            throw new System.NotSupportedException();//mov	al, es:[di+84h]
            throw new System.NotSupportedException();//les	di, int ptr [bp+player.offset]
            throw new System.NotSupportedException();//mov	es:[di+0F7h], al
            throw new System.NotSupportedException();//mov	di, [bp+arg_0]
            throw new System.NotSupportedException();//les	di, ss:[di-0x1C0]
            throw new System.NotSupportedException();//mov	al, es:[di+85h]
            throw new System.NotSupportedException();//les	di, int ptr [bp+player.offset]
            throw new System.NotSupportedException();//mov	es:[di+0F8h], al
            throw new System.NotSupportedException();//mov	di, [bp+arg_0]
            throw new System.NotSupportedException();//les	di, ss:[di-0x1C0]
            throw new System.NotSupportedException();//mov	al, es:[di+86h]
            throw new System.NotSupportedException();//les	di, int ptr [bp+player.offset]
            throw new System.NotSupportedException();//mov	es:[di+0F9h], al
            throw new System.NotSupportedException();//mov	di, [bp+arg_0]
            throw new System.NotSupportedException();//les	di, ss:[di-0x1C0]
            throw new System.NotSupportedException();//mov	al, es:[di+87h]
            throw new System.NotSupportedException();//les	di, int ptr [bp+player.offset]
            throw new System.NotSupportedException();//mov	es:[di+0FAh], al
            throw new System.NotSupportedException();//les	di, int ptr [bp+player.offset]
            throw new System.NotSupportedException();//mov	short ptr es:[di+103h], 0x12C
            throw new System.NotSupportedException();//mov	di, [bp+arg_0]
            throw new System.NotSupportedException();//les	di, ss:[di-0x1C0]
            throw new System.NotSupportedException();//add	di, 0x96
            throw new System.NotSupportedException();//push	es
            throw new System.NotSupportedException();//push	di
            throw new System.NotSupportedException();//les	di, int ptr [bp+player.offset]
            throw new System.NotSupportedException();//add	di, 0x109
            throw new System.NotSupportedException();//push	es
            throw new System.NotSupportedException();//push	di
            throw new System.NotSupportedException();//mov	ax, 8
            throw new System.NotSupportedException();//push	ax
            throw new System.NotSupportedException();//call	Move(Any &,Any &,Word)
            throw new System.NotSupportedException();//mov	di, [bp+arg_0]
            throw new System.NotSupportedException();//les	di, ss:[di-0x1C0]
            throw new System.NotSupportedException();//mov	al, es:[di+9Fh]
            throw new System.NotSupportedException();//les	di, int ptr [bp+player.offset]
            throw new System.NotSupportedException();//mov	es:[di+11Ah], al
            throw new System.NotSupportedException();//mov	di, [bp+arg_0]
            throw new System.NotSupportedException();//les	di, ss:[di-0x1C0]
            throw new System.NotSupportedException();//mov	al, es:[di+0A0h]
            throw new System.NotSupportedException();//les	di, int ptr [bp+player.offset]
            throw new System.NotSupportedException();//mov	es:[di+11Bh], al
            throw new System.NotSupportedException();//mov	di, [bp+arg_0]
            throw new System.NotSupportedException();//les	di, ss:[di-0x1C0]
            throw new System.NotSupportedException();//add	di, 0x0A1
            throw new System.NotSupportedException();//push	es
            throw new System.NotSupportedException();//push	di
            throw new System.NotSupportedException();//les	di, int ptr [bp+player.offset]
            throw new System.NotSupportedException();//add	di, 0x11C
            throw new System.NotSupportedException();//push	es
            throw new System.NotSupportedException();//push	di
            throw new System.NotSupportedException();//mov	ax, 2
            throw new System.NotSupportedException();//push	ax
            throw new System.NotSupportedException();//call	Move(Any &,Any &,Word)
            throw new System.NotSupportedException();//mov	di, [bp+arg_0]
            throw new System.NotSupportedException();//les	di, ss:[di-0x1C0]
            throw new System.NotSupportedException();//add	di, 0x0A3
            throw new System.NotSupportedException();//push	es
            throw new System.NotSupportedException();//push	di
            throw new System.NotSupportedException();//les	di, int ptr [bp+player.offset]
            throw new System.NotSupportedException();//add	di, 0x11E
            throw new System.NotSupportedException();//push	es
            throw new System.NotSupportedException();//push	di
            throw new System.NotSupportedException();//mov	ax, 2
            throw new System.NotSupportedException();//push	ax
            throw new System.NotSupportedException();//call	Move(Any &,Any &,Word)
            throw new System.NotSupportedException();//mov	di, [bp+arg_0]
            throw new System.NotSupportedException();//les	di, ss:[di-0x1C0]
            throw new System.NotSupportedException();//add	di, 0x0A5
            throw new System.NotSupportedException();//push	es
            throw new System.NotSupportedException();//push	di
            throw new System.NotSupportedException();//les	di, int ptr [bp+player.offset]
            throw new System.NotSupportedException();//add	di, 0x120
            throw new System.NotSupportedException();//push	es
            throw new System.NotSupportedException();//push	di
            throw new System.NotSupportedException();//mov	ax, 2
            throw new System.NotSupportedException();//push	ax
            throw new System.NotSupportedException();//call	Move(Any &,Any &,Word)
            throw new System.NotSupportedException();//mov	di, [bp+arg_0]
            throw new System.NotSupportedException();//les	di, ss:[di-0x1C0]
            throw new System.NotSupportedException();//add	di, 0x0A7
            throw new System.NotSupportedException();//push	es
            throw new System.NotSupportedException();//push	di
            throw new System.NotSupportedException();//les	di, int ptr [bp+player.offset]
            throw new System.NotSupportedException();//add	di, 0x122
            throw new System.NotSupportedException();//push	es
            throw new System.NotSupportedException();//push	di
            throw new System.NotSupportedException();//mov	ax, 2
            throw new System.NotSupportedException();//push	ax
            throw new System.NotSupportedException();//call	Move(Any &,Any &,Word)
            throw new System.NotSupportedException();//mov	di, [bp+arg_0]
            throw new System.NotSupportedException();//les	di, ss:[di-0x1C0]
            throw new System.NotSupportedException();//mov	al, es:[di+0A9h]
            throw new System.NotSupportedException();//les	di, int ptr [bp+player.offset]
            throw new System.NotSupportedException();//mov	es:[di+124h], al
            throw new System.NotSupportedException();//mov	di, [bp+arg_0]
            throw new System.NotSupportedException();//les	di, ss:[di-0x1C0]
            throw new System.NotSupportedException();//mov	al, es:[di+0AAh]
            throw new System.NotSupportedException();//les	di, int ptr [bp+player.offset]
            throw new System.NotSupportedException();//mov	es:[di+125h], al
            throw new System.NotSupportedException();//mov	di, [bp+arg_0]
            throw new System.NotSupportedException();//les	di, ss:[di-0x1C0]
            throw new System.NotSupportedException();//mov	al, es:[di+0ABh]
            throw new System.NotSupportedException();//les	di, int ptr [bp+player.offset]
            throw new System.NotSupportedException();//mov	es:[di+126h], al
            throw new System.NotSupportedException();//mov	di, [bp+arg_0]
            throw new System.NotSupportedException();//les	di, ss:[di-0x1C0]
            throw new System.NotSupportedException();//mov	ax, es:[di+0ACh]
            throw new System.NotSupportedException();//mov	dx, es:[di+0AEh]
            throw new System.NotSupportedException();//les	di, int ptr [bp+player.offset]
            throw new System.NotSupportedException();//mov	es:[di+127h], ax
            throw new System.NotSupportedException();//mov	es:[di+129h], dx
            throw new System.NotSupportedException();//mov	di, [bp+arg_0]
            throw new System.NotSupportedException();//les	di, ss:[di-0x1C0]
            throw new System.NotSupportedException();//mov	al, es:[di+0B0h]
            throw new System.NotSupportedException();//les	di, int ptr [bp+player.offset]
            throw new System.NotSupportedException();//mov	es:[di+12Bh], al
            throw new System.NotSupportedException();//mov	di, [bp+arg_0]
            throw new System.NotSupportedException();//les	di, ss:[di-0x1C0]
            throw new System.NotSupportedException();//mov	al, es:[di+0B1h]
            throw new System.NotSupportedException();//les	di, int ptr [bp+player.offset]
            throw new System.NotSupportedException();//mov	es:[di+12Ch], al
            for (int var_2 = 1; var_2 <= 3; var_2++)
            {
                throw new System.NotSupportedException();//mov	al, [bp+var_2]
                throw new System.NotSupportedException();//cbw
                throw new System.NotSupportedException();//mov	di, [bp+arg_0]
                throw new System.NotSupportedException();//les	di, ss:[di-0x1C0]
                throw new System.NotSupportedException();//add	di, ax
                throw new System.NotSupportedException();//mov	dl, es:[di+0B1h]
                throw new System.NotSupportedException();//mov	al, [bp+var_2]
                throw new System.NotSupportedException();//cbw
                throw new System.NotSupportedException();//les	di, int ptr [bp+player.offset]
                throw new System.NotSupportedException();//add	di, ax
                throw new System.NotSupportedException();//mov	es:[di+12Ch], dl
                throw new System.NotSupportedException();//mov	al, [bp+var_2]
                throw new System.NotSupportedException();//cbw
                throw new System.NotSupportedException();//mov	di, [bp+arg_0]
                throw new System.NotSupportedException();//les	di, ss:[di-0x1C0]
                throw new System.NotSupportedException();//add	di, ax
                throw new System.NotSupportedException();//mov	dl, es:[di+0B4h]
                throw new System.NotSupportedException();//mov	al, [bp+var_2]
                throw new System.NotSupportedException();//cbw
                throw new System.NotSupportedException();//les	di, int ptr [bp+player.offset]
                throw new System.NotSupportedException();//add	di, ax
                throw new System.NotSupportedException();//mov	es:[di+136h], dl
            }
            throw new System.NotSupportedException();//mov	di, [bp+arg_0]
            throw new System.NotSupportedException();//les	di, ss:[di-0x1C0]
            throw new System.NotSupportedException();//mov	ax, es:[di+0B8h]
            throw new System.NotSupportedException();//les	di, int ptr [bp+player.offset]
            throw new System.NotSupportedException();//mov	es:[di+13Ch], ax
            throw new System.NotSupportedException();//mov	di, [bp+arg_0]
            throw new System.NotSupportedException();//les	di, ss:[di-0x1C0]
            throw new System.NotSupportedException();//mov	al, es:[di+0BAh]
            throw new System.NotSupportedException();//les	di, int ptr [bp+player.offset]
            throw new System.NotSupportedException();//mov	es:[di+13Eh], al
            throw new System.NotSupportedException();//mov	di, [bp+arg_0]
            throw new System.NotSupportedException();//les	di, ss:[di-0x1C0]
            throw new System.NotSupportedException();//mov	al, es:[di+0BBh]
            throw new System.NotSupportedException();//les	di, int ptr [bp+player.offset]
            throw new System.NotSupportedException();//mov	es:[di+13Fh], al
            throw new System.NotSupportedException();//mov	di, [bp+arg_0]
            throw new System.NotSupportedException();//les	di, ss:[di-0x1C0]
            throw new System.NotSupportedException();//mov	al, es:[di+0BCh]
            throw new System.NotSupportedException();//les	di, int ptr [bp+player.offset]
            throw new System.NotSupportedException();//mov	es:[di+140h], al
            throw new System.NotSupportedException();//mov	di, [bp+arg_0]
            throw new System.NotSupportedException();//les	di, ss:[di-0x1C0]
            throw new System.NotSupportedException();//mov	al, es:[di+0BDh]
            throw new System.NotSupportedException();//les	di, int ptr [bp+player.offset]
            throw new System.NotSupportedException();//mov	es:[di+141h], al
            throw new System.NotSupportedException();//mov	di, [bp+arg_0]
            throw new System.NotSupportedException();//les	di, ss:[di-0x1C0]
            throw new System.NotSupportedException();//mov	al, es:[di+0BEh]
            throw new System.NotSupportedException();//les	di, int ptr [bp+player.offset]
            throw new System.NotSupportedException();//mov	es:[di+142h], al
            throw new System.NotSupportedException();//mov	di, [bp+arg_0]
            throw new System.NotSupportedException();//les	di, ss:[di-0x1C0]
            throw new System.NotSupportedException();//mov	al, es:[di+0C0h]
            throw new System.NotSupportedException();//les	di, int ptr [bp+player.offset]
            throw new System.NotSupportedException();//mov	es:[di+144h], al

            System.Array.Copy(bp_var_1C0.field_C1, player.icon_colours, 6);

            throw new System.NotSupportedException();//mov	di, [bp+arg_0]
            throw new System.NotSupportedException();//les	di, ss:[di-0x1C0]
            throw new System.NotSupportedException();//mov	al, es:[di+0C7h]
            throw new System.NotSupportedException();//les	di, int ptr [bp+player.offset]
            throw new System.NotSupportedException();//mov	es:[di+14Ch], al
            throw new System.NotSupportedException();//mov	di, [bp+arg_0]
            throw new System.NotSupportedException();//les	di, ss:[di-0x1C0]
            throw new System.NotSupportedException();//add	di, 0x0CC
            throw new System.NotSupportedException();//push	es
            throw new System.NotSupportedException();//push	di
            throw new System.NotSupportedException();//les	di, int ptr [bp+player.offset]
            throw new System.NotSupportedException();//add	di, 0x151
            throw new System.NotSupportedException();//push	es
            throw new System.NotSupportedException();//push	di
            throw new System.NotSupportedException();//mov	ax, 0x34
            throw new System.NotSupportedException();//push	ax
            throw new System.NotSupportedException();//call	Move(Any &,Any &,Word)
            throw new System.NotSupportedException();//mov	di, [bp+arg_0]
            throw new System.NotSupportedException();//les	di, ss:[di-0x1C0]
            throw new System.NotSupportedException();//mov	al, es:[di+100h]
            throw new System.NotSupportedException();//les	di, int ptr [bp+player.offset]
            throw new System.NotSupportedException();//mov	es:[di+185h], al
            throw new System.NotSupportedException();//mov	di, [bp+arg_0]
            throw new System.NotSupportedException();//les	di, ss:[di-0x1C0]
            throw new System.NotSupportedException();//mov	al, es:[di+101h]
            throw new System.NotSupportedException();//les	di, int ptr [bp+player.offset]
            throw new System.NotSupportedException();//mov	es:[di+186h], al
            throw new System.NotSupportedException();//mov	di, [bp+arg_0]
            throw new System.NotSupportedException();//les	di, ss:[di-0x1C0]
            throw new System.NotSupportedException();//mov	ax, es:[di+102h]
            throw new System.NotSupportedException();//les	di, int ptr [bp+player.offset]
            throw new System.NotSupportedException();//mov	es:[di+187h], ax
            throw new System.NotSupportedException();//mov	di, [bp+arg_0]
            throw new System.NotSupportedException();//les	di, ss:[di-0x1C0]
            throw new System.NotSupportedException();//mov	al, es:[di+10Ch]
            throw new System.NotSupportedException();//mov	player.health_status, al
            throw new System.NotSupportedException();//mov	di, [bp+arg_0]
            throw new System.NotSupportedException();//les	di, ss:[di-0x1C0]
            throw new System.NotSupportedException();//mov	al, es:[di+10Dh]
            throw new System.NotSupportedException();//les	di, int ptr [bp+player.offset]
            throw new System.NotSupportedException();//mov	es:[di+196h], al
            throw new System.NotSupportedException();//mov	di, [bp+arg_0]
            throw new System.NotSupportedException();//les	di, ss:[di-0x1C0]
            throw new System.NotSupportedException();//mov	al, es:[di+10Eh]
            throw new System.NotSupportedException();//les	di, int ptr [bp+player.offset]
            throw new System.NotSupportedException();//mov	es:[di+197h], al
            throw new System.NotSupportedException();//mov	di, [bp+arg_0]
            throw new System.NotSupportedException();//les	di, ss:[di-0x1C0]
            throw new System.NotSupportedException();//mov	al, es:[di+110h]
            throw new System.NotSupportedException();//les	di, int ptr [bp+player.offset]
            throw new System.NotSupportedException();//mov	es:[di+199h], al
            throw new System.NotSupportedException();//mov	di, [bp+arg_0]

            player.ac = bp_var_1C0.field_111;
            player.field_19B = bp_var_1C0.field_112;

            player.field_19C = bp_var_1C0.field_113;
            player.field_19D = bp_var_1C0.field_114;

            player.attack_dice_count = bp_var_1C0.field_115;
            player.field_19F = bp_var_1C0.field_116;

            player.attack_dice_size = bp_var_1C0.field_117;
            player.field_1A1 = bp_var_1C0.field_118;

            player.damageBonus = (sbyte)bp_var_1C0.field_119;
            player.field_1A3 = bp_var_1C0.field_11A;
            player.hit_point_current = bp_var_1C0.field_11B;
            player.movement = (byte)bp_var_1C0.field_11C;
        }


        internal static void sub_48F35(HillsFarPlayer hills_far_player, Player bp_player_ptr, Player bp_var_1CA)
        {
            Player var_7 = bp_player_ptr;

            if (var_7.tmp_str < hills_far_player.field_14)
            {
                var_7.tmp_str = hills_far_player.field_14;
                var_7.strength = hills_far_player.field_14;
            }

            if (var_7.tmp_str_00 < hills_far_player.field_15)
            {
                var_7.tmp_str_00 = hills_far_player.field_15;
                var_7.max_str_00 = hills_far_player.field_15;
            }

            if (var_7.tmp_int < hills_far_player.field_16)
            {
                var_7.tmp_int = hills_far_player.field_16;
                var_7._int = hills_far_player.field_16;
            }
            if (var_7.tmp_wis < hills_far_player.field_17)
            {
                var_7.tmp_wis = hills_far_player.field_17;
                var_7.wis = hills_far_player.field_17;
            }
            if (var_7.tmp_dex < hills_far_player.field_18)
            {
                var_7.tmp_dex = hills_far_player.field_18;
                var_7.dex = hills_far_player.field_18;
            }
            if (var_7.tmp_con < hills_far_player.field_19)
            {
                var_7.tmp_con = hills_far_player.field_19;
                var_7.con = hills_far_player.field_19;
            }
            if (var_7.tmp_cha < hills_far_player.field_1A)
            {
                var_7.tmp_cha = hills_far_player.field_1A;
                var_7.charisma = hills_far_player.field_1A;
            }

            if (var_7.exp < hills_far_player.field_2E)
            {
                var_7.exp = hills_far_player.field_2E;
            }

            if (ovr020.getPlayerGold(bp_player_ptr) < hills_far_player.field_28)
            {
                for (int slot = 0; slot < 5; slot++)
                {
                    ovr022.drop_coins(slot, bp_player_ptr.Money[slot], bp_player_ptr);
                }
                ovr022.addPlayerGold((short)(hills_far_player.field_28 / 5));
            }

            if (bp_player_ptr.age < hills_far_player.field_1E)
            {
                bp_player_ptr.age = hills_far_player.field_1E;
            }

            var_7.cleric_lvl = (hills_far_player.field_B7 > 0) ? (byte)1 : (byte)0;
            var_7.magic_user_lvl = (hills_far_player.field_B8 > 0) ? (byte)1 : (byte)0;
            var_7.fighter_lvl = (hills_far_player.field_B9 > 0) ? (byte)1 : (byte)0;
            var_7.thief_lvl = (hills_far_player.field_BA > 0) ? (byte)1 : (byte)0;

            var_7.field_E5 = 1;

            if (hills_far_player.field_26 != 0)
            {
                var_7.field_192 = 1;
            }

            gbl.area2_ptr.field_550 = 0xff;
            gbl.byte_1D8B0 = 0;
            gbl.byte_1B2F1 = 1;

            do
            {
                ovr018.train_player();
            } while (gbl.byte_1D8B0 == 0);

            gbl.byte_1B2F1 = 0;
            gbl.player_ptr = bp_var_1CA;

            var_7.hit_point_max = hills_far_player.field_21;
            var_7.field_12C = (byte)(var_7.hit_point_max - ovr018.get_con_hp_adj(bp_player_ptr));
            var_7.hit_point_current = hills_far_player.field_20;
        }


        static Set asc_49280 = new Set(0x020E, new byte[] { 
            0x04, 0x04, 0x00, 0x80, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x02, 0x08, 0x00, 0x10	});

        static ClassId[] unk_1682A = {
            ClassId.unknown,    ClassId.thief,      ClassId.fighter,    ClassId.mc_f_t, ClassId.magic_user,
            ClassId.mc_mu_t,    ClassId.mc_f_mu,    ClassId.mc_f_mu_t,  ClassId.cleric, ClassId.mc_c_t,
            ClassId.mc_c_f,     ClassId.unknown,    ClassId.mc_c_mu,    ClassId.unknown, ClassId.mc_c_f_m, 
            ClassId.unknown};

        internal static void import_char01(byte arg_0, byte arg_2, ref Player player_ptr, string arg_8)
        {
            Player player01_ptr;
            string var_2DF;
            string var_2DA;
            string var_2CA;
            Player player02_ptr;
            HillsFarPlayer var_1C4;
            PoolRadPlayer var_1C0;
            bool var_1BC;
            string var_1BB = string.Empty;
            byte[] var_192;
            Affect affect_ptr = null;
            Item item_ptr;
            short var_182;
            File file;
            string var_100;

            var_100 = arg_8;

            var_1BC = seg042.find_and_open_file(out file, false, gbl.SavePath + var_100);

            seg041.displayString("Loading...Please Wait", 0, 10, 0x18, 0);


            if (gbl.import_from == ImportSource.Curse)
            {
                var_192 = new byte[Player.StructSize];

                seg051.BlockRead(0x1a6, var_192, file);
                player_ptr = new Player(var_192, 0);

                var_192 = null;
                seg051.Close(file);
            }
            else if (gbl.import_from == ImportSource.Pool)
            {
                byte[] data = new byte[0x11D];

                seg051.BlockRead(0x11D, data, file);
                seg051.Close(file);

                var_1C0 = new PoolRadPlayer(data);

                load_pool_rad_player(player_ptr, var_1C0);

                var_1C0 = null;
            }
            else if (gbl.import_from == ImportSource.Hillsfar)
            {
                byte[] data = new byte[0xBC];

                seg051.BlockRead(out var_182, 0xBC, data, file);
                seg051.Close(file);

                var_1C4 = new HillsFarPlayer(data);

                player_ptr.itemsPtr = null;
                player_ptr.affect_ptr = null;
                player_ptr.actions = null;
                player_ptr.next_player = null;

                var_2DA = var_1C4.field_4;

                var_2DF = ".guy";
                var_1BC = sub_483AE(ref var_182, ref var_1BC, var_1BB, var_2DF, var_2DA);

                if (var_1BC == true)
                {
                    var_2CA = var_100;
                    seg051.Delete(4, seg051.Pos(var_100, "."), ref var_2CA);

                    var_1BC = seg042.find_and_open_file(out file, false, gbl.SavePath + var_2CA + var_2DF);

                    data = new byte[Player.StructSize];

                    seg051.BlockRead(out var_182, Player.StructSize, data, file);
                    seg051.Close(file);

                    player_ptr = new Player(data, 0);

                    player_ptr.itemsPtr = null;
                    player_ptr.affect_ptr = null;
                    player_ptr.actions = null;
                    player_ptr.next_player = null;

                    player02_ptr = gbl.player_ptr;
                    gbl.player_ptr = player_ptr;

                    sub_48F35(var_1C4, player_ptr, player02_ptr);

                    if (var_1C4.field_1D > 0)
                    {
                        item_ptr = ovr025.new_Item(0, Affects.helpless, (Affects)var_1C4.field_1D, (short)(var_1C4.field_1D * 200),
                            0, 0, false, 0, false, 0, 0, 0x57, -89, -88, 0x46);
                        ovr025.addItem(item_ptr, player_ptr);
                    }

                    if (var_1C4.field_23 > 0)
                    {
                        item_ptr = ovr025.new_Item(0, Affects.affect_41, (Affects)var_1C4.field_23, (short)(var_1C4.field_23 * 0x15E),
                            0, 1, false, 0, false, 0, 1, 0x45, -89, -50, 0x4F);

                        ovr025.addItem(item_ptr, player_ptr);
                    }

                    if (var_1C4.field_86 > 0)
                    {
                        item_ptr = ovr025.new_Item(0, Affects.helpless, (Affects)var_1C4.field_86, (short)(var_1C4.field_86 * 0xc8),
                            0, 0, false, 0, false, 0, 0, 0x42, -89, -88, 0x45);

                        ovr025.addItem(item_ptr, player_ptr);
                    }

                    if (var_1C4.field_87 > 0)
                    {
                        item_ptr = ovr025.new_Item(0, Affects.affect_3e, (Affects)var_1C4.field_87, (short)(var_1C4.field_87 * 0x190),
                            0, (short)(var_1C4.field_87 * 10), false, 0, false, 0, 0, 0x40, -89, -71, 0x46);

                        ovr025.addItem(item_ptr, player_ptr);
                    }
                }
                else
                {
                    var_2DA = var_1C4.field_4;

                    var_2DF = ".cha";

                    var_1BC = sub_483AE(ref var_182, ref var_1BC, var_1BB, var_2DF, var_2DA);

                    if (var_1BC == true)
                    {
                        data = seg051.GetMem(0x11D);

                        var_2CA = var_100;
                        var_2CA = var_100;
                        seg051.Delete(4, seg051.Pos(var_100, "."), ref var_2CA);

                        var_1BC = seg042.find_and_open_file(out file, false, gbl.SavePath + var_2CA + var_2DF);

                        seg051.BlockRead(out var_182, 0x011D, data, file);
                        seg051.Close(file);

                        var_1C0 = new PoolRadPlayer(data);

                        load_pool_rad_player(player_ptr, var_1C0);

                        var_1C0 = null;

                        player02_ptr = gbl.player_ptr;
                        gbl.player_ptr = player_ptr;

                        sub_48F35(var_1C4, player_ptr, player02_ptr);
                    }
                    else
                    {
                        player02_ptr = gbl.player_ptr;
                        gbl.player_ptr = player_ptr;

                        player01_ptr = player_ptr;

                        for (int i = 0; i < 6; i++)
                        {
                            player01_ptr.icon_colours[i] = (byte)(((gbl.default_icon_colours[i] + 8) << 4) + gbl.default_icon_colours[i]);
                        }

                        player01_ptr.field_124 = 0x32;
                        player01_ptr.field_73 = 0x28;
                        player01_ptr.health_status = Status.okey;
                        player01_ptr.in_combat = true;
                        player01_ptr.field_13F = 1;
                        player01_ptr.field_140 = 1;
                        player01_ptr.field_DE = 1;

                        player01_ptr.mod_id = seg051.Random((byte)0xff);
                        player01_ptr.icon_id = 0x0A;

                        player01_ptr.field_11C = 2;
                        player01_ptr.field_11E = 1;
                        player01_ptr.field_120 = 2;
                        player01_ptr.field_125 = 1;
                        player01_ptr.field_E4 = 0x0C;

                        player01_ptr.name = var_1C4.field_4;
                        player01_ptr.tmp_str = var_1C4.field_14;
                        player01_ptr.strength = var_1C4.field_14;
                        player01_ptr.tmp_str_00 = var_1C4.field_15;
                        player01_ptr.max_str_00 = var_1C4.field_15;

                        player01_ptr.stats[1].tmp = var_1C4.field_16;
                        player01_ptr.stats[1].max = var_1C4.field_16;

                        player01_ptr.stats[2].tmp = var_1C4.field_17;
                        player01_ptr.stats[2].max = var_1C4.field_17;
                        player01_ptr.stats[3].tmp = var_1C4.field_18;
                        player01_ptr.stats[3].max = var_1C4.field_18;
                        player01_ptr.stats[4].tmp = var_1C4.field_19;
                        player01_ptr.stats[4].max = var_1C4.field_19;
                        player01_ptr.stats[5].tmp = var_1C4.field_1A;
                        player01_ptr.stats[5].max = var_1C4.field_1A;

                        player01_ptr.race = (Race)(var_1C4.field_2D + 1);

                        if (player01_ptr.race == Race.half_orc)
                        {
                            player01_ptr.race = Race.human;
                        }


                        switch (player01_ptr.race)
                        {
                            case Race.halfling:
                                player01_ptr.icon_size = 1;
                                ovr024.add_affect(false, 0xff, 0, Affects.affect_61, player_ptr);
                                break;

                            case Race.dwarf:
                                player01_ptr.icon_size = 1;

                                ovr024.add_affect(false, 0xff, 0, Affects.affect_61, player_ptr);
                                ovr024.add_affect(false, 0xff, 0, Affects.affect_1a, player_ptr);
                                ovr024.add_affect(false, 0xff, 0, Affects.affect_2f, player_ptr);
                                break;

                            case Race.gnome:
                                player01_ptr.icon_size = 1;

                                ovr024.add_affect(false, 0xff, 0, Affects.affect_61, player_ptr);
                                ovr024.add_affect(false, 0xff, 0, Affects.affect_12, player_ptr);
                                ovr024.add_affect(false, 0xff, 0, Affects.affect_2f, player_ptr);
                                ovr024.add_affect(false, 0xff, 0, Affects.affect_30, player_ptr);
                                break;

                            case Race.elf:
                                player01_ptr.icon_size = 2;
                                ovr024.add_affect(false, 0xff, 0, Affects.affect_6b, player_ptr);
                                break;

                            case Race.half_elf:
                                player01_ptr.icon_size = 2;
                                ovr024.add_affect(false, 0xff, 0, Affects.affect_7c, player_ptr);
                                break;

                            default:
                                player01_ptr.icon_size = 2;
                                break;
                        }

                        player01_ptr._class = unk_1682A[var_1C4.field_35 & 0x0F];
                        player01_ptr.age = var_1C4.field_1E;

                        player01_ptr.cleric_lvl = (var_1C4.field_B7 > 0) ? (byte)1 : (byte)0;
                        player01_ptr.magic_user_lvl = (var_1C4.field_B8 > 0) ? (byte)1 : (byte)0;
                        player01_ptr.fighter_lvl = (var_1C4.field_B9 > 0) ? (byte)1 : (byte)0;
                        player01_ptr.thief_lvl = (var_1C4.field_BA > 0) ? (byte)1 : (byte)0;
                        player01_ptr.field_E5 = 1;
                        player01_ptr.sex = var_1C4.field_2C;
                        player01_ptr.alignment = var_1C4.field_1C;
                        player01_ptr.exp = var_1C4.field_2E;

                        if (player01_ptr.magic_user_lvl > 0)
                        {
                            player01_ptr.field_79[0xB - 1] = 1;
                            player01_ptr.field_79[0x12 - 1] = 1;
                            player01_ptr.field_79[0x13 - 1] = 1;
                            player01_ptr.field_79[0x15 - 1] = 1;
                        }

                        gbl.area2_ptr.field_550 = 0xff;

                        gbl.byte_1D8B0 = 0;
                        gbl.byte_1B2F1 = 1;

                        do
                        {
                            ovr018.train_player();
                        } while (gbl.byte_1D8B0 == 0);

                        gbl.byte_1B2F1 = 0;

                        ovr022.addPlayerGold(300);
                        gbl.player_ptr = player02_ptr;
                        player01_ptr.hit_point_max = var_1C4.field_21;
                        player01_ptr.field_12C = (byte)(player01_ptr.hit_point_max - ovr018.get_con_hp_adj(player_ptr));
                        player01_ptr.hit_point_current = var_1C4.field_20;
                    }
                }

                seg051.FreeMem(0x00bc, var_1C4);
            }

            if (gbl.import_from == ImportSource.Curse)
            {
                seg051.Delete(4, seg051.Pos(var_100, "."), ref var_100);
            }
            else
            {
                var_100 = seg042.clean_string(player_ptr.name);
            }

            if (seg042.file_find(gbl.SavePath + var_100 + ".swg") == true)
            {
                byte[] var_18A = new byte[Item.StructSize];

                var_1BC = seg042.find_and_open_file(out file, false, gbl.SavePath + var_100 + ".swg");

                Item last_item = null;
                do
                {
                    seg051.BlockRead(out var_182, Item.StructSize, var_18A, file);

                    if (var_182 == Item.StructSize)
                    {
                        Item new_item = new Item(var_18A, 0);

                        if (player_ptr.itemsPtr == null)
                        {
                            player_ptr.itemsPtr = new_item;
                            last_item = player_ptr.itemsPtr;
                        }
                        else
                        {
                            last_item.next = new_item;
                            last_item = last_item.next;
                        }
                    }
                } while (var_182 == Item.StructSize);

                seg051.Close(file);
                seg051.FreeMem(Item.StructSize, var_18A);
            }


            if (seg042.file_find(gbl.SavePath + var_100 + ".fx") == true)
            {
                var_192 = seg051.GetMem(9);
                var_1BC = seg042.find_and_open_file(out file, false, gbl.SavePath + var_100 + ".fx");

                do
                {
                    seg051.BlockRead(out var_182, Affect.StructSize, var_192, file);

                    if (var_182 == Affect.StructSize)
                    {
                        Affect tmp_affect = new Affect(var_192, 0);

                        if (player_ptr.affect_ptr == null)
                        {
                            player_ptr.affect_ptr = tmp_affect;
                            affect_ptr = player_ptr.affect_ptr;
                        }
                        else
                        {
                            affect_ptr.next = tmp_affect;
                            affect_ptr = affect_ptr.next;
                        }
                    }
                } while (var_182 == Affect.StructSize);

                seg051.Close(file);
                seg051.FreeMem(Affect.StructSize, var_192);
            }

            if (gbl.import_from == ImportSource.Pool)
            {
                if (seg042.file_find(gbl.SavePath + var_100 + ".spc") == true)
                {
                    var_192 = seg051.GetMem(9);

                    var_1BC = seg042.find_and_open_file(out file, false, gbl.SavePath + var_100 + ".spc");

                    do
                    {
                        seg051.BlockRead(out var_182, 9, var_192, file);

                        if (var_182 == 9 &&
                            asc_49280.MemberOf(var_192[0]) == true)
                        {
                            Affect tmpAffect = new Affect(var_192, 0);

                            if (player_ptr.affect_ptr == null)
                            {
                                player_ptr.affect_ptr = tmpAffect;
                                affect_ptr = player_ptr.affect_ptr;
                            }
                            else
                            {
                                affect_ptr.next = tmpAffect;
                                affect_ptr = affect_ptr.next;
                            }
                        }
                    } while (var_182 == 9);

                    seg051.Close(file);

                    var_192 = null;
                }
            }
            seg043.clear_keyboard();
            ovr025.reclac_player_values(player_ptr);
            ovr026.sub_6A3C6(player_ptr);
        }


        internal static Player load_mob(int monster_id)
        {
            byte[] data;
            short decode_size;

            string area_text = gbl.game_area.ToString();
            seg042.load_decode_dax(out data, out decode_size, monster_id, "MON" + area_text + "CHA.dax");

            if (decode_size == 0)
            {
                seg041.displayAndDebug("Unable to load monster", 0, 15);
                seg043.print_and_exit();
            }

            Player player = new Player(data, 0);

            seg051.FreeMem(data);

            seg042.load_decode_dax(out data, out decode_size, monster_id, "MON" + area_text + "SPC.dax");

            if (decode_size != 0)
            {
                int offset = 0;
                Affect lastAffect = null;

                do
                {
                    Affect affect = new Affect(data, offset);

                    if (offset == 0)
                    {
                        player.affect_ptr = affect;
                        lastAffect = affect;
                    }
                    else
                    {
                        lastAffect.next = affect;
                        lastAffect = affect;
                    }

                    offset += 9;
                } while (offset < decode_size);

                seg051.FreeMem(decode_size, data);
            }

            seg042.load_decode_dax(out data, out decode_size, monster_id, "MON" + area_text + "ITM.dax");

            if (decode_size != 0)
            {
                int offset = 0;
                Item lastItem = null;

                do
                {
                    Item item = new Item(data, offset);

                    if (offset == 0)
                    {
                        player.itemsPtr = item;
                    }
                    else
                    {
                        lastItem.next = item;
                    }
                    lastItem = item;

                    offset += Item.StructSize;

                } while (offset < decode_size);
            }

            seg043.clear_keyboard();

            return player;
        }


        internal static void load_npc(int monster_id) // sub_4A57D
        {
            if (gbl.area2_ptr.party_size <= 7)
            {
                Player player = load_mob(monster_id);

                player.mod_id = (byte)monster_id;

                sub_4A60A(player);

                ovr034.chead_cbody_comspr_icon(player.icon_id, monster_id, "CPIC");
            }
        }

        static Set unk_4A5EA = new Set(0x0001, new byte[] { 0xFF });

        internal static void sub_4A60A(Player new_player)
        {
            new_player.icon_id = 0xff;

            gbl.player_next_ptr.Add(new_player);
            gbl.player_ptr = new_player;

            bool[] icon_slot = new bool[8];

            foreach (Player tmp in gbl.player_next_ptr)
            {
                if (unk_4A5EA.MemberOf(tmp.icon_id) == true)
                {
                    icon_slot[tmp.icon_id] = true;
                }
            }

            Player var_10 = gbl.player_ptr;
            var_10.icon_id = 0;

            while (var_10.icon_id < 8 &&
                icon_slot[var_10.icon_id] == true)
            {
                var_10.icon_id += 1;
            }

            gbl.area2_ptr.party_size++;

            if (new_player.field_F7 > 0x7f)
            {
                ovr026.sub_6A3C6(new_player);
            }
        }

        static Set save_game_keys = new Set(0x0802, new byte[] { 0xFE, 0x07 }); // asc_4A761

        internal static void loadGameMenu() // loadGame
        {
            gbl.import_from = 0;

            if (save() == true)
            {
                string games_list = string.Empty;

                for (char save_letter = 'A'; save_letter <= 'J'; save_letter++)
                {
                    string file_name = gbl.SavePath + "savgam" + save_letter.ToString() + ".dat";

                    if (seg042.file_find(file_name) == true)
                    {
                        games_list += save_letter.ToString() + " ";
                    }
                }

                if (games_list.Length != 0)
                {
                    games_list = games_list.TrimEnd();

                    bool stop_loop = false;
                    char save_letter = '\0';
                    do
                    {
                        bool speical_key;
                        char input_key = ovr027.displayInput(out speical_key, false, 0, 15, 10, 13, games_list, "Load Which Game: ");

                        stop_loop = input_key == 0x00; // Escape
                        save_letter = '\0';

                        if (save_game_keys.MemberOf(input_key) == true)
                        {
                            save_letter = input_key;
                            string file_name = gbl.SavePath + "savgam" + save_letter.ToString() + ".dat";
                            stop_loop = seg042.file_find(file_name);
                        }
                    } while (stop_loop == false);

                    if (save_letter != '\0')
                    {
                        string file_name = gbl.SavePath + "savgam" + save_letter.ToString() + ".dat";

                        loadSaveGame(file_name);
                    }
                }
            }
        }

        internal static void loadSaveGame(string file_name)
        {
            File file;
            seg042.find_and_open_file(out file, true, file_name);

            ovr027.redraw_screen();
            seg041.displayString("Loading...Please Wait", 0, 10, 0x18, 0);
            gbl.byte_1B2EB = 1;

            byte[] data = new byte[0x2000];

            seg051.BlockRead(1, data, file);
            gbl.game_area = data[0];

            seg051.BlockRead(0x800, data, file);
            gbl.area_ptr = new Area1(data, 0);

            seg051.BlockRead(0x800, data, file);
            gbl.area2_ptr = new Area2(data, 0);

            seg051.BlockRead(0x400, data, file);
            gbl.stru_1B2CA = new Struct_1B2CA(data, 0);

            seg051.BlockRead(0x1E00, data, file);
            gbl.ecl_ptr = new EclBlock(data, 0);

            seg051.BlockRead(5, data, file);
            gbl.mapPosX = (sbyte)data[0];
            gbl.mapPosY = (sbyte)data[1];
            gbl.mapDirection = data[2];
            gbl.mapWallType = data[3];
            gbl.mapWallRoof = data[4];

            seg051.BlockRead(1, data, file);
            gbl.last_game_state = data[0];

            seg051.BlockRead(1, data, file);
            gbl.game_state = data[0];

            seg051.BlockRead(2, data, file);
            gbl.word_1D53E = Sys.ArrayToShort(data, 0);

            seg051.BlockRead(2, data, file);
            gbl.word_1D540 = Sys.ArrayToShort(data, 0);

            seg051.BlockRead(2, data, file);
            gbl.word_1D542 = Sys.ArrayToShort(data, 0);

            seg051.BlockRead(2, data, file);
            gbl.word_1D544 = Sys.ArrayToShort(data, 0);

            seg051.BlockRead(2, data, file);
            gbl.word_1D546 = Sys.ArrayToShort(data, 0);

            seg051.BlockRead(2, data, file);
            gbl.word_1D548 = Sys.ArrayToShort(data, 0);

            seg051.BlockRead(1, data, file);
            int number_of_players = data[0];

            seg051.BlockRead(0x148, data, file);
            string[] var_148 = Sys.ArrayToStrings(data, 0, System.Math.Min(0x148, 0x29 * number_of_players), 0x29);

            seg051.Close(file);

            gbl.PicsOn = ((gbl.area_ptr.pics_on >> 1) != 0);
            gbl.AnimationsOn = ((gbl.area_ptr.pics_on & 1) != 0);
            gbl.game_speed_var = gbl.area_ptr.game_speed;
            gbl.area2_ptr.party_size = 0;

            for (int index = 0; index < number_of_players; index++)
            {
                string var_1F6 = seg042.clean_string(var_148[index]);

                if (seg042.file_find(gbl.SavePath + var_1F6 + ".sav") == true)
                {
                    Player player = new Player();

                    import_char01(1, 1, ref player, var_1F6 + ".sav");
                    sub_4A60A(player);

                    if (save() == false)
                    {
                        return;
                    }
                }
            }

            foreach (Player tmp_player in gbl.player_next_ptr)
            {
                remove_player_file(tmp_player);
            }

            foreach (Player tmp_player in gbl.player_next_ptr)
            {
                gbl.player_ptr = tmp_player;

                if (gbl.player_ptr.field_F7 < 0x80)
                {
                    LoadPlayerCombatIcon(true);
                }
                else
                {
                    ovr034.chead_cbody_comspr_icon(gbl.player_ptr.icon_id, gbl.player_ptr.mod_id, "CPIC");
                }
            }
        

            gbl.player_ptr = gbl.player_next_ptr[0];

            gbl.game_area = gbl.area2_ptr.game_area;

            if (gbl.area_ptr.field_1CC != 0)
            {
                if (gbl.game_state != 0)
                {
                    if (gbl.word_1D53E > 0)
                    {
                        ovr031.Load3DMap(gbl.area_ptr.current_3DMap_block_id);
                    }

                    if (gbl.word_1D53E > 0)
                    {
                        ovr031.LoadWalldef((byte)gbl.word_1D540, (byte)gbl.word_1D53E);
                    }
                    if (gbl.word_1D542 > 0)
                    {
                        ovr031.LoadWalldef((byte)gbl.word_1D544, (byte)gbl.word_1D542);
                    }
                    if (gbl.word_1D546 > 0)
                    {
                        ovr031.LoadWalldef((byte)gbl.word_1D548, (byte)gbl.word_1D546);
                    }
                }
            }
            else
            {
                ovr030.load_bigpic(0x79);
            }

            seg043.clear_keyboard();
            ovr027.redraw_screen();

            gbl.last_game_state = gbl.game_state;

            gbl.game_state = 0;
        }
 
        
        static int save_space_required()
        {
            int size = 0;
            foreach (Player var_6 in gbl.player_next_ptr)
            {
                size += 0x1A6;

                Item item = var_6.itemsPtr;
                while (item != null)
                {
                    size += Item.StructSize;

                    item = item.next;
                }

                Affect affect = var_6.affect_ptr;
                while (affect != null)
                {
                    size += Affect.StructSize;

                    affect = affect.next;
                }
            }

            return size;
        }


        static Set unk_4AEA0 = new Set (0x000a , new byte[ ] { 0x01, 0x00, 0x00, 0x00 , 0x00 , 0x00 , 0x00 , 0x00, 0xFE, 0x07 });
        static Set unk_4AEEF = new Set(0x0003, new byte[] { 0x05, 0x00, 0x04 });

        internal static void SaveGame()
        {
            short var_1FC;
            char var_1FA;
            bool var_1F9;
            string var_1CF;
            Player player_ptr;
            File save_file = new File();
            string[] var_171 = new string[9];

            do
            {
                var_1FA = ovr027.displayInput(out var_1F9, (gbl.game_state == 2), 0, 15, 10, 13, "A B C D E F G H I J", "Save Which Game: ");

            } while (unk_4AEA0.MemberOf(var_1FA) == false);

            if (var_1FA != '\0')
            {
                gbl.import_from = ImportSource.Curse;

                if (save() == true)
                {
                    int space_required;
                    if (seg042.file_find(gbl.SavePath + "savgam" + var_1FA + ".dat") == true)
                    {
                        space_required = 0;
                    }
                    else
                    {
                        space_required = 0x3208;
                    }

                    space_required += save_space_required();

                    if (space_required > seg046.getDiskSpace((byte)(char.ToUpper(gbl.SavePath[0]) - 0x40)))
                    {
                        seg041.displayAndDebug("Can't save.  No room on this disk.", 0, 14);
                        return;
                    }

                    do
                    {
                        save_file.Assign(gbl.SavePath + "savgam" + var_1FA + ".dat");
                        seg051.Rewrite(save_file);
                        var_1FC = gbl.FIND_result;

                        if (unk_4AEEF.MemberOf(var_1FC) == false)
                        {
                            seg041.displayAndDebug("Unexpected error during save: " + var_1FC.ToString(), 0, 14);
                            seg051.Close(save_file);
                            return;
                        }
                    } while (unk_4AEEF.MemberOf(var_1FC) == false);

                    ovr027.redraw_screen();
                    seg041.displayString("Saving...Please Wait", 0, 10, 0x18, 0);

                    gbl.area_ptr.game_speed = (byte)gbl.game_speed_var;
                    gbl.area_ptr.pics_on = (byte)(((gbl.PicsOn) ? 0x02 : 0) | ((gbl.AnimationsOn) ? 0x01 : 0));
                    gbl.area2_ptr.game_area = gbl.game_area;

                    byte[] data = new byte[0x1E00];

                    data[0] = gbl.game_area;
                    seg051.BlockWrite(1, data, save_file);

                    seg051.BlockWrite(0x800, gbl.area_ptr.ToByteArray(), save_file);
                    seg051.BlockWrite(0x800, gbl.area2_ptr.ToByteArray(), save_file);
                    seg051.BlockWrite(0x400, gbl.stru_1B2CA.ToByteArray(), save_file);
                    seg051.BlockWrite(0x1E00, gbl.ecl_ptr.ToByteArray(), save_file);

                    data[0] = (byte)gbl.mapPosX;
                    data[1] = (byte)gbl.mapPosY;
                    data[2] = gbl.mapDirection;
                    data[3] = gbl.mapWallType;
                    data[4] = gbl.mapWallRoof;
                    seg051.BlockWrite(5, data, save_file);

                    data[0] = gbl.last_game_state;
                    seg051.BlockWrite(1, data, save_file);
                    data[0] = gbl.game_state;
                    seg051.BlockWrite(1, data, save_file);

                    Sys.ShortToArray(gbl.word_1D53E, data, 0);
                    Sys.ShortToArray(gbl.word_1D540, data, 2);

                    Sys.ShortToArray(gbl.word_1D542, data, 4);
                    Sys.ShortToArray(gbl.word_1D544, data, 6);

                    Sys.ShortToArray(gbl.word_1D546, data, 8);
                    Sys.ShortToArray(gbl.word_1D548, data, 10);

                    seg051.BlockWrite(12, data, save_file);

                    int party_count = 0;
                    foreach (Player tmp_player in gbl.player_next_ptr)
                    {
                        party_count++;
                        var_171[party_count - 1] = "CHRDAT" + var_1FA + party_count.ToString();
                    }

                    data[0] = (byte)party_count;
                    seg051.BlockWrite(1, data, save_file);

                    for (int i = 0; i < party_count; i++)
                    {
                        Sys.StringToArray(data, 0x29*i, 0x29, var_171[i]);
                    }
                    seg051.BlockWrite(0x148, data, save_file);
                    seg051.Close(save_file);
                    
                    party_count = 0;
                    foreach (Player tmp_player in gbl.player_next_ptr)
                    {
                        party_count++;
                        sub_47DFC("CHRDAT" + var_1FA + party_count.ToString(), tmp_player);
                        remove_player_file(tmp_player);
                    }

                    gbl.byte_1C01B = 1;
                    ovr027.redraw_screen();
                }
            }
        }
    }
}
