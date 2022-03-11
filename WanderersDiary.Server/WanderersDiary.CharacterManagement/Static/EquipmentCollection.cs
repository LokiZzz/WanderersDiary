using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WanderersDiary.CharacterManagement.Models;
using WanderersDiary.CharacterManagement.Models.Utility;

namespace WanderersDiary.CharacterManagement.Static
{
    public class EquipmentCollection : StaticCollectionBase<EquipmentCollection, Equipment>
    {
        public static Equipment Abacus = new Equipment
        {
            Name = new LocalizedString { EN = "Abacus", RU = "Счеты" },
            Price = 2m, Weight = 2m, Type = EEquipmentType.Tool
        };

        public static Equipment AcidVial = new Equipment
        {
            Name = new LocalizedString { EN = "Acid (vial)", RU = "Кислота (Флакон)" },
            Description = new LocalizedString {
               EN = "As an action, you can splash the contents of this vial onto a creature within 5 feet of you or throw  the vial up to 20 feet, shattering it on impact. In either case, make a ranged attack against a creature or object, treating the acid as an improvised weapon. On a hit, the target takes 2d6 acid damage.",
               RU = "Вы можете действием выплеснуть содержимое этого сосуда на существо, находящееся в пределах 5 футов от вас, или метнуть сосуд на расстояние до 20 футов, чтобы он разбился от удара. В любом случае совершите дальнобойную атаку против существа или предмета, считая кислоту импровизированным оружием. При попадании цель получает урон кислотой 2к6."
            },
            Price = 25m, Weight = 1m, Type = EEquipmentType.Consumable
        };

        public static Equipment AlchemistsFireFlask = new Equipment
        {
            Name = new LocalizedString { EN = "Alchemist's fire (flask)", RU = "Алхимический огонь (фляжка)" },
            Description = new LocalizedString {
               EN = "This sticky, adhesive fluid ignites when exposed to air. As an action, you can throw this flask up to 20 feet, shattering it on impact. Make a ranged attack against a creature or object, treating the alchemist's tire as an improvised weapon. On a hit, the target takes Id4 tire damage at the start of each of its turns. Acreature can end this damage by using its action to make a DC 10 Dexterity check to extinguish the liames.",
               RU = "Эта вязкая и клейкая жидкость воспламеняется при контакте с воздухом. Вы можете действием метнуть фляжку на расстояние до 20 футов, разбив её от удара. Совершите дальнобойную атаку по существу или предмету, считая алхимический огонь импровизированным оружием. При попадании цель получает урон огнём 1к4 в начале каждого своего хода. Существо может окончить этот урон, потратив действие на тушение пламени, и совершив проверку Ловкости со Сл 10."
            },
            Price = 50m, Weight = 1m, Type = EEquipmentType.Consumable
        };

        public static Equipment Arrow = new Equipment
        {
            Name = new LocalizedString { EN = "Arrow", RU = "Стрела" },
            Price = 0.05m, Weight = 0.05m, Type = EEquipmentType.Ammunition
        };

        public static Equipment Arrows20 = new Equipment
        {
            Name = new LocalizedString { EN = "Arrow", RU = "Стрела" },
            Price = 0.05m, Weight = 0.05m, Type = EEquipmentType.Ammunition,
            Quantity = 20
        };

        public static Equipment BlowgunNeedle = new Equipment
        {
            Name = new LocalizedString { EN = "Blowgun needle", RU = "Игла для трубки" },
            Price = 0.02m, Weight = 0.02m, Type = EEquipmentType.Ammunition,
        };

        public static Equipment BlowgunNeedles50 = new Equipment
        {
            Name = new LocalizedString { EN = "Blowgun needle", RU = "Игла для трубки" },
            Price = 0.02m, Weight = 0.02m, Type = EEquipmentType.Ammunition,
            Quantity = 50
        };

        public static Equipment CrossbowBolt = new Equipment
        {
            Name = new LocalizedString { EN = "Crossbow bolt", RU = "Арбалетный болт" },
            Price = 0.05m, Weight = 0.075m, Type = EEquipmentType.Ammunition
        };

        public static Equipment CrossbowBolts20 = new Equipment
        {
            Name = new LocalizedString { EN = "Crossbow bolt", RU = "Арбалетный болт" },
            Price = 0.05m, Weight = 0.075m, Type = EEquipmentType.Ammunition,
            Quantity = 20
        };

        public static Equipment SlingBullets = new Equipment
        {
            Name = new LocalizedString { EN = "Sling bullet", RU = "Снаряд для пращи" },
            Price = 0.002m, Weight = 0.075m, Type = EEquipmentType.Ammunition,
        };

        public static Equipment SlingBullets20 = new Equipment
        {
            Name = new LocalizedString { EN = "Sling bullet", RU = "Снаряд для пращи" },
            Price = 0.002m, Weight = 0.075m, Type = EEquipmentType.Ammunition,
            Quantity = 20
        };

        public static Equipment AntitoxinVial = new Equipment
        {
            Name = new LocalizedString { EN = "Antitoxin (vial)", RU = "Противоядие (флакон)" },
            Description = new LocalizedString {
               EN = "Acreature that drinks this viaI of liquid gains advantage on saving throws against poison for 1 hour. lt confers no benetit to undead or constructs.",
               RU = "Существо, выпившее жидкость из этого флакона, в течение часа совершает спасброски от яда с преимуществом. Оно не предоставляет преимущества нежити и конструктам."
            },
            Price = 50m, Weight = 0m, Type = EEquipmentType.Consumable
        };

        public static Equipment Crystal = new Equipment
        {
            Name = new LocalizedString { EN = "Crystal", RU = "Кристалл" },
            Description = new LocalizedString {
               EN = "An arcane focus is a special iteman orb, a crystal, a rod, a specially constructed staff, a wand.like length ofwood, or some similar itemdesigned to channel the power of arcane spells. A sorcerer, warlock, or wizard can use such an item as a spellcasting focus, as described in chapter 10.",
               RU = "Магическая фокусировка это особый предмет — сфера, кристалл, жезл, особый посох, короткая деревянная палочка или похожий предмет — созданный для проведения тайных заклинаний. Волшебники, колдуны и чародеи могут использовать эти предметы в качестве фокусировки для заклинаний, как описано в главе 10."
            },
            Price = 10m, Weight = 1m, Type = EEquipmentType.ArcaneFocus
        };

        public static Equipment Orb = new Equipment
        {
            Name = new LocalizedString { EN = "Orb", RU = "Сфера" },
            Description = new LocalizedString {
               EN = "An arcane focus is a special iteman orb, a crystal, a rod, a specially constructed staff, a wand.like length ofwood, or some similar itemdesigned to channel the power of arcane spells. A sorcerer, warlock, or wizard can use such an item as a spellcasting focus, as described in chapter 10.",
               RU = "Магическая фокусировка это особый предмет — сфера, кристалл, жезл, особый посох, короткая деревянная палочка или похожий предмет — созданный для проведения тайных заклинаний. Волшебники, колдуны и чародеи могут использовать эти предметы в качестве фокусировки для заклинаний, как описано в главе 10."
            },
            Price = 20m, Weight = 3m, Type = EEquipmentType.ArcaneFocus
        };

