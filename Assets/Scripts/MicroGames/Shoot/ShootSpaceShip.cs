namespace Auboreal {

	using System;
	using DG.Tweening;
	using UnityEngine;

	public class ShootSpaceShip : MonoBehaviour {

		public float spaceShipSpeed;
		public float spaceShipThurst;
		public Camera mainCamera;
		public SpriteRenderer spaceShipRenderer;

		private float m_SpriteWidth;
		private InputHandler m_InputHandler;

		private enum MoveState {

			Idle = 0,
			Right = 1,
			Left = 2

		}

		public void OnGameStarted() {
			m_SpriteWidth = spaceShipRenderer.bounds.size.x;
			m_InputHandler = FindObjectOfType<InputHandler>();
		}

		private void Update() {
			ProcessInputs();
		}

		private void ProcessInputs() {
			var currentPos = this.transform.position;
			var leftBoundary = mainCamera.ScreenToWorldPoint(Vector3.zero).x + m_SpriteWidth;
			var rightBoundary = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x - m_SpriteWidth;

			if (m_InputHandler.Input.x > 0 && currentPos.x < rightBoundary) {
				Move(MoveState.Right);
			}
			else if (m_InputHandler.Input.x < 0 && currentPos.x > leftBoundary) {
				Move(MoveState.Left);
			}
			else {
				Move(MoveState.Idle);
			}
		}


		private void Move(MoveState moveState) {
			var currentPos = this.transform.position;

			switch (moveState) {
				case MoveState.Idle:
					break;
				case MoveState.Right:
					this.transform.DOMoveX(currentPos.x + spaceShipThurst, spaceShipSpeed);
					break;
				case MoveState.Left:
					this.transform.DOMoveX(currentPos.x - spaceShipThurst, spaceShipSpeed);
					break;
				default:
					throw new ArgumentOutOfRangeException(nameof(moveState), moveState, null);
			}
		}

	}

}