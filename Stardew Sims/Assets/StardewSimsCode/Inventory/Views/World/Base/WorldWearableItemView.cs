using StardewSimsCode.SerializedTypes.Implementations;
using UnityEngine;
using UnityEngine.U2D.Animation;

namespace StardewSimsCode.Inventory.Views.World.Base
{
    public abstract class WorldWearableItemView : MonoBehaviour
    {
        [SerializeField] protected Inventory _inventory;
        [SerializeField] protected SpriteLibrary _spriteLibrary;
        [SerializeField] protected SpriteResolver _spriteResolver;
        [SerializeField] protected SpriteRenderer _spriteRenderer;
        [SerializeField] protected SerializedString _defaultSpriteResolverCategory;
        [SerializeField] protected SerializedString _defaultSpriteResolverLabel;
        
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