using Classes;

namespace engine
{
    class ovr010
    {
        internal static void sub_3504B(Player player)
        {
            bool var_2;
            byte var_1;

            var_2 = process_input_in_monsters_turn(player);
            ovr027.ClearPromptArea();
            ovr025.ClearPlayerTextArea();

            if (player.in_combat == false)
            {
                var_2 = ovr025.clear_actions(player);
            }

            var_1 = player.actions.field_15;

            if (var_1 == 0 || var_1 == 4 || ovr024.roll_dice(4, 1) == 1)
            {
                var_1 = ovr024.roll_dice(8, 1);

                if (var_1 != 8)
                {
                    var_1 = (byte)(ovr024.roll_dice(2, 1) + 4);
                }
                else
                {
                    var_1 = ovr024.roll_dice(4, 1);
                }
            }

            player.actions.field_15 = var_1;

            if (var_2 == false)
            {
                var_2 = sub_3637F(player);
            }

            if (player.actions.field_14 != 0 &&
                player.actions.field_10 == 0)
            {
                ovr025.DisplayPlayerStatusString(true, 10, "flees in panic", player);
            }

            if (var_2 == true)
            {
                return;
            }

            if (sub_354AA(player))
            {
                ovr025.clear_actions(player);
                return;
            }

            if (player.actions.spell_id > 0)
            {
                ovr023.sub_5D2E1(1, QuickFight.True, player.actions.spell_id);

                ovr025.clear_actions(player);
                return;
            }

            if (turn_undead(player) != 0)
            {
                ovr025.clear_actions(player);
                return;
            }

            if (sub_3560B(player) == true)
            {
                return;
            }

            sub_36673(player);
            var_2 = process_input_in_monsters_turn(player);

            while (var_2 == false)
            {
                if (ovr014.find_target(false, 1, 0xff, player) == true &&
                    player.actions.delay > 0 &&
                    player.in_combat == true)
                {
                    var_2 = sub_35DB1(player);
                }
                else
                {
                    var_2 = sub_361F7(player);
                }
            }
        }


        internal static byte turn_undead(Player player)
        {
            Player var_5;
            byte ret_val;

            if (player.actions.field_11 == 0 &&
                (player.cleric_lvl > 0 || player.turn_undead > player.field_E6) &&
                ovr014.sub_3F433(out var_5, player) == true)
            {
                ret_val = 1;
                ovr014.turns_undead(player);
            }
            else
            {
                ret_val = 0;
            }

            return ret_val;
        }


        internal static bool sub_352AF(int spell_id, int mapY, int mapX)
        {
            bool result = false;

            int save_bonus = (gbl.player_ptr.combat_team == CombatTeam.Ours)? -2 : 8;

            ovr032.Rebuild_SortedCombatantList(gbl.mapToBackGroundTile, 1, 0xff, gbl.spell_table[spell_id].field_F, mapY, mapX);
   
            for (int i = 1; i <= gbl.sortedCombatantCount; i++)
            {
                Player tmpPlayer = gbl.player_array[gbl.SortedCombatantList[i].player_index];
                SpellEntry spell_entry = gbl.spell_table[spell_id];

                if (gbl.player_ptr.OppositeTeam() != tmpPlayer.combat_team &&
                    spell_entry.can_save_flag != DamageOnSave.Zero &&
                    ovr024.do_saving_throw(save_bonus, spell_entry.field_9, tmpPlayer) == false)
                {
                    result = true;
                }
            }

            return result;
        }


        internal static bool sub_353B1(byte arg_0, byte arg_2, Player attacker)
        {
            if (gbl.spell_table[arg_2].field_D < arg_0)
            {
                Player dummy_target;
                if ((arg_2 != 3 && gbl.spell_table[arg_2].field_E == 0) ||
                    (arg_2 == 3 && ovr014.find_healing_target(out dummy_target, attacker)))
                {
                    return true;
                }
                else
                {
                    int near_count = ovr025.near_enemy(ovr023.sub_5CDE5(arg_2), attacker);

                    if (near_count > 0)
                    {
                        if (gbl.spell_table[arg_2].field_F == 0)
                        {
                            return true;
                        }
                        else
                        {
                            for (int i = 1; i <= near_count; i++)
                            {
                                int index = gbl.near_targets[i];
                                if (sub_352AF(arg_2, gbl.CombatMap[index].yPos, 
                                        gbl.CombatMap[index].xPos) == true)
                                {
                                    return false;
                                }
                            }
                            return true;
                        }
                    }
                }
            }

            return false;
        }


