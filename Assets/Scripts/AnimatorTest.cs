using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorTest1 : MonoBehaviour
{
    public Animator animator;
    public KeyCode keyToTrigger = KeyCode.A;
    public string triggerToPlay = "Fly";

    private void OnValidate()
    {
        if (animator == null) animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(keyToTrigger))
        {
            animator.SetTrigger(triggerToPlay);
        }
    }
}
