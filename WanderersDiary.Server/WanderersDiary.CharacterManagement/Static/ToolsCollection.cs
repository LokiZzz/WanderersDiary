using System;
using System.Collections.Generic;
using System.Text;
using WanderersDiary.CharacterManagement.Models;
using WanderersDiary.CharacterManagement.Models.Utility;

namespace WanderersDiary.CharacterManagement.Static
{
    public class ToolsCollection : StaticCollectionBase<ToolsCollection,Equipment>
    {
        public static Equipment DisguiseKit = new Equipment
        {
            Name = new LocalizedString { EN = "Disguise Kit", RU = "Набор для грима" },
            Price = 25m,
            Weight = 3,
            Description = new LocalizedString
            {
                EN = "A disguise kit includes cosmetics, hair dye, small props, and a few pieces of clothing.",
                RU = "Набор для грима включает в себя различную косметику, краску для волос, немного реквизита и несколько нарядов."
            },
            Type = EEquipmentType.Tool
        };

        public static Equipment ForgeryKit = new Equipment
        {
            Name = new LocalizedString { EN = "Forgery Kit", RU = "Набор для фальсификации" },
            Price = 15m,
            Weight = 5,
            Description = new LocalizedString
            {
                EN = "A forgery kit includes several different types of ink, a variety of parchments and papers, several quills, seals and sealing wax, gold and silver leaf, and small tools to sculpt melted wax to mimic a seal.",
                RU = "Набор для фальсификации включает в себя чернила различных видов, пергамент и бумагу различных видов, несколько писчих перьев, печати и сургуч, золотой и серебряный листы и небольшие инструменты для лепки из расплавленного воска имитации печати."
            },
            Type = EEquipmentType.Tool
        };

        public static Equipment HerbalismKit = new Equipment
        {
            Name = new LocalizedString { EN = "Herbalism Kit", RU = "Инструменты травника" },
            Price = 5m,
            Weight = 3m,
            Description = new LocalizedString
            {
                EN = "An herbalism kit includes pouches to store herbs, clippers and leather gloves for collecting plants, a mortar and pestle, and several glass jars.",
                RU = "Включает в себя мешочки для хранения трав, секатор и кожаные перчатки для сбора растений, несколько стеклянных банок, ступку и пестик."
            },
            Type = EEquipmentType.Tool
        };

        public static Equipment Navigator = new Equipment
        {
            Name = new LocalizedString { EN = "Navigator’s Tools", RU = "Инструменты навигатора" },
            Price = 25m,
            Weight = 2m,
            Description = new LocalizedString
            {
                EN = "Navigator's tools include a sextant, a compass, calipers, a ruler, parchment, ink, and a quill.",
                RU = "Эти инструменты включают секстант, компас, калипер, линейку, пергамент, чернила и перо."
            },
            Type = EEquipmentType.Tool
        };

        public static Equipment Poisoner = new Equipment
        {
            Name = new LocalizedString { EN = "Poisoner’s Kit", RU = "Инструменты отравителя" },
            Price = 50m,
            Weight = 2m,
            Description = new LocalizedString
            {
                EN = "A poisoner's kit includes glass vials, a mortar and pestle, chemicals, and a glass stirring rod.",
                RU = "Инструменты отравителя включают в себя стеклянные склянки, ступку и пестик, химические реагенты и стеклянную палочку для размешивания."
            },
            Type = EEquipmentType.Tool
        };

        public static Equipment Thieve = new Equipment
        {
            Name = new LocalizedString { EN = "Thieves’ tools", RU = "Воровские инструменты" },
            Price = 25m,
            Weight = 1m,
            Description = new LocalizedString
            {
                EN = "Smith's tools include hammers, tongs, charcoal, rags, and a whetstone.",
                RU = "Инструменты кузнеца включают в себя молоты, клещи, уголь, ветошь и точильный камень."
            },
            Type = EEquipmentType.Tool
        };

        #region Artisan's tools

