using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndingDialogue : MonoBehaviour
{
    public Text Dialogue;
    public float secUntilNextChar = 0.08f;
    public string[] DialogueBoxLines;

    private int nextSent;

    // Start is called before the first frame update
    void Start()
    {
        DialogueBoxLines = new string[14];

        DialogueBoxLines[0] = "Engel:\nA...Arista! You're here!";
        DialogueBoxLines[1] = "Engel:\nI was afraid you would never come.";
        DialogueBoxLines[2] = "Engel:\n...oh no, did my fans hurt you?";
        DialogueBoxLines[3] = "Arista:\nAh, it's nothing.";
        DialogueBoxLines[4] = "Engel:\nI....I'm so sorry.";
        DialogueBoxLines[5] = "Engel:\nI'm sorry you had to go through so much trouble just to get here.";
        DialogueBoxLines[6] = "Arista:\nI'm fine though. Really.";
        DialogueBoxLines[7] = "Arista:\nI'm just glad I got a chance to hang out with you one last time before I go to Uni.";
        DialogueBoxLines[8] = "Engel:\n(blushes)";
        DialogueBoxLines[9] = "Arista:\nAnd of course I couldn't leave before giving you this!";
        DialogueBoxLines[10] = "(Arista hands him a small wrapped birthday present)";
        DialogueBoxLines[11] = "Engel:\n(His eyes widen) No way! Is it...";
        DialogueBoxLines[12] = "Arista:\nYeah. It is.";
        DialogueBoxLines[13] = "Engel:\n.....Thank you.";

        endingCutsceneLines();
    }

    public void endingCutsceneLines()
    {
        nextSent = 0;
        StartCoroutine(endingCutsceneLinesRoutine());

    }

    IEnumerator endingCutsceneLinesRoutine()
    {

        Dialogue.text = "";
        foreach (char letter in DialogueBoxLines[nextSent].ToCharArray())
        {
            Dialogue.text += letter;
            yield return new WaitForSeconds(secUntilNextChar);
        }
    }

    public void pressNextToAdvance()
    {
        nextSent = nextSent + 1;
        StartCoroutine(endingCutsceneLinesRoutine());
    }

    //references: https://www.youtube.com/watch?v=8oTYabhj248
}
