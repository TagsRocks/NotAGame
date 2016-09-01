﻿using UnityEngine;
using System.Collections;

public class controller : MonoBehaviour
{
		

		public float speed = 6.0F;
		public float jumpSpeed = 20.0F;
		public float gravity = 10.0F;
		private Vector3 moveDirection = Vector3.zero;
		
		void Start(){}
		
		void Update() {
			CharacterController controller = GetComponent<CharacterController>();
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= speed;
			if (Input.GetButton("Jump")){
				//mycamera.jumpCount += 1f;
				moveDirection.y = jumpSpeed;
			}
			moveDirection.y -= gravity * Time.deltaTime;
			controller.Move(moveDirection * Time.deltaTime);
		}
		
}
