using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    [Header("Player Life Settings")]
    public int maxLive = 10;
    public int currentLive = 10;
    public LiveUIManager liveUIManager;

    void Start()
    {
        liveUIManager.UpdateLive(currentLive, maxLive);
    }

    public void TakeDamage(int damage)
    {
        currentLive -= damage;
    }

    public void Heal(int heal)
    {
        currentLive += heal;
        
        if(currentLive > maxLive)
        {
            currentLive = maxLive;
        }
        liveUIManager.UpdateLive(currentLive, maxLive);
    }

}
