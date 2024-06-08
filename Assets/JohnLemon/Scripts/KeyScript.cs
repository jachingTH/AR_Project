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
        // �浹�� ������Ʈ�� �±װ� ������ �±׿� ��ġ�ϴ��� Ȯ��
        if (other.CompareTag(targetTag))
        {
            // keytime ������ 1 ����
            keytime += 1;

            // �ֿܼ� keytime �� ��� (����� ����)
            Debug.Log("Keytime: " + keytime);

            UpdateKeytimeText();

            audioSource.Play();

            // �浹�� ������Ʈ ����
            Destroy(gameObject);

            
        }
    }

    // keytime ������ UI�� ������Ʈ�ϴ� �Լ�
    void UpdateKeytimeText()
    {
        if (keytimeText != null)
        {
            keytimeText.text = "Key: " + keytime.ToString() + "/5";
        }
    }
}
