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
        get => State.GetAddress(nameof(Owner));
        set => State.SetAddress(nameof(Owner), value);
    }

    public bool TestBool
    {
        get => State.GetBool("TestBool");
        private set => State.SetBool("TestBool", value);
    }

    public byte TestByte
    {
        get 
        {
            var valueArray = State.GetBytes("TestByte");
            return valueArray[0];
        }
        private set
        {
            byte[] valueArray = { value };
            State.SetBytes("TestByte", valueArray);
        }
    }

    public char TestChar
    {
        get => State.GetChar("TestChar");
        private set => State.SetChar("TestChar", value);
    }

    public string TestString
    {
        get => State.GetString("TestString");
        private set => State.SetString("TestString", value);
    }

    public uint TestUInt32
    {
        get => State.GetUInt32("TestUInt32");
        private set => State.SetUInt32("TestUInt32", value);
    }

    public int TestInt32
    {
        get => State.GetInt32("TestInt32");
        private set => State.SetInt32("TestInt32", value);
    }

    public ulong TestUInt64
    {
        get => State.GetUInt64("TestUInt64");
        private set => State.SetUInt64("TestUInt64", value);
    }

    public long TestInt64
    {
        get => State.GetInt64("TestInt64");
        private set => State.SetInt64("TestInt64", value);
    }

    public Address TestAddress
    {
        get => State.GetAddress("TestAddress");
        private set => State.SetAddress("TestAddress", value);
    }

    public byte[] TestByteArray
    {
        get => State.GetBytes("TestByteArray");
        private set => State.SetBytes("TestByteArray", value);
    }

    public UInt128 TestUInt128
    {
        get => State.GetUInt128("TestUInt128");
        private set => State.SetUInt128("TestUInt128", value);
    }

    public UInt256 TestUInt256
    {
        get => State.GetUInt256("TestUInt256");
        private set => State.SetUInt256("TestUInt256", value);
    }

    public string TestMethod(int messageIndex, string message)
    {
        string key = $"Message[{messageIndex}]";
        State.SetString(key, message);
        Log(new TestMessageLog { index = messageIndex, message = message });
        // Testing retrieval after setting.
        return $"{key}: {State.GetString(key)}";
    }

    public struct TestMessageLog
    {
        [Index]
        public int index;

        public string message;
    }
}