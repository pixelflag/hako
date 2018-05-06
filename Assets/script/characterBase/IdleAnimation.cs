using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleAnimation : MonoBehaviour
{
    private Sprite[] sprites;

    void Start ()
    {
        sprites = Resources.LoadAll<Sprite>(GetComponent<Character>().path + "/idle/");
    }

    public Sprite GetSprite(CharacterDirection direction)
    {
        switch (direction)
        {
            case CharacterDirection.RIGHT: return sprites[3];
            case CharacterDirection.UP:    return sprites[2];
            case CharacterDirection.LEFT:  return sprites[1];
            case CharacterDirection.DOWN:  return sprites[0];
        }
        return sprites[0];
    }
}
