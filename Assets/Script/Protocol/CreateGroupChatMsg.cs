//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: CreateGroupChatMsg.proto
// Note: requires additional types generated from: ChatData.proto
namespace protocol
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"CreateGroupChatReq")]
  public partial class CreateGroupChatReq : global::ProtoBuf.IExtensible
  {
    public CreateGroupChatReq() {}
    
    private readonly global::System.Collections.Generic.List<string> _userId = new global::System.Collections.Generic.List<string>();
    [global::ProtoBuf.ProtoMember(1, Name=@"userId", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<string> userId
    {
      get { return _userId; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"CreateGroupChatRsp")]
  public partial class CreateGroupChatRsp : global::ProtoBuf.IExtensible
  {
    public CreateGroupChatRsp() {}
    
    private protocol.CreateGroupChatRsp.ResultCode _resultCode;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"resultCode", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public protocol.CreateGroupChatRsp.ResultCode resultCode
    {
      get { return _resultCode; }
      set { _resultCode = value; }
    }
    private int _groupChatId;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"groupChatId", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int groupChatId
    {
      get { return _groupChatId; }
      set { _groupChatId = value; }
    }
    [global::ProtoBuf.ProtoContract(Name=@"ResultCode")]
    public enum ResultCode
    {
            
      [global::ProtoBuf.ProtoEnum(Name=@"SUCCESS", Value=0)]
      SUCCESS = 0,
            
      [global::ProtoBuf.ProtoEnum(Name=@"FAIL", Value=1)]
      FAIL = 1
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}