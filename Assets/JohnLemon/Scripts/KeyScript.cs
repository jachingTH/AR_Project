using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyScript : MonoBehaviour
{
    public float rotationSpeed = 100f;
    public string targetTag = "Player";
    public static int keytime = 0;
    public Text keytimeText;

    public AudioClip collisionSound;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = collisionSound;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        // 충돌한 오브젝트의 태그가 설정된 태그와 일치하는지 확인
        if (other.CompareTag(targetTag))
        {
            // keytime 변수를 1 증가
            keytime += 1;

            // 콘솔에 keytime 값 출력 (디버깅 목적)
            Debug.Log("Keytime: " + keytime);

            UpdateKeytimeText();

            audioSource.Play();

            // 충돌한 오브젝트 삭제
            Destroy(gameObject);

            
        }
    }

    // keytime 변수를 UI에 업데이트하는 함수
    void UpdateKeytimeText()
    {
        if (keytimeText != null)
        {
            keytimeText.text = "Key: " + keytime.ToString() + "/5";
        }
    }
}
