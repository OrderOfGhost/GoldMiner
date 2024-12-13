using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
private Animator anim;

    void Awake() {
        anim = GetComponent<Animator>();
    }

    public void DungYenAnimation() {
        anim.Play(AnimationTags.DUNGYEN_ANIMATION);
    }

    public void BanXuongAnimation() {
        anim.Play(AnimationTags.BANXUONG_ANIMATION);
    }

    public void KeoLenNheAnimation() {
        anim.Play(AnimationTags.KEOLEN1_ANIMATION);
    }

    public void KeoLenNangAnimation() {
        anim.Play(AnimationTags.KEOLEN2_ANIMATION);
    }

    public void NemBomAnimation() {
        anim.Play(AnimationTags.NEMBOM_ANIMATION);
    }

    public void AnMungAnimation() {
        anim.Play(AnimationTags.ANMUNG_ANIMATION);
    }
}
