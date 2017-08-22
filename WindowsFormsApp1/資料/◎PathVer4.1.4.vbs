Option Explicit


';;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
';�ϊ��t�@�C���̃����N��T���Č������X�g���쐬
';
';�X�V����
';2012/09/20		�ϊ��t�@�C���̃��X�g�݂̂ɑΉ�			Ver2.0.0
':2012/09/24		�G�N�Z���Ȃ��ŋN���\�ɂ���			Ver2.0.1
':2012/09/25		�R�����g�����A�N���g���b�v�ǉ�			Ver2.0.2
';2012/09/26		�ϊ����s���̃n���h���ǉ�			Ver2.0.3
';2012/10/02		�e�̌����ɑΉ��A��k�N��Tool�ɑΉ�		Ver3.0.0
':2012/10/05		���i���Ɏ擾����ꏊ���f�[�^�ϊ��ɍ��킹��	Ver3.0.1
':2012/10/11		Version�`�F�b�N�̏���������			Ver3.0.2
';2013/09/24		Analyzer�p�Ƀ��C���[�����擾����		Ver3.0.3
';2013/12/17		�f�[�^�ϊ��c�[��xxx.xls�ȂǂɑΉ�		Ver3.0.4
';2013/12/26		���i��,�������Ă����ꍇ�̑΍�			Ver3.0.5
';2013/12/27		�֐��Ł��Ȃǂ������Ă����ꍇ�������\�ɂ���	Ver3.0.6
';2014/02/14		�����Ɣg�`�̐e�q�ɑΉ�				Ver3.0.7
';2014/02/21		�Z���̒��ɉ��s�R�[�h�������Ă����疳��		Ver3.0.8
';2014/03/24		�t�@�C���̗L���`�F�b�N���ɍs���B		Ver3.0.9
';			���W���[���@�\�̓���				�@�@�V	
';2014/03/31		���W���[���t�@�C���폜�̃^�C�~���O�̕ύX	Ver3.0.10
';			�o�̓t�@�C����������̏ꍇ���l�[���ł��Ȃ��s��@�@�V
';2014/04/23		�������t������ꍇ�̓g���b�v������B		Ver3.0.11
';2014/05/16		resum�t�@�C���̓����xlsm��ǉ�			Ver3.0.12
';2014/05/26		�G�N�Z�������N�̍X�V���s���悤�Ɏd�l�ύX	Ver3.0.13
';2014/06/05		�f�[�^�ϊ��c�[���Ɠ����V�[�g�g���b�v������B	Ver3.0.14
';			�ϊ����̃G���[�𖳎����Ă����̗L����		�@�@�V
';2014/06/12		�X���b�h�����ɕύX				Ver3.1.0
';2014/06/19		�쐬��Ƀf�[�^�̐��������`�F�b�N����@�\��ǉ�	Ver3.1.1
';2014/07/08		xls����VerUp�ɔ������̂ƃ����N���ύX		Ver4.1.0
';2015/02/24		�V�[�g���͑O����v�łn�j�A���ɕ���������Ɣr��	Ver4.1.1
';2015/03/23		In						Ver4.1.2
';2016/01/29		�����N�؂�̏ꍇ�A�h���X���o��
';			�t�@�C���̒u���ꏊ���ύX���ꂽ�̂Ń����N�ύX	Ver4.1.3
';2017/07/31		workbook_open()�ضނ������Ȃ��̂�visible����	Ver4.1.4
';;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;


'====�X���b�h���@�P�`�T���炢�Őݒ肵�Ă��������B�i�b�o�t�p���[���K�v�j
Const THREAD = 5






Const ForAppending = 8
Const ForReading = 1
Const ForWriting = 2

Const XlsMacroPath = "V:\Soft\���̑�\000_�l�t�H���_\���c\�}�N��\AddInAuto���i����V4.xla"
Const strPathFile = "V:\Soft\���̑�\000_�l�t�H���_\���c\�}�N��\path.txt"
Const DataHead = "��PathV4"
Const VersionMe = "V:\Soft\���̑�\000_�l�t�H���_\���c\�}�N��\��PathVer4.1.4.vbs"
Const ThreadPath = "V:\Soft\���̑�\000_�l�t�H���_\���c\�}�N��\Lib\��PathThreadVer1.0.0.vbs"



'--�f�[�^�ϊ��c�[���ɍ��킹��
Const l_lampSetSheet = "�����v�ݒ�"
Const l_lampDataSheet = "�����v���i"
Const l_sacSheet = "�r�`�b�\"
Const l_soundDataSheet = "�T�E���h���i"
Const l_motorSheet = "���[�^�ݒ�"
Const l_motorDataSheet = "���[�^���i"
Const l_selectSheet = "�I���e�[�u�����i"
Const l_selectSheet2 = "������"
Const l_patternSheet = "�p�^�[��"
Const l_patternSheet2 = "������"
Const l_subTableSheet = "�s�a"
Const l_funcDataSheet = "�֐����i"
Const l_mainCommandSheet = "���C���R�}���h�ݒ�"
Const l_inWatchSheet = "���͊Ď��ݒ�"
Const l_serialSetSheet = "�V���A���ݒ�"
Const l_soundCHSetSheet = "�T�E���h�b�g�ݒ�"
Const l_soundPhraseMapSheet = "�T�E���h�t���[�Y�}�b�v"
Const l_soundPhraseDataSheet = "�T�E���h�t���[�Y���i"
Const l_subCommandSheet = "�T�u�R�}���h�ݒ�"
Const l_insCommandSheet = "�����R�}���h�ݒ�"
Const l_serialLampRateSheet = "�V���A�������v�P�x�ݒ�"
'-------------------------------------------------------------------
Const DataStart = "<!--Data Start-->"

Dim vrFileName				'//�Ώۃf�B���N�g������Files�I�u�W�F�N�g
Dim vrSheetName				'//�Ώۃt�@�C���̑S�V�[�g
Dim vrSubFolder				'//�q�f�B���N�g��
Dim vrSplit				'//�t���p�X��z�񉻂���
Dim vrWkBook
Dim vrLinkName


