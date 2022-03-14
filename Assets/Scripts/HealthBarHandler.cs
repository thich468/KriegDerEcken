using UnityEngine;
using UnityEngine.UI;

public class HealthBarHandler : MonoBehaviour
{
    private static Image HealthBarImage;
    public GameObject Player;
    int startHp;
    float hpUnit;
    PlayerCollision pc;



    public static void SetHealthBarValue(float value)
    {
        HealthBarImage.fillAmount = value;
        if (HealthBarImage.fillAmount < 0.2f)
        {
            SetHealthBarColor(Color.red);
        }
        else if (HealthBarImage.fillAmount < 0.4f)
        {
            SetHealthBarColor(Color.yellow);
        }
        else
        {
            SetHealthBarColor(Color.green);
        }
    }

    public static float GetHealthBarValue()
    {
        return HealthBarImage.fillAmount;
    }

    
    public static void SetHealthBarColor(Color healthColor)
    {
        HealthBarImage.color = healthColor;
    }

    
    private void Start()
    {
        HealthBarImage = GetComponent<Image>();
        pc = Player.GetComponent<PlayerCollision>();
        startHp = pc.hp;
        hpUnit = 1f / startHp;

    }

    private void Update()
    {
        SetHealthBarValue(pc.hp * hpUnit);
    }
}