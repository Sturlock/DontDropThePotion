using UnityEngine;
using UnityEngine.UI;

public enum StationType
{
    burner, boil, chop
}

public class StationScript : MonoBehaviour
{
    public StationType type;

    [SerializeField]
    private float stationDownTimer;

    [SerializeField]
    private float requiredHoldTime;

    [SerializeField]
    private Image fillImage;

    [SerializeField]
    private CanvasGroup canvas;

    private void Awake()
    {
        canvas.alpha = 0;
    }
    public bool Burner(HandScript hand, bool hasIngredient)
    {
        if (hasIngredient)
        {
            canvas.alpha = 1;
            stationDownTimer += Time.deltaTime;
            if (stationDownTimer >= requiredHoldTime)
            {
                Reset(hand);
                return true;
            }
            if (fillImage != null)
                fillImage.fillAmount = stationDownTimer / requiredHoldTime;
        }
        return false;
    }

    public bool Boil(HandScript hand, bool hasIngredient)
    {
        if (hasIngredient)
        {
            canvas.alpha = 1;
            stationDownTimer += Time.deltaTime;
            if (stationDownTimer >= requiredHoldTime)
            {
                Reset(hand);
                return true;
            }
            if (fillImage != null)
                fillImage.fillAmount = stationDownTimer / requiredHoldTime;
        }
        return false;
    }

    public bool Chop(HandScript hand, bool hasIngredient)
    {
        if (hasIngredient)
        {
            canvas.alpha = 1;
            stationDownTimer += Time.deltaTime;
            if (stationDownTimer >= requiredHoldTime)
            {
                Reset(hand);
                return true;
            }
            if (fillImage != null)
                fillImage.fillAmount = stationDownTimer / requiredHoldTime;
        }
        return false;
    }

    private void Reset(HandScript hand)
    {
        canvas.alpha = 0;
        stationDownTimer = 0;
        if (fillImage != null)
            fillImage.fillAmount = stationDownTimer / requiredHoldTime;
    }
}