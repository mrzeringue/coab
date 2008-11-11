using Classes;
using System.Collections.Generic;

namespace engine
{
    class ovr026
    {
        static byte[,] /*seg600:42BC*/ unk_1A5CC = { 
            {1, 0, 0, 0, 0},
            {0, 1, 0, 0, 0},
            {1, 1, 0, 0, 0},
            {0, 1, 1, 0, 0},
            {0, 0, 1, 0, 0}, 
            {0, 0, 0, 1, 0},    
            {0, 0, 1, 1, 0}, 
            {1, 1, 0, 0, 1},  //seg600:42EE
            {0, 0, 0, 1, 1},  //seg600:42F3
            {1, 0, 1, 0, 0},  //seg600:42F8
            {1, 1, 1, 0, 0},  //seg600:42FD
        };

        static byte[,] /*seg600:43E5*/ unk_1A6F5 = { 
            {0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0}, 
            {0, 0, 0, 0, 0},  
            {0, 0, 0, 0, 0}, 
            {1, 0, 0, 0, 0}, 
            {1, 0, 0, 0, 0}, 
            {0, 1, 0, 0, 0}, 
            {0, 1, 0, 0, 0}
        };

        static byte[,] /*seg600:4448*/ unk_1A758 = { 
            {0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0},
            {1, 0, 0, 0, 0},
            {0, 0, 0, 1, 0},
            {1, 0, 0, 0, 0},
            {0, 0, 0, 1, 0},
            {0, 1, 0, 0, 0} 
        };



        internal static void sub_6A00F(Player player)
        {
            sbyte var_2;

            for (int i = 0; i < 5; i++)
            {
                player.field_12D[0, i] = 0;
                player.field_12D[1, i] = 0;
                player.field_12D[2, i] = 0;
            }

            for (int skill = 0; skill <= 7; skill++)
            {
                if (sub_6B3D1(player) != 0 &&
                    player.Skill_B_lvl[skill] != 0)
                {
                    var_2 = (sbyte)player.Skill_B_lvl[skill];
                }
                else
                {
                    var_2 = (sbyte)player.class_lvls[skill];
                }

                if (var_2 > 0)
                {
                    switch (skill)
                    {
                        case 0:
                            player.field_12D[0, 0] += 1;

                            for (int sp_class = 0; sp_class <= (var_2 - 2); sp_class++)
                            {
                                for (int sp_lvl = 0; sp_lvl < 5; sp_lvl++)
                                {
                                    player.field_12D[0, sp_lvl] += unk_1A5CC[sp_class, sp_lvl];
                                }
                            }

                            calc_cleric_spells(false, player);

                            for (int i = 1; i <= 100; i++)
                            {
                                SpellEntry var_12 = gbl.spell_table[i];

                                int sp_class = (var_12.spellLevel - 1) / 5;
                                int sp_lvl = (var_12.spellLevel - 1) % 5;

                                if (var_12.spellClass == 0 &&
                                    player.field_12D[sp_class, sp_lvl] > 0 &&
                                    i != 0x24)
                                {
                                    player.field_79[i - 1] = 1;
                                }
                            }
                            break;

                        case 3:
                            if (var_2 > 8)
                            {
                                for (int var_3 = 8; var_3 < var_2; var_3++)
                                {
                                    for (int sp_lvl = 0; sp_lvl < 5; sp_lvl++)
                                    {
                                        player.field_12D[0, sp_lvl] += unk_1A6F5[var_3, sp_lvl];
                                    }
                                }

                                for (int i = 1; i <= 100; i++)
                                {
                                    SpellEntry var_12 = gbl.spell_table[i];

                                    int sp_class = (var_12.spellLevel - 1) / 5;
                                    int sp_lvl = (var_12.spellLevel - 1) % 5;

                                    if (var_12.spellClass == 0 &&
                                        player.field_12D[sp_class, sp_lvl] > 0)
                                    {
                                        player.field_79[i - 1] = 1;
                                    }
                                }
                            }
                            break;

                        case 4:
                            if (var_2 > 7)
                            {
                                for (int var_3 = 8; var_3 <= var_2; var_3++)
                                {
                                    for (int sp_lvl = 0; sp_lvl < 3; sp_lvl++)
                                    {
                                        player.field_12D[1, sp_lvl] += unk_1A758[var_3, sp_lvl];
                                    }

                                    for (int sp_lvl = 3; sp_lvl < 5; sp_lvl++)
                                    {
                                        player.field_12D[2, sp_lvl - 3] += unk_1A758[var_3, sp_lvl];
                                    }
                                }

                                for (int i = 1; i <= 100; i++)
                                {
                                    if (gbl.spell_table[i].spellClass == 1)
                                    {
                                        player.field_79[i - 1] = 1;
                                    }
                                }
                            }

                            break;

                        case 5:
                            player.field_12D[2, 0] += 1;

                            for (int lvl = 0; lvl <= (var_2 - 2); lvl++)
                            {
                                /* unk_1A7C6 = seg600:44B6 */
                                player.field_12D[2, 0] += ovr020.unk_1A7C6[lvl, 0];
                                player.field_12D[2, 1] += ovr020.unk_1A7C6[lvl, 1];
                                player.field_12D[2, 2] += ovr020.unk_1A7C6[lvl, 2];
                                player.field_12D[2, 3] += ovr020.unk_1A7C6[lvl, 3];
                                player.field_12D[2, 4] += ovr020.unk_1A7C6[lvl, 4];
                            }
                            break;
                    }
                }
            }

            foreach (Item item in player.items)
            {
                if (item.affect_3 == Affects.affect_81 && item.readied)
                {
                    for (int sp_lvl = 0; sp_lvl < 3; sp_lvl++)
                    {
                        player.field_12D[2, sp_lvl] *= 2;
                    }
                }
            }
        }


