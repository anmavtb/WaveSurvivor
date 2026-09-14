using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(InputManager))]
[RequireComponent(typeof(MovementComponent))]
[RequireComponent(typeof(AttackComponent))]
[RequireComponent(typeof(StatsManager))]
[RequireComponent(typeof(PlayerExp))]
[RequireComponent(typeof(PlayerMagnet))]

public class PlayerBase : Singleton<PlayerBase>
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}