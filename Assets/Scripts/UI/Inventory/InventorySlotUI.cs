using InventorySystem;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI.Inventory
{
    public class InventorySlotUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        [SerializeField] private Image itemIcon;
        [SerializeField] private TextMeshProUGUI quantityText;
        [SerializeField] private CanvasGroup canvasGroup;

        private Transform _initialParent;
        private int _initialSiblingIndex;
        public ItemData Item { get; private set; }
        
        public void SetItem(InventorySlot slot)
        {
            Item = slot.Item;
            itemIcon.sprite = slot.Item.Icon;
            quantityText.text = slot.Quantity > 1 ? $"{slot.Quantity}" : "";
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            _initialParent = transform.parent;
            _initialSiblingIndex = transform.GetSiblingIndex();
            
            transform.SetParent(transform.root); 
            transform.SetAsLastSibling(); 
            
            canvasGroup.blocksRaycasts = false;
        }

        public void OnDrag(PointerEventData eventData)
        {
            transform.position = eventData.position; 
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            transform.SetParent(_initialParent);
            transform.SetSiblingIndex(_initialSiblingIndex);
            
            canvasGroup.blocksRaycasts = true;
        }
    }
}