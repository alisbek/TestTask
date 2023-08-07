using WebApplication2.Services;

namespace PostEngine.Tests;

[TestFixture]
public class MessageReaderTests
{
    private MemoryStream _stream;
    private MessageReader _messageReader;

    [SetUp]
    public void SetUp()
    {
        _stream = new MemoryStream();
        _messageReader = new MessageReader(_stream, (byte)'\n', 1024);
    }

    [Test]
    public void ReadMessage_ReturnsMessageWithEndSymbol()
    {
        var message = "Some text message here\n";
        var messageBytes = System.Text.Encoding.UTF8.GetBytes(message);

        _stream.Write(messageBytes, 0, messageBytes.Length);
        _stream.Seek(0, SeekOrigin.Begin);

        var result = _messageReader.ReadMessage();

        Assert.AreEqual(message, result);
    }
}