        public static Equipment Rod = new Equipment
        {
            Name = new LocalizedString { EN = "Rod", RU = "Жезл" },
            Description = new LocalizedString {
               EN = "An arcane focus is a special iteman orb, a crystal, a rod, a specially constructed staff, a wand.like length ofwood, or some similar itemdesigned to channel the power of arcane spells. A sorcerer, warlock, or wizard can use such an item as a spellcasting focus, as described in chapter 10.",
               RU = "Магическая фокусировка это особый предмет — сфера, кристалл, жезл, особый посох, короткая деревянная палочка или похожий предмет — созданный для проведения тайных заклинаний. Волшебники, колдуны и чародеи могут использовать эти предметы в качестве фокусировки для заклинаний, как описано в главе 10."
            },
            Price = 10m, Weight = 2m, Type = EEquipmentType.ArcaneFocus
        };

        public static Equipment Staff = new Equipment
        {
            Name = new LocalizedString { EN = "Staff", RU = "Посох" },
            Description = new LocalizedString {
               EN = "An arcane focus is a special iteman orb, a crystal, a rod, a specially constructed staff, a wand.like length ofwood, or some similar itemdesigned to channel the power of arcane spells. A sorcerer, warlock, or wizard can use such an item as a spellcasting focus, as described in chapter 10.",
               RU = "Магическая фокусировка это особый предмет — сфера, кристалл, жезл, особый посох, короткая деревянная палочка или похожий предмет — созданный для проведения тайных заклинаний. Волшебники, колдуны и чародеи могут использовать эти предметы в качестве фокусировки для заклинаний, как описано в главе 10."
            },
            Price = 5m, Weight = 4m, Type = EEquipmentType.ArcaneFocus
        };

        public static Equipment Wand = new Equipment
        {
            Name = new LocalizedString { EN = "Wand", RU = "Волшебная палочка" },
            Description = new LocalizedString {
               EN = "An arcane focus is a special iteman orb, a crystal, a rod, a specially constructed staff, a wand.like length ofwood, or some similar itemdesigned to channel the power of arcane spells. A sorcerer, warlock, or wizard can use such an item as a spellcasting focus, as described in chapter 10.",
               RU = "Магическая фокусировка это особый предмет — сфера, кристалл, жезл, особый посох, короткая деревянная палочка или похожий предмет — созданный для проведения тайных заклинаний. Волшебники, колдуны и чародеи могут использовать эти предметы в качестве фокусировки для заклинаний, как описано в главе 10."
            },
            Price = 10m, Weight = 1m, Type = EEquipmentType.ArcaneFocus
        };

        public static Equipment Backpack = new Equipment
        {
            Name = new LocalizedString { EN = "Backpack", RU = "Рюкзак" },
            Description = new LocalizedString {
               EN = "Capacily: 1 cubic foot/30 pounds of gear<br>You can al50 strap items, such as a bedroll ar a coil af rape, to lhe oulside of a backpack.",
               RU = "Вместимость: 1 кубический фут/30 фунтов (15 килограмм)<br>Вы также можете привязывать такие предметы как спальники и верёвки снаружи рюкзака."
            },
            Price = 2m, Weight = 5m, Type = EEquipmentType.Container
        };

        public static Equipment BallBearing = new Equipment
        {
            Name = new LocalizedString { EN = "Ball bearings (bag of 1000)", RU = "Металлические шарики (сумка с 1000 шт.)" },
            Description = new LocalizedString {
               EN = "As an action, you can spill these tiny metal balls from their pouch to cover a levei area 10 feet square. Acreature moving across the covered area must succeed on a DC 10 Dexterity saving throw or fali prone. A creature moving through the area at half speed doesn't need to make the saving throw.",
               RU = "Вы можете действием рассыпать из этого мешка крохотные металлические шарики, покрыв площадь 10 × 10 футов. Существа, перемещающиеся по этой области, должны преуспеть в спасброске Ловкости со Сл 10, иначе они падают ничком. Существо, перемещающееся по этой области с уменьшенной вдвое скоростью, не обязано совершать спасбросок."
            },
            Price = 0.001m, Weight = 0.002m, Type = EEquipmentType.Consumable,
        };

        public static Equipment BallBearingsBagOf1000 = new Equipment
        {
            Name = new LocalizedString { EN = "Ball bearings (bag of 1000)", RU = "Металлические шарики (сумка с 1000 шт.)" },
            Description = new LocalizedString {
               EN = "As an action, you can spill these tiny metal balls from their pouch to cover a levei area 10 feet square. Acreature moving across the covered area must succeed on a DC 10 Dexterity saving throw or fali prone. A creature moving through the area at half speed doesn't need to make the saving throw.",
               RU = "Вы можете действием рассыпать из этого мешка крохотные металлические шарики, покрыв площадь 10 × 10 футов. Существа, перемещающиеся по этой области, должны преуспеть в спасброске Ловкости со Сл 10, иначе они падают ничком. Существо, перемещающееся по этой области с уменьшенной вдвое скоростью, не обязано совершать спасбросок."
            },
            Price = 0.001m, Weight = 0.002m, Type = EEquipmentType.Consumable,
            Quantity = 1000
        };

        public static Equipment Barrel = new Equipment
        {
            Name = new LocalizedString { EN = "Barrel", RU = "Бочка" },
            Description = new LocalizedString {
               EN = "Capacity: 40 gallons liquid, 4 cubic feel solid",
               RU = "Вмевтимость: 40 галлонов (150 литров), 4 кубических фута"
            },
            Price = 2m, Weight = 70m, Type = EEquipmentType.Container
        };

        public static Equipment Basket = new Equipment
        {
            Name = new LocalizedString { EN = "Basket", RU = "Корзина" },
            Description = new LocalizedString {
               EN = "Capacity: 2 cubic feel/40 pounds of gear",
               RU = "Вместимость: 2 кубических фута/40 фунтов (20 килограмм)"
            },
            Price = 0.4m, Weight = 2m, Type = EEquipmentType.Container
        };

        public static Equipment Bedroll = new Equipment
        {
            Name = new LocalizedString { EN = "Bedroll", RU = "Спальник" },
            Price = 1m, Weight = 7m, Type = EEquipmentType.Camp
        };

        public static Equipment Bell = new Equipment
        {
            Name = new LocalizedString { EN = "Bell", RU = "Колокольчик" },
            Price = 1m, Weight = 0m, Type = EEquipmentType.Gear
        };

        public static Equipment Blanket = new Equipment
        {
            Name = new LocalizedString { EN = "Blanket", RU = "Одеяло" },
            Price = 0.5m, Weight = 3m, Type = EEquipmentType.Camp
        };

        public static Equipment BlockAndTackle = new Equipment
        {
            Name = new LocalizedString { EN = "Block and tackle", RU = "Блок и лебедка" },
            Description = new LocalizedString {
               EN = "Aset of pulleys with a cable threaded through them and a hook to attach to objects, a block and tackle allows you to hoist up to four times the weight you can normally lift.",
               RU = "Набор блоков и тросов с крюками для подвешивания предметов. Блок и лебёдка позволяют вам поднять в четыре раза больше, чем обычно."
            },
            Price = 0.1m, Weight = 5m, Type = EEquipmentType.Gear
        };

        public static Equipment Book = new Equipment
        {
            Name = new LocalizedString { EN = "Book", RU = "Книга" },
            Description = new LocalizedString {
               EN = "A book might contain poetry, historical accounts, information pertaining to a particular tield of lore, diagrams and notes on gnomish contraptions, or just about anything else that can be represented using text or pictures.</a>.",
               RU = "В книге могут быть стихи, документальные сведения, информация о чём-либо, диаграммы и заметки о гномьих приспособлениях, или что угодно другое, представленное текстом и картинками."
            },
            Price = 25m, Weight = 5m, Type = EEquipmentType.Consumable
        };

