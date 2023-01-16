using KitchenData;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace MacNCheese.Dishes
{
    public class MacNCheese : ModDish
    {
        public override string UniqueNameID => "Mac and Cheese";
        public override DishType Type => DishType.Side;
        public override DishCustomerChange CustomerMultiplier => DishCustomerChange.SmallDecrease;
        public override CardType CardType => CardType.Default;
        public override Unlock.RewardLevel ExpReward => Unlock.RewardLevel.Small;
        public override UnlockGroup UnlockGroup => UnlockGroup.Dish;
        public override List<Dish.MenuItem> ResultingMenuItems => new List<Dish.MenuItem>
        {
            new Dish.MenuItem
            {
                Item = Mod.MacNCheeseServing
            }
        };
        public override HashSet<Dish.IngredientUnlock> IngredientsUnlocks => new HashSet<Dish.IngredientUnlock>
        {
            new Dish.IngredientUnlock
            {
                Ingredient = Mod.UncookedPasta,
                MenuItem = Mod.MacNCheeseServing
            }
        };
        public override HashSet<Item> MinimumIngredients => new HashSet<Item>
        {
            Mod.Pot,
            Mod.Water,
            Mod.Cheese,
            Mod.Butter,
            Mod.Milk
          //  Mod.Pasta    Not Implimented Yet
        };
        public override HashSet<Process> RequiredProcesses => new HashSet<Process>
        {
            Mod.Cook,
            Mod.Chop,
        };
        public override IDictionary<Locale, string> LocalisedRecipe => new Dictionary<Locale, string>
        {
            { Locale.English, "Put pasta and water in a pot then cook. Add cheese, butter, and milk then cook again. Makes 10 servings" }
        };
        public override IDictionary<Locale, UnlockInfo> LocalisedInfo => new Dictionary<Locale, UnlockInfo>
        {
            { Locale.English, LocalisationUtils.CreateUnlockInfo("Mac and Cheese", "Adds Mac and Cheese as a Side", "Seconds Please?") }
        };
    }
}