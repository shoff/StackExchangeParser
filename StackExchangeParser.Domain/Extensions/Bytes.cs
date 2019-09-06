namespace StackExchangeParser.Domain.Extensions
{
    using System;
    using System.Diagnostics;
    using System.Globalization;
    using System.Text;

    public static class Bytes
    {
        // ReSharper disable once InconsistentNaming
        private const decimal PowerOf2s = 1024;

        public static MegaByte Size(this string file)
        {
            return CreateFromByteCount(Encoding.UTF8.GetBytes(file).Length);
        }

        public static MegaByte CreateFromByteCount(int byteCount)
        {
            if (byteCount <= 0)
            {
                return new MegaByte();
            }

            decimal kilobytes = byteCount / PowerOf2s;

            //if (kilobytes < PowerOf2s)
            //{
            // less than one meg
            return new MegaByte(kilobytes);
            //}

            // ReSharper disable once PossibleLossOfFraction
            //var count = Math.Round(Math.Floor(kilobytes / PowerOf2s), MidpointRounding.AwayFromZero);
            //return new MegaByte(count);
        }


        public class MegaByte
        {
            private readonly int kCount;

            public MegaByte(decimal kilobytes = 0)
            {

                var toThousandths = Math.Truncate(kilobytes * 1000m) / 1000m;

                // I'm embarrassed that this is the only way I could figure out how to do this...
                this.Bytes = int.Parse((Math.Truncate(kilobytes * 1000m) / 1000m)
                    .ToString(CultureInfo.InvariantCulture).Substring(2));

                var test = int.Parse(toThousandths.ToString(CultureInfo.InvariantCulture).Substring(2));
                Debug.Assert(test == this.Bytes);

                this.kCount = Convert.ToInt32(Math.Truncate(kilobytes));
                this.Count = this.kCount / 1024;
            }

            public int Bytes { get; }

            public int Count { get; }

            public int KiloBytes => this.Count > 0 ? this.Count * 1024 + this.kCount : this.kCount;
        }


    }

}