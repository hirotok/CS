
Imports com.epson.pos

''' <summary>
	''' �h���A���܂邩�G���[�X�e�[�^�X���Ԃ����܂Ń��[�v
	''' </summary>
	''' <remarks></remarks>
	Private Sub loopCloseDrawer()

		AddHandler m_objAPI.StatusCallback, AddressOf PrinterStatusMonitoring

		Try
			' �v�����^�ƒʐM�J�n
			If m_objAPI.OpenMonPrinter(driver.OpenType.TYPE_PRINTER, ���V�[�g�v�����^��) = driver.ErrorCode.SUCCESS Then

				isDrawerSignal = False

				'�R�[���o�b�N�ƃC�x���g�֐��̘A���J�n
				If m_objAPI.SetStatusBack() = driver.ErrorCode.SUCCESS Then

					Do
						If isDrawerSignal Then
							m_objAPI.CancelStatusBack()
						End If
					Loop While Not isDrawerSignal

				Else
					MessageBox.Show("�R�[���o�b�N�֐��̓o�^�Ɏ��s���܂����B", "Program09", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				End If

				If Not m_objAPI.CloseMonPrinter = driver.ErrorCode.SUCCESS Then
					MessageBox.Show("�Ď��v�����^�̃N���[�Y�Ɏ��s���܂����B", "Program09", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				End If
			Else
				MessageBox.Show("�Ď��v�����^�̃I�[�v���Ɏ��s���܂����B", "Program09", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			End If

		Catch ex As Exception
			MessageBox.Show("StatusAPI�̃��[�h�Ɏ��s���܂����B", "Program09", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
		Finally
			m_objAPI.CancelStatusBack()
		End Try

	End Sub