        internal static bool sub_354AA(Player player)
        {
            Item var_14 = null;

            int teamCount = player.OppositeTeam() == CombatTeam.Ours ? gbl.friends_count : gbl.foe_count;
            if (player.actions.can_use == true &&
                teamCount > 0 &&
                gbl.area_ptr.can_cast_spells == false)
            {
                int var_3 = ovr024.roll_dice(7, 1);
                byte var_2 = 7;
                for (int var_4 = 1; var_4 <= var_3; var_4++)
                {
                    foreach (var item_ptr in player.items)
                    {
                        byte var_8 = (byte)item_ptr.affect_2;
                        byte var_7 = gbl.unk_1C020[item_ptr.type].item_slot;

                        if (ovr023.item_is_scroll(item_ptr) == false &&
                            (int)item_ptr.affect_3 < 0x80 &&
                            item_ptr.readied &&
                            var_8 > 0)
                        {
                            if (var_8 > 0x38)
                            {
                                var_8 -= 0x17;
                            }

                            if (sub_353B1(var_2, var_8, player))
                            {
                                var_14 = item_ptr;
                                break;
                            }
                        }
                    }
                    var_2 -= 1;
                }
            }

            bool var_1 = false;
            if (var_14 != null)
            {
                bool var_15 = false; /* simeon */
                ovr020.sub_56478(ref var_15, var_14);
                var_1 = true;
            }

            return var_1;
        }


        internal static bool sub_3560B(Player player)
        {
            byte var_5E;
            byte var_5A;
            byte[] spell_list = new byte[gbl.max_spells];

            int spells_count = 0;

            if (player.actions.can_cast == true)
            {
                for (int sp_index = 1; sp_index < gbl.max_spells; sp_index++)
                {
                    if (player.spell_list[sp_index] > 0)
                    {
                        spell_list[spells_count] = player.spell_list[sp_index];
                        spells_count++;
                    }
                }
            }

            byte spell_id = 0;
            var_5A = 7;
            int var_5B = ovr024.roll_dice(7, 1);
            int var_5D = 1;


            if (spells_count > 0 &&
                (player.field_F7 > 0x7F || gbl.magicOn == true))
            {
                if ((player.OppositeTeam()== CombatTeam.Ours ? gbl.friends_count : gbl.foe_count) > 0)
                {
                    while (var_5D <= var_5B && spell_id == 0)
                    {
                        for (var_5E = 1; var_5E < 4 && spell_id == 0; var_5E++)
                        {
                            int random_spell_index = ovr024.roll_dice(spells_count, 1) - 1;
                            byte random_spell_id = spell_list[random_spell_index];

                            if (sub_353B1(var_5A, random_spell_id, player))
                            {
                                spell_id = random_spell_id;
                            }
                        }

                        var_5A--;
                        var_5D++;
                    }
                }
            }

            bool casting_spell;

            if (spell_id > 0)
            {
                ovr014.spell_menu3(out casting_spell, QuickFight.True, spell_id);
            }
            else
            {
                casting_spell = false;
            }

            return casting_spell;
        }

        static byte[] data_2B8 = new byte[]{ 
            0, 8, 7, 6, 1, 2, 8, 1, 2, 7,
            6, 7 ,1 ,8 ,6 ,2 ,1 ,7 ,8 ,2 ,
            6, 8 ,7, 6 ,5 ,4 ,8 ,1 ,2 ,3,  
            4 ,8 ,4 ,6 ,2 ,8 ,6, 4 ,0 ,8 ,
            0 ,6 ,2 ,8 ,2 ,0 ,4 ,0, 0 ,2 ,
            6 ,2 ,2 ,0 ,4 ,4 ,4 ,2, 6, 6 };/* actual from seg600:02BD - seg600:02F8 */

