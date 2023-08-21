using StardewSimsCode.Inventory.Views.World.Base;

namespace StardewSimsCode.Inventory.Views.World.Implementations
{
    public class WorldOutfitView : WorldWearableItemView
    {
        protected override void UpdateSpriteLibrary()
        {
            if (_inventory.IsEquippingOutfit())
            {
                SetUpEquippedOutfit();
                return;
            }

            SetUpEmptyPiece();
        }

        private void SetUpEquippedOutfit()
        {
            _spriteLibrary.spriteLibraryAsset = _inventory.Outfit.SpriteLibraryAsset;
        }
    }
}