        public static Equipment BottleGlass = new Equipment
        {
            Name = new LocalizedString { EN = "Bottle, glass", RU = "Бутылка, стеклянная" },
            Description = new LocalizedString {
               EN = "Capacity: 1.5 pints liquid",
               RU = "Вместимость: 1,5 пинты (0,75 литра)"
            },
            Price = 2m, Weight = 2m, Type = EEquipmentType.Consumable
        };

        public static Equipment Bucket = new Equipment
        {
            Name = new LocalizedString { EN = "Bucket", RU = "Ведро" },
            Description = new LocalizedString {
               EN = "Capacity: 3 gallons liquid, 1/2 cubic fool solid",
               RU = "Вместимость: 3 галлона (11 литров), 0,5 кубических футов"
            },
            Price = 0.05m, Weight = 2m, Type = EEquipmentType.Container
        };

        public static Equipment Caltrop = new Equipment
        {
            Name = new LocalizedString { EN = "Caltrop", RU = "Калтроп" },
            Description = new LocalizedString {
               EN = "As an action, you can spread a single bag of caltrops to cover a 5-foot-square area. Any creature that enters the area must succeed on a DC 15 Dexterity saving throw or stop moving and take I piercing damage. Until the creature regains at least I hit point, its walking speed is reduced by 10 feet. Acreature moving through the area at half speed doesn't need to make the saving throw.",
               RU = "Вы можете действием рассыпать сумку калтропов по площади в 5 × 5 футов. Все существа, входящие в эту область, должны преуспеть в спасброске Ловкости со Сл 15, иначе они останавливаются и получают колющий урон 1. Пока это существо не восстановит как минимум 1 хит, его скорость ходьбы уменьшена на 10 футов. Существо, перемещающееся по этой области с уменьшенной вдвое скоростью, не обязано совершать спасбросок."
            },
            Price = 0.05m, Weight = 0.1m, Type = EEquipmentType.Consumable
        };

        public static Equipment CaltropsBagOf20 = new Equipment
        {
            Name = new LocalizedString { EN = "Caltrops (bag of 20)", RU = "Калтропы (сумка 20 шт.)" },
            Description = new LocalizedString {
               EN = "As an action, you can spread a single bag of caltrops to cover a 5-foot-square area. Any creature that enters the area must succeed on a DC 15 Dexterity saving throw or stop moving and take I piercing damage. Until the creature regains at least I hit point, its walking speed is reduced by 10 feet. Acreature moving through the area at half speed doesn't need to make the saving throw.",
               RU = "Вы можете действием рассыпать сумку калтропов по площади в 5 × 5 футов. Все существа, входящие в эту область, должны преуспеть в спасброске Ловкости со Сл 15, иначе они останавливаются и получают колющий урон 1. Пока это существо не восстановит как минимум 1 хит, его скорость ходьбы уменьшена на 10 футов. Существо, перемещающееся по этой области с уменьшенной вдвое скоростью, не обязано совершать спасбросок."
            },
            Price = 0.05m, Weight = 0.1m, Type = EEquipmentType.Consumable,
            Quantity = 20
        };

        public static Equipment Candle = new Equipment
        {
            Name = new LocalizedString { EN = "Candle", RU = "Свеча" },
            Description = new LocalizedString {
               EN = "For I hour, a candle sheds bright light in a 5.foot radius and dim light for an additional 5 feet.",
               RU = "В течение 1 часа свеча испускает яркий свет в пределах радиуса 5 футов и тусклый свет в пределах ещё 5 футов."
            },
            Price = 0.01m, Weight = 0m, Type = EEquipmentType.Consumable
        };

        public static Equipment CaseCrossbowBolt = new Equipment
        {
            Name = new LocalizedString { EN = "Case, crossbow bolt", RU = "Футляр для болтов" },
            Description = new LocalizedString {
               EN = "This wooden case can hold up to twenty crossbow bolts.",
               RU = "В этот деревянный контейнер помещаются 20 арбалетных болтов."
            },
            Price = 1m, Weight = 1m, Type = EEquipmentType.Container
        };

        public static Equipment CaseMapOrScroll = new Equipment
        {
            Name = new LocalizedString { EN = "Case, map or scroll", RU = "Футляр для документов" },
            Description = new LocalizedString {
               EN = "This cylindricalleather case can hold up to ten rolled-up sheets of paper or tive rolled-up sheets of parchment.",
               RU = "В этом цилиндрическом кожаном тубусе может храниться до десяти скрученных листов бумаги или пять скрученных листов пергамента."
            },
            Price = 1m, Weight = 1m, Type = EEquipmentType.Container
        };

        public static Equipment Chain10Feet = new Equipment
        {
            Name = new LocalizedString { EN = "Chain (10 feet)", RU = "Цепь (10 футов)" },
            Description = new LocalizedString {
               EN = "Achain has 10 hit points. lt can be burst with a successful DC 20 Strength check.",
               RU = "У цепи 10 хитов. Её можно порвать успешной проверкой Силы со Сл 20."
            },
            Price = 5m, Weight = 10m, Type = EEquipmentType.Gear
        };

        public static Equipment Chalk1Piece = new Equipment
        {
            Name = new LocalizedString { EN = "Chalk (1 piece)", RU = "Мел (1 кусок)" },
            Price = 0.01m, Weight = 0m, Type = EEquipmentType.Consumable
        };

        public static Equipment Chest = new Equipment
        {
            Name = new LocalizedString { EN = "Chest", RU = "Сундук" },
            Description = new LocalizedString {
               EN = "Capacity: 12 cubic feel/300 pounds of gear",
               RU = "Вместимость: 12 кубических футов/300 фунтов (150 килограмм)"
            },
            Price = 5m, Weight = 25m, Type = EEquipmentType.Container
        };

        public static Equipment ClimbersKit = new Equipment
        {
            Name = new LocalizedString { EN = "Climber's kit", RU = "Комплект для лазания" },
            Description = new LocalizedString {
               EN = "Aclimber's kit includes special pitons, boot tips, gloves, and a harness. You can use the climber's kit as an action to anchor yourself; when you do, you can't fali more than 25 feet from the point where you anchored yourself, and you can't climb more than 25 feet away from that point without undoing the anchor.",
               RU = "В набор для лазания входят шлямбуры, накладные подошвы, перчатки и страховочная привязь. Вы можете действием использовать набор для лазания, чтобы закрепиться на высоте; если вы делаете это, вы не можете упасть более чем на 25 футов от того места, где закрепились, но и не можете подняться выше 25 футов от этого места, не открепившись."
            },
            Price = 25m, Weight = 12m, Type = EEquipmentType.Kit
        };

        public static Equipment ClothesCommon = new Equipment
        {
            Name = new LocalizedString { EN = "Clothes, common", RU = "Одежда, обычная" },
            Price = 0.5m, Weight = 3m, Type = EEquipmentType.Clothes
        };

        public static Equipment ClothesCostume = new Equipment
        {
            Name = new LocalizedString { EN = "Clothes, costume", RU = "Одежда, костюм" },
            Price = 5m, Weight = 4m, Type = EEquipmentType.Clothes
        };

        public static Equipment ClothesFine = new Equipment
        {
            Name = new LocalizedString { EN = "Clothes, fine", RU = "Одежда, отличная" },
            Price = 15m, Weight = 6m, Type = EEquipmentType.Clothes
        };

        public static Equipment ClothesTravelers = new Equipment
        {
            Name = new LocalizedString { EN = "Clothes, traveler's", RU = "Одежда, дорожная" },
            Price = 2m, Weight = 4m, Type = EEquipmentType.Clothes
        };

