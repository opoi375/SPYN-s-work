using System;
using Script.Interface;
using Script.Item;
using UnityEngine;

namespace Script.Player
{
    public class PlayerHand:MonoBehaviour,IItemParent
    {
        /// <summary>
        /// 这个是手上的物品对象
        /// </summary>
        private ItemObject itemObject = null;

        public void OnTriggerEnter(Collider other)
        {
            Debug.Log("OnTriggerStay");
            ItemObject itemObject = other.GetComponent<ItemObject>();
            if (itemObject)
            {
                GetItem(itemObject);
            }
        }

        public void GetItem(ItemObject it)
        {
            if (!itemObject)
            {
                this.itemObject = it;
                this.itemObject.SetParent(this);
            }
        }

        public void UseItem()
        {
            if (!itemObject)
            {
                Debug.LogWarning("没有物品可用");
                return;
            }
            
            itemObject.UseItem();
        }

        public void FreeItem()
        {
            itemObject.FreeItem();
            itemObject = null;
        }
        
        private void OnDestroy()
        {
            Clear();
        }
        public void Clear()
        {
            itemObject = null;
        }
    }
}