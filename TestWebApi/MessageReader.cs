public class MessageReader
{
    private readonly Stream _stream;
    private readonly byte _messageEndSymbol;
    private readonly int _bufferSize;

    public MessageReader(Stream stream, byte messageEndSymbol, int bufferSize)
    {
        _stream = stream ?? throw new ArgumentNullException(nameof(stream));
        _messageEndSymbol = messageEndSymbol;
        _bufferSize = bufferSize;
    }

    public string ReadMessage()
    {
        using (var memoryStream = new MemoryStream())
        {
            int readBytes;
            byte[] buffer = new byte[_bufferSize];

            while ((readBytes = _stream.Read(buffer, 0, buffer.Length)) > 0)
            {
                memoryStream.Write(buffer, 0, readBytes);
                if (buffer[readBytes - 1] == _messageEndSymbol)
                {
                    break;
                }
            }

            return System.Text.Encoding.UTF8.GetString(memoryStream.ToArray());
        }
    }
}

