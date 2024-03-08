using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chinese_Chess
{
    public class AutoLocate
    {
        public void Do(ref Point AfterPos, bool bRelativeorAbsolute = true)
        {

            int i;
            int afterXPos = AfterPos.X;
            int afterYPos = AfterPos.Y;
            if (bRelativeorAbsolute == true) { i = 30; }  // round Relative (Default)
            else { i = 0; } // round Absolute
            if (afterYPos >= 630 - i) { afterYPos = 630; }
            else if (afterYPos >= 560 - i && afterYPos <= 630 - i) { afterYPos = 560; }
            else if (afterYPos >= 490 - i && afterYPos <= 560 - i) { afterYPos = 490; }
            else if (afterYPos >= 420 - i && afterYPos <= 490 - i) { afterYPos = 420; }
            else if (afterYPos >= 350 - i && afterYPos <= 420 - i) { afterYPos = 350; }
            else if (afterYPos >= 280 - i && afterYPos <= 350 - i) { afterYPos = 280; }
            else if (afterYPos >= 210 - i && afterYPos <= 280 - i) { afterYPos = 210; }
            else if (afterYPos >= 140 - i && afterYPos <= 210 - i) { afterYPos = 140; }
            else if (afterYPos >= 70 - i && afterYPos <= 140 - i) { afterYPos = 70; }
            else if (afterYPos >= 0 - i && afterYPos <= 70 - i) { afterYPos = 0; }
            else if (afterYPos <= 0) { afterYPos = 0; }


            if (afterXPos >= 560 - i) { afterXPos = 560; }
            else if (afterXPos >= 490 - i && afterXPos <= 560 - i) { afterXPos = 490; }
            else if (afterXPos >= 420 - i && afterXPos <= 490 - i) { afterXPos = 420; }
            else if (afterXPos >= 350 - i && afterXPos <= 420 - i) { afterXPos = 350; }
            else if (afterXPos >= 280 - i && afterXPos <= 350 - i) { afterXPos = 280; }
            else if (afterXPos >= 210 - i && afterXPos <= 280 - i) { afterXPos = 210; }
            else if (afterXPos >= 140 - i && afterXPos <= 210 - i) { afterXPos = 140; }
            else if (afterXPos >= 70 - i && afterXPos <= 140 - i) { afterXPos = 70; }
            else if (afterXPos >= 0 - i && afterXPos <= 70 - i) { afterXPos = 0; }
            else if (afterXPos <= 0) { afterXPos = 0; }

            AfterPos = new Point(afterXPos, afterYPos);
        }
    }
}
