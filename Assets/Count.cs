using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Auboreal {
    public class Count : MonoBehaviour
{
    private InputHandler inputs;
    public TextMeshProUGUI text;

    bool buffer = false;
    float timer = 0;
    public int count = 0;

    private void Start()
    {
        inputs = FindObjectOfType<InputHandler>();
    }

    private void FixedUpdate()
    {
        if (!buffer)
        {
            if (inputs.Input.x < 0 && count > 0)
            {
                count -= 1;
                text.text = $"{count}";
                buffer = true;
            }
            else if (inputs.Input.x > 0)
            {
                count += 1;
                text.text = $"{count}";
                buffer = true;
            }
        }
        else
        {
            timer += Time.deltaTime;

            if (inputs.Input.x != 0)
            {
                timer = 0;
            }

            if (timer > 0.25f)
            {
                buffer = false;
            }
        }
    }
}

}