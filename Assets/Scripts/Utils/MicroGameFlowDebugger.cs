namespace Auboreal {

	using System.Linq;
	using UnityEngine;

	public class MicroGameFlowDebugger : MonoBehaviour {

		private int m_SelectedGameIndex = 0;
		private bool m_ShowDebugGUI = false;

		private void Start() {
			EventManager.Debug.MicroGameSelected(PersistentData.Instance.GetRandomMicroGame());
		}

		private void Update() {
			if (Input.GetKeyDown(KeyCode.Space)) {
				EventManager.Debug.MicroGameSelected(PersistentData.Instance.GetRandomMicroGame());
			}

			if (Input.GetKeyDown(KeyCode.D)) {
				m_ShowDebugGUI = !m_ShowDebugGUI;
			}
		}

		private void OnGUI() {
			if (!m_ShowDebugGUI) return;

			GUILayout.BeginArea(new Rect(10, 10, 250, 400));
			GUILayout.Label("Select a MicroGame:");

			m_SelectedGameIndex =
				GUILayout.SelectionGrid(m_SelectedGameIndex,
					PersistentData.Instance.microgames.Select(mg => mg.name).ToArray(), 1);

			if (GUILayout.Button("Load Selected MicroGame")) {
				EventManager.Debug.MicroGameSelected(PersistentData.Instance.microgames[m_SelectedGameIndex]);
			}

			GUILayout.EndArea();
		}

	}

}