        public static Equipment Alchemist = new Equipment
        {
            Name = new LocalizedString { EN = "Alchemist’s supplies	", RU = "Инструменты алхимика" },
            Price = 50m,
            Weight = 8,
            Description = new LocalizedString
            {
                EN = "Инструменты алхимика включают в себя две стеклянные мензурки, металлический каркас, удерживающий мензурку над открытым пламенем, стеклянную палочку для размешивания, небольшие ступку и пестик, мешочек обычных алхимических ингредиентов, включающих в себя соль, измельчённое железо и дистиллированную воду.",
                RU = "Alchemist's supplies include two glass beakers, a metal frame to hold a beaker in place over an open flame, a glass stirring rod, a small mortar and pestle, and a pouch of common alchemical ingredients, including salt, powdered iron, and purified water."
            },
            Type = EEquipmentType.Tool
        };

        public static Equipment Brewer = new Equipment
        {
            Name = new LocalizedString { EN = "Brewer’s supplies", RU = "Инструменты пивовара" },
            Price = 20m,
            Weight = 9,
            Description = new LocalizedString
            {
                EN = "Brewer's supplies include a large glass jug, a quantity of hops, a siphon, and several feet of tubing.",
                RU = "Инструменты пивовара включают в себя стеклянную бутыль, некоторое количество хмеля, сифон, змеевик и несколько футов трубок."
            },
            Type = EEquipmentType.Tool
        };

        public static Equipment Calligrapher = new Equipment
        {
            Name = new LocalizedString { EN = "Calligrapher’s Supplies", RU = "Инструменты каллиграфа" },
            Price = 10m,
            Weight = 5,
            Description = new LocalizedString
            {
                EN = "Calligrapher's supplies include ink, a dozen sheets of parchment, and three quills.",
                RU = "Чернила, множество пергаментных листов и три писчих пера."
            },
            Type = EEquipmentType.Tool
        };

        public static Equipment Carpenter = new Equipment
        {
            Name = new LocalizedString { EN = "Carpenter’s Tools", RU = "Инструменты плотника" },
            Price = 8m,
            Weight = 6,
            Description = new LocalizedString
            {
                EN = "Carpenter's tools include a saw, a hammer, nails, a hatchet, a square, a ruler, an adze, a plane, and a chisel.",
                RU = "Инструменты плотника включают в себя пилу, молоток, гвозди, топор, угольник, линейку, кородёр, рубанок и стамеску."
            },
            Type = EEquipmentType.Tool
        };

        public static Equipment Cartographer = new Equipment
        {
            Name = new LocalizedString { EN = "Cartographer's Tools", RU = "Инструменты плотника" },
            Price = 15m,
            Weight = 6,
            Description = new LocalizedString
            {
                EN = "Cartographer's tools consist of a quill, ink, parchment, a pair of compasses, calipers, and a ruler.",
                RU = "Инструменты картографа включают в себя писчее перо, чернила, пергамент, циркуль, кронциркуль и линейку."
            },
            Type = EEquipmentType.Tool
        };

        public static Equipment Cobbler = new Equipment
        {
            Name = new LocalizedString { EN = "Cobbler’s Tools", RU = "Инструменты сапожник" },
            Price = 50m,
            Weight = 10,
            Description = new LocalizedString
            {
                EN = "Cobbler's tools consist of a hammer, an awl, a knife, a shoe stand, a cutter, spare leather, and thread.",
                RU = "Включают в себя молоток, шило, нож, обувную колодку, ножницы, запас кожи и ниток."
            },
            Type = EEquipmentType.Tool
        };

        public static Equipment Cook = new Equipment
        {
            Name = new LocalizedString { EN = "Cook’s Utensils", RU = "Инструменты повара" },
            Price = 50m,
            Weight = 10,
            Description = new LocalizedString
            {
                EN = "Cook's utensils include a metal pot, knives, forks, a stirring spoon, and a ladle.",
                RU = "Инструменты повара включают в себя металлический котёл, ножи, вилки, ложку для размешивания и половник."
            },
            Type = EEquipmentType.Tool
        };

        public static Equipment Glassblower = new Equipment
        {
            Name = new LocalizedString { EN = "Glassblower’s Tools", RU = "Инструменты стеклодува" },
            Price = 30m,
            Weight = 5m,
            Description = new LocalizedString
            {
                EN = "The tools include a blowpipe, a small marver, blocks, and tweezers. You need a source of heat to work glass.",
                RU = "Включают в себя трубку для выдувания, маленькую стеклодувную обкатку, катальник, развёртки и щипцы. Вам нужен источник тепла для работы со стеклом."
            },
            Type = EEquipmentType.Tool
        };

