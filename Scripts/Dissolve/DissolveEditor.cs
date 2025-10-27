using UnityEngine;
using System.Collections;
using System.Collections.Generic;

# if UNITY_EDITOR
using UnityEditor;

[CustomEditor(typeof(DissolveAnimation))]
public class DissolveEditor : Editor {
    public override void OnInspectorGUI() {
        DrawDefaultInspector();
        DissolveAnimation dissolveScript = (DissolveAnimation)target;
        
        if (GUILayout.Button("Appear")) {
            dissolveScript.DissolveDisappear();
        }
        if (GUILayout.Button("Disappear"))  {
            dissolveScript.DissolveAppear();
        }

        if (GUILayout.Button("PingPong"))  {
            dissolveScript.DissolvePingPong();
        }
        
        if (GUILayout.Button("Stop all Coroutines"))  {
            dissolveScript.StopAllCoroutines();
        }
    }
}
#endif
