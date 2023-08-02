using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    Vector2 rawInput;

    [SerializeField] float paddingRight;
    [SerializeField] float paddingLeft;     //padding kısmında yaptığımız şey oyuncuyu ekranın dışına çıkarmamak
    [SerializeField] float paddingTop;
    [SerializeField] float paddingBottom;

    Vector2 minBounds;
    Vector2 maxBounds;  //bounds ve initbound() yaptığımız şey ise oyunu kameranın gördüğü yerde tutmak

    Shooter shooter;

    void Awake()
    {
        shooter = GetComponent<Shooter>();   
    }

      void Start()
    {
        InitBounds();
    }
    void InitBounds()
    {
        Camera mainCamera = Camera.main;
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0,0));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1,1));
    }
    void Update()
    {
        Move();
    }
    void Move()
    {
        Vector2 delta = rawInput * moveSpeed * Time.deltaTime;  //oyuncumuzun hareketi 
        Vector2 newPos = new Vector2();
        newPos.x = Mathf.Clamp(transform.position.x + delta.x, minBounds.x + paddingRight, maxBounds.x - paddingLeft);
        newPos.y = Mathf.Clamp(transform.position.y + delta.y, minBounds.y + paddingBottom, maxBounds.y - paddingTop);
        transform.position = newPos;
    }
    void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>();
    }

    void OnFire(InputValue value)
    {
        if(shooter != null)
        {
            shooter.isFiring = value.isPressed;
        }
    }
}
