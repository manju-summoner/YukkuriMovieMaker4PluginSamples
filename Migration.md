# �������MovieMaker v4.34.x.x�ȑO�ɍ쐬���ꂽ�v���W�F�N�g�t�@�C���̈ڍs�菇

## �w�i
�������MovieMaker v4.35.0.0��.NET9�Ɉڍs�������֌W�ŁAv4.34.x.x�ȑO�ɍ쐬���ꂽ�v���W�F�N�g�t�@�C����v4.35.0.0�ȍ~�Ńr���h����ƁA�ȉ��̂悤�ȃG���[���\������r���h�ł��Ȃ��Ȃ��Ă��܂��B
```
CS1705 �A�Z���u��'YukkuriMovieMaker.Plugin' (...)�́A�Q�Ƃ���Ă���A�Z���u�� '...'���V�����o�[�W�������܂�'...'���g�p���܂�
MSB3277 "..." �̈قȂ�o�[�W�����ԂŁA�����ł��Ȃ�������������܂����B
```
�ȑO�Ƀr���h����dll�͈�������YMM v4.35.0.0�ȍ~�ł��g�p�ł��܂����A�ăr���h���s���ꍇ�̓v���W�F�N�g�t�@�C����YMM v4.35�ȍ~�p�ɕҏW����K�v������܂��B

## �ڍs�菇
�ȉ��̎菇�����s���A�v���W�F�N�g�t�@�C����YMM v4.35.0.0�ȍ~�p�ɕҏW����K�v������܂��B

1. �v���W�F�N�g�t�@�C�����_�u���N���b�N �܂��� `�E�N���b�N`��`�v���W�F�N�g �t�@�C����ҏW`
1. `<TargetFramework>`��`net9.0-windows10.0.19041.0`�ɕύX
1. `�r���h(B)`��`�\�����[�V�����̃N���[��(C)`�����s
```xml
<PropertyGroup>
    �@�@�@�@�@  <!-- ��������net9.0�ɕύX -->
    <TargetFramework>net9.0-windows10.0.19041.0</TargetFramework>
    <UseWPF>true</UseWPF>

    ...�ȗ�...

</PropertyGroup>
```