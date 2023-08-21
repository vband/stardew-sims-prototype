using StardewSimsCode.Inventory.Views.World.Base;

namespace StardewSimsCode.Inventory.Views.World.Implementations
{
    public class WorldHatView : WorldWearableItemView
    {
        protected override void UpdateSpriteLibrary()
        {
            if (_inventory.IsEquippingHat())
            {
                SetUpEquippedHat();
                return;
            }

            SetUpEmptyPiece();
        }

        private void SetUpEquippedHat()
        {
            _spriteLibrary.spriteLibraryAsset = _inventory.Hat.SpriteLibraryAsset;
        }
    }
}