        internal static void sub_6A3C6(Player player)
        {
            player.field_73 = 0;

            for (int skill = 0; skill <= 7; skill++)
            {
                byte skill_lvl = player.class_lvls[skill];

                if (ovr018.unk_1A14A[(skill * 0xD) + skill_lvl] > player.field_73)
                {
                    player.field_73 = ovr018.unk_1A14A[(skill * 0xD) + skill_lvl];
                }

                if (player.field_E5 < skill_lvl)
                {
                    player.field_E5 = skill_lvl;
                }

                if (skill == 2 || skill == 3)
                {
                    if (skill_lvl > 6)
                    {
                        player.field_11C = 3;
                    }
                }
                else if (skill == 4)
                {
                    if (skill_lvl > 7)
                    {
                        player.field_11C = 3;
                    }
                }
            }

            sub_6A00F(player);
            sub_6A7FB(player);

            if (player.thief_lvl > 0)
            {
                sub_6AAEA(player);
            }

            player.classFlags = 0;

            for (int skill = 0; skill <= 7; skill++)
            {
                if (player.class_lvls[skill] > 0 ||
                    (player.Skill_B_lvl[skill] > 0 && player.Skill_B_lvl[skill] < player.field_E5))
                {
                    player.classFlags += ovr018.unk_1A1B2[skill];
                }
            }

            for (int item_slot = 0; item_slot <= 12; item_slot++)
            {
                if (player.itemArray[item_slot] != null &&
                    (gbl.unk_1C020[player.itemArray[item_slot].type].classFlags & player.classFlags) == 0 &&
                    player.itemArray[item_slot].cursed == false)
                {
                    player.itemArray[item_slot].readied = false;
                }
            }

            if (sub_6B3D1(player) != 0)
            {
                for (int skill = 0; skill <= 7; skill++)
                {
                    byte skill_lvl = player.Skill_B_lvl[skill];

                    if (skill == 2 || skill == 3)
                    {
                        if (skill_lvl > 6)
                        {
                            player.field_11C = 3;
                        }
                    }
                    else if (skill == 4)
                    {
                        if (skill_lvl > 7)
                        {
                            player.field_11C = 3;
                        }
                    }

                    if (ovr018.unk_1A14A[(skill * 0xd) + skill_lvl] > player.field_73)
                    {
                        player.field_73 = ovr018.unk_1A14A[(skill * 0xd) + skill_lvl];
                    }
                }

                if (player.field_113 > 6 ||
                    player.field_115 > 7 ||
                    player.field_114 > 6)
                {
                    player.field_11C = 3;
                }

                if (player.field_117 > 0)
                {
                    sub_6AAEA(player);
                }
            }
        }


