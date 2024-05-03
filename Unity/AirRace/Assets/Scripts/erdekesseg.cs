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
        erdekesSzoveg.Add("Néhány országban még ma is alkalmazzák.\nEzek az országok közé tartozik India, Észak-Korea\nés egyes afrikai országok.\n\nRelatív olcsó fentartási költsége miatt,\nnagyon népszerû volt, ezért sokat gyártottak belõle.(több mint 11 ezer darabot)");
        erdekesSzoveg.Add("Híres volt sebességérõl és manõverezõképességérõl.\nKépes volt a hangsebesség töbszörösével repülni,\nés sok verziója magas teljesítményû hajtõmûveket\nhasznált.");
        erdekesSzoveg.Add("Arra tervezték, hogy esetleges támadákor\ngyorsan felszáljon és az ellenséges vadászgépeket és bombázókat lelõje, és visszatérjen a bázisra.\nEz a formájában is látszik, hisz egy nagy hajtómû köré tervezték a gépet, úgy hogy a felülete lehetõ legkisebb legyen.");
        erdekesSzoveg.Add("Nagyon sokoldalú gép volt, különbözö verziói számos szerepet töltöttek be.\nEbbe beleértve a vadász, bombazó, felderítõ és\na vadászbombázó szerepeket is.\nEz az egyszerûsége és a könnyû módosíthatósága miatt köszönhetõ.");
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