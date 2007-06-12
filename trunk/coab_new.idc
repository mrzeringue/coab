//
// �������������������������������������������������������������������������ͻ
// �     This file is generated by The Interactive Disassembler (IDA)        �
// �������������������������������������������������������������������������ͼ
//
//
//      This file contains the user-defined type definitions.
//      To use it press F2 in IDA and enter the name of this file.
//

#define UNLOADED_FILE   1
#include <idc.idc>

static main(void) {
        Enums();                // enumerations
        Structures();           // structure types
}

//------------------------------------------------------------------------
// Information about enum types

static Enums(void) {
        auto id;                // enum id

	id = AddEnum(-1,"cure_wound",0x1100000);
	AddConstEx(id,"cure_light",	0x1,	0xffffffff);
	AddConstEx(id,"cure_serious",	0x2,	0xffffffff);
	AddConstEx(id,"cure_critical",	0x3,	0xffffffff);
	AddConstEx(id,"heal",	0x4,	0xffffffff);
	id = AddEnum(-1,"Bool",0x1100000);
	AddConstEx(id,"false",	0x0,	0xffffffff);
	AddConstEx(id,"true",	0x1,	0xffffffff);
	id = AddEnum(-1,"player_status",0x1100000);
	AddConstEx(id,"okey",	0x0,	0xffffffff);
	AddConstEx(id,"animated",	0x1,	0xffffffff);
	AddConstEx(id,"tempgone",	0x2,	0xffffffff);
	AddConstEx(id,"running",	0x3,	0xffffffff);
	AddConstEx(id,"unconscious",	0x4,	0xffffffff);
	AddConstEx(id,"dying",	0x5,	0xffffffff);
	AddConstEx(id,"dead",	0x6,	0xffffffff);
	AddConstEx(id,"stoned",	0x7,	0xffffffff);
	AddConstEx(id,"gone",	0x8,	0xffffffff);
	id = AddEnum(-1,"race",0x2200000);
	AddConstEx(id,"monster",	0x0,	0xffffffff);
	AddConstEx(id,"dwarf",	0x1,	0xffffffff);
	AddConstEx(id,"elf",	0x2,	0xffffffff);
	AddConstEx(id,"gnome",	0x3,	0xffffffff);
	AddConstEx(id,"half_elf",	0x4,	0xffffffff);
	AddConstEx(id,"halfling",	0x5,	0xffffffff);
	AddConstEx(id,"half_orc",	0x6,	0xffffffff);
	AddConstEx(id,"human",	0x7,	0xffffffff);
	id = AddEnum(-1,"class",0x2200000);
	AddConstEx(id,"cleric",	0x0,	0xffffffff);
	AddConstEx(id,"druid",	0x1,	0xffffffff);
	AddConstEx(id,"fighter",	0x2,	0xffffffff);
	AddConstEx(id,"paladin",	0x3,	0xffffffff);
	AddConstEx(id,"ranger",	0x4,	0xffffffff);
	AddConstEx(id,"magic_user",	0x5,	0xffffffff);
	AddConstEx(id,"thief",	0x6,	0xffffffff);
	AddConstEx(id,"monk",	0x7,	0xffffffff);
	AddConstEx(id,"mc_c_f",	0x8,	0xffffffff);
	AddConstEx(id,"mc_c_f_m",	0x9,	0xffffffff);
	AddConstEx(id,"mc_c_r",	0xa,	0xffffffff);
	AddConstEx(id,"mc_c_mu",	0xb,	0xffffffff);
	AddConstEx(id,"mc_c_t",	0xc,	0xffffffff);
	AddConstEx(id,"mc_f_mu",	0xd,	0xffffffff);
	AddConstEx(id,"mc_f_t",	0xe,	0xffffffff);
	AddConstEx(id,"mc_f_mu_t",	0xf,	0xffffffff);
	AddConstEx(id,"mc_mu_t",	0x10,	0xffffffff);
	AddConstEx(id,"unknown",	0x11,	0xffffffff);
	id = AddEnum(-1,"money",0x1100000);
	AddConstEx(id,"copper",	0x1,	0xffffffff);
	AddConstEx(id,"silver",	0x2,	0xffffffff);
	AddConstEx(id,"electrum",	0x3,	0xffffffff);
	AddConstEx(id,"gold",	0x4,	0xffffffff);
	AddConstEx(id,"platinum",	0x5,	0xffffffff);
	AddConstEx(id,"gems",	0x6,	0xffffffff);
	AddConstEx(id,"jewelry",	0x7,	0xffffffff);
	id = AddEnum(-1,"affects",0x1100000);
	AddConstEx(id,"bless",	0x1,	0xffffffff);
	AddConstEx(id,"cursed",	0x2,	0xffffffff);
	AddConstEx(id,"affect_03",	0x3,	0xffffffff);
	AddConstEx(id,"dispel_evil",	0x4,	0xffffffff);
	AddConstEx(id,"detect_magic",	0x5,	0xffffffff);
	AddConstEx(id,"affect_06",	0x6,	0xffffffff);
	AddConstEx(id,"faerie_fire",	0x7,	0xffffffff);
	AddConstEx(id,"protection_from_evil",	0x8,	0xffffffff);
	AddConstEx(id,"protection_from_good",	0x9,	0xffffffff);
	AddConstEx(id,"resist_cold",	0xa,	0xffffffff);
	AddConstEx(id,"charm_person",	0xb,	0xffffffff);
	AddConstEx(id,"enlarge",	0xc,	0xffffffff);
	AddConstEx(id,"affect_0d",	0xd,	0xffffffff);
	AddConstEx(id,"friends",	0xe,	0xffffffff);
	AddConstEx(id,"affect_0f",	0xf,	0xffffffff);
	AddConstEx(id,"read_magic",	0x10,	0xffffffff);
	AddConstEx(id,"shield",	0x11,	0xffffffff);
	AddConstEx(id,"affect_12",	0x12,	0xffffffff);
	AddConstEx(id,"find_traps",	0x13,	0xffffffff);
	AddConstEx(id,"resist_fire",	0x14,	0xffffffff);
	AddConstEx(id,"silence_15_radius",	0x15,	0xffffffff);
	AddConstEx(id,"slow_poison",	0x16,	0xffffffff);
	AddConstEx(id,"spiritual_hammer",	0x17,	0xffffffff);
	AddConstEx(id,"detect_invisibility",	0x18,	0xffffffff);
	AddConstEx(id,"invisibility",	0x19,	0xffffffff);
	AddConstEx(id,"affect_1a",	0x1a,	0xffffffff);
	AddConstEx(id,"fumbling",	0x1b,	0xffffffff);
	AddConstEx(id,"mirror_image",	0x1c,	0xffffffff);
	AddConstEx(id,"ray_of_enfeeblement",	0x1d,	0xffffffff);
	AddConstEx(id,"affect_1e",	0x1e,	0xffffffff);
	AddConstEx(id,"helpless",	0x1f,	0xffffffff);
	AddConstEx(id,"funky__32",	0x20,	0xffffffff);
	AddConstEx(id,"blinded",	0x21,	0xffffffff);
	AddConstEx(id,"cause_disease_1",	0x22,	0xffffffff);
	AddConstEx(id,"confuse",	0x23,	0xffffffff);
	AddConstEx(id,"bestow_curse",	0x24,	0xffffffff);
	AddConstEx(id,"blink",	0x25,	0xffffffff);
	AddConstEx(id,"strength",	0x26,	0xffffffff);
	AddConstEx(id,"haste",	0x27,	0xffffffff);
	AddConstEx(id,"affect_28",	0x28,	0xffffffff);
	AddConstEx(id,"prot_from_normal_missiles",	0x29,	0xffffffff);
	AddConstEx(id,"slow",	0x2a,	0xffffffff);
	AddConstEx(id,"affect_2b",	0x2b,	0xffffffff);
	AddConstEx(id,"cause_disease_2",	0x2c,	0xffffffff);
	AddConstEx(id,"prot_from_evil_10_radius",	0x2d,	0xffffffff);
	AddConstEx(id,"prot_from_good_10_radius",	0x2e,	0xffffffff);
	AddConstEx(id,"affect_2f",	0x2f,	0xffffffff);
	AddConstEx(id,"affect_30",	0x30,	0xffffffff);
	AddConstEx(id,"prayer",	0x31,	0xffffffff);
	AddConstEx(id,"hot_fire_shield",	0x32,	0xffffffff);
	AddConstEx(id,"snake_charm",	0x33,	0xffffffff);
	AddConstEx(id,"paralyze",	0x34,	0xffffffff);
	AddConstEx(id,"sleep",	0x35,	0xffffffff);
	AddConstEx(id,"cold_fire_shield",	0x36,	0xffffffff);
	AddConstEx(id,"poisoned",	0x37,	0xffffffff);
	AddConstEx(id,"affect_38",	0x38,	0xffffffff);
	AddConstEx(id,"affect_39",	0x39,	0xffffffff);
	AddConstEx(id,"affect_3a",	0x3a,	0xffffffff);
	AddConstEx(id,"regenerate",	0x3b,	0xffffffff);
	AddConstEx(id,"affect_3c",	0x3c,	0xffffffff);
	AddConstEx(id,"fire_resist",	0x3d,	0xffffffff);
	AddConstEx(id,"affect_3e",	0x3e,	0xffffffff);
	AddConstEx(id,"minor_globe_of_invulnerability",	0x3f,	0xffffffff);
	AddConstEx(id,"affect_40",	0x40,	0xffffffff);
	AddConstEx(id,"affect_41",	0x41,	0xffffffff);
	AddConstEx(id,"affect_42",	0x42,	0xffffffff);
	AddConstEx(id,"affect_43",	0x43,	0xffffffff);
	AddConstEx(id,"feeble",	0x44,	0xffffffff);
	AddConstEx(id,"invisible_to_animals",	0x45,	0xffffffff);
	AddConstEx(id,"affect_46",	0x46,	0xffffffff);
	AddConstEx(id,"invisible",	0x47,	0xffffffff);
	AddConstEx(id,"camouflage",	0x48,	0xffffffff);
	AddConstEx(id,"prot_drag_breath",	0x49,	0xffffffff);
	AddConstEx(id,"affect_4a",	0x4a,	0xffffffff);
	AddConstEx(id,"affect_4b",	0x4b,	0xffffffff);
	AddConstEx(id,"affect_4c",	0x4c,	0xffffffff);
	AddConstEx(id,"berserk",	0x4d,	0xffffffff);
	AddConstEx(id,"affect_4f",	0x4f,	0xffffffff);
	AddConstEx(id,"affect_50",	0x50,	0xffffffff);
	AddConstEx(id,"affect_51",	0x51,	0xffffffff);
	AddConstEx(id,"affect_52",	0x52,	0xffffffff);
	AddConstEx(id,"affect_53",	0x53,	0xffffffff);
	AddConstEx(id,"affect_54",	0x54,	0xffffffff);
	AddConstEx(id,"affect_55",	0x55,	0xffffffff);
	AddConstEx(id,"affect_56",	0x56,	0xffffffff);
	AddConstEx(id,"affect_57",	0x57,	0xffffffff);
	AddConstEx(id,"affect_58",	0x58,	0xffffffff);
	AddConstEx(id,"displace",	0x59,	0xffffffff);
	AddConstEx(id,"affect_5a",	0x5a,	0xffffffff);
	AddConstEx(id,"affect_5b",	0x5b,	0xffffffff);
	AddConstEx(id,"affect_5c",	0x5c,	0xffffffff);
	AddConstEx(id,"affect_5d",	0x5d,	0xffffffff);
	AddConstEx(id,"affect_5e",	0x5e,	0xffffffff);
	AddConstEx(id,"affect_5F",	0x5f,	0xffffffff);
	AddConstEx(id,"affect_60",	0x60,	0xffffffff);
	AddConstEx(id,"affect_61",	0x61,	0xffffffff);
	AddConstEx(id,"affect_62",	0x62,	0xffffffff);
	AddConstEx(id,"affect_63",	0x63,	0xffffffff);
	AddConstEx(id,"affect_64",	0x64,	0xffffffff);
	AddConstEx(id,"affect_65",	0x65,	0xffffffff);
	AddConstEx(id,"affect_66",	0x66,	0xffffffff);
	AddConstEx(id,"affect_67",	0x67,	0xffffffff);
	AddConstEx(id,"affect_68",	0x68,	0xffffffff);
	AddConstEx(id,"affect_69",	0x69,	0xffffffff);
	AddConstEx(id,"affect_6a",	0x6a,	0xffffffff);
	AddConstEx(id,"affect_6b",	0x6b,	0xffffffff);
	AddConstEx(id,"affect_6c",	0x6c,	0xffffffff);
	AddConstEx(id,"affect_6d",	0x6d,	0xffffffff);
	AddConstEx(id,"affect_6e",	0x6e,	0xffffffff);
	AddConstEx(id,"affect_6f",	0x6f,	0xffffffff);
	AddConstEx(id,"affect_70",	0x70,	0xffffffff);
	AddConstEx(id,"affect_71",	0x71,	0xffffffff);
	AddConstEx(id,"affect_72",	0x72,	0xffffffff);
	AddConstEx(id,"affect_73",	0x73,	0xffffffff);
	AddConstEx(id,"affect_74",	0x74,	0xffffffff);
	AddConstEx(id,"affect_75",	0x75,	0xffffffff);
	AddConstEx(id,"affect_76",	0x76,	0xffffffff);
	AddConstEx(id,"affect_77",	0x77,	0xffffffff);
	AddConstEx(id,"affect_78",	0x78,	0xffffffff);
	AddConstEx(id,"affect_79",	0x79,	0xffffffff);
	AddConstEx(id,"affect_7a",	0x7a,	0xffffffff);
	AddConstEx(id,"affect_7b",	0x7b,	0xffffffff);
	AddConstEx(id,"affect_7c",	0x7c,	0xffffffff);
	AddConstEx(id,"affect_7d",	0x7d,	0xffffffff);
	AddConstEx(id,"affect_7e",	0x7e,	0xffffffff);
	AddConstEx(id,"affect_7f",	0x7f,	0xffffffff);
	AddConstEx(id,"affect_80",	0x80,	0xffffffff);
	AddConstEx(id,"affect_81",	0x81,	0xffffffff);
	AddConstEx(id,"affect_82",	0x82,	0xffffffff);
	AddConstEx(id,"affect_83",	0x83,	0xffffffff);
	AddConstEx(id,"affect_84",	0x84,	0xffffffff);
	AddConstEx(id,"affect_85",	0x85,	0xffffffff);
	AddConstEx(id,"affect_86",	0x86,	0xffffffff);
	AddConstEx(id,"affect_87",	0x87,	0xffffffff);
	AddConstEx(id,"affect_88",	0x88,	0xffffffff);
	AddConstEx(id,"affect_89",	0x89,	0xffffffff);
	AddConstEx(id,"affect_8a",	0x8a,	0xffffffff);
	AddConstEx(id,"affect_8b",	0x8b,	0xffffffff);
	AddConstEx(id,"affect_8c",	0x8c,	0xffffffff);
	AddConstEx(id,"affect_8D",	0x8d,	0xffffffff);
	AddConstEx(id,"affect_8e",	0x8e,	0xffffffff);
	AddConstEx(id,"affect_8f",	0x8f,	0xffffffff);
	AddConstEx(id,"affect_90",	0x90,	0xffffffff);
	AddConstEx(id,"affect_91",	0x91,	0xffffffff);
	AddConstEx(id,"affect_92",	0x92,	0xffffffff);
	id = AddEnum(-1,"stat_name",0x2200000);
	AddConstEx(id,"STR",	0x0,	0xffffffff);
	AddConstEx(id,"INT",	0x1,	0xffffffff);
	AddConstEx(id,"WIS",	0x2,	0xffffffff);
	AddConstEx(id,"DEX",	0x3,	0xffffffff);
	AddConstEx(id,"CON",	0x4,	0xffffffff);
	AddConstEx(id,"CHA",	0x5,	0xffffffff);
	id = AddEnum(-1,"spell_id",0x1100000);
	AddConstEx(id,"knock",	0x1f,	0xffffffff);
	id = AddEnum(-1,"spell_location",0x1100000);
	AddConstEx(id,"memory",	0x0,	0xffffffff);
	AddConstEx(id,"grimoire",	0x1,	0xffffffff);
	AddConstEx(id,"scroll",	0x2,	0xffffffff);
	AddConstEx(id,"scrolls",	0x3,	0xffffffff);
	AddConstEx(id,"choose",	0x4,	0xffffffff);
	AddConstEx(id,"memorize",	0x5,	0xffffffff);
	AddConstEx(id,"scribe",	0x6,	0xffffffff);
	id = AddEnum(-1,"skills",0x1100000);
	AddConstEx(id,"cleric_skill",	0x0,	0xffffffff);
	AddConstEx(id,"druid_skill",	0x1,	0xffffffff);
	AddConstEx(id,"fighter_skill",	0x2,	0xffffffff);
	AddConstEx(id,"paladin_skill",	0x3,	0xffffffff);
	AddConstEx(id,"ranger_skill",	0x4,	0xffffffff);
	AddConstEx(id,"magic_user_skill",	0x5,	0xffffffff);
	AddConstEx(id,"thief_skill",	0x6,	0xffffffff);
	AddConstEx(id,"monk_skill",	0x7,	0xffffffff);
	id = AddEnum(-1,"spell_action",0x1100000);
	AddConstEx(id,"cast",	0x1,	0xffffffff);
	AddConstEx(id,"memorize_",	0x2,	0xffffffff);
	AddConstEx(id,"scribe_",	0x3,	0xffffffff);
	id = AddEnum(-1,"struct_sizes",0x1100000);
	AddConstEx(id,"affect_struct_size",	0x9,	0xffffffff);
	AddConstEx(id,"action_struct_size",	0x16,	0xffffffff);
	AddConstEx(id,"item_struct_size",	0x3f,	0xffffffff);
	AddConstEx(id,"char_struct_size",	0x1a6,	0xffffffff);
	AddConstEx(id,"ecl_struct_size",	0x1e00,	0xffffffff);
}

