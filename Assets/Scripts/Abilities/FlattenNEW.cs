using UnityEngine;

public class FlattenNEW : MonoBehaviour
{
    public bool isFlatten;

    InputManagerNEW inputManagerNEW;
    LanternNEW lantern;
    FrogJumpNEW frogJump;
    ChangeShape changeShape;
    PauseMenu pauseMenu;

    private UnflattenCheck unflattenCheck;
    public Cloth cloak;


    private void Awake()
    {
        inputManagerNEW = GetComponent<InputManagerNEW>();
        lantern = GetComponent<LanternNEW>();
        frogJump = GetComponent<FrogJumpNEW>();
        pauseMenu = GetComponent<PauseMenu>();
        unflattenCheck = GetComponent<UnflattenCheck>();

    }

    void Update()
    {
        if (!pauseMenu.isGamePaused && !pauseMenu.isInventory)
        {
            HandleFlattenX();
            HandleFlattenY();
            HandleUnflatten();
        }
    }

    public void HandleFlattenX()
    {

        if (inputManagerNEW.flattenX && !lantern.isLantern && !frogJump.isFrogJumping) 
        {
            isFlatten = true;
            cloak.enabled = false;
            Debug.Log("FlattenX");
            this.transform.localScale = new Vector3(1, .05f, 1);
        }
    }

    public void HandleFlattenY()
    {
       if(inputManagerNEW.flattenY && !lantern.isLantern && !frogJump.isFrogJumping)
       {
            isFlatten = true;
            cloak.enabled = false;
            Debug.Log("FlattenY");
            transform.localScale = new Vector3(.15f, 1, .75f);
       }
    }

    public void HandleUnflatten()
    {
        if(!inputManagerNEW.flattenX && !inputManagerNEW.flattenY && unflattenCheck.canUnflatten)
        {
            isFlatten = false;
            transform.localScale = new Vector3(1, 1, 1);
            cloak.enabled = true;
        }
    }
}
