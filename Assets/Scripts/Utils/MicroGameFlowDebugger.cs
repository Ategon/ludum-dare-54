namespace Auboreal {

	using UnityEngine.SceneManagement;
	using UnityEngine;

	public class MicroGameFlowDebugger : MonoBehaviour {

		private int m_SelectedGameIndex = 0;
		private bool m_ShowDebugGUI = false;

		private void OnEnable() {
			EventManager.Debug.OnTriggerNextMicroGame += OnTriggerNextMicroGame;
		}

		private void OnDisable() {
			EventManager.Debug.OnTriggerNextMicroGame -= OnTriggerNextMicroGame;
		}

		private void OnTriggerNextMicroGame() {
			PersistentData.Instance.SwitchScene(PersistentData.Instance.GetRandomMicroGame(), LoadSceneMode.Additive);
		}

	}

}