using UnityEngine;

public class MedicalKit : MonoBehaviour
{
    [Header("Medical Kit Settings")]
    public int heal = 3;
    
    void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")){
            other.GetComponent<PlayerLife>().Heal(heal);
            Destroy(gameObject);
        }
    }
}
