using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelect : MonoBehaviour
{
    public bool enableSelectCharacter;
    public enum Player { Frog, VirtualGuy, PinkMan, MaskDude , FrogOrange};
    public Player playerSelected;

    public Animator animator;
    public SpriteRenderer spriteRenderer;

    public RuntimeAnimatorController[] playersController;
    public Sprite[] playersRenderer;


    void Start()

    {

        if (!enableSelectCharacter)
        {
            ChangePlayerInMenu();
        }
        else
        {

            switch (playerSelected)
            {
                case Player.Frog:
                    spriteRenderer.sprite = playersRenderer[0];
                    animator.runtimeAnimatorController = playersController[0];
                    break;
                case Player.PinkMan:
                    spriteRenderer.sprite = playersRenderer[1];
                    animator.runtimeAnimatorController = playersController[1];
                    break;
                case Player.VirtualGuy:
                    spriteRenderer.sprite = playersRenderer[2];
                    animator.runtimeAnimatorController = playersController[2];
                    break;
                case Player.MaskDude:
                    spriteRenderer.sprite = playersRenderer[3];
                    animator.runtimeAnimatorController = playersController[3];
                    break;
                case Player.FrogOrange:
                    spriteRenderer.sprite = playersRenderer[4];
                    animator.runtimeAnimatorController = playersController[4];
                    break;
                default:
                    break;
            }
        }
    }

    public void ChangePlayerInMenu()
    {
        switch (PlayerPrefs.GetString("PlayerSelected"))
        {
            case "Frog":
                spriteRenderer.sprite = playersRenderer[0];
                animator.runtimeAnimatorController = playersController[0];
                break;
            case "PinkMan":
                spriteRenderer.sprite = playersRenderer[1];
                animator.runtimeAnimatorController = playersController[1];
                break;
            case "VirtualGuy":
                spriteRenderer.sprite = playersRenderer[2];
                animator.runtimeAnimatorController = playersController[2];
                break;
            case "MaskDude":
                spriteRenderer.sprite = playersRenderer[3];
                animator.runtimeAnimatorController = playersController[3];
                break;
            case "FrogOrange":
                spriteRenderer.sprite = playersRenderer[4];
                animator.runtimeAnimatorController = playersController[4];
                break;
            default:
                break;
        }
    }
}