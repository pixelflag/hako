using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkAnimation : MonoBehaviour
{
    [SerializeField]
    private int animationTotalFrame = 4;
    [SerializeField]
    private int animationSpeed = 12;

    [SerializeField]
    private int rightHeadFrame = 12;
    [SerializeField]
    private int upHeadFrame = 8;
    [SerializeField]
    private int leftHeadFrame = 4;
    [SerializeField]
    private int downHeadFrame = 0;

    protected int animationFrame = 0;
    protected int animationCount = 0;

    private Sprite[] sprites;

    void Start ()
    {
        sprites = Resources.LoadAll<Sprite>(GetComponent<Character>().path + "/walk/");
    }

    public void ResetFrame()
    {
        animationFrame = 0;
        animationCount = 0;
    }

    public Sprite GetSprite(CharacterDirection direction)
    {

        animationCount++;

        if (animationSpeed <= animationCount)
        {
            animationFrame += 1;
            animationCount = 0;
        }

        if (animationTotalFrame <= animationFrame)
        {
            animationFrame = 0;
        }

        switch (direction)
        {
            case CharacterDirection.DOWN:  return sprites[downHeadFrame + animationFrame];
            case CharacterDirection.LEFT:  return sprites[leftHeadFrame + animationFrame];
            case CharacterDirection.UP:    return sprites[upHeadFrame + animationFrame];
            case CharacterDirection.RIGHT: return sprites[rightHeadFrame + animationFrame];
        }
        return sprites[0];
    }
}
