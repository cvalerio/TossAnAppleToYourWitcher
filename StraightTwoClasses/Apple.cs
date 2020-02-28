using System;

namespace TossAnAppleToYourWitcher
{
    public class Apple
    {
        public Apple(AppleKind kind)
        {

        }

        public Box Box { get; private set; }

        public void MoveToBox(Box box, int position)
        {
            if(box == null) throw new ArgumentNullException(nameof(box));
            int oldPosition = -1;
            var oldBox = this.Box;
            if (oldBox != null)
            {
                oldPosition = oldBox.GetApplePosition(this);
                oldBox.RemoveApple(this);
            }
            var moved = false;
            try
            {

                this.Box = box;
                Box.SetApplePosition(this, position);
                moved = true;
            }
            finally
            {
                if (!moved)
                {
                    if (oldBox != null)
                        oldBox.AddApple(this, oldPosition);
                    else
                        this.Box = null;
                }
            }
        }

        public void MoveToHand()
        {
            this.Box = null;
        }
    }
}