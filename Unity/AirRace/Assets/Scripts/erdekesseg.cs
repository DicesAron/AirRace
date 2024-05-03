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
        erdekesSzoveg.Add("N�h�ny orsz�gban m�g ma is alkalmazz�k.\nEzek az orsz�gok k�z� tartozik India, �szak-Korea\n�s egyes afrikai orsz�gok.\n\nRelat�v olcs� fentart�si k�lts�ge miatt,\nnagyon n�pszer� volt, ez�rt sokat gy�rtottak bel�le.(t�bb mint 11 ezer darabot)");
        erdekesSzoveg.Add("H�res volt sebess�g�r�l �s man�verez�k�pess�g�r�l.\nK�pes volt a hangsebess�g t�bsz�r�s�vel rep�lni,\n�s sok verzi�ja magas teljes�tm�ny� hajt�m�veket\nhaszn�lt.");
        erdekesSzoveg.Add("Arra tervezt�k, hogy esetleges t�mad�kor\ngyorsan felsz�ljon �s az ellens�ges vad�szg�peket �s bomb�z�kat lel�je, �s visszat�rjen a b�zisra.\nEz a form�j�ban is l�tszik, hisz egy nagy hajt�m� k�r� tervezt�k a g�pet, �gy hogy a fel�lete lehet� legkisebb legyen.");
        erdekesSzoveg.Add("Nagyon sokoldal� g�p volt, k�l�nb�z� verzi�i sz�mos szerepet t�lt�ttek be.\nEbbe bele�rtve a vad�sz, bombaz�, felder�t� �s\na vad�szbomb�z� szerepeket is.\nEz az egyszer�s�ge �s a k�nny� m�dos�that�s�ga miatt k�sz�nhet�.");
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