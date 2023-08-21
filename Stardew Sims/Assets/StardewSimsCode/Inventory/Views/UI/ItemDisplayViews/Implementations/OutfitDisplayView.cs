using StardewSimsCode.Inventory.Views.UI.ItemDisplayViews.Base;

namespace StardewSimsCode.Inventory.Views.UI.ItemDisplayViews.Implementations
{
    public class OutfitDisplayView : WearableItemDisplayView
    {
        protected override void UpdateImage()
        {
            if (!_inventory.IsEquippingOutfit())
            {
                SetUpEmptyPiece();
                return;
            }

            SetUpEquippedOutfit();
        }

        private void SetUpEquippedOutfit()
        {
            _image.sprite = _inventory.Outfit.DisplaySprite;
            SetUpEquippedColor();
        }
    }
}