        internal static bool sub_3573B(out bool arg_0, byte arg_4, byte arg_6, Player player)
        {
            byte var_A;

            arg_0 = false;
            bool result = false;

            byte var_6 = data_2B8[(player.actions.field_15 * 5) + arg_6];
            byte playerDirection = (byte)((arg_4 + var_6) % 8);

            byte groundTile;
            byte playerIndex;  
            bool isPoisonousCloud;
            bool isNoxiousCloud;
            ovr033.getGroundInformation(out isPoisonousCloud, out isNoxiousCloud, out groundTile, out playerIndex, playerDirection, player);

            if (groundTile == 0)
            {
                arg_0 = true;
            }
            else
            {
                if (gbl.BackGroundTiles[groundTile].move_cost == 0xff)
                {
                    return false;
                }

                if ((playerDirection & 1) != 0)
                {
                    var_A = (byte)(gbl.BackGroundTiles[groundTile].move_cost * 3);
                }
                else
                {
                    var_A = (byte)(gbl.BackGroundTiles[groundTile].move_cost * 2);
                }

                if (playerIndex == 0 && var_A < player.actions.move)
                {
                    if (isNoxiousCloud == true &&
                        player.HasAffect(Affects.animate_dead) == false &&
                        player.HasAffect(Affects.stinking_cloud) == false &&
                        player.HasAffect(Affects.affect_6f) == false &&
                        player.HasAffect(Affects.affect_7d) == false &&
                        player.HasAffect(Affects.affect_81) == false &&
                        player.HasAffect(Affects.minor_globe_of_invulnerability) == false &&
                        player.actions.field_10 == 0)
                    {
                        if (ovr024.do_saving_throw(0, 0, player) == false)
                        {
                            var_A = (byte)(player.actions.move + 1);
                        }
                    }


                    if (isPoisonousCloud == true &&
                        player.field_E5 < 7 &&
                        player.HasAffect(Affects.affect_81) == false &&
                        player.HasAffect(Affects.affect_6f) == false &&
                        player.HasAffect(Affects.affect_85) == false &&
                        player.HasAffect(Affects.affect_7d) == false &&
                        player.actions.field_10 == 0)
                    {
                        var_A = (byte)(player.actions.move + 1);
                    }

                    if (player.actions.move >= var_A)
                    {
                        result = true;
                    }
                }
            }

            return result;
        }


