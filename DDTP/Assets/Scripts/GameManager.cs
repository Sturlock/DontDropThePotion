using System.Collections;
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
    private List<Image> imagePotions = new List<Image>();
    [SerializeField]
    private List<Image> imagePotionSliders = new List<Image>();

    //Timers
    private float gameDownTimer;
    private float requiredHoldTime = 20;


    // Start is called before the first frame update
    void Start()
    {
        int i = Random.Range(1, 10);
        foreach (PotionCombo.Entry entry in potionCombo.m_recipes)
        {
            if (i >= entry.m_weight)
            {
                //Add to List
                currentEntrys.Add(entry);
                Debug.Log("ADDED");
                break;
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        if(currentEntrys.Count == 3)
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

        for(int i = 0; i < currentEntrys.Count; i++ )
        {
            if(currentEntrys[i] == potionCombo.m_recipes[0])
            {
                for (int x = 0; x < imagePotions.Count; i++)
                {
                    if(imagePotions[x] == null)
                    {
                        imagePotions[x] = currentEntrys[i].comboImage;
                        imagePotionSliders[x] = currentEntrys[i].sliderImage;
                        imagePotions[x].gameObject.SetActive(true);
                    }
                }

            }
            if (currentEntrys[i] == potionCombo.m_recipes[1])
            {
                for (int x = 0; x < imagePotions.Count; i++)
                {
                    if (imagePotions[x] == null)
                    {
                        imagePotions[x] = currentEntrys[i].comboImage;
                        imagePotionSliders[x] = currentEntrys[i].sliderImage;
                        imagePotions[x].gameObject.SetActive(true);
                    }
                }

            }
            if (currentEntrys[i] == potionCombo.m_recipes[2])
            {
                for (int x = 0; x < imagePotions.Count; i++)
                {
                    if (imagePotions[x] == null)
                    {
                        imagePotions[x] = currentEntrys[i].comboImage;
                        imagePotionSliders[x] = currentEntrys[i].sliderImage;
                        imagePotions[x].gameObject.SetActive(true);
                    }
                }
            }
        }
        
    }


    private void Reset()
    {
        gameDownTimer = 0;
    }
}
