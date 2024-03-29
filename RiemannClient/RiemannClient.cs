//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: RiemannClient.proto
namespace RiemannClient
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"State")]
  public partial class State : global::ProtoBuf.IExtensible
  {
    public State() {}
    

    private long _time = default(long);
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"time", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(long))]
    public long time
    {
      get { return _time; }
      set { _time = value; }
    }

    private string _state = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"state", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string state
    {
      get { return _state; }
      set { _state = value; }
    }

    private string _service = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"service", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string service
    {
      get { return _service; }
      set { _service = value; }
    }

    private string _host = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"host", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string host
    {
      get { return _host; }
      set { _host = value; }
    }

    private string _description = "";
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"description", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string description
    {
      get { return _description; }
      set { _description = value; }
    }

    private bool _once = default(bool);
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name=@"once", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(default(bool))]
    public bool once
    {
      get { return _once; }
      set { _once = value; }
    }
    private readonly global::System.Collections.Generic.List<string> _tags = new global::System.Collections.Generic.List<string>();
    [global::ProtoBuf.ProtoMember(7, Name=@"tags", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<string> tags
    {
      get { return _tags; }
    }
  

    private float _ttl = default(float);
    [global::ProtoBuf.ProtoMember(8, IsRequired = false, Name=@"ttl", DataFormat = global::ProtoBuf.DataFormat.FixedSize)]
    [global::System.ComponentModel.DefaultValue(default(float))]
    public float ttl
    {
      get { return _ttl; }
      set { _ttl = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"Event")]
  public partial class Event : global::ProtoBuf.IExtensible
  {
    public Event() {}
    

    private long _time = default(long);
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"time", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(long))]
    public long time
    {
      get { return _time; }
      set { _time = value; }
    }

    private string _state = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"state", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string state
    {
      get { return _state; }
      set { _state = value; }
    }

    private string _service = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"service", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string service
    {
      get { return _service; }
      set { _service = value; }
    }

    private string _host = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"host", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string host
    {
      get { return _host; }
      set { _host = value; }
    }

    private string _description = "";
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"description", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string description
    {
      get { return _description; }
      set { _description = value; }
    }
    private readonly global::System.Collections.Generic.List<string> _tags = new global::System.Collections.Generic.List<string>();
    [global::ProtoBuf.ProtoMember(7, Name=@"tags", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<string> tags
    {
      get { return _tags; }
    }
  

    private float _ttl = default(float);
    [global::ProtoBuf.ProtoMember(8, IsRequired = false, Name=@"ttl", DataFormat = global::ProtoBuf.DataFormat.FixedSize)]
    [global::System.ComponentModel.DefaultValue(default(float))]
    public float ttl
    {
      get { return _ttl; }
      set { _ttl = value; }
    }
    private readonly global::System.Collections.Generic.List<Attribute> _attributes = new global::System.Collections.Generic.List<Attribute>();
    [global::ProtoBuf.ProtoMember(9, Name=@"attributes", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<Attribute> attributes
    {
      get { return _attributes; }
    }
  

    private long _metric_sint64 = default(long);
    [global::ProtoBuf.ProtoMember(13, IsRequired = false, Name=@"metric_sint64", DataFormat = global::ProtoBuf.DataFormat.ZigZag)]
    [global::System.ComponentModel.DefaultValue(default(long))]
    public long metric_sint64
    {
      get { return _metric_sint64; }
      set { _metric_sint64 = value; }
    }

    private double _metric_d = default(double);
    [global::ProtoBuf.ProtoMember(14, IsRequired = false, Name=@"metric_d", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(double))]
    public double metric_d
    {
      get { return _metric_d; }
      set { _metric_d = value; }
    }

    private float _metric_f = default(float);
    [global::ProtoBuf.ProtoMember(15, IsRequired = false, Name=@"metric_f", DataFormat = global::ProtoBuf.DataFormat.FixedSize)]
    [global::System.ComponentModel.DefaultValue(default(float))]
    public float metric_f
    {
      get { return _metric_f; }
      set { _metric_f = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"Query")]
  public partial class Query : global::ProtoBuf.IExtensible
  {
    public Query() {}
    

    private string _string = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"string", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string @string
    {
      get { return _string; }
      set { _string = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"Msg")]
  public partial class Msg : global::ProtoBuf.IExtensible
  {
    public Msg() {}
    

    private bool _ok = default(bool);
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"ok", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(default(bool))]
    public bool ok
    {
      get { return _ok; }
      set { _ok = value; }
    }

    private string _error = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"error", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string error
    {
      get { return _error; }
      set { _error = value; }
    }
    private readonly global::System.Collections.Generic.List<State> _states = new global::System.Collections.Generic.List<State>();
    [global::ProtoBuf.ProtoMember(4, Name=@"states", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<State> states
    {
      get { return _states; }
    }
  

    private Query _query = null;
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"query", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public Query query
    {
      get { return _query; }
      set { _query = value; }
    }
    private readonly global::System.Collections.Generic.List<Event> _events = new global::System.Collections.Generic.List<Event>();
    [global::ProtoBuf.ProtoMember(6, Name=@"events", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<Event> events
    {
      get { return _events; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"Attribute")]
  public partial class Attribute : global::ProtoBuf.IExtensible
  {
    public Attribute() {}
    
    private string _key;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"key", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string key
    {
      get { return _key; }
      set { _key = value; }
    }

    private string _value = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"value", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string value
    {
      get { return _value; }
      set { _value = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}