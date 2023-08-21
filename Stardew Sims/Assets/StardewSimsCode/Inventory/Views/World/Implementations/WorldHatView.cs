using StardewSimsCode.Inventory.Views.World.Base;

namespace StardewSimsCode.Inventory.Views.World.Implementations
{
    public class WorldHatView : WorldWearableItemView
    {
        protected override void UpdateSpriteLibrary()
        {
            if (_inventory.IsEquippingHat())
            {
                _spriteLibrary.spriteLibraryAsset = _inventory.Hat.SpriteLibraryAsset;
                return;
            }

            _spriteLibrary.spriteLibraryAsset = null;
            _spriteRenderer.sprite = null;
        }
    }
}