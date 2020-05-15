using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity.Attributes;

namespace Leap.Unity
{
    public class HandGraphicScript : HandModel
    {
        private Hand _hand;

        public override ModelType HandModelType
        {
            get
            {
                return ModelType.Graphics;
            }
        }

        public override bool SupportsEditorPersistence()
        {
            return true;
        }

        public override Hand GetLeapHand()
        {
            return _hand;
        }

        public override void SetLeapHand(Hand hand)
        {
            _hand = hand;
        }

        public override void InitHand()
        {
            UpdateHand();
        }

        public override void BeginHand()
        {
            base.BeginHand();
        }

        public override void UpdateHand()
        {
            if (palm != null)
            {
                //获取手掌位置数据与旋转方向数据，并应用于手模型的root bone进行绘制
                palm.position = _hand.PalmPosition.ToVector3();
                palm.rotation = _hand.Rotation.ToQuaternion();

                //对左右手进行不同的方向与位置修正
                if (_hand.IsLeft)
                {
                    palm.position += new Vector3(-0.01f, 0, -0.0518f);
                    palm.transform.Rotate(new Vector3(0.93f, -87.217f, 4.67f));
                }
                else if(_hand.IsRight)
                {
                    palm.position += new Vector3(0, 0, -0.057f);
                    palm.transform.Rotate(new Vector3(178.289f, 90.9839f, 3.267f));
                }

            }

            for (int i = 0; i < fingers.Length; ++i)
            {
                if (fingers[i] != null)
                {
                    setFinger(fingers[i],i);
                }
            }

        }
        private  Vector3 modelFingerPointing = Vector3.forward;
        private  Vector3 modelPalmFacing = -Vector3.up;

        public Quaternion Reorientation()
        {
            return Quaternion.Inverse(Quaternion.LookRotation(modelFingerPointing, -modelPalmFacing));
        }

        private void setFinger(FingerModel finger,int type)
        {
            for (int i = 0; i < finger.bones.Length; i++)
            {
                if (finger.bones[i] != null)
                {
                    //finger.bones[i].position = GetBoneCenter(i);
                    
                    
                    Debug.Log("Finger " +finger.fingerType+",Bone "+i+"  Rotation:"+_hand.Fingers[type].bones[i].Rotation.ToQuaternion());
                    Debug.Log("eulerAngles"+_hand.Fingers[type].bones[i].Rotation.ToQuaternion().eulerAngles);
                }
            }
        }
    }
}
