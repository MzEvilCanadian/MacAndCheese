using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace MacNCheese.Customs.MacNCheeseProcess
{
    class UncookedMacCheeseMilkandButter : CustomItemGroup
    {
        public override string UniqueNameID => "Uncooked Mac Cheese Milk and Butter";
        public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("Uncooked Mac Pot");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.Dish;

        public override List<ItemGroup.ItemSet> Sets => new List<ItemGroup.ItemSet>()
        {
            new ItemGroup.ItemSet()
            {
                Max = 1,
                Min = 1,
                Items = new List<Item>()
                {
                    Main.UncookedMacCheeseandMilk
                }
            },
            new ItemGroup.ItemSet()
            {
                Max = 1,
                Min = 1,
                Items = new List<Item>()
                {
                    Main.ButterSlice
                }
            }
        };
        public override List<Item.ItemProcess> Processes => new List<Item.ItemProcess>
        {
            new Item.ItemProcess
            {
                Duration = 7,
                Process = Main.Cook,
                Result = Main.CookedMacNCheesePot
            }
        };

        public override void OnRegister(GameDataObject gameDataObject)
        {
            var materials = new Material[]
            {
                   MaterialUtils.GetExistingMaterial("Metal"),
             };
            MaterialUtils.ApplyMaterial(Prefab, "Pot", materials);
            materials[0] = MaterialUtils.GetExistingMaterial("Metal - Dark");
            MaterialUtils.ApplyMaterial(Prefab, "Handles", materials);
            materials[0] = MaterialUtils.GetExistingMaterial("Piano White");
            MaterialUtils.ApplyMaterial(Prefab, "Milk", materials);
            materials[0] = MaterialUtils.GetExistingMaterial("IngredientLib - \"Egg Dough\"");
            MaterialUtils.ApplyMaterial(Prefab, "Mac", materials);
            materials[0] = MaterialUtils.GetExistingMaterial("IngredientLib- \"Butter\"");
            MaterialUtils.ApplyMaterial(Prefab, "Butter", materials);
            materials[0] = MaterialUtils.GetExistingMaterial("Cheese - Default");
            MaterialUtils.ApplyMaterial(Prefab, "Shaving0", materials);
            MaterialUtils.ApplyMaterial(Prefab, "Shaving1", materials);
            MaterialUtils.ApplyMaterial(Prefab, "Shaving2", materials);
        }
    }
}
