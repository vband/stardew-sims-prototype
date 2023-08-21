using StardewSimsCode.Inventory.Views.UI.ItemDisplayViews.Base;

namespace StardewSimsCode.Inventory.Views.UI.ItemDisplayViews.Implementations
{
    public class HatDisplayView : WearableItemDisplayView
    {
        protected override void UpdateImage()
        {
            if (!_inventory.IsEquippingHat())
            {
                SetUpEmptyPiece();
                return;
            }

            SetUpEquippedHat();
        }

        private void SetUpEquippedHat()
        {
            _image.sprite = _inventory.Hat.DisplaySprite;
            SetUpEquippedColor();
        }
    }
}