using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Assets.Characters
{
/// <summary>
    /// The main character script.
    /// </summary>
    public class MainCharacter : MainCreature
    {
        public Animator Animator;
        
        
        public void SetState(MainAnimationState state)
        {
            foreach (var variable in new[] {"Idle","Running","Jumping","Dead" })
            {
                Animator.SetBool(variable, false);
            }

            switch (state)
            {
                case MainAnimationState.Idle: Animator.SetBool("Idle", true); break;
               
                case MainAnimationState.Running: Animator.SetBool("Running", true); break;
              
                case MainAnimationState.Jumping: Animator.SetBool("Jumping", true); break;
                
                case MainAnimationState.Dead: Animator.SetBool("Dead", true); break;
                
            }

            //Debug.Log("SetState: " + state);
        }

        public MainAnimationState GetState()
        {
            if (Animator.GetBool("Idle")) return MainAnimationState.Idle;
            if (Animator.GetBool("Running")) return MainAnimationState.Running;
            if (Animator.GetBool("Jumping")) return MainAnimationState.Jumping;
            if (Animator.GetBool("Dead")) return MainAnimationState.Dead;
            return MainAnimationState.Idle;
        }
    }
}
