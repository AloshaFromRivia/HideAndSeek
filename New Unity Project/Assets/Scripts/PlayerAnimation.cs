using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private float _animationSpeed = 0.1f;
    private int _currentFrame;
    private SpriteRenderer _renderer;
    [SerializeField] private Sprite[] _standSprites;
    private float _time;
    [SerializeField] private Sprite[] _walkSprites;
    private PlayerController player;

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

    private void Awake()
    {
        player = GetComponentInParent<PlayerController>();
        _renderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        switch (player.action)
        {
            case PlayersAction.Stand:
                if (_currentFrame >= 4)
                {
                    _currentFrame = 0;
                }
                Animation(_standSprites);
                break;

            case PlayersAction.Walk:
                Animation(_walkSprites);
                break;

            default:
                break;
        }
    }
}