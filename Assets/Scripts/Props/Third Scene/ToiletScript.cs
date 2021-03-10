using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToiletScript : MonoBehaviour
{
    private int count = 0;
    [Tooltip("Şimdilik parent ama modelde değişir")]
    [SerializeField]
    private GameObject toiletLid;
    [SerializeField]
    private ToiletBottom bottom;
    [SerializeField]
    private GameObject key;
    [SerializeField]
    private float openUpAgainAngle;

    [SerializeField]
    private GameObject toothBrush;
    [SerializeField]
    private GameObject soap;
    [SerializeField]
    private float burpTime;
    [SerializeField]
    private float closeAgainTime;
    [SerializeField]
    private float closeSpeed;
    [SerializeField]
    private float openSpeed;


    private bool isClose = false;
    private bool isDestroy = false;
    private bool isDestroyCheck = false;
    private bool isCloseCheck = false;
    private float timer = 0;
    private void Awake()
    {
        bottom = transform.Find("Bottom").GetComponent<ToiletBottom>();
        key = transform.Find("Scene 3 Key").gameObject;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         ToiletLid();
        Destroyer();
        if (isClose && !isCloseCheck)
        {
            timer += Time.deltaTime * 1;  
        }
        ThrowBackKey();
        
    }

    public void ToiletLid()
    {
        if(bottom.getCounter() == 2 && toiletLid.transform.localRotation.x < -260f / 360f && !isClose)
        {
            toiletLid.transform.Rotate(closeSpeed * Time.deltaTime, 0f,0f);
        }
        else if(bottom.getCounter() == 2)
        {
            isClose = true;
            isDestroy = true;
        }
    }

    public void Destroyer()
    {
        if (isDestroy && !isDestroyCheck)
        {
            isDestroyCheck = true;
            Destroy(gameObject.transform.Find("Bottom").transform.Find("Brush").gameObject);
            Destroy(gameObject.transform.Find("Bottom").transform.Find("Soap").gameObject);
            
        }
    }

    public void ThrowBackKey()
    {
        if(isClose && timer >= burpTime + closeAgainTime && !isCloseCheck)
        {
            isClose = false;
            isCloseCheck = true;
        }
        else if (isClose && timer >= burpTime && !isCloseCheck)
        {

            if (toiletLid.transform.localRotation.x > -openUpAgainAngle/360f)
            {
                toiletLid.transform.Rotate(-openSpeed * Time.deltaTime, 0f, 0f);
            }
            else //if(Mathf.Clamp(toiletLid.transform.localRotation.x,-1f,0f) == 0f)
            {
                key.SetActive(true);
            }
        }
    }
}
