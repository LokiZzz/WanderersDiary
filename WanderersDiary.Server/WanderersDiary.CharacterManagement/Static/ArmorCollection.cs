using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WanderersDiary.CharacterManagement.Models;
using WanderersDiary.CharacterManagement.Models.Enums;
using WanderersDiary.CharacterManagement.Models.Utility;

namespace WanderersDiary.CharacterManagement.Static
{
    public class ArmorCollection : StaticCollectionBase<ArmorCollection, Armor>
    {
        public static Armor Padded = new Armor
        {
            Name = new LocalizedString { EN = "Padded armor", RU = "Стёганная броня" }, Category = EArmorType.Light,
            Price = 5,
            BaseAC = 11, HaveDexterityModifier = true, MaxDexterityBonus = null, 
            StrenghtRequirement = null,
            HaveStealthDisadvantage = true, 
            Weight = 8, 
        };

        public static Armor Leather = new Armor
        {
            Name = new LocalizedString { EN = "Leather armor", RU = "Кожаная броня" }, Category = EArmorType.Light,
            Price = 10,
            BaseAC = 11, HaveDexterityModifier = true, MaxDexterityBonus = null, 
            StrenghtRequirement = null,
            HaveStealthDisadvantage = false, 
            Weight = 10, 
        };

        public static Armor StuddedLeather = new Armor
        {
            Name = new LocalizedString { EN = "Studded leather armor", RU = "Клёпанная кожаная броня" }, Category = EArmorType.Light,
            Price = 45,
            BaseAC = 12, HaveDexterityModifier = true, MaxDexterityBonus = null, 
            StrenghtRequirement = null,
            HaveStealthDisadvantage = false, 
            Weight = 13, 
        };

        public static Armor Hide = new Armor
        {
            Name = new LocalizedString { EN = "Hide armor", RU = "Броня из шкур" }, Category = EArmorType.Medium,
            Price = 10,
            BaseAC = 12, HaveDexterityModifier = true, MaxDexterityBonus = 2,
            StrenghtRequirement = null,
            HaveStealthDisadvantage = false,
            Weight = 12,
        };

        public static Armor ChainShirt = new Armor
        {
            Name = new LocalizedString { EN = "Chain shirt", RU = "Кольчужная рубаха" }, Category = EArmorType.Medium,
            Price = 50,
            BaseAC = 13, HaveDexterityModifier = true, MaxDexterityBonus = 2,
            StrenghtRequirement = null,
            HaveStealthDisadvantage = false,
            Weight = 20,
        };

        public static Armor ScaleMail = new Armor
        {
            Name = new LocalizedString { EN = "Chain shirt", RU = "Чешуйчатая броня" }, Category = EArmorType.Medium,
            Price = 50,
            BaseAC = 14, HaveDexterityModifier = true, MaxDexterityBonus = 2,
            StrenghtRequirement = null,
            HaveStealthDisadvantage = true,
            Weight = 45,
        };

        public static Armor Breastplate = new Armor
        {
            Name = new LocalizedString { EN = "Breastplate", RU = "Кираса" }, Category = EArmorType.Medium,
            Price = 400,
            BaseAC = 14, HaveDexterityModifier = true, MaxDexterityBonus = 2,
            StrenghtRequirement = null,
            HaveStealthDisadvantage = false,
            Weight = 20,
        };

        public static Armor HalfPlate = new Armor
        {
            Name = new LocalizedString { EN = "Half plate", RU = "Полулаты" }, Category = EArmorType.Medium,
            Price = 750,
            BaseAC = 15, HaveDexterityModifier = true, MaxDexterityBonus = 2,
            StrenghtRequirement = null,
            HaveStealthDisadvantage = true,
            Weight = 40,
        };

        public static Armor RingMail = new Armor
        {
            Name = new LocalizedString { EN = "Ring mail", RU = "Колечная броня" }, Category = EArmorType.Heavy,
            Price = 30,
            BaseAC = 14, HaveDexterityModifier = false, MaxDexterityBonus = null,
            StrenghtRequirement = null,
            HaveStealthDisadvantage = true,
            Weight = 40,
        };

        public static Armor ChainMail = new Armor
        {
            Name = new LocalizedString { EN = "Chain mail", RU = "Кольчуга" }, Category = EArmorType.Heavy,
            Price = 75,
            BaseAC = 16, HaveDexterityModifier = false, MaxDexterityBonus = null,
            StrenghtRequirement = 13,
            HaveStealthDisadvantage = true,
            Weight = 55,
        };

        public static Armor Splint = new Armor
        {
            Name = new LocalizedString { EN = "Splint armor", RU = "Наборная броня" }, Category = EArmorType.Heavy,
            Price = 200,
            BaseAC = 17, HaveDexterityModifier = false, MaxDexterityBonus = null,
            StrenghtRequirement = 15,
            HaveStealthDisadvantage = true,
            Weight = 60,
        };

        public static Armor Plate = new Armor
        {
            Name = new LocalizedString { EN = "Plate armor", RU = "Латы" }, Category = EArmorType.Heavy,
            Price = 1500,
            BaseAC = 18, HaveDexterityModifier = false, MaxDexterityBonus = null,
            StrenghtRequirement = 15,
            HaveStealthDisadvantage = true,
            Weight = 65,
        };

        public static Armor Shield = new Armor
        {
            Name = new LocalizedString { EN = "Shield", RU = "Щит" }, Category = EArmorType.Shield,
            Price = 10,
            BaseAC = 2, HaveDexterityModifier = false, MaxDexterityBonus = null,
            StrenghtRequirement = 0,
            HaveStealthDisadvantage = false,
            Weight = 6,
        };       
    }
}
