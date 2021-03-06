﻿using Sulakore.Communication;
using Sulakore.Habbo;
using Sulakore.Protocol;
using System;

namespace TanjiMimic.Utilities.Events.Incoming
{
    public class PlayerWhisperEventArgs : EventArgs, IHabboEvent
    {
        private readonly HMessage _packet;

        public ushort Header { get; private set; }
        public int PlayerIndex { get; private set; }
        public string Message { get; private set; }
        public HTheme Theme { get; private set; }

        public PlayerWhisperEventArgs(HMessage packet)
        {
            _packet = packet;
            Header = _packet.Header;

            int position = 0;
            PlayerIndex = _packet.ReadInt(ref position);
            Message = _packet.ReadString(ref position);
            _packet.ReadInt(ref position);
            Theme = (HTheme)_packet.ReadInt(ref position);
        }

        public override string ToString()
        {
            return string.Format("Header: {0}, PlayerIndex: {1}, Message: {2}, Theme: {3}",
                            Header, PlayerIndex, Message, Theme);
        }
    }
}
