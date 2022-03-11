using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WanderersDiary.CharacterManagement.Models;
using WanderersDiary.CharacterManagement.Models.Enums;
using WanderersDiary.CharacterManagement.Models.Game;
using WanderersDiary.CharacterManagement.Models.Utility;

namespace WanderersDiary.CharacterManagement.Static
{
    public class WeaponCollection : StaticCollectionBase<WeaponCollection,Weapon>
    {
        public static Weapon Club = new Weapon
        {
            Name = new LocalizedString { EN = "Club", RU = "Дубинка" },
            Price = 0.1m,
            Damage = new List<Damage> { new Damage { DiceCount = 1, DiceType = EDice.D4, Type = EDamageType.Bludgeoning } },
            Weight = 2,
            Properties = new List<EWeaponProperty> { EWeaponProperty.Light },
            Categories = new List<EWeaponType> { EWeaponType.Simple, EWeaponType.Melee },
        };

        public static Weapon Dagger = new Weapon
        {
            Name = new LocalizedString { EN = "Dagger", RU = "Кинжал" },
            Price = 2,
            Damage = new List<Damage> { new Damage { DiceCount = 1, DiceType = EDice.D4, Type = EDamageType.Piercing } },
            Weight = 1,
            Properties = new List<EWeaponProperty> { EWeaponProperty.Light, EWeaponProperty.Finesse, EWeaponProperty.Thrown },
            Categories = new List<EWeaponType> { EWeaponType.Simple, EWeaponType.Melee },
            Range = new Range { WODis = 20, Max = 60 }
        };

        public static Weapon Greatclub = new Weapon
        {
            Name = new LocalizedString { EN = "Greatclub", RU = "Палица" },
            Price = 0.2m,
            Damage = new List<Damage> { new Damage { DiceCount = 1, DiceType = EDice.D8, Type = EDamageType.Bludgeoning } },
            Weight = 10,
            Properties = new List<EWeaponProperty> { EWeaponProperty.TwoHanded },
            Categories = new List<EWeaponType> { EWeaponType.Simple, EWeaponType.Melee },
        };

        public static Weapon Handaxe = new Weapon
        {
            Name = new LocalizedString { EN = "Handaxe", RU = "Ручной топор" },
            Price = 5,
            Damage = new List<Damage> { new Damage { DiceCount = 1, DiceType = EDice.D6, Type = EDamageType.Slashing } },
            Weight = 2,
            Properties = new List<EWeaponProperty> { EWeaponProperty.Light, EWeaponProperty.Thrown },
            Categories = new List<EWeaponType> { EWeaponType.Simple, EWeaponType.Melee },
            Range = new Range { WODis = 20, Max = 60 }
        };

        public static Weapon Javelin = new Weapon
        {
            Name = new LocalizedString { EN = "Javelin", RU = "Метательное копьё" },
            Price = 0.5m,
            Damage = new List<Damage> { new Damage { DiceCount = 1, DiceType = EDice.D6, Type = EDamageType.Piercing } },
            Weight = 2,
            Properties = new List<EWeaponProperty> { EWeaponProperty.Thrown },
            Categories = new List<EWeaponType> { EWeaponType.Simple, EWeaponType.Melee },
            Range = new Range { WODis = 30, Max = 120 }
        };

        public static Weapon LightHammer = new Weapon
        {
            Name = new LocalizedString { EN = "Light hammer", RU = "Лёгкий молот" },
            Price = 2,
            Damage = new List<Damage> { new Damage { DiceCount = 1, DiceType = EDice.D4, Type = EDamageType.Bludgeoning } },
            Weight = 2,
            Properties = new List<EWeaponProperty> { EWeaponProperty.Light, EWeaponProperty.Thrown },
            Categories = new List<EWeaponType> { EWeaponType.Simple, EWeaponType.Melee },
            Range = new Range { WODis = 20, Max = 60 }
        };

        public static Weapon Mace = new Weapon
        {
            Name = new LocalizedString { EN = "Mace", RU = "Булава" },
            Price = 5,
            Damage = new List<Damage> { new Damage { DiceCount = 1, DiceType = EDice.D6, Type = EDamageType.Bludgeoning } },
            Weight = 4,
            Properties = new List<EWeaponProperty>(),
            Categories = new List<EWeaponType> { EWeaponType.Simple, EWeaponType.Melee },
            Range = new Range { WODis = 20, Max = 60 }
        };

