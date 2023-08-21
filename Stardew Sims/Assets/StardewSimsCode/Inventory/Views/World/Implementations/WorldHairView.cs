using StardewSimsCode.Inventory.Views.World.Base;

namespace StardewSimsCode.Inventory.Views.World.Implementations
{
    public class WorldHairView : WorldWearableItemView
    {
        protected override void UpdateSpriteLibrary()
        {
            if (_inventory.IsEquippingHair())
            {
                SetUpEquippedHair();
                return;
            }

            SetUpEmptyPiece();
        }

        private void SetUpEquippedHair()
        {
            _spriteLibrary.spriteLibraryAsset = _inventory.Hair.SpriteLibraryAsset;
        }
    }
}