namespace Auboreal {

	using UnityEngine;

	public class Singleton<T> : MonoBehaviour where T : MonoBehaviour {

		private static T m_Instance;

		public static T Instance {
			get {
				if (m_Instance == null) {
					m_Instance = FindObjectOfType<T>();

					if (m_Instance == null) {
						var obj = new GameObject();
						obj.name = typeof(T).Name;
						m_Instance = obj.AddComponent<T>();
					}
				}

				return m_Instance;
			}
		}

		protected virtual void Awake() {
			if (m_Instance != null && m_Instance != this) {
				Destroy(this.gameObject);
			}
			else {
				m_Instance = this as T;
				DontDestroyOnLoad(this.gameObject);
			}
		}

	}

}