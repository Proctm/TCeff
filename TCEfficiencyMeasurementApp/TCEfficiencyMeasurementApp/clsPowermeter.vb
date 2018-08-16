Imports Thorlabs.PM100D
Public Class cls_powermeter
    Private _PowerMeter As PM100D
    'At present power meters can only be Thorlabs Connected to any PM100 unit
    Public Sub New(ByVal ResourceName As String, ByVal ModelNumber As String, ByVal SerialNumber As String, ByVal PowerMeterNumber As Integer)

        _ResourceName = ResourceName
        _ModelNo = Trim(ModelNumber)
        _SerialNo = Trim(SerialNumber)
        _PWMno = PowerMeterNumber

        _PowerMeter = New PM100D(_ResourceName, True, True)
    End Sub

#Region "PowerMeter Propoties"
    Private _ResourceName As String
    Public ReadOnly Property ResourceName() As String
        Get
            Return _ResourceName
        End Get
    End Property

    Private _PWMno As String
    Public ReadOnly Property PWMNo() As String
        Get
            Return _PWMno
        End Get
    End Property

    Private _ModelNo As String
    Public ReadOnly Property ModelNo() As String
        Get
            Return _ModelNo
        End Get
    End Property

    Private _SerialNo As String
    Public ReadOnly Property SerialNo() As String
        Get
            Return _SerialNo
        End Get
    End Property

    Private _PowerValue As Double
    Public ReadOnly Property PowerValue() As Double
        Get
            _PowerValue = GetPower()
            Return _PowerValue
        End Get
    End Property



    Private _QuickDrop_Power As Double
    Public ReadOnly Property QuickDrop_Power() As String
        Get
            Return _QuickDrop_Power
        End Get
    End Property

    Private _QuickDrop_Enabled As Boolean
    Public Property QuickDrop_Enabled() As Boolean
        Get
            Return _QuickDrop_Enabled
        End Get
        Set(ByVal value As Boolean)
            If value = True Then
                _QuickDrop_Power = Math.Round(_PowerValue - (_PowerValue / 3), 2)
            Else 'value is false
                _QuickDrop_Power = 0
            End If
            _QuickDrop_Enabled = value
        End Set
    End Property

    Private _AutoRange As Boolean
    Public Property AutoRange() As Boolean
        Get
            Return _AutoRange
        End Get
        Set(ByVal value As Boolean)
            _PowerMeter.setPowerAutoRange(value)
            _AutoRange = value
        End Set
    End Property

    Private _Setlambda As Integer
    Public Property Setlambda() As Integer
        Get
            Return _Setlambda
        End Get
        Set(ByVal value As Integer)
            _PowerMeter.setWavelength(value)
            _Setlambda = value
        End Set
    End Property
#End Region

#Region "PowerMeter Functions and set wavelength"
    Private Function GetPower() As Double
        Dim Power As Double = 0
        _PowerMeter.measPower(Power)
        Return Power
    End Function

    'Private Function Setwave() As Double
    '  Dim lambda As Double
    ' _PowerMeter.setWavelength(lambda)
    'Return lambda
    'End Function


#End Region

End Class
