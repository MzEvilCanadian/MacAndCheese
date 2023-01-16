using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace MacNCheese.Customs.MacNCheeseProcess
{
    internal class UncookedPasta : CustomItemGroup
    {
        public override string UniqueNameID => "Uncooked Pasta";
        public override GameObject Prefab => Mod.Cheese.Prefab;         // Filler line until graphics are made
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;

        public override List<ItemGroup.ItemSet> Sets => new List<ItemGroup.ItemSet>()
        {
            new ItemGroup.ItemSet()
            {
                Max = 2,
                Min = 2,
                Items = new List<Item>()
                {
                    Mod.Pot,
                    Mod.Water
                }
            }
        };
        public override List<Item.ItemProcess> Processes => new List<Item.ItemProcess>
        {
            new Item.ItemProcess
            {
                Duration = 5,
                Process = Mod.Cook,
                Result = Mod.CookedPasta
            }
        };

     /*   public override void OnRegister(GameDataObject gameDataObject)
        {
            var materials = new Material[]
            {
                MaterialUtils.GetExistingMaterial("Bread - Inside"),
             };
            MaterialUtils.ApplyMaterial(Prefab, "GameObject", materials);
            materials[0] = MaterialUtils.GetExistingMaterial("Bread");
            MaterialUtils.ApplyMaterial(Prefab, "GameObject (1)", materials);
            materials[0] = MaterialUtils.GetExistingMaterial("Paper - Postit Yellow");
            MaterialUtils.ApplyMaterial(Prefab, "GameObject (2)", materials);

            // MaterialUtils.ApplyMaterial([object], [name], [material list]
        }
     */
    }
}