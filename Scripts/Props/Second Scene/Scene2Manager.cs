using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene2Manager : MonoBehaviour
{
    [SerializeField]
    private UngaBungaMaster master;
    [SerializeField]
    private GameObject key;
    private void Awake()
    {
        master = transform.Find("UNGA BUNGA ITEMS").GetComponent<UngaBungaMaster>();
        key = transform.Find("Scene 2 Key").gameObject;
    }
    // Update is called once per frame
    void Update()
    {
        if (master.getKey())
        {
            key.SetActive(true);
        }
    }
}
