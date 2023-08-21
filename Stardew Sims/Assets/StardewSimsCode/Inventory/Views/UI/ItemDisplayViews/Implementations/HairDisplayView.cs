using StardewSimsCode.Inventory.Views.UI.ItemDisplayViews.Base;

namespace StardewSimsCode.Inventory.Views.UI.ItemDisplayViews.Implementations
{
    public class HairDisplayView : WearableItemDisplayView
    {
        protected override void UpdateImage()
        {
            if (!_inventory.IsEquippingHair())
            {
                SetUpEmptyPiece();
                return;
            }

            SetUpEquippedHair();
        }

        private void SetUpEquippedHair()
        {
            _image.sprite = _inventory.Hair.DisplaySprite;
            SetUpEquippedColor();
        }
    }
}