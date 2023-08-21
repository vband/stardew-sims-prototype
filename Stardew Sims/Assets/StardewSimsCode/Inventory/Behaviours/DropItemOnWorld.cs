using StardewSimsCode.Inventory.Items;
using StardewSimsCode.Inventory.Views.World;
using StardewSimsCode.SerializedTypes.Implementations;
using UnityEngine;

namespace StardewSimsCode.Inventory.Behaviours
{
    public class DropItemOnWorld : MonoBehaviour
    {
        [SerializeField] private GameObject _worldItemPrefab;
        [SerializeField] private SerializedFloat _droppedItemDistance;
            
        public void OnDroppedItem(object data)
        {
            if (data is not Item item)
                return;

            var newItemGameObject = Instantiate(_worldItemPrefab);
            newItemGameObject.GetComponent<WorldItemView>().SetItem(item);
            newItemGameObject.transform.position = GetRandomPosition();
        }

        private Vector3 GetRandomPosition()
        {
            var randomDirection = Random.insideUnitCircle.normalized;
            var randomDirectionVector3 = new Vector3(randomDirection.x, randomDirection.y, 0);
            var randomPosition = transform.position + randomDirectionVector3 * _droppedItemDistance.Value;
            return randomPosition;
        }
    }
}