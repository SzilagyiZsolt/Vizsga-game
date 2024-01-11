using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arena2mapDoor : MonoBehaviour
{
    public SaveManager saveManager;
    public GameObject knight;
    public CinemachineVirtualCamera knightCamera;
    public GameObject bossTrigger;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                saveManager.Save();
                knightCamera.GetCinemachineComponent<CinemachineFramingTransposer>().m_TrackedObjectOffset = new Vector3(0f, 1.4f, 0f);
                knight.transform.position = new Vector2(95, -0.2f);
                bossTrigger.SetActive(true);
            }
        }
    }
}