        public static Equipment ComponentPouch = new Equipment
        {
            Name = new LocalizedString { EN = "Component pouch", RU = "Мешочек с компонентами" },
            Description = new LocalizedString {
               EN = "A component pouch is a small, watertight leather belt pouch that has compartments to hold ali the material components and other special items you need to cast your spells, except for those components that have a specitic cost (as indicated in a spell's description).",
               RU = "Мешочек с компонентами это маленький водонепроницаемый кожаный поясной кошель с отделениями для хранения материальных компонентов и других особых предметов, нужных для накладывания заклинаний, если только у этих компонентов не указана стоимость (смотрите описание заклинания)."
            },
            Price = 25m, Weight = 2m, Type = EEquipmentType.Tool
        };

        public static Equipment Crowbar = new Equipment
        {
            Name = new LocalizedString { EN = "Crowbar", RU = "Ломик" },
            Description = new LocalizedString {
               EN = "Using a crowbar granls advantage to Strength checks where the crowbar's leverage can be applied.",
               RU = "Использование ломика позволяет совершать проверки Силы с преимуществом, если рычаг должен помочь."
            },
            Price = 2m, Weight = 5m, Type = EEquipmentType.Tool
        };

        public static Equipment SprigOfMistletoe = new Equipment
        {
            Name = new LocalizedString { EN = "Sprig of mistletoe", RU = "Веточка омелы" },
            Description = new LocalizedString {
               EN = "A druidic focus might be a sprig of mistletoe or holly, a wand or scepter made of yew or another special wood, a staff drawn whole out of a living tree, or a totem object incorporating feathers, fur, bones, and teeth from sacred animaIs. Adruid can use such an object as a spellcasting focus, as described in chapter 10.",
               RU = "Фокусировкой друида может быть веточка омелы или падуба, палочка или скипетр из тиса или другого дерева, посох, созданный из живого дерева, или тотем с перьями, мехом, костями и зубами священных животных. Друид может использовать эти предметы в качестве фокусировки для заклинаний, как описано в главе 10."
            },
            Price = 1m, Weight = 0m, Type = EEquipmentType.DruidicFocus
        };

        public static Equipment Totem = new Equipment
        {
            Name = new LocalizedString { EN = "Totem", RU = "Тотем" },
            Description = new LocalizedString {
               EN = "A druidic focus might be a sprig of mistletoe or holly, a wand or scepter made of yew or another special wood, a staff drawn whole out of a living tree, or a totem object incorporating feathers, fur, bones, and teeth from sacred animaIs. Adruid can use such an object as a spellcasting focus, as described in chapter 10.",
               RU = "Фокусировкой друида может быть веточка омелы или падуба, палочка или скипетр из тиса или другого дерева, посох, созданный из живого дерева, или тотем с перьями, мехом, костями и зубами священных животных. Друид может использовать эти предметы в качестве фокусировки для заклинаний, как описано в главе 10."
            },
            Price = 1m, Weight = 0m, Type = EEquipmentType.DruidicFocus
        };

        public static Equipment WoodenStaff = new Equipment
        {
            Name = new LocalizedString { EN = "Wooden staff", RU = "Деревянный посох" },
            Description = new LocalizedString {
               EN = "A druidic focus might be a sprig of mistletoe or holly, a wand or scepter made of yew or another special wood, a staff drawn whole out of a living tree, or a totem object incorporating feathers, fur, bones, and teeth from sacred animaIs. Adruid can use such an object as a spellcasting focus, as described in chapter 10.",
               RU = "Фокусировкой друида может быть веточка омелы или падуба, палочка или скипетр из тиса или другого дерева, посох, созданный из живого дерева, или тотем с перьями, мехом, костями и зубами священных животных. Друид может использовать эти предметы в качестве фокусировки для заклинаний, как описано в главе 10."
            },
            Price = 5m, Weight = 4m, Type = EEquipmentType.DruidicFocus
        };

        public static Equipment YewWand = new Equipment
        {
            Name = new LocalizedString { EN = "Yew wand", RU = "Тисовая палочка" },
            Description = new LocalizedString {
               EN = "A druidic focus might be a sprig of mistletoe or holly, a wand or scepter made of yew or another special wood, a staff drawn whole out of a living tree, or a totem object incorporating feathers, fur, bones, and teeth from sacred animaIs. Adruid can use such an object as a spellcasting focus, as described in chapter 10.",
               RU = "Фокусировкой друида может быть веточка омелы или падуба, палочка или скипетр из тиса или другого дерева, посох, созданный из живого дерева, или тотем с перьями, мехом, костями и зубами священных животных. Друид может использовать эти предметы в качестве фокусировки для заклинаний, как описано в главе 10."
            },
            Price = 10m, Weight = 1m, Type = EEquipmentType.DruidicFocus
        };

        public static Equipment FishingTackle = new Equipment
        {
            Name = new LocalizedString { EN = "Fishing tackle", RU = "Комплект для рыбалки" },
            Description = new LocalizedString {
               EN = "This kit includes a wooden rod, silken line, corkwood bobbers, steel hooks, lead sinkers, velvet lures, and narrow netting.",
               RU = "В этот набор входит удилище, шёлковая леска, пробковый поплавок, стальные крючки, свинцовые грузила, приманки из ниток и мелкоячеистая сеть."
            },
            Price = 1m, Weight = 4m, Type = EEquipmentType.Kit
        };

        public static Equipment FlaskOrTankard = new Equipment
        {
            Name = new LocalizedString { EN = "Flask or tankard", RU = "Фляга или большая кружка" },
            Description = new LocalizedString {
               EN = "Capacity: 1 pint liquid",
               RU = "Вместимость: 1 пинта (0,5 литра)"
            },
            Price = 0.02m, Weight = 1m, Type = EEquipmentType.Container
        };

        public static Equipment GrapplingHook = new Equipment
        {
            Name = new LocalizedString { EN = "Grappling hook", RU = "Крюк-кошка" },
            Price = 2m, Weight = 4m, Type = EEquipmentType.Gear
        };

        public static Equipment Hammer = new Equipment
        {
            Name = new LocalizedString { EN = "Hammer", RU = "Молоток" },
            Price = 1m, Weight = 3m, Type = EEquipmentType.Tool
        };

        public static Equipment HammerSledge = new Equipment
        {
            Name = new LocalizedString { EN = "Hammer, sledge", RU = "Молот кузнечный" },
            Price = 2m, Weight = 10m, Type = EEquipmentType.Tool
        };

        public static Equipment HealersKit = new Equipment
        {
            Name = new LocalizedString { EN = "Healer's kit", RU = "Комплект целителя" },
            Description = new LocalizedString {
               EN = "This kit is a leather pouch containing bandages, salves, and splints. The kit has ten uses. As an action, you can expend one use of the kit to stabilize a creature that has O hit points, without needing to make a Wisdom (Medicine) check.",
               RU = "Это кожаный кошель с бинтами, мазями и шинами. Набор годится для десяти использований. Вы можете действием потратить одно использование набора для стабилизации существа, у которого 0 хитов, не совершая проверку Мудрости (Медицина)."
            },
            Price = 2m, Weight = 10m, Type = EEquipmentType.Kit
        };