        internal static void calc_cleric_spells(bool arg_0, Player player) /* sub_6A686 */
        {
            int var_3 = player.cleric_lvl + player.turn_undead * sub_6B3D1(player);

            if (var_3 > 0)
            {
                if (arg_0 == true)
                {
                    for (int sp_lvl = 1; sp_lvl < 5; sp_lvl++)
                    {
                        player.field_12D[0, sp_lvl] = 0;
                    }

                    player.field_12D[0, 0] = 1;

                    for (int sp_class = 0; sp_class <= (var_3 - 2); sp_class++)
                    {
                        for (int sp_lvl = 0; sp_lvl < 5; sp_lvl++)
                        {
                            player.field_12D[0, sp_lvl] += unk_1A5CC[sp_class, sp_lvl];
                        }
                    }
                }

                if (player.wis > 12 && player.field_12D[0, 0] > 0)
                {
                    player.field_12D[0, 0] += 1;
                }

                if (player.wis > 13 && player.field_12D[0, 0] > 0)
                {
                    player.field_12D[0, 0] += 1;
                }

                if (player.wis > 14 && player.field_12D[0, 1] > 0)
                {
                    player.field_12D[0, 1] += 1;
                }

                if (player.wis > 15 && player.field_12D[0, 1] > 0)
                {
                    player.field_12D[0, 1] += 1;
                }

                if (player.wis > 16 && player.field_12D[0, 2] > 0)
                {
                    player.field_12D[0, 2] += 1;
                }

                if (player.wis > 17 && player.field_12D[0, 3] > 0)
                {
                    player.field_12D[0, 3] += 1;
                }
            }
        }