        internal static void sub_359D1(Player player)
        {
            bool var_5;

            byte var_3;
            byte var_2 = 0; /* Simeon */
            byte var_1;

            string prompt = string.Format("Move/Attack, Move Left = {0} ", player.actions.move / 2);

            seg041.displayString(prompt, 0, 10, 0x18, 0);

            if (process_input_in_monsters_turn(player) == false)
            {
                if ((player.actions.move / 2) > 0 &&
                    player.actions.delay > 0)
                {
                    if (player.field_F7 < 0x80 ||
                       (player.field_F7 > 0x7F && gbl.enemyHealthPercentage <= (ovr024.roll_dice(100, 1) + gbl.byte_1D2CC)) ||
                        player.combat_team == CombatTeam.Enemy)
                    {
                        if (player.actions.field_14 != 0 ||
                            player.armor != null ||
                            player._class != ClassId.magic_user)
                        {
                            if (player.actions.field_14 == 0)
                            {
                                var_1 = ovr014.getTargetDirection(player.actions.target, player);
                            }
                            else
                            {
                                player.actions.field_15 = ovr024.roll_dice(2, 1);
                                var_1 = (byte)(gbl.mapDirection - (((gbl.mapDirection + 2) % 4) / 2));

                                if (player.combat_team == CombatTeam.Ours)
                                {
                                    var_1 += 4;
                                }

                                var_1 %= 8;
                            }

                            bool var_4 = false;
                            var_5 = false;
                            var_3 = 1;

                            while (var_3 < 6 && var_5 == false &&
                                sub_3573B(out var_4, var_1, var_3, player) == false)
                            {
                                if (player.actions.field_14 != 0 &&
                                    var_4 == true)
                                {
                                    var_5 = ovr014.flee_battle(player);
                                }
                                else
                                {
                                    var_3++;
                                }
                            }

                            if (var_5 == true)
                            {
                                player.actions.move = 0;
                                player.actions.field_14 = 0;
                                var_5 = ovr025.clear_actions(player);
                            }
                            else
                            {
                                var_2 = (byte)((data_2B8[(player.actions.field_15 * 5) + var_3] + var_1) % 8);

                                if (var_3 == 6 || ((var_2 + 4) % 8) == gbl.byte_1AB18)
                                {
                                    gbl.byte_1AB19++;
                                    player.actions.field_15 %= 6;
                                    player.actions.field_15 += 1;

                                    if (gbl.byte_1AB19 > 1)
                                    {
                                        player.actions.target = null;

                                        if (gbl.byte_1AB19 > 2)
                                        {
                                            player.actions.move = 0;
                                            var_5 = true;
                                        }
                                        else if (ovr014.find_target(false, 1, 0xFF, player) == false)
                                        {
                                            var_5 = sub_361F7(player);
                                        }
                                    }
                                }

                                if (var_3 < 6)
                                {
                                    gbl.byte_1AB18 = var_2;
                                }
                                else
                                {
                                    var_5 = true;
                                }
                            }

                            if (var_5 == false)
                            {
                                gbl.byte_1D910 = (gbl.byte_1D90E || ovr033.sub_74761(false, player) || player.combat_team == CombatTeam.Ours);

                                ovr033.draw_74B3F(0, 0, var_2, player);
                                ovr014.move_step_away_attack(player.actions.direction, player);

                                if (player.in_combat == false)
                                {
                                    var_5 = ovr025.clear_actions(player);
                                }
                                else
                                {
                                    if (player.actions.move > 0)
                                    {
                                        ovr014.sub_3E748(player.actions.direction, player);
                                    }

                                    if (player.in_combat == false)
                                    {
                                        var_5 = ovr025.clear_actions(player);
                                    }

                                    ovr024.in_poison_cloud(1, player);
                                }
                            }
                            return;
                        }
                    }
                }

                var_5 = sub_361F7(player);
            }
        }


