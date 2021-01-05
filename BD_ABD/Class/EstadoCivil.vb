Imports Oracle.DataAccess.Client
Public Class EstadoCivil
    Private idCivil As Integer
    Private nombre As String
    Public Sub New()
        Me.idCivil = 0
        Me.nombre = ""
    End Sub

    Public Sub New(idCivil As Integer, nombre As String)
        Me.idCivil = idCivil
        Me.nombre = nombre
    End Sub

    Public Property getSetIdCivil As Integer
        Get
            Return idCivil
        End Get
        Set(value As Integer)
            idCivil = value
        End Set
    End Property

    Public Property getSetNombre As String
        Get
            Return nombre
        End Get
        Set(value As String)
            nombre = value
        End Set
    End Property

    Public Sub insert()
        Dim query As String
        Dim conOracle As New Oracle
        If idCivil <> 0 And nombre <> "" Then
            query = "INSERT INTO EstadoCivil VALUES (" & idCivil & ", '" & nombre & "')"
            conOracle.objetoCommand(query)
            MessageBox.Show("Se agrego correctamente el registro!")
        Else
            MsgBox("Datos incorrectos!", MsgBoxStyle.Critical, "Error!")
        End If
    End Sub
    Public Sub update()
        Dim query As String
        Dim conOracle As New Oracle
        If idCivil <> 0 And nombre <> "" Then
            query = "UPDATE EstadoCivil SET nombre = '" & nombre & "' WHERE idCivil = " & idCivil
            conOracle.objetoCommand(query)
            MessageBox.Show("Se actualizo correctamente el registro!")
        Else
            MsgBox("Datos incorrectos!", MsgBoxStyle.Critical, "Error!")
        End If
    End Sub
    Public Sub delete()
        Dim query As String
        Dim conOracle As New Oracle
        If idCivil <> 0 Then
            query = "DELETE FROM EstadoCivil WHERE idCivil = " & idCivil
            conOracle.objetoCommand(query)
            MessageBox.Show("Registro Eliminado")
        Else
            MsgBox("Datos incorrectos!", MsgBoxStyle.Critical, "Error!")
        End If
    End Sub
    Public Function consultarRegistro() As Boolean
        Dim query As String
        Dim conOracle As New Oracle
        Dim dt As DataTable
        query = "SELECT * FROM EstadoCivil WHERE idCivil = " & idCivil
        consultarRegistro = False
        dt = conOracle.objetoDataAdapter(query)
        If dt.Rows.Count = 1 Then
            If IsDBNull(dt.Rows(0)("idCivil")) Then
                idCivil = 0
            Else
                idCivil = CStr(dt.Rows(0)("idCivil"))
            End If
            consultarRegistro = True
        End If
    End Function
    Public Function validacion() As Boolean
        Dim query As String
        Dim conOracle As New Oracle
        Dim dataT As New DataTable
        query = "Select * FROM Alumno WHERE idCivil = " & idCivil
        validacion = False
        dataT = conOracle.objetoDataAdapter(query)
        If dataT.Rows.Count >= 1 Then
            If IsDBNull(dataT.Rows(0)("idCivil")) Then
                idCivil = 0
            Else
                idCivil = CInt(dataT.Rows(0)("idCivil"))
            End If
            validacion = True
        End If
    End Function
    Sub consultarID()
        Dim query As String
        Dim conOracle As New Oracle
        Dim dataT As New DataTable
        query = "Select * FROM EstadoCivil WHERE idCivil = " & FormEstadoCivil.txtIdCivil.Text
        dataT = conOracle.objetoDataAdapter(query)
        If dataT.Rows.Count >= 1 Then
            If IsDBNull(dataT.Rows(0)("idCivil")) Then
                idCivil = 0
            Else
                idCivil = CInt(dataT.Rows(0)("idCivil"))
                FormEstadoCivil.cmbNombre.Text = CStr(dataT.Rows(0)("nombre"))
            End If
        End If
    End Sub
    Public Function consultarTabla() As Object
        Dim query As String
        Dim conOracle As New Oracle
        query = "SELECT idCivil as ""Id Estado Civil"", nombre AS ""Estado Civil"" FROM EstadoCivil ORDER BY idCivil"
        consultarTabla = conOracle.objetoDataAdapter(query)
    End Function

    Public Sub comboEstadoCivil(ByVal cmb As ComboBox)
        Dim lista As OracleDataReader
        Dim query As String
        Dim conOracle As New Oracle
        query = "SELECT nombre FROM EstadoCivil"
        lista = conOracle.objetoDataReader(query)
        cmb.Items.Clear()
        While lista.Read()
            cmb.Items.Add(lista.GetValue(0))
        End While
    End Sub
    Public Sub dataGirdView(ByVal dgv As DataGridView)
        dgv.DataSource = consultarTabla()
        dgv.Refresh()
        dgv.Columns.Item(0).Width = 250
        dgv.Columns.Item(1).Width = 265
    End Sub
End Class
