namespace Auboreal {

	using System.Linq;
	using UnityEngine;

	public class MicroGameFlowDebugger : MonoBehaviour {

		private int m_SelectedGameIndex = 0;

		private void Start() {
			EventManager.MicroGameSelected(PersistentData.Instance.GetRandomMicroGame());
		}

		private void Update() {
			if (Input.GetKeyDown(KeyCode.Space)) {
				EventManager.MicroGameSelected(PersistentData.Instance.GetRandomMicroGame());
			}
		}

		private void OnGUI() {
			GUILayout.BeginArea(new Rect(10, 10, 250, 400));
			GUILayout.Label("Select a MicroGame:");

			m_SelectedGameIndex =
				GUILayout.SelectionGrid(m_SelectedGameIndex,
					PersistentData.Instance.microgames.Select(mg => mg.name).ToArray(), 1);

			if (GUILayout.Button("Load Selected MicroGame")) {
				EventManager.MicroGameSelected(PersistentData.Instance.microgames[m_SelectedGameIndex]);
			}

			GUILayout.EndArea();
		}

	}

}