        public static Equipment Jeweler = new Equipment
        {
            Name = new LocalizedString { EN = "Jeweler’s Tools", RU = "Инструменты ювелира" },
            Price = 25m,
            Weight = 2m,
            Description = new LocalizedString
            {
                EN = "Jeweler's tools consist of a small saw and hammer, files, pliers, and tweezers.",
                RU = "Инструменты ювелира включают в себя небольшие пилу и молоточек, напильники, щипцы и пинцет."
            },
            Type = EEquipmentType.Tool
        };

        public static Equipment Leatherworker = new Equipment
        {
            Name = new LocalizedString { EN = "Leatherworker’s Tools", RU = "Инструменты ювелира" },
            Price = 5m,
            Weight = 5m,
            Description = new LocalizedString
            {
                EN = "Leatherworker's tools include a knife, a small mallet, an edger, a hole punch, thread, and leather scraps.",
                RU = "Инструменты кожевника включают кожевенный резак (нож), небольшую киянку, канавкорез, пробойник, нить и куски кожи."
            },
            Type = EEquipmentType.Tool
        };

        public static Equipment Mason = new Equipment
        {
            Name = new LocalizedString { EN = "Mason’s Tools", RU = "Инструменты каменщика" },
            Price = 10m,
            Weight = 8m,
            Description = new LocalizedString
            {
                EN = "Mason's tools consist of a trowel, a hammer, a chisel, brushes, and a square.",
                RU = "Включают в себя мастерок, молоток, долото, щётки и угольник."
            },
            Type = EEquipmentType.Tool
        };

        public static Equipment Painter = new Equipment
        {
            Name = new LocalizedString { EN = "Painter’s Supplies", RU = "Инструменты художника" },
            Price = 25m,
            Weight = 2m,
            Description = new LocalizedString
            {
                EN = "Painter's supplies include an easel, canvas, paints, brushes, charcoal sticks, and a palette.",
                RU = "Инструменты художнику включают в себя мольберт, холст, краски, кисти, угольные карандаши и палитру."
            },
            Type = EEquipmentType.Tool
        };

        public static Equipment Potter = new Equipment
        {
            Name = new LocalizedString { EN = "Potter’s Tools", RU = "Инструменты гончара" },
            Price = 10m,
            Weight = 3m,
            Description = new LocalizedString
            {
                EN = "Potter's tools include potter's needles, ribs, scrapers, a knife, and calipers.",
                RU = "Включают в себя гончарные иглы, цикли, скребки, нож и кронциркуль."
            },
            Type = EEquipmentType.Tool
        };

        public static Equipment Smith = new Equipment
        {
            Name = new LocalizedString { EN = "Smith’s Tools", RU = "Инструменты кузнеца" },
            Price = 20m,
            Weight = 8m,
            Description = new LocalizedString
            {
                EN = "Smith's tools include hammers, tongs, charcoal, rags, and a whetstone.",
                RU = "Инструменты кузнеца включают в себя молоты, клещи, уголь, ветошь и точильный камень."
            },
            Type = EEquipmentType.Tool
        };

        public static Equipment Tinker = new Equipment
        {
            Name = new LocalizedString { EN = "Tinker’s Tools", RU = "Инструменты ремонтника" },
            Price = 50m,
            Weight = 10m,
            Description = new LocalizedString
            {
                EN = "Tinker's tools include a variety of hand tools, thread, needles, a whetstone, scraps of cloth and leather, and a small pot of glue.",
                RU = "Инструменты ремонтника включают в себя различные ручные инструменты, нитки, иголки, точильный камень, куски ткани и кожи, небольшую банку клея."
            },
            Type = EEquipmentType.Tool
        };

        public static Equipment Weaver = new Equipment
        {
            Name = new LocalizedString { EN = "Weaver’s Tools", RU = "Инструменты ткача" },
            Price = 1m,
            Weight = 5m,
            Description = new LocalizedString
            {
                EN = "Weaver's tools include thread, needles, and scraps of cloth. You know how to work a loom, but such equipment is too large to transport.",
                RU = "Включают в себя нитки, иголки и куски ткани. Вы умеете пользоваться ткацким станком, но подобное оборудование слишком громоздкое для транспортировки."
            },
            Type = EEquipmentType.Tool
        };

