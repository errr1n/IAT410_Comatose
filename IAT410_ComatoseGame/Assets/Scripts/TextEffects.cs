using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextEffects : MonoBehaviour
{
    public TMP_Text textComponent;

       // Update is called once per frame
    void Update()
    {
        // Make sure TextMesh is constantly updating
        textComponent.ForceMeshUpdate();
        // Stored as varible for reuse
        var textInfo = textComponent.textInfo;

        // Applying effects per character
        // Could change it on a per word basis if needed?
        for (int i = 0; i < textInfo.characterCount; i++) { 
            var charInfo = textInfo.characterInfo[i];

        // Skip invisible characters
        // NOTE Space between words is not invisible
            if (!charInfo.isVisible) 
            {
                continue;
            }

            // Grabbing the TextMesh Vertices
            var verts = textInfo.meshInfo[charInfo.materialReferenceIndex].vertices;


        // Stored as index
            for (int j = 0; j < 4; ++j) 
            {
                var orig = verts[charInfo.vertexIndex + j];
                verts[charInfo.vertexIndex + j] = orig + new Vector3(0, Mathf.Sin(Time.time*2f + orig.x*0.01f) * 10f, 0 );
            }
        }
        
         for (int i = 0; i < textInfo.meshInfo.Length; ++i)
         {
             var meshInfo = textInfo.meshInfo[i];  
             meshInfo.mesh.vertices = meshInfo.vertices;
             textComponent.UpdateGeometry(meshInfo.mesh, i);
        }
    }
}
