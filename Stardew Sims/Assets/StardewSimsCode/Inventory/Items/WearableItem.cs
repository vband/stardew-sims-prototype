using UnityEngine;
using UnityEngine.U2D.Animation;

namespace StardewSimsCode.Inventory.Items
{
    public abstract class WearableItem : Item
    {
        [SerializeField] private SpriteLibraryAsset _spriteLibrary;
        public SpriteLibraryAsset SpriteLibraryAsset => _spriteLibrary;
        
        
    }
}