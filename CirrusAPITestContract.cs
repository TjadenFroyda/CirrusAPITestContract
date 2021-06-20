using System;
using Stratis.SmartContracts;

[Deploy]
public class CirrusAPITestContract : SmartContract
{
    public CirrusAPITestContract(ISmartContractState smartContractState, bool testBool, byte testByte, char testChar, 
        string testString, uint testUInt32, int testInt32, ulong testUInt64, long testInt64,
        Address testAddress, byte[] testByteArray, UInt128 testUInt128, UInt256 testUInt256)
    : base(smartContractState)
    {
        Owner = Message.Sender;
        TestBool = testBool;
        TestByte = testByte;
        TestChar = testChar;
        TestString = testString;
        TestUInt32 = testUInt32;
        TestInt32 = testInt32;
        TestUInt64 = testUInt64;
        TestInt64 = testInt64;
        TestAddress = testAddress;
        TestByteArray = testByteArray;
        TestUInt128 = testUInt128;
        TestUInt256 = testUInt256;
        this.TestMethod(0, "Contract initiated.");
    }

    public Address Owner
    {
        get => PersistentState.GetAddress(nameof(Owner));
        set => PersistentState.SetAddress(nameof(Owner), value);
    }

    public bool TestBool
    {
        get => PersistentState.GetBool("TestBool");
        private set => PersistentState.SetBool("TestBool", value);
    }

    public byte TestByte
    {
        get 
        {
            var valueArray = PersistentState.GetBytes("TestByte");
            return valueArray[0];
        }
        private set
        {
            byte[] valueArray = { value };
            PersistentState.SetBytes("TestByte", valueArray);
        }
    }

    public char TestChar
    {
        get => PersistentState.GetChar("TestChar");
        private set => PersistentState.SetChar("TestChar", value);
    }

    public string TestString
    {
        get => PersistentState.GetString("TestString");
        private set => PersistentState.SetString("TestString", value);
    }

    public uint TestUInt32
    {
        get => PersistentState.GetUInt32("TestUInt32");
        private set => PersistentState.SetUInt32("TestUInt32", value);
    }

    public int TestInt32
    {
        get => PersistentState.GetInt32("TestInt32");
        private set => PersistentState.SetInt32("TestInt32", value);
    }

    public ulong TestUInt64
    {
        get => PersistentState.GetUInt64("TestUInt64");
        private set => PersistentState.SetUInt64("TestUInt64", value);
    }

    public long TestInt64
    {
        get => PersistentState.GetInt64("TestInt64");
        private set => PersistentState.SetInt64("TestInt64", value);
    }

    public Address TestAddress
    {
        get => PersistentState.GetAddress("TestAddress");
        private set => PersistentState.SetAddress("TestAddress", value);
    }

    public byte[] TestByteArray
    {
        get => PersistentState.GetBytes("TestByteArray");
        private set => PersistentState.SetBytes("TestByteArray", value);
    }

    public UInt128 TestUInt128
    {
        get => PersistentState.GetUInt128("TestUInt128");
        private set => PersistentState.SetUInt128("TestUInt128", value);
    }

    public UInt256 TestUInt256
    {
        get => PersistentState.GetUInt256("TestUInt256");
        private set => PersistentState.SetUInt256("TestUInt256", value);
    }

    public string TestMethod(int messageIndex, string message)
    {
        string key = $"Message[{messageIndex}]";
        PersistentState.SetString(key, message);
        Log(new TestMessageLog { index = messageIndex, message = message });
        // Testing retrieval after setting.
        return $"{key}: {PersistentState.GetString(key)}";
    }

    public struct TestMessageLog
    {
        [Index]
        public int index;

        public string message;
    }
}