        public static Equipment Woodcarver = new Equipment
        {
            Name = new LocalizedString { EN = "Woodcarver’s Tools", RU = "Инструменты резчика по дереву" },
            Price = 1m,
            Weight = 5m,
            Description = new LocalizedString
            {
                EN = "Woodcarver's tools consist of a knife, a gouge, and a small saw.",
                RU = "ключают в себя нож, стамеску и маленькую пилу."
            },
            Type = EEquipmentType.Tool
        };

        #endregion

        #region Gaming set

        public static Equipment DiceSet = new Equipment
        {
            Name = new LocalizedString { EN = "Dice set", RU = "Игральные кости" },
            Price = 0.1m,
            Description = new LocalizedString
            {
                EN = "A gaming set has all the pieces needed to play a specific game or type of game, such as a complete deck of cards or a board and tokens.",
                RU = "Игровой набор включает в себя всё необходимое для конкретной игры или группы игр, как, например, полная колода карт или доска и фигуры."
            },
            Type = EEquipmentType.Tool
        };

        public static Equipment DragonChess = new Equipment
        {
            Name = new LocalizedString { EN = "Dragon chess set", RU = "Драконьи шахматы" },
            Price = 1m,
            Weight = 0.5m,
            Description = new LocalizedString
            {
                EN = "A gaming set has all the pieces needed to play a specific game or type of game, such as a complete deck of cards or a board and tokens.",
                RU = "Игровой набор включает в себя всё необходимое для конкретной игры или группы игр, как, например, полная колода карт или доска и фигуры."
            },
            Type = EEquipmentType.Tool
        };

        public static Equipment PlayingCards = new Equipment
        {
            Name = new LocalizedString { EN = "Playing card set", RU = "Игральные карты" },
            Price = 0.5m,
            Description = new LocalizedString
            {
                EN = "A gaming set has all the pieces needed to play a specific game or type of game, such as a complete deck of cards or a board and tokens.",
                RU = "Игровой набор включает в себя всё необходимое для конкретной игры или группы игр, как, например, полная колода карт или доска и фигуры."
            },
            Type = EEquipmentType.Tool
        };

        public static Equipment ThreeDragonAnte = new Equipment
        {
            Name = new LocalizedString { EN = "Three-Dragon Ante set", RU = "Ставка трёх драконов" },
            Price = 1m,
            Weight = 3m,
            Description = new LocalizedString
            {
                EN = "A gaming set has all the pieces needed to play a specific game or type of game, such as a complete deck of cards or a board and tokens.",
                RU = "Игровой набор включает в себя всё необходимое для конкретной игры или группы игр, как, например, полная колода карт или доска и фигуры."
            },
            Type = EEquipmentType.Tool
        };

        #endregion

        #region Musical instrument

        public static Equipment Bagpipes = new Equipment
        {
            Name = new LocalizedString { EN = "Bagpipes", RU = "Волынка" },
            Price = 30m,
            Weight = 6m,
            Description = new LocalizedString
            {
                EN = "Proficiency with a musical instrument indicates you are familiar with the techniques used to play it. You also have knowledge of some songs commonly performed with that instrument.",
                RU = "Владение музыкальным инструментом означает, что вы знакомы с приёмами игры на нём. Вы также знаете несколько песен, как правило, исполняющихся на этом инструменте."
            },
            Type = EEquipmentType.Tool
        };

        public static Equipment Drum = new Equipment
        {
            Name = new LocalizedString { EN = "Drum", RU = "Барабан" },
            Price = 6m,
            Weight = 3m,
            Description = new LocalizedString
            {
                EN = "Proficiency with a musical instrument indicates you are familiar with the techniques used to play it. You also have knowledge of some songs commonly performed with that instrument.",
                RU = "Владение музыкальным инструментом означает, что вы знакомы с приёмами игры на нём. Вы также знаете несколько песен, как правило, исполняющихся на этом инструменте."
            },
            Type = EEquipmentType.Tool
        };

        public static Equipment Dulcimer = new Equipment
        {
            Name = new LocalizedString { EN = "Dulcimer", RU = "Цимбалы" },
            Price = 25m,
            Weight = 10m,
            Description = new LocalizedString
            {
                EN = "Proficiency with a musical instrument indicates you are familiar with the techniques used to play it. You also have knowledge of some songs commonly performed with that instrument.",
                RU = "Владение музыкальным инструментом означает, что вы знакомы с приёмами игры на нём. Вы также знаете несколько песен, как правило, исполняющихся на этом инструменте."
            },
            Type = EEquipmentType.Tool
        };

