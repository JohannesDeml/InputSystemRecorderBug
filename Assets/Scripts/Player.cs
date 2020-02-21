// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Player.cs" company="Supyrb">
//   Copyright (c) 2020 Supyrb. All rights reserved.
// </copyright>
// <author>
//   Johannes Deml
//   public@deml.io
// </author>
// --------------------------------------------------------------------------------------------------------------------

using UnityEngine;

namespace Supyrb
{
	public class Player : MonoBehaviour
	{
		[SerializeField]
		private PlayerInputController playerInputController = null;

		[SerializeField]
		private float moveSpeed = 3f;

		private void FixedUpdate()
		{
			var inputX = playerInputController.ProcessMoveInput();

			transform.position += new Vector3(inputX * moveSpeed * Time.deltaTime, 0f, 0f);
		}

		#if UNITY_EDITOR
		private void Reset()
		{
			if (playerInputController == null)
			{
				playerInputController = GetComponent<PlayerInputController>();
			}
		}
		#endif
	}
}