        static byte[] byte_1A8CE = { 
        
    4, 2, 6, 5, 4, 10, 13, 14, 16, 15, 10, 13, 14,
    16, 15, 10, 13, 14, 16, 15, 9, 12, 13, 15,
    14, 9, 12, 13, 15, 14, 9, 12, 13, 15, 14, 7,
    10, 11, 13, 12, 7, 10, 11, 13, 12, 7, 10, 11,
    13, 12, 6, 9, 10, 12, 11, 6, 9, 10, 12, 11,
    6, 9, 10, 12, 11, 10, 13, 14, 16, 15, 10, 13,
    14, 16, 15, 10, 13, 14, 16, 15, 9, 12, 13,
    15, 14, 9, 12, 13, 15, 14, 9, 12, 13, 15, 14,
    7, 10, 11, 13, 12, 7, 10, 11, 13, 12, 7, 10,
    11, 13, 12, 6, 9, 10, 12, 11, 6, 9, 10, 12,
    11, 6, 9, 10, 12, 11, 14, 15, 16, 17, 17, 14,
    15, 16, 17, 17, 13, 14, 15, 16, 16, 13, 14,
    15, 16, 16, 11, 12, 13, 13, 14, 11, 12, 13,
    13, 14, 10, 11, 12, 12, 13, 10, 11, 12, 12,
    13, 8, 9, 10, 9, 11, 8, 9, 10, 9, 11, 7, 8, 9,
    8, 10, 7, 8, 9, 8, 10, 12, 13, 14, 15, 15, 12,
    13, 14, 15, 15, 11, 12, 13, 14, 14, 11, 12,
    13, 14, 14, 9, 9, 11, 11, 12, 9, 9, 11, 11,
    12, 8, 9, 10, 10, 11, 9, 9, 10, 10, 11, 6, 7,
    8, 7, 9, 6, 7, 8, 7, 9, 5, 6, 7, 6, 8, 5, 6, 7, 6, 8,
    14, 15, 16, 17, 17, 14, 15, 16, 17, 17, 13,
    14, 15, 16, 16, 13, 14, 15, 16, 16, 11, 12,
    13, 13, 14, 11, 12, 13, 13, 14, 10, 11, 12,
    12, 13, 10, 11, 12, 12, 13, 8, 9, 10, 9, 11,
    8, 9, 10, 9, 11, 7, 8, 9, 8, 10, 7, 8, 9, 8, 10,
    14, 13, 11, 15, 12, 14, 13, 11, 15, 12, 14,
    13, 11, 15, 12, 14, 13, 11, 15, 12, 14, 13,
    11, 15, 12, 13, 11, 9, 13, 10, 13, 11, 9, 13,
    10, 13, 11, 9, 13, 10, 13, 11, 9, 13, 10, 13,
    11, 9, 13, 10, 11, 9, 7, 11, 8, 11, 9, 7, 11,
    8, 13, 12, 14, 16, 15, 13, 12, 14, 16, 15,
    13, 12, 14, 16, 15, 13, 12, 14, 16, 15, 12,
    11, 12, 15, 13, 12, 11, 12, 15, 13, 12, 11,
    12, 15, 13, 12, 11, 12, 15, 13, 11, 10, 10,
    14, 11, 11, 10, 10, 14, 11, 11, 10, 10, 14,
    11, 11, 10, 10, 14, 11, 13, 12, 14, 16, 15,
    13, 12, 14, 16, 15, 13, 12, 14, 16, 15, 13,
    12, 14, 16, 15, 12, 11, 12, 15, 13, 12, 11,
    12, 15, 13, 12, 11, 12, 15, 13, 12, 11, 12,
    15, 13, 11, 10, 10, 14, 11, 13, 11, 9, 13,
    10, 11, 9, 7, 11, 8 };

        internal static void sub_6A7FB(Player player)
        {
            Item item = player.items.Find(i => (int)i.affect_3 > 0x80 && i.readied && ((int)i.affect_3 & 0x7F) == 6);
            bool var_9 = item != null && ((int)item.affect_3 & 0x7F) == 6;

            for (int var_1 = 0; var_1 <= 4; var_1++)
            {
                int var_2;

                player.field_DFArraySet(var_1, 0x14);
                for (var_2 = 0; var_2 <= 7; var_2++)
                {
                    if (player.class_lvls[var_2] > 0)
                    {
                        byte dl = byte_1A8CE[(var_2 * 60) + (player.class_lvls[var_2] * 5) + var_1];

                        if (player.field_DFArrayGet(var_1) > dl)
                        {
                            player.field_DFArraySet(var_1, dl);
                        }
                    }
                }

                var_2 -= 1; /* Orignal code had a post use test and would exit on 7,
                            * but this for loops uses are pre-test increment so fix var_2 */

                if (player.class_lvls[var_2] > player.Skill_B_lvl[var_2])
                {
                    byte dl = byte_1A8CE[(var_2 * 60) + (player.Skill_B_lvl[var_2] * 5) + var_1];

                    if (player.field_DFArrayGet(var_1) > dl)
                    {
                        player.field_DFArraySet(var_1, dl);
                    }
                }

                if (var_1 == 0)
                {
                    if (player.race == Race.dwarf || player.race == Race.halfling ||
                        var_9 == true)
                    {
                        if (player.con >= 4 && player.con <= 6)
                        {
                            player.field_DFArraySet(var_1, (byte)(player.field_DFArrayGet(var_1) + 1));
                        }
                        else if (player.con >= 7 && player.con <= 10)
                        {
                            player.field_DFArraySet(var_1, (byte)(player.field_DFArrayGet(var_1) + 2));
                        }
                        else if (player.con >= 11 && player.con <= 13)
                        {

                            player.field_DFArraySet(var_1, (byte)(player.field_DFArrayGet(var_1) + 3));
                        }
                        else if (player.con >= 14 && player.con <= 17)
                        {
                            player.field_DFArraySet(var_1, (byte)(player.field_DFArrayGet(var_1) + 4));
                        }
                        else if (player.con == 18)
                        {
                            player.field_DFArraySet(var_1, (byte)(player.field_DFArrayGet(var_1) + 5));
                        }
                    }
                }

                if (var_1 == 0)
                {
                    if (player.con == 0x13 || player.con == 0x14)
                    {
                        player.field_DFArraySet(var_1, (byte)(player.field_DFArrayGet(var_1) + 1));
                    }
                    else if (player.con == 0x15 || player.con == 0x16)
                    {
                        player.field_DFArraySet(var_1, (byte)(player.field_DFArrayGet(var_1) + 2));
                    }
                    else if (player.con == 0x17 || player.con == 0x18)
                    {
                        player.field_DFArraySet(var_1, (byte)(player.field_DFArrayGet(var_1) + 3));
                    }
                    else if (player.con == 0x19)
                    {
                        player.field_DFArraySet(var_1, (byte)(player.field_DFArrayGet(var_1) + 4));
                    }
                }
            }
        }


