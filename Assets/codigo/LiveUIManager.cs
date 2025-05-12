using UnityEngine;
using UnityEngine.UI;

public class LiveUIManager : MonoBehaviour
{
    [Header("UI Elements")]
    public Image liveUI;
    public CanvasGroup lifeBarObject;
    public Image armorUI;
    public CanvasGroup armorBarObject;
    public float hideBarsSeconds = 5f;
    public float hideVelocity = 0.2f;

    private bool showBars = false;

    void Update(){
        if(!showBars){
            lifeBarObject.alpha = lifeBarObject.alpha - hideVelocity * Time.deltaTime;
            armorBarObject.alpha = armorBarObject.alpha - hideVelocity * Time.deltaTime;
        }
    }

    public void UpdateLive(int currentLive, int maxLive)
    {
        showBarsUI();  
        liveUI.fillAmount = (float)currentLive / maxLive;
    }

    

    private void showBarsUI()
    {
        lifeBarObject.alpha = 1;
        armorBarObject.alpha = 1;
        showBars = true;
        Invoke("HideBarsUI", hideBarsSeconds);
    }

    private void HideBarsUI()
    {
        showBars = false;
    }




}
