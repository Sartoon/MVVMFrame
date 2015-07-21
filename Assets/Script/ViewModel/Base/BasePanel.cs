using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace MVVM
{
   public  class BasePanel:MonoBehaviour
    {
       public virtual void Show(object param =null)
       {
           gameObject.SetActive(false);
       }

       public virtual void Hide()
       {
           gameObject.SetActive(false);
       }
    }
}
