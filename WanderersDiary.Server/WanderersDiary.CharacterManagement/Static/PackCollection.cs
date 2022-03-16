using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using WanderersDiary.CharacterManagement.Models;
using WanderersDiary.CharacterManagement.Models.Utility;

namespace WanderersDiary.CharacterManagement.Static
{
    public class PackCollection : StaticCollectionBase<PackCollection, Pack>
    {
        public static Pack BurglarsPack = new Pack
        {
            PackName = new LocalizedString { EN = "Burglar's Pack", RU = "Набор взломщика" }, Price = 16,
            Content = new List<Equipment>
            {
                EquipmentCollection.Backpack.With(
                    EquipmentCollection.BallBearingsBagOf1000, EquipmentCollection.String10ft, EquipmentCollection.Bell, 
                    EquipmentCollection.Candle.X(5), EquipmentCollection.Crowbar, EquipmentCollection.Hammer, 
                    EquipmentCollection.Piton.X(10), EquipmentCollection.LanternHooded, EquipmentCollection.OilFlask.X(2), 
                    EquipmentCollection.Rations1Day.X(5), EquipmentCollection.Tinderbox, EquipmentCollection.Waterskin, 
                    EquipmentCollection.RopeHempen50Feet)
            }
        };

        public static Pack DiplomatsPack = new Pack
        {
            PackName = new LocalizedString { EN = "Diplomat's Pack", RU = "Набор дипломата" }, Price = 39,
            Content = new List<Equipment>
            {
                EquipmentCollection.Chest.With(
                    EquipmentCollection.CaseMapOrScroll.X(2), EquipmentCollection.ClothesFine, EquipmentCollection.Ink1OunceBottle,
                    EquipmentCollection.InkPen, EquipmentCollection.Lamp, EquipmentCollection.OilFlask.X(2),
                    EquipmentCollection.PaperOneSheet.X(5), EquipmentCollection.PerfumeVial, EquipmentCollection.SealingWax,
                    EquipmentCollection.Soap)
            }
        };

        public static Pack DungeoneersPack = new Pack
        {
            PackName = new LocalizedString { EN = "Dungeoneer's Pack", RU = "Набор исследователя подземелий" }, Price = 12,
            Content = new List<Equipment>
            {
                EquipmentCollection.Backpack.With(
                    EquipmentCollection.Crowbar, EquipmentCollection.Hammer, EquipmentCollection.Piton.X(10),
                    EquipmentCollection.Torch.X(10), EquipmentCollection.Tinderbox, EquipmentCollection.Rations1Day.X(10),
                    EquipmentCollection.Waterskin, EquipmentCollection.RopeHempen50Feet)
            }
        };

        public static Pack EntertainersPack = new Pack
        {
            PackName = new LocalizedString { EN = "Entertainer's Pack", RU = "Набор артиста" }, Price = 40,
            Content = new List<Equipment>
            {
                EquipmentCollection.Backpack.With(
                    EquipmentCollection.Bedroll, EquipmentCollection.ClothesCostume.X(2), EquipmentCollection.Candle.X(5),
                    EquipmentCollection.Rations1Day.X(5), EquipmentCollection.Waterskin, ToolsCollection.DisguiseKit)
            }
        };

        public static Pack ExplorersPack = new Pack
        {
            PackName = new LocalizedString { EN = "Explorer's Pack", RU = "Набор путешественника" }, Price = 10,
            Content = new List<Equipment>
            {
                EquipmentCollection.Backpack.With(
                    EquipmentCollection.Bedroll, EquipmentCollection.MessKit, EquipmentCollection.Tinderbox,
                    EquipmentCollection.Torch.X(10), EquipmentCollection.Rations1Day.X(10), EquipmentCollection.Waterskin,
                    EquipmentCollection.RopeHempen50Feet)
            }
        };

        public static Pack PriestsPack = new Pack
        {
            PackName = new LocalizedString { EN = "Priest's Pack", RU = "Набор священника" }, Price = 19,
            Content = new List<Equipment>
            {
                EquipmentCollection.Backpack.With(
                    EquipmentCollection.Blanket, EquipmentCollection.Candle.X(10), EquipmentCollection.Tinderbox,
                    EquipmentCollection.AlmsBox, EquipmentCollection.BlocksOfIncense.X(2), EquipmentCollection.Censer,
                    EquipmentCollection.Vestments, EquipmentCollection.Rations1Day.X(2), EquipmentCollection.Waterskin)
            }
        };

        public static Pack ScholarsPack = new Pack
        {
            PackName = new LocalizedString { EN = "Scholar's Pack", RU = "Набор учёного" }, Price = 40,
            Content = new List<Equipment>
            {
                EquipmentCollection.Backpack.With(
                    EquipmentCollection.Book, EquipmentCollection.Ink1OunceBottle, EquipmentCollection.InkPen,
                    EquipmentCollection.ParchmentOneSheet.X(10), EquipmentCollection.BagOfSand, EquipmentCollection.SmallKnife)
            }
        };
    }
}