        public static Weapon Quarterstaff = new Weapon
        {
            Name = new LocalizedString { EN = "Quarterstaff", RU = "Боевой посох" },
            Price = 0.2m,
            Damage = new List<Damage> { new Damage { DiceCount = 1, DiceType = EDice.D6, Type = EDamageType.Bludgeoning } },
            Versatile = new List<Damage> { new Damage { DiceCount = 1, DiceType = EDice.D8, Type = EDamageType.Bludgeoning } },
            Weight = 4,
            Properties = new List<EWeaponProperty>(),
            Categories = new List<EWeaponType> { EWeaponType.Simple, EWeaponType.Melee },
        };

        public static Weapon Sickle = new Weapon
        {
            Name = new LocalizedString { EN = "Sickle", RU = "Серп" },
            Price = 1,
            Damage = new List<Damage> { new Damage { DiceCount = 1, DiceType = EDice.D4, Type = EDamageType.Slashing } },
            Weight = 2,
            Properties = new List<EWeaponProperty> { EWeaponProperty.Light },
            Categories = new List<EWeaponType> { EWeaponType.Simple, EWeaponType.Melee },
        };

        public static Weapon Spear = new Weapon
        {
            Name = new LocalizedString { EN = "Spear", RU = "Копьё" },
            Price = 1,
            Damage = new List<Damage> { new Damage { DiceCount = 1, DiceType = EDice.D6, Type = EDamageType.Piercing } },
            Versatile = new List<Damage> { new Damage { DiceCount = 1, DiceType = EDice.D8, Type = EDamageType.Piercing } },
            Weight = 3,
            Properties = new List<EWeaponProperty> { EWeaponProperty.Thrown },
            Categories = new List<EWeaponType> { EWeaponType.Simple, EWeaponType.Melee },
            Range = new Range { WODis = 20, Max = 60 }
        };

        public static Weapon CrossbowLight = new Weapon
        {
            Name = new LocalizedString { EN = "Crossbow, light", RU = "Арбалет, лёгкий" },
            Price = 25,
            Damage = new List<Damage> { new Damage { DiceCount = 1, DiceType = EDice.D8, Type = EDamageType.Piercing } },
            Weight = 5,
            Properties = new List<EWeaponProperty> { EWeaponProperty.Ammunition, EWeaponProperty.Loading, EWeaponProperty.TwoHanded },
            Categories = new List<EWeaponType> { EWeaponType.Simple, EWeaponType.Ranged },
            Range = new Range { WODis = 80, Max = 320 }
        };

        public static Weapon Dart = new Weapon
        {
            Name = new LocalizedString { EN = "Dart", RU = "Дротик" },
            Price = 0.05m,
            Damage = new List<Damage> { new Damage { DiceCount = 1, DiceType = EDice.D4, Type = EDamageType.Piercing } },
            Weight = 0.25m,
            Properties = new List<EWeaponProperty> { EWeaponProperty.Finesse, EWeaponProperty.Thrown },
            Categories = new List<EWeaponType> { EWeaponType.Simple, EWeaponType.Ranged },
            Range = new Range { WODis = 20, Max = 60 }
        };

        public static Weapon ShortBow = new Weapon
        {
            Name = new LocalizedString { EN = "Shortbow", RU = "Короткий лук" },
            Price = 25,
            Damage = new List<Damage> { new Damage { DiceCount = 1, DiceType = EDice.D6, Type = EDamageType.Piercing } },
            Weight = 2,
            Properties = new List<EWeaponProperty> { EWeaponProperty.Ammunition, EWeaponProperty.TwoHanded },
            Categories = new List<EWeaponType> { EWeaponType.Simple, EWeaponType.Ranged },
            Range = new Range { WODis = 80, Max = 320 }
        };

        public static Weapon Sling = new Weapon
        {
            Name = new LocalizedString { EN = "Sling", RU = "Праща" },
            Price = 0.1m,
            Damage = new List<Damage> { new Damage { DiceCount = 1, DiceType = EDice.D4, Type = EDamageType.Bludgeoning } },
            Weight = null,
            Properties = new List<EWeaponProperty> { EWeaponProperty.Ammunition },
            Categories = new List<EWeaponType> { EWeaponType.Simple, EWeaponType.Ranged },
            Range = new Range { WODis = 30, Max = 120 }
        };