        public static Equipment Amulet = new Equipment
        {
            Name = new LocalizedString { EN = "Amulet", RU = "Амулет" },
            Description = new LocalizedString {
               EN = "A holy symbol is a representation of a god or pantheon. lt might be an amulet depicting a symbol representing a deity, the same symbol carefully engraved or inlaid as an emblem on a shield, or a tiny box holding a fragment of a sacred relic. Appendix B lists the symbols commonly associated with many gods in the multiverse. Acleric or paladin can use a holy symbol as a spellcasting focus, as described in chapter lO. To use the symbol in this way, the caster must hold it in hand, wear it visibly, or bear it on a shield.",
               RU = "Священный символ изображает божество или целый пантеон. Это может быть амулет, изображающий символ божества, символ, выгравированный или выложенный камнями в качестве эмблемы на щите, или крохотная коробочка, в которой хранится священная реликвия. В приложении Б приводится список символов, используемый для самых распространённых богов мультивселенной. Жрец или паладин может использовать священный символ в качестве фокусировки для заклинаний, как описано в главе 10. Для такого использования символа заклинатель должен держать его в руке, носить у всех на виду или нести на щите."
            },
            Price = 5m, Weight = 1m, Type = EEquipmentType.HolySymbol
        };

        public static Equipment Emblem = new Equipment
        {
            Name = new LocalizedString { EN = "Emblem", RU = "Эмблема" },
            Description = new LocalizedString {
               EN = "A holy symbol is a representation of a god or pantheon. lt might be an amulet depicting a symbol representing a deity, the same symbol carefully engraved or inlaid as an emblem on a shield, or a tiny box holding a fragment of a sacred relic. Appendix B lists the symbols commonly associated with many gods in the multiverse. Acleric or paladin can use a holy symbol as a spellcasting focus, as described in chapter lO. To use the symbol in this way, the caster must hold it in hand, wear it visibly, or bear it on a shield.",
               RU = "Священный символ изображает божество или целый пантеон. Это может быть амулет, изображающий символ божества, символ, выгравированный или выложенный камнями в качестве эмблемы на щите, или крохотная коробочка, в которой хранится священная реликвия. В приложении Б приводится список символов, используемый для самых распространённых богов мультивселенной. Жрец или паладин может использовать священный символ в качестве фокусировки для заклинаний, как описано в главе 10. Для такого использования символа заклинатель должен держать его в руке, носить у всех на виду или нести на щите."
            },
            Price = 5m, Weight = 0m, Type = EEquipmentType.HolySymbol
        };

        public static Equipment Reliquary = new Equipment
        {
            Name = new LocalizedString { EN = "Reliquary", RU = "Реликварий" },
            Description = new LocalizedString {
               EN = "A holy symbol is a representation of a god or pantheon. lt might be an amulet depicting a symbol representing a deity, the same symbol carefully engraved or inlaid as an emblem on a shield, or a tiny box holding a fragment of a sacred relic. Appendix B lists the symbols commonly associated with many gods in the multiverse. Acleric or paladin can use a holy symbol as a spellcasting focus, as described in chapter lO. To use the symbol in this way, the caster must hold it in hand, wear it visibly, or bear it on a shield.",
               RU = "Священный символ изображает божество или целый пантеон. Это может быть амулет, изображающий символ божества, символ, выгравированный или выложенный камнями в качестве эмблемы на щите, или крохотная коробочка, в которой хранится священная реликвия. В приложении Б приводится список символов, используемый для самых распространённых богов мультивселенной. Жрец или паладин может использовать священный символ в качестве фокусировки для заклинаний, как описано в главе 10. Для такого использования символа заклинатель должен держать его в руке, носить у всех на виду или нести на щите."
            },
            Price = 5m, Weight = 2m, Type = EEquipmentType.HolySymbol
        };

        public static Equipment HolyWaterFlask = new Equipment
        {
            Name = new LocalizedString { EN = "Holy water (flask)", RU = "Святая вода (фляга)" },
            Description = new LocalizedString {
               EN = "As an action, you can splash the contents of this lIask onto a creature within 5 feet of you or throw it up to 20 feet, shattering it on impact. In either case, make a ranged attack against a target creature, treating the holy water as an improvised weapon. If the target is a tiend or undead, it takes 2d6 radiant damage.",
               RU = "Вы можете действием облить содержимым этой фляги существо, находящееся в пределах 5 футов, или кинуть флягу на 20 футов, ломая при ударе. Совершите дальнобойную атаку по целевому существу, считая святую воду импровизированным оружием. Если цель — изверг или нежить, она получает урон излучением 2к6.<br>Жрец или паладин может создать святую воду, исполнив особый ритуал. Этот ритуал исполняется 1 час, использует толчёное серебро на 25 зм и требует, чтобы заклинатель потратил ячейку заклинаний 1 уровня."
            },
            Price = 25m, Weight = 1m, Type = EEquipmentType.Consumable
        };

        public static Equipment Hourglass = new Equipment
        {
            Name = new LocalizedString { EN = "Hourglass", RU = "Песочные часы" },
            Price = 25m, Weight = 1m, Type = EEquipmentType.Gear
        };

        public static Equipment HuntingTrap = new Equipment
        {
            Name = new LocalizedString { EN = "Hunting trap", RU = "Охотничий капкан" },
            Description = new LocalizedString {
               EN = "When you use your action to set it, this trap forms a saw-toothed steel ring that snaps shut when a creature steps on apressure plate in the center. The trap is affixed bya heavy chain to an immobi!e object, such as a tree ar a <a href='https://tentaculus.ru/equipment/#q=spike'>spike</a> driven into the ground. A creature that steps on the plate must succeed on a DC 13 Dexterity saving throw ar take Id4 piercing damage and stop moving. Thereafter, unti! the creature breaks free of the trap, its movement is limited by the length of the chain (typically 3 feet long). Acreature can use its action to make a DC 13 5trength check, freeing itself ar another creature within its reach on a success. Each fai!ed check deals 1 piercing damage to the trapped creature.",
               RU = "Если вы действием установите эту ловушку, она образует стальное кольцо с зазубренными краями, которая захлопывается, когда в её центр наступает существо. Капкан привязывается толстой цепью к неподвижному предмету, такому как дерево или <a href='https://tentaculus.ru/equipment/#q=spike'>колышек</a>, вбитый в землю. Существо, наступившее в центр, должно преуспеть в спасброске Ловкости со Сл 13, иначе оно получает колющий урон 1к4 и прекращает перемещение. Впоследствии, пока существо не высвободится из ловушки, его перемещения ограничены длиной цепи (обычно 1 метр). Любое существо может действием совершить проверку Силы со Сл 13, чтобы высвободить себя или другое существо, находящееся в пределах досягаемости. Каждая проваленная проверка причиняет пойманному существу колющий урон 1."
            },
            Price = 5m, Weight = 25m, Type = EEquipmentType.Gear
        };

        public static Equipment Ink1OunceBottle = new Equipment
        {
            Name = new LocalizedString { EN = "Ink (1 ounce bottle)", RU = "Чернила (бутылочка 30 грамм)" },
            Price = 10m, Weight = 0m, Type = EEquipmentType.Consumable
        };

        public static Equipment InkPen = new Equipment
        {
            Name = new LocalizedString { EN = "Ink pen", RU = "Писчее перо" },
            Price = 0.02m, Weight = 0m, Type = EEquipmentType.Tool
        };

        public static Equipment JugOrPitcher = new Equipment
        {
            Name = new LocalizedString { EN = "Jug or pitcher", RU = "Кувшин или графин" },
            Description = new LocalizedString {
               EN = "Capacity: 1 gallon liquid",
               RU = "Вместимость: 1 галлон (3,75 литра)"
            },
            Price = 0.02m, Weight = 4m, Type = EEquipmentType.Container
        };

        public static Equipment Ladder10foot = new Equipment
        {
            Name = new LocalizedString { EN = "Ladder (10-foot)", RU = "Лестница (10 футов)" },
            Price = 0.1m, Weight = 25m, Type = EEquipmentType.Gear
        };

