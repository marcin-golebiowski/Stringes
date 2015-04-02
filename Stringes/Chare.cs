﻿using System.Globalization;

namespace Stringes
{
    /// <summary>
    /// Represents a charactere, which provides location information on a character taken from a stringe.
    /// </summary>
    public sealed class Chare
    {
        private readonly Stringe _src;
        private readonly char _character;
        private readonly int _offset;
        private int _line;
        private int _column;

        /// <summary>
        /// The stringe from which the charactere was taken.
        /// </summary>
        public Stringe Source
        {
            get { return _src; }
        }

        /// <summary>
        /// The underlying character.
        /// </summary>
        public char Character
        {
            get { return _character; }
        }

        /// <summary>
        /// The position of the charactere in the stringe.
        /// </summary>
        public int Offset
        {
            get { return _offset; }
        }

        /// <summary>
        /// The line on which the charactere appears.
        /// </summary>
        public int Line
        {
            get
            {
                if (_line == 0) SetLineCol();
                return _line;
            }
        }

        /// <summary>
        /// The column on which the charactere appears.
        /// </summary>
        public int Column
        {
            get
            {
                if (_column == 0) SetLineCol();
                return _column;
            }
        }

        private void SetLineCol()
        {
            _line = _src.Line;
            _column = _src.Column;
            if (_offset <= 0) return;
            for (int i = 0; i < _offset; i++)
            {
                if (_src.ParentString[_offset] == '\n')
                {
                    _line++;
                    _column = 1;
                }
                else
                {
                    _column++;
                }
            }
        }

        internal Chare(Stringe source, char c, int offset)
        {
            _src = source;
            _character = c;
            _offset = offset;
            _line = _column = 0;
        }

        internal Chare(Stringe source, char c, int offset, int line, int col)
        {
            _src = source;
            _character = c;
            _offset = offset;
            _line = line;
            _column = col;
        }

        /// <summary>
        /// Returns the string representation of the current charactere.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return _character.ToString(CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Converts a charactere to a character.
        /// </summary>
        /// <param name="chare">The charactere to convert.</param>

        public static implicit operator char(Chare chare)
        {
            return chare._character;
        }
    }
}