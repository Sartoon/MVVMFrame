//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: OffLineMsg.proto
namespace protocol
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"OffLineSync")]
  public partial class OffLineSync : global::ProtoBuf.IExtensible
  {
    public OffLineSync() {}
    
    private protocol.OffLineSync.CauseCode _causeCode;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"causeCode", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public protocol.OffLineSync.CauseCode causeCode
    {
      get { return _causeCode; }
      set { _causeCode = value; }
    }
    [global::ProtoBuf.ProtoContract(Name=@"CauseCode")]
    public enum CauseCode
    {
            
      [global::ProtoBuf.ProtoEnum(Name=@"CHANGE_PASSWORD", Value=0)]
      CHANGE_PASSWORD = 0,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ANOTHER_LOGIN", Value=1)]
      ANOTHER_LOGIN = 1,
            
      [global::ProtoBuf.ProtoEnum(Name=@"KEEP_ALIVE_FALSE", Value=2)]
      KEEP_ALIVE_FALSE = 2
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}