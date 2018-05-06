using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageAnimation : MonoBehaviour
{
    const string DAMAGE_PATH = "damage/";
    private Sprite[] sprites;

    void Start ()
    {
        sprites = Resources.LoadAll<Sprite>(GetComponent<Character>().path + "/damage/");
    }

    public Sprite GetSprite(CharacterDirection direction)
    {
        switch (direction)
        {
            case CharacterDirection.DOWN:  return sprites[0];
            case CharacterDirection.LEFT:  return sprites[1];
            case CharacterDirection.UP:    return sprites[2];
            case CharacterDirection.RIGHT: return sprites[3];
        }
        return sprites[0];
    }
}
