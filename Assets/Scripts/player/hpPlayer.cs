using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hpPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public static hpPlayer Instance;
    public GameObject iconTraiTim;
    GameObject[] sluongIcon;
    public int soluongBlood;
    int x=0;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        sluongIcon = new GameObject[soluongBlood];
        for (int i = 0; i < soluongBlood; i++)
        {

            sluongIcon[i] = Instantiate(iconTraiTim);
            sluongIcon[i].transform.position = new Vector3(-3.7f + x, 4.5f, 0);
            sluongIcon[i].transform.rotation = Quaternion.identity;
            x += 1;
        }
    }
    public void hienBlood()
    {
        Destroy(sluongIcon[soluongBlood]); 
    }
    // Update is called once per frame
    void Update()
    {
      
    }
}
