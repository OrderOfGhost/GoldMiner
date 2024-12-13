using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookSc : MonoBehaviour
{
   
    public int scoreValue=0;
    [SerializeField]
    private Transform itemHolder;

    private bool itemAttached;

    private HookMov hookMovement;

    private PlayerAnimation playerAnim;

    void Awake() {
        hookMovement = GetComponentInParent<HookMov>();
        playerAnim = GetComponentInParent<PlayerAnimation>();
    }

    void OnTriggerEnter2D(Collider2D target) {

        if(target.tag == Tags.VANG_VUA || target.tag == Tags.VANG_TO ||
            target.tag == Tags.VANG_SIEUTO || target.tag == Tags.KIM_CUONG1 ||
            target.tag == Tags.KIM_CUONG2 || target.tag == Tags.KIM_CUONG3 ||
            target.tag == Tags.TUI_QUA || target.tag == Tags.CHUOT_THUONG || 
            target.tag == Tags.CHUOT_KIMCUONG1 || target.tag == Tags.CHUOT_KIMCUONG2 || 
            target.tag == Tags.CHUOT_KIMCUONG3 || target.tag == Tags.CHUOT_VANG || 
            target.tag == Tags.DA ){

            itemAttached = true;
            
            

            target.transform.parent = itemHolder;
            target.transform.position = itemHolder.position;

            hookMovement.move_Speed = target.GetComponent<ItemScript>().hook_Speed;
            scoreValue = target.GetComponent<ItemScript>().scoreValue;

            hookMovement.HookAttachedItem();

            // animate player
            if(hookMovement.move_Speed<=2)
            {
                playerAnim.KeoLenNangAnimation();
            }else{
                playerAnim.KeoLenNheAnimation();
            }

            if (target.tag == Tags.VANG_VUA || target.tag == Tags.VANG_TO) {

                 SoundManager.instance.GetVang();

            } else if (target.tag == Tags.DA ) {

                 SoundManager.instance.GetDa();
            }else if (target.tag== Tags.KIM_CUONG1 || target.tag== Tags.KIM_CUONG2 || target.tag== Tags.KIM_CUONG3)
            {
                SoundManager.instance.GetKimCuong();
            }else if(target.tag == Tags.VANG_SIEUTO){
                SoundManager.instance.GetVangLon();
            }

            SoundManager.instance.KeoDay(true);

        } // if target is an item


        if(target.tag == Tags.DELIVER_ITEM2) { 

            playerAnim.DungYenAnimation();

            if(itemAttached) {

                itemAttached = false;

                Transform objChild = itemHolder.GetChild(0);

                objChild.parent = null;
                objChild.gameObject.SetActive(false);
                GameplayManager2.instance.DisplayScore2(scoreValue);

                SoundManager.instance.KeoDay(false);
            }

        } // deliver item

    } // on trigger enter
}
