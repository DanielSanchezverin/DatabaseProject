Imports Oracle.DataAccess.Client
Public Class Genero
    Private idGenero As Integer
    Private nombre As String

    Public Sub New()
        Me.idGenero = 0
        Me.nombre = ""
    End Sub
    Public Sub New(idGenero As Integer, nombre As String)
        Me.idGenero = idGenero
        Me.nombre = nombre
    End Sub

    Public Property getSetIdGenero As Integer
        Get
            Return idGenero
        End Get
        Set(value As Integer)
            idGenero = value
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
        If idGenero <> 0 And nombre <> "" Then
            query = "INSERT INTO Genero VALUES (" & idGenero & ", '" & nombre & "')"
            conOracle.objetoCommand(query)
            MessageBox.Show("Se agrego correctamente el registro!")
        Else
            MsgBox("Datos incorrectos!", MsgBoxStyle.Critical, "Error!")
        End If
    End Sub
    Public Sub update()
        Dim query As String
        Dim conOracle As New Oracle
        If idGenero <> 0 And nombre <> "" Then
            query = "UPDATE Genero SET nombre = '" & nombre & "' WHERE idGenero = " & idGenero
            conOracle.objetoCommand(query)
            MessageBox.Show("Se actualizo correctamente el registro!")
        Else
            MsgBox("Datos incorrectos!", MsgBoxStyle.Critical, "Error!")
        End If
    End Sub
    Public Sub delete()
        Dim query As String
        Dim conOracle As New Oracle
        If idGenero <> 0 Then
            query = "DELETE FROM Genero WHERE idGenero = " & idGenero
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
        query = "SELECT * FROM Genero WHERE idGenero = " & idGenero
        consultarRegistro = False
        dt = conOracle.objetoDataAdapter(query)
        If dt.Rows.Count = 1 Then
            If IsDBNull(dt.Rows(0)("idGenero")) Then
                idGenero = 0
            Else
                idGenero = CStr(dt.Rows(0)("idGenero"))
            End If
            consultarRegistro = True
        End If
    End Function
    Public Function validacion() As Boolean
        Dim query As String
        Dim conOracle As New Oracle
        Dim dataT As New DataTable
        query = "Select * FROM Alumno WHERE idGenero = " & idGenero
        validacion = False
        dataT = conOracle.objetoDataAdapter(query)
        If dataT.Rows.Count >= 1 Then
            If IsDBNull(dataT.Rows(0)("idGenero")) Then
                idGenero = 0
            Else
                idGenero = CInt(dataT.Rows(0)("idGenero"))
            End If
            validacion = True
        End If
    End Function
    Sub consultarID()
        Dim query As String
        Dim conOracle As New Oracle
        Dim dataT As New DataTable
        query = "Select * FROM Genero WHERE idGenero = " & FormGenero.txtIdGenero.Text
        dataT = conOracle.objetoDataAdapter(query)
        If dataT.Rows.Count >= 1 Then
            If IsDBNull(dataT.Rows(0)("idGenero")) Then
                idGenero = 0
            Else
                idGenero = CInt(dataT.Rows(0)("idGenero"))
                FormGenero.cmbGenero.Text = CStr(dataT.Rows(0)("nombre"))
            End If
        End If
    End Sub
    Public Function consultarTabla() As Object
        Dim query As String
        Dim conOracle As New Oracle
        query = "SELECT idGenero as ""Id Genero"", nombre AS Genero FROM Genero ORDER BY idGenero"
        consultarTabla = conOracle.objetoDataAdapter(query)
    End Function

    Public Sub comboGenero(ByVal cmb As ComboBox)
        Dim lista As OracleDataReader
        Dim query As String
        Dim conOracle As New Oracle
        query = "SELECT nombre FROM Genero"
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
