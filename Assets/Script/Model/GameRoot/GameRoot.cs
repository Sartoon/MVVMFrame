using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
namespace MVVM
{
    public class GameRoot : MonoBehaviour
    {

        private static GameObject _rootObj;
        private static List<Action> _singletonReleaseList =new List<Action>();

        public void Awake()
        {
            _rootObj = gameObject;
            GameObject.DontDestroyOnLoad(_rootObj);
            StartCoroutine(InitSingletons());
        }

        private IEnumerator InitSingletons()
        {
            ClearCanvas();
            yield return null;
            AddSingleton<MessageDispatcher>();
            AddSingleton<UIManager>();
           // AddSingleton<>();

            
        }

        public static void AddSingleton<T>() where T :Singleton<T>
        {
            if(_rootObj.GetComponent<T>()==null)
            {
                T t=_rootObj.AddComponent<T>();
                t.SetInstance(t);
                t.Init();

                _singletonReleaseList.Add(delegate()
                {
                    t.Release();
                });
            }
        }
        public void ClearCanvas()
        {
            Transform canvas = GameObject.Find("Canvas").transform;
            foreach (Transform panel in canvas)
            {
                GameObject.Destroy(panel.gameObject);
            }
        }
    }

}