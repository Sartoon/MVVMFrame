using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
namespace MVVM
{
    /// <summary>
    /// 泛型的类型制定为“继承自Singleton的类”
    /// </summary>
    /// <typeparam name="T"></typeparam>
   public  class Singleton<T>:MonoBehaviour where T :Singleton<T>
    {
       private static T _instance;

       public static T GetInstance()
       {
           return _instance;
       }

       public void SetInstance(T t)
       {
           if (_instance == null)
           {
               _instance = t;
           }
       }
       public virtual void Init()
       {
           return;
       }
       public virtual void Release()
       {
           return;
       }
    }
}

