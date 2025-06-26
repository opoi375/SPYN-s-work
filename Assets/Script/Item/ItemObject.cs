using Script.Interface;
using Script.Player;
using UnityEngine;

namespace Script.Item
{
    public class ItemObject:MonoBehaviour
    {
        /// <summary>
        /// 这个是物品的标识
        /// </summary>
        public ItemScriptObject item;
        /// <summary>
        /// 这个是物品的父物体
        /// </summary>
        protected IItemParent ItemParent;

        public void SetParent(IItemParent itemParent)
        {
            ItemParent = itemParent;
            if (itemParent is PlayerHand)
            {
                this.transform.parent = (itemParent as PlayerHand).transform;
                this.transform.localPosition = Vector3.zero;
            }
        }

        public virtual void UseItem()
        {
            // 使用物品的逻辑
        }

        public void FreeItem()
        {
            ItemParent = null;
        }
        
    }
}