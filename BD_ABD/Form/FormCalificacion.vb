Public Class FormCalificacion
    Dim calificacion As New Calificacion
    Private Sub btnAtras_Click(sender As Object, e As EventArgs) Handles btnAtras.Click, Button4.Click, Button2.Click
        FormMain.Show()
        Me.Close()
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        If cmbCarrera.Text = "" Or cmbNoControl.Text = "" Or cmbMateria.Text = "" Or txtCalificacion.Text = "" Then
            MessageBox.Show("Datos incompletos o erroneos")
        Else
            calificacion = New Calificacion(cmbNoControl.Text, calificacion.consultaIdMateria(), calificacion.consultaIdCarrera(), txtCalificacion.Text)
            calificacion.getSetNoControl() = cmbNoControl.Text
            calificacion.getSetIdMateria() = calificacion.consultaIdMateria()
            calificacion.getSetIdCarrera() = calificacion.consultaIdCarrera()
            calificacion.getSetCalificacion() = txtCalificacion.Text
            If calificacion.consultarID And calificacion.consultarID2 Then
                If calificacion.consultarRegistro() = False Then
                    calificacion.insert()
                    calificacion.dataGirdView(dgv)
                Else
                    If MessageBox.Show("Este registro ya existe!, Quieres actualizarlo?", "Confirmar", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                        calificacion.update()
                    End If
                End If
                calificacion.dataGirdView(dgv)
            Else
                MessageBox.Show("No se puede agregar este registo, este registro ya existe!")
            End If
        End If
    End Sub

    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        If cmbCarrera.Text = "" Or cmbNoControl.Text = "" Or cmbMateria.Text = "" Or txtCalificacion.Text = "" Then
            MessageBox.Show("Datos incompletos o erroneos")
        Else
            calificacion = New Calificacion(cmbNoControl.Text, calificacion.consultaIdMateria(), calificacion.consultaIdCarrera(), txtCalificacion.Text)
            calificacion.getSetNoControl() = cmbNoControl.Text
            calificacion.getSetIdMateria() = calificacion.consultaIdMateria()
            calificacion.getSetIdCarrera() = calificacion.consultaIdCarrera()
            calificacion.getSetCalificacion() = txtCalificacion.Text
            If calificacion.consultarRegistro() = True Then
                calificacion.update()
            Else
                MessageBox.Show("No existe ese registro!, verifique los datos")
            End If
            calificacion.dataGirdView(dgv)
        End If
    End Sub

    Private Sub btnBorrar_Click(sender As Object, e As EventArgs) Handles btnBorrar.Click, Button1.Click
        If cmbCarrera.Text = "" Or cmbNoControl.Text = "" Or cmbMateria.Text = "" Or txtCalificacion.Text = "" Then
            MessageBox.Show("Datos incompletos o erroneos")
        Else
            calificacion = New Calificacion(cmbNoControl.Text, calificacion.consultaIdMateria(), calificacion.consultaIdCarrera(), txtCalificacion.Text)
            calificacion.getSetNoControl() = cmbNoControl.Text
            calificacion.getSetIdMateria() = calificacion.consultaIdMateria()
            calificacion.getSetIdCarrera() = calificacion.consultaIdCarrera()
            calificacion.getSetCalificacion() = txtCalificacion.Text
            If calificacion.consultarRegistro() = True Then
                If MessageBox.Show("¿Esta seguro?", "CONFIRMAR", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                    calificacion.delete()
                End If
            Else
                MessageBox.Show("No existe ese registro!, verifique los datos")
            End If
            calificacion.dataGirdView(dgv)
        End If
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click, Button3.Click
        cmbCarrera.Text = ""
        cmbNoControl.Text = ""
        cmbMateria.Text = ""
        txtCalificacion.Text = ""
        calificacion.dataGirdView(dgv)
    End Sub

    Private Sub FormCalificacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        calificacion.comboCarrera(cmbCarrera)
        calificacion.dataGirdView(dgv)
        Me.ToolTip1.SetToolTip(Me.btnLimpiar, "Click para limpiar cajas de texto ...")
        Me.ToolTip1.SetToolTip(Me.btnAgregar, "Click para Guardar información en el sistema...")
        Me.ToolTip1.SetToolTip(Me.btnActualizar, "Click para Actualizar la informacion en el sistema...")
        Me.ToolTip1.SetToolTip(Me.btnBorrar, "Click para Eliminar información en el sistema...")
    End Sub
    Private Sub dgv_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellClick
        cmbNoControl.Text = dgv.Rows(dgv.CurrentCellAddress.Y).Cells(0).Value
        cmbMateria.Text = dgv.Rows(dgv.CurrentCellAddress.Y).Cells(1).Value
        cmbCarrera.Text = dgv.Rows(dgv.CurrentCellAddress.Y).Cells(2).Value
        txtCalificacion.Text = dgv.Rows(dgv.CurrentCellAddress.Y).Cells(3).Value
    End Sub

    Private Sub cmbCarrera_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCarrera.SelectedIndexChanged
        calificacion.comboNoControl(cmbNoControl)
        calificacion.comboMateria(cmbMateria)
    End Sub

    Private Sub cmbNoControl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbNoControl.SelectedIndexChanged
        calificacion.comboMateria(cmbMateria)
    End Sub

    Private Sub cmbNoControl_TextChanged(sender As Object, e As EventArgs) Handles cmbNoControl.TextChanged
        If cmbNoControl.Text <> "" And IsNumeric(cmbNoControl.Text) Then
            calificacion.consultarID3()
        End If
    End Sub
    Private Sub cmbMateria_TextChanged(sender As Object, e As EventArgs) Handles cmbMateria.TextChanged
        If cmbNoControl.Text <> "" And IsNumeric(cmbNoControl.Text) And cmbMateria.Text <> "" Then
            calificacion.consultarID4()
        End If
    End Sub
End Class