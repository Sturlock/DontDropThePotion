using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private HandScript handScript;

    public PotionCombo potionCombo;
    public int score;
    private int baseScoreValue = 100;

    public PotionCombo.Entry currentEntry = null;

    [SerializeField]
    private GameObject imagePotion;
    [SerializeField]
    private Image fillImage;
    private bool completedPotion = true;
    private bool slotFull;

    private int e;

    //Timers
    [SerializeField]
    private float gameDownTimer;

    private float requiredHoldTime = 0;

    public bool CompletedPotion()
    {
        imagePotion.SetActive(false);
        imagePotion.GetComponent<Image>().sprite = null;
        Image fillImage = null;
        completedPotion = true;
        currentEntry = null;
        return true;
    }

    private void Start()
    {
        gameDownTimer = requiredHoldTime;
    }

    private void Update()
    {
        gameDownTimer += Time.deltaTime;
        if (fillImage != null)
            fillImage.fillAmount = gameDownTimer / requiredHoldTime;
    }

    // Update is called once per frame
    public PotionCombo.Entry FindEntry()
    {
        if (completedPotion || currentEntry == null)
        {
            if (gameDownTimer >= requiredHoldTime)
            {
                int i = Random.Range(1, 10);
                foreach (PotionCombo.Entry entry in potionCombo.m_recipes)
                {
                    if (i >= entry.m_weight)
                    {
                        //Add to List
                        currentEntry = entry;
                        slotFull = SlotSelection(entry);
                        SetUpPotion(entry);
                        Debug.Log("ADDED");
                        Reset();
                        return entry;
                    }
                }
                
            }
        }
        return null;
    }

    public void SetUpPotion(PotionCombo.Entry entry)
    {
        PotionScript potion = handScript.handPotion.GetComponent<PotionScript>();
        if (handScript.handPotion != null && !potion.start)
        {
            potion.entry = entry.m_ingredients;
            potion.meshFinishedProduct = entry.mesh;
            potion.matFinishedProduct = entry.material;
            potion.start = true;
        }
    }

    private bool SlotSelection(PotionCombo.Entry entry)
    {
        if (entry == potionCombo.m_recipes[0])
        {
            //for (int x = 0; x < imagePotions.Count; i++)

            {
                Image image = imagePotion.GetComponent<Image>();
                Image imageSlider = imagePotion.transform.GetChild(0).GetComponent<Image>();
                fillImage = imageSlider;
                if (image.sprite == null)
                {
                    image.sprite = entry.comboImage;
                    imageSlider.sprite = entry.sliderImage;
                    imageSlider.fillMethod = Image.FillMethod.Horizontal;
                    imageSlider.fillOrigin = 1;
                    imagePotion.gameObject.SetActive(true);
                }
            }
            return true;
        }
        else if (entry == potionCombo.m_recipes[1])
        {
            Image image = imagePotion.GetComponent<Image>();
            Image imageSlider = imagePotion.transform.GetChild(0).GetComponent<Image>();
            fillImage = imageSlider;
            if (image.sprite == null)
            {
                image.sprite = entry.comboImage;
                imageSlider.sprite = entry.sliderImage;
                imagePotion.gameObject.SetActive(true);
            }
            return true;
        }
        else if (entry == potionCombo.m_recipes[2])
        {
            Image image = imagePotion.GetComponent<Image>();
            Image imageSlider = imagePotion.transform.GetChild(0).GetComponent<Image>();
            fillImage = imageSlider;
            if (image.sprite == null)
            {
                image.sprite = entry.comboImage;
                imageSlider.sprite = entry.sliderImage;
                imagePotion.gameObject.SetActive(true);
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
        completedPotion = false;
    }

    public void GameOver()
    {
    }
}