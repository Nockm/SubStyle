namespace SubStyle.Sys;

public class ByteReader
{
    public ByteReader(Stream stream)
    {
        this.Stream = stream;
    }

    private byte[] Buffer { get; } = new byte[1024];

    private Stream Stream { get; }

    public int ReadInt32()
    {
        this.Stream.ReadExactly(this.Buffer, 0, 4);
        return BitConverter.ToInt32(this.Buffer, 0);
    }

    public short ReadInt16()
    {
        this.Stream.ReadExactly(this.Buffer, 0, 2);
        return BitConverter.ToInt16(this.Buffer, 0);
    }

    public uint ReadUInt32()
    {
        this.Stream.ReadExactly(this.Buffer, 0, 4);
        return BitConverter.ToUInt32(this.Buffer, 0);
    }

    public ushort ReadUInt16()
    {
        this.Stream.ReadExactly(this.Buffer, 0, 2);
        return BitConverter.ToUInt16(this.Buffer, 0);
    }
}
