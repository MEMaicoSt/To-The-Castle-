using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NarrationBox : MonoBehaviour
{
    public Text Narration;
    public float secUntilNextChar = 0.08f;
    public string[] NarrationBoxLines;

    private int nextSentence;

    public Text nextToPlay;

    // Start is called before the first frame update
    void Start()
    {

        NarrationBoxLines = new string[29];

        NarrationBoxLines[0] = "It's tonight. Prince Engel's birthday gala.";
        NarrationBoxLines[1] = "As his best friend, you wanted to attend this special occasion...";
        NarrationBoxLines[2] = "...and gift him with something special that he had been talking about for months prior..";
        NarrationBoxLines[3] = "..as well as spend time with him one more time before your graduation takes place, and you leave for Uni.";
        NarrationBoxLines[4] = "But, as you leave school, you see a crowd comprised of \nhis many, MANY adoring fans.";
        NarrationBoxLines[5] = "They're even crowding the bus stop. Shouldn't be too much of a problem";
        NarrationBoxLines[6] = "since it looks like the bus will be arriving soon, but the bus is filled with even more fans";
        NarrationBoxLines[7] = "all of whom are screaming very loudly.";
        NarrationBoxLines[8] = ".......Hey! It didn't even stop!";
        NarrationBoxLines[9] = "Okay, maybe you can just wait for the next one.";
        NarrationBoxLines[10] = "But....when the bus arrives, more fans rush \npast you, and one even shoves you out of her way.";
        NarrationBoxLines[11] = "Huh. Doesn't look like there are any taxis available either...";
        NarrationBoxLines[12] = "Your last resort, unfortunately, is to walk to the castle yourself.";
        NarrationBoxLines[13] = "You tap on one of their shoulders with an 'Excuse me', but she ignores you.";
        NarrationBoxLines[14] = "You say 'Excuse me.' a little louder, but she just turns around and gives you a dirty look,";
        NarrationBoxLines[15] = "and immediately returns her attention to the castle in the distance.";
        NarrationBoxLines[16] = "'Hey!', you say indignantly. 'I just wanted to go there and give my friend a gift!";
        NarrationBoxLines[17] = "The fan returns her attention to you and says  'Girl, we all want to go see him.";
        NarrationBoxLines[18] = "But you'll just have to wait. You're not special.'";
        NarrationBoxLines[19] = "'WHO?!', one pipes in, 'BUT HE'S MIIIIINE!' ";
        NarrationBoxLines[20] = " 'No, he's MINE!', another says, and they argue.";
        NarrationBoxLines[21] = "And more fans rush outside and shove you,\n saying 'MOVE!' and 'Get out of the way, LOSER.'";
        NarrationBoxLines[22] = ".........\nA feeling, all too familiar, returns to you.....";
        NarrationBoxLines[23] = "Every time there is a big festival or celebration....";
        NarrationBoxLines[24] = "...or even when your dear friend makes an appearance somewhere,\n the crowds are always there...";
        NarrationBoxLines[25] = "..and they always do this to you. Just the sight of you \ntalking to him makes them lose it.";
        NarrationBoxLines[26] = "It's as if they won't allow him to live anywhere except \ninside their own imaginations.";
        NarrationBoxLines[27] = "But, you've had enough of this. It is here that you decide \nnot to let them push you around anymore.";
        NarrationBoxLines[28] = "They WILL get out of your way and \nyou WILL get to the castle tonight.";

        beginningCutsceneLines();
    }

    public void beginningCutsceneLines()
    {
        nextSentence = 0;
        StartCoroutine(begginningCutsceneLinesRoutine());

    }

    IEnumerator begginningCutsceneLinesRoutine()
    {
        
        Narration.text = "";
        foreach(char letter in NarrationBoxLines[nextSentence].ToCharArray())
        {
            Narration.text += letter;
            yield return new WaitForSeconds(secUntilNextChar);
        }
    }

    public void pressButtonToAdvance()
    { 
       if(nextToPlay.text == "Play")
        {
            SceneManager.LoadScene("Level_1");
        }
        nextSentence = nextSentence + 1;
        if(nextSentence == 29)
        {
            nextToPlay.text = "Play";
        }
        else
        StartCoroutine(begginningCutsceneLinesRoutine());
    }
   

    //references: https://docs.unity3d.com/2020.1/Documentation/ScriptReference/Array.html
    //https://www.youtube.com/watch?v=8oTYabhj248
}
