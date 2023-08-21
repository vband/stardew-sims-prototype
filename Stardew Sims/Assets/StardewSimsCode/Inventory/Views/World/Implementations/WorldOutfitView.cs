using StardewSimsCode.Inventory.Views.World.Base;

namespace StardewSimsCode.Inventory.Views.World.Implementations
{
    public class WorldOutfitView : WorldWearableItemView
    {
        protected override void UpdateSpriteLibrary()
        {
            if (_inventory.IsEquippingOutfit())
            {
                _spriteLibrary.spriteLibraryAsset = _inventory.Outfit.SpriteLibraryAsset;
                return;
            }

            _spriteLibrary.spriteLibraryAsset = null;
            _spriteRenderer.sprite = null;
        }
    }
}