        static sbyte[,] /*seg600:3F20 */ unk_1A230 = { 
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 10, 15, 0, 0, 0, -10, -5 },
            { 0, 5, -5, 0, 5, 10, 5, 0, 0 },
            { 0, 0, 5, 10, 5, 5, 10, -15, 0 }, 
            { 0, 10, 0, 0, 0, 5, 0, 0, 0 }, 
            { 0, 5, 5, 5, 10, 15, 5, -15, -5 }, 
            { 0, -5, 5, 5, 0, 0, 5, 5, -10 }, 
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 
            { 0, -15, -10, -10, -20, -10, -19, -5, 10 }, 
            { 0, -15, -5, -5, 0, -5, -10, 0, 0 }, 
            { 0, 0, 0, -5, 0, 0, 0, 0, 0 }, 
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, -5, 0, 0, 0 } };

        static sbyte[,] /*seg600:3F33 */ unk_1A243 = { 
            { 0, 5, 10, 5, 0, 0 }, 
            { 0, 0, 5, 10, 5, 5 }, 
            { 5, 10, -15, 0, 10, 0 }, 
            { 0, 0, 0, 5, 0, 0 }, 
            { 0, 0, 5, 5, 5, 10 }, 
            { 10, 15, 5, -15, -5, -5 }, 
            { -5, 5, 5, 0, 0, 5 },
            { 5, 5, -10, 0, 0, 0 }, 
            { 0, 0, 0, 0, 0, 0 }, 
            { 0, -15, -10, -10, -20, -10 }, 
            { -10, -19, -5, -10, -15, -5 }, 
            { -5, -5, 0, -5, -10, 0 }, 
            { 0, 0, 0, 0, -5, 0 }, 
            { 0, 0, 0, 0, 0, 0 }, 
            { 0, 0, 0, 0, 0, 0 }, 
            { 0, 0, 0, 0, 0, 0 }, 
            { 0, 0, -5, 0, 0, 0 }, 
            { 0, 5, 10, 0, 5, 5 }, 
            { 5, 10, 15, 5, 10, 10 }, 
            { 10, 15, 20, 10, 12, 12 }, 
            { 12, 8, 8, 18, 17, 99 }, 
            { 99, 0, 3, 18, 3, 18 } };

        static byte[,] /*seg600:3EC0 */ unk_1A1D0 = {
            { 0, 0, 0, 0 , 0 , 0 ,0 , 0, 0 },
            { 0, 0x1E, 0x19, 0x14 ,0x0F, 0x0A, 0x0A, 0x55, 0x00 },
            { 0, 0x23, 0x1D, 0x19, 0x15, 0x0F, 0x0A, 0x56, 0x00 },
            { 0, 0x28, 0x21, 0x1E, 0x1B, 0x14, 0x0F, 0x57, 0x00 },
            { 0, 0x2D, 0x25, 0x23, 0x21, 0x19, 0x0F, 0x58, 0x14 },
            { 0, 0x32, 0x2A, 0x28, 0x28, 0x1F, 0x14, 0x5A, 0x19 },
            { 0, 0x37, 0x2F, 0x2D, 0x25, 0x14, 0x5C, 0x1E, 0x3C },
            { 0, 0x34, 0x32, 0x37, 0x2B, 0x19, 0x5E, 0x23, 0x41},
            { 0, 0x39, 0x37, 0x3E, 0x31, 0x19, 0x60, 0x28, 0x46},
            { 0, 0x3E, 0x3C, 0x46, 0x38, 0x1E, 0x62, 0x2D, 0x50},
            { 0, 0x43, 0x41, 0x4E, 0x3F, 0x1E, 0x63, 0x32, 0x5A},
            { 0, 0x48, 0x46, 0x56, 0x46, 0x23, 0x63, 0x3C, 0x64},
            { 0, 0x64, 0x4D, 0x4B, 0x5E, 0x4D, 0x23, 0x63, 0x41 } };



        internal static void sub_6AAEA(Player player)
        {
            byte var_2 = 0; //Simeon

            var item_found = player.items.Find(item => item.readied && (item.ScrollLearning(3, 2) || item.ScrollLearning(3, 11)));
            var var_A = item_found != null && item_found.ScrollLearning(3, 11);
            var var_B = item_found != null && item_found.ScrollLearning(3, 2);

            int var_4 = (sbyte)(player.thief_lvl + (sub_6B3D1(player) * player.field_117));

            if (var_4 < 4 && var_B == true)
            {
                var_4 = 4;
                var_B = false;
            }

            int var_5 = var_4;

            for (int var_1 = 1; var_1 <= 8; var_1++)
            {
                if (var_A == true)
                {
                    switch (var_1)
                    {
                        case 1:
                            if (var_4 < 5)
                            {
                                var_4 = 5;
                                var_2 = 0;
                            }
                            else
                            {
                                var_2 = 5;
                            }
                            break;

                        case 2:
                            if (var_4 < 7)
                            {
                                var_4 = 7;
                                var_2 = 0;
                            }
                            else
                            {
                                var_2 = 5;
                            }
                            break;
                    }
                }

                if (unk_1A230[(int)player.race, var_1] < 0 &&
                    unk_1A1D0[var_4, var_1] < (System.Math.Abs(unk_1A230[(int)player.race, var_1]) + var_2))
                {
                    player.field_EA[var_1 - 1] = 0;
                }
                else
                {
                    player.field_EA[var_1 - 1] = (byte)(var_2 + unk_1A1D0[var_4, var_1] + unk_1A230[(int)player.race, var_1]);

                    if (var_1 < 6)
                    {
                        player.field_EA[var_1 - 1] += (byte)unk_1A243[player.dex, var_1];
                    }

                }

                if (var_B == true)
                {
                    player.field_EA[var_1 - 1] += 10;
                }

                var_4 = var_5;
            }
        }


        internal static bool player_can_be_class(int _class, Player player) /* sub_6AD3E */
        {
            bool var_2 = (_class != HumanFirstClassOrSeventeen(player));
            int var_3 = 0;

            while (var_3 <= 5 &&
                (gbl.class_stats_min[HumanFirstClassOrSeventeen(player)][var_3] < 9 || player.stats[var_3].tmp > 14))
            {
                var_3++;
            }

            var_2 = (var_2 == true && var_3 > 5);
            var_3 = 0;

            while (var_3 <= 5 &&
                (gbl.class_stats_min[_class][var_3] < 9 || player.stats[var_3].tmp > 16))
            {
                var_3++;
            }

            var_2 = (var_2 == true && var_3 > 5);

            byte var_4 = 1;

            while (gbl.class_alignments[_class, 0] >= var_4 &&
                gbl.class_alignments[_class, var_4] != player.alignment)
            {
                var_4++;
            }

            if (var_2 == false ||
                gbl.class_alignments[_class, 0] < var_4)
            {
                var_2 = false;
            }
            else
            {
                var_2 = true;
            }

            return var_2;
        }


        internal static void multiclass(Player player)
        {
            int classes = gbl.race_classes[(int)player.race, 0];

            List<MenuItem> list = new List<MenuItem>();

            list.Add(new MenuItem("Pick New Class", true));
 
            for (int i = 1; i <= classes; i++)
            {
                int _class = gbl.race_classes[(int)player.race, i];

                if (player_can_be_class(_class, player) == true)
                {
                    list.Add(new MenuItem(ovr020.classString[_class]));
                }
            }

            if (list.Count == 1)
            {
                seg041.DisplayStatusText(15, 4, player.name + " doesn't qualify.");
                list.Clear();
                return;
            }

            MenuItem list_ptr;
            int index = 1;
            bool show_exit = true;
            bool var_F = true;

            char input_key;

            do
            {
                input_key = ovr027.sl_select_item(out list_ptr, ref index, ref var_F, show_exit, list,
                    0x16, 0x26, 2, 1, 15, 10, 13, "Select", string.Empty);

                if (input_key == 0)
                {
                    return;
                }
            } while (input_key != 0x53);

            player.exp = 0;
            player.field_11C = 2;
            byte var_2 = 0;

            while (var_2 <= 7 && ovr020.classString[var_2] != list_ptr.Text)
            {
                var_2++;
            }

            list.Clear();

            player.Skill_B_lvl[HumanFirstClassOrSeventeen(player)] = HumanFirstClassLevelOrZero(player);

            player.field_E6 = player.field_E5;
            player.field_E5 = 1;

            player.class_lvls[HumanFirstClassOrSeventeen(player)] = 0;
            player.class_lvls[var_2] = 1;

            for (int i = 0; i < 5; i++)
            {
                player.field_12D[0, i] = 0;
                player.field_12D[1, i] = 0;
                player.field_12D[2, i] = 0;
            }

            if (var_2 == 0)
            {
                player.field_12D[0,0] = 1;
            }
            else if (var_2 == 5)
            {
                player.field_12D[2,0] = 1;
                player.field_79[0xB - 1] = 1;
                player.field_79[0x12 - 1] = 1;
                player.field_79[0x15 - 1] = 1;
            }

            player._class = (ClassId)var_2;

            seg041.DisplayStatusText(0, 10, player.name + " is now a 1st level " + ovr020.classString[var_2] + ".");

            seg051.FillChar(0, 0x54, player.spell_list);

            sub_6A3C6(player);
            calc_cleric_spells(true, player);
            sub_6A7FB(player);
            sub_6AAEA(player);

            foreach(var item in player.items)
            {
                if ((gbl.unk_1C020[item.type].classFlags & player.classFlags) == 0 &&
                    item.cursed == false)
                {
                    item.readied = false;
                }
            }
        }


        internal static int getExtraFirstSkill(Player player)
        {
            if (player.race != Race.human)
            {
                return 0x11;
            }

            for (int index = 0; index < 7; index++)
            {
                if (player.Skill_B_lvl[index] > 0)
                    return index;
            }

            return 0x11;
        }

        internal static int HumanFirstClassOrSeventeen(Player player) // getFirstSkill
        {
            if (player.race != Race.human)
            {
                return 17;
            }

            for (int index = 0; index <= 7; index++)
            {
                if (player.class_lvls[index] > 0)
                    return index;
            }

            return 17;
        }

        internal static byte HumanFirstClassLevelOrZero(Player player) /* hasAnySkills */
        {
            if (player.race != Race.human)
            {
                return 0;
            }

            int loop_var = 0;

            while (loop_var < 7 &&
                player.class_lvls[loop_var] == 0)
            {
                loop_var++;
            }

            return player.class_lvls[loop_var];
        }


        internal static bool is_human(Player player)
        {
            return (player.race == Race.human);
        }


        internal static sbyte sub_6B3D1(Player player)
        {
            if (HumanFirstClassLevelOrZero(player) > player.field_E6)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
