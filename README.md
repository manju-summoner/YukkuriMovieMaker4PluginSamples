# �������MovieMaker4 �v���O�C���T���v���W

> [!NOTE]
> YMM v4.23.0.0��.NET7����.NET8�Ɉڍs�������߁A�v���W�F�N�g��`<TargetFramework>`��`net7.0-windows10.0.19041.0`����`net8.0-windows10.0.19041.0`�ɕύX����K�v������܂��B
> �ȑO�̃o�[�W�����̏������ƂɃv���O�C�����쐬���Ă��āA`"XXX" �̈قȂ�o�[�W�����ԂŁA�����ł��Ȃ�������������܂����B`�Ƃ����x�����\������r���h�ł��Ȃ��ꍇ�A��L�̕ύX��K�p��A`�r���h(B) �� �\�����[�V�����̃N���[��(C)`�����s���Ă��������B
> �ڍׂ�[������](./Migration.md)

## �v���W�F�N�g�̍쐬���@
.NET7�p�̃N���X���C�u�����v���W�F�N�g���쐬���Ă��������B  
### �v���W�F�N�g�̐ݒ�
�v���W�F�N�g�̍쐬��A�v���W�F�N�g�t�@�C����`<TargetFramework>`��`net8.0-windows10.0.19041.0`�ɕύX���A���̉���`<UseWPF>true</UseWPF>`��ǉ����Ă��������B
```xml
<PropertyGroup>
    <TargetFramework>net8.0-windows10.0.19041.0</TargetFramework>
    <UseWPF>true</UseWPF>

    ...�ȗ�...

</PropertyGroup>
```
### �Q�Ƃ̒ǉ�
1. �\�����[�V�����G�N�X�v���[���[����`�ˑ��֌W`���E�N���b�N���A`�v���W�F�N�g�Q�Ƃ̒ǉ�(R)`���N���b�N���܂��B
1. �Q�ƃ}�l�[�W���[�E�B���h�E������`�Q��(B)`�{�^�����N���b�N���܂��B
1. YMM4���C���X�g�[�����Ă���t�H���_���ɂ���`YukkuriMovieMaker.Plugin.dll`��`YukkuriMovieMaker.Controls.dll`��I�����A`OK`�{�^�����N���b�N���܂��B
1. `OK`�{�^�����N���b�N���A�Q�ƃ}�l�[�W���[����܂��B
1. �v���O�C���̎�������`CS0012: �^'T' �́A�Q�Ƃ���Ă��Ȃ��A�Z���u���ɒ�`����Ă��܂��B�A�Z���u�� '�A�Z���u����, Version=x.x.x.x, Culture=xxx, PublicKeyToken=xxx' �ɎQ�Ƃ�ǉ�����K�v������܂��B`�ƃG���[���\�����ꂽ�ꍇ�A�K�v�ɉ�����YMM4�t�H���_���ɂ���`�A�Z���u����.dll`���Q�Ƃɒǉ����Ă��������B

## �v���O�C���̓ǂݍ���
�r���h��A`YMM4�t�H���_\user\plugin\`�t�H���_����`�v���O�C�����t�H���_`���쐬���A`�v���O�C����.dll`��ۑ����Ă��������B  
YMM4�t�H���_���ɑ��݂��Ȃ�dll��ǂݍ���ł���ꍇ�A����dll���ꏏ�ɃR�s�[���Ă��������B  

�v���O�C��������ɓǂݍ��܂ꂽ�ꍇ�AYMM4��`�ݒ�`��`�v���O�C��`��`�v���O�C���ꗗ`�Ƀv���O�C�������\������܂��B

## �v���O�C���̔z�z�p�p�b�P�[�W��
�v���O�C����`.ymme`�`���Ŕz�z���邱�Ƃɂ��A�����N���b�N�Ńv���O�C�����C���X�g�[���ł���悤�ɂȂ�܂��B
1. �쐬�����v���O�C����zip�ň��k����
1. zip�t�@�C���̊g���q��`.ymme`�ɕύX����
1. `.ymme`�t�@�C����z�z����

## �T���v���ꗗ
### �����ǂݍ��݃v���O�C��
- [SampleAudioSourcePlugin](./SampleAudioSourcePlugin/)

### �f���ǂݍ��݃v���O�C��
- [SampleVideoSourcePlugin](./SampleVideoSourcePlugin/)

### �摜�ǂݍ��݃v���O�C��
- [SampleWICImageSourcePlugin](./SampleWICImageSourcePlugin/)

### �����G�ǂݍ��݃v���O�C��
- [SampleTachiePlugin](./SampleTachiePlugin/)

### �}�`�v���O�C��
- [SampleShapePlugin](./SampleShapePlugin/)

### �g�`�v���O�C��
- [SampleAudioSpectrumPlugin](./SampleAudioSpectrumPlugin/)

### ���揑���o���v���O�C��
- [SampleVideoFileWriterPlugin](./SampleVideoFileWriterPlugin/)

### �����G�t�F�N�g
- [SampleAudioEffect](./SampleAudioEffect/)

### �f���G�t�F�N�g
- [SampleVideoEffects](./SampleVideoEffects/)

### ���������v���O�C��
- [SampleSAPI5VoicePlugin](./SampleSAPI5VoicePlugin/)

### AI�e�L�X�g�⊮�v���O�C��
- [SampleTextCompletionPlugin](./SampleTextCompletionPlugin/)

### �����ꉻ�v���O�C��
- [SampleLocalizePlugin](./SampleLocalizePlugin/)

### �R���g���[���̈ꗗ�ƃJ�X�^���R���g���[��
- [SamplePropertyEditors](./SamplePropertyEditors/)

### ��ʐ؂�ւ��v���O�C��
- [SampleTransitionPlugin](./SampleTransitionPlugin/)

�A�C�e���ҏW�G���A�ŗ��p�ł���R���g���[���̈ꗗ�ƁA�J�X�^���R���g���[���̃T���v���ł�

## ���|�W�g���̃g�s�b�N
�v���O�C����GitHub�Ō��J����ꍇ�A����������̂��߃��|�W�g����[Topics��](https://docs.github.com/ja/repositories/managing-your-repositorys-settings-and-features/customizing-your-repository/classifying-your-repository-with-topics)�Ɉȉ��̃g�s�b�N��ݒ肷�邱�Ƃ𐄏����܂��B

| ��� | �g�s�b�N |
| --- | --- |
| ���� | [ymm4-plugin](https://github.com/topics/ymm4-plugin) |
| �����ǂݍ��݃v���O�C�� | [ymm4-audio-source](https://github.com/topics/ymm4-audio-source) |
| �f���ǂݍ��݃v���O�C�� | [ymm4-video-source](https://github.com/topics/ymm4-video-source) |
| �摜�ǂݍ��݃v���O�C�� | [ymm4-image-source](https://github.com/topics/ymm4-image-source) |
| �����G�v���O�C�� | [ymm4-tachie](https://github.com/topics/ymm4-tachie) |
| �}�`�v���O�C�� | [ymm4-shape](https://github.com/topics/ymm4-shape) |
| �g�`�v���O�C�� | [ymm4-audio-spectrum](https://github.com/topics/ymm4-audio-spectrum) |
| ����o�̓v���O�C�� | [ymm4-video-writer](https://github.com/topics/ymm4-video-writer) |
| �����G�t�F�N�g | [ymm4-audio-effect](https://github.com/topics/ymm4-audio-effect) |
| �f���G�t�F�N�g | [ymm4-video-effect](https://github.com/topics/ymm4-video-effect) |
| ���������v���O�C�� | [ymm4-voice](https://github.com/topics/ymm4-voice) |
| AI�e�L�X�g�⊮�v���O�C�� | [ymm4-text-completion](https://github.com/topics/ymm4-text-completion) |
| ��ʐ؂�ւ��v���O�C�� | [ymm4-transition](https://github.com/topics/ymm4-transition) |

## X�iTwitter�j�n�b�V���^�O
�v���O�C����Twitter�Ō��J����ꍇ�A����������̂��߈ȉ��̃n�b�V���^�O��ݒ肷�邱�Ƃ𐄏����܂��B

| ��� | �n�b�V���^�O |
| --- | --- |
| ���� | [#YMM4Plugin](https://twitter.com/search?q=%23YMM4Plugin) |

## BOOTH �^�O
�v���O�C����BOOTH�Ō��J����ꍇ�A����������̂��߈ȉ��̃n�b�V���^�O��ݒ肷�邱�Ƃ𐄏����܂��B

| ��� | �^�O |
| --- | --- |
| ���� | [#YMM4Plugin](https://booth.pm/ja/search/YMM4Plugin) |