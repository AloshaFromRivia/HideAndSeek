using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private SpriteRenderer _renderer;
    private float _time;
    private int _currentFrame;
    [SerializeField] private Sprite[] _walkSprites;
    [SerializeField] private Sprite[] _standSprites;
    [SerializeField] private float _animationSpeed = 0.1f;
    private PlayerController player;


    private void Awake()
    {
        player = GetComponentInParent<PlayerController>();
        _renderer = GetComponent<SpriteRenderer>();
    }

   
    void Update()
    {
        switch (player.action)
        {
            case playersAction.Stand:
                if (_currentFrame >= 4)
                {
                    _currentFrame = 0;
                }
                Animation(_standSprites);
                break;
            case playersAction.Walk:
                Animation(_walkSprites);
                break;
            default:
                break;
        }
    }



    private void Animation(Sprite[] anim)
    {
            _time += Time.deltaTime;
            if (_time >= _animationSpeed)
            {
                _time = 0;
                _renderer.sprite = anim[_currentFrame];
                _currentFrame++;
                if (_currentFrame == anim.Length - 1)
                {
                    _currentFrame = 0;
                }
            }
        else return;
    }
}
