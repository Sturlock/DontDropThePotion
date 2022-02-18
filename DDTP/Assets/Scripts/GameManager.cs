using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private HandScript handScript;

    public PotionCombo potionCombo;
    public int score;
    private int baseScoreValue = 100;

    [SerializeField]
    private List<PotionCombo.Entry> currentEntrys = new List<PotionCombo.Entry>();

    [SerializeField]
    private List<GameObject> imagePotions = new List<GameObject>();

    private bool Slot1, Slot2, Slot3, Slot4;

    //Timers
    private float gameDownTimer;

    private float requiredHoldTime = 20;

    // Start is called before the first frame update
    private void Start()
    {
        int i = Random.Range(1, 10);
        foreach (PotionCombo.Entry entry in potionCombo.m_recipes)
        {
            if (i >= entry.m_weight)
            {
                //Add to List
                currentEntrys.Add(entry);
                Slot1 = SlotSelection(entry);
                Debug.Log("ADDED");
                break;
            }
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (currentEntrys.Count == 3)
        {
            gameDownTimer += Time.deltaTime;
            if (gameDownTimer >= requiredHoldTime)
            {
                int i = Random.Range(1, 10);
                foreach (PotionCombo.Entry entry in potionCombo.m_recipes)
                {
                    if (i >= entry.m_weight)
                    {
                        //Add to List
                        currentEntrys.Add(entry);
                        SlotSelection(entry);
                        Debug.Log("ADDED");
                        break;
                    }
                }
                Reset();
            }
        }
        if (currentEntrys.Count <= 1)
        {
            if (handScript.handPotion != null)
                handScript.handPotion.GetComponent<PotionScript>().entry = currentEntrys[0].m_ingredients;
        }
    }

    private bool SlotSelection(PotionCombo.Entry entry)
    {
        if (entry == potionCombo.m_recipes[0])
        {
            //for (int x = 0; x < imagePotions.Count; i++)
            foreach (GameObject x in imagePotions)
            {
                Image image = x.GetComponent<Image>();
                Image imageSlider = x.transform.GetChild(0).GetComponent<Image>();
                if (image.sprite == null)
                {
                    image.sprite = entry.comboImage;
                    imageSlider.sprite = entry.sliderImage;
                    x.gameObject.SetActive(true);
                    
                }
            }
            return true;
        }
        else if (entry == potionCombo.m_recipes[1])
        {
            foreach (GameObject x in imagePotions)
            {
                Image image = x.GetComponent<Image>();
                Image imageSlider = x.transform.GetChild(0).GetComponent<Image>();
                if (image.sprite == null)
                {
                    image.sprite = entry.comboImage;
                    imageSlider.sprite = entry.sliderImage;
                    x.gameObject.SetActive(true);
                    
                }
            }
            return true;
        }
        else if (entry == potionCombo.m_recipes[2])
        {
            foreach (GameObject x in imagePotions)
            {
                Image image = x.GetComponent<Image>();
                Image imageSlider = x.transform.GetChild(0).GetComponent<Image>();
                if (image.sprite == null)
                {
                    image.sprite = entry.comboImage;
                    imageSlider.sprite = entry.sliderImage;
                    x.gameObject.SetActive(true);
                    
                }
            }
            return true;
        }
        else
        {
            return false;
        }
    }

    private void Reset()
    {
        gameDownTimer = 0;
    }
}