        public static Equipment Flute = new Equipment
        {
            Name = new LocalizedString { EN = "Flute", RU = "Флейта" },
            Price = 2m,
            Weight = 1m,
            Description = new LocalizedString
            {
                EN = "Proficiency with a musical instrument indicates you are familiar with the techniques used to play it. You also have knowledge of some songs commonly performed with that instrument.",
                RU = "Владение музыкальным инструментом означает, что вы знакомы с приёмами игры на нём. Вы также знаете несколько песен, как правило, исполняющихся на этом инструменте."
            },
            Type = EEquipmentType.Tool
        };

        public static Equipment Lute = new Equipment
        {
            Name = new LocalizedString { EN = "Lute", RU = "Лютня" },
            Price = 35m,
            Weight = 2m,
            Description = new LocalizedString
            {
                EN = "Proficiency with a musical instrument indicates you are familiar with the techniques used to play it. You also have knowledge of some songs commonly performed with that instrument.",
                RU = "Владение музыкальным инструментом означает, что вы знакомы с приёмами игры на нём. Вы также знаете несколько песен, как правило, исполняющихся на этом инструменте."
            },
            Type = EEquipmentType.Tool
        };

        public static Equipment Lyre = new Equipment
        {
            Name = new LocalizedString { EN = "Lyre", RU = "Лира" },
            Price = 30m,
            Weight = 2m,
            Description = new LocalizedString
            {
                EN = "Proficiency with a musical instrument indicates you are familiar with the techniques used to play it. You also have knowledge of some songs commonly performed with that instrument.",
                RU = "Владение музыкальным инструментом означает, что вы знакомы с приёмами игры на нём. Вы также знаете несколько песен, как правило, исполняющихся на этом инструменте."
            },
            Type = EEquipmentType.Tool
        };

        public static Equipment Horn = new Equipment
        {
            Name = new LocalizedString { EN = "Horn", RU = "Рожок" },
            Price = 3m,
            Weight = 2m,
            Description = new LocalizedString
            {
                EN = "Proficiency with a musical instrument indicates you are familiar with the techniques used to play it. You also have knowledge of some songs commonly performed with that instrument.",
                RU = "Владение музыкальным инструментом означает, что вы знакомы с приёмами игры на нём. Вы также знаете несколько песен, как правило, исполняющихся на этом инструменте."
            },
            Type = EEquipmentType.Tool
        };

        public static Equipment PanFlute = new Equipment
        {
            Name = new LocalizedString { EN = "Pan flute", RU = "Свирель" },
            Price = 12m,
            Weight = 2m,
            Description = new LocalizedString
            {
                EN = "Proficiency with a musical instrument indicates you are familiar with the techniques used to play it. You also have knowledge of some songs commonly performed with that instrument.",
                RU = "Владение музыкальным инструментом означает, что вы знакомы с приёмами игры на нём. Вы также знаете несколько песен, как правило, исполняющихся на этом инструменте."
            },
            Type = EEquipmentType.Tool
        };

        public static Equipment Shawn = new Equipment
        {
            Name = new LocalizedString { EN = "Shawn", RU = "Шалмей" },
            Price = 2m,
            Weight = 1m,
            Description = new LocalizedString
            {
                EN = "Proficiency with a musical instrument indicates you are familiar with the techniques used to play it. You also have knowledge of some songs commonly performed with that instrument.",
                RU = "Владение музыкальным инструментом означает, что вы знакомы с приёмами игры на нём. Вы также знаете несколько песен, как правило, исполняющихся на этом инструменте."
            },
            Type = EEquipmentType.Tool
        };

        public static Equipment Viol = new Equipment
        {
            Name = new LocalizedString { EN = "Viol", RU = "Виола" },
            Price = 30m, Weight = 1m,
            Description = new LocalizedString
            {
                EN = "Proficiency with a musical instrument indicates you are familiar with the techniques used to play it. You also have knowledge of some songs commonly performed with that instrument.",
                RU = "Владение музыкальным инструментом означает, что вы знакомы с приёмами игры на нём. Вы также знаете несколько песен, как правило, исполняющихся на этом инструменте."
            },
            Type = EEquipmentType.Tool
        };

        #endregion
    }
}
