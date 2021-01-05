Imports Oracle.DataAccess.Client
Public Class Calificacion
    Private noControl As String
    Private idMateria As Integer
    Private idCarrera As Integer
    Private calificacion As Double

    Public Sub New()
        Me.noControl = ""
        Me.idMateria = 0
        Me.idCarrera = 0
        Me.calificacion = 0.0
    End Sub

    Public Sub New(noControl As String, idMateria As Integer, idCarrera As Integer, caificacion As Double)
        Me.noControl = noControl
        Me.idMateria = idMateria
        Me.idCarrera = idCarrera
        Me.calificacion = caificacion
    End Sub

    Public Property getSetNoControl() As String
        Get
            Return noControl
        End Get
        Set(value As String)
            noControl = value
        End Set
    End Property

    Public Property getSetIdMateria() As Integer
        Get
            Return idMateria
        End Get
        Set(value As Integer)
            idMateria = value
        End Set
    End Property

    Public Property getSetIdCarrera() As Integer
        Get
            Return idCarrera
        End Get
        Set(value As Integer)
            idCarrera = value
        End Set
    End Property

    Public Property getSetCalificacion() As Double
        Get
            Return calificacion
        End Get
        Set(value As Double)
            calificacion = value
        End Set
    End Property

    Public Sub insert()
        Dim query As String
        Dim conOracle As New Oracle
        If noControl <> "" And idMateria <> 0 And idCarrera <> 0 And calificacion <> 0.0 Then
            query = "INSERT INTO Calificacion VALUES ('" & noControl & "', " & idMateria & ", " & idCarrera & ", " & calificacion & ")"
            conOracle.objetoCommand(query)
            MessageBox.Show("Se agrego correctamente el registro!")
        Else
            MsgBox("Datos incorrectos!", MsgBoxStyle.Critical, "Error!")
        End If
    End Sub
    Public Sub update()
        Dim query As String
        Dim conOracle As New Oracle
        If noControl <> "" And idMateria <> 0 And idCarrera <> 0 And calificacion <> 0.0 Then
            query = "UPDATE Calificacion SET calificacion = " & calificacion & " WHERE noControl = '" & noControl & "' AND idMateria = " & idMateria &
                    " AND idCarrera = " & idCarrera
            conOracle.objetoCommand(query)
            MessageBox.Show("Se actualizo correctamente el registro!")
        Else
            MsgBox("Datos incorrectos!", MsgBoxStyle.Critical, "Error!")
        End If
    End Sub
    Public Sub delete()
        Dim query As String
        Dim conOracle As New Oracle
        If noControl <> "" And idMateria <> 0 And idCarrera <> 0 Then
            query = "DELETE FROM Calificacion WHERE noControl = '" & noControl & "' AND idMateria = " & idMateria & " AND idCarrera = " & idCarrera
            conOracle.objetoCommand(query)
            MessageBox.Show("Registro Eliminado")
        Else
            MsgBox("Datos incorrectos!", MsgBoxStyle.Critical, "Error!")
        End If
    End Sub
    Public Function consultaIdMateria() As Integer
        Dim query As String
        Dim conOracle As New Oracle
        Dim dt As DataTable
        query = "SELECT idMateria FROM MateriaPorCarrera WHERE descripcion = '" & FormCalificacion.cmbMateria.Text & "'"
        dt = conOracle.objetoDataAdapter(query)
        If dt.Rows.Count = 1 Then
            If IsDBNull(dt.Rows(0)("idMateria")) Then
                idMateria = 0
            Else
                idMateria = CStr(dt.Rows(0)("idMateria"))
            End If
        End If
        Return idMateria
    End Function
    Public Function consultaIdCarrera() As Integer
        Dim query As String
        Dim conOracle As New Oracle
        Dim dt As DataTable
        query = "SELECT idCarrera FROM Carrera WHERE nombre = '" & FormCalificacion.cmbCarrera.Text & "'"
        dt = conOracle.objetoDataAdapter(query)
        If dt.Rows.Count = 1 Then
            If IsDBNull(dt.Rows(0)("idCarrera")) Then
                idCarrera = 0
            Else
                idCarrera = CStr(dt.Rows(0)("idCarrera"))
            End If
        End If
        Return idCarrera
    End Function
    Public Function consultarRegistro() As Boolean
        Dim query As String
        Dim conOracle As New Oracle
        Dim dt As DataTable
        query = "SELECT * FROM Calificacion WHERE noControl = '" & noControl & "' AND idMateria = " & idMateria &
                    " AND idCarrera = " & idCarrera
        consultarRegistro = False
        dt = conOracle.objetoDataAdapter(query)
        If dt.Rows.Count = 1 Then
            If IsDBNull(dt.Rows(0)("noControl")) Then
                noControl = 0
            Else
                noControl = CStr(dt.Rows(0)("noControl"))
            End If
            consultarRegistro = True
        End If
    End Function
    Public Function consultarID() As Boolean
        Dim query As String
        Dim conOracle As New Oracle
        Dim dt As DataTable
        query = "SELECT noControl, idCarrera FROM Alumno WHERE noControl = '" & noControl & "' AND idCarrera = " & idCarrera
        consultarID = False
        dt = conOracle.objetoDataAdapter(query)
        If dt.Rows.Count = 1 Then
            If IsDBNull(dt.Rows(0)("noControl")) Then
                noControl = 0
            Else
                noControl = CStr(dt.Rows(0)("noControl"))
                idCarrera = CInt(dt.Rows(0)("idCarrera"))
            End If
            consultarID = True
        End If
    End Function
    Public Function consultarID2() As Boolean
        Dim query As String
        Dim conOracle As New Oracle
        Dim dt As DataTable
        query = "SELECT idMateria, idCarrera FROM MateriaPorCarrera WHERE idMateria = " & idMateria & " AND idCarrera = " & idCarrera
        consultarID2 = False
        dt = conOracle.objetoDataAdapter(query)
        If dt.Rows.Count = 1 Then
            If IsDBNull(dt.Rows(0)("idMateria")) Then
                idMateria = 0
            Else
                idMateria = CStr(dt.Rows(0)("idMateria"))
                idCarrera = CInt(dt.Rows(0)("idCarrera"))
            End If
            consultarID2 = True
        End If
    End Function
    Public Sub consultarID3()
        Dim query As String
        Dim conOracle As New Oracle
        Dim dt As DataTable
        query = "SELECT Alumno.noControl AS ""No Control"", Carrera.nombre AS Carrera
            FROM CargaMateria 
            INNER JOIN Alumno ON CargaMateria.noControl = Alumno.noControl
            INNER JOIN MateriaPorCarrera ON CargaMateria.idMateria = MateriaPorCarrera.idMateria
            AND CargaMateria.idCarrera = MateriaPorCarrera.idCarrera
            INNER JOIN Carrera ON MateriaPorCarrera.idCarrera = Carrera.idCarrera
            WHERE Alumno.noControl = '" & FormCalificacion.cmbNoControl.Text & "'
            GROUP BY Alumno.noControl, Carrera.nombre"
        dt = conOracle.objetoDataAdapter(query)
        If dt.Rows.Count = 1 Then
            If IsDBNull(dt.Rows(0)("No Control")) Then
                noControl = 0
            Else
                FormCalificacion.cmbCarrera.Text = CStr(dt.Rows(0)("Carrera"))
            End If
        End If
    End Sub
    Public Sub consultarID4()
        Dim query As String
        Dim conOracle As New Oracle
        Dim dt As DataTable
        query = "SELECT Calificacion FROM Calificacion
                INNER JOIN CargaMateria ON Calificacion.idMateria = CargaMateria.idMateria
                AND Calificacion.idCarrera = CargaMateria.idCarrera
                AND Calificacion.noControl = CargaMateria.noControl
                INNER JOIN MateriaPorCarrera ON CargaMateria.idMateria = MateriaPorCarrera.idMateria
                AND CargaMateria.idCarrera = MateriaPorCarrera.idCarrera
                WHERE Calificacion.noControl = '" & FormCalificacion.cmbNoControl.Text & "'
                AND MateriaPorCarrera.descripcion = '" & FormCalificacion.cmbMateria.Text & "'"
        dt = conOracle.objetoDataAdapter(query)
        If dt.Rows.Count = 1 Then
            If IsDBNull(dt.Rows(0)("Calificacion")) Then
                calificacion = 0
            Else
                FormCalificacion.txtCalificacion.Text = CInt(dt.Rows(0)("Calificacion"))
            End If
        End If
    End Sub
    Public Function consultarTabla() As Object
        Dim query As String
        Dim conOracle As New Oracle
        'If FormCalificacion.cmbCarrera.Text <> "" And FormCalificacion.cmbMateria.Text = "" And FormCalificacion.cmbNoControl.Text = "" Then
        '    query = "SELECT Calificacion.noControl AS ""No Control"", MateriaPorCarrera.descripcion AS Materia, 
        '            Carrera.nombre AS Carrera, Calificacion.calificacion AS Calificacion
        '            FROM Calificacion 
        '            INNER JOIN CargaMateria ON Calificacion.idMateria = CargaMateria.idMateria
        '            AND Calificacion.idCarrera = CargaMateria.idCarrera
        '            AND Calificacion.noControl = CargaMateria.noControl
        '            INNER JOIN Alumno ON CargaMateria.noControl = Alumno.noControl
        '            INNER JOIN MateriaPorCarrera ON CargaMateria.idMateria = MateriaPorCarrera.idMateria
        '            AND CargaMateria.idCarrera = MateriaPorCarrera.idCarrera
        '            INNER JOIN Carrera ON MateriaPorCarrera.idCarrera = Carrera.idCarrera
        '            AND Carrera.nombre = '" & FormCalificacion.cmbCarrera.Text & "'
        '            ORDER BY Calificacion.noControl"
        'ElseIf FormCalificacion.cmbCarrera.Text <> "" And FormCalificacion.cmbMateria.Text = "" And FormCalificacion.cmbNoControl.Text <> "" Then
        '    query = "SELECT Calificacion.noControl AS ""No Control"", MateriaPorCarrera.descripcion AS Materia, 
        '            Carrera.nombre AS Carrera, Calificacion.calificacion AS Calificacion
        '            FROM Calificacion 
        '            INNER JOIN CargaMateria ON Calificacion.idMateria = CargaMateria.idMateria
        '            AND Calificacion.idCarrera = CargaMateria.idCarrera
        '            AND Calificacion.noControl = CargaMateria.noControl
        '            INNER JOIN Alumno ON CargaMateria.noControl = Alumno.noControl
        '            INNER JOIN MateriaPorCarrera ON CargaMateria.idMateria = MateriaPorCarrera.idMateria
        '            AND CargaMateria.idCarrera = MateriaPorCarrera.idCarrera
        '            INNER JOIN Carrera ON MateriaPorCarrera.idCarrera = Carrera.idCarrera 
        '            AND Carrera.nombre = '" & FormCalificacion.cmbCarrera.Text & "'
        '            AND Alumno.noControl = '" & FormCalificacion.cmbNoControl.Text & "'
        '            ORDER BY Calificacion.noControl"
        'ElseIf FormCalificacion.cmbCarrera.Text <> "" And FormCalificacion.cmbMateria.Text <> "" And FormCalificacion.cmbNoControl.Text = "" Then
        '    query = "SELECT Calificacion.noControl AS ""No Control"", MateriaPorCarrera.descripcion AS Materia, 
        '            Carrera.nombre AS Carrera, Calificacion.calificacion AS Calificacion
        '            FROM Calificacion 
        '            INNER JOIN CargaMateria ON Calificacion.idMateria = CargaMateria.idMateria
        '            AND Calificacion.idCarrera = CargaMateria.idCarrera
        '            AND Calificacion.noControl = CargaMateria.noControl
        '            INNER JOIN Alumno ON CargaMateria.noControl = Alumno.noControl
        '            INNER JOIN MateriaPorCarrera ON CargaMateria.idMateria = MateriaPorCarrera.idMateria
        '            AND CargaMateria.idCarrera = MateriaPorCarrera.idCarrera
        '            INNER JOIN Carrera ON MateriaPorCarrera.idCarrera = Carrera.idCarrera 
        '            AND Carrera.nombre = '" & FormCalificacion.cmbCarrera.Text & "'
        '            AND MateriaPorCarrera.descripcion = '" & FormCalificacion.cmbMateria.Text & "'
        '        ORDER BY Calificacion.noControl"
        'ElseIf FormCalificacion.cmbCarrera.Text <> "" And FormCalificacion.cmbMateria.Text <> "" And FormCalificacion.cmbNoControl.Text <> "" Then
        '    query = "SELECT Calificacion.noControl AS ""No Control"", MateriaPorCarrera.descripcion AS Materia, 
        '            Carrera.nombre AS Carrera, Calificacion.calificacion AS Calificacion
        '            FROM Calificacion 
        '            INNER JOIN CargaMateria ON Calificacion.idMateria = CargaMateria.idMateria
        '            AND Calificacion.idCarrera = CargaMateria.idCarrera
        '            AND Calificacion.noControl = CargaMateria.noControl
        '            INNER JOIN Alumno ON CargaMateria.noControl = Alumno.noControl
        '            INNER JOIN MateriaPorCarrera ON CargaMateria.idMateria = MateriaPorCarrera.idMateria
        '            AND CargaMateria.idCarrera = MateriaPorCarrera.idCarrera
        '            INNER JOIN Carrera ON MateriaPorCarrera.idCarrera = Carrera.idCarrera 
        '            AND Carrera.nombre = '" & FormCalificacion.cmbCarrera.Text & "'
        '            AND MateriaPorCarrera.descripcion = '" & FormCalificacion.cmbMateria.Text & "'
        '            AND Alumno.noControl = '" & FormCalificacion.cmbNoControl.Text & "'
        '            ORDER BY Calificacion.noControl"
        'ElseIf FormCalificacion.cmbCarrera.Text = "" And FormCalificacion.cmbMateria.Text <> "" And FormCalificacion.cmbNoControl.Text = "" Then
        '    query = "SELECT Calificacion.noControl AS ""No Control"", MateriaPorCarrera.descripcion AS Materia, 
        '            Carrera.nombre AS Carrera, Calificacion.calificacion AS Calificacion
        '            FROM Calificacion 
        '            INNER JOIN CargaMateria ON Calificacion.idMateria = CargaMateria.idMateria
        '            AND Calificacion.idCarrera = CargaMateria.idCarrera
        '            AND Calificacion.noControl = CargaMateria.noControl
        '            INNER JOIN Alumno ON CargaMateria.noControl = Alumno.noControl
        '            INNER JOIN MateriaPorCarrera ON CargaMateria.idMateria = MateriaPorCarrera.idMateria
        '            AND CargaMateria.idCarrera = MateriaPorCarrera.idCarrera
        '            INNER JOIN Carrera ON MateriaPorCarrera.idCarrera = Carrera.idCarrera
        '            AND MateriaPorCarrera.descripcion = '" & FormCalificacion.cmbMateria.Text & "'
        '            ORDER BY Calificacion.noControl"
        'ElseIf FormCalificacion.cmbCarrera.Text = "" And FormCalificacion.cmbMateria.Text <> "" And FormCalificacion.cmbNoControl.Text <> "" Then
        '    query = "SELECT Calificacion.noControl AS ""No Control"", MateriaPorCarrera.descripcion AS Materia, 
        '            Carrera.nombre AS Carrera, Calificacion.calificacion AS Calificacion
        '            FROM Calificacion 
        '            INNER JOIN CargaMateria ON Calificacion.idMateria = CargaMateria.idMateria
        '            AND Calificacion.idCarrera = CargaMateria.idCarrera
        '            AND Calificacion.noControl = CargaMateria.noControl
        '            INNER JOIN Alumno ON CargaMateria.noControl = Alumno.noControl
        '            INNER JOIN MateriaPorCarrera ON CargaMateria.idMateria = MateriaPorCarrera.idMateria
        '            AND CargaMateria.idCarrera = MateriaPorCarrera.idCarrera
        '            INNER JOIN Carrera ON MateriaPorCarrera.idCarrera = Carrera.idCarrera
        '            AND MateriaPorCarrera.descripcion = '" & FormCalificacion.cmbMateria.Text & "'
        '            AND Alumno.noControl = '" & FormCalificacion.cmbNoControl.Text & "'
        '            ORDER BY Calificacion.noControl"
        'ElseIf FormCalificacion.cmbCarrera.Text = "" And FormCalificacion.cmbMateria.Text = "" And FormCalificacion.cmbNoControl.Text <> "" Then
        '    query = "SELECT Calificacion.noControl AS ""No Control"", MateriaPorCarrera.descripcion AS Materia, 
        '            Carrera.nombre AS Carrera, Calificacion.calificacion AS Calificacion
        '            FROM Calificacion 
        '            INNER JOIN CargaMateria ON Calificacion.idMateria = CargaMateria.idMateria
        '            AND Calificacion.idCarrera = CargaMateria.idCarrera
        '            AND Calificacion.noControl = CargaMateria.noControl
        '            INNER JOIN Alumno ON CargaMateria.noControl = Alumno.noControl
        '            INNER JOIN MateriaPorCarrera ON CargaMateria.idMateria = MateriaPorCarrera.idMateria
        '            AND CargaMateria.idCarrera = MateriaPorCarrera.idCarrera
        '            INNER JOIN Carrera ON MateriaPorCarrera.idCarrera = Carrera.idCarrera
        '            AND Alumno.noControl = '" & FormCalificacion.cmbNoControl.Text & "'
        '            ORDER BY Calificacion.noControl"
        'Else
        '    query = "SELECT Calificacion.noControl AS ""No Control"", MateriaPorCarrera.descripcion AS Materia, 
        '            Carrera.nombre AS Carrera, Calificacion.calificacion AS Calificacion
        '            FROM Calificacion 
        '            INNER JOIN CargaMateria ON Calificacion.idMateria = CargaMateria.idMateria
        '            AND Calificacion.idCarrera = CargaMateria.idCarrera
        '            AND Calificacion.noControl = CargaMateria.noControl
        '            INNER JOIN Alumno ON CargaMateria.noControl = Alumno.noControl
        '            INNER JOIN MateriaPorCarrera ON CargaMateria.idMateria = MateriaPorCarrera.idMateria
        '            AND CargaMateria.idCarrera = MateriaPorCarrera.idCarrera
        '            INNER JOIN Carrera ON MateriaPorCarrera.idCarrera = Carrera.idCarrera
        '            ORDER BY Calificacion.noControl"
        'End If
        query = "SELECT Calificacion.noControl AS ""No Control"", MateriaPorCarrera.descripcion AS Materia, 
                    Carrera.nombre AS Carrera, Calificacion.calificacion AS Calificacion
                    FROM Calificacion 
                    INNER JOIN CargaMateria ON Calificacion.idMateria = CargaMateria.idMateria
                    AND Calificacion.idCarrera = CargaMateria.idCarrera
                    AND Calificacion.noControl = CargaMateria.noControl
                    INNER JOIN Alumno ON CargaMateria.noControl = Alumno.noControl
                    INNER JOIN MateriaPorCarrera ON CargaMateria.idMateria = MateriaPorCarrera.idMateria
                    AND CargaMateria.idCarrera = MateriaPorCarrera.idCarrera
                    INNER JOIN Carrera ON MateriaPorCarrera.idCarrera = Carrera.idCarrera
                    ORDER BY Calificacion.noControl"
        consultarTabla = conOracle.objetoDataAdapter(query)
    End Function
    Public Sub comboNoControl(ByVal cmb As ComboBox)
        Dim lista As OracleDataReader
        Dim query As String
        Dim conOracle As New Oracle
        query = "SELECT CargaMateria.noControl FROM CargaMateria, alumno, Carrera
                WHERE CargaMateria.noControl = CargaMateria.noControl AND
                CargaMateria.idCarrera = Alumno.idCarrera 
                AND Alumno.idCarrera = Carrera.idCarrera AND
                Carrera.nombre = '" & FormCalificacion.cmbCarrera.Text & "'
                GROUP BY CargaMateria.noControl"
        '"SELECT Alumno.noControl FROM Alumno, Carrera 
        '        WHERE Alumno.idCarrera = Carrera.idCarrera AND
        '        Carrera.nombre = '" & FormCalificacion.cmbCarrera.Text & "'"
        'If FormCalificacion.cmbCarrera.Text = "" And FormCalificacion.cmbMateria.Text = "" Then
        '    query = "SELECT noControl FROM Alumno"
        'ElseIf FormCalificacion.cmbCarrera.Text = "" And FormCalificacion.cmbMateria.Text <> "" Then
        '    query = "SELECT noControl FROM Alumno
        '            INNER JOIN Carrera ON Alumno.idCarrera = Carrera.idCarrera
        '            INNER JOIN MateriaPorCarrera ON Carrera.idCarrera = MateriaPorCarrera.idCarrera
        '            WHERE MateriaPorCarrera.descripcion = '" & FormCalificacion.cmbMateria.Text & "'"
        'ElseIf FormCalificacion.cmbCarrera.Text <> "" And FormCalificacion.cmbMateria.Text = "" Then
        'query = "SELECT noControl FROM Alumno
        '            INNER JOIN Carrera ON Alumno.idCarrera = Carrera.idCarrera
        '            WHERE Carrera.nombre = '" & FormCalificacion.cmbCarrera.Text & "'"
        'Else
        '    query = "SELECT noControl FROM Alumno
        '            INNER JOIN Carrera ON Alumno.idCarrera = Carrera.idCarrera
        '            INNER JOIN MateriaPorCarrera ON Carrera.idCarrera = MateriaPorCarrera.idCarrera
        '            WHERE MateriaPorCarrera.descripcion = '" & FormCalificacion.cmbMateria.Text & "'
        '            WHERE Carrera.nombre = '" & FormCalificacion.cmbCarrera.Text & "'"
        'End If
        lista = conOracle.objetoDataReader(query)
        cmb.Items.Clear()
        While lista.Read()
            cmb.Items.Add(lista.GetValue(0))
        End While
    End Sub
    Public Sub comboCarrera(ByVal cmb As ComboBox)
        Dim lista As OracleDataReader
        Dim query As String
        Dim conOracle As New Oracle
        query = "SELECT nombre FROM Carrera"
        lista = conOracle.objetoDataReader(query)
        cmb.Items.Clear()
        While lista.Read()
            cmb.Items.Add(lista.GetValue(0))
        End While
    End Sub
    Public Sub comboMateria(ByVal cmb As ComboBox)
        Dim lista As OracleDataReader
        Dim query As String
        Dim conOracle As New Oracle
        'If FormCalificacion.cmbNoControl.Text = "" And FormCalificacion.cmbCarrera.Text = "" Then
        '    query = "SELECT descripcion FROM MateriaPorCarrera"
        'ElseIf FormCalificacion.cmbNoControl.Text = "" And FormCalificacion.cmbCarrera.Text <> "" Then
        '    query = "SELECT MateriaPorCarrera.descripcion FROM MateriaPorCarrera
        '            INNER JOIN Carrera ON MateriaPorCarrera.idCarrera = Carrera.idCarrera
        '            WHERE Carrera.nombre = '" & FormCalificacion.cmbCarrera.Text & "'"
        'ElseIf FormCalificacion.cmbNoControl.Text <> "" And FormCalificacion.cmbCarrera.Text = "" Then
        '    query = "SELECT MateriaPorCarrera.descripcion FROM MateriaPorCarrera
        '            INNER JOIN Alumno ON CargaMateria.noControl = Alumno.noControl
        '            Alumno.noControl = '" & FormCalificacion.cmbNoControl.Text & "'"
        'Else
        'el chido
        'query = "SELECT MateriaPorCarrera.descripcion FROM MateriaPorCarrera
        '            INNER JOIN Carrera ON MateriaPorCarrera.idCarrera = Carrera.idCarrera
        '            INNER JOIN CargaMateria ON MateriaPorCarrera.idCarrera = CargaMateria.idCarrera
        '            AND MateriaPorCarrera.idMateria = CargaMateria.idMateria
        '            INNER JOIN Alumno ON CargaMateria.noControl = Alumno.noControl
        '            WHERE Carrera.nombre = '" & FormCalificacion.cmbCarrera.Text & "' AND
        '            Alumno.noControl = '" & FormCalificacion.cmbNoControl.Text & "'"
        'End If
        If FormCalificacion.cmbNoControl.Text = "" Then
            query = "SELECT MateriaPorCarrera.descripcion FROM Carrera, MateriaPorCarrera, CargaMateria
                    WHERE CargaMateria.idCarrera = MateriaPorCarrera.idCarrera AND
                    CargaMateria.idMateria = MateriaPorCarrera.idMateria AND
                    MateriaPorCarrera.idCarrera = Carrera.idCarrera AND
                    Carrera.nombre = '" & FormCalificacion.cmbCarrera.Text & "'
                    GROUP BY MateriaPorCarrera.descripcion"
        Else
            query = "SELECT MateriaPorCarrera.descripcion FROM Carrera, MateriaPorCarrera, CargaMateria
                    WHERE CargaMateria.idCarrera = MateriaPorCarrera.idCarrera AND
                    CargaMateria.idMateria = MateriaPorCarrera.idMateria AND
                    MateriaPorCarrera.idCarrera = Carrera.idCarrera AND
                    Carrera.nombre = '" & FormCalificacion.cmbCarrera.Text & "' AND
                    CargaMateria.noControl = '" & FormCalificacion.cmbNoControl.Text & "'"
        End If
        lista = conOracle.objetoDataReader(query)
        cmb.Items.Clear()
        While lista.Read()
            cmb.Items.Add(lista.GetValue(0))
        End While
    End Sub
    Public Sub dataGirdView(ByVal dgv As DataGridView)
        dgv.DataSource = consultarTabla()
        dgv.Refresh()
        dgv.Columns.Item(1).Width = 160
        dgv.Columns.Item(2).Width = 135
    End Sub
End Class