// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: bgs/low/pb/client/presence_listener.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021, 8981
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace WowPacketParserModule.V10_0_0_46181.Protos.V10_2_0_52649.Bgs.Protocol.Presence.V1 {

  /// <summary>Holder for reflection information generated from bgs/low/pb/client/presence_listener.proto</summary>
  public static partial class PresenceListenerReflection {

    #region Descriptor
    /// <summary>File descriptor for bgs/low/pb/client/presence_listener.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static PresenceListenerReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "CiliZ3MvbG93L3BiL2NsaWVudC9wcmVzZW5jZV9saXN0ZW5lci5wcm90bxIY",
            "YmdzLnByb3RvY29sLnByZXNlbmNlLnYxGiZiZ3MvbG93L3BiL2NsaWVudC9w",
            "cmVzZW5jZV90eXBlcy5wcm90bxolYmdzL2xvdy9wYi9jbGllbnQvYWNjb3Vu",
            "dF90eXBlcy5wcm90bxohYmdzL2xvdy9wYi9jbGllbnQvcnBjX3R5cGVzLnBy",
            "b3RvIqYBChVTdWJzY3JpYmVOb3RpZmljYXRpb24SOQoNc3Vic2NyaWJlcl9p",
            "ZBgBIAEoCzIiLmJncy5wcm90b2NvbC5hY2NvdW50LnYxLkFjY291bnRJZBI2",
            "CgVzdGF0ZRgCIAMoCzInLmJncy5wcm90b2NvbC5wcmVzZW5jZS52MS5QcmVz",
            "ZW5jZVN0YXRlEhoKEnN1YnNjcmliZXJfcHJvZ3JhbRgDIAEoDSKpAQoYU3Rh",
            "dGVDaGFuZ2VkTm90aWZpY2F0aW9uEjkKDXN1YnNjcmliZXJfaWQYASABKAsy",
            "Ii5iZ3MucHJvdG9jb2wuYWNjb3VudC52MS5BY2NvdW50SWQSNgoFc3RhdGUY",
            "AiADKAsyJy5iZ3MucHJvdG9jb2wucHJlc2VuY2UudjEuUHJlc2VuY2VTdGF0",
            "ZRIaChJzdWJzY3JpYmVyX3Byb2dyYW0YAyABKA0ynAIKEFByZXNlbmNlTGlz",
            "dGVuZXISYwoLT25TdWJzY3JpYmUSLy5iZ3MucHJvdG9jb2wucHJlc2VuY2Uu",
            "djEuU3Vic2NyaWJlTm90aWZpY2F0aW9uGhkuYmdzLnByb3RvY29sLk5PX1JF",
            "U1BPTlNFIgiC+SsECAE4ARJpCg5PblN0YXRlQ2hhbmdlZBIyLmJncy5wcm90",
            "b2NvbC5wcmVzZW5jZS52MS5TdGF0ZUNoYW5nZWROb3RpZmljYXRpb24aGS5i",
            "Z3MucHJvdG9jb2wuTk9fUkVTUE9OU0UiCIL5KwQIAjgBGjiC+SsuCipibmV0",
            "LnByb3RvY29sLnByZXNlbmNlLnYxLlByZXNlbmNlTGlzdGVuZXI4AYr5KwII",
            "AUICSAE="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { WowPacketParserModule.V10_0_0_46181.Protos.V10_2_0_52649.Bgs.Protocol.Presence.V1.PresenceTypesReflection.Descriptor, WowPacketParserModule.V10_0_0_46181.Protos.V10_2_0_52649.Bgs.Protocol.Account.V1.AccountTypesReflection.Descriptor, WowPacketParserModule.V10_0_0_46181.Protos.V10_2_0_52649.Bgs.Protocol.RpcTypesReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(WowPacketParserModule.V10_0_0_46181.Protos.V10_2_0_52649.Bgs.Protocol.Presence.V1.SubscribeNotification), WowPacketParserModule.V10_0_0_46181.Protos.V10_2_0_52649.Bgs.Protocol.Presence.V1.SubscribeNotification.Parser, new[]{ "SubscriberId", "State", "SubscriberProgram" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(WowPacketParserModule.V10_0_0_46181.Protos.V10_2_0_52649.Bgs.Protocol.Presence.V1.StateChangedNotification), WowPacketParserModule.V10_0_0_46181.Protos.V10_2_0_52649.Bgs.Protocol.Presence.V1.StateChangedNotification.Parser, new[]{ "SubscriberId", "State", "SubscriberProgram" }, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  [global::System.Diagnostics.DebuggerDisplayAttribute("{ToString(),nq}")]
  public sealed partial class SubscribeNotification : pb::IMessage<SubscribeNotification>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<SubscribeNotification> _parser = new pb::MessageParser<SubscribeNotification>(() => new SubscribeNotification());
    private pb::UnknownFieldSet _unknownFields;
    private int _hasBits0;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<SubscribeNotification> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return WowPacketParserModule.V10_0_0_46181.Protos.V10_2_0_52649.Bgs.Protocol.Presence.V1.PresenceListenerReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public SubscribeNotification() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public SubscribeNotification(SubscribeNotification other) : this() {
      _hasBits0 = other._hasBits0;
      subscriberId_ = other.subscriberId_ != null ? other.subscriberId_.Clone() : null;
      state_ = other.state_.Clone();
      subscriberProgram_ = other.subscriberProgram_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public SubscribeNotification Clone() {
      return new SubscribeNotification(this);
    }

    /// <summary>Field number for the "subscriber_id" field.</summary>
    public const int SubscriberIdFieldNumber = 1;
    private WowPacketParserModule.V10_0_0_46181.Protos.V10_2_0_52649.Bgs.Protocol.Account.V1.AccountId subscriberId_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public WowPacketParserModule.V10_0_0_46181.Protos.V10_2_0_52649.Bgs.Protocol.Account.V1.AccountId SubscriberId {
      get { return subscriberId_; }
      set {
        subscriberId_ = value;
      }
    }

    /// <summary>Field number for the "state" field.</summary>
    public const int StateFieldNumber = 2;
    private static readonly pb::FieldCodec<WowPacketParserModule.V10_0_0_46181.Protos.V10_2_0_52649.Bgs.Protocol.Presence.V1.PresenceState> _repeated_state_codec
        = pb::FieldCodec.ForMessage(18, WowPacketParserModule.V10_0_0_46181.Protos.V10_2_0_52649.Bgs.Protocol.Presence.V1.PresenceState.Parser);
    private readonly pbc::RepeatedField<WowPacketParserModule.V10_0_0_46181.Protos.V10_2_0_52649.Bgs.Protocol.Presence.V1.PresenceState> state_ = new pbc::RepeatedField<WowPacketParserModule.V10_0_0_46181.Protos.V10_2_0_52649.Bgs.Protocol.Presence.V1.PresenceState>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public pbc::RepeatedField<WowPacketParserModule.V10_0_0_46181.Protos.V10_2_0_52649.Bgs.Protocol.Presence.V1.PresenceState> State {
      get { return state_; }
    }

    /// <summary>Field number for the "subscriber_program" field.</summary>
    public const int SubscriberProgramFieldNumber = 3;
    private readonly static uint SubscriberProgramDefaultValue = 0;

    private uint subscriberProgram_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public uint SubscriberProgram {
      get { if ((_hasBits0 & 1) != 0) { return subscriberProgram_; } else { return SubscriberProgramDefaultValue; } }
      set {
        _hasBits0 |= 1;
        subscriberProgram_ = value;
      }
    }
    /// <summary>Gets whether the "subscriber_program" field is set</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool HasSubscriberProgram {
      get { return (_hasBits0 & 1) != 0; }
    }
    /// <summary>Clears the value of the "subscriber_program" field</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void ClearSubscriberProgram() {
      _hasBits0 &= ~1;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as SubscribeNotification);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(SubscribeNotification other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (!object.Equals(SubscriberId, other.SubscriberId)) return false;
      if(!state_.Equals(other.state_)) return false;
      if (SubscriberProgram != other.SubscriberProgram) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (subscriberId_ != null) hash ^= SubscriberId.GetHashCode();
      hash ^= state_.GetHashCode();
      if (HasSubscriberProgram) hash ^= SubscriberProgram.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void WriteTo(pb::CodedOutputStream output) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      output.WriteRawMessage(this);
    #else
      if (subscriberId_ != null) {
        output.WriteRawTag(10);
        output.WriteMessage(SubscriberId);
      }
      state_.WriteTo(output, _repeated_state_codec);
      if (HasSubscriberProgram) {
        output.WriteRawTag(24);
        output.WriteUInt32(SubscriberProgram);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      if (subscriberId_ != null) {
        output.WriteRawTag(10);
        output.WriteMessage(SubscriberId);
      }
      state_.WriteTo(ref output, _repeated_state_codec);
      if (HasSubscriberProgram) {
        output.WriteRawTag(24);
        output.WriteUInt32(SubscriberProgram);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int CalculateSize() {
      int size = 0;
      if (subscriberId_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(SubscriberId);
      }
      size += state_.CalculateSize(_repeated_state_codec);
      if (HasSubscriberProgram) {
        size += 1 + pb::CodedOutputStream.ComputeUInt32Size(SubscriberProgram);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(SubscribeNotification other) {
      if (other == null) {
        return;
      }
      if (other.subscriberId_ != null) {
        if (subscriberId_ == null) {
          SubscriberId = new WowPacketParserModule.V10_0_0_46181.Protos.V10_2_0_52649.Bgs.Protocol.Account.V1.AccountId();
        }
        SubscriberId.MergeFrom(other.SubscriberId);
      }
      state_.Add(other.state_);
      if (other.HasSubscriberProgram) {
        SubscriberProgram = other.SubscriberProgram;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(pb::CodedInputStream input) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      input.ReadRawMessage(this);
    #else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            if (subscriberId_ == null) {
              SubscriberId = new WowPacketParserModule.V10_0_0_46181.Protos.V10_2_0_52649.Bgs.Protocol.Account.V1.AccountId();
            }
            input.ReadMessage(SubscriberId);
            break;
          }
          case 18: {
            state_.AddEntriesFrom(input, _repeated_state_codec);
            break;
          }
          case 24: {
            SubscriberProgram = input.ReadUInt32();
            break;
          }
        }
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
            break;
          case 10: {
            if (subscriberId_ == null) {
              SubscriberId = new WowPacketParserModule.V10_0_0_46181.Protos.V10_2_0_52649.Bgs.Protocol.Account.V1.AccountId();
            }
            input.ReadMessage(SubscriberId);
            break;
          }
          case 18: {
            state_.AddEntriesFrom(ref input, _repeated_state_codec);
            break;
          }
          case 24: {
            SubscriberProgram = input.ReadUInt32();
            break;
          }
        }
      }
    }
    #endif

  }

  [global::System.Diagnostics.DebuggerDisplayAttribute("{ToString(),nq}")]
  public sealed partial class StateChangedNotification : pb::IMessage<StateChangedNotification>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<StateChangedNotification> _parser = new pb::MessageParser<StateChangedNotification>(() => new StateChangedNotification());
    private pb::UnknownFieldSet _unknownFields;
    private int _hasBits0;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<StateChangedNotification> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return WowPacketParserModule.V10_0_0_46181.Protos.V10_2_0_52649.Bgs.Protocol.Presence.V1.PresenceListenerReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public StateChangedNotification() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public StateChangedNotification(StateChangedNotification other) : this() {
      _hasBits0 = other._hasBits0;
      subscriberId_ = other.subscriberId_ != null ? other.subscriberId_.Clone() : null;
      state_ = other.state_.Clone();
      subscriberProgram_ = other.subscriberProgram_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public StateChangedNotification Clone() {
      return new StateChangedNotification(this);
    }

    /// <summary>Field number for the "subscriber_id" field.</summary>
    public const int SubscriberIdFieldNumber = 1;
    private WowPacketParserModule.V10_0_0_46181.Protos.V10_2_0_52649.Bgs.Protocol.Account.V1.AccountId subscriberId_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public WowPacketParserModule.V10_0_0_46181.Protos.V10_2_0_52649.Bgs.Protocol.Account.V1.AccountId SubscriberId {
      get { return subscriberId_; }
      set {
        subscriberId_ = value;
      }
    }

    /// <summary>Field number for the "state" field.</summary>
    public const int StateFieldNumber = 2;
    private static readonly pb::FieldCodec<WowPacketParserModule.V10_0_0_46181.Protos.V10_2_0_52649.Bgs.Protocol.Presence.V1.PresenceState> _repeated_state_codec
        = pb::FieldCodec.ForMessage(18, WowPacketParserModule.V10_0_0_46181.Protos.V10_2_0_52649.Bgs.Protocol.Presence.V1.PresenceState.Parser);
    private readonly pbc::RepeatedField<WowPacketParserModule.V10_0_0_46181.Protos.V10_2_0_52649.Bgs.Protocol.Presence.V1.PresenceState> state_ = new pbc::RepeatedField<WowPacketParserModule.V10_0_0_46181.Protos.V10_2_0_52649.Bgs.Protocol.Presence.V1.PresenceState>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public pbc::RepeatedField<WowPacketParserModule.V10_0_0_46181.Protos.V10_2_0_52649.Bgs.Protocol.Presence.V1.PresenceState> State {
      get { return state_; }
    }

    /// <summary>Field number for the "subscriber_program" field.</summary>
    public const int SubscriberProgramFieldNumber = 3;
    private readonly static uint SubscriberProgramDefaultValue = 0;

    private uint subscriberProgram_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public uint SubscriberProgram {
      get { if ((_hasBits0 & 1) != 0) { return subscriberProgram_; } else { return SubscriberProgramDefaultValue; } }
      set {
        _hasBits0 |= 1;
        subscriberProgram_ = value;
      }
    }
    /// <summary>Gets whether the "subscriber_program" field is set</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool HasSubscriberProgram {
      get { return (_hasBits0 & 1) != 0; }
    }
    /// <summary>Clears the value of the "subscriber_program" field</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void ClearSubscriberProgram() {
      _hasBits0 &= ~1;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as StateChangedNotification);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(StateChangedNotification other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (!object.Equals(SubscriberId, other.SubscriberId)) return false;
      if(!state_.Equals(other.state_)) return false;
      if (SubscriberProgram != other.SubscriberProgram) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (subscriberId_ != null) hash ^= SubscriberId.GetHashCode();
      hash ^= state_.GetHashCode();
      if (HasSubscriberProgram) hash ^= SubscriberProgram.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void WriteTo(pb::CodedOutputStream output) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      output.WriteRawMessage(this);
    #else
      if (subscriberId_ != null) {
        output.WriteRawTag(10);
        output.WriteMessage(SubscriberId);
      }
      state_.WriteTo(output, _repeated_state_codec);
      if (HasSubscriberProgram) {
        output.WriteRawTag(24);
        output.WriteUInt32(SubscriberProgram);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      if (subscriberId_ != null) {
        output.WriteRawTag(10);
        output.WriteMessage(SubscriberId);
      }
      state_.WriteTo(ref output, _repeated_state_codec);
      if (HasSubscriberProgram) {
        output.WriteRawTag(24);
        output.WriteUInt32(SubscriberProgram);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int CalculateSize() {
      int size = 0;
      if (subscriberId_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(SubscriberId);
      }
      size += state_.CalculateSize(_repeated_state_codec);
      if (HasSubscriberProgram) {
        size += 1 + pb::CodedOutputStream.ComputeUInt32Size(SubscriberProgram);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(StateChangedNotification other) {
      if (other == null) {
        return;
      }
      if (other.subscriberId_ != null) {
        if (subscriberId_ == null) {
          SubscriberId = new WowPacketParserModule.V10_0_0_46181.Protos.V10_2_0_52649.Bgs.Protocol.Account.V1.AccountId();
        }
        SubscriberId.MergeFrom(other.SubscriberId);
      }
      state_.Add(other.state_);
      if (other.HasSubscriberProgram) {
        SubscriberProgram = other.SubscriberProgram;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(pb::CodedInputStream input) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      input.ReadRawMessage(this);
    #else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            if (subscriberId_ == null) {
              SubscriberId = new WowPacketParserModule.V10_0_0_46181.Protos.V10_2_0_52649.Bgs.Protocol.Account.V1.AccountId();
            }
            input.ReadMessage(SubscriberId);
            break;
          }
          case 18: {
            state_.AddEntriesFrom(input, _repeated_state_codec);
            break;
          }
          case 24: {
            SubscriberProgram = input.ReadUInt32();
            break;
          }
        }
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
            break;
          case 10: {
            if (subscriberId_ == null) {
              SubscriberId = new WowPacketParserModule.V10_0_0_46181.Protos.V10_2_0_52649.Bgs.Protocol.Account.V1.AccountId();
            }
            input.ReadMessage(SubscriberId);
            break;
          }
          case 18: {
            state_.AddEntriesFrom(ref input, _repeated_state_codec);
            break;
          }
          case 24: {
            SubscriberProgram = input.ReadUInt32();
            break;
          }
        }
      }
    }
    #endif

  }

  #endregion

}

#endregion Designer generated code
