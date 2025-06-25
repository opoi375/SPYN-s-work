using System;
using System.Collections.Generic;
using FameWork.Config;
using Script.FameWork.Factory;
using Script.FameWork.Singleton;
using UnityEngine;
using UnityEngine.Events;

namespace Script.FameWork.UI
{
    /// <summary>
    /// UI������
    /// ��̬��ʾ�������
    /// </summary>
    public class UIMgr : Singleton<UIMgr>
    {
        //��ŵ�ǰ��ʾ�����
        private Dictionary<Type,PanelBase> panelDic = new Dictionary<Type,PanelBase>();
        private Transform canvasTrans;
        private UIMgr()
        {
            //��̬����CanvasԤ����
            GameObject canvas = GameObjFactory.Instance.GetItem(ResPathConfig.UIPath + "Canvas");
            GameObject.DontDestroyOnLoad(canvas);
            canvasTrans = canvas.transform;
        }

        /// <summary>
        /// ��ʾ���
        /// </summary>
        /// <typeparam name="T">�������</typeparam>
        public T ShowPanel<T>()where T : PanelBase
        {
            if (panelDic.ContainsKey(typeof(T))) return panelDic[typeof(T)] as T;
            //��������������ʾ����ֱ�ӷ���
            GameObject panel = GameObjFactory.Instance.GetItem(ResPathConfig.UIPath + typeof(T).Name);
            panel.transform.SetParent(canvasTrans, false);
            PanelBase panelBase = panel.GetComponent<PanelBase>();
            panelDic.Add(typeof(T),panelBase);
            panelBase.ShowMe();
            return panel as T;//����������
        }
        /// <summary>
        /// �������
        /// </summary>
        /// <typeparam name="T">�������</typeparam>
        /// <param name="action">������غ��������¼�</param>
        public void HidePanel<T>(UnityAction action = null)where T : PanelBase
        {
            if (!panelDic.ContainsKey(typeof(T))) return;
            PanelBase panelBase = panelDic[typeof(T)];
            panelBase.HideMe(() =>
            {
                panelBase.transform.SetParent(null);
                GameObject.Destroy(panelBase.gameObject);
                action?.Invoke();
            });
            panelDic.Remove(typeof(T));
        }
        /// <summary>
        /// ����ӻ�ȡ���
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetPanel<T>()where T : PanelBase
        {
            if (!panelDic.ContainsKey(typeof(T)))
                return null;
        
            return panelDic[typeof(T)] as T;
        }
    }
}
