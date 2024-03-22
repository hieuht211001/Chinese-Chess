using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using Chinese_Chess.Properties;

namespace Chinese_Chess
{
    public enum SOUNDTYPE
    {
        NORMAL_MOVE,
        TAKE_MOVE,
        RECHECK_MOVE,
        BUTTON_SOUND
    }

    public class Game_Sound
    {
        public static bool bSoundEnable = true; // by default game sound is enable
        public void Add(SOUNDTYPE SoundType)
        {
            // based on sound setting
            if (bSoundEnable == false ) { return; }

            if (SoundType == SOUNDTYPE.NORMAL_MOVE)
            {
                SoundPlayer player = new SoundPlayer(Resources.sound_normal_move);
                player.Play();
            }
            else if (SoundType == SOUNDTYPE.TAKE_MOVE)
            {
                SoundPlayer player = new SoundPlayer(Resources.sound_take);
                player.Play();
            }
            else if (SoundType == SOUNDTYPE.RECHECK_MOVE)
            {
                SoundPlayer player = new SoundPlayer(Resources.sound_recheck);
                player.Play();
            }
            else if (SoundType == SOUNDTYPE.BUTTON_SOUND)
            {
                SoundPlayer player = new SoundPlayer(Resources.sound_button_click);
                player.Play();
            }
        }
    }
}
