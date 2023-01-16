using KitchenData;
using System.Collections.Generic;

namespace MacNCheese.Registry
{
    public interface ILocalisedRecipeHolder
    {
        IDictionary<Locale, string> LocalisedRecipe { get; }

    }
}
