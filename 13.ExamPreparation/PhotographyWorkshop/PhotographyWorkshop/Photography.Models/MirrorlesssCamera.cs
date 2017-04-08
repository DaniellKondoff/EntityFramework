using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photography.Models
{
    public class MirrorlesssCamera : Camera
    {
        public string MaxVideoResolution { get; set; }

        public int MaxFrameRate { get; set; }
    }
}
