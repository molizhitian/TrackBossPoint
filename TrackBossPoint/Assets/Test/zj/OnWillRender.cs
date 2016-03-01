using UnityEngine;
using System.Collections;

public class OnWillRender : MonoBehaviour {
    public GameObject _ImageObj;
    public bool isRendering = false;
   
    void Update()
    {
        if (isRendering)
        {
            _ImageObj.SetActive(false);
            Debug.Log(" 可见状态下你要执行 的东西");
        }
        else
        {
            _ImageObj.SetActive(true);
            Debug.Log(" 不可见状态下你要执行的东西");
        }
    }
    void OnBecameVisible()
    {
        isRendering = true;
       
    }
    void OnBecameInvisible()
    {
        isRendering = false;
        
    }

}