        internal static bool sub_35DB1(Player player)
        {
            gbl.byte_1AB18 = 8;
            gbl.byte_1AB19 = 0;

            byte var_13 = 0;
            bool var_3 = true;
            bool var_2 = false;

            ovr024.work_on_00(player, 14);

            if (player.combat_team == CombatTeam.Ours &&
                ovr025.bandage(true) == true)
            {
                player.actions.delay = 0;
            }

            if (player.actions.delay == 0)
            {
                var_3 = false;
            }

            while (var_2 == false && var_3 == true)
            {
                if (player.actions.field_14 != 0)
                {
                    while (player.actions.move > 0 &&
                        player.actions.delay > 0 &&
                        player.actions.delay < 20)
                    {
                        sub_359D1(player);
                    }
                }

                if (player.actions.delay == 0 ||
                    player.actions.delay == 20)
                {
                    var_3 = false;
                }
                else
                {
                    var_2 = false;
                }

                if (var_2 == false && var_3 == true)
                {
                    var_13++;

                    if (var_13 > 20)
                    {
                        var_2 = true;
                        
                        var_3 = false;
                        if (sub_361F7(player) == false)
                        {
                            var_3 = true;
                        }
                    }

                    gbl.byte_1D90E = false;
                    int range = 1;

                    if (player.field_151 != null)
                    {
                        range = gbl.unk_1C020[player.field_151.type].field_C - 1;
                    }

                    if (range == 0 || range == 0xff || range == -1)
                    {
                        range = 1;
                    }

                    Player target = player.actions.target;

                    if (target != null &&
                        (target.in_combat == false ||
                        target.combat_team == CombatTeam.Ours))
                    {
                        target = null;
                    }

                    if (target != null &&
                        ovr014.sub_3F143(target, player) == true)
                    {
                        int tmpX = ovr033.PlayerMapXPos(target);
                        int tmpY = ovr033.PlayerMapYPos(target);

                        int var_6 = range;

                        gbl.mapToBackGroundTile.field_6 = false;

                        if (ovr032.canReachTarget(gbl.mapToBackGroundTile, ref var_6, ref tmpY, ref tmpX, ovr033.PlayerMapYPos(player), ovr033.PlayerMapXPos(player)) == true &&
                            (var_6 / 2) <= range)
                        {
                            gbl.byte_1D90E = true;
                        }
                    }

                    if (gbl.byte_1D90E == false)
                    {
                        int enemy_near = ovr025.near_enemy(range, player);

                        if (enemy_near == 0)
                        {
                            if (ovr014.find_target(false, 0, 0xff, player) == true)
                            {
                                sub_359D1(player);
                            }
                            else
                            {
                                var_2 = sub_361F7(player);
                            }
                        }
                        else
                        {
                            int roll = ovr024.roll_dice(enemy_near, 1);

                            target = gbl.player_array[gbl.near_targets[roll]];

                            if (ovr025.is_weapon_ranged(player) == true &&
                                ovr025.is_weapon_ranged_melee(player) == false &&
                                ovr025.near_enemy(1, player) > 0)
                            {
                                sub_36673(player);
                                var_2 = true;
                            }
                            else if (ovr025.getTargetRange(target, player) == 1 ||
                                ovr014.sub_3F143(target, player) == true)
                            {
                                gbl.byte_1D90E = true;
                            }
                        }
                    }

                    if (gbl.byte_1D90E == true)
                    {
                        ovr033.redrawCombatArea(ovr014.getTargetDirection(target, player), 2, ovr033.PlayerMapYPos(player), ovr033.PlayerMapXPos(player));

                    }

                    if (gbl.byte_1D90E == true)
                    {
                        if (ovr014.sub_3EF3D(target, player) == true)
                        {
                            var_2 = ovr025.clear_actions(player);
                        }
                        else
                        {
                            ovr014.sub_3F94D(target, player);

                            Item item = null;

                            if (ovr025.is_weapon_ranged(player) == true)
                            {
                                gbl.byte_1D90E = ovr025.sub_6906C(out item, player);

                                if (ovr025.is_weapon_ranged_melee(player) == true &&
                                    ovr025.getTargetRange(target, player) == 1)
                                {

                                    item = null;
                                }
                            }

                            ovr014.sub_3F9DB(out var_2, item, 0, target, player);

                            if (var_2 == true)
                            {
                                var_3 = false;
                            }
                            else if (target.in_combat == false)
                            {
                                var_2 = true;
                            }
                        }
                    }
                }
            }

            return (var_3 == false);
        }


        internal static bool sub_361F7(Player player)
        {
            bool var_1;

            ovr025.ClearPlayerTextArea();

            if (player.IsHeld() == true ||
                ovr025.is_weapon_ranged(player) == true ||
                player.actions.delay == 0)
            {
                var_1 = ovr025.clear_actions(player);
            }
            else
            {
                var_1 = ovr025.guarding(player);
            }

            return var_1;
        }


        /// <summary>
        /// processes keyboard input during combat. Returns if current player is user controlled
        /// </summary>
        internal static bool process_input_in_monsters_turn(Player player) /* sub_36269 */
        {
            bool player_turn = false;

            if (seg049.KEYPRESSED() == true)
            {
                byte var_6 = seg043.GetInputKey();

                if (var_6 == 0)
                {
                    var_6 = seg043.GetInputKey();
                }

                if (var_6 == 0x32)
                {
                    gbl.magicOn = !gbl.magicOn;

                    if (gbl.magicOn == true)
                    {
                        ovr025.string_print01("Magic On");
                    }
                    else
                    {
                        ovr025.string_print01("Magic Off");
                    }
                }
                else if (var_6 == 0x20)
                {
                    foreach (Player player_ptr in gbl.player_next_ptr)
                    {
                        if (player_ptr.field_F7 < 0x80 &&
                            player_ptr.health_status != Status.animated)
                        {
                            player_ptr.quick_fight = QuickFight.False;
                        }
                    }

                    if (player.quick_fight == QuickFight.False)
                    {
                        player.actions.delay = 20;
                        player_turn = true;
                    }
                }
                else if (var_6 == '-')
                {
                    ovr014.god_intervene();
                }
            }

            seg043.clear_keyboard();

            return player_turn;
        }