        public static Weapon Battleaxe = new Weapon
        {
            Name = new LocalizedString { EN = "Battleaxe", RU = "Боевой топор" },
            Price = 10,
            Damage = new List<Damage> { new Damage { DiceCount = 1, DiceType = EDice.D8, Type = EDamageType.Slashing } },
            Versatile = new List<Damage> { new Damage { DiceCount = 1, DiceType = EDice.D10, Type = EDamageType.Slashing } },
            Weight = 4,
            Properties = new List<EWeaponProperty>(),
            Categories = new List<EWeaponType> { EWeaponType.Martial, EWeaponType.Melee },
        };

        public static Weapon Flail = new Weapon
        {
            Name = new LocalizedString { EN = "Flail", RU = "Цеп" },
            Price = 10,
            Damage = new List<Damage> { new Damage { DiceCount = 1, DiceType = EDice.D8, Type = EDamageType.Bludgeoning } },
            Weight = 2,
            Properties = new List<EWeaponProperty>(),
            Categories = new List<EWeaponType> { EWeaponType.Martial, EWeaponType.Melee },
        };

        public static Weapon Glaive = new Weapon
        {
            Name = new LocalizedString { EN = "Glaive", RU = "Глефа" },
            Price = 20,
            Damage = new List<Damage> { new Damage { DiceCount = 1, DiceType = EDice.D10, Type = EDamageType.Slashing } },
            Weight = 6,
            Properties = new List<EWeaponProperty> { EWeaponProperty.Heavy, EWeaponProperty.Reach, EWeaponProperty.TwoHanded },
            Categories = new List<EWeaponType> { EWeaponType.Martial, EWeaponType.Melee },
        };

        public static Weapon Greataxe = new Weapon
        {
            Name = new LocalizedString { EN = "Greataxe", RU = "Секира" },
            Price = 30,
            Damage = new List<Damage> { new Damage { DiceCount = 1, DiceType = EDice.D12, Type = EDamageType.Slashing } },
            Weight = 7,
            Properties = new List<EWeaponProperty> { EWeaponProperty.Heavy, EWeaponProperty.TwoHanded },
            Categories = new List<EWeaponType> { EWeaponType.Martial, EWeaponType.Melee },
        };

        public static Weapon Greatsword = new Weapon
        {
            Name = new LocalizedString { EN = "Greatsword", RU = "Двуручный меч" },
            Price = 50,
            Damage = new List<Damage> { new Damage { DiceCount = 2, DiceType = EDice.D6, Type = EDamageType.Slashing } },
            Weight = 6,
            Properties = new List<EWeaponProperty> { EWeaponProperty.Heavy, EWeaponProperty.TwoHanded },
            Categories = new List<EWeaponType> { EWeaponType.Martial, EWeaponType.Melee },
        };

        public static Weapon Halberd = new Weapon
        {
            Name = new LocalizedString { EN = "Halberd", RU = "Алебарда" },
            Price = 20,
            Damage = new List<Damage> { new Damage { DiceCount = 1, DiceType = EDice.D10, Type = EDamageType.Slashing } },
            Weight = 6,
            Properties = new List<EWeaponProperty> { EWeaponProperty.Heavy, EWeaponProperty.Reach, EWeaponProperty.TwoHanded },
            Categories = new List<EWeaponType> { EWeaponType.Martial, EWeaponType.Melee },
        };

        public static Weapon Lance = new Weapon
        {
            Name = new LocalizedString { EN = "Lance", RU = "Длинное копьё" },
            Price = 10,
            Damage = new List<Damage> { new Damage { DiceCount = 1, DiceType = EDice.D12, Type = EDamageType.Piercing } },
            Weight = 6,
            Properties = new List<EWeaponProperty> { EWeaponProperty.Reach, EWeaponProperty.Special },
            Categories = new List<EWeaponType> { EWeaponType.Martial, EWeaponType.Melee },
        };

        public static Weapon Longsword = new Weapon
        {
            Name = new LocalizedString { EN = "Longsword", RU = "Длинный меч" },
            Price = 15,
            Damage = new List<Damage> { new Damage { DiceCount = 1, DiceType = EDice.D8, Type = EDamageType.Slashing } },
            Versatile = new List<Damage> { new Damage { DiceCount = 1, DiceType = EDice.D10, Type = EDamageType.Slashing } },
            Weight = 3,
            Properties = new List<EWeaponProperty>(),
            Categories = new List<EWeaponType> { EWeaponType.Martial, EWeaponType.Melee },
        };

