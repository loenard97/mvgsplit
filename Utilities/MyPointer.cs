namespace LiveSplit.MVGSplit.MemoryHandling
{
    public readonly struct MyPointer
    {
        public MyPointer(int address, int[] offsets)
        {
            Address = address;
            Offsets = offsets;
        }

        public int Address { get; }
        public int[] Offsets { get; }

        public override string ToString() => $"({Address}, {Offsets})";
    }
}