        public static Equipment Lamp = new Equipment
        {
            Name = new LocalizedString { EN = "Lamp", RU = "Лампа" },
            Description = new LocalizedString {
               EN = "A lamp casts bright light in a 15-foot radius and dim light for an additional 30 feet. Once lit, il burns for 6 hours on a flask (1 pint) of oil.",
               RU = "Лампа испускает яркий свет в пределах 15 футов и тусклый свет в пределах ещё 30 футов. Зажжённая лампа горит 6 часов от одной фляги (1 пинта [0,5 литра]) масла."
            },
            Price = 0.5m, Weight = 1m, Type = EEquipmentType.Tool
        };

        public static Equipment LanternBullseye = new Equipment
        {
            Name = new LocalizedString { EN = "Lantern, bullseye", RU = "Фонарь, направленный" },
            Description = new LocalizedString {
               EN = "A bullseye lantern casts bright light in a 60-foot cone and dim light for an additional 60 feet. Once lit, it burns for 6 hours on a flask (1 pint) of oil.",
               RU = "Направленный фонарь испускает яркий свет 60-футовым конусом и тусклый свет в пределах ещё 60 футов. Зажжённый фонарь горит 6 часов от одной фляги (1 пинта [0,5 литра]) масла."
            },
            Price = 10m, Weight = 2m, Type = EEquipmentType.Tool
        };

        public static Equipment LanternHooded = new Equipment
        {
            Name = new LocalizedString { EN = "Lantern, hooded", RU = "Фонарь, закрытый" },
            Description = new LocalizedString {
               EN = "A hooded lantern casts bright light in a 30-foot radius and dim light for an additional 30 feet. Once lit, it burns for 6 hours on a flask (1 pinl) of oil. As an action, you can lower the hood, reducing the light lo dim light in a 5-foot radius.",
               RU = "Закрытый фонарь испускает яркий свет в пределах 30 футов и тусклый свет в пределах ещё 30 футов. Зажжённый фонарь горит 6 часов от одной фляги (1 пинта [0,5 литра]) масла. Вы можете действием опустить козырёк, уменьшив освещение до тусклого света в пределах 5 футов."
            },
            Price = 5m, Weight = 2m, Type = EEquipmentType.Tool
        };

        public static Equipment Lock = new Equipment
        {
            Name = new LocalizedString { EN = "Lock", RU = "Замóк" },
            Description = new LocalizedString {
               EN = "A key is provided with the lock. Without the key, a creature proticient with thieves' toois can pick this lock with a successful DC 15 Dexterity check. Vour DM may decide that better locks are available for higher prices.",
               RU = "Вместе с замком идёт и ключ. Без ключа существо, владеющее воровскими инструментами, может вскрыть замок успешной проверкой Ловкости со Сл 15. Мастер может решить, что есть более качественные замки, стоящие больше."
            },
            Price = 10m, Weight = 1m, Type = EEquipmentType.Gear
        };

        public static Equipment MagnifyingGlass = new Equipment
        {
            Name = new LocalizedString { EN = "Magnifying glass", RU = "Увеличительное стекло" },
            Description = new LocalizedString {
               EN = "This lens allows a closer look at small objects. It is also useful as a substitute for flint and steel when starting tires. Lighting a fire with a magnifying glass requires light as bright as sunlight to focus, tinder to ignite, and about 5 minutes for the fire to ignite. A magnifying glass grants advantage on any ability check made to appraise ar inspect an item that is small ar highly detailed.",
               RU = "Эта линза позволяет разглядывать маленькие предметы. Линзу также можно использовать для замены кремня и кресала. Разжигание огня увеличительным стеклом требует света, яркого как свет солнца, трута для розжига и примерно 5 минут. Увеличительное стекло позволяет совершать с преимуществом проверки характеристик, сделанных для оценки или исследования мелких и высокодетализированных предметов."
            },
            Price = 100m, Weight = 0m, Type = EEquipmentType.Tool
        };

        public static Equipment Manacles = new Equipment
        {
            Name = new LocalizedString { EN = "Manacles", RU = "Кандалы" },
            Description = new LocalizedString {
               EN = "These metal restraints can bind a 5mall ar Medium creature. Escaping the manacles requires a successful DC 20 Dexterity check. Breaking them requires a successful DC 20 5trength check. Each set of manacles comes with one key. Without the key, a creature pro/icient with thieves' tools can pick the manacles' lock with a successful DC 15 Dexterity check. Manacles have 15 hit points.",
               RU = "Эти металлические оковы удерживают существ Маленького и Среднего размера. Для того чтобы сбежать из кандалов, требуется успешная проверка Ловкости со Сл 20. Для того чтобы их сломать, требуется проверка Силы со Сл 20. Каждый набор кандалов идёт с одним ключом. Без ключа существо, владеющее воровскими инструментами, может вскрыть замок кандалов успешной проверкой Ловкости со Сл 15. У кандалов 15 хитов"
            },
            Price = 2m, Weight = 6m, Type = EEquipmentType.Gear
        };

        public static Equipment MessKit = new Equipment
        {
            Name = new LocalizedString { EN = "Mess kit", RU = "Столовый набор" },
            Description = new LocalizedString {
               EN = "This tin box contains a cup and simple cutlery. The box clamps together, and one side can be used as a cooking pan and the other as a plate or shallow bowl.",
               RU = "В этой небольшой коробке находится чашка и простые столовые приборы. Коробка раскрывается, и одна сторона может использоваться как сковорода, а другая — как тарелка или неглубокая миска."
            },
            Price = 0.2m, Weight = 1m, Type = EEquipmentType.Kit
        };

        public static Equipment MirrorSteel = new Equipment
        {
            Name = new LocalizedString { EN = "Mirror, steel", RU = "Зеркало, стальное" },
            Price = 5m, Weight = 0.5m, Type = EEquipmentType.Gear
        };

        public static Equipment OilFlask = new Equipment
        {
            Name = new LocalizedString { EN = "Oil (flask)", RU = "Масло (фляга)" },
            Description = new LocalizedString {
               EN = "Oil usually comes in a clay flask that holds 1pintoAs an action, you can splash the oi! in this flaskanta a creature within 5 feet of you ar throw it up to20 feet, shattering it on impacto Make a ranged attackagainst a target creature ar object, treating the oil asan improvised weapon. On a hit, the target is coveredin oil. If the larget takes any /ire damage before the oildries (after 1 minute), the target takes an additional 5 fire damagc from the burning oil. Vou can also pour a flask of oi! on the ground to cover a 5-foot-square area, provided that the surface is leveI. Ir lit. the oi! burns for 2 rounds and deals 5 tire damage to any creature that enters the area ar ends its turn in the area, A creature can take this damage only once per turno",
               RU = "Обычно масло продаётся в глиняных флягах по 1 пинте (0,5 литра). Вы можете действием облить маслом из фляги существо, находящееся в пределах 5 футов, или кинуть её на 20 футов, ломая при ударе. Совершите дальнобойную атаку по целевому существу или предмету, считая масло импровизированным оружием. При попадании цель покрывается маслом. Если цель получает урон огнём, пока масло не высохло (1 минута), она получает дополнительный урон огнём 5 от горящего масла. Вы можете также вылить фляжку масла на землю, покрыв площадь 5 × 5 футов, при условии, что пол ровный. Если теперь масло поджечь, оно горит 2 раунда и причиняет урон огнём 5 всем существам, входящим в эту область или оканчивающим в ней ход. Существо может получить этот урон только один раз за ход."
            },
            Price = 0.1m, Weight = 1m, Type = EEquipmentType.Consumable
        };

