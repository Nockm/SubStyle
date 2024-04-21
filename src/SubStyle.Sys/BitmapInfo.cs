namespace SubStyle.Sys;

public class BitmapInfo
{
    public BitmapInfo(Stream stream)
    {
        MemoryStream memoryStream = new MemoryStream();
        stream.CopyTo(memoryStream);

        memoryStream.Seek(0, SeekOrigin.Begin);
        ByteReader byteReader = new ByteReader(memoryStream);

        // Load metadata.
        this.Type = byteReader.ReadUInt16();
        this.Size = byteReader.ReadUInt32();
        this.Reserved = byteReader.ReadUInt32();
        this.StartOfImageData = byteReader.ReadUInt32();
        this.BitmapSize = byteReader.ReadUInt32();
        this.WidthPixels = byteReader.ReadUInt32();
        this.HighPixels = byteReader.ReadUInt32();
        this.NumberOfPlans = byteReader.ReadUInt16();
        this.SizeOfEachPoint = byteReader.ReadUInt16();
        this.Compression = byteReader.ReadUInt32();
        this.ImageSize = byteReader.ReadUInt32();
        this.HorizontalResolution = byteReader.ReadUInt32();
        this.VerticalResolution = byteReader.ReadUInt32();
        this.TableColorSize = byteReader.ReadUInt32();
        this.ColorCounter = byteReader.ReadUInt32();

        // Add storage for metadata.
        long numBytesRead = stream.Position;
        byte[] buffer = new byte[numBytesRead];

        // Dump metadata.
        stream.Seek(0, SeekOrigin.Begin);
        stream.ReadExactly(buffer, 0, (int)numBytesRead);
        this.HeaderHex = BitConverter.ToString(buffer);
    }

    public ushort Type { get; set; } // 0-1

    public uint Size { get; set; } // 2-5

    public uint Reserved { get; set; } // 6-9

    public uint StartOfImageData { get; set; } // 10-13

    public uint BitmapSize { get; set; } // 14-17

    public uint WidthPixels { get; set; } // 18-21

    public uint HighPixels { get; set; } // 22-25

    public ushort NumberOfPlans { get; set; } // 26-27

    public ushort SizeOfEachPoint { get; set; } // 28-29

    public uint Compression { get; set; } // 30-33

    public uint ImageSize { get; set; } // 34-37

    public uint HorizontalResolution { get; set; } // 38-41

    public uint VerticalResolution { get; set; } // 42-45

    public uint TableColorSize { get; set; } // 46-49

    public uint ColorCounter { get; set; } // 50-53

    public string HeaderHex { get; set; }

    public override string ToString()
    {
        string[] tokens = new string[]
        {
            /*
            $"Type=[{this.Type}]",
            $"Size=[{this.Size}]",
            $"Reserved=[{this.Reserved}]",
            $"StartOfImageData=[{this.StartOfImageData}]",
            $"BitmapSize=[{this.BitmapSize}]",
            */
            $"WidthPixels=[{this.WidthPixels}]",
            $"HighPixels=[{this.HighPixels}]",
            /*
            $"NumberOfPlans=[{this.NumberOfPlans}]",
            $"SizeOfEachPoint=[{this.SizeOfEachPoint}]",
            $"Compression=[{this.Compression}]",
            $"ImageSize=[{this.ImageSize}]",
            $"HorizontalResolution=[{this.HorizontalResolution}]",
            $"VerticalResolution=[{this.VerticalResolution}]",
            $"TableColorSize=[{this.TableColorSize}]",
            $"ColorCounter=[{this.ColorCounter}]",
            */
        };

        string properties = string.Join(" ", tokens);

        return string.Join("\n", new string[] { this.HeaderHex, properties });
    }
}
