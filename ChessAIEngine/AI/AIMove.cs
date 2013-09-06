using System;
using System.Collections.Generic;
using System.Text;

namespace ChessEngine.AI
{
    public class AIMove
    {
        private byte destinationRow;
        private byte destinationColumn;
        private byte sourceRow;
        private byte sourceColumn;

        public byte SourceColumn
        {
            get { return sourceColumn; }
            set { sourceColumn = value; }
        }

        public byte SourceRow
        {
            get { return sourceRow; }
            set { sourceRow = value; }
        }

        public byte DestinationColumn
        {
            get { return destinationColumn; }
            set { destinationColumn = value; }
        }

        public byte DestinationRow
        {
            get { return destinationRow; }
            set { destinationRow = value; }
        }
    }
}
