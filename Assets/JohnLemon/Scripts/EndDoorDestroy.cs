using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndDoorDestroy : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // keytime 값이 5 이상인지 확인합니다.
        if (KeyScript.keytime >= 5)
        {
            // keytime 값이 5 이상일 경우 오브젝트를 삭제합니다.
            Destroy(gameObject);
        }
    }
}
