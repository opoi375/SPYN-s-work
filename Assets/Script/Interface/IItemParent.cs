using Script.Item;
using UnityEditorInternal.Profiling.Memory.Experimental;

namespace Script.Interface
{
    public interface IItemParent
    {
        
        public void GetItem(ItemObject itemObject);
        
        public void UseItem();
        
        public void FreeItem();
    }
}