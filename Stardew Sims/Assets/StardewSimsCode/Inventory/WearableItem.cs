using UnityEngine;
using UnityEngine.U2D.Animation;

namespace StardewSimsCode.Inventory
{
    public abstract class WearableItem : Item
    {
        [SerializeField] private SpriteLibraryAsset _spriteLibrary;

        public abstract void Equip(Inventory inventory);
    }
}