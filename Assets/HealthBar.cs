using UnityEngine.UI;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public Image healthBarFill;
    public DamageReceiver EnemyDamageReceiver; 

    private void Start()
    {
        UpdateHealthBar();
    }

    public void UpdateHealthBar()
    {
        if (EnemyDamageReceiver != null && healthBarFill != null)
        {
            healthBarFill.fillAmount = EnemyDamageReceiver.CurrentHP / EnemyDamageReceiver.MaxHp;
        }
    }
}
