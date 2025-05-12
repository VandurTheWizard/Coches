using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    [Header("Player Collisions Settings")]
    public float inmunityTime4Trap = 2f;



    private PlayerLife playerLife;
    private bool inmunity4Trap = false;
    private float actualDamage4Trap = 0;

    void Start()
    {
        playerLife = GetComponent<PlayerLife>();
    }

    void Update(){
        if(!inmunity4Trap && actualDamage4Trap > 0){
            
            inmunity4Trap = true;
            playerLife.TakeDamage((int)actualDamage4Trap);
            
            Invoke("ChangeInmunity4Trap", inmunityTime4Trap);
        }
    }

    private void ChangeInmunity4Trap()
    {
        inmunity4Trap = false;
    }
}
