using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApocalypticWorld.Classes
{
    public enum LivingThingsType
    {
        Hero, 
        Enemy
    }

    static class Helper
    {
        //M: Message
        public static readonly string M_START_EXPLORING = "If you want to start exploring, type 'start', or enter additional informations.";
        public static readonly string M_RESET_ALL_HEALTHS = "r_all_healths to reset all living things health";
        public static readonly string M_SHORTCUTS = $"type {C_L_RESET_ALL_HEALTHS} to reset Hero's and the Enemies' healths \n" +
            $"type {C_L_CLEAR_CONSOLE} to clear console \n" +
            $"type {C_L_RESET} to start all over \n" +
            $"type {C_L_HELP} to trigger this message";

        //EM: Error Message
        public static readonly string EM_INT_FORMAT_EXCEPTION = "You have entered none numeric characters! Please try again.";
        public static readonly string EM_INDEX_OUT_OF_RANGE_EXCEPTION = "You have not entered essential values! Please try again.";
        public static readonly string EM_ENEMY_NOT_FOUND = "You have not entered wrong enemy name! Please try again.";
        public static readonly string EM_MISSING_VALUES = "You have not entered essential values! Please try again.";
        public static readonly string EM_NO_OPERATION = "No operation has done! Please check the entries you entered.";

        //C: Checker, L: Lowercase
        public static readonly string C_L_RESOURCES = "resources";
        public static readonly string C_L_METERS = "meters";
        public static readonly string C_L_AWAY = "away";
        public static readonly string C_L_HEALTH = "hp";
        public static readonly string C_L_ATTACK = "attack";
        public static readonly string C_L_HERO = "hero";
        public static readonly string C_L_ENEMY = "enemy";
        public static readonly string C_L_POSITION = "position";
        public static readonly string C_L_THERE = "there";
        public static readonly string C_L_IS = "is";
        public static readonly string C_L_ARE = "are";
        public static readonly string C_L_START = "start";
        public static readonly string C_L_RESET_ALL_HEALTHS = "reset_all_healths";
        public static readonly string C_L_CLEAR_CONSOLE = "clear_console";
        public static readonly string C_L_RESET = "reset";
        public static readonly string C_L_HELP = "help";

        public static readonly string C_HERO = "Hero";

        //SO: Split Operator
        public static readonly char SO_INPUTS = ' ';

        //I: Index
        public static readonly int I_HERO_RESOURCES_TEXT = 0;
        public static readonly int I_HERO_RESOURCES_VALUE = 2;
        public static readonly int I_HERO_HEALTH_TEXT = 3;
        public static readonly int I_HERO_HEALTH_VALUE = 2;
        public static readonly int I_HERO_ATTACK_POWER_TEXT = 1;
        public static readonly int I_HERO_ATTACK_POWER_VALUE = 3;
        public static readonly int I_HERO_NAME_VALUE = 0;
        public static readonly int I_HERO_NAME_POSITION_TEXT_ODD = 5;
        public static readonly int I_HERO_NAME_POSITION_TEXT_EVEN = 4;
        public static readonly int I_HERO_NAME_POSITION_VALUE_ODD = 6;
        public static readonly int I_HERO_NAME_POSITION_VALUE_EVEN = 5;
        public static readonly int I_ENEMY_NAME_VALUE_ODD = 3;
        public static readonly int I_ENEMY_NAME_VALUE_EVEN = 2;

        public static void EnemyNotFoundException()
        {
            Console.WriteLine(Helper.EM_ENEMY_NOT_FOUND);
        }

        public static void IntFormatException()
        {
            Console.WriteLine(Helper.EM_INT_FORMAT_EXCEPTION);
        }
    }
}
