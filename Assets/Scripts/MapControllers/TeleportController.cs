using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportController : MonoBehaviour
{
    private GameObject prevRoom;
    //[SerializeField] private GameObject player;
    private void Start()
    {

    }
    private void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Door"))
        {
            Debug.Log("지정된 오브젝트와 Door의 충돌 감지!");
            // 문과 연결된 장소로 이동
            transform.position = collision.gameObject.GetComponent<DoorData>().ConnectedDoorPosition;
        }

        if (collision.gameObject.CompareTag("Portal"))
        {
            Debug.Log("지정된 오브젝트와 포탈의 충돌 감지!");
            // 보스스테이지로 이동
            SceneManager.LoadScene("BossScene");
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("Room"))
        {
            Debug.Log("지정된 오브젝트와 방의 충돌 감지!");
            if (prevRoom != null)
            {
                prevRoom.SetActive(false);
            }
            prevRoom = collision.transform.GetChild(0).gameObject;
            prevRoom.SetActive(true);
        }
    }
}