Dim objFso				'//FileSystemObject
Dim objSrc				'//FolderObject

Dim objLogStream			'//���W���[���p�̃t�@�C���X�g���[��
Dim objExcel
Dim objRange
Dim objErrStream
Dim objShell
Dim objFileNameDic			'//�Ō�̃`�F�b�N���鎫��

Dim objFile
Dim objInStr
		

Dim strStart				'//�����J�n���̃G�N�Z�����ڽ��ێ�
Dim strDate
Dim strFileName()
Dim strFileName2			'//�쐬�ς݃t�@�C���̔z��
Dim strResumePath
Dim strSheet				'//�V�[�g�g���b�v�̔z��

Dim strStreamPath			'//�匳��stream�̃p�X
Dim strStreamPathAy()			'//objStream�̃p�X Thred�������쐬
Dim strStreamPathAyPid()

Dim objStream				'//�܂Ƃ߂��t�@�C���B
Dim objStreamOpenCheck			'//�J���邩�̃`�F�b�N�p
Dim objStreamOutPutErr			'//�o�̓t�@�C�����s���X�g


Dim sh					'//Shell
Dim arg					'//�f�[�^�ϊ��c�[���̏ꏊ�i�����Ŏ擾�j

Dim blErr

Dim i,x
Dim vrDust

