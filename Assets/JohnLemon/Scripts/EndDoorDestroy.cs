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
        // keytime ���� 5 �̻����� Ȯ���մϴ�.
        if (KeyScript.keytime >= 5)
        {
            // keytime ���� 5 �̻��� ��� ������Ʈ�� �����մϴ�.
            Destroy(gameObject);
        }
    }
}
