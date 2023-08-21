using UnityEngine;
using UnityEngine.U2D.Animation;

namespace StardewSimsCode.Inventory.Views.World.Base
{
    public abstract class WorldWearableItemView : MonoBehaviour
    {
        [SerializeField] protected Inventory _inventory;
        [SerializeField] protected SpriteLibrary _spriteLibrary;
        [SerializeField] protected SpriteRenderer _spriteRenderer;
        
        protected abstract void UpdateSpriteLibrary();

        private void Start()
        {
            UpdateSpriteLibrary();
        }

        private void OnEnable()
        {
            _inventory.InventoryChanged += OnInventoryChanged;
        }

        private void OnDisable()
        {
            _inventory.InventoryChanged -= OnInventoryChanged;
        }

        private void OnInventoryChanged()
        {
            UpdateSpriteLibrary();
        }
        
        protected void SetUpEmptyPiece()
        {
            _spriteLibrary.spriteLibraryAsset = null;
            _spriteRenderer.sprite = null;
        }
    }
}