using KitchenData;
using KitchenLib.Customs;
using System.Collections.Generic;
using UnityEngine;

namespace MacNCheese.Customs.MacNCheeseProcess
{
    class CookedMacNCheesePot : CustomItem
    {
        public override string UniqueNameID => "CookedNoodlePot";
        public override GameObject Prefab => Mod.Tomato.Prefab;
        public override Item DisposesTo => Mod.Pot;
        public override int SplitCount => 10;
        public override Item SplitSubItem => Mod.MacNCheeseServing;
        public override List<Item> SplitDepletedItems => new List<Item>
        {
            Mod.Pot
        };
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.None;

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