Dim strFileAdd()



	'//�X���b�h���̃`�F�b�N
	If THREAD > 5 Or THREAD =< 0	Then
		MsgBox "�X���b�h��������ł͂���܂���", 2, "�N���ł��܂���"
		WScript.Quit
	End If



	'//�ŏ��̏���
	strDate = Replace(date, "/", "")
	Set objFso = CreateObject("Scripting.FileSystemObject")
	Set objShell = CreateObject("Shell.Application")
	'//Version�`�F�b�N�̏���
	If objFso.FileExists(VersionMe) = False Then
		If MsgBox("�V�����o�[�W�������o�Ă���\��������܂��B" & Chr(13) & "���ɍs���܂����H", 64 + 4 ,"New Version") = 6 Then
			objShell.Explore( objFso.GetParentFolderName(VersionMe))
			Set objFso = Nothing
			Set objShell = Nothing
			Wscript.Quit
		End If
	End If
	
	
	Set objExcel = CreateObject("Excel.Application")
	Set objInStr = new CharWideNarrow	'//�g�킹�Ă��������Ă��镶���ϊ��N���X	
	strSheet = Array(l_lampSetSheet,l_lampDataSheet,l_sacSheet,l_soundDataSheet,l_motorSheet,l_motorDataSheet,l_selectSheet,l_selectSheet2,l_patternSheet,l_patternSheet2,_
			l_subTableSheet,l_funcDataSheet,l_mainCommandSheet,l_inWatchSheet,l_serialSetSheet,l_soundCHSetSheet,l_soundPhraseMapSheet,l_soundPhraseDataSheet,_
			l_subCommandSheet,l_insCommandSheet,l_serialLampRateSheet)

	objExcel.DisplayAlerts = False


	'//pid�t�@�C���̑|��
	For x = 0 To 5
		If objFso.FileExists( objFso.GetSpecialFolder(2) & "\" & "\PathLink" & "Th" & x & ".pid" ) Then
			objFso.DeleteFile objFso.GetSpecialFolder(2) & "\" & "\PathLink" & "Th" & x & ".pid" , true
		End If
	Next






If WScript.Arguments.Count = 0 Then
'//�_�u���N���b�N��
	'//�N���g���b�v��ǉ�
	IF MsgBox ("�����̃f�B���N�g���S�Č�������̂ŏ������Ԃ�������܂�", 4 + 48, "���ӎ���") = 6 Then '//vbYes
		Call Current	'//�����̋��ꏊ����ċN����
	Else
		Wscript.Quit
	End IF
Else
'//�t�@�C����n���ꂽ�ꍇ

	'//�p�X�̍\���Ŋi�[
	vrSplit = Split(WScript.Arguments(0),"\")
	arg = WScript.Arguments(0)

	'//xls��n���ꂽ�Ƃ��̓f�[�^�ϊ��c�[�����ۂ��𔻒肷��
	Select Case objFso.GetExtensionName(vrSplit(Ubound(vrsplit)))
		Case "xls","xlsm"
			Call DataConvert	'//�f�[�^�ϊ��t�@�C������e�L�X�g���쐬
	
		Case "txt"
			Call NSSsearch		'//�e�L�X�g���畔�i�������Ăяo��
			
		Case "resume"
			Call psResume
		
		Case Else
			WScript.Echo "�f�[�^�ϊ��c�[��.xls�������͍쐬���ꂽ�e�L�X�g��n���Ă�������"
			Call ErrorException			
	End Select

End If



Sub Current()
'//�ċA�������s���S�����z���o��


	'//Ver3.0.11�̓���l�[���̃g���b�v �y�͂��z��6�@�y�������z��7
	If objFso.FileExists( objFso.GetFolder(".") & "\PathAll" & strDate & "V4.txt" ) Then
		If MsgBox("����̓��t�����݂��܂�" & Chr(13) & "�����𑱂��܂����H" , 32+4 , "����!!") = 7 Then
			'//�������I������
			Call ErrorException
		End If
	End If



	strStreamPath = objFso.GetFolder(".") & "\PathAll" & strDate & "V4.txt"
	Set objStream = objFso.OpenTextFile(strStreamPath, ForWriting, True)
	objStream.WriteLine Date		'//�Œ�f�[�^�̏o��
	objStream.WriteLine DataHead
	objStream.WriteLine "�p�X" & Chr(9) & "�V�[�g" & Chr(9) & "�A�h���X" & Chr(9) & "���i��" & Chr(9) & "�q���" & Chr(9) & "������" & Chr(9) & "�g���K�[" & Chr(9) & "���C���["
	ReDim strFileName(0)
	psLoop2 objFso.GetFolder(".")

	'//�Ō�Ɏ擾�����t�@�C�����ƁA���ۂɓf���o�����t�@�C�����̐����`�F�b�N���s���B(V4.1.1)
	strFileName2 = strFileName

		
	'//�f�[�^�ϊ����r���Ŏ��s���Ă����W���[���\�ɂ����iV3.0.9�j
	strResumePath = objFso.GetFolder(".") & "\PathLinkLog" & strDate & "V41.resume"
	Set objLogStream = objFso.OpenTextFile(strResumePath, ForWriting, True)
	objLogStream.WriteLine Date		'//�Œ�f�[�^�̏o��
	objLogStream.WriteLine DataHead & ".1"
	objLogStream.WriteLine strStreamPath
	objLogStream.WriteLine objFso.GetFolder(".")	'//���s�p�X
	objLogStream.WriteLine "�p�X" & Chr(9) & "�t�@�C���I�[�v��" & Chr(9) &"�J�n����" & Chr(9) & "�I������" & Chr(9) & "�t�@�C���T�C�Y"
	objLogStream.WriteLine DataStart
	objLogStream.Close				'//��U����
	'//�t�@�C���o�̓��W���[��
	Call DataOutPut(THREAD)
	
End Sub



Sub psLoop2(ByVal src)




	Set objSrc = objFso.GetFolder(src)
	For Each vrFileName In objSrc.Files
		If objFso.GetExtensionName(vrFileName) = "xlsx" or  objFso.GetExtensionName(vrFileName) = "xls"  Then
			ReDim Preserve strFileName(UBound(strFileName)+1)
			Set objFile = objFso.GetFile(vrFileName)
			strFileName(Ubound(strFileName)-1) = objFile.path
		End If
	Next
	
	'//�ċA����
	For Each vrSubFolder In objSrc.SubFolders
		psLoop2 vrSubFolder
	Next

End Sub





Sub DataConvert()

Dim blSheet



	'//�ϊ��t�@�C����n���ꂽ�Ƃ��ȊO�͏I��
	If Not InStrWord( vrSplit(Ubound(vrSplit)) ,"�f�[�^�ϊ��c�[��" , True )  Then	'//�����܂ݔ���
		WScript.Echo "�f�[�^�ϊ��c�[��.xls��n���Ă�������"
		Call ErrorException
	End If
	
	
	'//�Y���V�[�g����������Ȃ�������I��
	Set vrWkBook = objExcel.Workbooks.Open (WScript.Arguments(0),1 , True)
	For Each vrSheetName In vrWkBook.Sheets
		If vrSheetName.Name = "�ϊ��ݒ�" Then
			blSheet = True
		End If
	Next

	If blSheet = False Then
		WScript.Echo "�V�[�g�y�ϊ��ݒ�z��������܂���"
		Call ErrorException
	End If
	Set objRange = vrWkBook.Sheets("�ϊ��ݒ�").Cells.Find("��",,,1,,,0)	'//�V�[�g���Œ�
	
	

	ReDim strFileName(0)
	'//�f�o�b�O
	ReDim strFileAdd(0)
	If Not objRange Is Nothing Then
		strStart = objRange.ADDRESS
		i = 1
		Do
			Do While objRange.Offset(i,1).Value = "�ϊ��t�@�C�����i�t���p�X�j"	'//���̃L�[�ŒT��
				If objRange.Offset(i,2).value <> "" Then
					ReDim Preserve strFileName(Ubound(strFileName)+1)
					ReDim Preserve strFileAdd(Ubound(strFileAdd)+1)
					strFileName(Ubound(strFileName)-1) = objRange.Offset(i,2).value
				'//	�f�o�b�O
					strFileAdd(Ubound(strFileAdd)-1) = objRange.Offset(i,2).address
				End If
				i = i + 1
			Loop
			Set objRange = vrWkBook.Sheets("�ϊ��ݒ�").Cells.FindNext(objRange)
			i = 1
		Loop While Not objRange Is Nothing And objRange.ADDRESS <> strStart
	End If
	vrWkBook.Saved = True
	vrWkBook.Close	


	'//�t�@�C���̗L�����`�F�b�N�݂̂��ɍs��(V3.0.9)
	'//3.0.8�܂ł͓����ɍs���Ă����̂œr�������ŏI������B
	For i = 0 To Ubound(strFileName)-1
		If objFso.FileExists(strFileName(i)) = False Then
			'//�t�@�C����������Ȃ������ꍇ�̓����N������ł��邱�Ƃ�ʒm����
			If blErr = False Then
				Set objErrStream = objFso.OpenTextFile(objFso.GetParentFolderName(arg) & "\PathLinkErr" & strDate & "V4.txt", ForWriting, True)
				blErr = True
			End If
			objErrStream.Write strFileName(i)
			objErrStream.WriteLine strFileAdd(i)
		End If
	Next
	
	
	If blErr Then
		Set objErrStream = Nothing
		set objExcel = Nothing
		set objFso = Nothing
		MsgBox "�ϊ��t�@�C���̒��Ɍ�����Ȃ������N������܂����B" & Chr(13) & _
			"�G���[���O��f���o���܂����̂ł��m�F��������" , 48 , "����!!"
		Wscript.Quit
	End If


	'//Ver3.0.11�̓���l�[���̃g���b�v �y�͂��z��6�@�y�������z��7
	If objFso.FileExists( objFso.GetParentFolderName(arg) & "\PathLink" & strDate & "V4.txt") Then
		If MsgBox("����̓��t�����݂��܂�" & Chr(13) & "�����𑱂��܂����H" , 32+4 , "����!!") = 7 Then
			'//�������I������
			Call ErrorException
		End If
	End If

	'//�Ō�Ɏ擾�����t�@�C�����ƁA���ۂɓf���o�����t�@�C�����̐����`�F�b�N���s���B(V3.1.1)
	strFileName2 = strFileName	
	

	'//�f�[�^�ϊ����r���Ŏ��s���Ă����W���[���\�ɂ����iV3.0.9�j
	strResumePath = objFso.GetParentFolderName(arg) & "\PathLinkLog" & strDate & "V41.resume"
	Set objLogStream = objFso.OpenTextFile(strResumePath, ForWriting, True)	
	objLogStream.WriteLine Date		'//�Œ�f�[�^�̏o��
	objLogStream.WriteLine DataHead & ".1"

	'//Thread�p�ɃI�u�W�F�N�g�̍쐬
	ReDim strStreamPathAy(THREAD-1)
	ReDim strStreamPathAyPid(THREAD-1)
	For x = 0 To THREAD-1
		'//���ɑ��݂��Ă���ꍇ�͍폜
		strStreamPathAy(x) = objFso.GetParentFolderName(arg) & "\PathLink" & strDate & ".Th" & x
		If objFso.FileExists( strStreamPathAy(x) ) Then
			objFso.DeleteFile  strStreamPathAy(x) , true
		End If
		objLogStream.WriteLine strStreamPathAy(x)
		strStreamPathAyPid(x) = objFso.GetSpecialFolder(2) & "\" & "\PathLink" & "Th" & x & ".pid"
	Next
	objLogStream.WriteLine ""		'//��s������B
	objLogStream.WriteLine arg		'//�f�[�^�ϊ�Tool
	objLogStream.WriteLine "�p�X" & Chr(9) & "�t�@�C���I�[�v��" & Chr(9) &"�J�n����" & Chr(9) & "�I������" & Chr(9) & "�t�@�C���T�C�Y"
	objLogStream.WriteLine DataStart
	objLogStream.Close				'//��U����
	
	Call DataOutPut(THREAD)

End Sub

Sub DataOutPut(ByVal argTHREAD)
'//������s���ƃ��W���[�����̃X���b�h�������킹��׈�����ǉ�

Const Dlm = "@.@"	'//split�̃f���~�b�g
Const Dlm2 = "*.*"	'//�X�y�[�X�̃f���~�b�g

Dim objExec()	'//���s�I�u�W�F�N�g
Dim objPidStream
Dim args	'//�t�@�C�����ȂǂɃX�y�[�X�����L���Ă������Ƃ��Ďg����悤�ɂ���B

'//�������珈���𕪊����ċ��ʉ�����B
	Set sh = CreateObject("WScript.Shell")
	ReDim objExec(0)
	For x = 0 To argTHREAD-1
		ReDim Preserve objExec(x)
	Next
	
	
	'//�S�Ċ������킩��悤�Ƀ_�~�[�v���O�������܂��͑��点��B
	For x = 0 To argTHREAD-1
		Set objExec(x) = sh.Exec("wscript.exe " & ThreadPath & " " & "DMY")
	Next
	

	'//�P�{�ڂ͎蓮�ŋN��������B
	i = 0
	For x = 0 To argTHREAD-1
		If i >= UBound(strFileName) Then
			Exit For
		End If
		'//Thread����PID���L�^����B
		args = strStreamPathAy(x) & Dlm & strFileName(i) & Dlm & strResumePath & Dlm & strStreamPathAyPid(x)
		args = RePlace(args," ",Dlm2)	'//�X�y�[�X�𕶎��ɕς��āA������n������Ŗ߂��B
		Set objPidStream  = objFso.OpenTextFile( strStreamPathAyPid(x) , ForWriting, true)
		Set objExec(x) = sh.Exec("wscript.exe " & ThreadPath  & " " & args)
		objPidStream.Write objExec(x).ProcessID			
		objPidStream.Close
		Set objPidStream = Nothing
		i = i + 1
	Next

	'//�Q�{�ڂ����status���m�F����pid���Ǘ�����B
	'//�����P�F�o�̓t�@�C���p�X�A�@�����Q�F�����t�@�C���A�@�����R�F���W���[���p�X�A�@�����S�FPID�p�X
	Do While true
		If i => UBound(strFileName) Then
			Exit Do
		End If
		For x = 0 To argTHREAD-1
			If objExec(x).status = 1 Then
				args = strStreamPathAy(x) & Dlm & strFileName(i) & Dlm & strResumePath & Dlm & strStreamPathAyPid(x)
				args = RePlace(args," ",Dlm2)	'//�X�y�[�X�𕶎��ɕς��āA������n������Ŗ߂��B
				Set objPidStream  = objFso.OpenTextFile( strStreamPathAyPid(x) , ForWriting, true)
				Set objExec(x) = sh.Exec("wscript.exe " & ThreadPath & " " & args)				
				objPidStream.Write objExec(x).ProcessID			
				objPidStream.Close
				Set objPidStream = Nothing
				i = i + 1
				If i >= UBound(strFileName) Then
					Exit For
				End If
				Wscript.Sleep(300)	'//���\�[�X��Ԃ��B
			End If
		Next
	Loop


	'//�S�Ă�status�������ɂȂ�܂őҋ@
	For x = 0 To argTHREAD-1
		Do while objExec(x).status = 0
			Wscript.Sleep(10)
		Loop
	Next
	




	'//�S�Ċ���������ɕύX����B(Ver3.1.0)
	'//�G���[����Ȃ��ꍇ��Link�t�@�C�����쐬����悤�Ƀ^�C�~���O��ύX(V3.0.10)
	strStreamPath = objFso.GetParentFolderName(arg) & "\PathLink" & strDate & "V4.txt"
	Set objStream = objFso.OpenTextFile(strStreamPath, ForWriting, True)
	objStream.WriteLine Date		'//�Œ�f�[�^�̏o��
	objStream.WriteLine DataHead
	objStream.WriteLine "�p�X" & Chr(9) & "�V�[�g" & Chr(9) & "�A�h���X" & Chr(9) & "���i��" & Chr(9) & "�q���" & Chr(9) & "������" & Chr(9) & "�g���K�[" & Chr(9) & "���C���["

	'//�e�o�̓t�@�C�����P�ɂ܂Ƃ߂�B
	For x = 0 To argTHREAD-1
		Set objStreamOpenCheck = objFso.OpenTextFile(strStreamPathAy(x) , ForReading, False)
		objStream.Write objStreamOpenCheck.ReadAll
		objStreamOpenCheck.Close
		objFso.DeleteFile strStreamPathAy(x) ,true
	Next
	objStream.Close
	Wscript.Sleep(50)
	
	
	
	'//�S�Ċ����������_�Ńt�@�C���̐����`�F�b�N���s���iVer3.1.1�j
	'//�쐬�������W���[���p�X����z����쐬����B


	Set objFileNameDic = CreateObject("Scripting.Dictionary")
	Set objLogStream = objFso.OpenTextFile(strResumePath, ForReading,False)
	
	'// <!--Data Start>�܂ŃJ�b�g
	Do while true
		vrDust = objLogStream.ReadLine
		If vrDust = DataStart Then
			Exit Do
		End If
	Loop
	
	
	'//log�o�̓t�@�C���������ɓo�^
	Do Until objLogStream.AtEndOfLine
		vrSplit = Split(objLogStream.ReadLine, Chr(9))
		objFileNameDic.Add vrSplit(0),vrSplit(0)
	Loop
	
	'//strFileName2�Ɣ�r���A�f�[�^�ϊ��c�[���L�ڂ̃t�@�C�������o�͂���Ă��Ȃ��ꍇ��log�t�@�C���ɏo�͂���B
	x = 0
	Do Until x = Ubound(strFileName2)-1
		If Not objFileNameDic.Exists( strFileName2(x) ) Then
			If Not objFso.FileExists(strStreamPath & ".Err") Then
				Set objStreamOutPutErr = objFso.OpenTextFile( strStreamPath & ".Err",ForWriting,True)
				objStreamOutPutErr.WriteLine	Date
				objStreamOutPutErr.WriteLine	DataHead & ".1"
			End If
			objStreamOutPutErr.WriteLine strFileName2(x)
		End If
		x = x + 1
	Loop
	
	If objFso.FileExists(strStreamPath & ".Err") Then
		objStreamOutPutErr.Close
		msgbox "�o�͂���Ă��Ȃ��t�@�C����������܂����B" & Chr(13) & strStreamPath & ".Err�ł��m�F��������"
	End If
	
	msgbox  "�S�����N����"
	
	set objStreamOutPutErr = Nothing
	set objExcel = Nothing
	set objStream= Nothing
	set objLogStream = Nothing
	set objFso = Nothing


End Sub



Function LF_Del(Byval inStr)
'//�n���ꂽ�f�[�^����LF�f�[�^( chr(10)�j�𔲂��ĕԂ�


	LF_Del = Replace(inStr, chr(10), "")



End Function




Sub psResume()
'//���W���[���t�@�C����n���ꂽ���̏������s���B


Dim oldStream
Dim vrDust
Dim blSheet


Dim splPathLink		'//�p�X�����N�t�@�C���̃X�v���b�g�f�[�^
Dim splResume		'//���W���[���t�@�C���̃X�v���b�g�f�[�^

Dim strPathLinkFile()	'//Version4����z��ŏ���
Dim strPathLinkCheck

Dim strRunPath		'//���s�p�X
Dim x,y

Dim objDicResumeList	'//���Ȃ��̎���

	ReDim strPathLinkFile(0)

	'//�����̍쐬
	Set objDicResumeList = CreateObject("Scripting.Dictionary")
	
	'//���W���[���t�@�C���̓ǂݎ�胂�[�h�ŊJ��
	strResumePath = WScript.Arguments(0)
	Set objLogStream = objFso.OpenTextFile(strResumePath, ForReading, True)
	vrDust = objLogStream.ReadLine	'//���t
	If objLogStream.ReadLine <> DataHead & ".1" Then	'//�o�[�W�����`�F�b�N
		MsgBox "�o�[�W�������قȂ�܂��B" & Chr(13) & _
			"�{�o�[�W������:Ver3.1�n�ɂȂ�܂��B" , 48 , "����!!"	
		objLogStream.close
		set objLogStream = Nothing
		Wscript.Quit
	End If
	
	'//PathLink�̃t�@�C���p�X
	Do While True
		strPathLinkCheck = objLogStream.ReadLine
		If strPathLinkCheck = "" Then
			Exit Do
		End If
		ReDim Preserve strPathLinkFile(Ubound(strPathLinkFile)+1)
		strPathLinkFile(UBound(strPathLinkFile)-1) = strPathLinkCheck
	Loop
	
	
	strRunPath = objLogStream.ReadLine		'//�t�@�C���Ȃ̂��A���s�p�X�Ȃ̂��̔��肪�K�v
	vrDust = objLogStream.ReadLine			'//���W���[���t�@�C���̍���
	

	'//���W���[���t�@�C���̃��[�h�ʒu���Ō�ɂn�j���o���ʒu�܂ňړ�
	Do Until objLogStream.AtEndOfLine
		vrDust = objLogStream.ReadLine
		splResume = Split(vrDust,Chr(9))
		objDicResumeList.Add splResume(0),splResume(0)	'//�����t�@�C�����������ɓo�^
	Loop

	'//Thread�t�@�C�����J���A�����t�@�C�����ƈ�v�����ꍇ��_new�ɏ�����
	For x = 0 To UBound(strPathLinkFile) -1
		Set oldStream = objFso.OpenTextFile(strPathLinkFile(x), ForReading,true)
		Set objStream = objFso.OpenTextFile(strPathLinkFile(x) & "_new" , ForWriting, True)
		Do Until oldStream.AtEndOfLine
			vrDust = oldStream.ReadLine 
			splPathLink = Split(vrDust,Chr(9))	'//���̃t�@�C�������擾�j
			If objDicResumeList.Exists( splPathLink(0)) = True Then
				objStream.WriteLine vrDust
			End If
		Loop
		oldStream.Close
		objStream.Close	
	
	
	Next
	
	Set oldStream = Nothing


	For x = 0 To UBound(strPathLinkFile)-1
		objFso.CopyFile strPathLinkFile(x) & "_new", strPathLinkFile(x), True  '//OverWrite
		objFso.DeleteFile strPathLinkFile(x) & "_new" ,True 			 '//�����폜
	Next
			
	
	
	ReDim strFileName(0)
	If objFso.GetExtensionName(strRunPath) = "xls" or objFso.GetExtensionName(strRunPath) = "xlsx"  or objFso.GetExtensionName(strRunPath) = "xlsm"Then
		'//�Y���V�[�g����������Ȃ�������I��
		Set vrWkBook = objExcel.Workbooks.Open (strRunPath,3 , True)
		For Each vrSheetName In vrWkBook.Sheets
			If vrSheetName.Name = "�ϊ��ݒ�" Then
				blSheet = True
			End If
		Next

		If blSheet = False Then
			WScript.Echo "�V�[�g�y�ϊ��ݒ�z��������܂���"
			Call ErrorException
		End If
		Set objRange = vrWkBook.Sheets("�ϊ��ݒ�").Cells.Find("��",,,1,,,0)	'//�V�[�g���Œ�

		If Not objRange Is Nothing Then
			strStart = objRange.ADDRESS
			i = 1
			Do
				Do While objRange.Offset(i,1).Value = "�ϊ��t�@�C�����i�t���p�X�j"	'//���̃L�[�ŒT��
					If objRange.Offset(i,2).value <> "" Then
						ReDim Preserve strFileName(Ubound(strFileName)+1)
						strFileName(Ubound(strFileName)-1) = objRange.Offset(i,2).value
					End If
					i = i + 1
				Loop
				Set objRange = vrWkBook.Sheets("�ϊ��ݒ�").Cells.FindNext(objRange)
				i = 1
			Loop While Not objRange Is Nothing And objRange.ADDRESS <> strStart
		End If
		vrWkBook.Saved = True
		vrWkBook.Close	

			
	Else
		psLoop2 objFso.GetFolder(strRunPath)
	End If
		
	'//strFileName�̔z����쐬���āA�������Ă�����̂�r������B
	strFileName2 = strFileName
	Redim strFileName(0)	'//��U�N���A
	
	'//�����ɓo�^�̖�����̂ݍĔz�u
	For y = 0 To Ubound(strFileName2) -1
		If objDicResumeList.Exists(strFileName2(y)) = False Then
			Redim Preserve strFileName(UBound(strFileName)+1)
			strFileName(Ubound(strFileName)-1) = strFileName2(y)
			objDicResumeList.Add strFileName2(y), strFileName2(y)
		End If
	Next
	Set objDicResumeList = Nothing
	


	'//���W���[���t�@�C���Adat�t�@�C���𖖔�����ǋL���[�h�ŊJ��
	ReDim strStreamPathAy(UBound(strPathLinkFile)-1)
	ReDim strStreamPathAyPid(UBound(strPathLinkFile)-1)
	
	For x = 0 To UBound(strPathLinkFile)-1
		strStreamPathAy(x) = objFso.GetParentFolderName(arg) & "\PathLink" & strDate & ".Th" & x
		strStreamPathAyPid(x) = objFso.GetSpecialFolder(2) & "\" & "\PathLink" & "Th" & x & ".pid"
	Next	
	

	'//���W���[���J�n
	Call DataOutPut(UBound(strPathLinkFile))

	

End Sub





Function InStrSheetName( ByVal sheetName )
'//�����P�F�V�[�g��
'//�@�\�F�f�[�^�ϊ��c�[���Ɠ����V�[�g�g���b�v�łn�j��������n�j


Dim i
	For i = 0 To UBound( strSheet)
		If InStrWord( sheetName , strSheet(i) , False ) Then	'//�O����v�̂�
			InStrSheetName = True
			Exit Function
		End If
	Next
	InStrSheetName = False

End Function






Function InStrWord(ByVal strString , ByVal strPattern , ByVal blLike )
'//�����P�F�����Ώۂ̕�����
'//�����Q�F����������������
'//�����R�FTrue�ˊ܂ݔ���iLike)�@False�ˑO����v����
'//�ߒl�FTrue�˂���܂����B�@False�˂Ȃ�
Dim objReg


Set objReg = CreateObject("VBScript.RegExp")


	If blLike = True Then
		objReg.Pattern = "(" &  strPattern & ")"
	else
		objReg.Pattern = "^" & strPattern	'//�p�^�[�����܂܂�Ă��邩�̔��� Ver4.1.1�ˑO����v�֕ύX
	End If


	objReg.IgnoreCase = True
	If objReg.Test( objInStr.ToWideAll( Ucase(strString),false ) ) Then
		InStrWord = True
	Else
		InStrWord = False
	End IF
Set objReg = Nothing

End Function





Sub NSSsearch()
'//�G�N�Z���I�u�W�F�N�g���쐬���Ă�������}�N�����Ăяo��

Dim objSrcPathStream
Dim objWord
Dim objDoc
dim iCount

	Do Until objFso.FileExists(strPathFile) = False
		iCount = iCount + 1
		If iCount > 1000 Then
			objFso.DeleteFile strPathFile, True  '//�����폜
		End If
	Loop

	
	Set objSrcPathStream = objFso.OpenTextFile(strPathFile,ForWriting,True)
	objSrcPathStream.WriteLine WScript.Arguments(0)
	objSrcPathStream.Close
	Set objSrcPathStream = Nothing
	
	Set objExcel = CreateObject("Excel.Application")
	

	With objExcel
		.Visible = true
		.Visible = false
		.Workbooks.Open XlsMacroPath,3,True
	End With
	
End Sub





Sub ErrorException()
'//�r���ŉ������������@�܂Ƃ߂ăI�u�W�F�N�g�̊J��

	objExcel.Quit
	Set objExcel = Nothing
	Set objFso = Nothing
	Wscript.Quit

End Sub






Class CharWideNarrow
'//�@�悻����E���Ă������C�u����
'// i�@�̐錾�����������̂ŃO���[�o���̉e����^���Ă���(-"-)

	Dim  widedicASCII, widedicANK, narrowdicASCII, narrowdicANK
	Dim x ,i
	
	
	Private Sub Class_Initialize()
		'�R���X�g���N�^
		Set widedicASCII   = CreateObject("Scripting.Dictionary")
		Set widedicANK     = CreateObject("Scripting.Dictionary")
		Set narrowdicASCII = CreateObject("Scripting.Dictionary")
		Set narrowdicANK   = CreateObject("Scripting.Dictionary")

		With narrowdicANK
			'�\�̍쐬
			.Add "�K", "�"
			.Add "�J", "�"
			.Add "��", "�"
			.Add "��", "�"
			.Add "��", "��"
			.Add "��", "�"
			.Add "��", "�"
			.Add "��", "��"
			.Add "��", "��"
			.Add "��", "�"
			.Add "��", "�"
			.Add "��", "�"
			.Add "��", "�"
			.Add "��", "�"
			.Add "��", "�"
			.Add "��", "�"
			.Add "��", "�"
			.Add "��", "�"
			.Add "��", "�"
			.Add "��", "�"
			.Add "��", "�"
			.Add "��", "�"
			.Add "��", "�"
			.Add "��", "�"
			.Add "��", "�"
			.Add "�~", "�"
			.Add "�}", "�"
			.Add "�|", "��"
			.Add "�{", "��"
			.Add "�z", "�"
			.Add "�y", "��"
			.Add "�x", "��"
			.Add "�w", "�"
			.Add "�v", "��"
			.Add "�u", "��"
			.Add "�t", "�"
			.Add "�s", "��"
			.Add "�r", "��"
			.Add "�q", "�"
			.Add "�p", "��"
			.Add "�o", "��"
			.Add "�n", "�"
			.Add "�m", "�"
			.Add "�l", "�"
			.Add "�k", "�"
			.Add "�j", "�"
			.Add "�i", "�"
			.Add "�h", "��"
			.Add "�g", "�"
			.Add "�f", "��"
			.Add "�e", "�"
			.Add "�d", "��"
			.Add "�c", "�"
			.Add "�b", "�"
			.Add "�a", "��"
			.Add "�`", "�"
			.Add "�_", "��"
			.Add "�^", "�"
			.Add "�]", "��"
			.Add "�\", "�"
			.Add "�[", "��"
			.Add "�Z", "�"
			.Add "�Y", "��"
			.Add "�X", "�"
			.Add "�W", "��"
			.Add "�V", "�"
			.Add "�U", "��"
			.Add "�T", "�"
			.Add "�S", "��"
			.Add "�R", "�"
			.Add "�Q", "��"
			.Add "�P", "�"
			.Add "�O", "��"
			.Add "�N", "�"
			.Add "�M", "��"
			.Add "�L", "�"
			.Add "�K", "��"
			.Add "�J", "�"
			.Add "�I", "�"
			.Add "�H", "�"
			.Add "�G", "�"
			.Add "�F", "�"
			.Add "�E", "�"
			.Add "�D", "�"
			.Add "�C", "�"
			.Add "�B", "�"
			.Add "�A", "�"
			.Add "�@", "�"
			.Add "�[", "�"
			.Add "�E", "�"
			.Add "�A", "�"
			.Add "�v", "�"
			.Add "�u", "�"
			.Add "�B", "�"

			'�t�����\�̍쐬
			For Each x In .Keys
				If widedicANK.Exists( .Item(x) ) = False Then
					widedicANK.Add .Item(x), x
				End If
			Next
		End With

		With narrowdicASCII
			'�\�̍쐬
			.Add "�`", "~"
			.Add "�p", "}"
			.Add "�b", "|"
			.Add "�o", "{"
			.Add "��", "z"
			.Add "��", "y"
			.Add "��", "x"
			.Add "��", "w"
			.Add "��", "v"
			.Add "��", "u"
			.Add "��", "t"
			.Add "��", "s"
			.Add "��", "r"
			.Add "��", "q"
			.Add "��", "p"
			.Add "��", "o"
			.Add "��", "n"
			.Add "��", "m"
			.Add "��", "l"
			.Add "��", "k"
			.Add "��", "j"
			.Add "��", "i"
			.Add "��", "h"
			.Add "��", "g"
			.Add "��", "f"
			.Add "��", "e"
			.Add "��", "d"
			.Add "��", "c"
			.Add "��", "b"
			.Add "��", "a"
			.Add "�e", "`"
			.Add "�Q", "_"
			.Add "�O", "^"
			.Add "�n", "]"
			.Add "��", "\"
			.Add "�m", "["
			.Add "�y", "Z"
			.Add "�x", "Y"
			.Add "�w", "X"
			.Add "�v", "W"
			.Add "�u", "V"
			.Add "�t", "U"
			.Add "�s", "T"
			.Add "�r", "S"
			.Add "�q", "R"
			.Add "�p", "Q"
			.Add "�o", "P"
			.Add "�n", "O"
			.Add "�m", "N"
			.Add "�l", "M"
			.Add "�k", "L"
			.Add "�j", "K"
			.Add "�i", "J"
			.Add "�h", "I"
			.Add "�g", "H"
			.Add "�f", "G"
			.Add "�e", "F"
			.Add "�d", "E"
			.Add "�c", "D"
			.Add "�b", "C"
			.Add "�a", "B"
			.Add "�`", "A"
			.Add "��", "@"
			.Add "�H", "?"
			.Add "��", ">"
			.Add "��", "="
			.Add "��", "<"
			.Add "�G", ";"
			.Add "�F", ":"
			.Add "�X", "9"
			.Add "�W", "8"
			.Add "�V", "7"
			.Add "�U", "6"
			.Add "�T", "5"
			.Add "�S", "4"
			.Add "�R", "3"
			.Add "�Q", "2"
			.Add "�P", "1"
			.Add "�O", "0"
			.Add "�^", "/"
			.Add "�D", "."
			.Add "�|", "-"
			.Add "�C", ","
			.Add "�{", "+"
			.Add "��", "*"
			.Add "�j", ")"
			.Add "�i", "("
			.Add "�f", "'"
			.Add "��", "&"
			.Add "��", "%"
			.Add "��", "$"
			.Add "��", "#"
			.Add "�h", """"
			.Add "�I", "!"
			.Add "�@", " "

			'�t�����\�̍쐬
			For Each x In .Keys
				 widedicASCII.Add .Item(x), x
			Next
		End With
	End Sub

	Private Sub Class_Terminated()
		'�f�X�g���N�^
		Set widedicASCII   = Nothing
		Set widedicANK     = Nothing
		Set narrowdicASCII = Nothing
		Set narrowdicANK   = Nothing
	End Sub

	Function ToNarrowAll( byref str )
		Dim rtn, max_, char_, trns_
		rtn = ""
		max_ = len( str )
		For i = 1 to max_
			char_ = Mid( str,i,1 )
			If narrowdicASCII.Exists( char_ ) Then
				trns_ = narrowdicASCII.Item( char_ )
			Else
				If narrowdicANK.Exists( char_ ) Then
					trns_ = narrowdicANK.Item( char_ )
				Else
					trns_ = char_
				End If
			End If
			rtn = rtn & trns_
		Next 
		ToNarrowAll = rtn
	End Function

	Function ToNarrowASCII( byref str )
		Dim rtn, max_, char_, trns_
		rtn = ""
		max_ = len( str )
		For i = 1 to max_
			char_ = Mid( str,i,1 )
			If narrowdicASCII.Exists( char_ ) Then
				trns_ = narrowdicASCII.Item( char_ )
			Else
				trns_ = char_
			End If
			rtn = rtn & trns_
		Next 
		ToNarrowASCII = rtn
	End Function

	Function ToNarrowKANA( byref str )
		Dim rtn, max_, char_, trns_
		rtn = ""
		max_ = len( str )
		For i = 1 to max_
			char_ = Mid( str,i,1 )
			If narrowdicANK.Exists( char_ ) Then
				trns_ = narrowdicANK.Item( char_ )
			Else
				trns_ = char_
			End If
			rtn = rtn & trns_
		Next 
		ToNarrowKANA = rtn
	End Function

	Function ToWideAll( byref str , byval option_ )
	'//�g�킹�Ă�����Ă����ĂȂ񂾂���
	'//�����̃I�v�V�����̐������炢�����Ƃ��ė~����
	
	
		Dim rtn, max_, char_, trns_, next_c, flg_nextc_trns
		rtn = ""
		max_ = len( str ) - 1
		flg_nextc_trns = False
		For i = 1 to max_
			If flg_nextc_trns = True Then
				flg_nextc_trns = False
			Else
				char_  = Mid( str, i   , 1 )
				next_c = Mid( str, i+1 , 1 )

				Select Case next_c
				Case "�" , "�" 
					If widedicANK.Exists( char_ & next_c ) Then
						char_ = char_ & next_c
						flg_nextc_trns = True
					End If				
				Case "�" , "�"
					If Option_ Then
						If widedicANK.Exists( char_ & next_c ) Then
							char_ = char_ & next_c
							flg_nextc_trns = True
						End If
					End If				
				Case Else
				End Select

				If widedicASCII.Exists( char_ ) Then
					trns_ = widedicASCII.Item( char_ )
				Else
					If widedicANK.Exists( char_ ) Then
						trns_ = widedicANK.Item( char_ )
					Else
						trns_ = char_
					End If
				End If
				rtn = rtn & trns_
			End If
		Next

		If flg_nextc_trns = False Then
			char_  = Right( str, 1 )
			If widedicASCII.Exists( char_ ) Then
				trns_ = widedicASCII.Item( char_ )
			Else
				If widedicANK.Exists( char_ ) Then
					trns_ = widedicANK.Item( char_ )
				Else
					trns_ = char_
				End If
			End If
			rtn = rtn & trns_
		End If

		ToWideAll = rtn
	End Function

	Function ToWideASCII( byref str )
		Dim rtn, max_, char_, trns_
		rtn = ""
		max_ = len( str )
		For i = 1 to max_
			char_  = Mid( str,i, 1 )
			If widedicASCII.Exists( char_ ) Then
				trns_ = widedicASCII.Item( char_ )
			Else
				trns_ = char_
			End If
			rtn = rtn & trns_
		Next

		ToWideASCII = rtn
	End Function

	Function ToWideKANA( byref str , byval option_ )
		Dim rtn, max_, char_, trns_, next_c, flg_nextc_trns
		rtn = ""
		max_ = len( str ) - 1
		flg_nextc_trns = False
		For i = 1 to max_
			If flg_nextc_trns = True Then
				flg_nextc_trns = False
			Else
				char_  = Mid( str, i   , 1 )
				next_c = Mid( str, i+1 , 1 )

				Select Case next_c
				Case "�" , "�"
					If widedicANK.Exists( char_ & next_c ) Then
						char_ = char_ & next_c
						flg_nextc_trns = True
					End If				
				Case "�" , "�"
					If option_ Then
						If widedicANK.Exists( char_ & next_c ) Then
							char_ = char_ & next_c
							flg_nextc_trns = True
						End If
					End If				
				Case Else
				End Select

				If widedicANK.Exists( char_ ) Then
					trns_ = widedicANK.Item( char_ )
				Else
					trns_ = char_
				End If
				rtn = rtn & trns_
			End If
		Next

		If flg_nextc_trns = False Then
			char_  = Right( str, 1 )
			If widedicANK.Exists( char_ ) Then
				trns_ = widedicANK.Item( char_ )
			Else
				trns_ = char_
			End If
			rtn = rtn & trns_
		End If

		ToWideKANA = rtn
	End Function
End Class

