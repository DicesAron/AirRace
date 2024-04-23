using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class erdekesseg : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI szoveg;
    List<string> erdekesSzoveg = new List<string>();
    public GameObject balgomb;
    public GameObject jobgomb;
    int helyzet = 0;
    // Start is called before the first frame update
    void Start()
    {
        erdekesSzoveg.Add("1");
        erdekesSzoveg.Add("2");
        erdekesSzoveg.Add("3");
        erdekesSzoveg.Add("4");
        szoveg.text = erdekesSzoveg[helyzet];
        balgomb.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (helyzet == 0)
        {
            balgomb.SetActive(false);
        }
        else
        {
            balgomb.SetActive(true);
        }
        if (helyzet == 3)
        {
            jobgomb.SetActive(false);
        }
        else
        {
            jobgomb.SetActive(true);
        }
        
    }

    public void jobraLapoz()
    {
        helyzet += 1;
        szoveg.text = erdekesSzoveg[helyzet];
    }

    public void balraLapoz()
    {
        helyzet -= 1;
        szoveg.text = erdekesSzoveg[helyzet];
    }
}