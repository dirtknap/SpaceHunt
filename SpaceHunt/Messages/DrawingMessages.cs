using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceHunt.StateTracker;
using SpaceHunt.Utils;

namespace SpaceHunt.Messages
{
    class InitialzeScreen { }

    class DrawSector
    {
        public Sector Sector { get; set; }

        public DrawSector(Sector sector)
        {
            Sector = sector;
        }
    }

    class DrawCursor
    {
        public Point CursorPos { get; set; }

        public DrawCursor(Point cursorPos)
        {
            CursorPos = cursorPos;
        }
    }

    class PrintLine
    {
        public string Text { get; set; }

        public PrintLine(string text)
        {
            Text = text;
        }
    }
}
