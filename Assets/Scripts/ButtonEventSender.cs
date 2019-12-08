using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class ButtonEventSender : MonoBehaviour {
        public static Action onChooseRock = delegate { };
        public static Action onChoosePaper = delegate { };
        public static Action onChooseScissors = delegate { };
        public void ChooseRock () { onChooseRock (); }
        public void ChoosePaper () { onChoosePaper (); }
        public void ChooseScissors () { onChooseScissors (); }
    }
}