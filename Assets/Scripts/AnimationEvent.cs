using UnityEngine;

public class AnimationEvent : MonoBehaviour
{

    [SerializeField] PlayerCombat playerCombat;

    public void DealDamage()
    {
        playerCombat.DealDamage();
    }

    public void FinishedAttacking()
    {
        playerCombat.FinishAttacking();
    }
}
