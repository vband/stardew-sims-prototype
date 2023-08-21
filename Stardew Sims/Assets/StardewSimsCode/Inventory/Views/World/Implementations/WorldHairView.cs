using StardewSimsCode.Inventory.Views.World.Base;

namespace StardewSimsCode.Inventory.Views.World.Implementations
{
    public class WorldHairView : WorldWearableItemView
    {
        protected override void UpdateSpriteLibrary()
        {
            if (_inventory.IsEquippingHair())
            {
                _spriteLibrary.spriteLibraryAsset = _inventory.Hair.SpriteLibraryAsset;
                return;
            }

            _spriteLibrary.spriteLibraryAsset = null;
            _spriteRenderer.sprite = null;
        }
    }
}