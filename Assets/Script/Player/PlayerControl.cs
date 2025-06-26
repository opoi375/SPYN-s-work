using Script.Enum;
using Unity.VisualScripting;
using UnityEngine;

namespace Script.Player
{
    public class PlayerControl:MonoBehaviour
    {
        [SerializeField]
        private Transform leftHand;
        [SerializeField]
        private Transform rightHand;
        
        
        private EHand handType = EHand.LeftHand;
        private void Awake()
        {
            Init();  
        }
        
        public void Init()
        {
            if (!leftHand)
            {
                leftHand = GameObject.Find("L_Hand_IK").transform;
            }

            if (!rightHand)
            {
                rightHand = GameObject.Find("R_Hand_IK").transform;
            }
        }
        
        private void OnDestroy()
        {
            Clear();
        }
        public void Clear()
        {
            leftHand = null;
            rightHand = null;
        }

        private void Update()
        {
            // 获取鼠标位置
            Vector3 mousePosition = Input.mousePosition;
            // 将鼠标位置转换为世界坐标
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, -Camera.main.transform.position.z-Camera.main.nearClipPlane));
           
            // 更新手部位置
            if (handType == EHand.LeftHand)
            {
                //对左手进行操作
                leftHand.position = new Vector3(worldPosition.x, worldPosition.y, leftHand.position.z);
                if (worldPosition.x < -0.2)
                {
                    SwitchHand();
                }
            }
            else if (handType == EHand.RightHand)
            {
                //对右手进行操作
                rightHand.position = new Vector3(worldPosition.x, worldPosition.y, rightHand.position.z);
                if (worldPosition.x > 0.2)
                {
                    SwitchHand();
                }
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
               SwitchHand();
            }
            
        }

        public void SwitchHand()
        {
            //切换手的类型
            handType = handType == EHand.LeftHand ? EHand.RightHand : EHand.LeftHand;
        }
        
        
    }
}