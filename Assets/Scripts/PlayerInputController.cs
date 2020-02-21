// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PlayerInputController.cs" company="Supyrb">
//   Copyright (c) 2020 Supyrb. All rights reserved.
// </copyright>
// <author>
//   Johannes Deml
//   public@deml.io
// </author>
// --------------------------------------------------------------------------------------------------------------------

using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Supyrb
{
	public class PlayerInputController : MonoBehaviour
	{
		[SerializeField]
		private float moveButtonLerpSpeed = 2.5f;

		private PlayerInputActions playerInputActions;
		private bool jump;
		private float move;


		private void Awake()
		{
			playerInputActions = new PlayerInputActions();
			playerInputActions.Enable();
			Subscribe();
		}

		private void Subscribe()
		{
			playerInputActions.Player.Jump.started += OnJump;
		}

		private void OnDestroy()
		{
			Unsubscribe();
		}

		private void Unsubscribe()
		{
			playerInputActions.Player.Jump.started -= OnJump;
		}

		public bool ProcessJumpInput()
		{
			var jumpValue = jump;
			jump = false;
			return jumpValue;
		}

		public float ProcessMoveInput()
		{
			var buttonMove = ProcessButtonMoveInput();
			var axisMove = ProcessAxisMove();

			move = Mathf.Clamp(buttonMove + axisMove, -1f, 1f);
			return move;
		}

		private float ProcessButtonMoveInput()
		{
			var input = playerInputActions.Player.ButtonLeft.ReadValue<float>();
			input += playerInputActions.Player.ButtonRight.ReadValue<float>();
			if (Mathf.Abs(input) <= Mathf.Epsilon)
			{
				return 0f;
			}

			return Mathf.Lerp(move, input, Time.deltaTime * moveButtonLerpSpeed);
		}

		private float ProcessAxisMove()
		{
			return playerInputActions.Player.Move.ReadValue<float>();
		}

		private void OnJump(InputAction.CallbackContext action)
		{
			jump = true;
		}

		private void InitializeGame()
		{
			jump = false;
			move = 0f;
		}
	}
}