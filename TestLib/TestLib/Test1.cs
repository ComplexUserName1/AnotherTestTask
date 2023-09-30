using Newtonsoft.Json;

namespace TestLib
{
    public class Test1
    {
        public int Process()
        {
            string json = File.ReadAllText("test.json");
            var obj = JsonConvert.DeserializeObject<TestData>(json);

            string data1 = (string)obj.Fields[0].Value;
            int offset = (int)(Int64)obj.Fields[1].Value;
            int shift = (int)(Int64)obj.Fields[2].Value;

            uint[] array = ConvertHexStringToArray(data1);

            if (offset >= array.Length)
            {
                throw new InvalidOperationException("Offset value is out of range.");
            }

            uint x = array[offset] >> shift;

            return (int)x;
        }

        private uint[] ConvertHexStringToArray(string hexString)
        {
            int numChars = hexString.Length;
            uint[] result = new uint[numChars / 8];
            for (int i = 0; i < numChars; i += 8)
            {
                string hexValue = hexString.Substring(i, 8);
                result[i / 8] = Convert.ToUInt32(hexValue, 16);
            }

            return result;
        }
    }

    public class TestData
    {
        public List<FieldData> Fields { get; set; }
    }

    public class FieldData
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public object Value { get; set; }
    }
}