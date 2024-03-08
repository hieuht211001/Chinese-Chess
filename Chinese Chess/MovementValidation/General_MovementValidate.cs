using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chinese_Chess
{
    public class General_MovementValidate
    {
        PossibleMovement_CircleData circleData = new PossibleMovement_CircleData();
        public void Validate(Point BeforePos, ref Point AfterPos)
        {
            if (!circleData.GetStatus_AtPosition(AfterPos))   // move in pos have circle
            {
                Pieces.isClicked = true; // keep circle if move not complete
                AfterPos = BeforePos;
            }
        }
    }
}