        public static Equipment ParchmentOneSheet = new Equipment
        {
            Name = new LocalizedString { EN = "Parchment (one sheet)", RU = "Пергамент (1 лист)" },
            Price = 0.1m, Weight = 0m, Type = EEquipmentType.Consumable
        };

        public static Equipment PaperOneSheet = new Equipment
        {
            Name = new LocalizedString { EN = "Paper (one sheet)", RU = "Бумага (1 лист)" },
            Price = 0.2m, Weight = 0m, Type = EEquipmentType.Consumable
        };

        public static Equipment PerfumeVial = new Equipment
        {
            Name = new LocalizedString { EN = "Perfume (vial)", RU = "Духи́ (флакон)" },
            Price = 5m, Weight = 0m, Type = EEquipmentType.Consumable
        };

        public static Equipment PiekMiners = new Equipment
        {
            Name = new LocalizedString { EN = "Piek, miner's", RU = "Кирка, горняцкая" },
            Price = 2m, Weight = 10m, Type = EEquipmentType.Tool
        };

        public static Equipment Piton = new Equipment
        {
            Name = new LocalizedString { EN = "Piton", RU = "Шлямбур" },
            Price = 0.05m, Weight = 0.25m, Type = EEquipmentType.Gear
        };

        public static Equipment PoisonBasicVial = new Equipment
        {
            Name = new LocalizedString { EN = "Poison, basic (vial)", RU = "Яд, простой (флакон)" },
            Description = new LocalizedString {
               EN = "Vou can use the poison in Ihis via IlOcoat one slashing or piercing weapon or up to threepieces of ammunition. Applying the poison takesan action. A creature hit by the poisoned weapon orammunition must make a DC 10 Constitution savingthrow or take 1d4 poison damage. Once applied, thepoison retains potency for I minute before drying.",
               RU = "Вы можете покрыть ядом из этого флакона одно рубящее или колющее оружие или три боеприпаса. Наносится яд одним действием. Существо, по которому попадёт отравленное оружие или боеприпас, должно совершить спасбросок Телосложения со Сл 10, получая в случае провала урон ядом 1к4. Нанесённый яд эффективен 1 минуту, после чего высыхает."
            },
            Price = 100m, Weight = 0m, Type = EEquipmentType.Consumable
        };

        public static Equipment Pole10foot = new Equipment
        {
            Name = new LocalizedString { EN = "Pole (10-foot)", RU = "Шест (10 футов)" },
            Price = 0.05m, Weight = 7m, Type = EEquipmentType.Gear
        };

        public static Equipment PotIron = new Equipment
        {
            Name = new LocalizedString { EN = "Pot, iron", RU = "Горшок, железный" },
            Description = new LocalizedString {
               EN = "Capacity: 1 gallon liquid",
               RU = "Вместимость: 1 галлон (3,75 литра)"
            },
            Price = 2m, Weight = 10m, Type = EEquipmentType.Tool
        };

        public static Equipment PotionOfHealing = new Equipment
        {
            Name = new LocalizedString { EN = "Potion of healing", RU = "Зелье лечения" },
            Description = new LocalizedString {
               EN = "Character who drinks the magical red fiuid in this vial regains 2d4 + 2 hit points. Drinking or administering a potion takes an action.",
               RU = "Существо, выпившее магическую красную жидкость из этого флакона, восстанавливает 2к4 + 2 хита. Зелье выпивается или заливается в рот другому действием."
            },
            Price = 50m, Weight = 0.5m, Type = EEquipmentType.Consumable
        };

        public static Equipment Pouch = new Equipment
        {
            Name = new LocalizedString { EN = "Pouch", RU = "Кошель" },
            Description = new LocalizedString {
               EN = "A c1oth or leather pouch can hold up to 20 sling bullets or 50 blowgun needles, among other things. A compartmentalized pouch for holding spell components is called a component pouch.<br>Capacity: 1/5 cubic foot/6 pounds of gear",
               RU = "В кожаном или тканевом кошеле поместится 20 снарядов для пращи или 50 иголок для духовой трубки, а также другие вещи. Кошель с отделениями для хранения компонентов заклинаний называется мешочком с компонентами.<br>0,2 кубических фута/6 фунтов (3 килограмма)"
            },
            Price = 0.5m, Weight = 1m, Type = EEquipmentType.Container
        };

        public static Equipment Quiver = new Equipment
        {
            Name = new LocalizedString { EN = "Quiver", RU = "Колчан" },
            Description = new LocalizedString {
               EN = "Quiver can hold up to 20 arrows.",
               RU = "В колчан помещается 20 стрел."
            },
            Price = 1m, Weight = 1m, Type = EEquipmentType.Container
        };

        public static Equipment RamPortable = new Equipment
        {
            Name = new LocalizedString { EN = "Ram, portable", RU = "Таран, переносной" },
            Description = new LocalizedString {
               EN = "Vou can use a portable ram to break down doors. When doing so, you gain a +4 bonus on the Strength check. One other character can help you use the ram, giving you advantage on this check.",
               RU = "Вы можете вышибать портативным тараном двери. Вы получаете бонус +4 к проверкам Силы. Если другой персонаж помогает вам использовать таран, вы совершаете проверку с преимуществом."
            },
            Price = 4m, Weight = 35m, Type = EEquipmentType.Gear
        };

        public static Equipment Rations1Day = new Equipment
        {
            Name = new LocalizedString { EN = "Rations (1 day)", RU = "Рационы (1 день)" },
            Description = new LocalizedString {
               EN = "Rations consist of dry foods suitable for extended travei, including jerky, dried fruit, hardlack, and nuts.",
               RU = "Рационы состоят из обезвоженной пищи, подходящей для путешествий, включая вяленое мясо, сухофрукты, галеты и орехи."
            },
            Price = 0.5m, Weight = 2m, Type = EEquipmentType.Consumable
        };

        public static Equipment Robes = new Equipment
        {
            Name = new LocalizedString { EN = "Robes", RU = "Ряса" },
            Price = 1m, Weight = 4m, Type = EEquipmentType.Clothes
        };

        public static Equipment RopeHempen50Feet = new Equipment
        {
            Name = new LocalizedString { EN = "Rope, hempen (50 feet)", RU = "Верёвка пеньковая (50 футов)" },
            Description = new LocalizedString {
               EN = "Rope, whether made of hemp or silk, has 2 hit points and can be burst with a DC 17 Strenglh check.",
               RU = "У верёвки, сделанной из пеньки или шёлка, 2 хита, и её можно порвать проверкой Силы со Сл 17."
            },
            Price = 1m, Weight = 10m, Type = EEquipmentType.Gear
        };

        public static Equipment RopeSilk50Feet = new Equipment
        {
            Name = new LocalizedString { EN = "Rope, silk (50 feet)", RU = "Верёвка, шёлковая (50 футов)" },
            Description = new LocalizedString {
               EN = "Rope, whether made of hemp or silk, has 2 hit points and can be burst with a DC 17 Strenglh check.",
               RU = "У верёвки, сделанной из пеньки или шёлка, 2 хита, и её можно порвать проверкой Силы со Сл 17."
            },
            Price = 10m, Weight = 5m, Type = EEquipmentType.Gear
        };

        public static Equipment Sack = new Equipment
        {
            Name = new LocalizedString { EN = "Sack", RU = "Мешок" },
            Description = new LocalizedString {
               EN = "Capacity: 1 cubic f001/30 pounds of gear",
               RU = "Вместимость: 1 кубический фут/30 фунтов (15 килограмм)"
            },
            Price = 0.01m, Weight = 0.5m, Type = EEquipmentType.Container
        };

