using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator _animator;
    private PlatformMovement _platformMovement;
    private SpriteRenderer _rend;

    public AudioClip pewClip;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _platformMovement = GetComponent<PlatformMovement>();
        _rend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        switch(_platformMovement.GetCurrentState())
        {
            case PlayerState.IDLE:
                _animator.SetBool("isWalking", false);
                break;
            case PlayerState.WALKING:
                _animator.SetBool("isWalking", true);
                break;
            case PlayerState.JUMPING:
                break;
        }

        if(_platformMovement.GetDirection().x < 0) 
        {
            _rend.flipX = true;
        }
        else if(_platformMovement.GetDirection().x > 0)
        {
            _rend.flipX = false;
        }
    }

    public void PlayPew(float volume)
    {
        AudioManager.instance.PlayAudio(pewClip, "pewpew", false, volume);
    }
}