//------------------------------------------------------------------------
// Information about structure types

static Structures(void) {
        auto id;

	id = AddStrucEx(-1,"_stub_descr",0);
	id = AddStrucEx(-1,"time_s",0);
	id = AddStrucEx(-1,"unknown01",0);
	id = AddStrucEx(-1,"stringListEntry",0);
	id = AddStrucEx(-1,"charStruct",0);
	id = AddStrucEx(-1,"pointer",0);
	id = AddStrucEx(-1,"FILE",0);
	id = AddStrucEx(-1,"String",0);
	id = AddStrucEx(-1,"item",0);
	id = AddStrucEx(-1,"actions",0);
	id = AddStrucEx(-1,"effect",0);
	id = AddStrucEx(-1,"struc_151",0);
	id = AddStrucEx(-1,"affect",0);
	id = AddStrucEx(-1,"unknown_array",0);
	id = AddStrucEx(-1,"area",0);
	id = AddStrucEx(-1,"dax_block",0);
	id = AddStrucEx(-1,"Words",0);
	id = AddStrucEx(-1,"area2",0);
	id = AddStrucEx(-1,"player_file",0);
	id = AddStrucEx(-1,"stats_max",0);
	
	id = GetStrucIdByName("_stub_descr");
	AddStrucMember(id,"int_code",	0x0,	0x000400,	-1,	2);
	SetMemberComment(id,	0x0,	"Overlay manager interrupt",	0);
	AddStrucMember(id,"memswap",	0x2,	0x10000400,	-1,	2);
	SetMemberComment(id,	0x2,	"Runtime memory swap address",	0);
	AddStrucMember(id,"fileoff",	0x4,	0x20000400,	-1,	4);
	SetMemberComment(id,	0x4,	"Offset in the file to the Code",	0);
	AddStrucMember(id,"codesize",	0x8,	0x10000400,	-1,	2);
	SetMemberComment(id,	0x8,	"Code size",	0);
	AddStrucMember(id,"relsize",	0xa,	0x10000400,	-1,	2);
	SetMemberComment(id,	0xa,	"Relocation area size",	0);
	AddStrucMember(id,"nentries",	0xc,	0x10000400,	-1,	2);
	SetMemberComment(id,	0xc,	"Number of overlay entries",	0);
	AddStrucMember(id,"prevstub",	0xe,	0x10000400,	-1,	2);
	SetMemberComment(id,	0xe,	"Previous stub",	0);
	AddStrucMember(id,"workarea",	0x10,	0x1000400,	-1,	16);
	
	id = GetStrucIdByName("time_s");
	AddStrucMember(id,"minutes",	0x0,	0x000400,	-1,	1);
	AddStrucMember(id,"hours",	0x1,	0x000400,	-1,	1);
	AddStrucMember(id,"hundredth_sec",	0x2,	0x000400,	-1,	1);
	AddStrucMember(id,"seconds",	0x3,	0x000400,	-1,	1);
	
	id = GetStrucIdByName("unknown01");
	AddStrucMember(id,"field_0",	0x0,	0x10000400,	-1,	2);
	AddStrucMember(id,"field_2",	0x2,	0x10000400,	-1,	2);
	SetMemberComment(id,	0x2,	"is 0xD7B0, 0xD7B1, or 0xD7B2",	1);
	AddStrucMember(id,"field_4",	0x4,	0x10000400,	-1,	2);
	AddStrucMember(id,"field_6",	0x6,	0x10000400,	-1,	2);
	AddStrucMember(id,"field_8",	0x8,	0x10000400,	-1,	2);
	AddStrucMember(id,"field_A",	0xa,	0x10000400,	-1,	2);
	AddStrucMember(id,"field_C",	0xc,	0x10000400,	-1,	2);
	AddStrucMember(id,"field_E",	0xe,	0x10000400,	-1,	2);
	AddStrucMember(id,"fnc_offset",	0x10,	0x10000400,	-1,	2);
	AddStrucMember(id,"fnc_seg",	0x12,	0x10000400,	-1,	2);
	AddStrucMember(id,"field_14",	0x14,	0x10000400,	-1,	2);
	AddStrucMember(id,"field_16",	0x16,	0x10000400,	-1,	2);
	AddStrucMember(id,"field_18",	0x18,	0x10000400,	-1,	2);
	AddStrucMember(id,"field_1A",	0x1a,	0x10000400,	-1,	2);
	AddStrucMember(id,"field_1C",	0x1c,	0x10000400,	-1,	2);
	AddStrucMember(id,"field_1E",	0x1e,	0x10000400,	-1,	2);
	AddStrucMember(id,"field_30",	0x30,	0x10000400,	-1,	2);
	AddStrucMember(id,"field_80",	0x80,	0x10000400,	-1,	2);
	
	id = GetStrucIdByName("stringListEntry");
	AddStrucMember(id,"string",	0x0,	0x000400,	-1,	1);
	AddStrucMember(id,"field_29",	0x29,	0x000400,	-1,	1);
	AddStrucMember(id,"next",	0x2a,	0x60000400,	GetStrucIdByName("pointer"),	4);
	
	id = GetStrucIdByName("charStruct");
	AddStrucMember(id,"name",	0x0,	0x50000400,	0x1,	16);
	AddStrucMember(id,"tmp_str",	0x10,	0x000400,	-1,	1);
	AddStrucMember(id,"strenght",	0x11,	0x000400,	-1,	1);
	AddStrucMember(id,"tmp_int",	0x12,	0x000400,	-1,	1);
	AddStrucMember(id,"int",	0x13,	0x000400,	-1,	1);
	AddStrucMember(id,"tmp_wis",	0x14,	0x000400,	-1,	1);
	AddStrucMember(id,"wis",	0x15,	0x000400,	-1,	1);
	AddStrucMember(id,"tmp_dex",	0x16,	0x000400,	-1,	1);
	AddStrucMember(id,"dex",	0x17,	0x000400,	-1,	1);
	AddStrucMember(id,"tmp_con",	0x18,	0x000400,	-1,	1);
	AddStrucMember(id,"con",	0x19,	0x000400,	-1,	1);
	AddStrucMember(id,"tmp_cha",	0x1a,	0x000400,	-1,	1);
	AddStrucMember(id,"charisma",	0x1b,	0x000400,	-1,	1);
	AddStrucMember(id,"strenght_18_100",	0x1c,	0x000400,	-1,	1);
	AddStrucMember(id,"field_1D",	0x1d,	0x000400,	-1,	1);
	AddStrucMember(id,"spell_list",	0x1e,	0x000400,	-1,	84);
	AddStrucMember(id,"spell_to_learn_count",	0x72,	0x000400,	-1,	1);
	AddStrucMember(id,"field_73",	0x73,	0x000400,	-1,	1);
	AddStrucMember(id,"race",	0x74,	0x000400,	-1,	1);
	AddStrucMember(id,"class",	0x75,	0x000400,	-1,	1);
	AddStrucMember(id,"age",	0x76,	0x000400,	-1,	1);
	AddStrucMember(id,"hit_point_max",	0x78,	0x000400,	-1,	1);
	AddStrucMember(id,"field_82",	0x82,	0x000400,	-1,	1);
	AddStrucMember(id,"field_83",	0x83,	0x000400,	-1,	1);
	AddStrucMember(id,"field_84",	0x84,	0x000400,	-1,	1);
	AddStrucMember(id,"field_87",	0x87,	0x000400,	-1,	1);
	AddStrucMember(id,"field_8A",	0x8a,	0x000400,	-1,	1);
	AddStrucMember(id,"field_8B",	0x8b,	0x000400,	-1,	1);
	AddStrucMember(id,"field_8D",	0x8d,	0x000400,	-1,	1);
	AddStrucMember(id,"field_97",	0x97,	0x000400,	-1,	1);
	AddStrucMember(id,"field_9A",	0x9a,	0x000400,	-1,	1);
	AddStrucMember(id,"field_A7",	0xa7,	0x000400,	-1,	1);
	AddStrucMember(id,"field_DD",	0xdd,	0x000400,	-1,	1);
	AddStrucMember(id,"field_DE",	0xde,	0x000400,	-1,	1);
	AddStrucMember(id,"field_DF",	0xdf,	0x000400,	-1,	1);
	AddStrucMember(id,"field_E0",	0xe0,	0x000400,	-1,	1);
	AddStrucMember(id,"field_E1",	0xe1,	0x000400,	-1,	1);
	AddStrucMember(id,"field_E2",	0xe2,	0x000400,	-1,	1);
	AddStrucMember(id,"field_E3",	0xe3,	0x000400,	-1,	1);
	AddStrucMember(id,"field_E4",	0xe4,	0x000400,	-1,	1);
	AddStrucMember(id,"field_E5",	0xe5,	0x000400,	-1,	1);
	AddStrucMember(id,"field_E6",	0xe6,	0x000400,	-1,	1);
	AddStrucMember(id,"field_E7",	0xe7,	0x000400,	-1,	1);
	AddStrucMember(id,"field_E8",	0xe8,	0x000400,	-1,	1);
	AddStrucMember(id,"field_E9",	0xe9,	0x000400,	-1,	1);
	AddStrucMember(id,"field_EB",	0xeb,	0x000400,	-1,	1);
	AddStrucMember(id,"affect_ptr",	0xf2,	0x60000400,	GetStrucIdByName("pointer"),	4);
	AddStrucMember(id,"field_F7",	0xf7,	0x000400,	-1,	1);
	SetMemberComment(id,	0xf7,	"if 0 or 0xB3 you can pool money",	1);
	AddStrucMember(id,"field_F8",	0xf8,	0x000400,	-1,	1);
	AddStrucMember(id,"field_FA",	0xfa,	0x000400,	-1,	1);
	AddStrucMember(id,"copper",	0xfb,	0x10000400,	-1,	2);
	AddStrucMember(id,"electrum",	0xfd,	0x10000400,	-1,	2);
	AddStrucMember(id,"silver",	0xff,	0x10000400,	-1,	2);
	AddStrucMember(id,"gold",	0x101,	0x10000400,	-1,	2);
	AddStrucMember(id,"platinum",	0x103,	0x10000400,	-1,	2);
	AddStrucMember(id,"field_105",	0x105,	0x10000400,	-1,	2);
	AddStrucMember(id,"field_107",	0x107,	0x10000400,	-1,	2);
	AddStrucMember(id,"cleric_lvl",	0x109,	0x000400,	-1,	1);
	SetMemberComment(id,	0x109,	"normal classes use this as an skill array",	1);
	AddStrucMember(id,"druid_lvl",	0x10a,	0x000400,	-1,	1);
	AddStrucMember(id,"fighter_lvl",	0x10b,	0x000400,	-1,	1);
	AddStrucMember(id,"paladin_lvl",	0x10c,	0x000400,	-1,	1);
	AddStrucMember(id,"ranger_lvl",	0x10d,	0x000400,	-1,	1);
	AddStrucMember(id,"magic_user_lvl",	0x10e,	0x000400,	-1,	1);
	AddStrucMember(id,"thief_lvl",	0x10f,	0x000400,	-1,	1);
	AddStrucMember(id,"monk_lvl",	0x110,	0x000400,	-1,	1);
	AddStrucMember(id,"turn_undead",	0x111,	0x000400,	-1,	1);
	AddStrucMember(id,"field_112",	0x112,	0x000400,	-1,	1);
	AddStrucMember(id,"field_113",	0x113,	0x000400,	-1,	1);
	AddStrucMember(id,"field_114",	0x114,	0x000400,	-1,	1);
	AddStrucMember(id,"field_115",	0x115,	0x000400,	-1,	1);
	AddStrucMember(id,"field_116",	0x116,	0x000400,	-1,	1);
	AddStrucMember(id,"field_117",	0x117,	0x000400,	-1,	1);
	AddStrucMember(id,"field_118",	0x118,	0x000400,	-1,	1);
	AddStrucMember(id,"sex",	0x119,	0x000400,	-1,	1);
	AddStrucMember(id,"field_11A",	0x11a,	0x000400,	-1,	1);
	AddStrucMember(id,"alignment",	0x11b,	0x000400,	-1,	1);
	AddStrucMember(id,"field_11C",	0x11c,	0x000400,	-1,	1);
	AddStrucMember(id,"field_11D",	0x11d,	0x000400,	-1,	1);
	AddStrucMember(id,"field_11E",	0x11e,	0x000400,	-1,	1);
	AddStrucMember(id,"field_120",	0x120,	0x000400,	-1,	1);
	AddStrucMember(id,"field_124",	0x124,	0x000400,	-1,	1);
	AddStrucMember(id,"field_125",	0x125,	0x000400,	-1,	1);
	AddStrucMember(id,"field_126",	0x126,	0x000400,	-1,	1);
	AddStrucMember(id,"exp_lw",	0x127,	0x10000400,	-1,	2);
	AddStrucMember(id,"exp_hw",	0x129,	0x10000400,	-1,	2);
	AddStrucMember(id,"field_12B",	0x12b,	0x000400,	-1,	1);
	AddStrucMember(id,"field_12C",	0x12c,	0x000400,	-1,	1);
	AddStrucMember(id,"field_12D",	0x12d,	0x000400,	-1,	1);
	AddStrucMember(id,"field_130",	0x130,	0x000400,	-1,	1);
	AddStrucMember(id,"field_131",	0x131,	0x000400,	-1,	1);
	AddStrucMember(id,"field_137",	0x137,	0x000400,	-1,	1);
	AddStrucMember(id,"field_13C",	0x13c,	0x10000400,	-1,	2);
	AddStrucMember(id,"field_13E",	0x13e,	0x000400,	-1,	1);
	AddStrucMember(id,"field_13F",	0x13f,	0x000400,	-1,	1);
	AddStrucMember(id,"field_140",	0x140,	0x000400,	-1,	1);
	AddStrucMember(id,"field_141",	0x141,	0x000400,	-1,	1);
	AddStrucMember(id,"field_142",	0x142,	0x000400,	-1,	1);
	AddStrucMember(id,"icon_id",	0x143,	0x000400,	-1,	1);
	AddStrucMember(id,"field_144",	0x144,	0x000400,	-1,	1);
	SetMemberComment(id,	0x144,	"byte[6]",	1);
	AddStrucMember(id,"field_148",	0x148,	0x000400,	-1,	1);
	AddStrucMember(id,"field_14B",	0x14b,	0x000400,	-1,	1);
	AddStrucMember(id,"field_14C",	0x14c,	0x000400,	-1,	1);
	SetMemberComment(id,	0x14c,	"0 no item to use?",	1);
	AddStrucMember(id,"itemsPtr",	0x14d,	0x60000400,	GetStrucIdByName("pointer"),	4);
	AddStrucMember(id,"field_151",	0x151,	0x60000400,	GetStrucIdByName("pointer"),	4);
	AddStrucMember(id,"player_ptr_01",	0x175,	0x60000400,	GetStrucIdByName("pointer"),	4);
	AddStrucMember(id,"player_ptr_02",	0x179,	0x60000400,	GetStrucIdByName("pointer"),	4);
	AddStrucMember(id,"player_ptr_03",	0x17d,	0x60000400,	GetStrucIdByName("pointer"),	4);
	AddStrucMember(id,"player_ptr_04",	0x181,	0x60000400,	GetStrucIdByName("pointer"),	4);
	AddStrucMember(id,"field_185",	0x185,	0x000400,	-1,	1);
	AddStrucMember(id,"field_186",	0x186,	0x000400,	-1,	1);
	AddStrucMember(id,"weight",	0x187,	0x10000400,	-1,	2);
	AddStrucMember(id,"next_player",	0x189,	0x60000400,	GetStrucIdByName("pointer"),	4);
	AddStrucMember(id,"actions",	0x18d,	0x60000400,	GetStrucIdByName("pointer"),	4);
	AddStrucMember(id,"field_191",	0x191,	0x000400,	-1,	1);
	SetMemberComment(id,	0x191,	"paladin skill ??",	1);
	AddStrucMember(id,"field_192",	0x192,	0x000400,	-1,	1);
	AddStrucMember(id,"field_193",	0x193,	0x000400,	-1,	1);
	AddStrucMember(id,"field_194",	0x194,	0x000400,	-1,	1);
	AddStrucMember(id,"health_status",	0x195,	0x000400,	-1,	1);
	AddStrucMember(id,"in_combat",	0x196,	0x000400,	-1,	1);
	AddStrucMember(id,"combat_team",	0x197,	0x000400,	-1,	1);
	SetMemberComment(id,	0x197,	"0 - our team, 1 - enermy",	1);
	AddStrucMember(id,"field_198",	0x198,	0x000400,	-1,	1);
	AddStrucMember(id,"field_199",	0x199,	0x000400,	-1,	1);
	AddStrucMember(id,"field_19A",	0x19a,	0x000400,	-1,	1);
	AddStrucMember(id,"field_19B",	0x19b,	0x000400,	-1,	1);
	AddStrucMember(id,"field_19C",	0x19c,	0x000400,	-1,	1);
	AddStrucMember(id,"field_19D",	0x19d,	0x000400,	-1,	1);
	AddStrucMember(id,"field_19E",	0x19e,	0x000400,	-1,	1);
	AddStrucMember(id,"field_19F",	0x19f,	0x000400,	-1,	1);
	AddStrucMember(id,"field_1A0",	0x1a0,	0x000400,	-1,	1);
	AddStrucMember(id,"field_1A1",	0x1a1,	0x000400,	-1,	1);
	AddStrucMember(id,"field_1A2",	0x1a2,	0x000400,	-1,	1);
	AddStrucMember(id,"field_1A3",	0x1a3,	0x000400,	-1,	1);
	AddStrucMember(id,"hit_point_current",	0x1a4,	0x000400,	-1,	1);
	AddStrucMember(id,"initiative",	0x1a5,	0x000400,	-1,	1);
	
	id = GetStrucIdByName("pointer");
	AddStrucMember(id,"offset",	0x0,	0x10000400,	-1,	2);
	AddStrucMember(id,"seg",	0x2,	0x10000400,	-1,	2);
	
	id = GetStrucIdByName("FILE");
	AddStrucMember(id,"field_0",	0x0,	0x10000400,	-1,	2);
	AddStrucMember(id,"status",	0x2,	0x10000400,	-1,	2);
	SetMemberComment(id,	0x2,	"gets set to 0xD7B0",	1);
	AddStrucMember(id,"field_4",	0x4,	0x000400,	-1,	22);
	AddStrucMember(id,"name",	0x1a,	0x000400,	-1,	80);
	
	id = GetStrucIdByName("String");
	AddStrucMember(id,"length",	0x0,	0x000400,	-1,	1);
	AddStrucMember(id,"string",	0x1,	0x000400,	-1,	255);
	
	id = GetStrucIdByName("item");
	AddStrucMember(id,"field_0",	0x0,	0x20000400,	-1,	4);
	AddStrucMember(id,"field_4",	0x4,	0x20000400,	-1,	4);
	AddStrucMember(id,"field_8",	0x8,	0x20000400,	-1,	4);
	AddStrucMember(id,"field_C",	0xc,	0x20000400,	-1,	4);
	AddStrucMember(id,"field_10",	0x10,	0x20000400,	-1,	4);
	AddStrucMember(id,"field_14",	0x14,	0x20000400,	-1,	4);
	AddStrucMember(id,"field_18",	0x18,	0x20000400,	-1,	4);
	AddStrucMember(id,"field_1C",	0x1c,	0x20000400,	-1,	4);
	AddStrucMember(id,"field_20",	0x20,	0x20000400,	-1,	4);
	AddStrucMember(id,"field_24",	0x24,	0x20000400,	-1,	4);
	AddStrucMember(id,"field_28",	0x28,	0x000400,	-1,	1);
	AddStrucMember(id,"next_item",	0x2a,	0x60000400,	GetStrucIdByName("pointer"),	4);
	AddStrucMember(id,"type",	0x2e,	0x000400,	-1,	1);
	SetMemberComment(id,	0x2e,	"11 - 14 = scroll",	1);
	AddStrucMember(id,"field_2F",	0x2f,	0x000400,	-1,	1);
	AddStrucMember(id,"field_30",	0x30,	0x000400,	-1,	1);
	AddStrucMember(id,"field_31",	0x31,	0x000400,	-1,	1);
	AddStrucMember(id,"exp_value",	0x32,	0x000400,	-1,	1);
	AddStrucMember(id,"field_33",	0x33,	0x000400,	-1,	1);
	AddStrucMember(id,"field_34",	0x34,	0x000400,	-1,	1);
	SetMemberComment(id,	0x34,	"maybe cursed",	1);
	AddStrucMember(id,"field_35",	0x35,	0x000400,	-1,	1);
	AddStrucMember(id,"field_36",	0x36,	0x000400,	-1,	1);
	SetMemberComment(id,	0x36,	"maybe cursed",	1);
	AddStrucMember(id,"weight",	0x37,	0x000400,	-1,	1);
	AddStrucMember(id,"field_38",	0x38,	0x000400,	-1,	1);
	AddStrucMember(id,"count",	0x39,	0x000400,	-1,	1);
	AddStrucMember(id,"value",	0x3a,	0x000400,	-1,	1);
	SetMemberComment(id,	0x3a,	"seams like value is in electrum, as value is doubled.",	1);
	AddStrucMember(id,"field_3B",	0x3b,	0x000400,	-1,	1);
	AddStrucMember(id,"affect_1",	0x3c,	0x000400,	-1,	1);
	AddStrucMember(id,"affect_2",	0x3d,	0x000400,	-1,	1);
	AddStrucMember(id,"affect_3",	0x3e,	0x000400,	-1,	1);
	
	id = GetStrucIdByName("actions");
	AddStrucMember(id,"spell_id",	0x0,	0x000400,	-1,	1);
	AddStrucMember(id,"can_cast",	0x1,	0x000400,	-1,	1);
	AddStrucMember(id,"field_2",	0x2,	0x000400,	-1,	1);
	AddStrucMember(id,"delay",	0x3,	0x000400,	-1,	1);
	AddStrucMember(id,"field_4",	0x4,	0x000400,	-1,	1);
	AddStrucMember(id,"field_5",	0x5,	0x000400,	-1,	1);
	AddStrucMember(id,"move",	0x6,	0x000400,	-1,	1);
	SetMemberComment(id,	0x6,	"maybe how much movment is left",	1);
	AddStrucMember(id,"guarding",	0x7,	0x000400,	-1,	1);
	AddStrucMember(id,"field_8",	0x8,	0x000400,	-1,	1);
	AddStrucMember(id,"field_9",	0x9,	0x000400,	-1,	1);
	AddStrucMember(id,"target",	0xa,	0x60000400,	GetStrucIdByName("pointer"),	4);
	SetMemberComment(id,	0xa,	"target player",	1);
	AddStrucMember(id,"bleeding",	0xe,	0x000400,	-1,	1);
	AddStrucMember(id,"field_F",	0xf,	0x000400,	-1,	1);
	AddStrucMember(id,"field_10",	0x10,	0x000400,	-1,	1);
	AddStrucMember(id,"field_11",	0x11,	0x000400,	-1,	1);
	SetMemberComment(id,	0x11,	"can_turn",	1);
	AddStrucMember(id,"field_12",	0x12,	0x000400,	-1,	1);
	AddStrucMember(id,"field_13",	0x13,	0x000400,	-1,	1);
	AddStrucMember(id,"field_14",	0x14,	0x000400,	-1,	1);
	AddStrucMember(id,"field_15",	0x15,	0x000400,	-1,	1);
	
	id = GetStrucIdByName("effect");
	AddStrucMember(id,"field_0",	0x0,	0x000400,	-1,	1);
	AddStrucMember(id,"field_1",	0x1,	0x000400,	-1,	1);
	AddStrucMember(id,"field_2",	0x2,	0x000400,	-1,	1);
	AddStrucMember(id,"field_3",	0x3,	0x000400,	-1,	1);
	
	id = GetStrucIdByName("struc_151");
	AddStrucMember(id,"field_0",	0x0,	0x000400,	-1,	1);
	AddStrucMember(id,"field_1",	0x1,	0x000400,	-1,	1);
	AddStrucMember(id,"field_2",	0x2,	0x000400,	-1,	1);
	AddStrucMember(id,"field_3",	0x3,	0x000400,	-1,	1);
	AddStrucMember(id,"field_4",	0x4,	0x000400,	-1,	1);
	AddStrucMember(id,"field_5",	0x5,	0x000400,	-1,	1);
	AddStrucMember(id,"field_6",	0x6,	0x000400,	-1,	1);
	AddStrucMember(id,"field_7",	0x7,	0x000400,	-1,	1);
	AddStrucMember(id,"field_8",	0x8,	0x000400,	-1,	1);
	AddStrucMember(id,"field_9",	0x9,	0x000400,	-1,	1);
	AddStrucMember(id,"field_A",	0xa,	0x000400,	-1,	1);
	AddStrucMember(id,"field_B",	0xb,	0x000400,	-1,	1);
	AddStrucMember(id,"field_C",	0xc,	0x000400,	-1,	1);
	AddStrucMember(id,"field_D",	0xd,	0x000400,	-1,	1);
	AddStrucMember(id,"field_E",	0xe,	0x000400,	-1,	1);
	AddStrucMember(id,"field_F",	0xf,	0x000400,	-1,	1);
	AddStrucMember(id,"field_10",	0x10,	0x000400,	-1,	1);
	AddStrucMember(id,"field_11",	0x11,	0x000400,	-1,	1);
	AddStrucMember(id,"field_12",	0x12,	0x000400,	-1,	1);
	AddStrucMember(id,"field_13",	0x13,	0x000400,	-1,	1);
	AddStrucMember(id,"field_14",	0x14,	0x000400,	-1,	1);
	AddStrucMember(id,"field_15",	0x15,	0x000400,	-1,	1);
	AddStrucMember(id,"field_16",	0x16,	0x10000400,	-1,	2);
	AddStrucMember(id,"field_18",	0x18,	0x000400,	-1,	1);
	AddStrucMember(id,"field_19",	0x19,	0x000400,	-1,	1);
	AddStrucMember(id,"field_1A",	0x1a,	0x000400,	-1,	1);
	AddStrucMember(id,"field_1B",	0x1b,	0x000400,	-1,	1);
	AddStrucMember(id,"field_1C",	0x1c,	0x000400,	-1,	1);
	AddStrucMember(id,"field_1D",	0x1d,	0x000400,	-1,	1);
	AddStrucMember(id,"field_1E",	0x1e,	0x000400,	-1,	1);
	AddStrucMember(id,"field_1F",	0x1f,	0x000400,	-1,	1);
	AddStrucMember(id,"field_20",	0x20,	0x000400,	-1,	1);
	AddStrucMember(id,"field_21",	0x21,	0x000400,	-1,	1);
	AddStrucMember(id,"field_22",	0x22,	0x000400,	-1,	1);
	AddStrucMember(id,"field_23",	0x23,	0x000400,	-1,	1);
	AddStrucMember(id,"field_24",	0x24,	0x000400,	-1,	1);
	AddStrucMember(id,"field_25",	0x25,	0x000400,	-1,	1);
	AddStrucMember(id,"field_26",	0x26,	0x000400,	-1,	1);
	AddStrucMember(id,"field_27",	0x27,	0x000400,	-1,	1);
	AddStrucMember(id,"field_28",	0x28,	0x000400,	-1,	1);
	AddStrucMember(id,"field_29",	0x29,	0x000400,	-1,	1);
	AddStrucMember(id,"field_2A",	0x2a,	0x000400,	-1,	1);
	AddStrucMember(id,"field_2B",	0x2b,	0x000400,	-1,	1);
	AddStrucMember(id,"field_2C",	0x2c,	0x000400,	-1,	1);
	AddStrucMember(id,"field_2D",	0x2d,	0x000400,	-1,	1);
	AddStrucMember(id,"field_2E",	0x2e,	0x000400,	-1,	1);
	AddStrucMember(id,"field_2F",	0x2f,	0x000400,	-1,	1);
	AddStrucMember(id,"field_30",	0x30,	0x000400,	-1,	1);
	AddStrucMember(id,"field_31",	0x31,	0x000400,	-1,	1);
	
	id = GetStrucIdByName("affect");
	AddStrucMember(id,"type",	0x0,	0x000400,	-1,	1);
	AddStrucMember(id,"field_1",	0x1,	0x10000400,	-1,	2);
	AddStrucMember(id,"field_3",	0x3,	0x000400,	-1,	1);
	AddStrucMember(id,"field_4",	0x4,	0x000400,	-1,	1);
	AddStrucMember(id,"next",	0x5,	0x60000400,	GetStrucIdByName("pointer"),	4);
	
	id = GetStrucIdByName("unknown_array");
	AddStrucMember(id,"field_0",	0x0,	0x000400,	-1,	1);
	AddStrucMember(id,"field_1",	0x1,	0x000400,	-1,	1);
	AddStrucMember(id,"field_2",	0x2,	0x000400,	-1,	1);
	AddStrucMember(id,"field_3",	0x3,	0x000400,	-1,	1);
	
	id = GetStrucIdByName("area");
	AddStrucMember(id,"field_186",	0x186,	0x000400,	-1,	1);
	AddStrucMember(id,"field_188",	0x188,	0x000400,	-1,	1);
	AddStrucMember(id,"field_18A",	0x18a,	0x10000400,	-1,	2);
	AddStrucMember(id,"field_1C0",	0x1c0,	0x000400,	-1,	1);
	AddStrucMember(id,"field_1C1",	0x1c1,	0x000400,	-1,	1);
	AddStrucMember(id,"field_1C2",	0x1c2,	0x000400,	-1,	1);
	AddStrucMember(id,"field_1C3",	0x1c3,	0x000400,	-1,	1);
	AddStrucMember(id,"field_1C4",	0x1c4,	0x000400,	-1,	1);
	AddStrucMember(id,"field_1C5",	0x1c5,	0x000400,	-1,	1);
	AddStrucMember(id,"field_1C6",	0x1c6,	0x000400,	-1,	1);
	AddStrucMember(id,"field_1C7",	0x1c7,	0x000400,	-1,	1);
	AddStrucMember(id,"field_1C8",	0x1c8,	0x000400,	-1,	1);
	AddStrucMember(id,"field_1C9",	0x1c9,	0x000400,	-1,	1);
	AddStrucMember(id,"can_cast_spells",	0x1ca,	0x000400,	-1,	1);
	AddStrucMember(id,"field_1CB",	0x1cb,	0x000400,	-1,	1);
	AddStrucMember(id,"field_1CC",	0x1cc,	0x10000400,	-1,	2);
	AddStrucMember(id,"field_1CE",	0x1ce,	0x10000400,	-1,	2);
	AddStrucMember(id,"field_1D0",	0x1d0,	0x10000400,	-1,	2);
	AddStrucMember(id,"field_1D2",	0x1d2,	0x000400,	-1,	1);
	AddStrucMember(id,"field_1D3",	0x1d3,	0x000400,	-1,	1);
	AddStrucMember(id,"field_1D4",	0x1d4,	0x000400,	-1,	1);
	AddStrucMember(id,"field_1D5",	0x1d5,	0x000400,	-1,	1);
	AddStrucMember(id,"field_1D6",	0x1d6,	0x000400,	-1,	1);
	AddStrucMember(id,"field_1D7",	0x1d7,	0x000400,	-1,	1);
	AddStrucMember(id,"field_1D8",	0x1d8,	0x000400,	-1,	1);
	AddStrucMember(id,"field_1D9",	0x1d9,	0x000400,	-1,	1);
	AddStrucMember(id,"field_1DA",	0x1da,	0x000400,	-1,	1);
	AddStrucMember(id,"field_1DB",	0x1db,	0x000400,	-1,	1);
	AddStrucMember(id,"field_1DC",	0x1dc,	0x000400,	-1,	1);
	AddStrucMember(id,"field_1DD",	0x1dd,	0x000400,	-1,	1);
	AddStrucMember(id,"field_1DE",	0x1de,	0x000400,	-1,	1);
	AddStrucMember(id,"field_1DF",	0x1df,	0x000400,	-1,	1);
	AddStrucMember(id,"field_1E0",	0x1e0,	0x10000400,	-1,	2);
	AddStrucMember(id,"field_1E2",	0x1e2,	0x000400,	-1,	1);
	AddStrucMember(id,"field_1E3",	0x1e3,	0x000400,	-1,	1);
	AddStrucMember(id,"field_1E4",	0x1e4,	0x10000400,	-1,	2);
	AddStrucMember(id,"field_1F6",	0x1f6,	0x10000400,	-1,	2);
	AddStrucMember(id,"game_speed",	0x1f8,	0x10000400,	-1,	2);
	AddStrucMember(id,"pics_on",	0x1fe,	0x10000400,	-1,	2);
	AddStrucMember(id,"field_200",	0x200,	0x10000400,	-1,	64);
	SetMemberComment(id,	0x200,	"Word[32]",	1);
	AddStrucMember(id,"field_342",	0x342,	0x000400,	-1,	1);
	AddStrucMember(id,"field_3FA",	0x3fa,	0x10000400,	-1,	2);
	AddStrucMember(id,"field_3FE",	0x3fe,	0x10000400,	-1,	2);
	AddStrucMember(id,"field_43E",	0x43e,	0x000400,	-1,	1);
	
	id = GetStrucIdByName("dax_block");
	AddStrucMember(id,"height",	0x0,	0x10000400,	-1,	2);
	AddStrucMember(id,"width",	0x2,	0x10000400,	-1,	2);
	AddStrucMember(id,"field_4",	0x4,	0x10000400,	-1,	2);
	AddStrucMember(id,"field_6",	0x6,	0x10000400,	-1,	2);
	AddStrucMember(id,"item_count",	0x8,	0x000400,	-1,	1);
	AddStrucMember(id,"field_9",	0x9,	0x000400,	-1,	8);
	AddStrucMember(id,"bpp",	0x11,	0x10000400,	-1,	2);
	SetMemberComment(id,	0x11,	"bits per pixel",	1);
	AddStrucMember(id,"data_ptr",	0x13,	0x60000400,	GetStrucIdByName("pointer"),	4);
	
	id = GetStrucIdByName("Words");
	AddStrucMember(id,"low",	0x0,	0x10000400,	-1,	2);
	AddStrucMember(id,"high",	0x2,	0x10000400,	-1,	2);
	
	id = GetStrucIdByName("area2");
	AddStrucMember(id,"field_550",	0x550,	0x10000400,	-1,	2);
	AddStrucMember(id,"field_580",	0x580,	0x10000400,	-1,	2);
	AddStrucMember(id,"field_582",	0x582,	0x10000400,	-1,	2);
	AddStrucMember(id,"field_58C",	0x58c,	0x10000400,	-1,	2);
	AddStrucMember(id,"field_58E",	0x58e,	0x10000400,	-1,	2);
	SetMemberComment(id,	0x58e,	"0x0080 is battle lost",	1);
	AddStrucMember(id,"field_590",	0x590,	0x10000400,	-1,	2);
	AddStrucMember(id,"field_592",	0x592,	0x10000400,	-1,	2);
	AddStrucMember(id,"field_594",	0x594,	0x10000400,	-1,	2);
	AddStrucMember(id,"field_596",	0x596,	0x10000400,	-1,	2);
	AddStrucMember(id,"field_5A4",	0x5a4,	0x10000400,	-1,	2);
	AddStrucMember(id,"field_5A6",	0x5a6,	0x10000400,	-1,	2);
	AddStrucMember(id,"field_5AA",	0x5aa,	0x10000400,	-1,	2);
	AddStrucMember(id,"field_5C2",	0x5c2,	0x10000400,	-1,	2);
	AddStrucMember(id,"field_5C4",	0x5c4,	0x10000400,	-1,	2);
	AddStrucMember(id,"field_5C6",	0x5c6,	0x10000400,	-1,	2);
	AddStrucMember(id,"field_5CC",	0x5cc,	0x10000400,	-1,	2);
	AddStrucMember(id,"game_area",	0x624,	0x000400,	-1,	1);
	AddStrucMember(id,"field_666",	0x666,	0x10000400,	-1,	2);
	AddStrucMember(id,"field_67C",	0x67c,	0x000400,	-1,	1);
	AddStrucMember(id,"field_67E",	0x67e,	0x10000400,	-1,	2);
	AddStrucMember(id,"field_6D8",	0x6d8,	0x10000400,	-1,	2);
	AddStrucMember(id,"field_6DA",	0x6da,	0x10000400,	-1,	2);
	AddStrucMember(id,"field_6E0",	0x6e0,	0x10000400,	-1,	2);
	AddStrucMember(id,"field_6E2",	0x6e2,	0x10000400,	-1,	2);
	AddStrucMember(id,"field_6E4",	0x6e4,	0x10000400,	-1,	2);
	AddStrucMember(id,"field_6F2",	0x6f2,	0x10000400,	-1,	18);
	SetMemberComment(id,	0x6f2,	"Word[9]",	1);
	AddStrucMember(id,"field_799",	0x799,	0x000400,	-1,	1);
	AddStrucMember(id,"field_79A",	0x79a,	0x000400,	-1,	1);
	AddStrucMember(id,"field_79B",	0x79b,	0x000400,	-1,	1);
	AddStrucMember(id,"field_79C",	0x79c,	0x000400,	-1,	1);
	AddStrucMember(id,"field_79D",	0x79d,	0x000400,	-1,	1);
	AddStrucMember(id,"field_79E",	0x79e,	0x000400,	-1,	1);
	AddStrucMember(id,"field_79F",	0x79f,	0x000400,	-1,	1);
	AddStrucMember(id,"field_7A0",	0x7a0,	0x000400,	-1,	1);
	AddStrucMember(id,"field_7A1",	0x7a1,	0x000400,	-1,	1);
	AddStrucMember(id,"field_7A2",	0x7a2,	0x000400,	-1,	1);
	AddStrucMember(id,"field_7A3",	0x7a3,	0x000400,	-1,	1);
	AddStrucMember(id,"field_7A4",	0x7a4,	0x000400,	-1,	1);
	AddStrucMember(id,"field_7A5",	0x7a5,	0x000400,	-1,	1);
	AddStrucMember(id,"field_7A6",	0x7a6,	0x000400,	-1,	1);
	AddStrucMember(id,"field_7A7",	0x7a7,	0x000400,	-1,	1);
	AddStrucMember(id,"field_7A8",	0x7a8,	0x000400,	-1,	1);
	AddStrucMember(id,"field_7A9",	0x7a9,	0x000400,	-1,	1);
	AddStrucMember(id,"field_7AA",	0x7aa,	0x000400,	-1,	1);
	AddStrucMember(id,"field_7AB",	0x7ab,	0x000400,	-1,	1);
	
	id = GetStrucIdByName("player_file");
	AddStrucMember(id,"name",	0x0,	0x50000400,	0x1,	16);
	AddStrucMember(id,"strength",	0x10,	0x400400,	-1,	1);
	AddStrucMember(id,"race",	0x2e,	0x000400,	-1,	1);
	AddStrucMember(id,"sex",	0x9e,	0x000400,	-1,	1);
	AddStrucMember(id,"field_1",	0x11c,	0x000400,	-1,	1);
	
	id = GetStrucIdByName("stats_max");
	AddStrucMember(id,"field_0",	0x0,	0x000400,	-1,	1);
	AddStrucMember(id,"str",	0x2,	0x000400,	-1,	1);
	AddStrucMember(id,"str_100",	0x3,	0x400400,	-1,	1);
	AddStrucMember(id,"field_1",	0xf,	0x000400,	-1,	1);
}

// End of file.