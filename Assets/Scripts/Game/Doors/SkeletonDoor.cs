using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkeletonDoor : MonoBehaviour
{
    public Animator anim;
    public SaveManager saveManager;
    public GameObject knight;
    public CinemachineVirtualCamera knightCamera;
    public GameObject camObj;
    public CinemachineFreeLook freeLook;
    public CinemachineComposer comp;
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            anim.SetBool("Open", true);

            if (Input.GetKey(KeyCode.E))
            {
                saveManager.Save();
                CinemachineFramingTransposer composer = knightCamera.GetCinemachineComponent<CinemachineFramingTransposer>();
                composer.m_DeadZoneHeight = 0.05f;
                knightCamera.GetCinemachineComponent<CinemachineFramingTransposer>().m_TrackedObjectOffset = new Vector3(0f, 1f, 0f);
                knight.transform.position = new Vector2(25, 0);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            anim.SetBool("Open", false);
        }
    }
}