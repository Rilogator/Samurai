﻿using UnityEngine;
using RoboRyanTron.Unite2017.Variables;

public class SidescrollerMovement : MonoBehaviour
{
	public FloatReference maxSpeed;
	public FloatReference accel;

	private Rigidbody2D myBody;

	private float _moveX, _moveY;
	private Vector2 movement;

	private Animator anim;

	// Use this for initialization
	void Start ()
	{
		myBody = this.GetComponent<Rigidbody2D>();
		anim = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		_moveX = Input.GetAxisRaw("Horizontal");
		movement = new Vector3(_moveX, _moveY).normalized;
	}

	private void FixedUpdate()
	{
		Move();
	}

	public void Move()
	{
		if ((myBody.velocity.x > maxSpeed && _moveX < 0)
			|| (myBody.velocity.x < -maxSpeed && _moveX > 0)
			|| Mathf.Abs(myBody.velocity.x) < maxSpeed)
			myBody.AddForce(new Vector3(movement.x, 0) * accel * Time.deltaTime);		
	}
}