        internal static bool sub_3637F(Player player)
        {
            bool var_1 = false;
            player.actions.field_14 = 0;

            ovr024.sub_6460D(player);

            if (player.actions.field_10 != 0)
            {
                player.actions.field_14 = 1;
                ovr025.DisplayPlayerStatusString(true, 10, "is forced to flee", player);
            }
            else if (player.field_F7 > 0x7F)
            {
                gbl.byte_1D2CC = (byte)((player.field_F7 & 0x7F) << 1);

                if (gbl.byte_1D2CC > 0x66)
                {
                    gbl.byte_1D2CC = 0;
                }
                ovr024.work_on_00(player, 0x11);

                if (gbl.byte_1D2CC < (100 - ((player.hit_point_current * 100) / player.hit_point_max)) ||
                    gbl.byte_1D2CC == 0)
                {
                    //byte var_3 = gbl.byte_1D2CC;
                    gbl.byte_1D2CC = gbl.enemyHealthPercentage;

                    ovr024.work_on_00(player, 17);

                    if (gbl.byte_1D2CC < (100 - gbl.area2_ptr.field_58C) ||
                        gbl.byte_1D2CC == 0 ||
                        player.combat_team == CombatTeam.Ours)
                    {
                        int var_2 = ovr014.sub_40E8F(player);

                        if (var_2 <= (ovr014.sub_3E124(player) >> 1))
                        {
                            player.actions.field_14 = 1;
                            ovr024.remove_affect(null, Affects.affect_4a, player);
                            ovr024.remove_affect(null, Affects.affect_4b, player);
                        }
                        else if (player._int > 5)
                        {
                            ovr024.sub_644A7("Surrenders", Status.unconscious, player);

                            var_1 = ovr025.clear_actions(player);
                        }
                    }
                }
            }

            return var_1;
        }


        internal static int sub_36535(Item item, Player player)
        {
            Struct_1C020 var_12 = gbl.unk_1C020[item.type];

            int var_2 = var_12.diceSizeX * var_12.diceCountX;

            if (item.plus > 0)
            {
                var_2 += item.plus * 8;
            }

            if (var_12.field_B > 0)
            {
                var_2 += var_12.field_B * 2;
            }

            if (item.type == 0x55 &&
                player.actions.target != null &&
                player.actions.target.field_E9 > 0)
            {
                var_2 = 8;
            }

            if ((var_12.field_E & 8) > 0)
            {
                var_2 += (var_12.field_5 - 1) * 2;
            }

            if (var_12.field_1 <= 1)
            {
                var_2 += 3;
            }

            if ((var_12.field_1 + player.field_185) > 3)
            {
                var_2 = 0;
            }

            if (item.affect_3 == Affects.cast_throw_lightening &&
                ((int)item.affect_2 & 0x0f) != player.alignment)
            {
                var_2 = 0;
            }

            if (item.affect_2 == Affects.affect_53)
            {
                var_2 = 0;
            }

            if (item.cursed == true)
            {
                var_2 = 0;
            }

            return var_2;
        }


