using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    [SerializeField]
    private AudioSource getda_fx,getvang_fx,getvanglon_fx,getkimcuong_fx,congtien_fx,thaday_fx,keoday_fx,dongho_fx,touch_fx,fail_fx,win_fx;

    void Awake() {
        if (instance==null)
        {
            instance = this;
        }
    }

    public void GetDa(){
        getda_fx.Play();
    }
    public void GetVang(){
        getvang_fx.Play();
    }
    public void GetVangLon(){
        getvanglon_fx.Play();
    }
    public void GetKimCuong(){
        getkimcuong_fx.Play();   
    }
    public void CongTien(){
        congtien_fx.Play();
    }
    public void ThaDay(bool playFX)
    {
        if (playFX)
        {
            if (!thaday_fx.isPlaying)
            {
                thaday_fx.Play();
            }
        }else
        {
            if (thaday_fx.isPlaying)
            {
                thaday_fx.Stop();
            }
        }
    }
    public void KeoDay(bool playFX){

        if (playFX)
        {
            if (!keoday_fx.isPlaying)
            {
                keoday_fx.Play();
            }
        }else
        {
            if (keoday_fx.isPlaying)
            {
                keoday_fx.Stop();
            }
        }
    }
    public void DongHo(){
        dongho_fx.Play();
    }
    public void Touch(bool playFX){
        if (playFX)
        {
            if (!touch_fx.isPlaying)
            {
                touch_fx.Play();
            }
        }else
        {
            if (touch_fx.isPlaying)
            {
                touch_fx.Stop();
            }
        }
    }
    public void Fail(){
        fail_fx.Play();
    }
    public void Win(){
        win_fx.Play();
    }
}
