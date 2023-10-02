using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DiscreteWave : MonoBehaviour
{
    private TextMeshProUGUI text;
    private float timer;
    [SerializeField] private float amplitude = 1f;
    [SerializeField] private float speed = 3f;
    private int character = 0;

    void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
        text.ForceMeshUpdate();
    }

    void FixedUpdate()
    {
        timer += Time.deltaTime;
        text.ForceMeshUpdate();

        int nextCharacter = Mathf.FloorToInt(timer * speed % text.textInfo.characterCount);

        if (nextCharacter != character)
        {
            TMP_CharacterInfo charInfo = text.textInfo.characterInfo[character];
            var verts = text.textInfo.meshInfo[charInfo.materialReferenceIndex].vertices;

            for (int j = 0; j < 4; ++j)
            {
                var orig = verts[charInfo.vertexIndex + j];
                verts[charInfo.vertexIndex + j] = orig + new Vector3(0, -amplitude, 0);
            }

            TMP_CharacterInfo newCharInfo = text.textInfo.characterInfo[nextCharacter];
            var newVerts = text.textInfo.meshInfo[newCharInfo.materialReferenceIndex].vertices;

            for (int j = 0; j < 4; ++j)
            {
                var orig = verts[newCharInfo.vertexIndex + j];
                verts[newCharInfo.vertexIndex + j] = orig + new Vector3(0, amplitude, 0);
            }

            for (int i = 0; i < text.textInfo.meshInfo.Length; ++i)
            {
                var meshInfo = text.textInfo.meshInfo[i];
                meshInfo.mesh.vertices = meshInfo.vertices;
                text.UpdateGeometry(meshInfo.mesh, i);
            }
        }
    }
}
