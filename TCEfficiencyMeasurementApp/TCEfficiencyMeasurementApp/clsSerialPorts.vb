Imports System.IO.Ports

Public Class cls_SerialPorts

    Private _serialPort As SerialPort

    Private _Baudrate As Long
    Private _PortName As String
    Private _PortParity As Parity
    Private _DataBits As Integer
    Private _StopBits As StopBits
    Private _Handshaking As Handshake
    Private _Connect As Boolean
    Private _RS232Return As String
    Private _Timeout As Long


    Public Sub New(ByVal PortName As String, ByVal Baudrate As Double)
        _serialPort = New SerialPort
        _Baudrate = Baudrate
        _PortName = PortName
        _PortParity = Parity.None
        _DataBits = 8
        _StopBits = StopBits.One
        _Handshaking = Handshake.None
        _Timeout = 1000
        _Connect = False
        _Laser_Enabled = False
    End Sub


    Public Property RS232SendCommand() As String
        Get
            Return _RS232Return
        End Get
        Set(ByVal Command As String)
            If _Connect = True Then
                _serialPort.Write(Command & vbCr)
                System.Threading.Thread.Sleep(50)
                Try
                    If UCase(Command) = "LCT0" Or UCase(Command) = "LR" Then _Laser_Enabled = True
                    If Command = "LS" Then _Laser_Enabled = False
                    _RS232Return = _serialPort.ReadExisting
                Catch ex As Exception
                    _RS232Return = ex.Message
                End Try
            End If

        End Set
    End Property

    Public Property Prop_Connect() As Boolean
        Get
            Return _Connect
        End Get
        Set(ByVal value As Boolean)
            If _Connect <> value Then
                If value = True Then
                    _serialPort.BaudRate = _Baudrate
                    _serialPort.PortName = _PortName
                    _serialPort.Parity = _PortParity
                    _serialPort.DataBits = _DataBits
                    _serialPort.StopBits = _StopBits
                    _serialPort.Handshake = _Handshaking
                    _serialPort.ReadTimeout = _Timeout
                    _serialPort.WriteTimeout = _Timeout
                    _serialPort.Open()
                    _Connect = value
                Else
                    _serialPort.Close()
                End If
            End If
        End Set
    End Property

    Public Property SetTimeout() As Long
        Get
            Return _Timeout
        End Get
        Set(ByVal value As Long)
            _Timeout = value
        End Set
    End Property

    Public Property Prop_Handshaking() As Handshake
        Get
            Return _Handshaking
        End Get
        Set(ByVal value As Handshake)
            _Handshaking = value
        End Set
    End Property

    Public Property Prop_StopBits() As StopBits
        Get
            Return _StopBits
        End Get
        Set(ByVal value As StopBits)
            _StopBits = value
        End Set
    End Property

    Public Property Prop_DataBits() As Integer
        Get
            Return _DataBits
        End Get
        Set(ByVal value As Integer)
            _DataBits = value
        End Set
    End Property

    Public Property Prop_PortParity() As Parity
        Get
            Return _PortParity
        End Get
        Set(ByVal value As Parity)
            _PortParity = value
        End Set
    End Property

    Public Property Prop_PortName() As String
        Get
            Return _PortName
        End Get
        Set(ByVal value As String)
            _PortName = value
        End Set
    End Property

    Public Property Prop_BaudRate() As Long
        Get
            Return _Baudrate
        End Get
        Set(ByVal value As Long)
            _Baudrate = value
        End Set
    End Property

    Private _Laser_Enabled As Boolean
    Public ReadOnly Property Laser_Enabled() As Boolean
        Get
            Return _Laser_Enabled
        End Get
    End Property
End Class