        public static Weapon Maul = new Weapon
        {
            Name = new LocalizedString { EN = "Maul", RU = "Молот" },
            Price = 10,
            Damage = new List<Damage> { new Damage { DiceCount = 2, DiceType = EDice.D6, Type = EDamageType.Bludgeoning } },
            Weight = 10,
            Properties = new List<EWeaponProperty> { EWeaponProperty.Heavy, EWeaponProperty.TwoHanded },
            Categories = new List<EWeaponType> { EWeaponType.Martial, EWeaponType.Melee },
        };

        public static Weapon Morningstar = new Weapon
        {
            Name = new LocalizedString { EN = "Morningstar", RU = "Моргенштерн" },
            Price = 15,
            Damage = new List<Damage> { new Damage { DiceCount = 1, DiceType = EDice.D8, Type = EDamageType.Piercing } },
            Weight = 4,
            Properties = new List<EWeaponProperty>(),
            Categories = new List<EWeaponType> { EWeaponType.Martial, EWeaponType.Melee },
        };

        public static Weapon Pike = new Weapon
        {
            Name = new LocalizedString { EN = "Pike", RU = "Пика" },
            Price = 5,
            Damage = new List<Damage> { new Damage { DiceCount = 1, DiceType = EDice.D10, Type = EDamageType.Piercing } },
            Weight = 18,
            Properties = new List<EWeaponProperty> { EWeaponProperty.Heavy, EWeaponProperty.Reach, EWeaponProperty.TwoHanded },
            Categories = new List<EWeaponType> { EWeaponType.Martial, EWeaponType.Melee },
        };

        public static Weapon Rapier = new Weapon
        {
            Name = new LocalizedString { EN = "Rapier", RU = "Рапира" },
            Price = 25,
            Damage = new List<Damage> { new Damage { DiceCount = 1, DiceType = EDice.D8, Type = EDamageType.Piercing } },
            Weight = 2,
            Properties = new List<EWeaponProperty> { EWeaponProperty.Finesse },
            Categories = new List<EWeaponType> { EWeaponType.Martial, EWeaponType.Melee },
        };

        public static Weapon Scimitar = new Weapon
        {
            Name = new LocalizedString { EN = "Scimitar", RU = "Скимитар" },
            Price = 25,
            Damage = new List<Damage> { new Damage { DiceCount = 1, DiceType = EDice.D6, Type = EDamageType.Slashing } },
            Weight = 3,
            Properties = new List<EWeaponProperty> { EWeaponProperty.Finesse, EWeaponProperty.Light },
            Categories = new List<EWeaponType> { EWeaponType.Martial, EWeaponType.Melee },
        };

        public static Weapon Shortsword = new Weapon
        {
            Name = new LocalizedString { EN = "Shortsword", RU = "Короткий меч" },
            Price = 10,
            Damage = new List<Damage> { new Damage { DiceCount = 1, DiceType = EDice.D6, Type = EDamageType.Piercing } },
            Weight = 2,
            Properties = new List<EWeaponProperty> { EWeaponProperty.Finesse, EWeaponProperty.Light },
            Categories = new List<EWeaponType> { EWeaponType.Martial, EWeaponType.Melee },
        };

        public static Weapon Trident = new Weapon
        {
            Name = new LocalizedString { EN = "Shortsword", RU = "Короткий меч" },
            Price = 5,
            Damage = new List<Damage> { new Damage { DiceCount = 1, DiceType = EDice.D6, Type = EDamageType.Piercing } },
            Versatile = new List<Damage> { new Damage { DiceCount = 1, DiceType = EDice.D8, Type = EDamageType.Piercing } },
            Weight = 2,
            Properties = new List<EWeaponProperty> { EWeaponProperty.Thrown },
            Categories = new List<EWeaponType> { EWeaponType.Martial, EWeaponType.Melee },
            Range = new Range { WODis = 20, Max = 60 }
        };

        public static Weapon WarPick = new Weapon
        {
            Name = new LocalizedString { EN = "War pick", RU = "Боевая кирка" },
            Price = 5,
            Damage = new List<Damage> { new Damage { DiceCount = 1, DiceType = EDice.D8, Type = EDamageType.Piercing } },
            Weight = 2,
            Properties = new List<EWeaponProperty>(),
            Categories = new List<EWeaponType> { EWeaponType.Martial, EWeaponType.Melee },
        };

