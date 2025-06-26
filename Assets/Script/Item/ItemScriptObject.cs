using UnityEngine;

namespace Script.Item
{
    [CreateAssetMenu(menuName = "Item/ItemScriptObject")]
    public class ItemScriptObject: ScriptableObject
    {
        public readonly string Name;

        public ItemScriptObject(string name)
        {
            Name = name;
        }
    }
}