        public static Equipment ScaleMerchants = new Equipment
        {
            Name = new LocalizedString { EN = "Scale, merchant's", RU = "Весы, торговые" },
            Description = new LocalizedString {
               EN = "A scale includes a small balance,pans, and a suitable assortment of weights up to 2pounds. With it, you can measure the exact weight ofsmall objects, such as raw precious metais or tradegoods, to help determine their worth.",
               RU = "В набор входят рычажные весы, чашки и набор грузиков на 2 фунта. С их помощью можно точно измерять вес небольших предметов, таких как драгоценные металлы или товары."
            },
            Price = 5m, Weight = 3m, Type = EEquipmentType.Tool
        };

        public static Equipment SealingWax = new Equipment
        {
            Name = new LocalizedString { EN = "Sealing wax", RU = "Сургуч" },
            Price = 0.5m, Weight = 0m, Type = EEquipmentType.Consumable
        };

        public static Equipment Shovel = new Equipment
        {
            Name = new LocalizedString { EN = "Shovel", RU = "Лопата" },
            Price = 2m, Weight = 5m, Type = EEquipmentType.Tool
        };

        public static Equipment SignalWhistle = new Equipment
        {
            Name = new LocalizedString { EN = "Signal whistle", RU = "Сигнальный свисток" },
            Price = 0.05m, Weight = 0m, Type = EEquipmentType.Tool
        };

        public static Equipment SignetRing = new Equipment
        {
            Name = new LocalizedString { EN = "Signet ring", RU = "Кольцо-печатка" },
            Price = 5m, Weight = 0m, Type = EEquipmentType.Tool
        };

        public static Equipment Soap = new Equipment
        {
            Name = new LocalizedString { EN = "Soap", RU = "Мыло" },
            Price = 0.02m, Weight = 0m, Type = EEquipmentType.Consumable
        };

        public static Equipment Spellbook = new Equipment
        {
            Name = new LocalizedString { EN = "Spellbook", RU = "Книга заклинаний" },
            Description = new LocalizedString {
               EN = "Essential for wizards, a spellbook is a lealher.bound tome wilh 100 blank vellum pages suitable for recording spells.",
               RU = "Книги заклинаний очень важны для волшебников. Это переплетённые кожей тома, содержащие 100 пустых пергаментных страниц, на которых можно записывать заклинания."
            },
            Price = 50m, Weight = 3m, Type = EEquipmentType.Tool
        };

        public static Equipment SpikesIron10 = new Equipment
        {
            Name = new LocalizedString { EN = "Spikes, iron (10)", RU = "Шипы, железные (10)" },
            Price = 1m, Weight = 5m, Type = EEquipmentType.Consumable
        };

        public static Equipment Spyglass = new Equipment
        {
            Name = new LocalizedString { EN = "Spyglass", RU = "Подзорная труба" },
            Description = new LocalizedString {
               EN = "Objeets viewed through a spyglass are magnitied to twice their size.",
               RU = "Предметы, на которые смотрят в подзорную трубу, увеличиваются в два раза"
            },
            Price = 1000m, Weight = 1m, Type = EEquipmentType.Gear
        };

        public static Equipment TentTwoperson = new Equipment
        {
            Name = new LocalizedString { EN = "Tent, two-person", RU = "Палатка, двуместная" },
            Description = new LocalizedString {
               EN = "A simple and portable canvas shelter, a tent sleeps two.",
               RU = "В палатке, простом парусиновом жилище, могут спать двое."
            },
            Price = 2m, Weight = 20m, Type = EEquipmentType.Camp
        };

        public static Equipment Tinderbox = new Equipment
        {
            Name = new LocalizedString { EN = "Tinderbox", RU = "Трутница" },
            Description = new LocalizedString {
               EN = "This small container holds fiint, tire steel,and tinder (usually dry c10th soaked in Iight oil) used lokindle a tire. Using it to Iight a torch-or anything elsewith abundant, exposed fuel-takes an action. Lightingany olher tire takes 1 minute.",
               RU = "В этом небольшом контейнере находится кремень, кресало и трут (обычно это сухая тряпка, вымоченная в масле), используемые для разжигания огня. Использование его для разжигания факела — или чего-нибудь другого, легковоспламеняющегося — требует одного действия. Разжигание другого огня требует 1 минуты."
            },
            Price = 0.5m, Weight = 1m, Type = EEquipmentType.Tool
        };

        public static Equipment Torch = new Equipment
        {
            Name = new LocalizedString { EN = "Torch", RU = "Факел" },
            Description = new LocalizedString {
               EN = "A torch burns for 1 hour, providing bright Iight in a 20.foot radius and dim light for an additional 20 fee!. If you make a melee attack with a burning torch and hit, it deals 1 tire damage.",
               RU = "Факел горит 1 час, испуская яркий свет в пределах 20 футов и тусклый свет в пределах ещё 20 футов. Если вы совершаете рукопашную атаку горящим факелом и попадаете, он причиняет урон огнём 1."
            },
            Price = 0.01m, Weight = 1m, Type = EEquipmentType.Consumable
        };

        public static Equipment Vial = new Equipment
        {
            Name = new LocalizedString { EN = "Vial", RU = "Флакон" },
            Description = new LocalizedString {
               EN = "Capacity: 4 ounces liquid",
               RU = "Вместимость: 4 унции (100 грамм)"
            },
            Price = 1m, Weight = 0m, Type = EEquipmentType.Container
        };

        public static Equipment Waterskin = new Equipment
        {
            Name = new LocalizedString { EN = "Waterskin", RU = "Бурдюк" },
            Description = new LocalizedString {
               EN = "Capacity: pinls liquid<br>(Weight is for full waterscin)",
               RU = "Вместимость: 4 пинты (2 литра)<br>(Вес указан для заполненного бурдюка)"
            },
            Price = 0.2m, Weight = 5m, Type = EEquipmentType.Container
        };

        public static Equipment Whetstone = new Equipment
        {
            Name = new LocalizedString { EN = "Whetstone", RU = "Точильный камень" },
            Price = 0.01m, Weight = 1m, Type = EEquipmentType.Tool
        };

        public static Equipment String10ft = new Equipment
        {
            Name = new LocalizedString { EN = "10 foots of string", RU = "10 футов лески" },
            Type = EEquipmentType.Gear
        };

        public static Equipment AlmsBox = new Equipment
        {
            Name = new LocalizedString { EN = "Alms box", RU = "Коробка для пожертвований" },
            Type = EEquipmentType.Tool
        };

        public static Equipment BlocksOfIncense = new Equipment
        {
            Name = new LocalizedString { EN = "Blocks of incense", RU = "Благовония" },
            Type = EEquipmentType.Tool
        };

        public static Equipment Censer = new Equipment
        {
            Name = new LocalizedString { EN = "Censer", RU = "Кадило" },
            Type = EEquipmentType.Tool
        };

        public static Equipment Vestments = new Equipment
        {
            Name = new LocalizedString { EN = "Vestments", RU = "Облачение священника" },
            Type = EEquipmentType.Clothes
        };

        public static Equipment BagOfSand = new Equipment
        {
            Name = new LocalizedString { EN = "Small bag of sand", RU = "Небольшой мешочек с песком" },
            Type = EEquipmentType.Clothes
        };

        public static Equipment SmallKnife = new Equipment
        {
            Name = new LocalizedString { EN = "Small knife", RU = "Небольшой нож" },
            Type = EEquipmentType.Clothes
        };
    }
}
