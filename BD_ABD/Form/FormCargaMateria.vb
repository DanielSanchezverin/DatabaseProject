Imports Oracle.DataAccess.Client
Public Class FormCargaMateria
    Dim cargaMateria As New CargaMateria
    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        If cmbCarrera.Text = "" Or cmbNoControl.Text = "" Or cmbMateria.Text = "" Then
            MessageBox.Show("Datos incompletos o erroneos")
        Else
            cargaMateria = New CargaMateria(cmbNoControl.Text, cargaMateria.consultaIdMateria, cargaMateria.consultaIdCarrera)
            cargaMateria.getSetNoControl = cmbNoControl.Text
            cargaMateria.getSetIdMateria = cargaMateria.consultaIdMateria
            cargaMateria.getSetIdCarrera = cargaMateria.consultaIdCarrera
            If cargaMateria.consultarID() And cargaMateria.consultarID2() Then
                If cargaMateria.consultarRegistro = False Then
                    cargaMateria.insert()
                    cargaMateria.dataGirdView(dgv)
                Else
                    'If MessageBox.Show("Este registro ya existe!, Quieres actualizarlo?", "Confirmar", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                    '    cargaMateria.update()
                    MessageBox.Show("No se puede agregar este registo, este registro ya existe!")
                    'End If
                End If
                cargaMateria.dataGirdView(dgv)
            Else
                MessageBox.Show("No se puede agregar este registo, este registro ya existe!")
            End If
        End If
    End Sub

    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        If cmbCarrera.Text = "" Or cmbNoControl.Text = "" Or cmbMateria.Text = "" Then
            MessageBox.Show("Datos incompletos o erroneos")
        Else
            cargaMateria = New CargaMateria(cmbNoControl.Text, cargaMateria.consultaIdMateria, cargaMateria.consultaIdCarrera)
            cargaMateria.getSetNoControl = cmbNoControl.Text
            cargaMateria.getSetIdMateria = cargaMateria.consultaIdMateria
            cargaMateria.getSetIdCarrera = cargaMateria.consultaIdCarrera
            If cargaMateria.consultarRegistro Then
                cargaMateria.update()
            Else
                MessageBox.Show("No existe ese registro!, verifique los datos")
            End If
            cargaMateria.dataGirdView(dgv)
        End If
    End Sub

    Private Sub btnBorrar_Click(sender As Object, e As EventArgs) Handles btnBorrar.Click
        If cmbCarrera.Text = "" Or cmbNoControl.Text = "" Or cmbMateria.Text = "" Then
            MessageBox.Show("Datos incompletos o erroneos")
        Else
            cargaMateria = New CargaMateria(cmbNoControl.Text, cargaMateria.consultaIdMateria, cargaMateria.consultaIdCarrera)
            cargaMateria.getSetNoControl = cmbNoControl.Text
            cargaMateria.getSetIdMateria = cargaMateria.consultaIdMateria
            cargaMateria.getSetIdCarrera = cargaMateria.consultaIdCarrera
            If cargaMateria.consultarRegistro() Then
                If cargaMateria.validacion() = True Then
                    MessageBox.Show("No se puede dar de baja, tiene registros en otra tabla")
                Else
                    If MessageBox.Show("¿Esta seguro?", "CONFIRMAR", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                        cargaMateria.delete()
                    End If
                End If
            Else
                MessageBox.Show("No existe ese registro!, verifique los datos")
            End If
            cargaMateria.dataGirdView(dgv)
        End If
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        cmbCarrera.Text = ""
        cmbNoControl.Text = ""
        cmbMateria.Text = ""
        cargaMateria.dataGirdView(dgv)
    End Sub

    Private Sub btnAtras_Click(sender As Object, e As EventArgs) Handles btnAtras.Click
        FormMain.Show()
        Me.Close()
    End Sub

    Private Sub FormCargaMateria_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargaMateria.dataGirdView(dgv)
        cargaMateria.comboCarrera(cmbCarrera)
        Me.ToolTip1.SetToolTip(Me.btnLimpiar, "Click para limpiar cajas de texto ...")
        Me.ToolTip1.SetToolTip(Me.btnAgregar, "Click para Guardar información en el sistema...")
        Me.ToolTip1.SetToolTip(Me.btnActualizar, "Click para Actualizar la informacion en el sistema...")
        Me.ToolTip1.SetToolTip(Me.btnBorrar, "Click para Eliminar información en el sistema...")
    End Sub

    Private Sub cmbCarrera_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCarrera.SelectedIndexChanged
        cargaMateria.comboNoControl(cmbNoControl)
        cargaMateria.comboMateria(cmbMateria)
    End Sub

    Private Sub dgv_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellClick
        cmbNoControl.Text = dgv.Rows(dgv.CurrentCellAddress.Y).Cells(0).Value
        cmbMateria.Text = dgv.Rows(dgv.CurrentCellAddress.Y).Cells(1).Value
        cmbCarrera.Text = dgv.Rows(dgv.CurrentCellAddress.Y).Cells(2).Value
    End Sub

    Private Sub cmbNoControl_TextChanged(sender As Object, e As EventArgs) Handles cmbNoControl.TextChanged
        If cmbNoControl.Text <> "" And IsNumeric(cmbNoControl.Text) Then
            cargaMateria.consultarID3()
        End If
    End Sub
End Class