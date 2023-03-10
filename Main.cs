using MacNCheese.Customs.MacNCheeseProcess;
using MacNCheese.Registry;
using MacNCheese.Dishes;
using KitchenData;
using KitchenLib;
using KitchenLib.References;
using KitchenLib.Utils;
using KitchenMods;
using KitchenLib.Event;
using System.IO;
using System.Linq;
using System.Reflection;
using UnityEngine;
using ItemReference = KitchenLib.References.ItemReferences;

namespace MacNCheese
{
    class Main : BaseMod
    {
        internal const string MOD_ID = "MacAndCheese";
        internal const string MOD_NAME = "Mac and Cheese";
        internal const string MOD_VERSION = "0.1.2";
        internal const string MOD_AUTHOR = "MzEvilCanadian";
        public const string MOD_GAMEVERSION = ">=1.1.3";

        public static AssetBundle bundle;

        // Processes
        internal static Process Cook => GetExistingGDO<Process>(ProcessReferences.Cook);
        internal static Process Chop => GetExistingGDO<Process>(ProcessReferences.Chop);

        // Vanilla items
        internal static Item Pot => GetExistingGDO<Item>(ItemReference.Pot);
        internal static Item Water => GetExistingGDO<Item>(ItemReference.Water);
        internal static Item Cheese => GetExistingGDO<Item>(ItemReference.Cheese);
        internal static Item CheeseChopped => GetExistingGDO<Item>(ItemReference.CheeseGrated);
        internal static Item Plate => GetExistingGDO<Item>(ItemReference.Plate);

        // IngredientLib Items
        public static Item Milk => Find<Item>(IngredientLib.References.GetIngredient("Milk"));
        public static Item MilkIngredient => Find<Item>(IngredientLib.References.GetSplitIngredient("Milk"));
        public static Item ButterBlock => Find<Item>(IngredientLib.References.GetIngredient("Butter"));
        public static Item ButterSlice => Find<Item>(IngredientLib.References.GetSplitIngredient("Butter"));
        public static Item CookedMacaroni => Find<Item>(IngredientLib.References.GetIngredient("cooked potted macaroni"));
        public static Item Macaroni => Find<Item>(IngredientLib.References.GetIngredient("macaroni"));



        internal static Item CookedMacNCheesePot  => GetModdedGDO<Item, CookedMacNCheesePot>();
        internal static Item CookedMacNCheeseHalfPot => GetModdedGDO<Item, CookedMacNCheeseHalfPot>();
        internal static Item MacNCheeseServing => GetModdedGDO<Item, MacNCheeseServing>();
        internal static ItemGroup PlatedServing => GetModdedGDO<ItemGroup, PlatedServing>();
        internal static Dish MacNCheeseDish => GetModdedGDO<Dish, MacNCheeseDish>();


        internal static bool debug = true;
        public static void LogInfo(string _log) { Debug.Log($"[{MOD_NAME}] " + _log); }
        public static void LogInfo(object _log) { LogInfo(_log.ToString()); }

        public Main() : base(MOD_ID, MOD_NAME, MOD_AUTHOR, MOD_VERSION, $"{MOD_GAMEVERSION}", Assembly.GetExecutingAssembly())
        {
            string bundlePath = Path.Combine(new string[] { Directory.GetParent(Application.dataPath).FullName, "Mods", ModID });

            Debug.Log($"{MOD_NAME} {MOD_VERSION} {MOD_AUTHOR}: Loaded");
            Debug.Log($"Assets Loaded From {bundlePath}");
        }
        public override void PostActivate(KitchenMods.Mod mod)
        {
            base.PostActivate(mod);
            bundle = mod.GetPacks<AssetBundleModPack>().SelectMany(e => e.AssetBundles).ToList()[0];

            AddGameDataObject<UncookedPot>();
            AddGameDataObject<PlatedServing>();
            AddGameDataObject<MacNCheeseServing>();
            AddGameDataObject<CookedMacNCheesePot>();
            AddGameDataObject<CookedMacNCheeseHalfPot>();
            AddGameDataObject<MacNCheeseDish>();

            Events.BuildGameDataEvent += delegate (object s, BuildGameDataEventArgs args)
            {
                ModRegistry.HandleBuildGameDataEvent(args);
            };
        }
        protected override void OnUpdate() { }
        private static T1 GetModdedGDO<T1, T2>() where T1 : GameDataObject
        {
            return (T1)GDOUtils.GetCustomGameDataObject<T2>().GameDataObject;
        }
        private static T GetExistingGDO<T>(int id) where T : GameDataObject
        {
            return (T)GDOUtils.GetExistingGDO(id);
        }
        internal static T Find<T>(int id) where T : GameDataObject
        {
            return (T)GDOUtils.GetExistingGDO(id) ?? (T)GDOUtils.GetCustomGameDataObject(id)?.GameDataObject;
        }
    }
}
