using UnityEngine;

public class AnimationEvent : MonoBehaviour
{

    [SerializeField] PlayerCombat playerCombat;

    [SerializeField] PlayerAudio playerAudio;

    public void DealDamage()
    {
        playerCombat.DealDamage();
    }

    public void FinishedAttacking()
    {
        playerCombat.FinishAttacking();
    }

    public void AttackSound()
    {
        playerAudio.PlayAttackSound();
    }

    public void WalkSound()
    {
        playerAudio.PlayWalkAudio();
    }
}
