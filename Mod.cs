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
    class Mod
    {
        internal const string MOD_ID = "MacAndCheese";
        internal const string MOD_NAME = "Mac and Cheese";
        internal const string MOD_VERSION = "0.0.1";
        internal const string MOD_AUTHOR = "MzEvilCanadian";
        internal const string PLATEUP_VERSION = "1.1.2";

        public static AssetBundle bundle;

        internal static Process Cook => GetExistingGDO<Process>(ProcessReferences.Cook);
        internal static Process Chop => GetExistingGDO<Process>(ProcessReferences.Chop);
        internal static Item Pot => GetExistingGDO<Item>(ItemReference.Pot);
        internal static Item Water => GetExistingGDO<Item>(ItemReference.Water);
        internal static Item Cheese => GetExistingGDO<Item>(ItemReference.Cheese);

        public static Item Milk => Find<Item>(IngredientLib.References.IngredientReferences.Milk);
        public static Item MilkIngredient => Find<Item>(IngredientLib.References.SplitIngredientReferences.Milk);
        public static Item Butter => Find<Item>(IngredientLib.References.IngredientReferences.Butter);
        //Not Implimented yet
        //public static Item Pasta => Find<Item>(IngredientLib.References.IngredientReferences.Pasta);

        internal static ItemGroup UncookedPasta => GetModdedGDO<ItemGroup, UncookedPasta>();
        internal static Item CookedPasta => GetModdedGDO<Item, CookedPasta>();
        internal static ItemGroup UncookedMacNCheese => GetModdedGDO<ItemGroup, UncookedMacNCheese>();
        internal static Item CookedMacNCheesePot  => GetModdedGDO<Item, CookedMacNCheesePot>();
        internal static Item MacNCheeseServing => GetModdedGDO<Item, MacNCheeseServing>();

        internal static bool debug = true;
        public static void LogInfo(string _log) { Debug.Log($"[{MOD_NAME}] " + _log); }
        public static void LogInfo(object _log) { LogInfo(_log.ToString()); }

        public Mod() : base(MOD_ID, MOD_NAME, MOD_AUTHOR, MOD_VERSION, $"{PLATEUP_VERSION}", Assembly.GetExecutingAssembly())
        {
            string bundlePath = Path.Combine(new string[] { Directory.GetParent(Application.dataPath).FullName, "Mods", ModID });

            Debug.Log($"{MOD_NAME} {MOD_VERSION} {MOD_AUTHOR}: Loaded");
            Debug.Log($"Assets Loaded From {bundlePath}");
        }
        public override void PostActivate(KitchenMods.Mod mod)
        {
            base.PostActivate(mod);
            bundle = mod.GetPacks<AssetBundleModPack>().SelectMany(e => e.AssetBundles).ToList()[0];

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