        internal static void sub_36673(Player player)
        {            
            if (player.field_151 != null)
            {
                player.field_185 -= gbl.unk_1C020[player.field_151.type].field_1;
            }

            if (player.field_155 != null)
            {
                player.field_185 -= gbl.unk_1C020[player.field_155.type].field_1;
            }

            Item var_4 = null;
            Item var_8 = null;
            Item var_C = null;
            int var_15 = 1;

            int var_16 = (byte)(player.field_120 * player.field_11E);

            if (player.field_122 > 0)
            {
                var_16 += (byte)(player.field_122 * 2);
            }

            int max_bonus = 0;

            foreach(Item item in player.items)
            {
                int item_type = item.type;

                if (gbl.unk_1C020[item_type].item_slot == 0 &&
                    (gbl.unk_1C020[item_type].classFlags & player.classFlags) != 0)
                {
                    int var_18 = sub_36535(item, player);

                    if ((gbl.unk_1C020[item_type].field_E & 8) != 0 ||
                        (gbl.unk_1C020[item_type].field_E & 0x10) != 0)
                    {
                        if (var_18 > var_15)
                        {
                            var_4 = item;
                            var_15 = var_18;
                        }
                    }

                    if ((gbl.unk_1C020[item_type].field_E & 8) == 0 &&
                        var_18 > var_16)
                    {
                        var_8 = item;
                        var_16 = var_18;
                    }
                }


                if (gbl.unk_1C020[item_type].item_slot == 1)
                {
                    if ((gbl.unk_1C020[item_type].classFlags & player.classFlags) != 0)
                    {
                        int bonus = item.plus >= 0 ? item.plus + 1 : 0;

                        if (bonus > max_bonus)
                        {
                            var_C = item;
                            max_bonus = bonus;
                        }
                    }
                }
            }

            bool ranged_melee = ovr025.item_is_ranged_melee(var_4);
            bool var_1F = false;
            Item tmpItem = null;
            byte var_1A = 0;

            if (var_4 != null)
            {
                var_1A = gbl.unk_1C020[var_4.type].field_E;

                if ((var_1A & 0x10) != 0)
                {
                    tmpItem = var_4;
                }

                if ((var_1A & 8) != 0)
                {
                    if ((var_1A & 0x01) != 0)
                    {
                        tmpItem = player.Item_ptr_03;
                    }

                    if ((var_1A & 0x80) != 0)
                    {
                        tmpItem = player.Item_ptr_04;
                    }
                }
            }

            if (tmpItem != null ||
                var_1A == 10)
            {
                var_1F = true;
            }

            Item weapon;

            if (var_4 != null &&
                var_15 > (var_16 >> 1) &&
                var_1F == true &&
                (ranged_melee == true || ovr025.near_enemy(1, player) == 0))
            {
                weapon = var_4;
            }
            else
            {
                weapon = var_8;
            }

            bool itemsChanged = false;
            bool replace_weapon = true;

            if (player.field_151 != null &&
                (player.field_151 == weapon ||
                 player.field_151.cursed == true))
            {
                replace_weapon = false;
            }

            if (replace_weapon)
            {
                if (player.field_151 != null)
                {
                    ovr020.ready_Item(player.field_151);
                }

                ovr025.reclac_player_values(player);

                if (player.field_155 != null &&
                    player.field_155.cursed == false)
                {
                    player.field_185 -= gbl.unk_1C020[player.field_155.type].field_1;
                }

                if (weapon != null)
                {
                    ovr020.ready_Item(weapon);
                }

                itemsChanged = true;
            }

            ovr025.reclac_player_values(player);
            ovr014.sub_3EDD4(player);
            replace_weapon = true;

            if (player.field_155 != null &&
                (player.field_155 == var_C || player.field_155.cursed == true))
            {
                replace_weapon = false;
            }
            
            if (player.field_185 > 2)
            {
                if (player.field_155 == null ||
                    player.field_155.cursed == true)
                {
                    ovr020.ready_Item(weapon);
                    itemsChanged = true;
                }
                else
                {
                    ovr020.ready_Item(player.field_155);
                    itemsChanged = true;
                }
            }
            else if (player.field_185 < 2 && replace_weapon)
            {
                if (player.field_155 != null)
                {
                    ovr020.ready_Item(player.field_155);
                }
                ovr025.reclac_player_values(player);

                if (var_C != null)
                {
                    ovr020.ready_Item(var_C);
                }

                itemsChanged = true;
            }


            ovr025.reclac_player_values(player);

            if (itemsChanged == true)
            {
                ovr025.display_hitpoint_ac(player);
            }
        }
    }
}
