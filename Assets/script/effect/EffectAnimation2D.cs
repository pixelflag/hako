using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectAnimation2D : PixelObjectBase
{
    protected const string BASE_PATH = "sprite/";

    [SerializeField]
    protected string path = "effect/";

    [SerializeField]
    private int speed = 3;

    [SerializeField]
    private bool isLoop = false;

    private Sprite[] sprites;

    private bool _isDead;

    private bool _isPlaying;
    public bool isPlaying
    {
        get
        {
            return _isPlaying;
        }
    }

    private int count = 0;
    private int frame = 0;
    private int totalFrame = 0;

    protected SpriteRenderer spriteRenderer;

    void Start ()
    {
        sprites = Resources.LoadAll<Sprite>(BASE_PATH + path);
        totalFrame = sprites.Length;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        _isPlaying = true;
    }
	
	public void Update ()
    {
        if (_isPlaying)
        {
            spriteRenderer.sprite = sprites[frame];
                count++;

            if (speed <= count)
            {
                count = 0;
                frame++;
                if (totalFrame <= frame)
                {
                    frame = 0;

                    if (isLoop)
                    {
                        return;
                    }
                    else
                    {
                        _isPlaying = false;
                        _isDead = true;
                        Destroy(gameObject);
                        return;
                    }
                }
            }
        }
    }

    public void Play()
    {
        if (!_isDead)
        {
            _isPlaying = true;
        }
    }

    public void Destroy()
    {
        count = 0;
        frame = 0;
        _isPlaying = false;

        _isDead = true;
        Destroy(gameObject);
    }
}