        public static Weapon Warhammer = new Weapon
        {
            Name = new LocalizedString { EN = "Warhammer", RU = "Боевой молот" },
            Price = 15,
            Damage = new List<Damage> { new Damage { DiceCount = 1, DiceType = EDice.D8, Type = EDamageType.Bludgeoning } },
            Versatile = new List<Damage> { new Damage { DiceCount = 1, DiceType = EDice.D10, Type = EDamageType.Bludgeoning } },
            Weight = 2,
            Properties = new List<EWeaponProperty>(),
            Categories = new List<EWeaponType> { EWeaponType.Martial, EWeaponType.Melee },
        };

        public static Weapon Whip = new Weapon
        {
            Name = new LocalizedString { EN = "Whip", RU = "Кнут" },
            Price = 2,
            Damage = new List<Damage> { new Damage { DiceCount = 1, DiceType = EDice.D4, Type = EDamageType.Slashing } },
            Weight = 3,
            Properties = new List<EWeaponProperty> { EWeaponProperty.Finesse, EWeaponProperty.Reach },
            Categories = new List<EWeaponType> { EWeaponType.Martial, EWeaponType.Melee },
        };

        public static Weapon Blowgun = new Weapon
        {
            Name = new LocalizedString { EN = "Blowgun", RU = "Духовая трубка" },
            Price = 10,
            Damage = new List<Damage> { new Damage { Modifier = 1, Type = EDamageType.Piercing } },
            Weight = 1,
            Properties = new List<EWeaponProperty> { EWeaponProperty.Ammunition, EWeaponProperty.Loading },
            Categories = new List<EWeaponType> { EWeaponType.Martial, EWeaponType.Ranged },
            Range = new Range { WODis = 25, Max = 100 }
        };

        public static Weapon CrossbowHand = new Weapon
        {
            Name = new LocalizedString { EN = "Crossbow, hand", RU = "Арбалет, ручной" },
            Price = 75,
            Damage = new List<Damage> { new Damage { DiceCount = 1, DiceType = EDice.D6, Type = EDamageType.Piercing } },
            Weight = 3,
            Properties = new List<EWeaponProperty> { EWeaponProperty.Ammunition, EWeaponProperty.Light, EWeaponProperty.Loading },
            Categories = new List<EWeaponType> { EWeaponType.Martial, EWeaponType.Ranged },
            Range = new Range { WODis = 30, Max = 120 }
        };

        public static Weapon CrossbowHeavy = new Weapon
        {
            Name = new LocalizedString { EN = "Crossbow, heavy", RU = "Арбалет, тяжёлый" },
            Price = 50,
            Damage = new List<Damage> { new Damage { DiceCount = 1, DiceType = EDice.D10, Type = EDamageType.Piercing } },
            Weight = 18,
            Properties = new List<EWeaponProperty> { EWeaponProperty.Ammunition, EWeaponProperty.Heavy, EWeaponProperty.Loading, EWeaponProperty.TwoHanded },
            Categories = new List<EWeaponType> { EWeaponType.Martial, EWeaponType.Ranged },
            Range = new Range { WODis = 100, Max = 400 }
        };

        public static Weapon Longbow = new Weapon
        {
            Name = new LocalizedString { EN = "Longbow", RU = "Длинный лук" },
            Price = 50,
            Damage = new List<Damage> { new Damage { DiceCount = 1, DiceType = EDice.D8, Type = EDamageType.Piercing } },
            Weight = 2,
            Properties = new List<EWeaponProperty> { EWeaponProperty.Ammunition, EWeaponProperty.Heavy, EWeaponProperty.TwoHanded },
            Categories = new List<EWeaponType> { EWeaponType.Martial, EWeaponType.Ranged },
            Range = new Range { WODis = 150, Max = 600 }
        };

        public static Weapon Net = new Weapon
        {
            Name = new LocalizedString { EN = "Net", RU = "Сеть" },
            Price = 1,
            Weight = 3,
            Properties = new List<EWeaponProperty> { EWeaponProperty.Special, EWeaponProperty.Thrown },
            Categories = new List<EWeaponType> { EWeaponType.Martial, EWeaponType.Ranged },
            Range = new Range { WODis = 5, Max = 15 }
        };
    }
}
