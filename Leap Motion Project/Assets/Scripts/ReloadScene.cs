using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Leap.Unity;
using Leap;

public class ReloadScene : MonoBehaviour
{
    //private LeapServiceProvider P = new LeapServiceProvider();

    private float startTime;
    // Use this for initialization
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        LeapProvider provider = Hands.Provider;

        Hand hand = null;
        //If we found a provider, pull the hand from that
        if (provider != null)
        {
            var frame = provider.CurrentFrame;

            if (frame != null)
            {
                hand = frame.Get(Chirality.Right);
                if (hand == null)
                    hand = frame.Get(Chirality.Left);
            }
        }
        if (hand == null)
            print("未检测到手");
        else
        {
            if (isCloseHand(hand))
            {
                print("检测到握拳");
                if (Time.time - startTime >= 3)
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            if (isTwoHand(hand) && Time.time - startTime >= 3)
            {
                print("检测到剪刀手势");
                if(SceneManager.GetActiveScene().name.Equals("Main"))//若当前场景为Main则不进行场景切换
                    SceneManager.LoadScene("TurnOnLamp");
                else
                    SceneManager.LoadScene("Main");
            }
        }
        //bool isconnected = P.IsConnected();
        //print("isconnected:" + isconnected);
    }
    protected bool isCloseHand(Hand hand)     //是否握拳 
    {
        List<Finger> ListOfFingers = hand.Fingers;
        int count = 0;
        for (int i = 0; i < ListOfFingers.Count; i++)//循环遍历所有的手~~
        {
            Finger finger = ListOfFingers[i];
            if ((finger.TipPosition - hand.PalmPosition).Magnitude < 0.05)    // Magnitude  向量的长度 。是(x*x+y*y+z*z)的平方根。                                                        
            {
                count++;
            }
        }
        return (count == 5);
    }
    protected bool isTwoHand(Hand hand)     //是否比剪刀手 
    {
        List<Finger> ListOfFingers = hand.Fingers;
        int count = 0;
        for (int i = 0; i < ListOfFingers.Count; i++)//循环遍历所有的手~~
        {
            Finger finger = ListOfFingers[i];
            if (
                (finger.Type == Finger.FingerType.TYPE_THUMB || finger.Type == Finger.FingerType.TYPE_PINKY || finger.Type == Finger.FingerType.TYPE_RING)
                && (finger.TipPosition - hand.PalmPosition).Magnitude < 0.05)    // Magnitude  向量的长度 。是(x*x+y*y+z*z)的平方根。                                                        
            {
                count++;
            }
            else if ((finger.Type == Finger.FingerType.TYPE_INDEX || finger.Type == Finger.FingerType.TYPE_MIDDLE)
                && (finger.TipPosition - hand.PalmPosition).Magnitude > 0.07)
            {
                count++;
            }
        }
        return (count == 5);
    }
}