using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveEffect : MonoBehaviour
{
    private TextMeshProUGUI text;
    private float timer;
    [SerializeField] private float amplitude = 1f;
    [SerializeField] private float speed = 3f;

    void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
        text.ForceMeshUpdate();
    }

    void FixedUpdate()
    {
        timer += Time.deltaTime;
        text.ForceMeshUpdate();

        for (int i = 0; i < text.textInfo.characterCount; ++i)
        {
            TMP_CharacterInfo charInfo = text.textInfo.characterInfo[i];

            if (!charInfo.isVisible) continue;

            var verts = text.textInfo.meshInfo[charInfo.materialReferenceIndex].vertices;

            for (int j = 0; j < 4; ++j)
            {
                var orig = verts[charInfo.vertexIndex + j];
                verts[charInfo.vertexIndex + j] = orig + new Vector3(0, amplitude * Mathf.Sin(timer * speed + (Mathf.PI * 2 * i / text.textInfo.characterCount)), 0);
            }
        }

        for (int i = 0; i < text.textInfo.meshInfo.Length; ++i)
        {
            var meshInfo = text.textInfo.meshInfo[i];
            meshInfo.mesh.vertices = meshInfo.vertices;
            text.UpdateGeometry(meshInfo.mesh, i);
        }
    }
}
