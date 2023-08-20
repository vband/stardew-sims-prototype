using UnityEngine;

namespace StardewSimsCode.Inventory.Items
{
    [CreateAssetMenu(fileName = "NewHairItem", menuName = "StardewSims/Inventory/HairItem")]
    public class HairItem : WearableItem
    {
        public override void Equip(Inventory inventory)
        {
            inventory.EquipHair(this);
        }
    }
}