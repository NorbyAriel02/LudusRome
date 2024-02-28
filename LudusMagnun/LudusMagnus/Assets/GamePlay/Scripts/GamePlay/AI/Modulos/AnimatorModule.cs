using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimatorModule : MonoBehaviour
{
    public List<string> triggers;
    Animator animator;    
    Seguir seguir;
    Patrullar patrullar;    
    AnimatorClipInfo[] animations;
    void Start()
    {
        animator = GetComponent<Animator>();
        seguir = GetComponent<Seguir>();
        patrullar = GetComponent<Patrullar>();
        SetEvents();
        animations = animator.GetCurrentAnimatorClipInfo(0);
    }
    void SetEvents()
    {
        State[] states = GetComponents<State>();
        foreach(State state in states)
        {
            state.OnEnter.AddListener(delegate { AnimationTrigger(state.nextState.animationTrigger); });
        }
    }
    private void FixedUpdate()
    {
        if(seguir.enabled) 
            animator.SetFloat("MoveSpeed", seguir.GetVelocity());
        
        if (patrullar.enabled)
            animator.SetFloat("MoveSpeed", patrullar.GetVelocity());
    }
    public float GetAnimationDutarion(string name)
    {
        foreach(AnimatorClipInfo clipInfo in animations)
        {
            if (clipInfo.clip.name == name)
                return clipInfo.clip.length;
        }
        return 0;
    }
    
    public void AnimationTrigger(string parameterTrigger)
    {
        print(" animacion " + parameterTrigger);
        animator.SetTrigger(parameterTrigger);
    }
}
